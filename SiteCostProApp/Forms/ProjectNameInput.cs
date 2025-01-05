using Google.Cloud.Firestore;
using Google.Type;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SiteCostProApp.Forms
{
    public partial class ProjectNameInput : Form
    {
        public ProjectNameInput()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(25, 12);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(200, 22);
            this.txtProjectName.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(90, 55);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ProjectNameForm
            // 
            this.ClientSize = new System.Drawing.Size(280, 100);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtProjectName);
            this.Name = "ProjectNameForm";
            this.Text = "Enter Project Name";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void ProjectNameInput_Load(object sender, EventArgs e)
        {
            
        }

        //public string ProjectName { get; set; }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            // Validate the input (ensure it's not empty)
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                MessageBox.Show("Please enter a project name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                var db = FirestoreHelper.Database;

                var data = GetWriteData(txtProjectName.Text);
                    
                DocumentReference docref = db.Collection("Projects").Document(txtProjectName.Text);
                await docref.SetAsync(data);
                MessageBox.Show("Success!");
                
                string ProjectName = txtProjectName.Text;
                ProjectDetails projectDetails = new ProjectDetails(ProjectName);
                projectDetails.Show();
                this.Hide();
                
            }
        }



        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private ProjectDetailsPropeties GetWriteData(string projectName)
        {
            // Create an empty Project object with no values in each list
            return new ProjectDetailsPropeties()
            {
                ProjectName = projectName,
                Materials = new List<MaterialProperty>(),  // Empty list for Materials
                Equipments = new List<EquipmentProperty>(), // Empty list for Equipments
                Labour = new List<LabourProperty>(),        // Empty list for Labour
                Miscellaneous = new List<MiscellaneousProperty>() // Empty list for Miscellaneous
            };
        }

    }
}

