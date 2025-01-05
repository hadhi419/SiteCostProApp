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
    }
}
