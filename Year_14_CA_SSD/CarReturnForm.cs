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

namespace Year_14_CA_SSD
{

    public partial class CarReturnForm : Form
    {
        public event EventHandler Return;
        public int? CarId;
        public int? EmployeeId;
        public int? CustomerId;
        public int? TestDriveId;

        public bool UseTestDriveId = false;

        public int mileage;
        public DateTime endTime;
        public decimal? carPrice;

        public CarReturnForm()
        {
            InitializeComponent();
        }

        private void Car_DropDown_Click(object sender, EventArgs e)
        {
            Car_Picker();
        }
        void Car_Picker()
        {
            PickerForm carPicker = new PickerForm() { Table = "Cars" };
            if (carPicker.ShowDialog() == DialogResult.OK)
            {
                CarId = carPicker.SelectedId;
                Load_Car_Data();
            }
        }
        void Employee_Picker()
        {
            PickerForm employeePicker = new PickerForm() { Table = "Employees" };
            if (employeePicker.ShowDialog() == DialogResult.OK)
            {
                EmployeeId = employeePicker.SelectedId;
                Load_Employee_Data();
            }
        }
        void Load_Customer_Data()
        {
            try
            {
                Customer_Tool_Tip.RemoveAll();
                int id = (int)CustomerId;
                string[] values = SQL_Operation.ReadEntry(id, "CustomerId", "CustomerTable");
                if (values == null)
                {
                    throw new Exception();
                }
                Customer_Name_Label.Text = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                Customer_Tool_Tip.SetToolTip(Customer_Name_Label, Customer_Name_Label.Text);

                Cust_Tel_Label.Text = values[5];
                Customer_Tool_Tip.SetToolTip(Cust_Tel_Label, Cust_Tel_Label.Text);

                Cust_DOB_Label.Text = Globals.removeTime(values[4]);
                Customer_Tool_Tip.SetToolTip(Cust_DOB_Label, Cust_DOB_Label.Text);

                Postcode_Label.Text = values[10];
                Customer_Tool_Tip.SetToolTip(Postcode_Label, Postcode_Label.Text);

                Cust_Email_Label.Text = values[6];
                Customer_Tool_Tip.SetToolTip(Cust_Email_Label, Cust_Email_Label.Text);

                PrevCust_Label.Text = Globals.boolToYN(values[15]);
                Customer_Tool_Tip.SetToolTip(PrevCust_Label, PrevCust_Label.Text);

                Cust_LicenseNo_Label.Text = values[11];
                Customer_Tool_Tip.SetToolTip(Cust_LicenseNo_Label, Cust_LicenseNo_Label.Text);

                Cust_Issue_Label.Text = Globals.removeTime(values[12]);
                Customer_Tool_Tip.SetToolTip(Cust_Issue_Label, Cust_Issue_Label.Text);

                Cust_Expiry_Label.Text = Globals.removeTime(values[13]);
                Customer_Tool_Tip.SetToolTip(Cust_Expiry_Label, Cust_Expiry_Label.Text);

                Verified_Label.Text = Globals.boolToYN(values[14]);
                Customer_Tool_Tip.SetToolTip(Verified_Label, Verified_Label.Text);
            }
            catch
            {
                Customer_Tool_Tip.RemoveAll();
                CustomerId = null;
                Customer_Name_Label.Text = " ";
                Cust_Tel_Label.Text = "";
                Cust_DOB_Label.Text = "";
                Postcode_Label.Text = "";
                Cust_Email_Label.Text = "";
                PrevCust_Label.Text = "";
                Cust_LicenseNo_Label.Text = "";
                Cust_Issue_Label.Text = "";
                Cust_Expiry_Label.Text = "";
                Verified_Label.Text = "";
            }
        }

        void Load_Employee_Data()
        {
            try
            {
                Employee_Tool_Tip.RemoveAll();
                int id = (int)EmployeeId;
                string[] values = SQL_Operation.ReadEntry(id, "EmployeeId", "EmployeeTable");
                if (values == null)
                {
                    throw new Exception();
                }
                Employee_Name_Label.Text = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                Employee_Tool_Tip.SetToolTip(Employee_Name_Label, Employee_Name_Label.Text);

                Employee_DOB_Label.Text = Globals.removeTime(values[4]);
                Employee_Tool_Tip.SetToolTip(Employee_DOB_Label, Employee_DOB_Label.Text);

                Employee_Tel_Label.Text = values[5];
                Employee_Tool_Tip.SetToolTip(Employee_Tel_Label, Employee_Tel_Label.Text);

                Employee_Email_Label.Text = values[6];
                Employee_Tool_Tip.SetToolTip(Employee_Email_Label, Employee_Email_Label.Text);

                Employee_Username_Label.Text = values[13];
                Employee_Tool_Tip.SetToolTip(Employee_Username_Label, Employee_Username_Label.Text);
            }
            catch
            {
                Employee_Tool_Tip.RemoveAll();
                EmployeeId = null;
                Employee_Name_Label.Text = "";
                Employee_DOB_Label.Text = "";
                Employee_Tel_Label.Text = "";
                Employee_Email_Label.Text = "";
                Employee_Username_Label.Text = "";
            }
        }

        void Load_Car_Data()
        {
            try
            {
                Car_Tool_Tip.RemoveAll();
                int id = (int)CarId;
                string[] values = SQL_Operation.ReadEntry(id, "CarId", "CarTable");
                if (values == null)
                {
                    throw new Exception();
                }

                Car_TextBox.Text = Globals.removeWhitespace(Globals.getYear(values[4]) + " " + values[1] + " " + values[2]);
                Car_Tool_Tip.SetToolTip(Car_TextBox, Car_TextBox.Text);

                Registration_Label.Text = values[3];
                Car_Tool_Tip.SetToolTip(Registration_Label, Registration_Label.Text);

                mileage = Convert.ToInt32(values[5]);
                Mileage_Label.Text = Globals.addCommaToNumber(values[5]) + "km";
                Car_Tool_Tip.SetToolTip(Mileage_Label, Mileage_Label.Text);

                Bodystyle_Label.Text = values[11];
                Car_Tool_Tip.SetToolTip(Bodystyle_Label, Bodystyle_Label.Text);

                Colour_Label.Text = values[10];
                Car_Tool_Tip.SetToolTip(Colour_Label, Colour_Label.Text);

                NoOfSeats_Label.Text = values[12];
                Car_Tool_Tip.SetToolTip(NoOfSeats_Label, NoOfSeats_Label.Text);

                Transmission_Label.Text = values[6];
                Car_Tool_Tip.SetToolTip(Transmission_Label, Transmission_Label.Text);

                FuelType_Label.Text = values[7];
                Car_Tool_Tip.SetToolTip(FuelType_Label, FuelType_Label.Text);

                Engine_Size_Label.Text = values[8] + "l";
                Car_Tool_Tip.SetToolTip(Engine_Size_Label, Engine_Size_Label.Text);

                Power_Label.Text = values[9] + "hp";
                Car_Tool_Tip.SetToolTip(Power_Label, Power_Label.Text);
            }
            catch
            {
                Car_Tool_Tip.RemoveAll();
                MessageBox.Show("Error in reading car data");
                CarId = null;
                Car_TextBox.Text = "";
                Registration_Label.Text = "";
                Mileage_Label.Text = "";
                Bodystyle_Label.Text = "";
                Colour_Label.Text = "";
                NoOfSeats_Label.Text = "";
                Transmission_Label.Text = "";
                FuelType_Label.Text = "";
                Engine_Size_Label.Text = "";
                Power_Label.Text = "";
            }
        }
        void Load_Test_Drive_Data()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT TestDriveTypeTable.Description, CarUnavailabiltyTable.StartTime " +
                        $"FROM TestDriveTable " +
                        $"INNER JOIN CarUnavailabiltyTable ON TestDriveTable.CarUnavailabiltyId = CarUnavailabiltyTable.CarUnavailabiltyId " +
                        $"INNER JOIN TestDriveTypeTable ON TestDriveTable.TestDriveType = TestDriveTypeTable.TestDriveTypeId " +
                        $"WHERE TestDriveTable.TestDriveId = '{TestDriveId}'";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    Length_ComboBox.Text = reader["Description"].ToString();
                    Date_DateTimePicker.Value = Convert.ToDateTime(reader["StartTime"].ToString());
                    conn.Close();
                    return;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured");
                    return;
                }
            }
        }

        private void Car_TextBox_Click(object sender, EventArgs e)
        {
            Car_Picker();
        }

        private void Employee_TextBox_Click(object sender, EventArgs e)
        {
            Employee_Picker();
        }

        private void Employee_DropDown_Click(object sender, EventArgs e)
        {
            Employee_Picker();
        }

        private void CarReturnForm_Load(object sender, EventArgs e)
        {
            Clear_Details();
            Date_DateTimePicker.MaxDate = DateTime.Now.AddDays(7);
            Time_Returned_DateTimePicker.MaxDate = DateTime.Now;
            if (UseTestDriveId)
            {
                Load_Car_Data();
                Load_Customer_Data();
                Load_Employee_Data();
                Load_Test_Drive_Data();
                Mileage_NumericUpDown.Minimum = mileage;
            }
            else
            {
                CarId = null;
                CustomerId = null;
                EmployeeId = null;
                TestDriveId = null;
            }
        }
        
        string Get_Opening_Times()
        {
            int dayOfWeek = (int)Date_DateTimePicker.Value.DayOfWeek;
            if (dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }
            dayOfWeek--;
            return Globals.settings.OpenningTimes[dayOfWeek];
        }
        string Get_Closing_Times()
        {
            int dayOfWeek = (int)Date_DateTimePicker.Value.DayOfWeek;
            if (dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }
            dayOfWeek--;
            return Globals.settings.ClosingTimes[dayOfWeek];
        }
        int Convert_Time_To_Minutes(string time)
        {
            try
            {
                int minutes = 0;
                int hours = 0;
                if (time.Length == 5)
                {
                    hours = Convert.ToInt32(time.Substring(0, 2));
                    minutes = Convert.ToInt32(time.Substring(3, 2));
                }
                else if (time.Length == 4)
                {
                    hours = Convert.ToInt32(time.Substring(0, 1)); //first part of time eg 1 part of 1:50
                    minutes = Convert.ToInt32(time.Substring(2, 2));
                }
                return hours * 60 + minutes;
            }
            catch
            {
                MessageBox.Show("Error");
                return 0;
            }
        }
        void Clear_Details()
        {
            Customer_Name_Label.Text = "Customer Name";
            Cust_Tel_Label.Text = "";
            Cust_DOB_Label.Text = "";
            Postcode_Label.Text = "";
            Cust_Email_Label.Text = "";
            PrevCust_Label.Text = "";
            Cust_LicenseNo_Label.Text = "";
            Cust_Issue_Label.Text = "";
            Cust_Expiry_Label.Text = "";
            Verified_Label.Text = "";

            Employee_Name_Label.Text = "Employee Name";
            Employee_DOB_Label.Text = "";
            Employee_Tel_Label.Text = "";
            Employee_Email_Label.Text = "";
            Employee_Username_Label.Text = "";

            Car_TextBox.Text = "";
            Registration_Label.Text = "";
            Mileage_Label.Text = "";
            Bodystyle_Label.Text = "";
            Colour_Label.Text = "";
            NoOfSeats_Label.Text = "";
            Transmission_Label.Text = "";
            FuelType_Label.Text = "";
            Engine_Size_Label.Text = "";
            Power_Label.Text = "";
        }

        private void Find_Test_Drive_Button_Click(object sender, EventArgs e)
        {
            Find_Test_Drive();
        }
        DateTime? Get_Start_Date()
        {
            try
            {
                return Convert.ToDateTime(Date_DateTimePicker.Value.ToString("d"));
            }
            catch
            {
                return null;
            }

        }
        DateTime? Get_End_Date()
        {
            try
            {
                DateTime startDate = (DateTime)Get_Start_Date(); 
                if (Length_ComboBox.Text == "30 Minutes")
                {
                    return startDate.AddDays(1);
                }
                else if (Length_ComboBox.Text == "1 Day")
                {
                    return startDate.AddDays(2);
                }
                else if (Length_ComboBox.Text == "Weekend")
                {
                    return startDate.AddDays(4);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return null;
            }
        }
        void Find_Test_Drive() 
        {
            if(CarId == null)
            {
                MessageBox.Show("Car must be picked");
                return;
            }
            if(Length_ComboBox.Text == "")
            {
                MessageBox.Show("Length must be picked");
                return;
            }
            DateTime startDate = (DateTime)Get_Start_Date();
            DateTime endDate = (DateTime)Get_End_Date();

            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT TestDriveTable.TestDriveId,TestDriveTable.CustomerId,TestDriveTable.EmployeeId FROM TestDriveTable " +
                        $"INNER JOIN CarUnavailabiltyTable ON TestDriveTable.CarUnavailabiltyId = CarUnavailabiltyTable.CarUnavailabiltyId " +
                        $"WHERE CarUnavailabiltyTable.CarId = '{CarId}' AND CarUnavailabiltyTable.StartTime >= '{startDate.ToString("yyyy/MM/dd HH:mm:ss")}' AND CarUnavailabiltyTable.EndTime <= '{endDate.ToString("yyyy/MM/dd HH:mm:ss")}' ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    TestDriveId = Convert.ToInt32(reader["TestDriveId"]);
                    CustomerId = Convert.ToInt32(reader["CustomerId"]);
                    string employeeIdText = reader["EmployeeId"].ToString();
                    conn.Close();
                    Load_Customer_Data();
                    if (employeeIdText != "")
                    {
                        EmployeeId = Convert.ToInt32(employeeIdText);
                        Load_Employee_Data();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured");
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Test Drive cannot be found");
                    return;
                }
                
            }
            Mileage_NumericUpDown.Minimum = mileage;

        }

        private void Return_Button_Click(object sender, EventArgs e)
        {
            if (TestDriveId == null)
            {
                MessageBox.Show("Test Drive hasn't been found");
                return;
            }
            if(!Car_Returned_CheckBox.Checked)
            {
                MessageBox.Show("Car has not been marked as returned");
                return;
            }
            try
            {
                string[] carColumns = { "Mileage", "NeedsCleaned", "NeedsInspected" };
                string[] carValues = { Mileage_NumericUpDown.Value.ToString(), Convert.ToString(!Cleaned_CheckBox.Checked), Convert.ToString(!Inspected_CheckBox.Checked) };
                if(!SQL_Operation.UpdateEntryVariables((int)CarId, "CarId",carColumns , carValues, "CarTable"))
                {
                    MessageBox.Show("An error occured when updating the car database");
                    return;
                }
                string[] testColumns = { "HasBeenReturned", "ReturnedDamaged" };
                string[] testValues = { Car_Returned_CheckBox.Checked.ToString(), Convert.ToString(Car_Damaged_CheckBox.Checked) };
                if (!SQL_Operation.UpdateEntryVariables((int)TestDriveId, "TestDriveId",testColumns,testValues,"TestDriveTable"))
                {
                    MessageBox.Show("An error occured when updating the test drive database");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("An error occured");
                return;
            }

            decimal mileageFee = Calculate_Mileage_Fee();
            if(mileageFee != 0)
            {
                Create_Fee(mileageFee, "Fee for going over the mileage limit");
            }
            int hoursLate = Calculate_Hours_Late();
            if(hoursLate > 0)
            {
                decimal lateFee = Calculate_Late_Fee(hoursLate);
                Create_Fee(lateFee, "Fee for returning car late");
            }
            decimal damageFee = Get_Car_Damage_Fee();
            if(damageFee > 0)
            {
                Create_Fee(damageFee, "Fee for damaging a car");
            }
            if(Return != null)
            {
                Return.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }
        decimal Calculate_Mileage_Fee()
        {
            int mileageOver = Calculate_Mileage_Over_Limit();
            return mileageOver * Globals.settings.MileageFee;
            
        }
        int Calculate_Mileage_Over_Limit()
        {
            try
            {
                int mileageIncrease = Convert.ToInt32(Mileage_NumericUpDown.Value - Mileage_NumericUpDown.Minimum);
                int typeOfBooking = Length_ComboBox.SelectedIndex;
                int mileageLimit = Globals.settings.MileageLimits[typeOfBooking];
                if (mileageIncrease <= mileageLimit || mileageLimit == 0)
                {
                    return 0;
                }
                return mileageIncrease - mileageLimit;
            }
            catch
            {
                return 0;
            }
        }
        void Create_Fee(decimal amount, string description)
        {
            string[] paymentValues = { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), CustomerId.ToString(), amount.ToString("F"), "Fee",description, "False", "False" };
            if (!SQL_Operation.CreateEntry(paymentValues, "PaymentTable"))
            {
                MessageBox.Show("An error occurred");
            }
        }

        private void Car_Not_Damaged_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Car_Damaged_CheckBox.Checked)
            {
                decimal carPrice = Get_Car_Price();
                if(carPrice == 0)
                {
                    Fee_FlowLayoutPanel.Controls.Remove(Damage_Fee_Label);
                    Damage_Fee_Label.Visible = false;
                    return;
                }
                Damage_Fee_Label.Text = $"Damage Fee: £{Get_Car_Damage_Fee().ToString("F")}";
                Fee_FlowLayoutPanel.Controls.Add(Damage_Fee_Label);
                Damage_Fee_Label.Visible = true;
            }
            else
            {
                Fee_FlowLayoutPanel.Controls.Remove(Damage_Fee_Label);
            }
        }
        decimal Get_Car_Damage_Fee()
        {
            return Get_Car_Price() * Convert.ToDecimal(Globals.settings.DepositPercent) / 100;
        }
        decimal Get_Car_Price()
        {
            if (!carPrice.HasValue)
            {
                if (!CarId.HasValue)
                {
                    return 0;
                }
                carPrice = Convert.ToDecimal(SQL_Operation.ReadColumn(CarId.Value, "CarId", "Price", "CarTable"));
            }
            return carPrice.Value;
        }

        private void Car_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void Mileage_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int mileageOver = Calculate_Mileage_Over_Limit();
            if (mileageOver > 0)
            {
                Mileage_Fee_Label.Text = $"Mileage Fee ({mileageOver} Miles): £{Calculate_Mileage_Fee().ToString("F")}";
                if (!Fee_FlowLayoutPanel.Controls.Contains(Mileage_Fee_Label))
                {
                    Fee_FlowLayoutPanel.Controls.Add(Mileage_Fee_Label);
                    Mileage_Fee_Label.Visible = true;
                }
            }
            else
            {
                if (Fee_FlowLayoutPanel.Controls.Contains(Mileage_Fee_Label))
                {
                    Fee_FlowLayoutPanel.Controls.Remove(Mileage_Fee_Label);
                }
                Mileage_Fee_Label.Visible = false;
            }
        }

        private void Time_Returned_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            int hoursLate = Calculate_Hours_Late();
            if(hoursLate > 0)
            {
                Late_Fee_Label.Text = $"Late Fee ({hoursLate} Hours): £{Calculate_Late_Fee(hoursLate).ToString("F")}";
                if(!Fee_FlowLayoutPanel.Controls.Contains(Late_Fee_Label))
                {
                    Fee_FlowLayoutPanel.Controls.Add(Late_Fee_Label);
                    Late_Fee_Label.Visible = true;
                }
            }
            else
            {
                if(Fee_FlowLayoutPanel.Controls.Contains(Late_Fee_Label))
                {
                    Fee_FlowLayoutPanel.Controls.Remove(Late_Fee_Label);
                }
                Late_Fee_Label.Visible = false;
            }
        }
        decimal Calculate_Late_Fee(int hoursLate)
        {
            return hoursLate * Globals.settings.LateFee; //5.0m to be replaced with setting
        }
        int Calculate_Hours_Late()
        {
            if(endTime == DateTime.MinValue)
            {
                if (!TestDriveId.HasValue)
                {
                    return 0;
                }
                int carUnavailId = Convert.ToInt32(SQL_Operation.ReadColumn(TestDriveId.Value, "TestDriveId", "CarUnavailabiltyId", "TestDriveTable"));
                endTime = Convert.ToDateTime(SQL_Operation.ReadColumn(carUnavailId, "CarUnavailabiltyId", "EndTime", "CarUnavailabiltyTable"));
            }
            TimeSpan hoursDiff = Time_Returned_DateTimePicker.Value - endTime.AddHours(Globals.settings.TimeBeforeLate.TotalHours); //2 to be replaced with setting
            double lateHoursRaw = hoursDiff.TotalHours;
            int hoursLate = Convert.ToInt32(Math.Ceiling(lateHoursRaw));
            

            if(hoursLate < 0) { hoursLate = 0; }
            return hoursLate;
        }
    }
}
