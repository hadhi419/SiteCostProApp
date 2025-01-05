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
        public Miscellaneous(string projectName)
        {
            InitializeComponent();
            lblProjectName.Text = "PROJECT: " + projectName;
            dataGridView1.Font = new Font("Arial", 12, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Miscellaneous_Load(object sender, EventArgs e)
        {
            int desiredRowCount = 10;
            dataGridView1.RowCount = desiredRowCount;
            this.StartPosition = FormStartPosition.CenterScreen;



            dataGridView1.Columns[0].HeaderText = "Item Name";
            dataGridView1.Columns[1].HeaderText = "Quantity";
            dataGridView1.Columns[2].HeaderText = "Unit Price";
            dataGridView1.Columns[3].HeaderText = "Total";

            AddComboBoxColumnForMetrics();


            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
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
            comboBoxColumn.Items.AddRange(new string[] { "kg", "liters", "meters", "pieces", "bags" });

            // Insert the ComboBox column next to the Quantity column
            dataGridView1.Columns.Insert(2, comboBoxColumn); // Adjust the index as needed
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            // Check if the current row count is exceeded by user input
            if (e.RowIndex == dataGridView1.RowCount - 1)
            {
                // Automatically add a new row if user starts typing in the last row
                dataGridView1.Rows.Add();
            }

            if (e.RowIndex < 0)
                return;

            // Calculate total only if Quantity or Unit Price changes
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3) // Quantity or Unit Price column index
            {
                try
                {
                    // Parse Quantity and Unit Price
                    var quantityCell = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                    var unitPriceCell = dataGridView1.Rows[e.RowIndex].Cells[3].Value;

                    if (quantityCell != null && unitPriceCell != null)
                    {
                        if (decimal.TryParse(quantityCell.ToString(), out decimal quantity) &&
                            decimal.TryParse(unitPriceCell.ToString(), out decimal unitPrice))
                        {
                            // Calculate total
                            decimal total = quantity * unitPrice;

                            // Set total value in the Total column
                            dataGridView1.Rows[e.RowIndex].Cells[4].Value = total.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[4].Value = "Invalid";
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
            string projectName = lblProjectName.Text.Replace("PROJECT: ", "").Trim();

            // Create an instance of BudgetCalculator and pass the project name
            BudgetCalculator calc = new BudgetCalculator(projectName);
            this.Hide();
            calc.ShowDialog();
            this.Close();
        }
    }
}
