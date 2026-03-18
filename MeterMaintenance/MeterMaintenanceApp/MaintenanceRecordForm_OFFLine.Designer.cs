namespace MeterMaintenanceApp
{
    partial class MaintenanceRecordForm_OFFLine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtMaxUnSyncedRecordCount = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtGetUnSyncedRecordCount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_Department = new System.Windows.Forms.ComboBox();
            this.combo_sector = new System.Windows.Forms.ComboBox();
            this.combo_CompanySectorDept_Level = new System.Windows.Forms.ComboBox();
            this.combo_Company = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.butt_mode = new System.Windows.Forms.Button();
            this.butt_cancel = new System.Windows.Forms.Button();
            this.butt_Save = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_MaintenanceRecordCode = new System.Windows.Forms.TextBox();
            this.butt_print = new System.Windows.Forms.Button();
            this.txt_RetiredMetersCount = new System.Windows.Forms.TextBox();
            this.txt_RepairedMetersCount = new System.Windows.Forms.TextBox();
            this.txt_WorkingMetersCount = new System.Windows.Forms.TextBox();
            this.txt_MeterCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_MaintenanceRecordDate = new System.Windows.Forms.MaskedTextBox();
            this.combo_LabCenter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Column_ndx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MeterNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TestResult = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_CorrectiveActionCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_ErrorNumber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_CreationDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ModificationDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtMaxUnSyncedRecordCount);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtGetUnSyncedRecordCount);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(242, 573);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(16, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 70);
            this.button1.TabIndex = 14;
            this.button1.Text = "بحث متقدم";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(20, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(195, 34);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "OFFLINE";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaxUnSyncedRecordCount
            // 
            this.txtMaxUnSyncedRecordCount.ForeColor = System.Drawing.Color.DarkRed;
            this.txtMaxUnSyncedRecordCount.Location = new System.Drawing.Point(5, 307);
            this.txtMaxUnSyncedRecordCount.Multiline = true;
            this.txtMaxUnSyncedRecordCount.Name = "txtMaxUnSyncedRecordCount";
            this.txtMaxUnSyncedRecordCount.ReadOnly = true;
            this.txtMaxUnSyncedRecordCount.Size = new System.Drawing.Size(224, 47);
            this.txtMaxUnSyncedRecordCount.TabIndex = 2;
            this.txtMaxUnSyncedRecordCount.TabStop = false;
            this.txtMaxUnSyncedRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUser
            // 
            this.txtUser.ForeColor = System.Drawing.Color.DarkRed;
            this.txtUser.Location = new System.Drawing.Point(4, 115);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(227, 64);
            this.txtUser.TabIndex = 0;
            this.txtUser.TabStop = false;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGetUnSyncedRecordCount
            // 
            this.txtGetUnSyncedRecordCount.ForeColor = System.Drawing.Color.DarkRed;
            this.txtGetUnSyncedRecordCount.Location = new System.Drawing.Point(8, 199);
            this.txtGetUnSyncedRecordCount.Multiline = true;
            this.txtGetUnSyncedRecordCount.Name = "txtGetUnSyncedRecordCount";
            this.txtGetUnSyncedRecordCount.ReadOnly = true;
            this.txtGetUnSyncedRecordCount.Size = new System.Drawing.Size(219, 64);
            this.txtGetUnSyncedRecordCount.TabIndex = 1;
            this.txtGetUnSyncedRecordCount.TabStop = false;
            this.txtGetUnSyncedRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.combo_Department);
            this.panel1.Controls.Add(this.combo_sector);
            this.panel1.Controls.Add(this.combo_CompanySectorDept_Level);
            this.panel1.Controls.Add(this.combo_Company);
            this.panel1.Location = new System.Drawing.Point(248, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 55);
            this.panel1.TabIndex = 2;
            // 
            // combo_Department
            // 
            this.combo_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Department.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Department.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_Department.FormattingEnabled = true;
            this.combo_Department.Location = new System.Drawing.Point(12, 9);
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
            this.combo_sector.Location = new System.Drawing.Point(465, 9);
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
            "شركة",
            "قطاع",
            "هندسة"});
            this.combo_CompanySectorDept_Level.Location = new System.Drawing.Point(1151, 9);
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
            this.combo_Company.Location = new System.Drawing.Point(698, 9);
            this.combo_Company.Name = "combo_Company";
            this.combo_Company.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Company.Size = new System.Drawing.Size(441, 39);
            this.combo_Company.TabIndex = 6;
            this.combo_Company.SelectedIndexChanged += new System.EventHandler(this.combo_Company_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(8, 579);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1624, 361);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
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
            this.Column_LabCenterName});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 26;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1618, 328);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
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
            this.Column_CompanySectorDept_Level.Width = 200;
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.butt_mode);
            this.groupBox3.Controls.Add(this.butt_cancel);
            this.groupBox3.Controls.Add(this.butt_Save);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.txt_MaintenanceRecordDate);
            this.groupBox3.Controls.Add(this.combo_LabCenter);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(250, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(1382, 500);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "أدخال محضر جديد";
            // 
            // butt_mode
            // 
            this.butt_mode.BackColor = System.Drawing.Color.LemonChiffon;
            this.butt_mode.Enabled = false;
            this.butt_mode.Location = new System.Drawing.Point(278, 30);
            this.butt_mode.Name = "butt_mode";
            this.butt_mode.Size = new System.Drawing.Size(212, 33);
            this.butt_mode.TabIndex = 14;
            this.butt_mode.Text = "إدخال محضر جديد";
            this.butt_mode.UseVisualStyleBackColor = false;
            // 
            // butt_cancel
            // 
            this.butt_cancel.ForeColor = System.Drawing.Color.DarkRed;
            this.butt_cancel.Location = new System.Drawing.Point(543, 456);
            this.butt_cancel.Name = "butt_cancel";
            this.butt_cancel.Size = new System.Drawing.Size(251, 38);
            this.butt_cancel.TabIndex = 13;
            this.butt_cancel.Text = "الغاء";
            this.butt_cancel.UseVisualStyleBackColor = true;
            this.butt_cancel.Click += new System.EventHandler(this.butt_cancel_Click);
            // 
            // butt_Save
            // 
            this.butt_Save.ForeColor = System.Drawing.Color.DarkBlue;
            this.butt_Save.Location = new System.Drawing.Point(858, 456);
            this.butt_Save.Name = "butt_Save";
            this.butt_Save.Size = new System.Drawing.Size(251, 38);
            this.butt_Save.TabIndex = 12;
            this.butt_Save.Text = "حفظ";
            this.butt_Save.UseVisualStyleBackColor = true;
            this.butt_Save.Click += new System.EventHandler(this.butt_Save_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox4.Controls.Add(this.txt_MaintenanceRecordCode);
            this.groupBox4.Controls.Add(this.butt_print);
            this.groupBox4.Controls.Add(this.txt_RetiredMetersCount);
            this.groupBox4.Controls.Add(this.txt_RepairedMetersCount);
            this.groupBox4.Controls.Add(this.txt_WorkingMetersCount);
            this.groupBox4.Controls.Add(this.txt_MeterCount);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox4.Location = new System.Drawing.Point(6, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 484);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "الاعداد";
            // 
            // txt_MaintenanceRecordCode
            // 
            this.txt_MaintenanceRecordCode.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_MaintenanceRecordCode.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaintenanceRecordCode.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_MaintenanceRecordCode.Location = new System.Drawing.Point(3, 303);
            this.txt_MaintenanceRecordCode.Name = "txt_MaintenanceRecordCode";
            this.txt_MaintenanceRecordCode.ReadOnly = true;
            this.txt_MaintenanceRecordCode.Size = new System.Drawing.Size(194, 27);
            this.txt_MaintenanceRecordCode.TabIndex = 16;
            this.txt_MaintenanceRecordCode.TabStop = false;
            this.txt_MaintenanceRecordCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butt_print
            // 
            this.butt_print.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.butt_print.Image = global::MeterMaintenanceApp.Properties.Resources.printer;
            this.butt_print.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butt_print.Location = new System.Drawing.Point(36, 370);
            this.butt_print.Name = "butt_print";
            this.butt_print.Size = new System.Drawing.Size(115, 66);
            this.butt_print.TabIndex = 15;
            this.butt_print.Text = "طباعة";
            this.butt_print.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butt_print.UseVisualStyleBackColor = true;
            this.butt_print.Click += new System.EventHandler(this.butt_print_Click);
            // 
            // txt_RetiredMetersCount
            // 
            this.txt_RetiredMetersCount.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_RetiredMetersCount.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_RetiredMetersCount.Location = new System.Drawing.Point(16, 232);
            this.txt_RetiredMetersCount.Name = "txt_RetiredMetersCount";
            this.txt_RetiredMetersCount.ReadOnly = true;
            this.txt_RetiredMetersCount.Size = new System.Drawing.Size(73, 34);
            this.txt_RetiredMetersCount.TabIndex = 7;
            this.txt_RetiredMetersCount.TabStop = false;
            this.txt_RetiredMetersCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_RepairedMetersCount
            // 
            this.txt_RepairedMetersCount.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_RepairedMetersCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_RepairedMetersCount.Location = new System.Drawing.Point(16, 177);
            this.txt_RepairedMetersCount.Name = "txt_RepairedMetersCount";
            this.txt_RepairedMetersCount.ReadOnly = true;
            this.txt_RepairedMetersCount.Size = new System.Drawing.Size(73, 34);
            this.txt_RepairedMetersCount.TabIndex = 6;
            this.txt_RepairedMetersCount.TabStop = false;
            this.txt_RepairedMetersCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_WorkingMetersCount
            // 
            this.txt_WorkingMetersCount.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_WorkingMetersCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_WorkingMetersCount.Location = new System.Drawing.Point(16, 124);
            this.txt_WorkingMetersCount.Name = "txt_WorkingMetersCount";
            this.txt_WorkingMetersCount.ReadOnly = true;
            this.txt_WorkingMetersCount.Size = new System.Drawing.Size(73, 34);
            this.txt_WorkingMetersCount.TabIndex = 5;
            this.txt_WorkingMetersCount.TabStop = false;
            this.txt_WorkingMetersCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_MeterCount
            // 
            this.txt_MeterCount.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_MeterCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_MeterCount.Location = new System.Drawing.Point(16, 45);
            this.txt_MeterCount.Name = "txt_MeterCount";
            this.txt_MeterCount.ReadOnly = true;
            this.txt_MeterCount.Size = new System.Drawing.Size(73, 34);
            this.txt_MeterCount.TabIndex = 4;
            this.txt_MeterCount.TabStop = false;
            this.txt_MeterCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "تم تكهينهم";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(94, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "تم صيانتهم";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(105, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "أجمالي ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(114, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = " سليم";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ndx,
            this.Column_MeterNumber,
            this.Column_TestResult,
            this.Column_CorrectiveActionCode,
            this.Column_ErrorNumber,
            this.Column_CreationDateTime,
            this.Column_Notes,
            this.Column_ModificationDateTime});
            this.dataGridView1.Location = new System.Drawing.Point(217, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1166, 375);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            // 
            // txt_MaintenanceRecordDate
            // 
            this.txt_MaintenanceRecordDate.BackColor = System.Drawing.SystemColors.Window;
            this.txt_MaintenanceRecordDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txt_MaintenanceRecordDate.ForeColor = System.Drawing.Color.Black;
            this.txt_MaintenanceRecordDate.Location = new System.Drawing.Point(801, 25);
            this.txt_MaintenanceRecordDate.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaintenanceRecordDate.Mask = "0000/00/00";
            this.txt_MaintenanceRecordDate.Name = "txt_MaintenanceRecordDate";
            this.txt_MaintenanceRecordDate.Size = new System.Drawing.Size(175, 35);
            this.txt_MaintenanceRecordDate.TabIndex = 9;
            this.txt_MaintenanceRecordDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combo_LabCenter
            // 
            this.combo_LabCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_LabCenter.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_LabCenter.ForeColor = System.Drawing.Color.DarkBlue;
            this.combo_LabCenter.FormattingEnabled = true;
            this.combo_LabCenter.Location = new System.Drawing.Point(573, 23);
            this.combo_LabCenter.Name = "combo_LabCenter";
            this.combo_LabCenter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_LabCenter.Size = new System.Drawing.Size(221, 39);
            this.combo_LabCenter.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(977, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاريخ";
            // 
            // Column_ndx
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column_ndx.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column_ndx.HeaderText = "م";
            this.Column_ndx.MinimumWidth = 6;
            this.Column_ndx.Name = "Column_ndx";
            this.Column_ndx.ReadOnly = true;
            this.Column_ndx.Width = 25;
            // 
            // Column_MeterNumber
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.DarkRed;
            this.Column_MeterNumber.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column_MeterNumber.HeaderText = "رقم العداد";
            this.Column_MeterNumber.MinimumWidth = 6;
            this.Column_MeterNumber.Name = "Column_MeterNumber";
            this.Column_MeterNumber.Width = 200;
            // 
            // Column_TestResult
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column_TestResult.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column_TestResult.HeaderText = "نتيجة الفحص";
            this.Column_TestResult.MinimumWidth = 6;
            this.Column_TestResult.Name = "Column_TestResult";
            this.Column_TestResult.Width = 250;
            // 
            // Column_CorrectiveActionCode
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column_CorrectiveActionCode.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column_CorrectiveActionCode.HeaderText = "الاجراء التصحيحي";
            this.Column_CorrectiveActionCode.MinimumWidth = 6;
            this.Column_CorrectiveActionCode.Name = "Column_CorrectiveActionCode";
            this.Column_CorrectiveActionCode.Width = 250;
            // 
            // Column_ErrorNumber
            // 
            this.Column_ErrorNumber.HeaderText = "خطأ";
            this.Column_ErrorNumber.MinimumWidth = 6;
            this.Column_ErrorNumber.Name = "Column_ErrorNumber";
            this.Column_ErrorNumber.Width = 125;
            // 
            // Column_CreationDateTime
            // 
            this.Column_CreationDateTime.DataPropertyName = "CreationDateTime";
            this.Column_CreationDateTime.HeaderText = "تاريخ";
            this.Column_CreationDateTime.MinimumWidth = 6;
            this.Column_CreationDateTime.Name = "Column_CreationDateTime";
            this.Column_CreationDateTime.Visible = false;
            this.Column_CreationDateTime.Width = 125;
            // 
            // Column_Notes
            // 
            this.Column_Notes.DataPropertyName = "Notes";
            this.Column_Notes.HeaderText = "ملاحظات";
            this.Column_Notes.MinimumWidth = 6;
            this.Column_Notes.Name = "Column_Notes";
            this.Column_Notes.Width = 125;
            // 
            // Column_ModificationDateTime
            // 
            this.Column_ModificationDateTime.DataPropertyName = "ModificationDateTime";
            this.Column_ModificationDateTime.HeaderText = "تعديل";
            this.Column_ModificationDateTime.MinimumWidth = 6;
            this.Column_ModificationDateTime.Name = "Column_ModificationDateTime";
            this.Column_ModificationDateTime.Visible = false;
            this.Column_ModificationDateTime.Width = 125;
            // 
            // MaintenanceRecordForm_OFFLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1636, 954);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MaintenanceRecordForm_OFFLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صيانة العدادات";
            this.Load += new System.EventHandler(this.MaintenanceRecordForm_OFFLine_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGetUnSyncedRecordCount;
        private System.Windows.Forms.TextBox txtMaxUnSyncedRecordCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_Company;
        private System.Windows.Forms.ComboBox combo_CompanySectorDept_Level;
        private System.Windows.Forms.ComboBox combo_sector;
        private System.Windows.Forms.ComboBox combo_Department;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_LabCenter;
        private System.Windows.Forms.MaskedTextBox txt_MaintenanceRecordDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_RetiredMetersCount;
        private System.Windows.Forms.TextBox txt_RepairedMetersCount;
        private System.Windows.Forms.TextBox txt_WorkingMetersCount;
        private System.Windows.Forms.TextBox txt_MeterCount;
        private System.Windows.Forms.Button butt_Save;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.Button butt_cancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butt_mode;
        private System.Windows.Forms.Button butt_print;
        private System.Windows.Forms.TextBox txt_MaintenanceRecordCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ndx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MeterNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_TestResult;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_CorrectiveActionCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_ErrorNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CreationDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ModificationDateTime;
    }
}