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
    public partial class Register : Form
    {


        public Register()
        {
            InitializeComponent();
            SetPlaceholders();


        }



        private void btnSignup_Click(object sender, EventArgs e)
        {
            var db = FirestoreHelper.Database;
            if (CheckIfUserAlreadyExists())
            {
                MessageBox.Show("User Already Exists!");
                return;
            }
            var data = GetWriteData();
            DocumentReference docref = db.Collection("UserData").Document(data.email);
            docref.SetAsync(data);
            MessageBox.Show("Success!");

        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog();
            Close();    
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private UserData GetWriteData()
        {
            
            string email = txtEmail.Text.Trim();
            string password = Security.Encrypt(txtPass.Text);

            return new UserData()
            {
                email = email,
                password = password
            };
        }

        private bool CheckIfUserAlreadyExists()
        {
            string email = txtEmail.Text.Trim();


            var db = FirestoreHelper.Database;
            DocumentReference docref = db.Collection("UserData").Document(email);
            UserData data = docref.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if (data != null)
            {
                return true;
            }
            return false;
 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void SetPlaceholders()
        {
            // Set initial placeholder values
            SetPlaceholder(txtEmail, "Enter Email");
            SetPlaceholder(txtPass, "Enter Password");

            // Attach event handlers for GotFocus and LostFocus
            txtEmail.GotFocus += (s, e) => RemovePlaceholder(txtEmail, "Enter Email");
            txtEmail.LostFocus += (s, e) => SetPlaceholder(txtEmail, "Enter Email");

            txtPass.GotFocus += (s, e) => RemovePlaceholder(txtPass, "Enter Password");
            txtPass.LostFocus += (s, e) => SetPlaceholder(txtPass, "Enter Password");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray; // Set placeholder color
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black; // Reset to normal text color
            }
        }

    }
}
