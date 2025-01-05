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

namespace SiteCostProApp.Forms
{
    public partial class BudgetCalculator : Form
    {
       
        public BudgetCalculator(string projectName)
        {
            InitializeComponent();
            lblProjectName.Text = "PROJECT: " + projectName;
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        public BudgetCalculator(decimal materialSubtotal)
        {
            txtMaterial.Text = materialSubtotal.ToString("C");
        }

        public BudgetCalculator()
        {

        }
        private void BudgetCalculator_Load(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            // Initialize DataGridView columns

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblProjectName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblMaterial_Click(object sender, EventArgs e)
        {

        }

        private void lblEquipment_Click(object sender, EventArgs e)
        {

        }

        private void lblLabour_Click(object sender, EventArgs e)
        {

        }

        private void lblMisc_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkMaterial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string projectName = lblProjectName.Text.Replace("PROJECT: ", "").Trim(); // Extract the project name
            Material material = new Material(projectName);
            this.Hide(); // Hide the current form
            material.ShowDialog(); // Show the Material form
            this.Close();
        }

        private void linkEquipment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string projectName = lblProjectName.Text.Replace("PROJECT: ", "").Trim(); // Extract the project name
            Equipment equipment = new Equipment(projectName);
            this.Hide(); // Hide the login form
            equipment.ShowDialog(); // Show the homepage
            this.Close(); // Close the login form when the homepage is closed 
        }

        private void linkLabour_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {
            string projectName = lblProjectName.Text.Replace("PROJECT: ", "").Trim(); // Extract the project name
            Labour labour = new Labour(projectName);
            this.Hide(); // Hide the login form
            labour.ShowDialog(); // Show the homepage
            this.Close(); // Close the login form when the homepage is closed
        }

        private void linkMisc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string projectName = lblProjectName.Text.Replace("PROJECT: ", "").Trim(); // Extract the project name
            Miscellaneous miscellaneous = new Miscellaneous(projectName);
            this.Hide(); // Hide the login form
            miscellaneous.ShowDialog(); // Show the homepage
            this.Close(); // Close the login form when the homepage is closed
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
