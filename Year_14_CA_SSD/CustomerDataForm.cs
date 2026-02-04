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
    public partial class CustomerDataForm : Form
    {
        public event EventHandler AddCustomer;
        public List<string[]> customers = new List<string[]>();
        public List<int> displayedIndexes = new List<int>();
        public static string[] columns = { "CustomerId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "License No", "Issue Date", "Expiry Date", "Verified License", "Previous Customer", "Damaged Vehicle", "Archived" };
        public bool showArchive = false;
        public string lastSort;
        public CustomerDataForm()
        {
            InitializeComponent();
        }
        private void CustomerDataForm_Load(object sender, EventArgs e)
        {
            Setup_Form();
            Reset_Labels();
        }
        private void ListViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewCustomers.SelectedItems.Count != 1)
            {
                Reset_Labels();
                return;
            }
            Value_Tool_Tip.RemoveAll();
            string[] customer = customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]];

            Telephone_Label.Text = customer[5];
            Value_Tool_Tip.SetToolTip(Telephone_Label, customer[5]);

            Email_Label.Text = Globals.splitEmailTwoRows(customer[6], 15);
            Value_Tool_Tip.SetToolTip(Email_Label, customer[6]);

            Address_Line1_Label.Text = customer[7];
            Value_Tool_Tip.SetToolTip(Address_Line1_Label, customer[7]);

            Address_Line2_Label.Text = customer[8];
            Value_Tool_Tip.SetToolTip(Address_Line2_Label, customer[8]);

            Address_Line3_Label.Text = customer[9];
            Value_Tool_Tip.SetToolTip(Address_Line3_Label, customer[9]);

            Postcode_Label.Text = customer[10];
            Value_Tool_Tip.SetToolTip(Postcode_Label, customer[10]);

            License_Number_Label.Text = customer[11];
            Value_Tool_Tip.SetToolTip(License_Number_Label, customer[11]);

            Issue_Label.Text = customer[12];
            Value_Tool_Tip.SetToolTip(Issue_Label, customer[12]);

            Expiry_Label.Text = customer[13];
            Value_Tool_Tip.SetToolTip(Expiry_Label, customer[13]);

            Verified_Label.Text = Globals.boolToYN(customer[14]);
            Value_Tool_Tip.SetToolTip(Verified_Label, Globals.boolToYN(customer[14]));

            Previous_Label.Text = Globals.boolToYN(customer[15]);
            Value_Tool_Tip.SetToolTip(Previous_Label, Globals.boolToYN(customer[15]));

            Damaged_Label.Text = Globals.boolToYN(customer[16]);
            Value_Tool_Tip.SetToolTip(Damaged_Label, Globals.boolToYN(customer[16]));
            
        }
        void Reset_Labels()
        {
            Telephone_Label.Text = "";
            Email_Label.Text = "";
            Address_Line1_Label.Text = "";
            Address_Line2_Label.Text = "";
            Address_Line3_Label.Text = "";
            Postcode_Label.Text = "";
            License_Number_Label.Text = "";
            Issue_Label.Text = "";
            Expiry_Label.Text = "";
            Verified_Label.Text = "";
            Previous_Label.Text = "";
            Damaged_Label.Text = "";
        }
        private void Search_Button_Click(object sender, EventArgs e)
        {
            Filter_Customers();
            Display_Archived();
        }
        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            Refresh_Page();
        }
        void Refresh_Page()
        {
            customers.Clear();
            displayedIndexes.Clear();
            ListViewCustomers.Clear();
            Setup_Form();
        }
        private void Update_Customer_Button_Click(object sender, EventArgs e)
        {
            if(ListViewCustomers.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]][0]);
                if (ListViewCustomers.SelectedItems[0].ForeColor == Color.DarkGray)
                {
                    MessageBox.Show("Customer is archived, so they cannot be edited");
                    return;
                }
                if(AddCustomer != null)
                {
                    AddCustomer.Invoke(this, new Add_Customer_EventArgs { AddMode = false, Id = id });
                }
                this.Close();
            }
        }
        private void Remove_Customer_Button_Click(object sender, EventArgs e)
        {
            if (ListViewCustomers.SelectedItems.Count != 1)
            {
                MessageBox.Show("One customer must be selected");
                return;
            }
            if (ListViewCustomers.SelectedItems[0].ForeColor == Color.DarkGray)
            {
                MessageBox.Show("Customer is archived, so they cannot be deleted");
                return;
            }
            int id = Convert.ToInt32(customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]][0]);
            if(!Can_Delete(id))
            {
                MessageBox.Show("Customer cannot be deleted, please archive instead");
                return;
            }
            ConfirmationForm deleteConfirm = new ConfirmationForm() { text = "Warning: Deleting is a permanent action \n Only continue if you are certain" };
            deleteConfirm.StartPosition = FormStartPosition.Manual;
            deleteConfirm.Location = new Point(Cursor.Position.X - deleteConfirm.Size.Width / 2 + 100, Cursor.Position.Y - deleteConfirm.Size.Height / 2);
            if (deleteConfirm.ShowDialog() == DialogResult.OK)
            {
                if (!SQL_Operation.DeleteEntry(id, "CustomerId", "CustomerTable"))
                {
                    MessageBox.Show("And error occured");
                    return;
                }
                Refresh_Page();
            }
        }
        private void Add_Customer_Button_Click(object sender, EventArgs e)
        {
            if (AddCustomer != null)
            {
                AddCustomer.Invoke(this, new Add_Customer_EventArgs { AddMode = true });
            }
            this.Close();
        }
        static int Get_Column_Index(string column)
        {
            for(int i = 0; i < columns.Length;i++)
            {
                if(columns[i] == column)
                {
                    return i;
                }
            }
            return -1;
        }
        void Filter_Customers()
        {
            int filterIndex = Get_Column_Index(Filter_ComboBox.Text);
            if(filterIndex == -1)
            {
                MessageBox.Show("Filter not selected");
                return;
            }
            displayedIndexes.Clear();
            for (int i = 0; i < customers.Count;i++)
            {
                string[] customer = customers[i];
                if(customer[filterIndex].Contains(Filter_TextBox.Text))
                {
                    displayedIndexes.Add(i);
                }
            }
        }
        void Setup_Form()
        {
            Setup_ListView();
            Load_Customers();
            Display_Archived();
        }
        void Setup_ListView()
        {
            ListViewCustomers.Font = new Font(ListViewCustomers.Font, FontStyle.Bold);
            ListViewCustomers.ForeColor = Color.Red;
            ListViewCustomers.Columns.Add("First Name/s", 150);
            ListViewCustomers.Columns.Add("Middle Name/s", 150);
            ListViewCustomers.Columns.Add("Last Name/s", 150);
            ListViewCustomers.Columns.Add("Date Of Birth", 150);
            ListViewCustomers.Columns.Add("Phone Number", 170);
        }
        void Display_Customers()
        {
            ListViewCustomers.Items.Clear();
            for(int i = 0; i < displayedIndexes.Count;i++)
            {
                string[] customer = customers[displayedIndexes[i]];
                ListViewItem row = new ListViewItem(customer[1]);
                row.SubItems.Add(customer[2]);
                row.SubItems.Add(customer[3]);
                row.SubItems.Add(customer[4]);
                row.SubItems.Add(customer[5]);
                row.Font = new Font(ListViewCustomers.Font, FontStyle.Regular);
                if (Customer_Is_Archived(customer))
                {
                    row.ForeColor = Color.DarkGray;
                }
                else if(Customer_Is_Liabillty(customer))
                {
                    row.ForeColor = Color.Red;
                }
                else
                {
                    row.ForeColor = Color.Black;
                }
                row.ToolTipText = row.Text;
                ListViewCustomers.Items.Add(row);
            }
        }
        bool Customer_Is_Archived(string[] customer)
        {
            return Convert.ToBoolean(customer[Get_Column_Index("Archived")]);
        }
        bool Customer_Is_Liabillty(string[] customer)
        {
            return Convert.ToBoolean(customer[Get_Column_Index("Damaged Vehicle")]);
        }
        void Load_Customers()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM CustomerTable";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        string[] customer = new string[reader.FieldCount];
                        for(int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            if (columnName == "DateOfBirth" || columnName == "IssueDate" || columnName == "ExpiryDate") //any datetimes that don't need the time part
                            {
                                customer[i] = Globals.removeTime(reader.GetValue(i).ToString());
                            }
                            else
                            {
                                customer[i] = reader.GetValue(i).ToString().Trim();
                            }
                        }
                        customers.Add(customer);
                        displayedIndexes.Add(index);
                        index++;

                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured");
                }
            }
        }
        void Display_Archived()
        {
            if (!showArchive)
            {
                Filter_By_Archive();
                Display_Customers();
            }
            else //was hidding archived so need to reload customer
            {
                if(Filter_TextBox.Text != "")
                {
                    Filter_Customers();
                }
                else
                {
                    Reset_Displayed_Indexes();
                }
                Display_Customers();
            }
        }
        void Reset_Displayed_Indexes()
        {
            displayedIndexes.Clear();
            for (int i = 0; i < customers.Count; i++)
            {
                displayedIndexes.Add(i);
            }

        }
        void Filter_By_Archive()
        {
            List<int> tempIndexes = new List<int>();
            int archiveIndex = Get_Column_Index("Archived");
            foreach(int index in displayedIndexes)
            {
                if(customers[index][archiveIndex] == "False")
                {
                    tempIndexes.Add(index);
                }
            }
            displayedIndexes = tempIndexes;
        }

        private void Show_Archive_Button_Click(object sender, EventArgs e)
        {

        }
        void Show_Archive(object sender,EventArgs e)
        {
            showArchive = true;
            Show_Archive_Button.Click -= new EventHandler(Show_Archive);
            Show_Archive_Button.Click += new EventHandler(Hide_Archive);
            Show_Archive_Button.BackgroundImage = Properties.Resources.archive_visible;
            Display_Archived();
        }
        void Hide_Archive(object sender,EventArgs e)
        {
            showArchive = false;
            Show_Archive_Button.Click -= new EventHandler(Hide_Archive);
            Show_Archive_Button.Click += new EventHandler(Show_Archive);
            Show_Archive_Button.BackgroundImage = Properties.Resources.archive_not_visible;
            Display_Archived();
        }

        private void Archive_Button_Click(object sender, EventArgs e)
        {
            if(!Globals.isManager)
            {
                MessageBox.Show("Needs manager approval");
                return;
            }
            if(ListViewCustomers.SelectedItems.Count != 1)
            {
                MessageBox.Show("One customer must be selected");
                return;
            }
            if (ListViewCustomers.SelectedItems[0].ForeColor == Color.DarkGray)
            {
                MessageBox.Show("Customer is already archived");
                return;
            }
            int id = Convert.ToInt32(customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]][0]);
            if(!Can_Archive(id))
            {
                MessageBox.Show("Customer can't be archived");
                return;
            }
            ConfirmationForm archiveConfirm = new ConfirmationForm() { text = "Warning: Archiving is a permanent action \n Only continue if you are certain" };
            archiveConfirm.StartPosition = FormStartPosition.Manual;
            archiveConfirm.Location = new Point(Cursor.Position.X - archiveConfirm.Size.Width / 2 + 100, Cursor.Position.Y - archiveConfirm.Size.Height / 2);
            if (archiveConfirm.ShowDialog() == DialogResult.OK)
            {
                if (!SQL_Operation.UpdateEntryVariable(id, "CustomerId", "Archived", "True", "CustomerTable"))
                {
                    MessageBox.Show("An error ocurred");
                }
                else
                {
                    Refresh_Page();
                }
            }
        }
        bool Can_Delete(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT * FROM TestDriveTable WHERE CustomerId = '{ customerId}'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    string[] testDrive = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        testDrive[i] = reader.GetValue(i).ToString().Trim();
                    }

                    conn.Close();
                    return false;
                }
                catch (Exception e)
                {
                    return true;
                }
            }

        }
        bool Can_Archive(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT * FROM TestDriveTable WHERE CustomerId = '{ customerId}' AND StartTime > {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    string[] testDrive = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        testDrive[i] = reader.GetValue(i).ToString().Trim();
                    }

                    conn.Close();
                    return false;
                }
                catch (Exception e)
                {
                    return true;
                }
            }
        }

        public void Sort_Customer(List<int> items,int sortingIndex)
        {
            items.Sort((a, b) => customers[a][sortingIndex].CompareTo(customers[b][sortingIndex]));
        }
        public void Sort_Inverse_Customer(List<int> items, int sortingIndex)
        {
            items.Sort((b, a) => customers[a][sortingIndex].CompareTo(customers[b][sortingIndex]));
        }

        private void Sort_FirstName_Click(object sender, EventArgs e)
        {
            if (lastSort != "First Name")
            {
                Sort_Customer(displayedIndexes, 1);
                Display_Customers();
                lastSort = "First Name";
            }
            else
            {
                Sort_Inverse_Customer(displayedIndexes, 1);
                Display_Customers();
                lastSort = "Inverse First Name";
            }
        }

        private void Sort_Middle_Name_Click(object sender, EventArgs e)
        {
            if (lastSort != "Middle Name")
            {
                Sort_Customer(displayedIndexes, 2);
                Display_Customers();
                lastSort = "Middle Name";
            }
            else
            {
                Sort_Inverse_Customer(displayedIndexes, 2);
                Display_Customers();
                lastSort = "Inverse Middle Name";
            }
        }

        private void Sort_Last_Name_Click(object sender, EventArgs e)
        {
            if (lastSort != "Last Name")
            {
                Sort_Customer(displayedIndexes, 3);
                Display_Customers();
                lastSort = "Last Name";
            }
            else
            {
                Sort_Inverse_Customer(displayedIndexes, 3);
                Display_Customers();
                lastSort = "Inverse Last Name";
            }
        }

        private void Sort_DOB_Click(object sender, EventArgs e)
        {
            if (lastSort != "Date Of Birth")
            {
                displayedIndexes.Sort((a, b) => Convert.ToDateTime(customers[a][4]).CompareTo(Convert.ToDateTime(customers[b][4])));
                Display_Customers();
                lastSort = "Date Of Birth";
            }
            else
            {
                displayedIndexes.Sort((b, a) => Convert.ToDateTime(customers[a][4]).CompareTo(Convert.ToDateTime(customers[b][4])));
                Display_Customers();
                lastSort = "Inverse Date Of Birth";
            }
        }

        private void Sort_Phone_Number_Click(object sender, EventArgs e)
        {
            if (lastSort != "Phone Number")
            {
                Sort_Customer(displayedIndexes, 5);
                Display_Customers();
                lastSort = "Phone Number";
            }
            else
            {
                Sort_Inverse_Customer(displayedIndexes, 5);
                Display_Customers();
                lastSort = "Inverse Phone Number";
            }
        }

        private void Filter_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search_Button.PerformClick();
            }
        }
    }
    public class Add_Customer_EventArgs : EventArgs
    {
        public int Id;
        public bool AddMode;
    }

}
