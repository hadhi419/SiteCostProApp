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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SiteCostProApp.Forms
{
    public partial class OpenExisting : Form
    {
        public OpenExisting()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var db = FirestoreHelper.Database;
            DocumentReference docref = db.Collection("Projects").Document(txtProjectName.Text);
            ProjectDetailsPropeties data = docref.GetSnapshotAsync().Result.ConvertTo<ProjectDetailsPropeties>();

            if (data != null) {
                ProjectDetails projectDetails = new ProjectDetails(txtProjectName.Text);
                //projectDetails.txtEquipment = data.Labour.


            
            }
        }
    }
}
