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
        public CustomerDataForm()
        {
            InitializeComponent();
        }
        private void CustomerDataForm_Load(object sender, EventArgs e)
        {

        }
        private void ListViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Search_Button_Click(object sender, EventArgs e)
        {

        }
        private void Refresh_Button_Click(object sender, EventArgs e)
        {

        }
        private void Update_Customer_Button_Click(object sender, EventArgs e)
        {

        }
        private void Remove_Customer_Button_Click(object sender, EventArgs e)
        {

        }
        private void Add_Customer_Button_Click(object sender, EventArgs e)
        {

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
                            if (reader.GetName(i) == "DateOfBirth")
                            {
                                customer[i] = Globals.removeTime(reader.GetValue(i).ToString());
                            }
                            else
                            {
                                customer[i] = reader.GetValue(i).ToString().Trim();
                            }
                        }
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
    }
    public class Add_Customer_EventArgs : EventArgs
    {
        public int Id;
        public bool AddMode;
    }

}
