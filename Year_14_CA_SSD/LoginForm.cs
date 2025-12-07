using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class LoginForm : Form
    {
        public event EventHandler SignedIn;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Check_Username_Password();
        }
        void Check_Username_Password()
        {
            try
            {
                string password = Load_Employee_Password();
                if(password == null)
                {
                    throw new Exception();
                }
                if(password == "") //no username was found
                {
                    MessageBox.Show("Incorrect Username");
                    return;
                }
                if(password != Password_TextBox.Text)
                {
                    MessageBox.Show("Incorrect Password");
                    return;
                }
                int id = (int)Load_Employee_Id();
                Globals.loginId = id;
                Globals.signedIn = true;
                Globals.isManager = Load_Employee_Is_Manager();

                if(SignedIn != null)
                {
                    SignedIn.Invoke(this,EventArgs.Empty);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("An error occured");
            }
        }
        string Load_Employee_Password()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT Password FROM EmployeeTable WHERE Username ='{Username_TextBox.Text}'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string password = reader["Password"].ToString().Trim();
                        conn.Close();
                        return password;
                    }
                    conn.Close();
                    return "";
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        int? Load_Employee_Id()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT EmployeeId FROM EmployeeTable WHERE Username ='{Username_TextBox.Text}'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["EmployeeId"].ToString().Trim());
                        conn.Close();
                        return id;
                    }
                    conn.Close();
                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        bool Load_Employee_Is_Manager()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT Role FROM EmployeeTable WHERE Username ='{Username_TextBox.Text}'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if(reader["Role"].ToString().Trim() == "Manager")
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    throw new Exception();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        private void Show_Password_Button_MouseDown(object sender, MouseEventArgs e)
        {
            Password_TextBox.UseSystemPasswordChar = false;
        }

        private void Show_Password_Button_MouseUp(object sender, MouseEventArgs e)
        {
            Password_TextBox.UseSystemPasswordChar = true;
        }

        private void Forgotten_Password_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact an admistrator to reset your password");
        }
    }
}
