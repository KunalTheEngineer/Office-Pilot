namespace Tax_Consultant_25.Frames
{
    partial class ucShowReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIncomeYear = new System.Windows.Forms.TextBox();
            this.lblIncomeYear = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.txtFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtupToDate = new System.Windows.Forms.DateTimePicker();
            this.lblUptoDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMonth);
            this.panel1.Controls.Add(this.cmbMonth);
            this.panel1.Controls.Add(this.txtIncomeYear);
            this.panel1.Controls.Add(this.lblIncomeYear);
            this.panel1.Controls.Add(this.lblService);
            this.panel1.Controls.Add(this.lblReport);
            this.panel1.Controls.Add(this.txtFromDate);
            this.panel1.Controls.Add(this.txtupToDate);
            this.panel1.Controls.Add(this.lblUptoDate);
            this.panel1.Controls.Add(this.lblFromDate);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1401, 73);
            this.panel1.TabIndex = 2;
            // 
            // txtIncomeYear
            // 
            this.txtIncomeYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncomeYear.Location = new System.Drawing.Point(893, 23);
            this.txtIncomeYear.Name = "txtIncomeYear";
            this.txtIncomeYear.Size = new System.Drawing.Size(142, 28);
            this.txtIncomeYear.TabIndex = 13;
            // 
            // lblIncomeYear
            // 
            this.lblIncomeYear.AutoSize = true;
            this.lblIncomeYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeYear.Location = new System.Drawing.Point(836, 26);
            this.lblIncomeYear.Name = "lblIncomeYear";
            this.lblIncomeYear.Size = new System.Drawing.Size(68, 20);
            this.lblIncomeYear.TabIndex = 12;
            this.lblIncomeYear.Text = "YEAR :";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(13, 29);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(64, 22);
            this.lblService.TabIndex = 11;
            this.lblService.Text = "label1";
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(19, 22);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(0, 29);
            this.lblReport.TabIndex = 10;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.CustomFormat = "dd/MM/yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFromDate.Location = new System.Drawing.Point(702, 23);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(202, 28);
            this.txtFromDate.TabIndex = 9;
            // 
            // txtupToDate
            // 
            this.txtupToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtupToDate.CustomFormat = "dd/MM/yyyy";
            this.txtupToDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtupToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtupToDate.Location = new System.Drawing.Point(1041, 23);
            this.txtupToDate.Name = "txtupToDate";
            this.txtupToDate.Size = new System.Drawing.Size(200, 28);
            this.txtupToDate.TabIndex = 8;
            // 
            // lblUptoDate
            // 
            this.lblUptoDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUptoDate.AutoSize = true;
            this.lblUptoDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUptoDate.Location = new System.Drawing.Point(910, 26);
            this.lblUptoDate.Name = "lblUptoDate";
            this.lblUptoDate.Size = new System.Drawing.Size(125, 20);
            this.lblUptoDate.TabIndex = 7;
            this.lblUptoDate.Text = "UPTO DATE : ";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(567, 28);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(129, 20);
            this.lblFromDate.TabIndex = 6;
            this.lblFromDate.Text = "FROM DATE : ";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(1262, 14);
            this.btnShow.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(132, 42);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Location = new System.Drawing.Point(5, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1401, 563);
            this.panel2.TabIndex = 3;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1399, 561);
            this.reportViewer1.TabIndex = 0;
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "Spetember",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(879, 22);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(156, 28);
            this.cmbMonth.TabIndex = 14;
            // 
            // lblMonth
            // 
            this.lblMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(984, 26);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(86, 20);
            this.lblMonth.TabIndex = 15;
            this.lblMonth.Text = "MONTH :";
            // 
            // ucShowReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucShowReport";
            this.Size = new System.Drawing.Size(1411, 660);
            this.Load += new System.EventHandler(this.ucShowReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.DateTimePicker txtFromDate;
        private System.Windows.Forms.DateTimePicker txtupToDate;
        private System.Windows.Forms.Label lblUptoDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.TextBox txtIncomeYear;
        private System.Windows.Forms.Label lblIncomeYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
    }
}
