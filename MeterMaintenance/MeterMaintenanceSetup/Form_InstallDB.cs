using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterMaintenanceDB;
using MeterMaintenanceDB.DatabaseInstallation;
using MeterMaintenanceDB.Model;

namespace MeterMaintenanceSetup
{
    public partial class Form_InstallDB : Form
    {
        TestConnection testConnection = new TestConnection();
        User currentUser; 
        UserRepository userRepository;
        DatabaseInstaller databaseInstaller;
        public Form_InstallDB()
        {
            InitializeComponent();
        }

        private void Form_InstallDB_Load(object sender, EventArgs e)
        {
            if( !testConnection.CheckServerConnection())
            {
                MessageBox.Show("برجاء الاتصال بالسيرفر اولا");
                this.Close();
                return;
            }
            
            userRepository = new UserRepository(testConnection.GetServerConnection());

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (string.IsNullOrWhiteSpace(txt_userCode.Text))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("برجاء إدخال كود المشترك");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_UserName.Text))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("برجاء إدخال اسم المشترك");
                return;
            }

            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            button1.Enabled = false;

            try
            {
                var existingUser = await userRepository.GetByCodeAsync(txt_userCode.Text);

                if (existingUser != null)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("كود المشترك موجود بالفعل");
                    return;
                }

                var newUser = new User
                {
                    UserCode = txt_userCode.Text,
                    UserName = txt_UserName.Text.Trim(),
                    UserPassword = txt_UserPassword.Text.Trim(),
                    UserDegree = "1"
                };

                int newId = await userRepository.AddAsync(newUser);
                currentUser = await userRepository.GetByIdAsync(newId);

                if (currentUser == null)
                    return;

                databaseInstaller = new DatabaseInstaller(
                    testConnection.GetLocalConnection());
                textBox1.Text = "Creating DataBase......";
                // Step 1 – Create DB (30%)
                await Task.Run(() => databaseInstaller.CreateDatabase());
                progressBar1.Value = 30;
                textBox1.Text = "Creating Tables......";
                // Step 2 – Create Tables (60%)
                await Task.Run(() =>
                    databaseInstaller.CreateTables(
                        currentUser.UserCode,
                        currentUser.UserName));
                progressBar1.Value = 60;
                textBox1.Text = "Creating Procedures & Functions......";
                // Step 3 – Create SP (90%)
                await Task.Run(() =>
                    databaseInstaller.CreateStoredProcedures());
                progressBar1.Value = 90;
                textBox1.Text = "Sync DataBase......";
                // Step 4 – Sync (95%)
                await databaseInstaller.ExecSPSyncAsync();
                progressBar1.Value = 95;

                // Finish
                progressBar1.Value = 100;
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("تم ضبط الاعدادات بنجاح  🎉");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                progressBar1.Visible = false;
                button1.Enabled = true;
            }
        }
        //private async void button1_Click_xx(object sender, EventArgs e)
        //{
        //    if(String.IsNullOrEmpty(txt_userCode.Text))
        //    {
        //        MessageBox.Show("برجاء أدخال كود المشترك");
        //        return;
        //    }
        //    if (String.IsNullOrEmpty(txt_UserName.Text))
        //    {
        //        MessageBox.Show("برجاء أدخال كود المشترك");
        //        return;
        //    }
             
        //    var existingUser = await userRepository.GetByCodeAsync(txt_userCode.Text);
        //    if (existingUser != null)
        //    {
        //        MessageBox.Show("كود المشترك موجود بالفعل، يرجى إدخال كود جديد");
        //        return;
        //    }

        //    var newUser = new User
        //    {
        //        UserCode = txt_userCode.Text,
        //        UserName = txt_UserName.Text.Trim(),
        //        UserPassword = txt_UserPassword.Text.Trim(),
        //        UserDegree = "1"
        //    };

        //    int newId =  await userRepository.AddAsync(newUser);
        //    currentUser=await userRepository.GetByIdAsync(newId);
        //    if (currentUser != null) 
        //    {

        //        databaseInstaller = new DatabaseInstaller(testConnection.GetLocalConnection().ConnectionString);
        //        databaseInstaller.Install(currentUser.UserCode,
        //            currentUser.UserName);
        //    }
        //    MessageBox.Show("تم إضافة المشترك بنجاح");

        //}
    }
}
