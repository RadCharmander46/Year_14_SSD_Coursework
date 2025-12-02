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
    public partial class PaymentDataForm : Form
    {
        List<string[]> payments = new List<string[]>();
        List<int> displayedIndexes = new List<int>();
        List<string[]> customers = new List<string[]>();
        public string[] paymentColumns = { "PaymentId", "Transaction Time", "CustomerId", "Amount", "Transaction Type", "Description", "Has Been Paid", "Cancelled" };
        public string[] customerColumns = { "CustomerId", "First Name/s", "Middle Name/s", "Last Name/s", "Date Of Birth", "Phone Number", "Email Address", "Address Line 1", "Address Line 2", "Town/City", "Postcode", "License No", "Issue Date", "Expiry Date", "Verified License", "Previous Customer", "Damaged Vehicle", "Archived" };
        string lastSorted;
        public PaymentDataForm()
        {
            InitializeComponent();
        }

        private void PaymentDataForm_Load(object sender, EventArgs e)
        {
            Setup_ListView();
        }
        void Setup_ListView()
        {
            Setup_Columns();
            Load_Payments();
            Load_Customers();
            Display_All_Payments();
        }
        void Setup_Columns()
        {
            Payments_ListView.Columns.Add("Customer Name",200);
            Payments_ListView.Columns.Add("Transaction Time",200);
            Payments_ListView.Columns.Add("Transaction Type",200);
            Payments_ListView.Columns.Add("Amount",200);
        }
        void Load_Payments()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM PaymentTable";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        string[] payment = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            if (columnName == "TransactionTime") //any datetimes that don't need the time part
                            {
                                payment[i] = Globals.removeSeconds(reader.GetValue(i).ToString());
                            }
                            else
                            {
                                payment[i] = reader.GetValue(i).ToString().Trim();
                            }
                        }
                        payments.Add(payment);
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
        void Display_All_Payments()
        {
            Payments_ListView.Items.Clear();
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] payment = payments[displayedIndexes[i]];
                ListViewItem row = new ListViewItem(Get_Customer_Name(payment[2]));
                row.SubItems.Add(payment[1]);
                row.SubItems.Add(payment[4]);
                row.SubItems.Add("£" + payment[3]);
                Payments_ListView.Items.Add(row);
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
        string[] Get_Customer_Values(int customerId)
        {
            foreach (string[] customer in customers)
            {
                if (customer[0] == customerId.ToString())
                {
                    return customer;
                }
            }
            return null;
        }
        string[] Get_Customer_Values(string customerId)
        {
            return Get_Customer_Values(Convert.ToInt32(customerId));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            Payments_ListView.Clear();
            payments.Clear();
            customers.Clear();
            displayedIndexes.Clear();
            Setup_ListView();
        }

        private void Payments_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Payments_ListView.SelectedItems.Count == 1)
            {
                string[] payment = payments[displayedIndexes[Payments_ListView.SelectedItems[0].Index]];
                string[] customer = Get_Customer_Values(payment[Get_Payment_Column_Index("CustomerId")]);

                Cust_DOB_Label.Text = "DOB: " + Globals.removeTime(customer[Get_Customer_Column_Index("Date Of Birth")]);
                Cust_Email_Label.Text = "Email: " + customer[Get_Customer_Column_Index("Email Address")];
                Cust_Tel_Label.Text = "Tel: " + customer[Get_Customer_Column_Index("Phone Number")];
                Cust_Postcode_Label.Text = "Postcode: " + customer[Get_Customer_Column_Index("Postcode")];
                PrevCust_Label.Text = "Previous Customer: " + Globals.boolToYN(customer[Get_Customer_Column_Index("Previous Customer")]);
                Cust_LicenseNo_Label.Text = "License No: " + customer[Get_Customer_Column_Index("License No")];
                Cust_Issue_Label.Text = "Issue: " + Globals.removeTime(customer[Get_Customer_Column_Index("Issue Date")]);
                Cust_Expiry_Label.Text = "Expiry: " + Globals.removeTime(customer[Get_Customer_Column_Index("Expiry Date")]);
                Verified_Label.Text = "Verified: " + Globals.boolToYN(customer[Get_Customer_Column_Index("Verified License")]);

                Transaction_Time_Label.Text = "Transaction Time: " + payment[Get_Payment_Column_Index("Transaction Time")];
                Amount_Label.Text = "Amount: £" + payment[Get_Payment_Column_Index("Amount")];
                Transaction_Type_Label.Text = "Transaction Type: " + payment[Get_Payment_Column_Index("Transaction Type")];
                Paid_Label.Text = "Has Been Paid: " + Globals.boolToYN(payment[Get_Payment_Column_Index("Has Been Paid")]);
                Cancelled_Label.Text = "Cancelled: " + Globals.boolToYN(payment[Get_Payment_Column_Index("Cancelled")]);
                Description_Text_Label.Text = payment[Get_Payment_Column_Index("Description")];

            }
            else
            {
                Reset_Labels();
            }
        }
        void Reset_Labels()
        {
            Cust_DOB_Label.Text = "DOB: ";
            Cust_Email_Label.Text = "Email:";
            Cust_Tel_Label.Text = "Tel:";
            Cust_Postcode_Label.Text = "Postcode:";
            PrevCust_Label.Text = "Previous Customer:";
            Cust_LicenseNo_Label.Text = "License No:";
            Cust_Issue_Label.Text = "Issue:";
            Cust_Expiry_Label.Text = "Expiry:";
            Verified_Label.Text = "Verified:";

            Transaction_Time_Label.Text = "Transaction Time:";
            Amount_Label.Text = "Amount: £";
            Transaction_Type_Label.Text = "Transaction Type: ";
            Paid_Label.Text = "Has Been Paid:";
            Cancelled_Label.Text = "Cancelled:";
            Description_Text_Label.Text = "";
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
        int Get_Payment_Column_Index(string column)
        {
            for (int i = 0; i < paymentColumns.Length; i++)
            {
                string paymentColumn = paymentColumns[i];
                if (paymentColumn == column)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Sort_Customer_Click(object sender, EventArgs e)
        {
            if (lastSorted != "Customer")
            {
                Sort_Customer_Names();
                Display_All_Payments();
                lastSorted = "Customer";
            }
            else
            {
                Inverse_Sort_Customer_Names();
                Display_All_Payments();
                lastSorted = "Inverse Customer";
            }
        }
        void Sort_Customer_Names() // 2 is customer id
        {
            displayedIndexes.Sort((a, b) => Get_Customer_Name(payments[a][2]).CompareTo(Get_Customer_Name(payments[b][2])));
        }
        void Inverse_Sort_Customer_Names() // 2 is customer id
        {
            displayedIndexes.Sort((b,a) => Get_Customer_Name(payments[a][2]).CompareTo(Get_Customer_Name(payments[b][2])));
        }

        void Sort_Amounts() // 3 is amount
        {
            displayedIndexes.Sort((a, b) => Convert.ToDecimal(payments[a][3]).CompareTo(Convert.ToDecimal(payments[b][3])));
        }
        void Inverse_Sort_Amounts() // 3 is amount
        {
            displayedIndexes.Sort((b,a) => Convert.ToDecimal(payments[a][3]).CompareTo(Convert.ToDecimal(payments[b][3])));
        }

        void Sort_Transaction_Times() // 1 is time
        {
            displayedIndexes.Sort((a, b) => Convert.ToDateTime(payments[a][1]).CompareTo(Convert.ToDateTime(payments[b][1])));
        }
        void Inverse_Sort_Transaction_Times() // 1 is time
        {
            displayedIndexes.Sort((b,a) => Convert.ToDateTime(payments[a][1]).CompareTo(Convert.ToDateTime(payments[b][1])));
        }

        void Sort_Transaction_Types() // 4 is type
        {
            displayedIndexes.Sort((a, b) => payments[a][4].CompareTo(payments[b][4]));
        }
        void Inverse_Sort_Transaction_Types()
        {
            displayedIndexes.Sort((b,a) => payments[a][4].CompareTo(payments[b][4]));
        }

        private void Sort_Transaction_Time_Click(object sender, EventArgs e)
        {
            if (lastSorted != "Times")
            {
                Sort_Transaction_Times();
                Display_All_Payments();
                lastSorted = "Times";
            }
            else
            {
                Inverse_Sort_Transaction_Times();
                Display_All_Payments();
                lastSorted = "Inverse Times";
            }
        }

        private void Sort_Transaction_Type_Click(object sender, EventArgs e)
        {
            if (lastSorted != "Types")
            {
                Sort_Transaction_Types();
                Display_All_Payments();
                lastSorted = "Types";
            }
            else
            {
                Inverse_Sort_Transaction_Types();
                Display_All_Payments();
                lastSorted = "Inverse Types";
            }
        }

        private void Sort_Amount_Click(object sender, EventArgs e)
        {
            if (lastSorted != "Amount")
            {
                Sort_Amounts();
                Display_All_Payments();
                lastSorted = "Amount";
            }
            else
            {
                Inverse_Sort_Amounts();
                Display_All_Payments();
                lastSorted = "Inverse Amount";
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            if(Filter_ComboBox.Text == "" || Filter_ComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please pick something to search by");
                return;
            }
            Reset_Displayed_Indexes();
            if(Filter_ComboBox.Text == "Customer Name")
            {
                Search_Customer_Name();
            }
            else 
            {
                int index = Get_Payment_Column_Index(Filter_ComboBox.Text);
                Search_Payments(index);
            }
            Display_All_Payments();
        }
        void Search_Customer_Name()
        {
            List<int> tempIndexes = new List<int>();
            string searchText = Filter_TextBox.Text;
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] payment = payments[displayedIndexes[i]];
                int customerId = Convert.ToInt32(payment[Get_Payment_Column_Index("CustomerId")]);
                string customerName = Get_Customer_Name(customerId.ToString());
                if (customerName.Contains(searchText))
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
        }
        void Search_Payments(int index)
        {
            List<int> tempIndexes = new List<int>();
            string searchText = Filter_TextBox.Text;
            for (int i = 0; i < displayedIndexes.Count; i++)
            {
                string[] payment = payments[displayedIndexes[i]];
                string value = payment[index];
                if (value.Contains(searchText))
                {
                    tempIndexes.Add(displayedIndexes[i]);
                }
            }
            displayedIndexes = tempIndexes;
        }
        void Reset_Displayed_Indexes()
        {
            List<int> tempIndexes = new List<int>();
            for (int i = 0; i < payments.Count; i++)
            {
                tempIndexes.Add(i);
            }
            displayedIndexes = tempIndexes;
        }
    }
}
