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
    public partial class PickerForm : Form
    {
        public string Table;
        public int? SelectedId;
        public List<int> Ids = new List<int>();
        public int FilteringIndex = 0;
        public List<string[]> TableValues = new List<string[]>();
        public PickerForm()
        {
            InitializeComponent();
            
        }
        void Setup_Customers()
        {
            Table_ListView.Columns.Add("First Name", 91);
            Table_ListView.Columns.Add("Last Name", 91);
            Table_ListView.Columns.Add("Phone Number", 91);
            Table_ListView.Columns.Add("Date Of Birth", 91);
            Load_Customers();
            Display_Values();
            Sorting_Label.Text = "Fn";
        }
        void Setup_Employees()
        {
            Table_ListView.Columns.Add("ID", 91);
            Table_ListView.Columns.Add("First Name", 91);
            Table_ListView.Columns.Add("Last Name", 91);
            Table_ListView.Columns.Add("Date Of Birth", 91);
            Load_Employees();
            Display_Values();
            Sorting_Label.Text = "ID";
        }
        void Setup_Cars()
        {
            Table_ListView.Columns.Add("Registration", 91);
            Table_ListView.Columns.Add("Make", 91);
            Table_ListView.Columns.Add("Model", 91);
            Table_ListView.Columns.Add("Year Of Manufacture", 91);
            Load_Cars();
            Display_Values();
            Sorting_Label.Text = "REG";
        }
        private void Load_Customers()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CustomerId, FirstName, LastName, DateOfBirth, PhoneNumber FROM CustomerTable WHERE Archived = 'False'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] values = new string[4];
                        values[0] = reader["FirstName"].ToString().Trim();
                        values[1] = reader["LastName"].ToString().Trim();
                        values[2] = reader["PhoneNumber"].ToString().Trim();
                        values[3] = Globals.removeTime(reader["DateOfBirth"].ToString().Trim());

                        Ids.Add(Convert.ToInt32(reader["CustomerId"].ToString()));

                        
                        TableValues.Add(values);
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured");
                }
            }
        }

        void Load_Employees()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT EmployeeId, Username, FirstName, LastName, DateOfBirth FROM EmployeeTable WHERE Archived = 'False'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] values = new string[4];
                        values[0] = reader["Username"].ToString().Trim();
                        values[1] = reader["FirstName"].ToString().Trim();
                        values[2] = reader["LastName"].ToString().Trim();
                        values[3] = Globals.removeTime(reader["DateOfBirth"].ToString().Trim());

                        Ids.Add(Convert.ToInt32(reader["EmployeeId"].ToString()));


                        TableValues.Add(values);

                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured");
                }
            }
        }

        void Load_Cars()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT CarId, Registration, Make, Model, YearOfManufacture FROM CarTable";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] values = new string[4];
                        values[0] = reader["Registration"].ToString().Trim();
                        values[1] = reader["Make"].ToString().Trim();
                        values[2] = reader["Model"].ToString().Trim();
                        values[3] = Globals.getYear(reader["YearOfManufacture"].ToString().Trim());

                        Ids.Add(Convert.ToInt32(reader["CarId"].ToString()));

                        TableValues.Add(values);

                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error occured when loading the Car Database");
                }
            }
        }
      
      

        private void PickerForm_Load(object sender, EventArgs e)
        {
            if (Table == "Customers")
            {
                Setup_Customers();
            }
            else if (Table == "Employees")
            {
                Setup_Employees();
            }
            else if (Table == "Cars")
            {
                Setup_Cars();
            }
            else
            {
                MessageBox.Show("Unknown table");
                this.Close();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Continue_Button_Click(object sender, EventArgs e)
        {
            if (Table_ListView.SelectedItems.Count == 1)
            {
                int index = Table_ListView.SelectedItems[0].Index;
                SelectedId = Ids[index];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nothing is selected");
            }    
        }

        private void Search_TextBox_TextChanged(object sender, EventArgs e)
        {
            Display_Values();
        }
        void Display_Values()
        {
            Table_ListView.Items.Clear();
            foreach(string[] values in TableValues)
            {
                if (values[FilteringIndex].Contains(Search_TextBox.Text) || Search_TextBox.Text == "")
                {
                    ListViewItem row = new ListViewItem(values[0]);
                    row.SubItems.Add(values[1]);
                    row.SubItems.Add(values[2]);
                    row.SubItems.Add(values[3]);
                    row.ToolTipText = row.Text;
                    Table_ListView.Items.Add(row);
                }
            }
            
        }

        private void Change_Column_Button_Click(object sender, EventArgs e)
        {
            try
            {
                FilteringIndex++;
                if (FilteringIndex > 3)
                {
                    FilteringIndex = 0;
                }
                Change_Filter_Label();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        void Change_Filter_Label()
        {
            if (Table == "Customers")
            {
                if(FilteringIndex == 0)
                {
                    Sorting_Label.Text = "FN";
                }
                else if (FilteringIndex == 1)
                {
                    Sorting_Label.Text = "LN";
                }
                else if (FilteringIndex == 2)
                {
                    Sorting_Label.Text = "Tel";
                }
                else if (FilteringIndex == 3)
                {
                    Sorting_Label.Text = "DOB";
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else if (Table == "Employees")
            {
                if (FilteringIndex == 0)
                {
                    Sorting_Label.Text = "ID";
                }
                else if (FilteringIndex == 1)
                {
                    Sorting_Label.Text = "FN";
                }
                else if (FilteringIndex == 2)
                {
                    Sorting_Label.Text = "LN";
                }
                else if (FilteringIndex == 3)
                {
                    Sorting_Label.Text = "DOB";
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else if (Table == "Cars")
            {
                if (FilteringIndex == 0)
                {
                    Sorting_Label.Text = "REG";
                }
                else if (FilteringIndex == 1)
                {
                    Sorting_Label.Text = "MK";
                }
                else if (FilteringIndex == 2)
                {
                    Sorting_Label.Text = "MDL";
                }
                else if (FilteringIndex == 3)
                {
                    Sorting_Label.Text = "YOM";
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Unknown Table");
            }
        }

        private void Table_ListView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Continue_Button.PerformClick();
            }
        }
    }
}
