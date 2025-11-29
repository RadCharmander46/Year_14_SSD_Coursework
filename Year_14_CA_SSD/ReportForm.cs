using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            Load_Report();
        }
        public void Load_Report()
        {
            try
            {
                sqlConnection1.Open();

                sqlDataAdapter1.SelectCommand.Parameters.Clear();
                sqlDataAdapter1.SelectCommand.Parameters.AddWithValue("@CustId", 3);
                dsTestDriveBookings1.Clear();

                dsTestDriveBookings1.EnforceConstraints = false;
                sqlDataAdapter1.Fill(dsTestDriveBookings1, "CarTable");

                TestDriveCustomerReport report = new TestDriveCustomerReport();
                report.SetDataSource(dsTestDriveBookings1);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show("an error occurred");
            }
            finally
            {
                sqlConnection1.Close();
            }
        }
    }
}
