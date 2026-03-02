using MeterMaintenanceApp.Services;
using MeterMaintenanceApp.Services.MeterMaintenanceApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MeterMaintenanceApp
{
    public partial class Search : Form
    {
        private SystemInfoService _systemService;
        public DataTable DG2Source = new DataTable();
        public string SelectedCode = "";
        public Search()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string WhereStr = @"";
          
            int CompanySectorDept_Level = combo_CompanySectorDept_Level.SelectedIndex ;
            int CompanySectorDeptId = 0;
            int LabCenter_Id =Convert.ToInt32( combo_LabCenter.SelectedValue);
            if(CompanySectorDept_Level>0)
            {
                switch (CompanySectorDept_Level)
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

                WhereStr += @" and  MR.CompanySectorDept_Level=" + CompanySectorDept_Level.ToString()
                           ;
                if(CompanySectorDeptId>0)
                    WhereStr += @" and  CompanySectorDept_Id=" + CompanySectorDeptId.ToString()
                        ;
              

            }
            
            if(combo_LabCenter.SelectedIndex>0)
            {
                WhereStr += @" and LabCenter_Id=" + LabCenter_Id.ToString();
            }
            if (txt_MaintenanceRecordDate.Text != "    /  /")
            {
                WhereStr += @" and  MaintenanceRecordDate ='" + txt_MaintenanceRecordDate.Text +"'";
            }
            if(txt_MeterNumber.Text!=string.Empty)
            {
                WhereStr += @"  and MR.MaintenanceRecordCode IN
                (
                    SELECT MaintenanceRecordCode
                    FROM dbo.MaintenanceRecord_Detail
                    WHERE MeterNumber ="+txt_MeterNumber.Text+@"
                );";
            }

            await LoadMaintenanceGridAsync(WhereStr);

            this.Cursor = Cursors.Arrow;
        }

        private async void Search_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            combo_CompanySectorDept_Level.SelectedIndex = 0;

            _systemService = new SystemInfoService();
            bool isOnline = await _systemService.InitializeAsync();
            await LoadCompaniesAsync();
            await LoadLabCentersAsync();

        }
        private async Task LoadMaintenanceGridAsync(string  whereStr)
        {
            try
            {
                DG2Source.Rows.Clear();

                dataGridView2.Cursor = Cursors.WaitCursor;
                dataGridView2.RowTemplate.Height = 40;
                using (var service = new MaintenanceRecordViewService())
                {
                    await service.InitializeAsync();

                    var data = await service.GetByWhereAsync(whereStr);
                    DG2Source = data.ToDataTable();
                    DG2Source.Columns.Add("Column_View", typeof(string));

                    foreach (DataRow row in DG2Source.Rows)
                    {
                        row["Column_View"] = "VIEW";
                    }

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

        private async Task LoadCompaniesAsync()
        {
            var companies = await _systemService.GetCompaniesAsync();
            DataTable   table = companies.ToDataTable();
            DataRow row = table.NewRow();
            row[0] = 0;
            row[1] = "الكل";
            table.Rows.InsertAt(row, 0);
            combo_Company.DataSource = table;
            combo_Company.DisplayMember = "CompanySectorDeptName";
            combo_Company.ValueMember = "Id";
        }
        private async Task LoadLabCentersAsync()
        {
            var labs = await _systemService.GetLabCentersAsync();
            DataTable labs_table=labs.ToDataTable();
            DataRow row = labs_table.NewRow();
            row[0] = 0;
            row[1] = "الكل";
            labs_table.Rows.InsertAt(row,0);
            combo_LabCenter.DataSource = labs_table;
            combo_LabCenter.DisplayMember = "LabCenterName";
            combo_LabCenter.ValueMember = "Id";

        }

        private async void combo_CompanySectorDept_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combo_CompanySectorDept_Level.SelectedIndex)
            {
                case 0:
                    {
                        combo_Company.Visible = false;
                        combo_sector.Visible = false;
                        combo_Department.Visible = false;
                    }
                    break;
                case 1:
                    combo_Company.Visible = true;
                    combo_sector.Visible = false;
                    combo_Department.Visible = false;
                    break;

                case 2:
                    combo_Company.Visible = true;
                    combo_sector.Visible = true;
                    combo_Department.Visible = false;

                    if (combo_Company.SelectedValue is int cid)
                        await LoadSectorsAsync(cid);
                    break;

                case 3:
                    combo_Company.Visible = true;
                    combo_sector.Visible = true;
                    combo_Department.Visible = true;

                    if (combo_sector.SelectedValue is int sid)
                        await LoadDepartmentsAsync(sid);
                    break;
            }
        }

        private async Task LoadSectorsAsync(int companyId)
        {
            var sectors = await _systemService.GetSectorsAsync(companyId);
            DataTable table=sectors.ToDataTable();
            DataRow row = table.NewRow();
            row[0] = 0;
            row[1] = "الكل";
            table.Rows.InsertAt(row, 0);

            combo_sector.DataSource = table;
            combo_sector.DisplayMember = "CompanySectorDeptName";
            combo_sector.ValueMember = "Id";
        }

        private async Task LoadDepartmentsAsync(int sectorId)
        {
            var deps = await _systemService.GetDepartmentsAsync(sectorId);
            DataTable table = deps.ToDataTable();
            DataRow row = table.NewRow();
            row[0] = 0;
            row[1] = "الكل";
            table.Rows.InsertAt(row, 0);
            combo_Department.DataSource = table;
            combo_Department.DisplayMember = "CompanySectorDeptName";
            combo_Department.ValueMember = "Id";
        }

        private async void combo_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Company.SelectedValue is int sid)
                await LoadSectorsAsync(sid);
        }

        private async void combo_sector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_sector.SelectedValue is int sid)
                await LoadDepartmentsAsync(sid);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "Column_View")
            {
                var row = dataGridView2.Rows[e.RowIndex];

                var code = row.Cells["Column_MaintenanceRecordCode"].Value?.ToString();

                SelectedCode = code; 
                this.Close();
               
            }
        }
    }
}
