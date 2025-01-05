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
    
    public partial class Homepage : Form
    {
        private Button activeButton;
        public Homepage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            SetActiveButton(btnHome);
            btnHome.FlatAppearance.BorderSize = 0;
            btnProject.FlatAppearance.BorderSize = 0;
            btnBudget.FlatAppearance.BorderSize = 0;
            btnQuote.FlatAppearance.BorderSize = 0;

            btnHome.MouseEnter += Btn_MouseEnter;
            btnHome.MouseLeave += Btn_MouseLeave;

            btnProject.MouseEnter += Btn_MouseEnter;
            btnProject.MouseLeave += Btn_MouseLeave;

            btnBudget.MouseEnter += Btn_MouseEnter;
            btnBudget.MouseLeave += Btn_MouseLeave;

            btnQuote.MouseEnter += Btn_MouseEnter;
            btnQuote.MouseLeave += Btn_MouseLeave;
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            // Change background color on hover
            Button button = sender as Button;
            if (button != null && button != activeButton)
            {
                button.BackColor = Color.LightBlue; // Set hover color
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            // Reset to default color when mouse leaves
            Button button = sender as Button;
            if (button != null && button != activeButton)
            {
                button.BackColor = Color.DarkSlateGray; // Default color
            }
        }

        private void SetActiveButton(Button button)
        {
            if (activeButton != null && button != activeButton)
            {
                // Reset the previously active button to its default style
                activeButton.BackColor = Color.DarkSlateGray;
                activeButton.ForeColor = Color.White;
            }

            // Set the new active button's style
            activeButton = button;
            activeButton.BackColor = Color.White; // Highlight color
            activeButton.ForeColor = Color.Black; // Optional: change text color
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProject_Click(object sender, EventArgs e)
        {

            // Navigate to the HomePageForm
            Projects1 projects1 = new Projects1();
            projects1.Show();
            this.Hide();
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            
        }
    }
}

