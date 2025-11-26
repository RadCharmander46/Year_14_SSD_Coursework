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
    public partial class TestDriveDataForm : Form
    {
        public event EventHandler TestDrive;
        public bool showCancelled = false;
        public string lastSorted;
        public TestDriveDataForm()
        {
            InitializeComponent();
        }
        public List<int> displayedIndexes = new List<int>(); //index of testdrives
        public List<string[]> testDrives = new List<string[]>();
        public List<string[]> customers = new List<string[]>();
        public List<string[]> employees = new List<string[]>();
        public List<string[]> cars = new List<string[]>();
        public List<string[]> carUnavailabilities = new List<string[]>();
        public string[] testDriveColumns = { "TestDriveId", "CustomerId", "EmployeeId", "CarUnavailabiltyId", "PaymentId", "TestDriveType", "HasBeenReturned", "ReturnedDamaged", "IsCancelled" };
        public string[] customerColumns = { "CustomerId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "License No", "Issue Date", "Expiry Date", "Verified License", "Previous Customer", "Damaged Vehicle", "Archived" };
        public string[] employeeColumns = { "EmployeeId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "Department","Role","Username","Password" };
        public string[] carColumns = { "CarId", "Make", "Model", "Registration", "Year Of Manufacture", "Mileage", "Transmission", "Fuel Type", "Engine Size", "Power", "Colour", "Body Style", "No Of Seats", "Insurance Group", "Previous Owners", "Needs Cleaned", "Needs Inspected", "Price", "Has Been Sold" };
        public string[] carUnavailabiltyColumns = { "CarUnavailabiltyId", "CarId", "StartTime", "EndTime", "Description" };
        public string[] testDriveTypes = { "30 Minutes", "1 Day", "Weekend" };

        private void TestDriveDataForm_Load(object sender, EventArgs e)
        {
            Setup_ListView();
        }
        void Setup_ListView()
        {
            Setup_Columns();
            Load_Tables();
            Display_TestDrives();
            Reset_Labels();
        }
        void Load_Tables()
        {
            Load_Test_Drives();
            Load_Employees();
            Load_Cars();
            Load_Customers();
            Load_Car_Unavailabilities();
        }
        void Setup_Columns()
        {
            Test_Drives_ListView.Items.Clear();
            Test_Drives_ListView.Columns.Add("Customer Name", 170);
            Test_Drives_ListView.Columns.Add("Employee Name", 170);
            Test_Drives_ListView.Columns.Add("Car", 172);
            Test_Drives_ListView.Columns.Add("Start Time", 140);
            Test_Drives_ListView.Columns.Add("End Time", 140);
        }
        private void Load_Test_Drives()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TestDriveTable";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        string[] testDrive = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            testDrive[i] = reader.GetValue(i).ToString().Trim();
                        }
                        testDrives.Add(testDrive);
                        displayedIndexes.Add(index);
                        index++;
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured when loading the test drives");
                }
            }
        }

        void Reset_Displayed_Indexes()
        {
            List<int> tempIndexes = new List<int>();
            for(int i = 0; i < testDrives.Count;i++)
            {
                tempIndexes.Add(i);
            }
            displayedIndexes = tempIndexes;
        }

        private void Load_Employees()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM EmployeeTable";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] employee = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            employee[i] = reader.GetValue(i).ToString().Trim();
                        }
                        employees.Add(employee);
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured when loading the customers");
                }
            }
        }

        private void Load_Customers()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM CustomerTable";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] customer = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            customer[i] = reader.GetValue(i).ToString().Trim();
                        }
                        customers.Add(customer);
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured when loading the customers");
                }
            }
        }

        private void Load_Cars()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM CarTable";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] car = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            car[i] = reader.GetValue(i).ToString().Trim();
                        }
                        cars.Add(car);
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured when loading the customers");
                }
            }
        }

        private void Load_Car_Unavailabilities()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM CarUnavailabiltyTable";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] carUnavailabilty = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            carUnavailabilty[i] = reader.GetValue(i).ToString().Trim();
                        }
                        carUnavailabilities.Add(carUnavailabilty);
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured when loading the customers");
                }
            }
        }

        string[] Get_Test_Drive_Values(int testDriveId)
        {
            foreach (string[] testDrive in testDrives)
            {
                if (testDrive[0] == testDriveId.ToString())
                {
                    return testDrive;
                }
            }
            return null;
        }

        string[] Get_Customer_Values(int customerId)
        {
            foreach(string[] customer in customers)
            {
                if(customer[0] == customerId.ToString())
                {
                    return customer;
                }
            }
            return null;
        }
        string[] Get_Employee_Values(int employeeId)
        {
            foreach (string[] employee in employees)
            {
                if (employee[0] == employeeId.ToString())
                {
                    return employee;
                }
            }
            return null;
        }
        string[] Get_Car_Values(int carId)
        {
            foreach (string[] car in cars)
            {
                if (car[0] == carId.ToString())
                {
                    return car;
                }
            }
            return null;
        }
        string[] Get_Car_Unavailabilty_Values(int carUnavailabiltyId)
        {
            foreach (string[] carUnavailabilty in carUnavailabilities)
            {
                if (carUnavailabilty[0] == carUnavailabiltyId.ToString())
                {
                    return carUnavailabilty;
                }
            }
            return null;
        }
        string[] Get_Payment_Values(int paymentId)
        {
            return SQL_Operation.ReadEntry(paymentId, "PaymentId", "PaymentTable");
        }
        string Get_Employee_Name(string id)
        {
            try
            {
                int employeeId = Convert.ToInt32(id);
                string[] values =  Get_Employee_Values(employeeId);
                string name = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                return name;
            }
            catch
            {
                return "N/A";
            }
        }
        string Get_Customer_Name(string id)
        {
            try
            {
                int customerId = Convert.ToInt32(id);
                string[] values = Get_Customer_Values(customerId);
                string name = Globals.removeWhitespace(values[1] + " " + values[2] + " " + values[3]);
                return name;
            }
            catch
            {
                return "N/A";
            }
        }
        string Get_Car_Name(string id)
        {
            try
            {
                int carId = Convert.ToInt32(id);
                string[] values = Get_Car_Values(carId);
                string name = Globals.removeWhitespace(Globals.getYear(values[4]) + " " + values[1] + " " + values[2]);
                return name;
            }
            catch
            {
                return "N/A";
            }
        }
        string Get_Start_Time(string id)
        {
            try
            {
                int carUnavailabiltyId = Convert.ToInt32(id);
                string[] values = Get_Car_Unavailabilty_Values(carUnavailabiltyId);
                return Globals.removeSeconds(values[2]);
            }
            catch
            {
                return null;
            }
        }
        string Get_End_Time(string id)
        {
            try
            {
                int carUnavailabiltyId = Convert.ToInt32(id);
                string[] values = Get_Car_Unavailabilty_Values(carUnavailabiltyId);
                return Globals.removeSeconds(values[3]);
            }
            catch
            {
                return null;
            }
        }
        string Get_Car_Id(string id)
        {
            try
            {
                int carUnavailabiltyId = Convert.ToInt32(id);
                string[] values = Get_Car_Unavailabilty_Values(carUnavailabiltyId);
                return values[1];
            }
            catch
            {
                return null;
            }
        }
        string Get_Payment_Amount(string id)
        {
            int paymentId = Convert.ToInt32(id);
            string[] paymentValues = Get_Payment_Values(paymentId);
            return paymentValues[3];

        }
        string Get_Test_Drive_Type_Name(int id)
        {
            try
            {
                string[] values = SQL_Operation.ReadEntry(id, "TestDriveTypeId", "TestDriveTypeTable");
                return values[1];
            }
            catch
            {
                MessageBox.Show("An error occurred when reading the test drive type table");
                return null;
            }
        }
        void Display_All_TestDrives()
        {
            Test_Drives_ListView.Items.Clear();
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] testDrive = testDrives[displayedIndexes[i]];
                ListViewItem row = new ListViewItem(Get_Customer_Name(testDrive[1]));
                row.SubItems.Add(Get_Employee_Name(testDrive[2]));
                row.SubItems.Add(Get_Car_Name(Get_Car_Id(testDrive[3])));
                row.SubItems.Add(Get_Start_Time(testDrive[3]));
                row.SubItems.Add(Get_End_Time(testDrive[3]));
                Test_Drives_ListView.Items.Add(row);
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string[] testDrive = testDrives[displayedIndexes[Test_Drives_ListView.SelectedItems[0].Index]];

                DateTime startTime = Convert.ToDateTime(Test_Drives_ListView.SelectedItems[0].SubItems[3].Text);
                if (Globals.timeIsInFuture(startTime))
                {
                    if (TestDrive != null)
                    {
                        TestDrive.Invoke(this, new TestDrive_EventArgs { Id = Convert.ToInt32(testDrive[0]), AddMode = false });
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Test drive has already started, cannot be edited");
                }
            }
            catch
            {
                MessageBox.Show("A entry had not been selected");
            }
            
        }
    

        private void Add_Customer_Button_Click(object sender, EventArgs e)
        {
            if (TestDrive != null)
            {
                TestDrive.Invoke(this, new TestDrive_EventArgs { AddMode = true });
            }
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            if(Test_Drives_ListView.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(testDrives[displayedIndexes[Test_Drives_ListView.SelectedItems[0].Index]][0]);
                if(Can_Be_Cancelled(id))
                {
                    if(SQL_Operation.UpdateEntryVariable(id,"TestDriveId","IsCanceled","True","TestDriveTable")) //cancelling was succesful
                    {
                        string[] testDrive = Get_Test_Drive_Values(id);
                        int paymentId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("PaymentId")]);
                        if (Has_Been_Paid(paymentId))
                        {
                            int customerId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CustomerId")]);

                            //create a refund
                            decimal refundAmount = Convert.ToDecimal(Get_Payment_Amount(paymentId.ToString()));
                            string[] values = { customerId.ToString(), refundAmount.ToString(), "Refund", "Refund for a cancelled test drive", "False" };
                            if(!SQL_Operation.CreateEntry(values,"PaymentTable"))
                            {
                                MessageBox.Show("An error occurred when creating a refund");
                                return;
                            }
                        }
                        else
                        {
                            if(!SQL_Operation.UpdateEntryVariable(paymentId,"PaymentId","IsCancelled","True","PaymentTable"))
                            {
                                MessageBox.Show("An error occured when updating the payment");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occurred when updating the test drive ");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Test Drive cannot be cancelled");
                }

            }
        }
        bool Can_Be_Cancelled(int testDriveId)
        {
            string[] testDrive = Get_Test_Drive_Values(testDriveId);
            int carUnavailabiltyId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CarUnavailabiltyId")]);
            DateTime startDate = Convert.ToDateTime(Get_Start_Time(carUnavailabiltyId.ToString()));
            if(startDate < DateTime.Now.AddDays(-1)) //checking the test drive is more than 1 day ahead
            {
                return false;
            }
            return true;
        }
        bool Has_Been_Paid(int paymentId)
        {
            string[] payment = Get_Payment_Values(paymentId);
            return Convert.ToBoolean(payment[6]);
        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            Test_Drives_ListView.Clear();
            displayedIndexes.Clear();
            cars.Clear();
            employees.Clear();
            customers.Clear();
            carUnavailabilities.Clear();
            testDrives.Clear();
            Setup_ListView();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        int Get_TestDrive_Column_Index(string column)
        {
            for(int i = 0; i < testDriveColumns.Length;i++)
            {
                string testDriveColumn = testDriveColumns[i];
                if (testDriveColumn == column)
                {
                    return i;
                }
            }
            return -1;
        }
        int Get_Customer_Column_Index(string column)
        {
            for (int i = 0; i < customerColumns.Length; i++)
            {
                string customerColumn = customerColumns[i];
                if (customerColumn == column)
                {
                    return i;
                }
            }
            return -1;
        }

        int Get_Car_Column_Index(string column)
        {
            for (int i = 0; i < carColumns.Length; i++)
            {
                string carColumn = carColumns[i];
                if (carColumn == column)
                {
                    return i;
                }
            }
            return -1;
        }

        int Get_CarUnavailabilty_Column_Index(string column)
        {
            for (int i = 0; i < carColumns.Length; i++)
            {
                string carUnavailColumn = carUnavailabiltyColumns[i];
                if (carUnavailColumn == column)
                {
                    return i;
                }
            }
            return -1;
        }

        int Get_Employee_Column_Index(string column)
        {
            for (int i = 0; i < employeeColumns.Length; i++)
            {
                string employeeColumn = employeeColumns[i];
                if (employeeColumn == column)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Test_Drives_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Test_Drives_ListView.SelectedItems.Count == 1)
            {
                string[] testDrive = testDrives[displayedIndexes[Test_Drives_ListView.SelectedItems[0].Index]];
                int employeeId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("EmployeeId")]);
                int customerId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CustomerId")]);
                int carUnavailabiltyId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CarUnavailabiltyId")]);
                int carId = Convert.ToInt32(Get_Car_Id(carUnavailabiltyId.ToString()));

                Display_Customer(customerId);
                Display_Employee(employeeId);
                Display_Car(carId);

                Returned_Label.Text = "Car Returned: " + Globals.boolToYN(testDrive[Get_TestDrive_Column_Index("HasBeenReturned")]);
                Damaged_Returned.Text = "Car Damaged: " + Globals.boolToYN(testDrive[Get_TestDrive_Column_Index("ReturnedDamaged")]);
                Cancelled_Label.Text = "Test Drive Cancelled: " + Globals.boolToYN(testDrive[Get_TestDrive_Column_Index("IsCancelled")]);

                int testDriveTypeId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("TestDriveType")]);
                Test_Drive_Length_Label.Text = "Test Drive Length: " + Get_Test_Drive_Type_Name(testDriveTypeId);

                int paymentId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("PaymentId")]);
                string[] paymentValues = Get_Payment_Values(paymentId);
                
                Cost_Label.Text = "Cost: £" +  paymentValues[3];
                Paid_Label.Text = "Paid: " + Globals.boolToYN(paymentValues[6]);

            }
            else
            {
                Reset_Labels();
            }
        }
        void Reset_Labels()
        {
            Cust_DOB_Label.Text = "DOB: ";
            Cust_Tel_Label.Text = "Tel: ";
            Cust_Email_Label.Text = "Email: ";
            Cust_Postcode_Label.Text = "Postcode: ";

            Reg_Label.Text = "Reg: ";
            Mileage_Label.Text = "Mileage: ";
            Transmission_Label.Text = "Transmission: ";
            Fuel_Type_Label.Text = "Fuel Type: ";
            Engine_Size_Label.Text = "Engine Size: ";
            Power_Label.Text = "Power: ";
            Colour_Label.Text = "Colour: ";
            Body_Style_Label.Text = "Body Style: ";

            Employee_DOB_Label.Text = "DOB: ";
            Employee_Tel_Label.Text = "Tel: ";
            Employee_Email_Label.Text = "Email: ";
            Employee_Username_Label.Text = "Username: ";

            Returned_Label.Text = "Car Returned: ";
            Damaged_Returned.Text = "Car Damaged: ";
            Cancelled_Label.Text = "Test Drive Cancelled: ";
            Test_Drive_Length_Label.Text = "Test Drive Length: ";
            Cost_Label.Text = "Cost: ";
            Paid_Label.Text = "Paid: ";
        }
        void Display_Customer(int customerId)
        {
            try
            {
                string[] customer = Get_Customer_Values(customerId);
                if (customer != null)
                {
                    Cust_DOB_Label.Text = "DOB: " + Globals.removeTime(customer[4]);
                    Cust_Tel_Label.Text = "Tel: " + customer[5];
                    Cust_Email_Label.Text = "Email: " + customer[6];
                    Cust_Postcode_Label.Text = "Postcode: " + customer[10];
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Cust_DOB_Label.Text = "DOB: ";
                Cust_Tel_Label.Text = "Tel: ";
                Cust_Email_Label.Text = "Email: ";
                Cust_Postcode_Label.Text = "Postcode: ";
            }
        }
        void Display_Car(int carId)
        {
            try
            {
                string[] car = Get_Car_Values(carId);
                if (car != null)
                {
                    Reg_Label.Text = "Reg: " + car[3];
                    Mileage_Label.Text = "Mileage: " + Globals.addCommaToNumber(car[5]) + "km";
                    Transmission_Label.Text = "Transmission: " + car[6];
                    Fuel_Type_Label.Text = "Fuel Type: " + car[7];
                    Engine_Size_Label.Text = "Engine Size: " + car[8] + "l";
                    Power_Label.Text = "Power: " + car[9] + "hp";
                    Colour_Label.Text = "Colour: " + car[10];
                    Body_Style_Label.Text = "Body Style: " + car[11];
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Reg_Label.Text = "Reg: ";
                Mileage_Label.Text = "Mileage: ";
                Transmission_Label.Text = "Transmission: ";
                Fuel_Type_Label.Text = "Fuel Type: ";
                Engine_Size_Label.Text = "Engine Size: ";
                Power_Label.Text = "Power: ";
                Colour_Label.Text = "Colour: ";
                Body_Style_Label.Text = "Body Style: ";
            }
        }
        void Display_Employee(int employeeId)
        {
            try
            {
                string[] employee = Get_Employee_Values(employeeId);
                if (employee != null)
                {
                    Employee_DOB_Label.Text = "DOB: " + Globals.removeTime(employee[4]);
                    Employee_Tel_Label.Text = "Tel: " + employee[5];
                    Employee_Email_Label.Text = "Email: " + employee[6];
                    Employee_Username_Label.Text = "Username: " + employee[13];
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Employee_DOB_Label.Text = "DOB: ";
                Employee_Tel_Label.Text = "Tel: ";
                Employee_Email_Label.Text = "Email: ";
                Employee_Username_Label.Text = "Username: ";
            }
        }

        private void Sorting_Group_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter_ComboBox.Items.Clear();
            switch (Sorting_Group_ComboBox.Text)
            {
                case "Customer":
                {
                    Add_Customer_DropDown();
                    break;
                }
                case "Employee":
                {
                    Add_Employee_DropDown();
                    break;
                }
                case "Car":
                {
                    Add_Car_DropDown();
                    break;
                }
                case "Test Drive":
                {
                    Add_TestDrive_DropDown();
                    break;
                }
                default:
                {
                    Filter_ComboBox.Items.Add("Select a section to sort first");
                    break;
                }
            }
        }
        void Add_Customer_DropDown()
        {
            Filter_ComboBox.Items.Add("First Name/s");
            Filter_ComboBox.Items.Add("Middle Name/s");
            Filter_ComboBox.Items.Add("Last Name/s");
            Filter_ComboBox.Items.Add("Date Of Birth");
            Filter_ComboBox.Items.Add("Phone Number");
            Filter_ComboBox.Items.Add("Email Address");
            Filter_ComboBox.Items.Add("Postcode");
        }
        void Add_Employee_DropDown()
        {
            Filter_ComboBox.Items.Add("First Name/s");
            Filter_ComboBox.Items.Add("Middle Name/s");
            Filter_ComboBox.Items.Add("Last Name/s");
            Filter_ComboBox.Items.Add("Date Of Birth");
            Filter_ComboBox.Items.Add("Phone Number");
            Filter_ComboBox.Items.Add("Email Address");
            Filter_ComboBox.Items.Add("Username");
        }
        void Add_Car_DropDown()
        {
            Filter_ComboBox.Items.Add("Make");
            Filter_ComboBox.Items.Add("Model");
            Filter_ComboBox.Items.Add("Registration");
            Filter_ComboBox.Items.Add("Year Of Manufacture");
        }

        void Add_TestDrive_DropDown()
        {
            Filter_ComboBox.Items.Add("Start Time");
            Filter_ComboBox.Items.Add("End Time");
            Filter_ComboBox.Items.Add("Length");
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            if(Sorting_Group_ComboBox.Text == "")
            {
                MessageBox.Show("Pick a searching group first");
                return;
            }
            if(Filter_ComboBox.Text == "")
            {
                MessageBox.Show("Pick a filed to search first");
                return;
            }
            Reset_Displayed_Indexes();
            switch (Sorting_Group_ComboBox.Text)
            {
                case "Customer":
                    {
                        Search_Customers();
                        break;
                    }
                case "Employee":
                    {
                        Search_Employees();
                        break;
                    }
                case "Car":
                    {
                        Search_Cars();
                        break;
                    }
                case "Test Drive":
                    {
                        Search_TestDrives();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Error occurred when reading the searching group");
                        return;
                        break;
                    }
            }
            Display_TestDrives();
        }
        void Search_Customers()
        {
            List<int> tempIndexes = new List<int>();
            string searchText = Filter_TextBox.Text;
            for(int i = 0; i < displayedIndexes.Count;i++)
            {
                string[] testDrive = testDrives[displayedIndexes[i]];
                int customerId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CustomerId")]);
                string[] customer = Get_Customer_Values(customerId);
                int filterIndex = Get_Customer_Column_Index(Filter_ComboBox.Text);
                if (customer[filterIndex].Contains(searchText))
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
        }

        void Search_Employees()
        {
            List<int> tempIndexes = new List<int>();
            string searchText = Filter_TextBox.Text;
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] testDrive = testDrives[displayedIndexes[i]];
                int employeeId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("EmployeeId")]);
                string[] employee = Get_Customer_Values(employeeId);
                int filterIndex = Get_Employee_Column_Index(Filter_ComboBox.Text);
                if (employee[filterIndex].Contains(searchText))
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
        }

        void Search_Cars()
        {
            List<int> tempIndexes = new List<int>();
            string searchText = Filter_TextBox.Text;
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] testDrive = testDrives[displayedIndexes[i]];
                int carUnavailId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CarUnavilabiltyId")]);
                string[] carUnavailValues = Get_Car_Unavailabilty_Values(carUnavailId);
                int carId = Convert.ToInt32(carUnavailValues[Get_CarUnavailabilty_Column_Index("CarId")]);

                string[] car = Get_Car_Values(carId);
                int filterIndex = Get_Car_Column_Index(Filter_ComboBox.Text);
                if (car[filterIndex].Contains(searchText))
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
        }
        void Search_TestDrives()
        {
            List<int> tempIndexes = new List<int>();
            string searchText = Filter_TextBox.Text;
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] testDrive = testDrives[displayedIndexes[i]];
                int carUnavailId = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("CarUnavailabiltyId")]);
                string[] carUnavailValues = Get_Car_Unavailabilty_Values(carUnavailId);
                string startDate = Convert.ToDateTime(carUnavailValues[Get_CarUnavailabilty_Column_Index("StartTime")]).ToString("yyyy/MM/dd HH:mm:ss");
                string endDate = Convert.ToDateTime(carUnavailValues[Get_CarUnavailabilty_Column_Index("EndTime")]).ToString("yyyy/MM/dd HH:mm:ss");
                int testDriveType = Convert.ToInt32(testDrive[Get_TestDrive_Column_Index("TestDriveType")]);

                int filterIndex = Filter_ComboBox.SelectedIndex;
                if(filterIndex == 2) //test drive type
                {
                    if(testDriveTypes[testDriveType].Contains(searchText))
                    {
                        tempIndexes.Add(displayedIndexes[i]);
                    }
                }
                else if(filterIndex == 1) //end time
                {
                    if(endDate.Contains(searchText))
                    {
                        tempIndexes.Add(displayedIndexes[i]);
                    }
                }
                else if(filterIndex == 0) //start time
                {
                    if(startDate.Contains(searchText))
                    {
                        tempIndexes.Add(displayedIndexes[i]);
                    }
                }
                else
                {
                    MessageBox.Show("An error occurred");
                    return;
                }
            }
            displayedIndexes = tempIndexes;
        }

        private void Remove_Test_Drive_Button_Click(object sender, EventArgs e)
        {
            if (Test_Drives_ListView.SelectedItems.Count == 1)
            {
                int testDriveId = Convert.ToInt32(testDrives[displayedIndexes[Test_Drives_ListView.SelectedItems[0].Index]][0]);
                if (Can_Be_Deleted(testDriveId))
                {
                    if (!SQL_Operation.DeleteEntry(testDriveId, "TestDriveId", "TestDriveTable"))
                    {
                        MessageBox.Show("An error ocurred");
                    }
                }
            }
        }
        bool Can_Be_Deleted(int id)
        {
            return true;
        }

        void Show_Cancelled(object sender, EventArgs e)
        {
            showCancelled = true;
            Show_Cancelled_Button.Click -= new EventHandler(Show_Cancelled);
            Show_Cancelled_Button.Click += new EventHandler(Hide_Cancelled);
            Show_Cancelled_Button.Image = Properties.Resources.cancel_visible;
            Display_TestDrives();
        }
        void Hide_Cancelled(object sender, EventArgs e)
        {
            showCancelled = false;
            Show_Cancelled_Button.Click -= new EventHandler(Hide_Cancelled);
            Show_Cancelled_Button.Click += new EventHandler(Show_Cancelled);
            Show_Cancelled_Button.Image = Properties.Resources.cancel_not_visible;
            Display_TestDrives();
        }

        void Display_TestDrives()
        {
            if(showCancelled)
            {
                Reset_Displayed_Indexes();
            }
            Filter_By_Cancelled();
            Display_All_TestDrives();
        }
        void Filter_By_Cancelled()
        {
            List<int> tempIndexes = new List<int>();
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] testDrive = testDrives[displayedIndexes[i]];
                bool cancelled = Convert.ToBoolean(testDrive[Get_TestDrive_Column_Index("IsCancelled")]);
                if (!cancelled || showCancelled )
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
        }

        private void Sort_Customer_Click(object sender, EventArgs e)
        {
            if (lastSorted != "Customer")
            {
                Sort_Customer_Names();
                Display_All_TestDrives();
                lastSorted = "Customer";
            }
            else
            {
                Inverse_Sort_Customer_Names();
                Display_All_TestDrives();
                lastSorted = "Inverse Customer";
            }
        }
        void Sort_Customer_Names() // 1 is customer id
        {
            displayedIndexes.Sort((a, b) => Get_Customer_Name(testDrives[a][1]).CompareTo(Get_Customer_Name(testDrives[b][1])));
        }
        void Inverse_Sort_Customer_Names()
        {
            displayedIndexes.Sort((b, a) => Get_Customer_Name(testDrives[a][1]).CompareTo(Get_Customer_Name(testDrives[b][1])));
        }

        private void Sort_Employee_Click(object sender, EventArgs e)
        {
            if(lastSorted != "Employee")
            {
                Sort_Employee_Names();
                Display_All_TestDrives();
                lastSorted = "Employee";
            }
            else
            {
                Inverse_Sort_Employee_Names();
                Display_All_TestDrives();
                lastSorted = "Inverse Employee";
            }
        }
        void Sort_Employee_Names() // 2 is customer id
        {
            displayedIndexes.Sort((a, b) => Get_Employee_Name(testDrives[a][2]).CompareTo(Get_Employee_Name(testDrives[b][2])));
        }
        void Inverse_Sort_Employee_Names()
        {
            displayedIndexes.Sort((b, a) => Get_Employee_Name(testDrives[a][2]).CompareTo(Get_Employee_Name(testDrives[b][2])));
        }

        private void Sort_Car_Click(object sender, EventArgs e)
        {
            if(lastSorted != "Car")
            {
                Sort_Car_Names();
                Display_All_TestDrives();
                lastSorted = "Car";
            }
            else
            {
                Inverse_Sort_Car_Names();
                Display_All_TestDrives();
                lastSorted = "Inverse Car";
            }
        }
        void Sort_Car_Names() // 3 is carUnavail id
        {
            displayedIndexes.Sort((a, b) => Get_Car_Name(Get_Car_Id(testDrives[a][3])).CompareTo(Get_Car_Name(Get_Car_Id(testDrives[b][3]))));
        }
        void Inverse_Sort_Car_Names()
        {
            displayedIndexes.Sort((b,a) => Get_Car_Name(Get_Car_Id(testDrives[a][3])).CompareTo(Get_Car_Name(Get_Car_Id(testDrives[b][3]))));
        }

        private void Sort_Start_Date_Click(object sender, EventArgs e)
        {
            if(lastSorted != "Start Date")
            {
                Sort_Start_Dates();
                Display_All_TestDrives();
                lastSorted = "Start Date";
            }
            else
            {
                Inverse_Sort_Start_Dates();
                Display_All_TestDrives();
                lastSorted = "Inverse Start Date";
            }

        }

        void Sort_Start_Dates() // 3 is carUnavail id
        {
            displayedIndexes.Sort((a, b) => Convert.ToDateTime(Get_Start_Time(testDrives[a][3])) .CompareTo(Convert.ToDateTime(Get_Start_Time(testDrives[b][3]))));
        }
        void Inverse_Sort_Start_Dates()
        {
            displayedIndexes.Sort((b, a) => Convert.ToDateTime(Get_Start_Time(testDrives[a][3])).CompareTo(Convert.ToDateTime(Get_Start_Time(testDrives[b][3]))));
        }

        private void Sort_End_Date_Click(object sender, EventArgs e)
        {
            if(lastSorted != "End Date")
            {
                Sort_End_Dates();
                Display_All_TestDrives();
                lastSorted = "End Date";
            }
            else
            {
                Inverse_Sort_End_Dates();
                Display_All_TestDrives();
                lastSorted = "Inverse End Date";
            }
        }

        void Sort_End_Dates() // 3 is carUnavail id
        {
            displayedIndexes.Sort((a, b) => Convert.ToDateTime(Get_End_Time(testDrives[a][3])).CompareTo(Convert.ToDateTime(Get_End_Time(testDrives[b][3]))));
        }
        void Inverse_Sort_End_Dates()
        {
            displayedIndexes.Sort((b, a) => Convert.ToDateTime(Get_End_Time(testDrives[a][3])).CompareTo(Convert.ToDateTime(Get_End_Time(testDrives[b][3]))));
        }
    }
    public class TestDrive_EventArgs : EventArgs
    {
        public int Id { get; set; }
        public bool AddMode { get; set; }
    }
}
