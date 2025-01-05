namespace SiteCostProApp.Forms
{
    partial class Projects
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnBudget = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnQuote = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenExisting = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.Location = new System.Drawing.Point(0, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(100, 23);
            this.lblProjectName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnProject);
            this.panel1.Controls.Add(this.btnBudget);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnQuote);
            this.panel1.Location = new System.Drawing.Point(-2, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1488, 53);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "SiteCost Pro";
            // 
            // btnProject
            // 
            this.btnProject.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProject.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProject.Location = new System.Drawing.Point(794, 3);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(108, 50);
            this.btnProject.TabIndex = 8;
            this.btnProject.Text = "Projects";
            this.btnProject.UseVisualStyleBackColor = false;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnBudget
            // 
            this.btnBudget.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBudget.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBudget.Location = new System.Drawing.Point(899, 3);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(135, 50);
            this.btnBudget.TabIndex = 6;
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
            this.btnHome.Location = new System.Drawing.Point(682, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(115, 50);
            this.btnHome.TabIndex = 5;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnQuote
            // 
            this.btnQuote.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuote.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuote.Location = new System.Drawing.Point(1031, 3);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Size = new System.Drawing.Size(136, 50);
            this.btnQuote.TabIndex = 7;
            this.btnQuote.Text = "Quotations";
            this.btnQuote.UseVisualStyleBackColor = false;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(219, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 311);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(277, 113);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(226, 29);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "+ Add a new project";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(0, 240);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 71);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "New Project";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnOpenExisting
            // 
            this.btnOpenExisting.Location = new System.Drawing.Point(483, 636);
            this.btnOpenExisting.Name = "btnOpenExisting";
            this.btnOpenExisting.Size = new System.Drawing.Size(253, 23);
            this.btnOpenExisting.TabIndex = 2;
            this.btnOpenExisting.Text = "Open Existing Project";
            this.btnOpenExisting.UseVisualStyleBackColor = true;
            this.btnOpenExisting.Click += new System.EventHandler(this.btnOpenExisting_Click);
            // 
            // Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 867);
            this.Controls.Add(this.btnOpenExisting);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Projects";
            this.Text = "Projects";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnQuote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnOpenExisting;
    }
}