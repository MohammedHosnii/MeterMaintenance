using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace MeterMaintenanceApp.ReportForms
{
    public partial class FrmReportViewer : Form
    {
        DataTable dt;
        DataTable dt2;
        string path;


        string[] arg;

        public FrmReportViewer()
        {
            InitializeComponent();
        }
        public FrmReportViewer(DataTable ReportDataTable, string ReportPath, params string[] Q)
        {
            InitializeComponent();


            dt = ReportDataTable;
            path = ReportPath;



            arg = new string[Q.Length];

            try
            {
                for (int i = 0; i < Q.Length; i++)
                {
                    arg[i] = Q[i];
                }
            }
            catch (Exception nex)
            {

            }





        }


        private void FrmReportViewer_Load(object sender, EventArgs e)
        {



            ReportDocument rpt = new ReportDocument();
            rpt.PrintOptions.PaperSize = PaperSize.PaperA4;




            rpt.Load(Application.StartupPath + path);




            string s = "'";
            try
            {


                for (int i = 0; i < arg.Length; i++)
                {
                    rpt.DataDefinition.FormulaFields["arg" + i.ToString()].Text = s + this.arg[i] + s;
                }


            }
            catch (Exception exarg) { }

            if (dt != null)
            {
                try
                {
                    rpt.SetDataSource(dt);
                }
                catch (DataSourceException ex)
                {
                    MessageBox.Show(ex.Message);


                }
            }

            if (dt2 != null)
            {
                try
                {
                    rpt.Database.Tables[0].SetDataSource(dt);
                    rpt.Database.Tables[1].SetDataSource(dt2);
                }
                catch (DataSourceException ex)
                {
                    MessageBox.Show(ex.Message);


                }
            }



            crystalReportViewer1.ReportSource = rpt;

            crystalReportViewer1.Zoom(1);

            crystalReportViewer1.Refresh();


            crystalReportViewer1.RightToLeft = RightToLeft.Yes;

        }

    }
}
