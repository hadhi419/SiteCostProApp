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
    public partial class Miscellaneous : Form
    {
        string ProjectName;
        public Miscellaneous(string _projectName)
        {
            InitializeComponent();
            lblProjectName.Text = "PROJECT: " + _projectName;
            miscellaneousDataGrid.Font = new Font("Arial", 12, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            ProjectName = _projectName;
        }

        private async void Miscellaneous_Load(object sender, EventArgs e)
        {
            var miscellaneousrDetails = new List<MiscellaneousProperty>();

            int defaultRowCount = 10;
            // Add default empty material entries


            miscellaneousDataGrid.CellValueChanged += miscellaneousDataGrid_CellValueChanged;

            var db = FirestoreHelper.Database;
            try
            {
                // Get the document reference from Firestore
                DocumentReference docRef = db.Collection("Projects").Document(ProjectName);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> documentData = snapshot.ToDictionary();

                    if (documentData.ContainsKey("Miscellaneous"))
                    {
                        var miscellaneousList = documentData["Miscellaneous"] as IEnumerable<object>;

                        if (miscellaneousList == null || !miscellaneousList.Any())
                        {
                            MessageBox.Show("Materials array is empty.");
                            //return;
                        }

                        // Fill material details from Firestore data
                        foreach (var miscellaneous in miscellaneousList)
                        {
                            var miscellaneousMap = miscellaneous as Dictionary<string, object>;
                            if (miscellaneousMap == null) continue;

                            // Add material data to the list
                            miscellaneousrDetails.Add(new MiscellaneousProperty
                            {
                                Item_Name = miscellaneousMap.ContainsKey("Item_Name") ? miscellaneousMap["Item_Name"]?.ToString() : "Unknown",
                                Quantity = miscellaneousMap.ContainsKey("Quantity") ? miscellaneousMap["Quantity"]?.ToString() : "Unknown",
                                Unit_Price = miscellaneousMap.ContainsKey("Unit_Price") ? miscellaneousMap["Unit_Price"]?.ToString() : "Unknown",
                                Total = miscellaneousMap.ContainsKey("Total") ? miscellaneousMap["Total"]?.ToString() : "Unknown"
                            });
                        }

                        // Bind the list to the DataGridView
                        // Bind the list to the DataGridView
                        miscellaneousDataGrid.DataSource = new BindingList<MiscellaneousProperty>(miscellaneousrDetails);
                        txtTotalMiscellaneous.Text = GetTotal("Total").ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Miscellaneous found in the document.");
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


        private void miscellaneousDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the current row count is exceeded by user input
            if (e.RowIndex == miscellaneousDataGrid.RowCount - 1 && e.ColumnIndex != -1)
            {
                // Automatically add a new row if user starts typing in the last row
                var miscellaneousDetails = (BindingList<MiscellaneousProperty>)miscellaneousDataGrid.DataSource;
                miscellaneousDetails.Add(new MiscellaneousProperty());
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

        double miscellaneousTotal;
        private void UpdateResultColumn(int rowIndex)
        {
            // Get the values from UnitPrice and Quantity columns
            string quantityText = miscellaneousDataGrid.Rows[rowIndex].Cells["Quantity"].Value?.ToString() ?? "0";
            string unitPriceText = miscellaneousDataGrid.Rows[rowIndex].Cells["Unit_Price"].Value?.ToString() ?? "0";

            // Try parsing the values to double
            if (double.TryParse(quantityText, out double quantity) && double.TryParse(unitPriceText, out double unitPrice))
            {
                // Multiply the values
                double result = quantity * unitPrice;

                // Set the result in the Total column
                miscellaneousDataGrid.Rows[rowIndex].Cells["Total"].Value = result.ToString(); // Format to 2 decimal places
            }
            else
            {
                // If parsing fails, set the result as "Invalid input"
                miscellaneousDataGrid.Rows[rowIndex].Cells["Total"].Value = "Invalid input";
            }

            // Update the MaterialCost textbox with the updated total
            miscellaneousDataGrid.Text = GetTotal("Total").ToString("F2");
            txtTotalMiscellaneous.Text = GetTotal("Total").ToString("F2");
            // Update the MaterialTotal value
            miscellaneousTotal = GetTotal("Total");
        }

        private double GetTotal(string columnName)
        {
            double sum = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in miscellaneousDataGrid.Rows)
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

        
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            // Check if the current row count is exceeded by user input
            if (e.RowIndex == miscellaneousDataGrid.RowCount - 1)
            {
                // Automatically add a new row if user starts typing in the last row
                miscellaneousDataGrid.Rows.Add();
            }

            if (e.RowIndex < 0)
                return;

            // Calculate total only if Quantity or Unit Price changes
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3) // Quantity or Unit Price column index
            {
                try
                {
                    // Parse Quantity and Unit Price
                    var quantityCell = miscellaneousDataGrid.Rows[e.RowIndex].Cells[1].Value;
                    var unitPriceCell = miscellaneousDataGrid.Rows[e.RowIndex].Cells[3].Value;

                    if (quantityCell != null && unitPriceCell != null)
                    {
                        if (decimal.TryParse(quantityCell.ToString(), out decimal quantity) &&
                            decimal.TryParse(unitPriceCell.ToString(), out decimal unitPrice))
                        {
                            // Calculate total
                            decimal total = quantity * unitPrice;

                            // Set total value in the Total column
                            miscellaneousDataGrid.Rows[e.RowIndex].Cells[4].Value = total.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            miscellaneousDataGrid.Rows[e.RowIndex].Cells[4].Value = "Invalid";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error calculating total: " + ex.Message);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            double total = GetTotal("Total");
            //MessageBox.Show(total.ToString());

            UpdateMiscellaneousToFirestore(ProjectName);

            ProjectDetails projectDetails = new ProjectDetails(ProjectName, 00, 00, total);
            projectDetails.Show();
            this.Hide();
        }

        private async Task UpdateMiscellaneousToFirestore(string projectName)
        {
            try
            {
                // Get the Firestore database instance
                var db = FirestoreHelper.Database;

                // Retrieve data from the DataGridView
                var updatedMiscellaneous = new List<MiscellaneousProperty>();

                foreach (DataGridViewRow row in miscellaneousDataGrid.Rows)
                {
                    // Skip new or empty rows
                    if (row.IsNewRow || row.Cells["Item_Name"].Value == null)
                        continue;

                    // Create a MaterialProperty object from DataGridView row
                    var miscellaneous = new MiscellaneousProperty
                    {
                        Item_Name = row.Cells["Item_Name"].Value.ToString(),
                        Quantity = row.Cells["Quantity"].Value?.ToString() ?? "",
                        Unit_Price = row.Cells["Unit_Price"].Value?.ToString() ?? "",
                        Total = row.Cells["Total"].Value?.ToString() ?? ""

                    };

                    updatedMiscellaneous.Add(miscellaneous);
                }

                // Update only the Materials field in Firestore
                var projectRef = db.Collection("Projects").Document(projectName);
                await projectRef.UpdateAsync("Miscellaneous", updatedMiscellaneous);

                MessageBox.Show("Miscellaneous updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating equipments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
