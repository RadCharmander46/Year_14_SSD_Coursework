using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class HomeScreenForm : Form
    {
        public event EventHandler SignIn;
        public event EventHandler ReturnCar;
        public HomeScreenForm()
        {
            InitializeComponent();
        }
        int carId;
        int testDriveId;
        DateTime endTime;

        private void HomeScreenForm_Load(object sender, EventArgs e)
        {
            if(!Globals.signedIn)
            {
                Message_Label.Visible = true;
                Message_Button.Visible = true;
            }
            else
            {
                Check_Car_Returns();
            }
        }

        private void Sign_In_Button_Click(object sender, EventArgs e)
        {
            if (Message_Button.Text == "Sign In")
            {
                if (SignIn != null)
                {
                    SignIn.Invoke(this, EventArgs.Empty);
                }
                this.Close();
            }
            else if(Message_Button.Text == "Return Car")
            {
                if(ReturnCar != null)
                {
                    ReturnCar.Invoke(this, new Car_Return_EventArgs() { testDriveId = testDriveId, carId = carId });
                }
                this.Close();
            }
        }

        void Check_Car_Returns()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT CarUnavailabiltyTable.EndTime,CarUnavailabiltyTable.CarId, TestDriveTable.TestDriveId FROM TestDriveTable " +
                        $"INNER JOIN CarUnavailabiltyTable ON TestDriveTable.CarUnavailabiltyId = CarUnavailabiltyTable.CarUnavailabiltyId " +
                        $"WHERE TestDriveTable.HasBeenReturned = 'FALSE' AND CarUnavailabiltyTable.EndTime <= '{DateTime.Now.AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss")}'";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        endTime = Convert.ToDateTime(reader["EndTime"].ToString());
                        carId = Convert.ToInt32(reader["CarId"].ToString());
                        testDriveId = Convert.ToInt32(reader["TestDriveId"].ToString());
                        conn.Close();
                        Show_Car_Return_Message();
                        return;
                    }
                    conn.Close();
                    Hide_Car_Return_Message();
                    return;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("An error occured");
                    Hide_Car_Return_Message();
                    return;
                }
            }
        }
        void Show_Car_Return_Message()
        {
            Message_Label.Visible = true;
            Message_Button.Visible = true;

            string[] carValues = SQL_Operation.ReadEntry(carId, "CarId", "CarTable");
            string carName = Globals.removeWhitespace(Globals.getYear(carValues[4]) + " " + carValues[1] + " " + carValues[2]);
            string message = $"{carName} should be returning at {endTime.ToString("HH:mm")}";

            Message_Label.Text = message;
            Message_Button.Text = "Return Car";
        }
        void Hide_Car_Return_Message()
        {
            Message_Label.Visible = false;
            Message_Button.Visible = false;
        }
    }
    public class Car_Return_EventArgs : EventArgs
    {
        public int testDriveId;
        public int carId;
    }
}
