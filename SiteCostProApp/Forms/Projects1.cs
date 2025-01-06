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
    public partial class Projects1 : Form
    {
        public Projects1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectNameInput projectNameInput = new ProjectNameInput();
            this.Hide();
            projectNameInput.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Projects1_Load(object sender, EventArgs e)
        {
            var db = FirestoreHelper.Database;

            ProjectsFlowLayout.Controls.Clear();

            

            try
            {
                // Get all documents in the "Projects" collection
                QuerySnapshot projectsSnapshot = await db.Collection("Projects").GetSnapshotAsync();

                if (projectsSnapshot.Documents.Count > 0)
                {
                    foreach (var document in projectsSnapshot.Documents)
                    {
                        // Get project data
                        Dictionary<string, object> projectData = document.ToDictionary();
                        string projectName = projectData.ContainsKey("ProjectName") ? projectData["ProjectName"]?.ToString() : "Unnamed Project";

                        // Create a new button or panel for the project
                        Button projectButton = new Button
                        {
                            Text = projectName,
                            Tag = document.Id, // Store document ID for future use
                            Size = new Size(560,50), // Set button size
                            Margin = new Padding(10), // Margin around the button
                            Padding = new Padding(5), // Padding inside the button
                            BackColor = Color.LightBlue, // Button background color
                            FlatStyle = FlatStyle.Flat, // Flat style for modern UI
                           // Location = new Point(250, 157), // Set location on the form
                            TextAlign = ContentAlignment.MiddleCenter // Center the text in the button
                        };
                        projectButton.FlatAppearance.BorderSize = 0;

                        // Attach a click event handler to navigate to the project details
                        projectButton.Click += (s, args) =>
                        {
                            string projectId = (s as Button)?.Tag.ToString();
                            LoadProjectDetails(projectId);
                        };

                        // Add the button to the FlowLayoutPanel
                        ProjectsFlowLayout.Controls.Add(projectButton);
                    }
                }
                else
                {
                    MessageBox.Show("No projects found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }


        }

        private void LoadProjectDetails(string projectName)
        {
            // Navigate to the project details page or load details for the project
            MessageBox.Show($"Selected project ID: {projectName}");

            ProjectDetails projectDetails = new ProjectDetails(projectName);

            projectDetails.Show();
            // Add your navigation logic here
        }
    }
}
