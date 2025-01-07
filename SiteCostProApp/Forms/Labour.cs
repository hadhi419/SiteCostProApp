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
    public partial class Labour : Form
    {

        string projectName;
        public Labour(string _projectName)
        {
            InitializeComponent();
            lblProjectName.Text = "PROJECT: " + projectName;
            labourDataGridView.Font = new Font("Arial", 12, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            projectName = _projectName;
        }

        private async void Labour_Load(object sender, EventArgs e)
        {

            txtLabourCost.Text = GetTotal("Total").ToString();
            var labourDetails = new List<LabourProperty>();

            int defaultRowCount = 10;
            // Add default empty material entries


            labourDataGridView.CellValueChanged += labourDataGridView_CellValueChanged;

            var db = FirestoreHelper.Database;
            try
            {
                // Get the document reference from Firestore
                DocumentReference docRef = db.Collection("Projects").Document(projectName);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> documentData = snapshot.ToDictionary();

                    if (documentData.ContainsKey("Labour"))
                    {
                        var laboursList = documentData["Labour"] as IEnumerable<object>;

                        if (laboursList == null || !laboursList.Any())
                        {
                            MessageBox.Show("Labours array is empty.");
                            //return;
                        }

                        // Fill material details from Firestore data
                        foreach (var labour in laboursList)
                        {
                            var labourMap = labour as Dictionary<string, object>;
                            if (labourMap == null) continue;

                            // Add material data to the list
                            labourDetails.Add(new LabourProperty
                            {
                                Labour_Type = labourMap.ContainsKey("Labour_Type") ? labourMap["Labour_Type"]?.ToString() : "Unknown",
                                Work_Time = labourMap.ContainsKey("Work_Time") ? labourMap["Work_Time"]?.ToString() : "Unknown",
                                Unit = labourMap.ContainsKey("Unit") ? labourMap["Unit"]?.ToString() : "Unknown",
                                Unit_Vage = labourMap.ContainsKey("Unit_Vage") ? labourMap["Unit_Vage"]?.ToString() : "Unknown",
                                Total = labourMap.ContainsKey("Total") ? labourMap["Total"]?.ToString() : "Unknown"
                            });
                        }

                        // Bind the list to the DataGridView
                        // Bind the list to the DataGridView
                        labourDataGridView.DataSource = new BindingList<LabourProperty>(labourDetails);

                        txtLabourCost.Text = GetTotal("Total").ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Labours found in the document.");
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

        private void labourDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the current row count is exceeded by user input
            if (e.RowIndex == labourDataGridView.RowCount - 1 && e.ColumnIndex != -1)
            {
                // Automatically add a new row if user starts typing in the last row
                var materialDetails = (BindingList<MaterialProperty>)labourDataGridView.DataSource;
                materialDetails.Add(new MaterialProperty());
            }

            if (e.RowIndex < 0)
                return;

            // Calculate total only if Unit Price changes (check for column index of Unit_Price)
            if (e.ColumnIndex == 3) // Assuming Unit_Price is in column index 3
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
        double LabourTotal;
        private void UpdateResultColumn(int rowIndex)
        {
            // Get the values from UnitPrice and Quantity columns
            string workTimeText = labourDataGridView.Rows[rowIndex].Cells["Work_Time"].Value?.ToString() ?? "0";
            string unitVageText = labourDataGridView.Rows[rowIndex].Cells["Unit_Vage"].Value?.ToString() ?? "0";

            // Try parsing the values to double
            if (double.TryParse(workTimeText, out double workTime) && double.TryParse(unitVageText, out double unitVage))
            {
                // Multiply the values
                double result = workTime * unitVage;

                // Set the result in the Total column
                labourDataGridView.Rows[rowIndex].Cells["Total"].Value = result.ToString(); // Format to 2 decimal places
            }
            else
            {
                // If parsing fails, set the result as "Invalid input"
                labourDataGridView.Rows[rowIndex].Cells["Total"].Value = "Invalid input";
            }

            // Update the MaterialCost textbox with the updated total
            labourDataGridView.Text = GetTotal("Total").ToString("F2");
            txtLabourCost.Text = GetTotal("Total").ToString("F2");
            // Update the MaterialTotal value
            LabourTotal = GetTotal("Total");
        }

        private double GetTotal(string columnName)
        {
            double sum = 0;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in labourDataGridView.Rows)
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
            labourDataGridView.Columns.Insert(2, comboBoxColumn); // Adjust the index as needed
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            // Check if the current row count is exceeded by user input
            if (e.RowIndex == labourDataGridView.RowCount - 1)
            {
                // Automatically add a new row if user starts typing in the last row
                labourDataGridView.Rows.Add();
            }

            if (e.RowIndex < 0)
                return;

            // Calculate total only if Quantity or Unit Price changes
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3) // Quantity or Unit Price column index
            {
                try
                {
                    // Parse Quantity and Unit Price
                    var labourTypeCell = labourDataGridView.Rows[e.RowIndex].Cells[1].Value;
                    var unitPriceCell = labourDataGridView.Rows[e.RowIndex].Cells[3].Value;

                    if (labourTypeCell != null && unitPriceCell != null)
                    {
                        if (decimal.TryParse(labourTypeCell.ToString(), out decimal quantity) &&
                            decimal.TryParse(unitPriceCell.ToString(), out decimal unitPrice))
                        {
                            // Calculate total
                            decimal total = quantity * unitPrice;

                            // Set total value in the Total column
                            labourDataGridView.Rows[e.RowIndex].Cells[4].Value = total.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            labourDataGridView.Rows[e.RowIndex].Cells[4].Value = "Invalid";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error calculating total: " + ex.Message);
                }
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            double total = GetTotal("Total");
            //MessageBox.Show(total.ToString());

            UpdateLaboursToFirestore(projectName);

            ProjectDetails projectDetails = new ProjectDetails(projectName, 00, 00, total);
            projectDetails.Show();
            this.Hide();
        }


        private async Task UpdateLaboursToFirestore(string projectName)
        {
            try
            {
                // Get the Firestore database instance
                var db = FirestoreHelper.Database;

                // Retrieve data from the DataGridView
                var updatedLabours = new List<LabourProperty>();

                foreach (DataGridViewRow row in labourDataGridView.Rows)
                {
                    // Skip new or empty rows
                    if (row.IsNewRow || row.Cells["Labour_Type"].Value == null)
                        continue;

                    // Create a MaterialProperty object from DataGridView row
                    var labour = new LabourProperty
                    {
                        Labour_Type = row.Cells["Labour_Type"].Value.ToString(),
                        Unit = row.Cells["Unit"].Value?.ToString() ?? "",
                        Work_Time = row.Cells["Work_Time"].Value?.ToString() ?? "",
                        Unit_Vage = row.Cells["Unit_vage"].Value?.ToString() ?? "",
                        Total = row.Cells["Total"].Value?.ToString() ?? ""

                    };

                    updatedLabours.Add(labour);
                }

                // Update only the Materials field in Firestore
                var projectRef = db.Collection("Projects").Document(projectName);
                await projectRef.UpdateAsync("Labour", updatedLabours);

                MessageBox.Show("Labours updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating equipments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}

