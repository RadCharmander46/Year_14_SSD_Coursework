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
        int? customerId;
        public ReportForm()
        {
            InitializeComponent();
        }
        public void Load_Customer_Report()
        {
            try
            {
                sqlConnectionCustomer.Open();

                sqlDataAdapterCustomer.SelectCommand.Parameters.Clear();
                sqlDataAdapterCustomer.SelectCommand.Parameters.AddWithValue("@CustId", 3);
                dsTestDriveCustomer.Clear();

                dsTestDriveCustomer.EnforceConstraints = false;
                sqlDataAdapterCustomer.Fill(dsTestDriveCustomer, "CarTable");

                TestDriveCustomerReport report = new TestDriveCustomerReport();
                report.SetDataSource(dsTestDriveCustomer);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show("an error occurred");
            }
            finally
            {
                sqlConnectionCustomer.Close();
            }
        }
        public void Load_Times_Report()
        {
            try
            {
                sqlConnectionCustomer.Open();

                dsTestDriveTimes.Clear();

                dsTestDriveTimes.EnforceConstraints = false;
                sqlDataAdapterTimes.Fill(dsTestDriveTimes, "CarTable");

                TestDriveTimesReport report = new TestDriveTimesReport();
                report.SetDataSource(dsTestDriveTimes);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show("an error occurred");
            }
            finally
            {
                sqlConnectionCustomer.Close();
            }
        }

        private void Customer_TextBox_Click(object sender, EventArgs e)
        {
            Customer_DropDown();
        }
        void Customer_DropDown()
        {
            PickerForm customerPicker = new PickerForm() { Table = "Customers" };
            customerPicker.ShowDialog();
            if(customerPicker.DialogResult == DialogResult.OK)
            {
                customerId = Convert.ToInt32(customerPicker.SelectedId);
            }
                
        }

        private void View_Report_Button_Click(object sender, EventArgs e)
        {
            if (Time_RadioButton.Checked)
            {
                Load_Times_Report();
            }
            else if(Customer_RadioButton.Checked)
            {
                Load_Customer_Report();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
