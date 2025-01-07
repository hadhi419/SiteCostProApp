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

        double materialTotal = 0;
        double equipmentTotal = 0;
        double labourlTotal = 0;
        double miscelleneousTotal = 0;

        public ProjectDetails(string projectName, double _materialTotal)
        {
            InitializeComponent();
            ProjectName = projectName;
            lblProject.Text = ProjectName;
            txtMaterial.Text = _materialTotal.ToString();
            materialTotal = _materialTotal;
        }

        public ProjectDetails(string projectName, double _materialTotal, double _equipmentTotal)
        {
            InitializeComponent();
            ProjectName = projectName;
            lblProject.Text = ProjectName;
            txtEquipment.Text = _equipmentTotal.ToString();
            equipmentTotal = _equipmentTotal;
        }
        
        public ProjectDetails(string projectName, double _materialTotal, double _equipmentTotal, double _labourTotal)
        {
            InitializeComponent();
            ProjectName = projectName;
            lblProject.Text = ProjectName;
            txtLabour.Text = _labourTotal.ToString();
            labourlTotal = _labourTotal;
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



                if (documentData.ContainsKey("Labour"))
                {
                    var laboursList = documentData["Labour"] as IEnumerable<object>;
                    if (laboursList == null || !laboursList.Any())
                    {
                        //MessageBox.Show("Materials array is empty.");
                        //return;
                    }

                    // Calculate the total
                    int total = 0;
                    foreach (var labour in laboursList)
                    {
                        if (labour is Dictionary<string, object> labourMap && labourMap.ContainsKey("Total"))
                        {
                            total += Convert.ToInt32(labourMap["Total"] ?? 0);
                        }
                    }

                    // Update the UI with the total
                    txtLabour.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("No Labour found in the document.");
                }



                if (documentData.ContainsKey("Equipments"))
                {
                    var equipmentsList = documentData["Equipments"] as IEnumerable<object>;
                    if (equipmentsList == null || !equipmentsList.Any())
                    {
                        //MessageBox.Show("Materials array is empty.");
                        //return;
                    }

                    // Calculate the total
                    int total = 0;
                    foreach (var equipment in equipmentsList)
                    {
                        if (equipment is Dictionary<string, object> labourMap && labourMap.ContainsKey("Total"))
                        {
                            total += Convert.ToInt32(labourMap["Total"] ?? 0);
                        }
                    }

                    // Update the UI with the total
                   txtEquipment.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("No Labour found in the document.");
                }

                if (documentData.ContainsKey("Miscellaneous"))
                {
                    var miscellaneousList = documentData["Miscellaneous"] as IEnumerable<object>;
                    if (miscellaneousList == null || !miscellaneousList.Any())
                    {
                        //MessageBox.Show("Materials array is empty.");
                        //return;
                    }

                    // Calculate the total
                    int total = 0;
                    foreach (var miscellaneous in miscellaneousList)
                    {
                        if (miscellaneous is Dictionary<string, object> materialMap && materialMap.ContainsKey("Total"))
                        {
                            total += Convert.ToInt32(materialMap["Total"] ?? 0);
                        }
                    }

                    // Update the UI with the total
                    txtMisc.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("No miscellaneous found in the document.");
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

        private void linkLabour_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Labour labour = new Labour(ProjectName);
            this.Hide();
            labour.Show();
        }

        private void linkMisc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Miscellaneous miscellaneous = new Miscellaneous(ProjectName);
            miscellaneous.Show();
            this.Hide();
        }
    }
}
