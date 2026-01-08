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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShowEmployeeWork = new System.Windows.Forms.DataGridView();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnReply = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowEmployeeWork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowEmployeeWork
            // 
            this.dgvShowEmployeeWork.AllowUserToAddRows = false;
            this.dgvShowEmployeeWork.AllowUserToDeleteRows = false;
            this.dgvShowEmployeeWork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnReply,
            this.EmployeeName});
            this.dgvShowEmployeeWork.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShowEmployeeWork.Location = new System.Drawing.Point(4, 10);
            this.dgvShowEmployeeWork.Margin = new System.Windows.Forms.Padding(4);
            this.dgvShowEmployeeWork.Name = "dgvShowEmployeeWork";
            this.dgvShowEmployeeWork.RowHeadersVisible = false;
            this.dgvShowEmployeeWork.RowHeadersWidth = 51;
            this.dgvShowEmployeeWork.RowTemplate.Height = 24;
            this.dgvShowEmployeeWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowEmployeeWork.Size = new System.Drawing.Size(1064, 616);
            this.dgvShowEmployeeWork.TabIndex = 3;
            this.dgvShowEmployeeWork.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowEmployeeWork_CellClick);
            this.dgvShowEmployeeWork.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvShowEmployeeWork_CellFormatting);
            this.dgvShowEmployeeWork.SelectionChanged += new System.EventHandler(this.dgvShowEmployeeWork_SelectionChanged);
            // 
            // Service
            // 
            this.Service.DataPropertyName = "service";
            this.Service.FillWeight = 67.26594F;
            this.Service.HeaderText = "Service";
            this.Service.MinimumWidth = 6;
            this.Service.Name = "Service";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "inputDate";
            this.Column2.FillWeight = 71.95868F;
            this.Column2.HeaderText = "Input Date";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "clientName";
            this.ClientName.FillWeight = 93.15478F;
            this.ClientName.HeaderText = "Name";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "workType";
            this.Column4.FillWeight = 65.42023F;
            this.Column4.HeaderText = "Work Type";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "dueDate";
            this.Column6.FillWeight = 64.7177F;
            this.Column6.HeaderText = "Due Date";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // btnQuery
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnQuery.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnQuery.FillWeight = 38.90058F;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.HeaderText = "Query";
            this.btnQuery.MinimumWidth = 6;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnQuery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnQuery.Text = "QUERY";
            this.btnQuery.UseColumnTextForButtonValue = true;
            // 
            // btnReply
            // 
            this.btnReply.DataPropertyName = "reply";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.btnReply.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnReply.FillWeight = 38.90058F;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReply.HeaderText = "Reply";
            this.btnReply.MinimumWidth = 6;
            this.btnReply.Name = "btnReply";
            this.btnReply.Text = "REPLY";
            this.btnReply.UseColumnTextForButtonValue = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.FillWeight = 67.26594F;
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.MinimumWidth = 6;
            this.EmployeeName.Name = "EmployeeName";
            // 
            // ucShowEmployeeWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvShowEmployeeWork);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucShowEmployeeWork";
            this.Size = new System.Drawing.Size(1072, 630);
            this.Load += new System.EventHandler(this.ucShowEmployeeWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowEmployeeWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowEmployeeWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn btnQuery;
        private System.Windows.Forms.DataGridViewButtonColumn btnReply;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
    }
}
