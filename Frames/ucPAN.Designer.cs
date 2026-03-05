namespace Tax_Consultant_25.Frames
{
    partial class ucPAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPAN));
            this.dgvAllInOne = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbAllocatedTo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbWorkStatus = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFeesStatus = new System.Windows.Forms.ComboBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTradeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.dtpInputDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReply = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInOne)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllInOne
            // 
            this.dgvAllInOne.AllowUserToAddRows = false;
            this.dgvAllInOne.AllowUserToDeleteRows = false;
            this.dgvAllInOne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInOne.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAllInOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.ClName,
            this.Column4,
            this.WorkType,
            this.EmployeeName,
            this.Column6,
            this.btnReply,
            this.Column7,
            this.Status,
            this.Column3});
            this.dgvAllInOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInOne.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllInOne.Location = new System.Drawing.Point(0, 0);
            this.dgvAllInOne.Name = "dgvAllInOne";
            this.dgvAllInOne.RowHeadersVisible = false;
            this.dgvAllInOne.RowHeadersWidth = 51;
            this.dgvAllInOne.RowTemplate.Height = 24;
            this.dgvAllInOne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllInOne.Size = new System.Drawing.Size(1313, 508);
            this.dgvAllInOne.TabIndex = 4;
            this.dgvAllInOne.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInOne_CellClick);
            this.dgvAllInOne.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAllInOne_CellFormatting);
            this.dgvAllInOne.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAllInOne_DataBindingComplete);
            this.dgvAllInOne.SelectionChanged += new System.EventHandler(this.dgvAllInOne_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbAllocatedTo);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cmbWorkStatus);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbFeesStatus);
            this.panel2.Controls.Add(this.txtFees);
            this.panel2.Controls.Add(this.txtClientName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTradeName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpDueDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTaskName);
            this.panel2.Controls.Add(this.dtpInputDate);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1314, 139);
            this.panel2.TabIndex = 0;
            // 
            // cmbAllocatedTo
            // 
            this.cmbAllocatedTo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbAllocatedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllocatedTo.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllocatedTo.FormattingEnabled = true;
            this.cmbAllocatedTo.Location = new System.Drawing.Point(23, 91);
            this.cmbAllocatedTo.Name = "cmbAllocatedTo";
            this.cmbAllocatedTo.Size = new System.Drawing.Size(238, 29);
            this.cmbAllocatedTo.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(69, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 21);
            this.label20.TabIndex = 92;
            this.label20.Text = "ASSIGNED TO";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(948, 67);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(327, 62);
            this.txtDescription.TabIndex = 9;
            this.txtDescription.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(818, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 21);
            this.label9.TabIndex = 90;
            this.label9.Text = "DESCRIPTION:";
            // 
            // cmbWorkStatus
            // 
            this.cmbWorkStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbWorkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkStatus.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWorkStatus.FormattingEnabled = true;
            this.cmbWorkStatus.Items.AddRange(new object[] {
            "Not Started",
            "Waiting For Documents",
            "Document Received",
            "Return Prepaired",
            "Cancelled",
            "Complete",
            "Done"});
            this.cmbWorkStatus.Location = new System.Drawing.Point(582, 90);
            this.cmbWorkStatus.Name = "cmbWorkStatus";
            this.cmbWorkStatus.Size = new System.Drawing.Size(229, 28);
            this.cmbWorkStatus.TabIndex = 8;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(673, 67);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 21);
            this.label24.TabIndex = 86;
            this.label24.Text = "STATUS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 21);
            this.label7.TabIndex = 87;
            this.label7.Text = "FEES AMT.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(442, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 88;
            this.label8.Text = "FEES STATUS";
            // 
            // cmbFeesStatus
            // 
            this.cmbFeesStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeesStatus.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFeesStatus.FormattingEnabled = true;
            this.cmbFeesStatus.Items.AddRange(new object[] {
            "PENDING",
            "PAID"});
            this.cmbFeesStatus.Location = new System.Drawing.Point(420, 91);
            this.cmbFeesStatus.Name = "cmbFeesStatus";
            this.cmbFeesStatus.Size = new System.Drawing.Size(150, 29);
            this.cmbFeesStatus.TabIndex = 7;
            // 
            // txtFees
            // 
            this.txtFees.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFees.Location = new System.Drawing.Point(278, 90);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(136, 29);
            this.txtFees.TabIndex = 6;
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(201, 29);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(254, 29);
            this.txtClientName.TabIndex = 1;
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged);
            this.txtClientName.Leave += new System.EventHandler(this.txtClientName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 82;
            this.label2.Text = "CLIENT NAME";
            // 
            // txtTradeName
            // 
            this.txtTradeName.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradeName.Location = new System.Drawing.Point(479, 29);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(323, 29);
            this.txtTradeName.TabIndex = 2;
            this.txtTradeName.Leave += new System.EventHandler(this.txtTradeName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1130, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 78;
            this.label3.Text = "DUE DATE";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(1097, 29);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(178, 29);
            this.dtpDueDate.TabIndex = 4;
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(578, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 79;
            this.label4.Text = "TRADE NAME";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(890, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 77;
            this.label5.Text = "TASK NAME";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskName.Location = new System.Drawing.Point(835, 32);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(227, 29);
            this.txtTaskName.TabIndex = 3;
            // 
            // dtpInputDate
            // 
            this.dtpInputDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInputDate.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInputDate.Location = new System.Drawing.Point(23, 29);
            this.dtpInputDate.Name = "dtpInputDate";
            this.dtpInputDate.Size = new System.Drawing.Size(154, 29);
            this.dtpInputDate.TabIndex = 0;
            this.dtpInputDate.ValueChanged += new System.EventHandler(this.dtpInputDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 21);
            this.label6.TabIndex = 73;
            this.label6.Text = "START DATE";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvAllInOne);
            this.panel1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1313, 508);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Location = new System.Drawing.Point(4, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1313, 51);
            this.panel3.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(634, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 37);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(520, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 37);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(420, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 37);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "p_InputDate";
            this.Column2.FillWeight = 80.20885F;
            this.Column2.HeaderText = "START DATE";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // ClName
            // 
            this.ClName.DataPropertyName = "clientName";
            this.ClName.HeaderText = "NAME";
            this.ClName.MinimumWidth = 6;
            this.ClName.Name = "ClName";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "p_TradeName";
            this.Column4.FillWeight = 132.9587F;
            this.Column4.HeaderText = "TRADE NAME";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // WorkType
            // 
            this.WorkType.DataPropertyName = "p_TaskName";
            this.WorkType.FillWeight = 135.721F;
            this.WorkType.HeaderText = "TASK NAME";
            this.WorkType.MinimumWidth = 6;
            this.WorkType.Name = "WorkType";
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "p_AllocatedTo";
            this.EmployeeName.FillWeight = 126.0884F;
            this.EmployeeName.HeaderText = "ASSIGNED TO";
            this.EmployeeName.MinimumWidth = 6;
            this.EmployeeName.Name = "EmployeeName";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "p_DueDate";
            this.Column6.FillWeight = 73.38605F;
            this.Column6.HeaderText = "DUE DATE";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // btnReply
            // 
            this.btnReply.FillWeight = 72.78397F;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReply.HeaderText = "REPLY";
            this.btnReply.MinimumWidth = 6;
            this.btnReply.Name = "btnReply";
            this.btnReply.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnReply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnReply.Text = "REPLY";
            this.btnReply.UseColumnTextForButtonValue = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "p_FeeStatus";
            this.Column7.FillWeight = 81.62328F;
            this.Column7.HeaderText = "FEES STATUS";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "p_Status";
            this.Status.FillWeight = 118.4807F;
            this.Status.HeaderText = "STATUS";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "p_Description";
            this.Column3.FillWeight = 132.4815F;
            this.Column3.HeaderText = "DESCRIPTION";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // ucPAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ucPAN";
            this.Size = new System.Drawing.Size(1320, 716);
            this.Load += new System.EventHandler(this.ucPAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInOne)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAllInOne;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbAllocatedTo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbWorkStatus;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbFeesStatus;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTradeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.DateTimePicker dtpInputDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn btnReply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
