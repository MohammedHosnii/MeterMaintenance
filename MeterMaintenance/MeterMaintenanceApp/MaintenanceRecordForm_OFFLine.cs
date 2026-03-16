using MeterMaintenanceApp.ReportForms;
using MeterMaintenanceApp.Services;
using MeterMaintenanceApp.Services.MeterMaintenanceApp.Services;
using MeterMaintenanceDB.OfflineModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;


namespace MeterMaintenanceApp
{
    public partial class MaintenanceRecordForm_OFFLine : Form
    {
        private int add_update=0; //0add 1 update
        private long currentCode = 0;
        private SystemInfoService _systemService;
        private MeterMaintenanceLocalService _meterMaintenanceservice;
        private int UnSyncedRecordCount = 0;
        public DataTable DG2Source=new DataTable();
        bool isOnline = false;
        public MaintenanceRecordForm_OFFLine()
        {
            InitializeComponent();
            
        }

        private async void MaintenanceRecordForm_OFFLine_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            combo_CompanySectorDept_Level.SelectedIndex = 0;

            _systemService = new SystemInfoService();

            // Initialize DB + system info
             isOnline = await _systemService.InitializeAsync();
            if (isOnline)
                textBox1.Text = "ONLine";
            else
                textBox1.Text = "OFFLine";

            var snapshot = _systemService.GetSystemSnapshot();
            txtUser.Text = snapshot.UserName;
            txtMaxUnSyncedRecordCount.Text =
                $"الحد الاقصي {snapshot.MaxUnSyncedCount} محضر";

            // Unsynced count
            UnSyncedRecordCount = _systemService.GetUnSyncedCount();
            txtGetUnSyncedRecordCount.Text =
                $"عدد المحاضر التي لم ترفع بعد {UnSyncedRecordCount}";

            // Load dropdowns
            await LoadCompaniesAsync();
            await LoadLabCentersAsync();
            await LoadTestResults();
            await LoadCorrectiveAction();
            _meterMaintenanceservice = new MeterMaintenanceLocalService();
            await _meterMaintenanceservice.InitializeAsync();
            groupBox2.Text = "المحاضر السابقة ل"+combo_Company.Text;
            await LoadMaintenanceGridAsync( Convert.ToInt32( combo_Company.SelectedValue));
        }

        private async Task LoadCompaniesAsync()
        {
            var companies = await _systemService.GetCompaniesAsync();
            combo_Company.DataSource = companies;
            combo_Company.DisplayMember = "CompanySectorDeptName";
            combo_Company.ValueMember = "Id";
        }

        private async Task LoadTestResults ()
        {
            var testResults = await _systemService.GetTestResultAsync();
            Column_TestResult.DataSource = testResults;
            Column_TestResult.DisplayMember = "TestResultName";
            Column_TestResult.ValueMember = "TestResultCode";
             
        }

        private async Task LoadCorrectiveAction()
        {
            var CorrectiveAction = await _systemService.GetCorrectiveActionAsync();
            Column_CorrectiveActionCode.DataSource = CorrectiveAction;
            Column_CorrectiveActionCode.DisplayMember = "CorrectiveActionName";
            Column_CorrectiveActionCode.ValueMember = "CorrectiveActionCode";
           
        }

        private async Task LoadLabCentersAsync()
        {
            var labs = await _systemService.GetLabCentersAsync();
            combo_LabCenter.DataSource = labs;
            combo_LabCenter.DisplayMember = "LabCenterName";
            combo_LabCenter.ValueMember = "Id";
         
        }

        private async Task LoadSectorsAsync(int companyId)
        {
            var sectors = await _systemService.GetSectorsAsync(companyId);
            combo_sector.DataSource = sectors;
            combo_sector.DisplayMember = "CompanySectorDeptName";
            combo_sector.ValueMember = "Id";
        }

        private async Task LoadDepartmentsAsync(int sectorId)
        {
            var deps = await _systemService.GetDepartmentsAsync(sectorId);
            combo_Department.DataSource = deps;
            combo_Department.DisplayMember = "CompanySectorDeptName";
            combo_Department.ValueMember = "Id";
        }

       
        private async void combo_sector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_sector.SelectedValue is int sid)
                await LoadDepartmentsAsync(sid);
        }
        private async void combo_CompanySectorDept_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combo_CompanySectorDept_Level.SelectedIndex)
            {
                case 0:
                    combo_Company.Visible = true;
                    combo_sector.Visible = false;
                    combo_Department.Visible = false;
                    break;

                case 1:
                    combo_Company.Visible = true;
                    combo_sector.Visible = true;
                    combo_Department.Visible = false;

                    if (combo_Company.SelectedValue is int cid)
                        await LoadSectorsAsync(cid);
                    break;

                case 2:
                    combo_Company.Visible = true;
                    combo_sector.Visible = true;
                    combo_Department.Visible = true;

                    if (combo_sector.SelectedValue is int sid)
                        await LoadDepartmentsAsync(sid);
                    break;
            }
        }

        private async void combo_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Company.SelectedValue is int sid)
            {
               
                groupBox2.Text = "المحاضر السابقة ل" + combo_Company.Text;
                await LoadSectorsAsync(sid);
                await LoadMaintenanceGridAsync(sid);
            }
                
            

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Height = 40;
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row= dataGridView1.Rows[e.RowIndex];
            if (!row.IsNewRow)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
            dataGridView1.EndEdit();

            CalaCounts();
        }

        private void CalaCounts()
        {
            try
            {
                int meterCount = 0;
                int workingMetersCount = 0;
                int repairedMetersCount = 0;
                int retiredMetersCount = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    
                    var meterObj = row.Cells["Column_MeterNumber"]?.Value;
                    if (meterObj != null)
                    {
                        string meterStr = meterObj.ToString();
                        if (!string.IsNullOrWhiteSpace(meterStr) && meterStr.Length > 5)
                            meterCount++;
                    }

                   
                    var testObj = row.Cells["Column_TestResult"]?.Value;
                    if (testObj != null && int.TryParse(testObj.ToString(), out int testResult))
                    {
                        if (testResult == 1)
                        {
                            workingMetersCount++;
                            continue;
                        }
                            
                    }

                    // --- Corrective action ---
                   
                    var actionObj = row.Cells["Column_CorrectiveActionCode"]?.Value;
                    if (actionObj != null && int.TryParse(actionObj.ToString(), out int action))
                    {
                        switch (action)
                        {
                            case 1:
                            case 2:
                                repairedMetersCount++;
                                break;

                            case 3:
                                retiredMetersCount++;
                                break;
                        }
                    }
                }

                txt_MeterCount.Text = meterCount.ToString();
                txt_RepairedMetersCount.Text = repairedMetersCount.ToString();
                txt_RetiredMetersCount.Text = retiredMetersCount.ToString();
                txt_WorkingMetersCount.Text = workingMetersCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating counts:\n" + ex.Message);
            }
        }

        private async void butt_Save_Click(object sender, EventArgs e)
        {
            if(txt_MaintenanceRecordDate.Text== "    /  /")
            {
                MessageBox.Show("برجاء ادخال التاريخ");
                this.ActiveControl=txt_MaintenanceRecordDate;
                return;
            }
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("برجاء ادخال العدادات");
                this.ActiveControl = dataGridView1;
                return;
            }    

            if (HasDuplicateMeters())
            {
                MessageBox.Show("رقم عداد مكرر");
                return;
            }

            try
            {
                // ===============================
                // HEADER
                // ===============================
                int CompanySectorDeptId = 0;

                switch (combo_CompanySectorDept_Level.SelectedIndex + 1)
                {
                    case 1:
                        CompanySectorDeptId =
                            Convert.ToInt32(combo_Company.SelectedValue);
                        break;

                    case 2:
                        CompanySectorDeptId =
                            Convert.ToInt32(combo_sector.SelectedValue);
                        break;

                    case 3:
                        CompanySectorDeptId =
                            Convert.ToInt32(combo_Department.SelectedValue);
                        break;
                }

                var header = new MeterMaintenanceLocal
                {
                    MaintenanceRecordDate = GetDate(txt_MaintenanceRecordDate),
                    CompanySectorDept_Id = CompanySectorDeptId,
                    LabCenter_Id = GetComboValue(combo_LabCenter),
                    MeterCount = GetInt(txt_MeterCount),
                    WorkingMetersCount = GetInt(txt_WorkingMetersCount),
                    RepairedMetersCount = GetInt(txt_RepairedMetersCount),
                    RetiredMetersCount = GetInt(txt_RetiredMetersCount),
                    ISSync = isOnline,
                    CompanySectorDept_Level =
                        combo_CompanySectorDept_Level.SelectedIndex + 1,
                    UserId = 0
                };


                if (add_update == 1)
                    header.MaintenanceRecordCode = currentCode;
                else
                    header.MaintenanceRecordCode = 0;

                // ===============================
                // DETAILS
                // ===============================
                var details = new List<MaintenanceRecordDetailLocal>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    details.Add(new MaintenanceRecordDetailLocal
                    {
                        MeterNumber =
                            row.Cells["Column_MeterNumber"].Value?.ToString(),
                        TestResultCode =
                            row.Cells["Column_TestResult"].Value?.ToString(),
                        CorrectiveActionCode =
                            row.Cells["Column_CorrectiveActionCode"].Value?.ToString(),
                        ISSync = isOnline
                    });
                }

                var fullDto = new MeterMaintenanceFullLocalDto
                {
                    Header = header,
                    Details = details
                };

                // ===============================
                // SAVE OR UPDATE
                // ===============================
                if (add_update == 0)
                {
                    await _meterMaintenanceservice.SaveAsync(fullDto);
                    MessageBox.Show("تم الادخال بنجاح ✅");
                }
                else
                {
                    await _meterMaintenanceservice.UpdateAsync(fullDto);
                    MessageBox.Show("تم التعديل بنجاح ✅");
                }
                if (isOnline)
                    await _meterMaintenanceservice.SyncFromServerToLocal(fullDto);

                // reset mode
                add_update = 0;
                currentCode = 0;
            
                await LoadMaintenanceGridAsync(Convert.ToInt32(combo_Company.SelectedValue));

                string message = " طباعة المحضر "    ;

                message += "؟";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                }
                cancelTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private async void butt_Save_Click_XXXXX(object sender, EventArgs e)
        {
            if (HasDuplicateMeters())
            {
                MessageBox.Show("رقم عداد مكرر");
                return;
            }
            try
            {
                // ===============================
                // HEADER
                // ===============================
                int CompanySectorDeptId = 0;
                switch(Convert.ToInt32( combo_CompanySectorDept_Level.SelectedIndex+1))
                {
                    case 1:
                        {
                            CompanySectorDeptId = 
                                Convert.ToInt32(combo_Company.SelectedValue);
                        }
                        break;
                    case 2:
                        {
                            CompanySectorDeptId =
                                Convert.ToInt32(combo_sector.SelectedValue);
                        }
                        break;
                    case 3:
                        {
                            CompanySectorDeptId =
                                Convert.ToInt32(combo_Department.SelectedValue);
                        }
                        break;
                }


                var header = new MeterMaintenanceLocal
                {
                    MaintenanceRecordDate = GetDate(txt_MaintenanceRecordDate),

                    CompanySectorDept_Id = CompanySectorDeptId,

                    LabCenter_Id = GetComboValue(combo_LabCenter),

                    MeterCount = GetInt(txt_MeterCount),

                    WorkingMetersCount = GetInt(txt_WorkingMetersCount),

                    RepairedMetersCount = GetInt(txt_RepairedMetersCount),

                    RetiredMetersCount = GetInt(txt_RetiredMetersCount),

                    MaintenanceRecordCode = 0,

                    ISSync = false,

                    CompanySectorDept_Level = combo_CompanySectorDept_Level.SelectedIndex + 1,
                    UserId = 0
                };


                // ===============================
                // DETAILS
                // (Example: from DataGridView)
                // ===============================
                var details = new List<MaintenanceRecordDetailLocal>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    
                    details.Add(new MaintenanceRecordDetailLocal
                    {
                       
                        MeterNumber = row.Cells["Column_MeterNumber"].Value?.ToString(),
                        TestResultCode = row.Cells["Column_TestResult"].Value?.ToString(),
                        CorrectiveActionCode = row.Cells["Column_CorrectiveActionCode"].Value?.ToString(),
                        ISSync = false
                    });
                }

                // ===============================
                // WRAP DTO
                // ===============================
                var fullDto = new MeterMaintenanceFullLocalDto
                {
                    Header = header,
                    Details = details
                };

                // ===============================
                // SAVE
                // ===============================
                await _meterMaintenanceservice.SaveAsync(fullDto);

                MessageBox.Show("Saved successfully ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }
        private int GetComboValue(ComboBox combo)
        {
            if (combo.SelectedValue == null)
                return 0;

            int.TryParse(combo.SelectedValue.ToString(), out int val);
            return val;
        }
        private int GetInt(TextBox txt)
        {
            int.TryParse(txt.Text, out int val);
            return val;
        }

        private DateTime GetDate(MaskedTextBox txt)
        {
            DateTime.TryParse(txt.Text, out DateTime dt);
            return dt;
        }

       
        private bool HasDuplicateMeters()
        {
            var seen = new HashSet<string>();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                
                var meter = row.Cells["Column_MeterNumber"].Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(meter))
                    continue;

                if (!seen.Add(meter))
                {
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index]
                        .Selected = false;
                    
                    dataGridView1.Rows[row.Index].Selected = true;  
                    return true;
                }
            }

            return false;
        }

        private async Task LoadMaintenanceGridAsync(int deptId)
        {
            try
            {
                DG2Source.Rows.Clear();

                dataGridView2.Cursor = Cursors.WaitCursor;

                using (var service = new MaintenanceRecordViewService())
                {
                    await service.InitializeAsync();
                    
                    var data = await service.GetByDepartmentAsync(deptId);
                    DG2Source=data.ToDataTable();
                    dataGridView2.AutoGenerateColumns = true;
                    dataGridView2.DataSource = DG2Source;
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                dataGridView2.Cursor = Cursors.Default;
            }
        }

        private void butt_cancel_Click(object sender, EventArgs e)
        {
            cancelTask();

          

        }
        private void  cancelTask()
        {
            dataGridView1.Rows.Clear();
            butt_mode.Text = groupBox3.Text = "إدخال محضر جديد";
            butt_print.Visible = false;
            add_update = 0;
            txt_MaintenanceRecordDate.Text = string.Empty;
            foreach (Control text in groupBox4.Controls)
            {

                if (text.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    text.Text = string.Empty;
                }
            }
        }

        private async void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                // ===============================
                // GET CODE FROM GRID
                // ===============================
                var codeObj = dataGridView2.Rows[e.RowIndex]
                    .Cells["Column_MaintenanceRecordCode"]
                    .Value;
                txt_MaintenanceRecordCode.Text = codeObj.ToString();
                await FillWithRecord(codeObj);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private async Task FillWithRecord(object codeObj)
        {
            if (codeObj == null) return;

            long code = Convert.ToInt64(codeObj);

            // ===============================
            // CALL SERVICE
            // ===============================
            var dto = await _meterMaintenanceservice.GetAsync(code);

            if (dto == null)
            {
                MessageBox.Show("Record not found");
                return;
            }

            // ===============================
            // FILL HEADER
            // ===============================
            txt_MaintenanceRecordDate.Text =
                dto.Header.MaintenanceRecordDate.ToString("yyyy-MM-dd");

            combo_LabCenter.SelectedValue =
                dto.Header.LabCenter_Id;

            txt_MeterCount.Text =
                dto.Header.MeterCount.ToString();

            txt_WorkingMetersCount.Text =
                dto.Header.WorkingMetersCount.ToString();

            txt_RepairedMetersCount.Text =
                dto.Header.RepairedMetersCount.ToString();

            txt_RetiredMetersCount.Text =
                dto.Header.RetiredMetersCount.ToString();

            dataGridView1.Rows.Clear();
            dataGridView1.RowTemplate.Height = 40;
            int i = 0;
            foreach (var d in dto.Details)
            {
                i++;
                dataGridView1.Rows.Add(i,
                    d.MeterNumber,
                    d.TestResultCode,
                    d.CorrectiveActionCode
                );
            }
            currentCode = dto.Header.MaintenanceRecordCode;
            butt_mode.Text = groupBox3.Text = "تعديل محضر قديم";
            butt_print.Visible = true;
            add_update = 1;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
            string code = search.SelectedCode;
            await FillWithRecord(code);
        }

        private void butt_print_Click(object sender, EventArgs e)
        {
            if (txt_MaintenanceRecordCode.Text != "")
                PrintWithRecord(txt_MaintenanceRecordCode.Text);
        }
        public async Task PrintWithRecord(object codeObj)
        {
            if (codeObj == null) return;

            long code = Convert.ToInt64(codeObj);
            DataTable dt;
            using (var service = new MeterMaintenanceReportService())
            {
                await service.InitializeAsync();

                var report = await service.GetReportAsync(code);

                 dt= InfoClass.ToDataTable(report);
            }
            try
            {

                this.Cursor = Cursors.WaitCursor;



                FrmReportViewer frm = new FrmReportViewer(dt, @"\rpt\MaintenanceRecord.rpt");



                this.Cursor = Cursors.Arrow;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message, "خطا",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        
    }
}

