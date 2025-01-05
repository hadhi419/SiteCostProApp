namespace SiteCostProApp.Forms
{
    partial class Homepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnBudget = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnQuote = new System.Windows.Forms.Button();
            this.lblwelcome = new System.Windows.Forms.Label();
            this.lblbelowWelcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnProject);
            this.panel1.Controls.Add(this.btnBudget);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnQuote);
            this.panel1.Location = new System.Drawing.Point(-5, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 45);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "SiteCost Pro";
            // 
            // btnProject
            // 
            this.btnProject.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProject.Location = new System.Drawing.Point(807, 0);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(100, 45);
            this.btnProject.TabIndex = 4;
            this.btnProject.Text = "Projects";
            this.btnProject.UseVisualStyleBackColor = false;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnBudget
            // 
            this.btnBudget.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBudget.Location = new System.Drawing.Point(906, 0);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(124, 45);
            this.btnBudget.TabIndex = 2;
            this.btnBudget.Text = "Budgeting";
            this.btnBudget.UseVisualStyleBackColor = false;
            this.btnBudget.Click += new System.EventHandler(this.btnBudget_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHome.Location = new System.Drawing.Point(704, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(108, 45);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnQuote
            // 
            this.btnQuote.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuote.Location = new System.Drawing.Point(1027, 0);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Size = new System.Drawing.Size(145, 45);
            this.btnQuote.TabIndex = 3;
            this.btnQuote.Text = "Quotations";
            this.btnQuote.UseVisualStyleBackColor = false;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // lblwelcome
            // 
            this.lblwelcome.AutoSize = true;
            this.lblwelcome.Font = new System.Drawing.Font("Microsoft YaHei", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwelcome.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblwelcome.Location = new System.Drawing.Point(30, 69);
            this.lblwelcome.Name = "lblwelcome";
            this.lblwelcome.Size = new System.Drawing.Size(484, 50);
            this.lblwelcome.TabIndex = 1;
            this.lblwelcome.Text = "Welcome to SiteCost Pro";
            // 
            // lblbelowWelcome
            // 
            this.lblbelowWelcome.AutoSize = true;
            this.lblbelowWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbelowWelcome.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblbelowWelcome.Location = new System.Drawing.Point(35, 119);
            this.lblbelowWelcome.Name = "lblbelowWelcome";
            this.lblbelowWelcome.Size = new System.Drawing.Size(457, 20);
            this.lblbelowWelcome.TabIndex = 2;
            this.lblbelowWelcome.Text = "Your all-in-one tool for construction budgeting and Quotation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(35, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(634, 69);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key SiteCost Pro features that simplifies construction management with\nprecise bu" +
    "dgeting, automated quotations, and streamlined cost tracking-\nall to make your p" +
    "rojects more efficient and error-free.\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(35, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(529, 46);
            this.label3.TabIndex = 4;
            this.label3.Text = " 1. Quotation Generation\r\n     Automatically generate professional quotations for" +
    " clients\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(35, 502);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(559, 69);
            this.label4.TabIndex = 5;
            this.label4.Text = " 2. Cost Tracking\r\n     Track budget  by category to stay on budget and reduce er" +
    "rors\r\n\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(35, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(454, 92);
            this.label5.TabIndex = 6;
            this.label5.Text = " 3. Enter Budget Details\r\n     Add expenses for material, labour and other costs\r" +
    "\n\r\n\r\n";
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 867);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblbelowWelcome);
            this.Controls.Add(this.lblwelcome);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Homepage";
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.Button btnQuote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblwelcome;
        private System.Windows.Forms.Label lblbelowWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}