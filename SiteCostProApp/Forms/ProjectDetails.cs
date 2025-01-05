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
    public partial class ProjectDetails : Form
    {

        string ProjectName = "";
        public ProjectDetails(string projectName)
        {
            InitializeComponent();
            this.ProjectName = projectName;
            lblProject.Text = ProjectName;

        }

        public ProjectDetails(string projectName, double MaterialTotal)
        {
            InitializeComponent();
            this.ProjectName = projectName;
            lblProject.Text = ProjectName;
            txtMaterial.Text = MaterialTotal.ToString();

        }

        private void ProjectDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void linkMaterial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Material material = new Material(ProjectName);
            this.Hide();
            material.Show();
        }

        private void linkEquipment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Equipment equipment = new Equipment(ProjectName);   
            this.Hide();
            equipment.Show();
        }
    }
}
