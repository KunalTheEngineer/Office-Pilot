namespace Tax_Consultant_25
{
    partial class frm_Query
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtQueryByEmp = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateEmp = new System.Windows.Forms.Button();
            this.btnSaveEmp = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblQueryByEmpId = new System.Windows.Forms.Label();
            this.pnlReply = new System.Windows.Forms.Panel();
            this.txtReply = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.pnlReply.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtQueryByEmp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(9, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 155);
            this.panel1.TabIndex = 0;
            // 
            // txtQueryByEmp
            // 
            this.txtQueryByEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQueryByEmp.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueryByEmp.Location = new System.Drawing.Point(93, 10);
            this.txtQueryByEmp.Name = "txtQueryByEmp";
            this.txtQueryByEmp.Size = new System.Drawing.Size(1105, 133);
            this.txtQueryByEmp.TabIndex = 1;
            this.txtQueryByEmp.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Query :";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Location = new System.Drawing.Point(22, 60);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(140, 28);
            this.lblEmpName.TabIndex = 1;
            this.lblEmpName.Text = "empName";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnUpdateEmp);
            this.panel2.Controls.Add(this.btnSaveEmp);
            this.panel2.Location = new System.Drawing.Point(9, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1216, 53);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(581, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateEmp
            // 
            this.btnUpdateEmp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateEmp.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmp.Location = new System.Drawing.Point(461, 7);
            this.btnUpdateEmp.Name = "btnUpdateEmp";
            this.btnUpdateEmp.Size = new System.Drawing.Size(100, 36);
            this.btnUpdateEmp.TabIndex = 1;
            this.btnUpdateEmp.Text = "UPDATE";
            this.btnUpdateEmp.UseVisualStyleBackColor = true;
            this.btnUpdateEmp.Click += new System.EventHandler(this.btnUpdateEmp_Click);
            // 
            // btnSaveEmp
            // 
            this.btnSaveEmp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveEmp.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEmp.Location = new System.Drawing.Point(344, 7);
            this.btnSaveEmp.Name = "btnSaveEmp";
            this.btnSaveEmp.Size = new System.Drawing.Size(100, 36);
            this.btnSaveEmp.TabIndex = 0;
            this.btnSaveEmp.Text = "SAVE";
            this.btnSaveEmp.UseVisualStyleBackColor = true;
            this.btnSaveEmp.Click += new System.EventHandler(this.btnSaveEmp_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvQuery);
            this.panel5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(9, 490);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1216, 234);
            this.panel5.TabIndex = 6;
            // 
            // dgvQuery
            // 
            this.dgvQuery.AllowUserToAddRows = false;
            this.dgvQuery.AllowUserToDeleteRows = false;
            this.dgvQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuery.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column5});
            this.dgvQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuery.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuery.Location = new System.Drawing.Point(0, 0);
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.RowHeadersVisible = false;
            this.dgvQuery.RowHeadersWidth = 51;
            this.dgvQuery.RowTemplate.Height = 24;
            this.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuery.Size = new System.Drawing.Size(1214, 232);
            this.dgvQuery.TabIndex = 0;
            this.dgvQuery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuery_CellClick);
            this.dgvQuery.SelectionChanged += new System.EventHandler(this.dgvQuery_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "queryClientName";
            this.Column1.FillWeight = 73.1505F;
            this.Column1.HeaderText = "Client";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "queryServiceName";
            this.Column6.FillWeight = 76.47024F;
            this.Column6.HeaderText = "Service";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "queryWorkType";
            this.Column7.FillWeight = 58.56437F;
            this.Column7.HeaderText = "Work";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "queryByEmp";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FillWeight = 208.8668F;
            this.Column2.HeaderText = "Query";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "querySolution";
            this.Column3.FillWeight = 204.2587F;
            this.Column3.HeaderText = "Sol.";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "insertedDate";
            this.Column5.FillWeight = 62.6466F;
            this.Column5.HeaderText = "In. Date";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // lblQueryByEmpId
            // 
            this.lblQueryByEmpId.AutoSize = true;
            this.lblQueryByEmpId.Location = new System.Drawing.Point(52, 32);
            this.lblQueryByEmpId.Name = "lblQueryByEmpId";
            this.lblQueryByEmpId.Size = new System.Drawing.Size(52, 16);
            this.lblQueryByEmpId.TabIndex = 8;
            this.lblQueryByEmpId.Text = "queryId";
            this.lblQueryByEmpId.Visible = false;
            // 
            // pnlReply
            // 
            this.pnlReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReply.Controls.Add(this.txtReply);
            this.pnlReply.Controls.Add(this.label1);
            this.pnlReply.Location = new System.Drawing.Point(9, 254);
            this.pnlReply.Name = "pnlReply";
            this.pnlReply.Size = new System.Drawing.Size(1216, 171);
            this.pnlReply.TabIndex = 2;
            // 
            // txtReply
            // 
            this.txtReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReply.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReply.Location = new System.Drawing.Point(93, 10);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(1105, 152);
            this.txtReply.TabIndex = 1;
            this.txtReply.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reply :";
            // 
            // frm_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 739);
            this.Controls.Add(this.pnlReply);
            this.Controls.Add(this.lblQueryByEmpId);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblEmpName);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frm_Query";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "QUERIES";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.frm_Query_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.pnlReply.ResumeLayout(false);
            this.pnlReply.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtQueryByEmp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveEmp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdateEmp;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvQuery;
        private System.Windows.Forms.Label lblQueryByEmpId;
        private System.Windows.Forms.Panel pnlReply;
        private System.Windows.Forms.RichTextBox txtReply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}