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
        public string[] columns = { "CustomerId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "License No", "Issue Date", "Expiry Date", "Verified License", "Previous Customer", "Damaged Vehicle", "Archived" };
        public bool showArchive = false;
        public CustomerDataForm()
        {
            InitializeComponent();
        }
        private void CustomerDataForm_Load(object sender, EventArgs e)
        {
            Setup_Form();
        }
        private void ListViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewCustomers.SelectedItems.Count == 1)
            {
                string[] customer = customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]];
                Telephone_Label.Text = "Tel: " + customer[5];
                Email_Label.Text = "Email: " + Globals.splitEmailTwoRows(customer[6], 20);
                Address_Line1_Label.Text = customer[7];
                Address_Line2_Label.Text = customer[8];
                Address_Line3_Label.Text = customer[9];
                Postcode_Label.Text = customer[10];
                License_Number_Label.Text = "License No: " +customer[11];
                Issue_Label.Text = "Issue: " + customer[12];
                Expiry_Label.Text = "Expiry: " + customer[13];
                Verified_Label.Text = "Verified License: " + Globals.boolToYN(customer[14]);
                Previous_Label.Text = "Previous Customer: " +Globals.boolToYN(customer[15]);
                Damaged_Label.Text = "Damaged Vehicle: " +Globals.boolToYN(customer[16]);
            }
            else
            {
                Telephone_Label.Text = "Tel:";
                Email_Label.Text = "Email:";
                Address_Line1_Label.Text = "";
                Address_Line2_Label.Text = "";
                Address_Line3_Label.Text = "";
                Postcode_Label.Text = "";
                License_Number_Label.Text = "License No:";
                Issue_Label.Text = "Issue:";
                Expiry_Label.Text = "Expiry:";
                Verified_Label.Text = "Verified License:";
                Previous_Label.Text = "Previous Customer:";
                Damaged_Label.Text = "Damaged Vehicle:";
            }
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
                if(AddCustomer != null)
                {
                    AddCustomer.Invoke(this, new Add_Customer_EventArgs { AddMode = false, Id = id });
                }
                this.Close();
            }
        }
        private void Remove_Customer_Button_Click(object sender, EventArgs e)
        {
            if (ListViewCustomers.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]][0]);
                if(Can_Delete(id))
                {
                    if (!SQL_Operation.DeleteEntry(id, "CustomerId", "CustomerTable"))
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
        private void Add_Customer_Button_Click(object sender, EventArgs e)
        {
            if (AddCustomer != null)
            {
                AddCustomer.Invoke(this, new Add_Customer_EventArgs { AddMode = true });
            }
            this.Close();
        }
        int Get_Column_Index(string column)
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
            ListViewCustomers.Columns.Add("First Name/s", 150);
            ListViewCustomers.Columns.Add("Middle Name/s", 150);
            ListViewCustomers.Columns.Add("Last Name/s", 150);
            ListViewCustomers.Columns.Add("Date Of Birth", 150);
            ListViewCustomers.Columns.Add("Phone Number", 150);
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
                ListViewCustomers.Items.Add(row);
            }
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
            Show_Archive_Button.Image = Properties.Resources.archive_visible;
            Display_Archived();
        }
        void Hide_Archive(object sender,EventArgs e)
        {
            showArchive = false;
            Show_Archive_Button.Click -= new EventHandler(Hide_Archive);
            Show_Archive_Button.Click += new EventHandler(Show_Archive);
            Show_Archive_Button.Image = Properties.Resources.archive_not_visible;
            Display_Archived();
        }

        private void Archive_Button_Click(object sender, EventArgs e)
        {
            if(ListViewCustomers.SelectedItems.Count == 1)
            {
                int id = Convert.ToInt32(customers[displayedIndexes[ListViewCustomers.SelectedItems[0].Index]][0]);
                ConfirmationForm archiveConfirm = new ConfirmationForm() {text = "Warning: Archiving is a permanent action \n Only continue if you are certain" };
                if(archiveConfirm.ShowDialog() == DialogResult.OK)
                {
                    if(!SQL_Operation.UpdateEntryVariable(id,"CustomerId","Archived","True","CustomerTable"))
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
        bool Can_Delete(int id)
        {
            return true;
        }
    }
    public class Add_Customer_EventArgs : EventArgs
    {
        public int Id;
        public bool AddMode;
    }

}
