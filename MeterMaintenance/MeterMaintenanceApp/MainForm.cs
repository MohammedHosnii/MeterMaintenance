using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterMaintenanceApp.Services;
using MeterMaintenanceDB;
 

namespace MeterMaintenanceApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private SystemInfoService _systemService;
        private async void MainForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _systemService = new SystemInfoService();
            try
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = ".......جاري الاتصال بالسيرفر";

                bool isOnline = await _systemService.InitializeAsync();

                if (!isOnline)
                {
                    GoOffline();
                    return;
                }

                textBox1.ForeColor = Color.Green;
                textBox1.Text = "ONLINE";

                textBox2.Text = "..........جاري تحميل البيانات";

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;

                using (var connection = new SqlConnection(_systemService.GetConnectionString()))
                {
                    await connection.OpenAsync();
                    var syncRepo = new SyncRepository(connection);
                    await syncRepo.ExecuteSyncAllTablesAsync();
                }

                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 100;
                GoOffline();
                
            }
            catch
            {
                GoOffline();
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
        private void GoOffline()
        {
            textBox1.ForeColor = Color.Red;
            textBox1.Text = "OFFLINE";

            var offlineForm = new MaintenanceRecordForm_OFFLine();
            offlineForm.Show();

            Hide();
        }

    }
}
