namespace Tax_Consultant_25.Frames
{
    partial class ucShowEmployeeWork
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShowEmployeeWork = new System.Windows.Forms.DataGridView();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowEmployeeWork)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShowEmployeeWork
            // 
            this.dgvShowEmployeeWork.AllowUserToAddRows = false;
            this.dgvShowEmployeeWork.AllowUserToDeleteRows = false;
            this.dgvShowEmployeeWork.AllowUserToResizeRows = false;
            this.dgvShowEmployeeWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowEmployeeWork.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvShowEmployeeWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowEmployeeWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Service,
            this.Column2,
            this.ClientName,
            this.Column4,
            this.Column6,
            this.btnQuery,
            this.Status,
            this.Column1,
            this.EmployeeName});
            this.dgvShowEmployeeWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowEmployeeWork.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShowEmployeeWork.Location = new System.Drawing.Point(0, 0);
            this.dgvShowEmployeeWork.Margin = new System.Windows.Forms.Padding(4);
            this.dgvShowEmployeeWork.Name = "dgvShowEmployeeWork";
            this.dgvShowEmployeeWork.RowHeadersVisible = false;
            this.dgvShowEmployeeWork.RowHeadersWidth = 51;
            this.dgvShowEmployeeWork.RowTemplate.Height = 24;
            this.dgvShowEmployeeWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowEmployeeWork.Size = new System.Drawing.Size(1320, 716);
            this.dgvShowEmployeeWork.TabIndex = 3;
            this.dgvShowEmployeeWork.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvShowEmployeeWork_CellFormatting);
            this.dgvShowEmployeeWork.SelectionChanged += new System.EventHandler(this.dgvShowEmployeeWork_SelectionChanged);
            // 
            // Service
            // 
            this.Service.DataPropertyName = "service";
            this.Service.FillWeight = 51.11872F;
            this.Service.HeaderText = "SERVICE";
            this.Service.MinimumWidth = 6;
            this.Service.Name = "Service";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "inputDate";
            this.Column2.FillWeight = 54.19965F;
            this.Column2.HeaderText = "START DATE";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "clientName";
            this.ClientName.FillWeight = 88.67043F;
            this.ClientName.HeaderText = "NAME";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "taskName";
            this.Column4.FillWeight = 85.44891F;
            this.Column4.HeaderText = "TASK NAME";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "dueDate";
            this.Column6.FillWeight = 49.7905F;
            this.Column6.HeaderText = "DUE DATE";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // btnQuery
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnQuery.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnQuery.FillWeight = 53.70379F;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.HeaderText = "QUERY";
            this.btnQuery.MinimumWidth = 6;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnQuery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnQuery.Text = "QUERY";
            this.btnQuery.UseColumnTextForButtonValue = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.FillWeight = 91.29164F;
            this.Status.HeaderText = "STATUS";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "description";
            this.Column1.FillWeight = 107.2755F;
            this.Column1.HeaderText = "DESCRIPTION";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "employeeName";
            this.EmployeeName.FillWeight = 87.18474F;
            this.EmployeeName.HeaderText = "EMPLOYEE NAME";
            this.EmployeeName.MinimumWidth = 6;
            this.EmployeeName.Name = "EmployeeName";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvShowEmployeeWork);
            this.panel1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 716);
            this.panel1.TabIndex = 4;
            // 
            // ucShowEmployeeWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucShowEmployeeWork";
            this.Size = new System.Drawing.Size(1320, 716);
            this.Load += new System.EventHandler(this.ucShowEmployeeWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowEmployeeWork)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowEmployeeWork;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn btnQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
    }
}
