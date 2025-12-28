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
        public int? CarId;
        public int? EmployeeId;
        public int? CustomerId;
        public int? TestDriveId;

        public int mileage;

        public CarReturnForm()
        {
            InitializeComponent();
        }

        private void Employee_Tel_Label_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Email_Label_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Username_Label_Click(object sender, EventArgs e)
        {

        }

      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Date_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                int id = (int)CustomerId;
                string[] values = SQL_Operation.ReadEntry(id, "CustomerId", "CustomerTable");
                if (values == null)
                {
                    throw new Exception();
                }
                Customer_Name_Label.Text = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                Cust_Tel_Label.Text = "Tel: " + values[5];
                Cust_DOB_Label.Text = "Date Of Birth: " + Globals.removeTime(values[4]);
                Postcode_Label.Text = "Postcode: " + values[10];
                Cust_Email_Label.Text = "Email: " + values[6];
                PrevCust_Label.Text = "Previous Customer: " + Globals.boolToYN(values[15]);
                Cust_LicenseNo_Label.Text = "License No: " + values[11];
                Cust_Issue_Label.Text = "Issue: " + Globals.removeTime(values[12]);
                Cust_Expiry_Label.Text = "Expiry: " + Globals.removeTime(values[13]);
                Verified_Label.Text = "Verified: " + Globals.boolToYN(values[14]);
            }
            catch
            {
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
                int id = (int)EmployeeId;
                string[] values = SQL_Operation.ReadEntry(id, "EmployeeId", "EmployeeTable");
                if (values == null)
                {
                    throw new Exception();
                }
                Employee_Name_Label.Text = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                Employee_DOB_Label.Text = "Date Of Birth: " + Globals.removeTime(values[4]);
                Employee_Tel_Label.Text = "Tel: " + values[5];
                Employee_Email_Label.Text = "Email: " + values[6];
                Employee_Username_Label.Text = "Username: " + values[13];
            }
            catch
            {
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
                int id = (int)CarId;
                string[] values = SQL_Operation.ReadEntry(id, "CarId", "CarTable");
                if (values == null)
                {
                    throw new Exception();
                }
                Car_TextBox.Text = Globals.removeWhitespace(Globals.getYear(values[4]) + " " + values[1] + " " + values[2]);
                Registration_Label.Text = "Reg: " + values[3];
                mileage = Convert.ToInt32(values[5]);
                Mileage_Label.Text = "Mileage: " + Globals.addCommaToNumber(values[5]) + "km";
                Bodystyle_Label.Text = "Body Style: " + values[11];
                Colour_Label.Text = "Colour: " + values[10];
                NoOfSeats_Label.Text = "Number Of Seats: " + values[12];
                Transmission_Label.Text = "Transmission: " + values[6];
                FuelType_Label.Text = "Fuel Type: " + values[7];
                Engine_Size_Label.Text = "Engine Size: " + values[8] + "l";
                Power_Label.Text = "Power: " + values[9] + "hp";
            }
            catch
            {
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

        private void Car_TextBox_TextChanged(object sender, EventArgs e)
        {

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
            CustomerId = null;
            Customer_Name_Label.Text = "Name";
            Cust_Tel_Label.Text = "Tel: ";
            Cust_DOB_Label.Text = "Date Of Birth: ";
            Postcode_Label.Text = "Postcode: ";
            Cust_Email_Label.Text = "Email: ";
            PrevCust_Label.Text = "Previous Customer:";
            Cust_LicenseNo_Label.Text = "License No:";
            Cust_Issue_Label.Text = "Issue:";
            Cust_Expiry_Label.Text = "Expiry";
            Verified_Label.Text = "Verified License:";

            EmployeeId = null;
            Employee_Name_Label.Text = "Name";
            Employee_DOB_Label.Text = "Date Of Birth:";
            Employee_Tel_Label.Text = "Tel:";
            Employee_Email_Label.Text = "Email:";
            Employee_Username_Label.Text = "Username:";

            CarId = null;
            Car_TextBox.Text = "";
            Registration_Label.Text = "Reg:";
            Mileage_Label.Text = "Mileage:";
            Bodystyle_Label.Text = "Body Style:";
            Colour_Label.Text = "Colour:";
            NoOfSeats_Label.Text = "Numebr Of Seats:";
            Transmission_Label.Text = "Transmission";
            FuelType_Label.Text = "Fuel Type:";
            Engine_Size_Label.Text = "Engine Size:";
            Power_Label.Text = "Power:";
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
                DateTime startDate = (DateTime)Get_Start_Date(); //add extra day to each to compensate for lack in time of day
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
                    MessageBox.Show("An error occured");
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
                string[] testValues = { Car_Returned_CheckBox.Checked.ToString(), Convert.ToString(!Car_Not_Damaged_CheckBox.Checked) };
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

            Calculate_Mileage_Fee();

        }
        void Calculate_Mileage_Fee()
        {
            int mileageIncrease = Convert.ToInt32(Mileage_NumericUpDown.Value - Mileage_NumericUpDown.Minimum);
            int typeOfBooking = Length_ComboBox.SelectedIndex;
            int mileageLimit = Globals.settings.MileageLimits[typeOfBooking];
            if(mileageIncrease <= mileageLimit || mileageLimit == 0)
            {
                return;
            }
            int mileageOver = mileageIncrease - mileageLimit;
            decimal mileageFee = mileageOver * Globals.settings.MileageFee;
            MessageBox.Show($"Mileage is over the allocated limit, the following fee must be paid: £{mileageFee}");
            string[] paymentValues = { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),CustomerId.ToString(),mileageFee.ToString(),"Fee","Fee for going over the allocated mileage limit","False","False"};
            if(!SQL_Operation.CreateEntry(paymentValues, "PaymentTable"))
            {
                MessageBox.Show("An error occurred");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Start_Time_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Car_Not_Damaged_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Car_Returned_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
