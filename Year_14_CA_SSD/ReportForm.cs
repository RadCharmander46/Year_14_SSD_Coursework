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
                sqlDataAdapterCustomer.SelectCommand.Parameters.AddWithValue("@CustId", customerId.Value);
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
            if (customerPicker.DialogResult == DialogResult.OK)
            {
                customerId = Convert.ToInt32(customerPicker.SelectedId);
                Load_Customer_Name(customerId.Value);
            }
                
        }
        void Load_Customer_Name(int customerId)
        {
            string[] customerValues = SQL_Operation.ReadEntry(customerId, "CustomerId", "CustomerTable");
            Customer_TextBox.Text = customerValues[1] + " " + customerValues[3];
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

        private void Time_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(Time_RadioButton.Checked)
            {
                Customer_Label.Visible = false;
                Customer_TextBox.Visible = false;
            }
        }

        private void Customer_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(Customer_RadioButton.Checked)
            {
                Customer_Label.Visible = true;
                Customer_TextBox.Visible = true;
            }
        }

        private void Customer_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Customer_Drop_Down_Click(object sender, EventArgs e)
        {
            Customer_DropDown();
        }
    }
}
