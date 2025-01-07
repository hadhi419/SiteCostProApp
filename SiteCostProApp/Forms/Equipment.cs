using Google.Api.Gax.ResourceNames;
using Google.Cloud.Firestore;
using SiteCostProApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteCostProApp.Forms
{
    public partial class Equipment : Form
    {

        public string ProjectName = "";
        public Equipment(string _projectName)
        {
            InitializeComponent();
            lblProjectName.Text = "PROJECT: " + _projectName;
            EquipmentDataGrid.Font = new Font("Arial", 12, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            ProjectName = _projectName;
        }

        private async void Equipment_Load(object sender, EventArgs e)
        {
            var equipmentDetails = new List<EquipmentProperty>();

            int defaultRowCount = 10;
            // Add default empty material entries


            EquipmentDataGrid.CellValueChanged += EquipmentDataGrid_CellValueChanged;

            var db = FirestoreHelper.Database;
            try
            {
                // Get the document reference from Firestore
                DocumentReference docRef = db.Collection("Projects").Document(ProjectName);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> documentData = snapshot.ToDictionary();

                    if (documentData.ContainsKey("Equipments"))
                    {
                        var equipmentList = documentData["Equipments"] as IEnumerable<object>;

                        if (equipmentList == null || !equipmentList.Any())
                        {
                            MessageBox.Show("Equipments array is empty.");
                            //return;
                        }

                        // Fill material details from Firestore data
                        foreach (var equipment in equipmentList)
                        {
                            var equipmentMap = equipment as Dictionary<string, object>;
                            if (equipmentMap == null) continue;

                            // Add material data to the list
                            equipmentDetails.Add(new EquipmentProperty
                            {
                                Equipment_Name = equipmentMap.ContainsKey("Equipment_Name") ? equipmentMap["Equipment_Name"]?.ToString() : "Unknown",
                                Usage_Time = equipmentMap.ContainsKey("Usage_Time") ? equipmentMap["Usage_Time"]?.ToString() : "Unknown",
                                Unit_Price = equipmentMap.ContainsKey("Unit_Price") ? equipmentMap["Unit_Price"]?.ToString() : "Unknown",
                                Total = equipmentMap.ContainsKey("Total") ? equipmentMap["Total"]?.ToString() : "Unknown"
                            });
                        }

                        // Bind the list to the DataGridView
                        EquipmentDataGrid.DataSource = new BindingList<EquipmentProperty>(equipmentDetails);
                        txtEquipmentCost.Text = GetTotal("Total").ToString();
                    }
                    else
                    {
                        MessageBox.Show("No equipments found in the document.");
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
            comboBoxColumn.Items.AddRange(new string[] { "Hours","Days" });

            // Insert the ComboBox column next to the Quantity column
            EquipmentDataGrid.Columns.Insert(2, comboBoxColumn); // Adjust the index as needed
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            // Check if the current row count is exceeded by user input
          
        }

        private void EquipmentDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the current row count is exceeded by user input
            if (e.RowIndex == EquipmentDataGrid.RowCount - 1 && e.ColumnIndex != -1)
            {
                // Automatically add a new row if user starts typing in the last row
                var materialDetails = (BindingList<MaterialProperty>)EquipmentDataGrid.DataSource;
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

        double EquipmwntTotal;

        private void UpdateResultColumn(int rowIndex)
        {
            // Get the values from UnitPrice and Quantity columns
            string unitPriceText = EquipmentDataGrid.Rows[rowIndex].Cells["Unit_Price"].Value?.ToString() ?? "0";
            string quantityText = EquipmentDataGrid.Rows[rowIndex].Cells["Usage_Time"].Value?.ToString() ?? "0";

            // Try parsing the values to double
            if (double.TryParse(unitPriceText, out double unitPrice) && double.TryParse(quantityText, out double quantity))
            {
                // Multiply the values
                double result = unitPrice * quantity;

                // Set the result in the Total column
                EquipmentDataGrid.Rows[rowIndex].Cells["Total"].Value = result.ToString(); // Format to 2 decimal places
            }
            else
            {
                // If parsing fails, set the result as "Invalid input"
                EquipmentDataGrid.Rows[rowIndex].Cells["Total"].Value = "Invalid input";
            }

            // Update the MaterialCost textbox with the updated total
            txtEquipmentCost.Text = GetTotal("Total").ToString("F2");

            // Update the MaterialTotal value
            EquipmwntTotal = GetTotal("Total");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double total = GetTotal("Total");
            //MessageBox.Show(total.ToString());

            UpdateEquipmentsToFirestore(ProjectName);

            ProjectDetails projectDetails = new ProjectDetails(ProjectName, 00, total);
            projectDetails.Show();
            this.Hide();
        }


        private async Task UpdateEquipmentsToFirestore(string projectName)
        {
            try
            {
                // Get the Firestore database instance
                var db = FirestoreHelper.Database;

                // Retrieve data from the DataGridView
                var updatedEquipments = new List<EquipmentProperty>();

                foreach (DataGridViewRow row in EquipmentDataGrid.Rows)
                {
                    // Skip new or empty rows
                    if (row.IsNewRow || row.Cells["Equipment_Name"].Value == null)
                        continue;

                    // Create a MaterialProperty object from DataGridView row
                    var equipment = new EquipmentProperty
                    {
                        Equipment_Name = row.Cells["Equipment_Name"].Value.ToString(),
                        //Unit = row.Cells["Unit"].Value?.ToString() ?? "",
                        Unit_Price = row.Cells["Unit_Price"].Value?.ToString() ?? "",
                        Usage_Time = row.Cells["Usage_Time"].Value?.ToString() ?? "",
                        Total = row.Cells["Total"].Value?.ToString() ?? ""

                    };

                    updatedEquipments.Add(equipment);
                }

                // Update only the Materials field in Firestore
                var projectRef = db.Collection("Projects").Document(projectName);
                await projectRef.UpdateAsync("Equipments", updatedEquipments);

                MessageBox.Show("Equipments updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating equipments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double GetTotal(string columnName)
        {
            double sum = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in EquipmentDataGrid.Rows)
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
    }
}
