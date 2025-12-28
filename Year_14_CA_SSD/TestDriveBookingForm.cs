using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class TestDriveBookingForm : Form
    {
        public TestDriveBookingForm()
        {
            InitializeComponent();
        }
        public event EventHandler HomeScreen;
        public int TestDriveId;
        public int? CustomerId = null;
        public int? EmployeeId = null;
        public int? CarId = null;
        public bool AddMode = true;

        private void TestDriveBookingForm_Load(object sender, EventArgs e)
        {
            Date_DateTimePicker.MinDate = DateTime.Now;
            Date_DateTimePicker.MaxDate = DateTime.Now.AddYears(1);
            Start_Time_ComboBox.Items.Clear();
            Display_Possible_Times();
            if (!AddMode)
            {
                Load_Test_Drive_Data();
                Setup_Edit_Mode();
            }
            else
            {
                Wipe_GroupBoxes();
            }
        }
        void Wipe_GroupBoxes()
        {
            Customer_TextBox.Text = " ";
            Cust_Tel_Label.Text = "Tel:";
            Cust_DOB_Label.Text = "Date Of Birth:";
            Postcode_Label.Text = "";
            Cust_Email_Label.Text = "Email:";
            PrevCust_Label.Text = "Previous Customer:";
            Cust_LicenseNo_Label.Text = "License No:";
            Cust_Issue_Label.Text = "Issue:";
            Cust_Expiry_Label.Text = "Expiry:";
            Verified_Label.Text = "";
            Employee_TextBox.Text = "";
            Employee_DOB_Label.Text = "Date Of Birth:";
            Employee_Tel_Label.Text = "Tel:";
            Employee_Email_Label.Text = "Email:";
            Employee_Username_Label.Text = "Username:";
            Car_TextBox.Text = "";
            Reg_Label.Text = "Reg:";
            Mileage_Label.Text = "Mileage:";
            BodyStyle_Label.Text = "Body Style:";
            Colour_Label.Text = "Colour:";
            NoOfSeats_Label.Text = "Number Of Seats";
            Transmission_Label.Text = "Transmission:";
            FuelType_Label.Text = "Fuel Type:";
            EngineSize_Label.Text = "Engine Size:";
            Power_Label.Text = "Power: ";
        }
        void Setup_Edit_Mode()
        {
            Title_Label.Text = "Edit a Test Drive";
            Book_Test_Drive_Button.Text = "Edit Test Drive";
        }
        void Load_Customer_Data()
        {
            try
            {
                int id = (int)CustomerId;
                string[] values = SQL_Operation.ReadEntry(id, "CustomerId", "CustomerTable");
                if(values == null)
                {
                    throw new Exception();
                }
                Customer_TextBox.Text = Globals.removeWhitespace(values[1] + " "+ values[2] + " " + values[3]);
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
                Customer_TextBox.Text = " ";
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
                if(values == null)
                {
                    throw new Exception();
                }
                Employee_TextBox.Text = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                Employee_DOB_Label.Text = "Date Of Birth: " + Globals.removeTime(values[4]);
                Employee_Tel_Label.Text = "Tel: " + values[5];
                Employee_Email_Label.Text = "Email: " + values[6];
                Employee_Username_Label.Text = "Username: " + values[13];
            }
            catch
            {
                EmployeeId = null;
                Employee_TextBox.Text = "";
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
                if(values == null)
                {
                    throw new Exception();
                }
                Car_TextBox.Text = Globals.removeWhitespace(Globals.getYear(values[4]) + " " + values[1] + " " + values[2]);
                Reg_Label.Text = "Reg: " + values[3];
                Mileage_Label.Text = "Mileage: " + Globals.addCommaToNumber(values[5]) + "km";
                BodyStyle_Label.Text = "Body Style: " + values[11];
                Colour_Label.Text = "Colour: " + values[10];
                NoOfSeats_Label.Text = "Number Of Seats: " + values[12];
                Transmission_Label.Text = "Transmission: " + values[6];
                FuelType_Label.Text = "Fuel Type: " + values[7];
                EngineSize_Label.Text = "Engine Size: " + values[8] + "l";
                Power_Label.Text = "Power: " + values[9] + "hp";
            }
            catch
            {
                MessageBox.Show("Error in reading car data");
                CarId = null;
                Car_TextBox.Text = "";
                Reg_Label.Text = "";
                Mileage_Label.Text = "";
                BodyStyle_Label.Text = "";
                Colour_Label.Text = "";
                NoOfSeats_Label.Text = "";
                Transmission_Label.Text = "";
                FuelType_Label.Text = "";
                EngineSize_Label.Text = "";
                Power_Label.Text = "";
            }
        }
       
        void Load_Test_Drive_Data()
        {
            try
            {
                string[] values = SQL_Operation.ReadEntry(TestDriveId, "TestDriveId", "TestDriveTable");
                CustomerId= Convert.ToInt32(values[1]);
                int carUnavailabiltyId = Convert.ToInt32(values[3]);
                string[] carValues = SQL_Operation.ReadEntry(carUnavailabiltyId, "CarUnavailabiltyId", "CarUnavailabiltyTable");
                CarId = Convert.ToInt32(carValues[1]);
                DateTime startTime = Convert.ToDateTime(carValues[2]);
                DateTime endTime = Convert.ToDateTime(carValues[3]);

                Date_DateTimePicker.Value = startTime;

                int testDriveType = Convert.ToInt32(values[5]);
                if (testDriveType == 1)
                {
                    Length_ComboBox.Text = "30 Minutes";
                }
                else if (testDriveType == 2)
                {
                    Length_ComboBox.Text = "1 Day";
                }
                else if (testDriveType == 3)
                {
                    Length_ComboBox.Text = "Weekend";
                }

                if (values[2] != "")
                {
                    EmployeeId = Convert.ToInt32(values[2]);
                    Load_Employee_Data();
                }

                Load_Customer_Data();
                Load_Car_Data();
                Start_Time_ComboBox.Items.Clear();
                Add_Blocked_Times(startTime, endTime,carUnavailabiltyId);
                Start_Time_ComboBox.Text = startTime.ToShortTimeString();
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured");
            }
        }
        void Add_Blocked_Times(DateTime startTime, DateTime endTime,int carUnavailabiltyId)
        {
            DateTime[][] unavailabiltyTimes = Get_Reduced_Car_Unavailabilty(carUnavailabiltyId);
            double hoursOffset = 0;
            if (Length_ComboBox.Text == "30 Minutes")
            {
                hoursOffset = 0.5d;
            }
            else if (Length_ComboBox.Text == "1 Day")
            {
                hoursOffset = 24;
            }
            else if (Length_ComboBox.Text == "Weekend")
            {
                hoursOffset = 72;
            }
            else
            {
                Start_Time_ComboBox.Items.Add("Pick a length");
                return;
            }
            for (int minutes = Convert_Time_To_Minutes(Get_Opening_Time()); minutes <= Convert_Time_To_Minutes(Get_Closing_Time()); minutes += 5)
            {
                DateTime time = Date_DateTimePicker.Value.Date.AddMinutes(minutes);
                if (!Time_Is_Unavailable(time, time.AddHours(hoursOffset), unavailabiltyTimes) && Globals.timeIsInFuture(time))
                {
                    Start_Time_ComboBox.Items.Add(time.ToShortTimeString());
                }
            }
            if (Start_Time_ComboBox.Items.Count == 0)
            {
                Start_Time_ComboBox.Items.Add("No times available");
            }

        }
        string Get_Opening_Time()
        {
            int dayOfWeek = (int)Date_DateTimePicker.Value.DayOfWeek;
            if(dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }
            dayOfWeek--;
            return Globals.settings.OpenningTimes[dayOfWeek];
        }
        string Get_Closing_Time()
        {
            int dayOfWeek = (int)Date_DateTimePicker.Value.DayOfWeek;
            if (dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }
            dayOfWeek--;
            return Globals.settings.ClosingTimes[dayOfWeek];
        }
        private void Customer_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load_Customer_Data();
            
        }

        private void Car_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Car_Data();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Length_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(Length_ComboBox.Text == "Weekend" && Get_Start_Date().Value.DayOfWeek != DayOfWeek.Friday))
            {
                Display_Price();
                Start_Time_ComboBox.Items.Clear();
                Display_Possible_Times();
                Update_Employee_Accom();
            }
            else
            {
                MessageBox.Show("Weekend test drive must start on friday");
                Length_ComboBox.Text = "";
                Length_ComboBox.SelectedItem = null;
            }
        }

        private void Previous_Customer_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globals.isManager && Previous_Customer_CheckBox.Checked)
            {
                MessageBox.Show("Needs Manager Approval");
                Previous_Customer_CheckBox.Checked = false;
            }
            Display_Price();
        }
        decimal Calculate_Price()
        {
            decimal price = 0;
            if(Length_ComboBox.Text == "Weekend") { 
                price = Globals.settings.TestDriveCosts[2]; 
            }
            else if(Length_ComboBox.Text == "1 Day") {
                price = Globals.settings.TestDriveCosts[1]; 
            }
            else { 
                price = Globals.settings.TestDriveCosts[0]; 
            }
            return price;
        }
        decimal Calculate_Discounted_Price()
        {
            decimal price = Calculate_Price();
            if (Previous_Customer_CheckBox.Checked)
            {
                price *= new decimal(0.85);
            }
            return price;
        }
        void Display_Price()
        {
            decimal price = Calculate_Price();
            Subtotal_Label.Text = $"Subtotal: £{price}";
            decimal discPrice = Calculate_Discounted_Price();
            Total_Label.Text = $"Total: £{discPrice}";
        }
       
        DateTime? Get_Start_Date()
        {
            try
            {
                return Convert.ToDateTime(Date_DateTimePicker.Value.ToString("d") +" "+ Start_Time_ComboBox.Text);
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
                    return startDate.AddMinutes(30);
                }
                else if (Length_ComboBox.Text == "1 Day")
                {
                    return startDate.AddDays(1);
                }
                else if (Length_ComboBox.Text == "Weekend")
                {
                    return startDate.AddDays(3);
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
        int? Create_Car_Unavailabilty()
        {
            try
            {
                DateTime startDate = (DateTime)Get_Start_Date();
                DateTime endDate = (DateTime)Get_End_Date();
                string[] values = { Convert.ToString(CarId), startDate.ToString("yyyy-MM-dd HH:mm:ss"), endDate.ToString("yyyy-MM-dd HH:mm:ss") ,"Out for Test Drive" };
                int? id = SQL_Operation.CreateEntryReturnId(values, "CarUnavailabiltyTable", "CarUnavailabiltyId");
                if(!id.HasValue)
                {
                    throw new Exception();
                }
                return id;
            }
            catch
            {
                return null;
            }
        }
        int? Create_Payment()
        {
            try
            {
                DateTime startTime = (DateTime) Get_Start_Date();
                string[] values = { startTime.ToString("yyyy-MM-dd HH:mm:ss"), CustomerId.ToString(), Calculate_Discounted_Price().ToString(), "Payment", "Paying for test drive","False","False"};
                int? id = SQL_Operation.CreateEntryReturnId(values, "PaymentTable", "PaymentId");
                if(id.HasValue)
                {
                    return id;
                }
                throw new Exception();
            }
            catch
            {
                return null;
            }
        }
        void Create_Test_Drive()
        {
            try
            {
                if (CustomerId == null || CarId == null)
                {
                    throw new Exception();
                }
                if(EmployeeId == null && Employee_Accom.Checked)
                {
                    throw new Exception();
                }
                DateTime[][] unavailabiltyForDay = Get_Unavailabilty_For_Day();
                if (Time_Is_Unavailable((DateTime)Get_Start_Date(), (DateTime)Get_End_Date() ,unavailabiltyForDay))
                {
                    MessageBox.Show("TIme is Unavailabile");
                    throw new Exception();
                }
                DateTime[][] employeeAvailabilty = Get_Employee_Unavailabilty((int)EmployeeId);
                if (Time_Is_Unavailable((DateTime)Get_Start_Date(),(DateTime)Get_End_Date(),employeeAvailabilty,false))
                {
                    MessageBox.Show("Employee is unavailable");
                    throw new Exception();
                }
                int? CarUnavailabityId = Create_Car_Unavailabilty();
                if (!CarUnavailabityId.HasValue)
                {
                    throw new Exception();
                }
                int? PaymentId = Create_Payment();
                if(!PaymentId.HasValue)
                {
                    throw new Exception();
                }
                try
                {
                    decimal price = Calculate_Discounted_Price();
                    if (Length_ComboBox.Text == "30 Minutes")
                    {
                        string[] values = { CustomerId.ToString(), EmployeeId.ToString(), CarUnavailabityId.ToString(), PaymentId.ToString(), "1", "False", "False", "False" };
                        if (!SQL_Operation.CreateEntry(values, "TestDriveTable"))
                        {
                            throw new Exception();
                        }
                    }
                    else if (Length_ComboBox.Text == "1 Day")
                    {
                        string[] values = { CustomerId.ToString(), "NULL", CarUnavailabityId.ToString(), PaymentId.ToString(), "2", "False", "False", "False" };
                        if (!SQL_Operation.CreateEntry(values, "TestDriveTable"))
                        {
                            throw new Exception();
                        }
                    }
                    else if (Length_ComboBox.Text == "Weekend")
                    {
                        string[] values = { CustomerId.ToString(), "NULL", CarUnavailabityId.ToString(), PaymentId.ToString(), "3", "False", "False", "False" };
                        if (!SQL_Operation.CreateEntry(values, "TestDriveTable"))
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch //problem in creating test drive entry so delete car unavailabilty to keep maintained
                {
                    SQL_Operation.DeleteEntry((int)CarUnavailabityId, "CarUnavailabiltyId", "CarUnavailabiltyTable");
                    SQL_Operation.DeleteEntry((int)PaymentId, "PaymentId", "PaymentTable");
                    throw new Exception();
                }

                if(HomeScreen != null)
                {
                    HomeScreen.Invoke(this, EventArgs.Empty);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("An error occurred in creating the test drive");
            }
        }
        private void Employee_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Employee_Data();
        }
        void Edit_Test_Drive()
        {
            //customer can't be changed, should cancel booking instead
            //car can't be changed, should cancel booking instead
            //date and time can be changed
            //length can't be changed
            //employee can be changed

            //therefore only need to change test drive employee and car unavailabilty start and end time

            try //chainging employee
            {
                int oldEmployeeId = Convert.ToInt32(SQL_Operation.ReadColumn(TestDriveId, "TestDriveId", "EmployeeId", "TestDriveTable"));
                if (oldEmployeeId != Convert.ToInt32(EmployeeId) && Length_ComboBox.Text == "30 Minutes")
                {
                    DateTime[][] unavailabiltyForDay = Get_Reduced_Employee_Availabilty(EmployeeId.Value,TestDriveId);
                    DateTime startTime = (DateTime)Get_Start_Date();
                    DateTime endTime = (DateTime)Get_End_Date();
                    if (Time_Is_Unavailable(startTime, endTime, unavailabiltyForDay,false))
                    {
                        MessageBox.Show("Employee is unavailable");
                        return;
                    }
                    if (!SQL_Operation.UpdateEntryVariable(TestDriveId, "TestDriveId", "EmployeeId", EmployeeId.ToString(), "TestDriveTable"))
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error occured in changing employee");
                return;
            }

            try //changing time
            {
                string idText = SQL_Operation.ReadColumn(TestDriveId, "TestDriveId", "CarUnavailabiltyId", "TestDriveTable");
                if(idText == null)
                {
                    throw new Exception();
                }
                int carUnavailabiltyId = Convert.ToInt32(idText);
                DateTime[][] unavailabiltyForDay = Get_Reduced_Car_Unavailabilty(carUnavailabiltyId);
                DateTime startTime = (DateTime)Get_Start_Date();
                DateTime endTime = (DateTime)Get_End_Date();
                if (Time_Is_Unavailable(startTime,endTime, unavailabiltyForDay))
                {
                    MessageBox.Show("Time is unavailable");
                    return;
                }
                string[] values = { startTime.ToString(), endTime.ToString() };
                string[] columns = { "StartTime", "EndTime" };
                if (!SQL_Operation.UpdateEntryVariables(carUnavailabiltyId, "CarUnavailabiltyId",columns,values,"CarUnavailabiltyTable"))
                {
                    throw new Exception();
                }

            }
            catch
            {
                MessageBox.Show("An error occured in changing the times");
                return;
            }
            if (HomeScreen != null)
            {
                HomeScreen.Invoke(this, EventArgs.Empty);
            }
            this.Close();

        }

        DateTime[][] Get_Employee_Unavailabilty(int employeeId)
        {
            List<DateTime[]> employeeUnavailabilties = new List<DateTime[]>();
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CarUnavailabiltyTable.StartTime, CarUnavailabiltyTable.EndTime FROM TestDriveTable " +
                        "INNER JOIN CarUnavailabiltyTable ON TestDriveTable.CarUnavailabiltyId = CarUnavailabiltyTable.CarUnavailabiltyId " +
                        $"WHERE TestDriveTable.EmployeeId = '{employeeId}'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime[] unavailabilty = new DateTime[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            unavailabilty[i] = Convert.ToDateTime(reader.GetValue(i).ToString().Trim());
                        }
                        employeeUnavailabilties.Add(unavailabilty);
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured");
                }
            }
            return employeeUnavailabilties.ToArray();
        }

        DateTime[][] Get_Reduced_Employee_Availabilty(int employeeId, int testDriveId)
        {
            List<DateTime[]> employeeUnavailabilties = new List<DateTime[]>();
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CarUnavailabiltyTable.StartTime, CarUnavailabiltyTable.EndTime FROM TestDriveTable " +
                        "INNER JOIN CarUnavailabiltyTable ON TestDriveTable.CarUnavailabiltyId = CarUnavailabiltyTable.CarUnavailabiltyId " +
                        $"WHERE TestDriveTable.EmployeeId = '{employeeId}' AND TestDriveTable.TestDriveId != '{testDriveId}'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime[] unavailabilty = new DateTime[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            unavailabilty[i] = Convert.ToDateTime(reader.GetValue(i).ToString().Trim());
                        }
                        employeeUnavailabilties.Add(unavailabilty);
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured");
                }
            }
            return employeeUnavailabilties.ToArray();
        }

        private void Book_Test_Drive_Button_Click(object sender, EventArgs e)
        {
            if (AddMode)
            {
                Create_Test_Drive();
            }
            else
            {
                Edit_Test_Drive();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                else if(time.Length == 4)
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
        string Convert_Minutes_To_Time(int minutes)
        {
            try
            {
                int hours = minutes / 60;
                int minutesRemainder = minutes % 60;
                if (minutesRemainder == 0)
                {
                    return hours.ToString() + ":00";
                }
                return hours.ToString() + ":" + minutesRemainder;
            }
            catch
            {
                return null;
            }
        }
        void Display_Possible_Times()
        {
            if (CarId != null)
            {
                DateTime[][] unavailabiltyTimes = Get_Unavailabilty_For_Day();
                double hoursOffset = 0;
                if (Length_ComboBox.Text == "30 Minutes")
                {
                    hoursOffset = 0.5d;
                }
                else if(Length_ComboBox.Text == "1 Day")
                {
                    hoursOffset = 24;
                }
                else if(Length_ComboBox.Text == "Weekend")
                {
                    hoursOffset = 72;
                }
                else
                {
                    Start_Time_ComboBox.Items.Add("Pick a length");
                    return;
                }
                for (int minutes = Convert_Time_To_Minutes(Get_Opening_Time()); minutes <= Convert_Time_To_Minutes(Get_Closing_Time()); minutes += 5)
                {
                    DateTime time = Date_DateTimePicker.Value.Date.AddMinutes(minutes);
                    if (!Time_Is_Unavailable(time,time.AddHours(hoursOffset), unavailabiltyTimes) && Globals.timeIsInFuture(time))
                    {
                        Start_Time_ComboBox.Items.Add(time.ToShortTimeString());
                    }
                }
                if(Start_Time_ComboBox.Items.Count == 0)
                {
                    Start_Time_ComboBox.Items.Add("No times available");
                }
            }
            else
            {
                Start_Time_ComboBox.Items.Add("Choose a car");
            }
        }
        DateTime[][] Get_Unavailabilty_For_Day()
        {
            DateTime day = Date_DateTimePicker.Value.Date;
            List<DateTime[]> unavailabiltyTimes = new List<DateTime[]>();
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT StartTime,EndTime FROM CarUnavailabiltyTable WHERE  CarId = '{CarId}' "; //((StartTime >= '{day.ToString("yyyy-MM-dd HH:mm:ss")}' AND StartTime < '{day.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")}') OR (EndTime >= '{day.ToString("yyyy-MM-dd HH:mm:ss")}' AND EndTime < '{day.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")}') OR (StartTime < '{day.ToString("yyyy-MM-dd HH:mm:ss")}' AND EndTime > '{day.ToString("yyyy-MM-dd HH:mm:ss")}') AND
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime[] unavailabiltyTime = new DateTime[2];
                        unavailabiltyTime[0]= Convert.ToDateTime(reader["StartTime"].ToString().Trim());
                        unavailabiltyTime[1]= Convert.ToDateTime(reader["EndTime"].ToString().Trim());
                        unavailabiltyTimes.Add(unavailabiltyTime);
                    }
                    conn.Close();
                    return unavailabiltyTimes.ToArray();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured");
                    return null;
                }
            }
        }
        DateTime[][] Get_Reduced_Car_Unavailabilty(int unavailabiltyToSkipId)
        {
            List<DateTime[]> unavailabiltyTimes = new List<DateTime[]>();
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT StartTime,EndTime FROM CarUnavailabiltyTable WHERE  CarId = '{CarId}' AND CarUnavailabiltyId != '{unavailabiltyToSkipId}' "; //((StartTime >= '{day.ToString("yyyy-MM-dd HH:mm:ss")}' AND StartTime < '{day.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")}') OR (EndTime >= '{day.ToString("yyyy-MM-dd HH:mm:ss")}' AND EndTime < '{day.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")}') OR (StartTime < '{day.ToString("yyyy-MM-dd HH:mm:ss")}' AND EndTime > '{day.ToString("yyyy-MM-dd HH:mm:ss")}') AND
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime[] unavailabiltyTime = new DateTime[2];
                        unavailabiltyTime[0] = Convert.ToDateTime(reader["StartTime"].ToString().Trim());
                        unavailabiltyTime[1] = Convert.ToDateTime(reader["EndTime"].ToString().Trim());
                        unavailabiltyTimes.Add(unavailabiltyTime);
                    }
                    conn.Close();
                    return unavailabiltyTimes.ToArray();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured");
                    return null;
                }
            }
        }
        bool Time_Is_Unavailable(DateTime startTime,DateTime endTime,DateTime[][] unavailabiltyTimes, bool haveCleaningTime = true)
        {
            try
            {
                if(unavailabiltyTimes == null)
                {
                    throw new Exception();
                }
                if(haveCleaningTime)
                {
                    endTime += Globals.settings.CleaningTimeBetweeenTestDrives;
                }
                for (int i = 0; i < unavailabiltyTimes.Length; i++)
                {
                    DateTime startUnavail = unavailabiltyTimes[i][0];
                    DateTime endUnavail = unavailabiltyTimes[i][1];
                    if(haveCleaningTime) { endUnavail += Globals.settings.CleaningTimeBetweeenTestDrives; }
                    if ( (startTime >= startUnavail && startTime <= endUnavail) || (endTime >= startUnavail && endTime <= endUnavail)) //time is during an unavailabilty period
                    {
                        return true;
                    }
                    if( (startUnavail >= startTime && startUnavail <= endTime) || (endUnavail >= startTime && endUnavail <= endTime)) //unavailabilty is inside the time
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void Date_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Start_Time_ComboBox.Items.Clear();
            Display_Possible_Times();
        }


        private void Customer_DropDown_Click(object sender, EventArgs e)
        {
            Customer_Picker();
        }
        void Customer_Picker()
        {
            if (AddMode)
            {
                try
                {
                    PickerForm customerPicker = new PickerForm() { Table = "Customers" };
                    DialogResult result = customerPicker.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        CustomerId = (int)customerPicker.SelectedId;
                        Load_Customer_Data();
                    }
                }
                catch
                {
                    MessageBox.Show("No customer selected");
                }
            }
            else
            {
                MessageBox.Show("Customer cannot be changed, cancel booking instead");
            }
        }

        private void Employee_DropDown_Click(object sender, EventArgs e)
        {
            Employee_Picker();
        }
        void Employee_Picker()
        {
            try
            {
                PickerForm customerPicker = new PickerForm() { Table = "Employees" };
                DialogResult result = customerPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    EmployeeId = (int)customerPicker.SelectedId;
                    Load_Employee_Data();
                }
            }
            catch
            {
                MessageBox.Show("No customer selected");
            }
        }

        private void Car_DropDown_Click(object sender, EventArgs e)
        {
            Car_Picker();
        }
        void Car_Picker()
        {
            if (AddMode)
            {
                try
                {
                    PickerForm customerPicker = new PickerForm() { Table = "Cars" };
                    DialogResult result = customerPicker.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        CarId = (int)customerPicker.SelectedId;
                        Load_Car_Data();
                    }
                }
                catch
                {
                    MessageBox.Show("No car selected");
                }
                finally
                {
                    Start_Time_ComboBox.Items.Clear();
                    Display_Possible_Times();
                }
            }
            else
            {
                MessageBox.Show("Car cannot be changed, cancel booking instead");
            }
        }

        bool Need_Employee()
        {
            try
            {
                string length = Length_ComboBox.Text;
                if (length == "30 Minutes")
                {
                    return true;
                }
                else if(length == "1 Day")
                {
                    return false;
                }
                else if (length == "Weekend")
                {
                    return false;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return true;
            }
        }

        private void Employee_Accom_CheckedChanged(object sender, EventArgs e)
        {
            Employee_Accom.Checked = Need_Employee();
        }
        void Update_Employee_Accom()
        {
            Employee_Accom.Checked = Need_Employee();
        }

        private void Employee_TextBox_TextChanged(object sender, EventArgs e)
        {
            Employee_Picker();
        }

        private void Length_ComboBox_Click(object sender, EventArgs e)
        {
            if (!AddMode)
            {
                MessageBox.Show("Length cannot be changed, create a new booking instead");
                Length_ComboBox.Enabled = false;
            }
        }


        private void Customer_TextBox_Click(object sender, EventArgs e)
        {
            Customer_Picker();
        }

        private void Employee_TextBox_Click(object sender, EventArgs e)
        {
            Employee_Picker();
        }

        private void Car_TextBox_Click(object sender, EventArgs e)
        {
            Car_Picker();
        }

        private void Start_Time_ComboBox_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Start_Time_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Show_Text_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
