namespace Tax_Consultant_25.Frames
{
    partial class ucEmployee
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAllInOne = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuery = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInOne)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAllInOne);
            this.panel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 624);
            this.panel1.TabIndex = 0;
            // 
            // dgvAllInOne
            // 
            this.dgvAllInOne.AllowUserToAddRows = false;
            this.dgvAllInOne.AllowUserToDeleteRows = false;
            this.dgvAllInOne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInOne.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAllInOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.btnQuery});
            this.dgvAllInOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInOne.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllInOne.Location = new System.Drawing.Point(0, 0);
            this.dgvAllInOne.Name = "dgvAllInOne";
            this.dgvAllInOne.RowHeadersVisible = false;
            this.dgvAllInOne.RowHeadersWidth = 51;
            this.dgvAllInOne.RowTemplate.Height = 24;
            this.dgvAllInOne.Size = new System.Drawing.Size(1054, 624);
            this.dgvAllInOne.TabIndex = 2;
            this.dgvAllInOne.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInOne_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "serial";
            this.Column1.FillWeight = 43.95757F;
            this.Column1.HeaderText = "SR.";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "i_Service";
            this.Column5.HeaderText = "Service";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "i_InputDate";
            this.Column2.FillWeight = 106.9764F;
            this.Column2.HeaderText = "Input Date";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "clientName";
            this.Column3.FillWeight = 138.4873F;
            this.Column3.HeaderText = "Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "i_WorkType";
            this.Column4.FillWeight = 97.25612F;
            this.Column4.HeaderText = "Work Type";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "i_DueDate";
            this.Column6.FillWeight = 96.21171F;
            this.Column6.HeaderText = "Due Date";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // btnQuery
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnQuery.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnQuery.FillWeight = 57.83103F;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuery.HeaderText = "Query";
            this.btnQuery.MinimumWidth = 6;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnQuery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnQuery.Text = "QUERY";
            this.btnQuery.UseColumnTextForButtonValue = true;
            // 
            // ucEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucEmployee";
            this.Size = new System.Drawing.Size(1072, 630);
            this.Load += new System.EventHandler(this.ucEmployee_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInOne)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAllInOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn btnQuery;
    }
}
