using Google.Cloud.Firestore;
using SiteCostProApp.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SiteCostProApp.Forms
{
    public partial class ProjectDetails : Form
    {
        private readonly string ProjectName;

        public ProjectDetails(string projectName)
        {
            InitializeComponent();
            ProjectName = projectName;
            lblProject.Text = ProjectName;
        }

        public ProjectDetails(string projectName, double materialTotal)
        {
            InitializeComponent();
            ProjectName = projectName;
            lblProject.Text = ProjectName;
            txtMaterial.Text = materialTotal.ToString();
        }

        private async void ProjectDetails_Load(object sender, EventArgs e)
        {
            try
            {
                // Get the Firestore database instance
                var db = FirestoreHelper.Database;

                // Get the document reference
                DocumentReference docRef = db.Collection("Projects").Document(ProjectName);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    MessageBox.Show("Document does not exist.");
                    return;
                }

                // Parse Firestore data
                var documentData = snapshot.ToDictionary();
                if (documentData.ContainsKey("Materials"))
                {
                    var materialsList = documentData["Materials"] as IEnumerable<object>;
                    if (materialsList == null || !materialsList.Any())
                    {
                        //MessageBox.Show("Materials array is empty.");
                        //return;
                    }

                    // Calculate the total
                    int total = 0;
                    foreach (var material in materialsList)
                    {
                        if (material is Dictionary<string, object> materialMap && materialMap.ContainsKey("Total"))
                        {
                            total += Convert.ToInt32(materialMap["Total"] ?? 0);
                        }
                    }

                    // Update the UI with the total
                    txtMaterial.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("No materials found in the document.");
                }

                //MessageBox.Show("Materials loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading materials: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkMaterial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var material = new Material(ProjectName);
            this.Hide();
            material.Show();
        }

        private void linkEquipment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var equipment = new Equipment(ProjectName);
            this.Hide();
            equipment.Show();
        }

        private void linkMaterial_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var material = new Material(ProjectName);
            this.Hide();
            material.Show();
        }

        private void linkEquipment_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Equipment equipment = new Equipment(ProjectName);
            this.Hide();
            equipment.Show();
        }
    }
}
