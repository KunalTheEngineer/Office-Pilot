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
            this.txtIncomeYear = new System.Windows.Forms.TextBox();
            this.lblIncomeYear = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblGSTType = new System.Windows.Forms.Label();
            this.cmbGSTType = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIncomeYear
            // 
            this.txtIncomeYear.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncomeYear.Location = new System.Drawing.Point(574, 3);
            this.txtIncomeYear.Name = "txtIncomeYear";
            this.txtIncomeYear.Size = new System.Drawing.Size(142, 27);
            this.txtIncomeYear.TabIndex = 2;
            // 
            // lblIncomeYear
            // 
            this.lblIncomeYear.AutoSize = true;
            this.lblIncomeYear.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeYear.Location = new System.Drawing.Point(507, 0);
            this.lblIncomeYear.Name = "lblIncomeYear";
            this.lblIncomeYear.Size = new System.Drawing.Size(61, 21);
            this.lblIncomeYear.TabIndex = 12;
            this.lblIncomeYear.Text = "YEAR :";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Location = new System.Drawing.Point(1222, 4);
            this.btnShow.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(132, 42);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "SHOW";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "GST",
            "INCOME TAX",
            "ACCOUNTING",
            "SHOPACT",
            "UDYAM",
            "TDS",
            "PAN/TAN",
            "PTEC/PTRC",
            "OTHER SERVICES"});
            this.cmbReportType.Location = new System.Drawing.Point(101, 3);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(142, 29);
            this.cmbReportType.TabIndex = 0;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cmbReportType);
            this.flowLayoutPanel1.Controls.Add(this.lblStatus);
            this.flowLayoutPanel1.Controls.Add(this.cmbStatus);
            this.flowLayoutPanel1.Controls.Add(this.lblIncomeYear);
            this.flowLayoutPanel1.Controls.Add(this.txtIncomeYear);
            this.flowLayoutPanel1.Controls.Add(this.lblGSTType);
            this.flowLayoutPanel1.Controls.Add(this.cmbGSTType);
            this.flowLayoutPanel1.Controls.Add(this.lblMonth);
            this.flowLayoutPanel1.Controls.Add(this.cmbMonth);
            this.flowLayoutPanel1.Controls.Add(this.btnShow);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1372, 59);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "REPORTS: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(249, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(76, 21);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "STATUS:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "PENDING",
            "DONE"});
            this.cmbStatus.Location = new System.Drawing.Point(331, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(170, 29);
            this.cmbStatus.TabIndex = 1;
            // 
            // lblGSTType
            // 
            this.lblGSTType.AutoSize = true;
            this.lblGSTType.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGSTType.Location = new System.Drawing.Point(722, 0);
            this.lblGSTType.Name = "lblGSTType";
            this.lblGSTType.Size = new System.Drawing.Size(91, 21);
            this.lblGSTType.TabIndex = 17;
            this.lblGSTType.Text = "GST TYPE:";
            // 
            // cmbGSTType
            // 
            this.cmbGSTType.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGSTType.FormattingEnabled = true;
            this.cmbGSTType.Items.AddRange(new object[] {
            "GST R-1",
            "GST R-3B",
            "GST R-4",
            "GST R-5",
            "GST R-5A",
            "GST R-6",
            "GST R-7",
            "GST R-8",
            "GST R-9",
            "GST R-10",
            "GST R-11",
            "CMP-08",
            "ITC-04",
            "IFF"});
            this.cmbGSTType.Location = new System.Drawing.Point(819, 3);
            this.cmbGSTType.Name = "cmbGSTType";
            this.cmbGSTType.Size = new System.Drawing.Size(153, 29);
            this.cmbGSTType.TabIndex = 3;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(978, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(77, 21);
            this.lblMonth.TabIndex = 21;
            this.lblMonth.Text = "MONTH:";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "JANUARY",
            "FEBRUARY",
            "MARCH",
            "APRIL",
            "MAY",
            "JUNE",
            "JULY",
            "AUGUST",
            "SEPTEMBER",
            "OCTOBER",
            "NOVEMBER",
            "DECEMBER"});
            this.cmbMonth.Location = new System.Drawing.Point(1061, 3);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(153, 29);
            this.cmbMonth.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Location = new System.Drawing.Point(4, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 651);
            this.panel1.TabIndex = 5;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1318, 651);
            this.reportViewer1.TabIndex = 1;
            // 
            // ucShowReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucShowReport";
            this.Size = new System.Drawing.Size(1325, 723);
            this.Load += new System.EventHandler(this.ucShowReport_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtIncomeYear;
        private System.Windows.Forms.Label lblIncomeYear;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGSTType;
        private System.Windows.Forms.ComboBox cmbGSTType;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
