namespace Tax_Consultant_25.Frames
{
    partial class ucShowGSTClients
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGSTClients = new System.Windows.Forms.DataGridView();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFill = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGSTClients)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvGSTClients);
            this.panel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 785);
            this.panel1.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.DarkOrange;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(259, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(105, 26);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "SHOW";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Monthly",
            "Quartely"});
            this.cmbType.Location = new System.Drawing.Point(90, 5);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(163, 28);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECT:";
            // 
            // dgvGSTClients
            // 
            this.dgvGSTClients.AllowUserToAddRows = false;
            this.dgvGSTClients.AllowUserToDeleteRows = false;
            this.dgvGSTClients.AllowUserToResizeColumns = false;
            this.dgvGSTClients.AllowUserToResizeRows = false;
            this.dgvGSTClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGSTClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGSTClients.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvGSTClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGSTClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientName,
            this.Column3,
            this.ReturnType,
            this.btnFill});
            this.dgvGSTClients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGSTClients.Location = new System.Drawing.Point(0, 39);
            this.dgvGSTClients.Name = "dgvGSTClients";
            this.dgvGSTClients.RowHeadersVisible = false;
            this.dgvGSTClients.RowHeadersWidth = 51;
            this.dgvGSTClients.RowTemplate.Height = 24;
            this.dgvGSTClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGSTClients.Size = new System.Drawing.Size(1247, 746);
            this.dgvGSTClients.TabIndex = 0;
            this.dgvGSTClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGSTClients_CellContentClick);
            this.dgvGSTClients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGSTClients_CellFormatting);
            this.dgvGSTClients.SelectionChanged += new System.EventHandler(this.dgvGSTClients_SelectionChanged);
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "c_Name";
            this.ClientName.FillWeight = 119.0031F;
            this.ClientName.HeaderText = "Name";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "c_BusinessName";
            this.Column3.FillWeight = 114.1543F;
            this.Column3.HeaderText = "Business";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // ReturnType
            // 
            this.ReturnType.DataPropertyName = "GSTForm";
            this.ReturnType.FillWeight = 104.6621F;
            this.ReturnType.HeaderText = "Return";
            this.ReturnType.MinimumWidth = 6;
            this.ReturnType.Name = "ReturnType";
            // 
            // btnFill
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.btnFill.DefaultCellStyle = dataGridViewCellStyle4;
            this.btnFill.FillWeight = 33.07336F;
            this.btnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFill.HeaderText = "Fill ";
            this.btnFill.MinimumWidth = 6;
            this.btnFill.Name = "btnFill";
            this.btnFill.Text = "FILL";
            this.btnFill.UseColumnTextForButtonValue = true;
            // 
            // ucShowGSTClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucShowGSTClients";
            this.Size = new System.Drawing.Size(1256, 791);
            this.Load += new System.EventHandler(this.ucShowGSTClients_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGSTClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvGSTClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnType;
        private System.Windows.Forms.DataGridViewButtonColumn btnFill;
        private System.Windows.Forms.Button btnShow;
    }
}
