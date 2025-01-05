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
    public partial class Projects : Form
    {
        //private Button activeButton;
        private Label lblProjectName;
        public Projects()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            Projects projects = new Projects();
            this.Hide();
            this.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Homepage homePage = new Homepage();
            this.Hide(); // Hide the login form
            homePage.ShowDialog(); // Show the homepage
            this.Close(); // Close the login form when the homepage is closed   
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {

        }

        private void btnQuote_Click(object sender, EventArgs e)
        {

        }

        //private void Projects_Load(object sender, EventArgs e)
        //{
        //    CenterPanel(panel2);
        //    //SetActiveButton(btnProject);
        //    btnHome.FlatAppearance.BorderSize = 0;
        //    btnProject.FlatAppearance.BorderSize = 0;
        //    btnBudget.FlatAppearance.BorderSize = 0;
        //    btnQuote.FlatAppearance.BorderSize = 0;

        //    btnHome.MouseEnter += Btn_MouseEnter;
        //    //btnHome.MouseLeave += Btn_MouseLeave;

        //    btnProject.MouseEnter += Btn_MouseEnter;
        //    //btnProject.MouseLeave += Btn_MouseLeave;

        //    btnBudget.MouseEnter += Btn_MouseEnter;
        //   // btnBudget.MouseLeave += Btn_MouseLeave;

        //    btnQuote.MouseEnter += Btn_MouseEnter;
        //   // btnQuote.MouseLeave += Btn_MouseLeave;
        //}

        //private void Btn_MouseEnter(object sender, EventArgs e)
        //{
        //    // Change background color on hover
        //    Button button = sender as Button;
        //    if (button != null && button != activeButton)
        //    {
        //        button.BackColor = Color.LightBlue; // Set hover color
        //    }
        //}

        //private void Btn_MouseLeave(object sender, EventArgs e)
        //{
        //    // Reset to default color when mouse leaves
        //    Button button = sender as Button;
        //    if (button != null && button != activeButton)
        //    {
        //        button.BackColor = Color.DarkSlateGray; // Default color
        //    }
        //}

        private void CenterPanel(Panel panel)
        {
            // Calculate the center position of the panel relative to the form
            int x = (this.ClientSize.Width - panel.Width) / 2;
            int y = (this.ClientSize.Height - panel.Height) / 2;

            // Set the panel's location
            panel.Location = new Point(x, y);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            BudgetCalculator calculator = new BudgetCalculator();
            this.Hide();
            calculator.Show();
        }

        //private void SetActiveButton(Button button)
        //{
        //    if (activeButton != null && button != activeButton)
        //    {
        //        // Reset the previously active button to its default style
        //        activeButton.BackColor = Color.DarkSlateGray;
        //        activeButton.ForeColor = Color.White;
        //    }

        //    // Set the new active button's style
        //    activeButton = button;
        //    activeButton.BackColor = Color.White; // Highlight color
        //    activeButton.ForeColor \= Color.Black; // Optional: change text color
        //}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BudgetCalculator calculator = new BudgetCalculator();
            this.Hide();
            calculator.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            BudgetCalculator calculator = new BudgetCalculator();
            this.Hide();
            calculator.Show();
        }

        private void btnOpenExisting_Click(object sender, EventArgs e)
        {

        }
    }
}
