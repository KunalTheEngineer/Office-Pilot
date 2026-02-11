namespace Tax_Consultant_25.Frames
{
    partial class ucAccounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAccounting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cmbPeriodicity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.cmbWorkStatus = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtTradeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRecurringTask = new System.Windows.Forms.ComboBox();
            this.cmbAllocatedTo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.dtpInputDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.txtWorkPeriod = new System.Windows.Forms.TextBox();
            this.lblDynamic1 = new System.Windows.Forms.Label();
            this.dgvAllInOne = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReply = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInOne)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.cmbPeriodicity);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtClientName);
            this.panel2.Controls.Add(this.cmbWorkStatus);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtYear);
            this.panel2.Controls.Add(this.txtTradeName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.dtpDueDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbRecurringTask);
            this.panel2.Controls.Add(this.cmbAllocatedTo);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtTaskName);
            this.panel2.Controls.Add(this.dtpInputDate);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtWorkPeriod);
            this.panel2.Controls.Add(this.lblDynamic1);
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1306, 209);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(987, 97);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(307, 99);
            this.txtDescription.TabIndex = 70;
            this.txtDescription.Text = "";
            // 
            // cmbPeriodicity
            // 
            this.cmbPeriodicity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbPeriodicity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodicity.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriodicity.FormattingEnabled = true;
            this.cmbPeriodicity.Items.AddRange(new object[] {
            "DAILY",
            "WEEKLY",
            "MONTHLY",
            "QUARTERLY",
            "HALF YEARLY",
            "YEARLY"});
            this.cmbPeriodicity.Location = new System.Drawing.Point(393, 101);
            this.cmbPeriodicity.Name = "cmbPeriodicity";
            this.cmbPeriodicity.Size = new System.Drawing.Size(172, 29);
            this.cmbPeriodicity.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1094, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 21);
            this.label5.TabIndex = 71;
            this.label5.Text = "DESCRIPTION\r\n";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(161, 32);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(254, 29);
            this.txtClientName.TabIndex = 69;
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged);
            this.txtClientName.Leave += new System.EventHandler(this.txtClientName_Leave);
            // 
            // cmbWorkStatus
            // 
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
            this.cmbWorkStatus.Location = new System.Drawing.Point(740, 102);
            this.cmbWorkStatus.Name = "cmbWorkStatus";
            this.cmbWorkStatus.Size = new System.Drawing.Size(234, 28);
            this.cmbWorkStatus.TabIndex = 68;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(227, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 21);
            this.label18.TabIndex = 70;
            this.label18.Text = "CLIENT NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(803, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 69;
            this.label6.Text = "STATUS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(590, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 21);
            this.label4.TabIndex = 67;
            this.label4.Text = "FINANCIAL YEAR";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(571, 101);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(163, 29);
            this.txtYear.TabIndex = 66;
            // 
            // txtTradeName
            // 
            this.txtTradeName.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradeName.Location = new System.Drawing.Point(421, 32);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(323, 29);
            this.txtTradeName.TabIndex = 68;
            this.txtTradeName.Leave += new System.EventHandler(this.txtTradeName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 21);
            this.label3.TabIndex = 70;
            this.label3.Text = "PERIODICITY";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(983, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 21);
            this.label21.TabIndex = 66;
            this.label21.Text = "DUE DATE";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(959, 32);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(157, 29);
            this.dtpDueDate.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(516, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 67;
            this.label1.Text = "TRADE NAME";
            // 
            // cmbRecurringTask
            // 
            this.cmbRecurringTask.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbRecurringTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecurringTask.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecurringTask.FormattingEnabled = true;
            this.cmbRecurringTask.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.cmbRecurringTask.Location = new System.Drawing.Point(229, 101);
            this.cmbRecurringTask.Name = "cmbRecurringTask";
            this.cmbRecurringTask.Size = new System.Drawing.Size(154, 29);
            this.cmbRecurringTask.TabIndex = 69;
            // 
            // cmbAllocatedTo
            // 
            this.cmbAllocatedTo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbAllocatedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllocatedTo.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllocatedTo.FormattingEnabled = true;
            this.cmbAllocatedTo.Location = new System.Drawing.Point(6, 101);
            this.cmbAllocatedTo.Name = "cmbAllocatedTo";
            this.cmbAllocatedTo.Size = new System.Drawing.Size(214, 29);
            this.cmbAllocatedTo.TabIndex = 62;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(24, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 21);
            this.label20.TabIndex = 65;
            this.label20.Text = "ASSIGNED TO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 21);
            this.label2.TabIndex = 68;
            this.label2.Text = "RECURRING TASK";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(800, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 21);
            this.label19.TabIndex = 64;
            this.label19.Text = "TASK NAME";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskName.Location = new System.Drawing.Point(751, 32);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(202, 29);
            this.txtTaskName.TabIndex = 61;
            // 
            // dtpInputDate
            // 
            this.dtpInputDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInputDate.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInputDate.Location = new System.Drawing.Point(5, 32);
            this.dtpInputDate.Name = "dtpInputDate";
            this.dtpInputDate.Size = new System.Drawing.Size(149, 29);
            this.dtpInputDate.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 21);
            this.label17.TabIndex = 38;
            this.label17.Text = "START DATE";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // txtWorkPeriod
            // 
            this.txtWorkPeriod.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkPeriod.Location = new System.Drawing.Point(1126, 32);
            this.txtWorkPeriod.Name = "txtWorkPeriod";
            this.txtWorkPeriod.Size = new System.Drawing.Size(168, 29);
            this.txtWorkPeriod.TabIndex = 1;
            // 
            // lblDynamic1
            // 
            this.lblDynamic1.AutoSize = true;
            this.lblDynamic1.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDynamic1.Location = new System.Drawing.Point(1150, 8);
            this.lblDynamic1.Name = "lblDynamic1";
            this.lblDynamic1.Size = new System.Drawing.Size(126, 21);
            this.lblDynamic1.TabIndex = 46;
            this.lblDynamic1.Text = "WORK PERIOD";
            // 
            // dgvAllInOne
            // 
            this.dgvAllInOne.AllowUserToAddRows = false;
            this.dgvAllInOne.AllowUserToDeleteRows = false;
            this.dgvAllInOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllInOne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInOne.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAllInOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.ClientName,
            this.WorkType,
            this.Column3,
            this.Column6,
            this.EmployeeName,
            this.Status,
            this.Column4,
            this.btnReply});
            this.dgvAllInOne.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllInOne.Location = new System.Drawing.Point(0, 0);
            this.dgvAllInOne.Name = "dgvAllInOne";
            this.dgvAllInOne.RowHeadersVisible = false;
            this.dgvAllInOne.RowHeadersWidth = 51;
            this.dgvAllInOne.RowTemplate.Height = 24;
            this.dgvAllInOne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllInOne.Size = new System.Drawing.Size(1307, 449);
            this.dgvAllInOne.TabIndex = 4;
            this.dgvAllInOne.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInOne_CellClick);
            this.dgvAllInOne.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAllInOne_CellFormatting);
            this.dgvAllInOne.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAllInOne_DataBindingComplete);
            this.dgvAllInOne.SelectionChanged += new System.EventHandler(this.dgvAllInOne_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Location = new System.Drawing.Point(4, 218);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1307, 46);
            this.panel3.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(634, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 37);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
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
            this.btnUpdate.TabIndex = 7;
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
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvAllInOne);
            this.panel1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1307, 449);
            this.panel1.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "serial";
            this.Column1.FillWeight = 57.11466F;
            this.Column1.HeaderText = "SR.";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "a_InputDate";
            this.Column2.FillWeight = 71.49169F;
            this.Column2.HeaderText = "START DT.";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "clientName";
            this.ClientName.FillWeight = 130.0702F;
            this.ClientName.HeaderText = "NAME";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            // 
            // WorkType
            // 
            this.WorkType.DataPropertyName = "a_TaskName";
            this.WorkType.FillWeight = 164.8167F;
            this.WorkType.HeaderText = "TASK NAME";
            this.WorkType.MinimumWidth = 6;
            this.WorkType.Name = "WorkType";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "a_FinancialYear";
            this.Column3.FillWeight = 51.76474F;
            this.Column3.HeaderText = "YEAR";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "a_DueDate";
            this.Column6.FillWeight = 70.71504F;
            this.Column6.HeaderText = "DUE DT.";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "a_AllocatedEmpName";
            this.EmployeeName.FillWeight = 132.2916F;
            this.EmployeeName.HeaderText = "ASSIGNED TO";
            this.EmployeeName.MinimumWidth = 6;
            this.EmployeeName.Name = "EmployeeName";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "a_Status";
            this.Status.FillWeight = 121.1653F;
            this.Status.HeaderText = "STATUS";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "a_Description";
            this.Column4.FillWeight = 164.3037F;
            this.Column4.HeaderText = "DESCRIPTION";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // btnReply
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Crimson;
            this.btnReply.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnReply.FillWeight = 54.44823F;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReply.HeaderText = "REPLY";
            this.btnReply.MinimumWidth = 6;
            this.btnReply.Name = "btnReply";
            this.btnReply.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnReply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnReply.Text = "REPLY";
            // 
            // ucAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ucAccounting";
            this.Size = new System.Drawing.Size(1325, 723);
            this.Load += new System.EventHandler(this.ucAccounting_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInOne)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDynamic1;
        private System.Windows.Forms.TextBox txtWorkPeriod;
        private System.Windows.Forms.DataGridView dgvAllInOne;
        private System.Windows.Forms.DateTimePicker dtpInputDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTradeName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAllocatedTo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.ComboBox cmbPeriodicity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRecurringTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWorkStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn btnReply;
    }
}
