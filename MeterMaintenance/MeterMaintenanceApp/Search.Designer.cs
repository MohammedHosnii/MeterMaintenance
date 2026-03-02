namespace MeterMaintenanceApp
{
    partial class Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_MeterNumber = new System.Windows.Forms.TextBox();
            this.txt_MaintenanceRecordDate = new System.Windows.Forms.MaskedTextBox();
            this.combo_LabCenter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_Department = new System.Windows.Forms.ComboBox();
            this.combo_sector = new System.Windows.Forms.ComboBox();
            this.combo_CompanySectorDept_Level = new System.Windows.Forms.ComboBox();
            this.combo_Company = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column_MaintenanceRecordDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CompanySectorDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MeterCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_WorkingMetersCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RepairedMetersCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RetiredMetersCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MaintenanceRecordCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ISSync = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_CompanySectorDept_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LabCenterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt_MeterNumber);
            this.panel1.Controls.Add(this.txt_MaintenanceRecordDate);
            this.panel1.Controls.Add(this.combo_LabCenter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combo_Department);
            this.panel1.Controls.Add(this.combo_sector);
            this.panel1.Controls.Add(this.combo_CompanySectorDept_Level);
            this.panel1.Controls.Add(this.combo_Company);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1586, 117);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 42);
            this.button1.TabIndex = 14;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_MeterNumber
            // 
            this.txt_MeterNumber.Location = new System.Drawing.Point(596, 67);
            this.txt_MeterNumber.Name = "txt_MeterNumber";
            this.txt_MeterNumber.Size = new System.Drawing.Size(271, 34);
            this.txt_MeterNumber.TabIndex = 13;
            // 
            // txt_MaintenanceRecordDate
            // 
            this.txt_MaintenanceRecordDate.BackColor = System.Drawing.SystemColors.Window;
            this.txt_MaintenanceRecordDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txt_MaintenanceRecordDate.ForeColor = System.Drawing.Color.Black;
            this.txt_MaintenanceRecordDate.Location = new System.Drawing.Point(1115, 67);
            this.txt_MaintenanceRecordDate.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaintenanceRecordDate.Mask = "0000/00/00";
            this.txt_MaintenanceRecordDate.Name = "txt_MaintenanceRecordDate";
            this.txt_MaintenanceRecordDate.Size = new System.Drawing.Size(175, 35);
            this.txt_MaintenanceRecordDate.TabIndex = 12;
            this.txt_MaintenanceRecordDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combo_LabCenter
            // 
            this.combo_LabCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_LabCenter.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_LabCenter.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_LabCenter.FormattingEnabled = true;
            this.combo_LabCenter.Location = new System.Drawing.Point(887, 65);
            this.combo_LabCenter.Name = "combo_LabCenter";
            this.combo_LabCenter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_LabCenter.Size = new System.Drawing.Size(221, 39);
            this.combo_LabCenter.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1291, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "تاريخ";
            // 
            // combo_Department
            // 
            this.combo_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Department.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Department.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_Department.FormattingEnabled = true;
            this.combo_Department.Location = new System.Drawing.Point(114, 9);
            this.combo_Department.Name = "combo_Department";
            this.combo_Department.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Department.Size = new System.Drawing.Size(441, 39);
            this.combo_Department.TabIndex = 8;
            // 
            // combo_sector
            // 
            this.combo_sector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_sector.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_sector.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_sector.FormattingEnabled = true;
            this.combo_sector.Location = new System.Drawing.Point(567, 9);
            this.combo_sector.Name = "combo_sector";
            this.combo_sector.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_sector.Size = new System.Drawing.Size(221, 39);
            this.combo_sector.TabIndex = 7;
            this.combo_sector.SelectedIndexChanged += new System.EventHandler(this.combo_sector_SelectedIndexChanged);
            // 
            // combo_CompanySectorDept_Level
            // 
            this.combo_CompanySectorDept_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_CompanySectorDept_Level.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_CompanySectorDept_Level.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_CompanySectorDept_Level.FormattingEnabled = true;
            this.combo_CompanySectorDept_Level.Items.AddRange(new object[] {
            "الكل",
            "شركة",
            "قطاع",
            "هندسة"});
            this.combo_CompanySectorDept_Level.Location = new System.Drawing.Point(1253, 9);
            this.combo_CompanySectorDept_Level.Name = "combo_CompanySectorDept_Level";
            this.combo_CompanySectorDept_Level.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_CompanySectorDept_Level.Size = new System.Drawing.Size(221, 39);
            this.combo_CompanySectorDept_Level.TabIndex = 7;
            this.combo_CompanySectorDept_Level.SelectedIndexChanged += new System.EventHandler(this.combo_CompanySectorDept_Level_SelectedIndexChanged);
            // 
            // combo_Company
            // 
            this.combo_Company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Company.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Company.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_Company.FormattingEnabled = true;
            this.combo_Company.Location = new System.Drawing.Point(800, 9);
            this.combo_Company.Name = "combo_Company";
            this.combo_Company.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Company.Size = new System.Drawing.Size(441, 39);
            this.combo_Company.TabIndex = 6;
            this.combo_Company.SelectedIndexChanged += new System.EventHandler(this.combo_Company_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1589, 466);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نتيجة البحث";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_MaintenanceRecordDate,
            this.Column_CompanySectorDeptName,
            this.Column_MeterCount,
            this.Column_WorkingMetersCount,
            this.Column_RepairedMetersCount,
            this.Column_RetiredMetersCount,
            this.Column_MaintenanceRecordCode,
            this.Column_ISSync,
            this.Column_CompanySectorDept_Level,
            this.Column_LabCenterName,
            this.Column_View});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 26;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1583, 433);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column_MaintenanceRecordDate
            // 
            this.Column_MaintenanceRecordDate.DataPropertyName = "MaintenanceRecordDate";
            this.Column_MaintenanceRecordDate.HeaderText = "تاريخ";
            this.Column_MaintenanceRecordDate.MinimumWidth = 6;
            this.Column_MaintenanceRecordDate.Name = "Column_MaintenanceRecordDate";
            this.Column_MaintenanceRecordDate.ReadOnly = true;
            this.Column_MaintenanceRecordDate.Width = 125;
            // 
            // Column_CompanySectorDeptName
            // 
            this.Column_CompanySectorDeptName.DataPropertyName = "CompanySectorDeptName";
            this.Column_CompanySectorDeptName.HeaderText = "شركة";
            this.Column_CompanySectorDeptName.MinimumWidth = 6;
            this.Column_CompanySectorDeptName.Name = "Column_CompanySectorDeptName";
            this.Column_CompanySectorDeptName.ReadOnly = true;
            this.Column_CompanySectorDeptName.Width = 300;
            // 
            // Column_MeterCount
            // 
            this.Column_MeterCount.DataPropertyName = "MeterCount";
            this.Column_MeterCount.HeaderText = "عدد";
            this.Column_MeterCount.MinimumWidth = 6;
            this.Column_MeterCount.Name = "Column_MeterCount";
            this.Column_MeterCount.ReadOnly = true;
            this.Column_MeterCount.Width = 125;
            // 
            // Column_WorkingMetersCount
            // 
            this.Column_WorkingMetersCount.DataPropertyName = "WorkingMetersCount";
            this.Column_WorkingMetersCount.HeaderText = "سليم";
            this.Column_WorkingMetersCount.MinimumWidth = 6;
            this.Column_WorkingMetersCount.Name = "Column_WorkingMetersCount";
            this.Column_WorkingMetersCount.ReadOnly = true;
            this.Column_WorkingMetersCount.Width = 75;
            // 
            // Column_RepairedMetersCount
            // 
            this.Column_RepairedMetersCount.DataPropertyName = "RepairedMetersCount";
            this.Column_RepairedMetersCount.HeaderText = "تم الصيانة";
            this.Column_RepairedMetersCount.MinimumWidth = 6;
            this.Column_RepairedMetersCount.Name = "Column_RepairedMetersCount";
            this.Column_RepairedMetersCount.ReadOnly = true;
            this.Column_RepairedMetersCount.Width = 75;
            // 
            // Column_RetiredMetersCount
            // 
            this.Column_RetiredMetersCount.DataPropertyName = "RetiredMetersCount";
            this.Column_RetiredMetersCount.HeaderText = "تم التكهين";
            this.Column_RetiredMetersCount.MinimumWidth = 6;
            this.Column_RetiredMetersCount.Name = "Column_RetiredMetersCount";
            this.Column_RetiredMetersCount.ReadOnly = true;
            this.Column_RetiredMetersCount.Width = 75;
            // 
            // Column_MaintenanceRecordCode
            // 
            this.Column_MaintenanceRecordCode.DataPropertyName = "MaintenanceRecordCode";
            this.Column_MaintenanceRecordCode.HeaderText = "الكود";
            this.Column_MaintenanceRecordCode.MinimumWidth = 6;
            this.Column_MaintenanceRecordCode.Name = "Column_MaintenanceRecordCode";
            this.Column_MaintenanceRecordCode.ReadOnly = true;
            this.Column_MaintenanceRecordCode.Width = 250;
            // 
            // Column_ISSync
            // 
            this.Column_ISSync.DataPropertyName = "ISSync";
            this.Column_ISSync.HeaderText = "مزامنة";
            this.Column_ISSync.MinimumWidth = 6;
            this.Column_ISSync.Name = "Column_ISSync";
            this.Column_ISSync.ReadOnly = true;
            this.Column_ISSync.Width = 75;
            // 
            // Column_CompanySectorDept_Level
            // 
            this.Column_CompanySectorDept_Level.DataPropertyName = "CompanySectorDept_Level";
            this.Column_CompanySectorDept_Level.HeaderText = "مستوي";
            this.Column_CompanySectorDept_Level.MinimumWidth = 6;
            this.Column_CompanySectorDept_Level.Name = "Column_CompanySectorDept_Level";
            this.Column_CompanySectorDept_Level.ReadOnly = true;
            this.Column_CompanySectorDept_Level.Width = 150;
            // 
            // Column_LabCenterName
            // 
            this.Column_LabCenterName.DataPropertyName = "LabCenterName";
            this.Column_LabCenterName.HeaderText = "مركز_معمل";
            this.Column_LabCenterName.MinimumWidth = 6;
            this.Column_LabCenterName.Name = "Column_LabCenterName";
            this.Column_LabCenterName.ReadOnly = true;
            this.Column_LabCenterName.Width = 125;
            // 
            // Column_View
            // 
            this.Column_View.DataPropertyName = "Column_View";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed;
            this.Column_View.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_View.HeaderText = "عرض التفاصيل";
            this.Column_View.MinimumWidth = 6;
            this.Column_View.Name = "Column_View";
            this.Column_View.ReadOnly = true;
            this.Column_View.Width = 125;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_Department;
        private System.Windows.Forms.ComboBox combo_sector;
        private System.Windows.Forms.ComboBox combo_CompanySectorDept_Level;
        private System.Windows.Forms.ComboBox combo_Company;
        private System.Windows.Forms.TextBox txt_MeterNumber;
        private System.Windows.Forms.MaskedTextBox txt_MaintenanceRecordDate;
        private System.Windows.Forms.ComboBox combo_LabCenter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaintenanceRecordDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CompanySectorDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MeterCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_WorkingMetersCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RepairedMetersCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RetiredMetersCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaintenanceRecordCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_ISSync;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CompanySectorDept_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LabCenterName;
        private System.Windows.Forms.DataGridViewButtonColumn Column_View;
    }
}