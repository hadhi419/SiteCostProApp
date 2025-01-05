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
using SiteCostProApp.Forms;



namespace SiteCostProApp.Forms
{
    public partial class LoginForm : Form
    {
        private const string EmailPlaceholder = "Enter your email";
        private const string PasswordPlaceholder = "Enter your password";
        public LoginForm()
        {
            InitializeComponent();
            //SetPlaceholder(txtEmail, EmailPlaceholder);
            //SetPlaceholder(txtPass, PasswordPlaceholder);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            Register form = new Register();
            form.Show();
            Close();
        }

        
        

        

        

        
        private async void btnSignin_Click(object sender, EventArgs e)
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


                    // Navigate to the HomePageForm
                    Homepage homePage = new Homepage();
                    this.Hide(); // Hide the login form
                    homePage.ShowDialog(); // Show the homepage
                    this.Close(); // Close the login form when the homepage is closed MessageBox.Show("Login Success!");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false; // Allow form to close
        }


    }
}
