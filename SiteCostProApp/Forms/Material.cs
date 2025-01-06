using Google.Api.Gax.ResourceNames;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiteCostProApp.Classes;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;


namespace SiteCostProApp.Forms
{
    public partial class Material : Form
    {
        String ProjectName;
        public Material(string _projectName)
        {
            InitializeComponent();
            lblProjectName.Text = "PROJECT: " + ProductName;
            materialDataGridView.Font = new Font("Arial", 12, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            ProjectName = _projectName;


        }



        private async void Material_Load(object sender, EventArgs e)
        {

            // Initialize the material list
            var materialDetails = new List<MaterialProperty>();

            int defaultRowCount = 10;
            // Add default empty material entries
            

            materialDataGridView.CellValueChanged += dmaterialDataGridView_CellValueChanged;

            var db = FirestoreHelper.Database;
            try
            {
                // Get the document reference from Firestore
                DocumentReference docRef = db.Collection("Projects").Document(ProjectName);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> documentData = snapshot.ToDictionary();

                    if (documentData.ContainsKey("Materials"))
                    {
                        var materialsList = documentData["Materials"] as IEnumerable<object>;

                        if (materialsList == null || !materialsList.Any())
                        {
                            MessageBox.Show("Materials array is empty.");
                            //return;
                        }

                        // Fill material details from Firestore data
                        foreach (var material in materialsList)
                        {
                            var materialMap = material as Dictionary<string, object>;
                            if (materialMap == null) continue;

                            // Add material data to the list
                            materialDetails.Add(new MaterialProperty
                            {
                                Material_Name = materialMap.ContainsKey("Material_Name") ? materialMap["Material_Name"]?.ToString() : "Unknown",
                                Quantity = materialMap.ContainsKey("Quantity") ? materialMap["Quantity"]?.ToString() : "Unknown",
                                Unit = materialMap.ContainsKey("Unit") ? materialMap["Unit"]?.ToString() : "Unknown",
                                Unit_Price = materialMap.ContainsKey("Unit_Price") ? materialMap["Unit_Price"]?.ToString() : "Unknown",
                                Total = materialMap.ContainsKey("Total") ? materialMap["Total"]?.ToString() : "Unknown"
                            });
                        }

                        // Bind the list to the DataGridView
                        materialDataGridView.DataSource = new BindingList<MaterialProperty>(materialDetails);
                    }
                    else
                    {
                        MessageBox.Show("No materials found in the document.");
                    }
                }
                else
                {
                    MessageBox.Show("Document does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }






        }










        private void dmaterialDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the current row count is exceeded by user input
            if (e.RowIndex == materialDataGridView.RowCount - 1 && e.ColumnIndex != -1)
            {
                // Automatically add a new row if user starts typing in the last row
                var materialDetails = (BindingList<MaterialProperty>)materialDataGridView.DataSource;
                materialDetails.Add(new MaterialProperty());
            }

            if (e.RowIndex < 0)
                return;

            // Calculate total only if Unit Price changes (check for column index of Unit_Price)
            if (e.ColumnIndex == 2) // Assuming Unit_Price is in column index 3
            {
                try
                {
                    // Call UpdateResultColumn to update the Total column
                    UpdateResultColumn(e.RowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error calculating total: " + ex.Message);
                }
            }
        }

        double MaterialTotal;

        private void UpdateResultColumn(int rowIndex)
        {
            // Get the values from UnitPrice and Quantity columns
            string unitPriceText = materialDataGridView.Rows[rowIndex].Cells["Unit_Price"].Value?.ToString() ?? "0";
            string quantityText = materialDataGridView.Rows[rowIndex].Cells["Quantity"].Value?.ToString() ?? "0";

            // Try parsing the values to double
            if (double.TryParse(unitPriceText, out double unitPrice) && double.TryParse(quantityText, out double quantity))
            {
                // Multiply the values
                double result = unitPrice * quantity;

                // Set the result in the Total column
                materialDataGridView.Rows[rowIndex].Cells["Total"].Value = result.ToString(); // Format to 2 decimal places
            }
            else
            {
                // If parsing fails, set the result as "Invalid input"
                materialDataGridView.Rows[rowIndex].Cells["Total"].Value = "Invalid input";
            }

            // Update the MaterialCost textbox with the updated total
            txtMaterialCost.Text = GetTotal("Total").ToString("F2");

            // Update the MaterialTotal value
            MaterialTotal = GetTotal("Total");
        }





        private void AddComboBoxColumnForMetrics()
        {
            // Create the ComboBox column
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Unit",
                Name = "ColumnUnit",
                DataPropertyName = "Unit",
                FlatStyle = FlatStyle.Flat
            };

            // Add metrics to the ComboBox
            comboBoxColumn.Items.AddRange(new string[] { "Hours", "Days" });

            // Insert the ComboBox column next to the Quantity column
            materialDataGridView.Columns.Insert(2, comboBoxColumn); // Adjust the index as needed
        }


        private double GetColumnSum(string columnName)
        {
            double sum = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in materialDataGridView.Rows)
            {
                // Ensure the cell value is not null or empty
                if (row.Cells[columnName].Value != null && row.Cells[columnName].Value.ToString() != string.Empty)
                {
                    // Add the value to sum (convert it to double)
                    sum += Convert.ToDouble(row.Cells[columnName].Value);
                }
            }

            return sum;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            double total = GetTotal("Total");
            //MessageBox.Show(total.ToString());

            UpdateMaterialsToFirestore(ProjectName);

            ProjectDetails projectDetails = new ProjectDetails(ProjectName, total);
            projectDetails.Show();
            this.Hide();
        }

        private async Task UpdateMaterialsToFirestore(string projectName)
        {
            try
            {
                // Get the Firestore database instance
                var db = FirestoreHelper.Database;

                // Retrieve data from the DataGridView
                var updatedMaterials = new List<MaterialProperty>();

                foreach (DataGridViewRow row in materialDataGridView.Rows)
                {
                    // Skip new or empty rows
                    if (row.IsNewRow || row.Cells["Material_Name"].Value == null)
                        continue;

                    // Create a MaterialProperty object from DataGridView row
                    var material = new MaterialProperty
                    {
                        Material_Name = row.Cells["Material_Name"].Value.ToString(),
                        Unit = row.Cells["Unit"].Value?.ToString() ?? "",
                        Unit_Price = row.Cells["Unit_Price"].Value?.ToString() ?? "",
                        Quantity = row.Cells["Quantity"].Value?.ToString() ?? "",
                        Total = row.Cells["Total"].Value?.ToString() ?? ""

                    };

                    updatedMaterials.Add(material);
                }

                // Update only the Materials field in Firestore
                var projectRef = db.Collection("Projects").Document(projectName);
                await projectRef.UpdateAsync("Materials", updatedMaterials);

                MessageBox.Show("Materials updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating materials: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private double GetTotal(string columnName)
        {
            double sum = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in materialDataGridView.Rows)
            {
                // Ensure the cell value is not null or empty
                if (row.Cells[columnName].Value != null && row.Cells[columnName].Value.ToString() != string.Empty)
                {
                    // Add the value to sum (convert it to double)
                    sum += Convert.ToDouble(row.Cells[columnName].Value);
                }
            }

            return sum;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
