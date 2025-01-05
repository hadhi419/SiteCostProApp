namespace SiteCostProApp.Forms
{
    partial class BudgetCalculator
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblLabour = new System.Windows.Forms.Label();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.lblMisc = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtEquipment = new System.Windows.Forms.TextBox();
            this.txtLabour = new System.Windows.Forms.TextBox();
            this.txtMisc = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.linkMaterial = new System.Windows.Forms.LinkLabel();
            this.linkEquipment = new System.Windows.Forms.LinkLabel();
            this.linkLabour = new System.Windows.Forms.LinkLabel();
            this.linkMisc = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.lblProjectName);
            this.panel1.Location = new System.Drawing.Point(34, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 74);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblProjectName.Location = new System.Drawing.Point(21, 20);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(151, 38);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "PROJECT: ";
            this.lblProjectName.Click += new System.EventHandler(this.lblProjectName_Click);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(37, 157);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(172, 30);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material Costs";
            this.lblMaterial.Click += new System.EventHandler(this.lblMaterial_Click);
            // 
            // lblLabour
            // 
            this.lblLabour.AutoSize = true;
            this.lblLabour.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabour.Location = new System.Drawing.Point(37, 271);
            this.lblLabour.Name = "lblLabour";
            this.lblLabour.Size = new System.Drawing.Size(159, 30);
            this.lblLabour.TabIndex = 3;
            this.lblLabour.Text = "Labour Costs";
            this.lblLabour.Click += new System.EventHandler(this.lblLabour_Click);
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipment.Location = new System.Drawing.Point(37, 209);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(134, 30);
            this.lblEquipment.TabIndex = 4;
            this.lblEquipment.Text = "Equipment";
            this.lblEquipment.Click += new System.EventHandler(this.lblEquipment_Click);
            // 
            // lblMisc
            // 
            this.lblMisc.AutoSize = true;
            this.lblMisc.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisc.Location = new System.Drawing.Point(37, 328);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(169, 30);
            this.lblMisc.TabIndex = 5;
            this.lblMisc.Text = "Miscellaneous";
            this.lblMisc.Click += new System.EventHandler(this.lblMisc_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(37, 409);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(86, 30);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "TOTAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(738, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rs.";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(679, 157);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(163, 30);
            this.txtMaterial.TabIndex = 8;
            this.txtMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(679, 208);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(163, 30);
            this.txtEquipment.TabIndex = 9;
            // 
            // txtLabour
            // 
            this.txtLabour.Location = new System.Drawing.Point(679, 257);
            this.txtLabour.Name = "txtLabour";
            this.txtLabour.Size = new System.Drawing.Size(163, 30);
            this.txtLabour.TabIndex = 10;
            // 
            // txtMisc
            // 
            this.txtMisc.Location = new System.Drawing.Point(679, 312);
            this.txtMisc.Name = "txtMisc";
            this.txtMisc.Size = new System.Drawing.Size(163, 30);
            this.txtMisc.TabIndex = 11;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(679, 397);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(163, 30);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // linkMaterial
            // 
            this.linkMaterial.AutoSize = true;
            this.linkMaterial.Location = new System.Drawing.Point(244, 160);
            this.linkMaterial.Name = "linkMaterial";
            this.linkMaterial.Size = new System.Drawing.Size(45, 25);
            this.linkMaterial.TabIndex = 13;
            this.linkMaterial.TabStop = true;
            this.linkMaterial.Text = "Edit";
            this.linkMaterial.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMaterial_LinkClicked);
            // 
            // linkEquipment
            // 
            this.linkEquipment.AutoSize = true;
            this.linkEquipment.Location = new System.Drawing.Point(244, 213);
            this.linkEquipment.Name = "linkEquipment";
            this.linkEquipment.Size = new System.Drawing.Size(45, 25);
            this.linkEquipment.TabIndex = 14;
            this.linkEquipment.TabStop = true;
            this.linkEquipment.Text = "Edit";
            this.linkEquipment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEquipment_LinkClicked);
            // 
            // linkLabour
            // 
            this.linkLabour.AutoSize = true;
            this.linkLabour.Location = new System.Drawing.Point(244, 271);
            this.linkLabour.Name = "linkLabour";
            this.linkLabour.Size = new System.Drawing.Size(45, 25);
            this.linkLabour.TabIndex = 15;
            this.linkLabour.TabStop = true;
            this.linkLabour.Text = "Edit";
            this.linkLabour.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabour_LinkClicked);
            // 
            // linkMisc
            // 
            this.linkMisc.AutoSize = true;
            this.linkMisc.Location = new System.Drawing.Point(244, 332);
            this.linkMisc.Name = "linkMisc";
            this.linkMisc.Size = new System.Drawing.Size(45, 25);
            this.linkMisc.TabIndex = 16;
            this.linkMisc.TabStop = true;
            this.linkMisc.Text = "Edit";
            this.linkMisc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMisc_LinkClicked);
            // 
            // BudgetCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 519);
            this.Controls.Add(this.linkMisc);
            this.Controls.Add(this.linkLabour);
            this.Controls.Add(this.linkEquipment);
            this.Controls.Add(this.linkMaterial);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtMisc);
            this.Controls.Add(this.txtLabour);
            this.Controls.Add(this.txtEquipment);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblMisc);
            this.Controls.Add(this.lblEquipment);
            this.Controls.Add(this.lblLabour);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BudgetCalculator";
            this.Text = "BudgetCalculator";
            this.Load += new System.EventHandler(this.BudgetCalculator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblLabour;
        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.Label lblMisc;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtEquipment;
        private System.Windows.Forms.TextBox txtLabour;
        private System.Windows.Forms.TextBox txtMisc;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.LinkLabel linkMaterial;
        private System.Windows.Forms.LinkLabel linkEquipment;
        private System.Windows.Forms.LinkLabel linkLabour;
        private System.Windows.Forms.LinkLabel linkMisc;
    }
}