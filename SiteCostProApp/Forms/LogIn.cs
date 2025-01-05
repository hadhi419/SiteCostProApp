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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }




        private  void btnSignin_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPass.Text;

            var db = FirestoreHelper.Database;
            DocumentReference docref = db.Collection("UserData").Document(email);
            UserData data = docref.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if (data != null)
            {
                if (password == Security.Decrypt(data.password))
                {
                    Homepage homepage = new Homepage();
                    homepage.Show();
                    this.Hide();

                    
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
        }
    }
}
