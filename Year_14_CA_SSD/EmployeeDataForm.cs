using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class EmployeeDataForm : Form
    {
        public List<int> displayedIndexes = new List<int>(); //indexes of employees
        public List<string[]> employees = new List<string[]>();
        public event EventHandler AddEmployee;
        public string[] employeeColumns = { "EmployeeId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "Department","Role","Username","Password","Archived","Unavailable","Next Time Available" };
        public bool showArchived;
        public string lastSort;
        public EmployeeDataForm()
        {
            InitializeComponent();
        }

        private void EmployeeDataForm_Load(object sender, EventArgs e)
        {
            Setup_Form();
        }

        void Setup_Form()
        {
            Setup_ListView();
            Load_Employees();
            Display_Employees();
        }
        void Setup_ListView()
        {
            Employee_ListView.Font = new Font(Employee_ListView.Font, FontStyle.Bold);
            Employee_ListView.Columns.Add("First Name/s", 150);
            Employee_ListView.Columns.Add("Middle Name/s", 150);
            Employee_ListView.Columns.Add("Last Name/s", 150);
            Employee_ListView.Columns.Add("Date Of Birth", 150);
            Employee_ListView.Columns.Add("Phone Number", 170);
        }
        void Display_All_Employees()
        {
            Employee_ListView.Items.Clear();
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] employee = employees[displayedIndexes[i]];
                ListViewItem row = new ListViewItem(employee[1]);
                row.SubItems.Add(employee[2]);
                row.SubItems.Add(employee[3]);
                row.SubItems.Add(Globals.removeTime(employee[4]));
                row.SubItems.Add(employee[5]);
                row.Font = new Font(Employee_ListView.Font, FontStyle.Regular);
                Employee_ListView.Items.Add(row);
            }
        }
        void Display_Employees()
        {
            if (showArchived) //were hidden before so need to reset displayed indexes
            {
                Reset_Displayed_Indexes();
            }
            Filter_By_Archived();
            Display_All_Employees();
        }
        void Filter_By_Archived()
        {
            List<int> tempIndexes = new List<int>();
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] employee = employees[displayedIndexes[i]];
                bool cancelled = Convert.ToBoolean(employee[Get_Employee_Column_Index("Archived")]);
                if (!cancelled || showArchived)
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
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
        void Reset_Displayed_Indexes()
        {
            List<int> tempIndexes = new List<int>();
            for (int i = 0; i < employees.Count; i++)
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

                    int index = 0;
                    while (reader.Read())
                    {
                        string[] employee = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            employee[i] = reader.GetValue(i).ToString().Trim();
                        }
                        employees.Add(employee);
                        displayedIndexes.Add(index);
                        index++;
                    }
                    conn.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured when loading the customers");
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Sort_Employees(List<int> items, int sortingIndex)
        {
            items.Sort((a, b) => employees[a][sortingIndex].CompareTo(employees[b][sortingIndex]));
        }
        public void Sort_Inverse_Employees(List<int> items, int sortingIndex)
        {
            items.Sort((b, a) => employees[a][sortingIndex].CompareTo(employees[b][sortingIndex]));
        }

        private void Sort_FirstName_Click(object sender, EventArgs e)
        {
            if (lastSort != "First Name")
            {
                Sort_Employees(displayedIndexes, 1);
                Display_All_Employees();
                lastSort = "First Name";
            }
            else
            {
                Sort_Inverse_Employees(displayedIndexes, 1);
                Display_All_Employees();
                lastSort = "Inverse First Name";
            }
        }

        private void Sort_Middle_Name_Click(object sender, EventArgs e)
        {
            if (lastSort != "Middle Name")
            {
                Sort_Employees(displayedIndexes, 2);
                Display_All_Employees();
                lastSort = "Middle Name";
            }
            else
            {
                Sort_Inverse_Employees(displayedIndexes, 2);
                Display_All_Employees();
                lastSort = "Inverse Middle Name";
            }
        }

        private void Sort_Last_Name_Click(object sender, EventArgs e)
        {
            if (lastSort != "Last Name")
            {
                Sort_Employees(displayedIndexes, 3);
                Display_All_Employees();
                lastSort = "Last Name";
            }
            else
            {
                Sort_Inverse_Employees(displayedIndexes, 3);
                Display_All_Employees();
                lastSort = "Inverse Last Name";
            }
        }

        private void Sort_DOB_Click(object sender, EventArgs e)
        {
            if (lastSort != "Date Of Birth")
            {
                displayedIndexes.Sort((a, b) => Convert.ToDateTime(employees[a][4]).CompareTo(Convert.ToDateTime(employees[b][4])));
                Display_All_Employees();
                lastSort = "Date Of Birth";
            }
            else
            {
                displayedIndexes.Sort((b, a) => Convert.ToDateTime(employees[a][4]).CompareTo(Convert.ToDateTime(employees[b][4])));
                Display_All_Employees();
                lastSort = "Inverse Date Of Birth";
            }
        }

        private void Sort_Phone_Number_Click(object sender, EventArgs e)
        {
            if (lastSort != "Phone Number")
            {
                Sort_Employees(displayedIndexes, 5);
                Display_All_Employees();
                lastSort = "Phone Number";
            }
            else
            {
                Sort_Inverse_Employees(displayedIndexes, 5);
                Display_All_Employees();
                lastSort = "Inverse Phone Number";
            }
        }

        private void Employee_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Employee_ListView.SelectedItems.Count == 1)
            {
                string[] employee = employees[displayedIndexes[Employee_ListView.SelectedItems[0].Index]];
                Telephone_Label.Text = employee[5];
                Email_Label.Text = Globals.splitEmailTwoRows(employee[6], 20);
                Address_Line1_Label.Text = employee[7];
                Address_Line2_Label.Text = employee[8];
                Address_Line3_Label.Text = employee[9];
                Postcode_Label.Text = employee[10];
                Username_Label.Text = employee[13];
                Department_Label.Text = employee[11];
                Role_Label.Text = employee[12];
                Archived_Label.Text = Globals.boolToYN(employee[15]);
                bool available = !Convert.ToBoolean(employee[16]);
                Available_Label.Text = Globals.boolToYN(available); //stored as unavailable check in database
                if(available)
                {
                    Next_Available_Label.Text = "Now";
                    return;
                }
                if (employee[17] != "")
                {
                    Next_Available_Label.Text = Globals.removeSeconds(employee[17]);
                }
                else
                {
                    Next_Available_Label.Text = "Unknown";
                }
            }
            else
            {
                Reset_Labels();
            }
        }
        void Reset_Labels()
        {
            Telephone_Label.Text = "";
            Email_Label.Text = "";
            Address_Line1_Label.Text = "";
            Address_Line2_Label.Text = "";
            Address_Line3_Label.Text = "";
            Postcode_Label.Text = "";
            Department_Label.Text = "";
            Role_Label.Text = "";
            Username_Label.Text = "";
            Archived_Label.Text = "";
            Available_Label.Text = "";
            Next_Available_Label.Text = "";
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            Filter_Employees();
            Display_Employees();
        }
        void Filter_Employees()
        {
            int filterIndex = Get_Employee_Column_Index(Search_ComboBox.Text);
            if (filterIndex == -1)
            {
                MessageBox.Show("Filter not selected");
                return;
            }
            displayedIndexes.Clear();
            for (int i = 0; i < employees.Count; i++)
            {
                string[] customer = employees[i];
                if (customer[filterIndex].Contains(Search_TextBox.Text))
                {
                    displayedIndexes.Add(i);
                }
            }
        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            Refresh_Page();
        }
        void Refresh_Page()
        {
            displayedIndexes.Clear();
            employees.Clear();
            Employee_ListView.Clear();
            Setup_Form();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (Employee_ListView.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(employees[displayedIndexes[Employee_ListView.SelectedItems[0].Index]][0]);
                if (Employee_Can_Be_Deleted(id))
                {
                    if (!SQL_Operation.DeleteEntry(id, "EmployeeId", "EmployeeTable"))
                    {
                        MessageBox.Show("And error occured");                                                                                                                                                   
                    }
                    else
                    {
                        Refresh_Page();
                    }
                }
            }
        }
        bool Employee_Can_Be_Deleted(int id)
        {
            return true;
        }

        private void Archive_Button_Click(object sender, EventArgs e)
        {
            if (Employee_ListView.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(employees[displayedIndexes[Employee_ListView.SelectedItems[0].Index]][0]);
                ConfirmationForm archiveConfirm = new ConfirmationForm() { text = "Warning: Archiving is a permanent action \n Only continue if you are certain" };
                if (archiveConfirm.ShowDialog() == DialogResult.OK)
                {
                    if (!SQL_Operation.UpdateEntryVariable(id, "EmployeeId", "Archived", "True", "EmployeeTable"))
                    {
                        MessageBox.Show("An error ocurred");
                    }
                    else
                    {
                        Refresh_Page();
                    }
                }
            }
        }
        void Show_Archive(object sender, EventArgs e)
        {
            showArchived = true;
            Show_Archive_Button.Click -= new EventHandler(Show_Archive);
            Show_Archive_Button.Click += new EventHandler(Hide_Archive);
            Show_Archive_Button.Image = Properties.Resources.archive_visible;
            Display_Employees();
        }
        void Hide_Archive(object sender, EventArgs e)
        {
            showArchived = false;
            Show_Archive_Button.Click -= new EventHandler(Hide_Archive);
            Show_Archive_Button.Click += new EventHandler(Show_Archive);
            Show_Archive_Button.Image = Properties.Resources.archive_not_visible;
            Display_Employees();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (Employee_ListView.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(employees[displayedIndexes[Employee_ListView.SelectedItems[0].Index]][0]);
                if (AddEmployee != null)
                {
                    AddEmployee.Invoke(this, new Add_Employee_EventArgs { AddMode = false, Id = id });
                }
                this.Close();
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (AddEmployee != null)
            {
                AddEmployee.Invoke(this, new Add_Employee_EventArgs { AddMode = true });
            }
            this.Close();
        }

        private void Email_Label_Click(object sender, EventArgs e)
        {

        }
    }
    public class Add_Employee_EventArgs : EventArgs
    {
        public int Id;
        public bool AddMode;
    }
}
