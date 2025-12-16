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
    public partial class CarCalendarForm : Form
    {
        public int? CarId;
        public DateTime? SelectedDate;
        public CarCalendarForm()
        {
            InitializeComponent();
        }
        readonly string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        private void CarCalendarForm_Load(object sender, EventArgs e)
        {
            int month = DateTime.Now.Month - 1;
            if (month < 0)
            {
                month = 11;
            }
            Month_Label.Text = months[month];
            Load_Calendar();
        }
        async void Load_Calendar()
        {
            SelectedDate = null;
            Calendar_FlowPanel.Controls.Clear();
            int month = Get_Index_Of_Month(Month_Label.Text) +1;

            DateTime firstDayMonth = Convert.ToDateTime($"{Year_Label.Text}/{month}/01");
            DayOfWeek day = firstDayMonth.DayOfWeek;
            int indexFirstDayMonth = Convert.ToInt32(day) -1 ; //would be minus 1 but sunday is 0
            if (indexFirstDayMonth < 0) { indexFirstDayMonth += 7; }
            indexFirstDayMonth -= 1;
            int year = Convert.ToInt32(Year_Label.Text);
            int previousMonth = month - 1;
            if(previousMonth < 1)
            {
                previousMonth = 12;
            }
            int previousMonthDays = DateTime.DaysInMonth(year, previousMonth);
            int monthDays = DateTime.DaysInMonth(year, month);

            int nextMonth = month + 1;
            if (nextMonth > 12)
            {
                nextMonth = 1;
            }

            DateTime[][] carUnavailabiltyTimes = Get_Car_Unavailabilty_Times();

            for(int i = previousMonthDays - indexFirstDayMonth ; i<=previousMonthDays;i++)
            {
                DateTime date = Convert.ToDateTime($"{year}/{previousMonth}/{i}");
                Calendar_FlowPanel.Controls.Add(Create_Date(date, carUnavailabiltyTimes, true));
            }
            for (int i = 1; i <= monthDays; i++)
            {
                DateTime date = Convert.ToDateTime($"{year}/{month}/{i}");
                Calendar_FlowPanel.Controls.Add(Create_Date(date, carUnavailabiltyTimes));
            }

            int numberOfDatesShown = Calendar_FlowPanel.Controls.Count;
            int numberToShow = 7 - (numberOfDatesShown % 7);
            if(numberToShow == 7) { numberToShow = 0; }
            for (int i = 1; i <= numberToShow; i++)
            {
                DateTime date = Convert.ToDateTime($"{year}/{nextMonth}/{i}");
                Calendar_FlowPanel.Controls.Add(Create_Date(date,carUnavailabiltyTimes,true));
            }
            Calendar_Date_FlowPanel.Hide();
        }
        FlowLayoutPanel Create_Date(DateTime day,DateTime[][] carUnavailtyTimes, bool darkened = false)
        {
            FlowLayoutPanel date = new FlowLayoutPanel();
            date.Size = Calendar_Date_FlowPanel.Size;
            date.Padding = Calendar_Date_FlowPanel.Padding;
            date.BorderStyle = BorderStyle.FixedSingle;
            date.FlowDirection = Calendar_Date_FlowPanel.FlowDirection;

            int numberOfEvents = 0;
            if (CarId != null)
            {
                numberOfEvents = Number_Of_Events_On_Day(carUnavailtyTimes, day);
            }

            foreach (Control control in Calendar_Date_FlowPanel.Controls)
            {
                if (control.Name == "Day_Label")
                {
                    Label newLabel = new Label();
                    newLabel.Size = control.Size;
                    newLabel.Name = control.Name;
                    newLabel.BackColor = Calendar_FlowPanel.BackColor;
                    newLabel.Font = control.Font;
                    newLabel.AutoSize = false;
                    newLabel.TextAlign = ContentAlignment.MiddleCenter;
                    newLabel.Text = Convert.ToString(day.Day);
                    if(darkened)
                    {
                        newLabel.ForeColor = Color.Silver;
                    }
                    newLabel.Visible = true;
                    newLabel.Click += new EventHandler(Date_Selected_Child);
                    date.Controls.Add(newLabel);
                }
                else
                {
                    PictureBox newControl = new PictureBox();
                    newControl.Size = control.Size;
                    newControl.Name = control.Name;
                    newControl.Text = control.Text;
                    newControl.BackColor = control.BackColor;
                    bool visible = false ;
                    if (newControl.Name == "Event_1_PictureBox" && numberOfEvents >= 1)
                    {
                        visible = true;
                    }
                    if (newControl.Name == "Event_2_PictureBox" && numberOfEvents >= 2)
                    {
                        visible = true;
                    }
                    if (newControl.Name == "Event_3_PictureBox" && numberOfEvents >= 3)
                    {
                        visible = true;
                    }
                    if (visible)
                    {
                        if (!darkened)
                        {
                            newControl.BackColor = control.BackColor;
                        }
                        else
                        {
                            newControl.BackColor = Color.DarkGray;
                        }
                    }
                    else
                    {
                        newControl.BackColor = Calendar_FlowPanel.BackColor;
                    }
                    newControl.Font = control.Font;
                    newControl.Click += new EventHandler(Date_Selected_Child);
                    date.Controls.Add(newControl);
                }
            }
            date.Click += new EventHandler(Date_Selected);
            
            return date;
        }
        void Increase_Date()
        {
            string currentMonth = Month_Label.Text;
            int index = Get_Index_Of_Month(currentMonth);
            
            int newIndex = index + 1;
            if(newIndex >= 12)
            {
                int year = Convert.ToInt32(Year_Label.Text);
                Year_Label.Text = Convert.ToString(year + 1);
                newIndex-= 12;
            }
            Month_Label.Text = months[newIndex];

        }
        void Decrease_Date()
        {
            string currentMonth = Month_Label.Text;
            int index = Get_Index_Of_Month(currentMonth); 
            int newIndex = index - 1;
            if (newIndex < 0)
            {
                int year = Convert.ToInt32(Year_Label.Text);
                Year_Label.Text = Convert.ToString(year - 1);
                newIndex += 12;
            }
            Month_Label.Text = months[newIndex];
        }

        int Get_Index_Of_Month(string month)
        {
            for (int i = 0; i < 12; i++)
            {
                if (months[i] == month)
                {
                    return i;
                }
            }
            return 0;
        }

        private void Next_Month_Button_Click(object sender, EventArgs e)
        {
            Increase_Date();
            Load_Calendar();
        }

        private void Previous_Month_Button_Click(object sender, EventArgs e)
        {
            Decrease_Date();
            Load_Calendar();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        DateTime[][] Get_Car_Unavailabilty_Times()
        {
            List<DateTime[]> unavailabiltyTimes = new List<DateTime[]>();
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT StartTime,EndTime FROM CarUnavailabiltyTable WHERE  CarId = '{CarId}' ";
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
        String[][] Get_Car_Unavailabilty()
        {
            List<String[]> unavailabiltyTimes = new List<String[]>();
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                try
                {
                    conn.Open();
                    string cmdText = $"SELECT * FROM CarUnavailabiltyTable WHERE  CarId = '{CarId}' ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        String[] unavailabiltyTime = new String[4];
                        unavailabiltyTime[0] = reader["StartTime"].ToString().Trim();
                        unavailabiltyTime[1] = reader["EndTime"].ToString().Trim();
                        unavailabiltyTime[2] = reader["CarUnavailabiltyId"].ToString().Trim();
                        unavailabiltyTime[3] = reader["Description"].ToString().Trim();
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
        int Number_Of_Events_On_Day(DateTime[][] eventTimes , DateTime date)
        {
            int number = 0;
            DateTime startOfDay = date.Date;
            DateTime endOfDay = date.Date.AddDays(1);
            for(int i = 0;i < eventTimes.Length; i++)
            {
                bool eventForThisDay = false; //so a event that starts and ends on the same day is only counted once
                if( (startOfDay <= eventTimes[i][0] && eventTimes[i][0] <= endOfDay) || (eventTimes[i][0] <= startOfDay && startOfDay <= eventTimes[i][1]))
                {
                    eventForThisDay = true;
                }
                if ( ( startOfDay <= eventTimes[i][1] && eventTimes[i][1] <= endOfDay) || (eventTimes[i][0] <= endOfDay && endOfDay <=  eventTimes[i][1]))
                {
                    eventForThisDay = true;
                }

                if (eventForThisDay)
                {
                    number += 1;
                }
            }
            return number;
        }

        private void Event_1_PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Event_2_PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Event_3_PictureBox_Click(object sender, EventArgs e)
        {

        }
        private void Date_Selected(object sender, EventArgs e)
        {
            Unselect_Date();
            FlowLayoutPanel date = (FlowLayoutPanel)sender;
            foreach (Control control in date.Controls)
            {
                if(control.BackColor == date.BackColor)
                {
                    control.BackColor = Color.Silver;
                }

                if (control.Name == "Day_Label")
                {

                    int day = Convert.ToInt32(control.Text);
                    int month = Get_Index_Of_Month(Month_Label.Text) +1;

                    if(control.BackColor == Color.DarkGray) //is darkened as so of a diffferent month
                    {
                        if(day >= 15)
                        {
                            month--;
                        }
                        else
                        {
                            month++;
                        }
                    }

                    if(month < 1)
                    {
                        month = 12;
                    }
                    else if (month > 12)
                    {
                        month = 1;
                    }
                    int year = Convert.ToInt32(Year_Label.Text);
                    SelectedDate = Convert.ToDateTime($"{year}/{month}/{day}");
                }
            }
            date.BackColor = Color.Silver;

            Show_Events_For_Day();

        }
        void Unselect_Date()
        {
            Events_FlowPanel.Controls.Clear();
            foreach (FlowLayoutPanel date in Calendar_FlowPanel.Controls)
            {
                foreach (Control control in date.Controls)
                {
                    if (control.BackColor == date.BackColor)
                    {
                        control.BackColor = Calendar_FlowPanel.BackColor;
                    }
                }
                date.BackColor = Calendar_FlowPanel.BackColor;
            }
        }
        private void Date_Selected_Child(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Date_Selected(control.Parent, EventArgs.Empty);
        }

        private void Car_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Calendar();
        }
        void Show_Events_For_Day()
        {
            Events_FlowPanel.Controls.Clear();
            String[][] carUnavailabilty = Get_Car_Unavailabilty();
            String[][] eventsOnDate = Filter_Unavailabilty_By_Date(SelectedDate.Value, carUnavailabilty);
            Started_Label.Visible = false;
            for(int i = 0; i < eventsOnDate.Length;i++)
            {
                Label eventLabel = new Label();
                eventLabel.Text = eventsOnDate[i][3] + ":";
                eventLabel.Size = Started_Label.Size;
                eventLabel.Font = Started_Label.Font;
                Events_FlowPanel.Controls.Add(eventLabel);

                Label startLabel = new Label();
                startLabel.Text = "Start: " + Globals.removeSeconds(eventsOnDate[i][0]);
                startLabel.Size = Started_Label.Size;
                startLabel.Font = Started_Label.Font;
                Events_FlowPanel.Controls.Add(startLabel);

                Label endLabel = new Label();
                endLabel.Text = "End: " + Globals.removeSeconds(eventsOnDate[i][1]);
                endLabel.Size = new Size(Started_Label.Size.Width,Started_Label.Size.Height * 2);
                endLabel.Font = Started_Label.Font;
                Events_FlowPanel.Controls.Add(endLabel);
            }
        }
        String[][] Filter_Unavailabilty_By_Date(DateTime date,String[][] carUnavailabilty)
        {
            DateTime startDate = date.Date;
            DateTime endDate = startDate.AddDays(1);
            List<String[]> filteredTimes = new List<String[]>();
            for(int i =0;i< carUnavailabilty.Length;i++)
            {
                DateTime unavailabiltyStartTime = Convert.ToDateTime(carUnavailabilty[i][0]);
                DateTime unavailabiltyEndTime = Convert.ToDateTime(carUnavailabilty[i][1]);
                bool includeTime = false;
                if (startDate <= unavailabiltyStartTime && unavailabiltyStartTime < endDate || unavailabiltyStartTime <= startDate && startDate < unavailabiltyEndTime)
                {
                    includeTime = true;
                }
                if (unavailabiltyEndTime >= startDate && unavailabiltyEndTime < endDate || unavailabiltyStartTime <= endDate && endDate < unavailabiltyEndTime)
                {
                    includeTime = true;
                }
                if(includeTime)
                {
                    filteredTimes.Add(carUnavailabilty[i]);
                }
            }
            return filteredTimes.ToArray();
        }

        private void Car_DropDown_Click(object sender, EventArgs e)
        {
            Car_Picker();
        }
        void Car_Picker()
        {
            try
            {
                PickerForm carPicker = new PickerForm() { Table = "Cars" };
                carPicker.ShowDialog();
                if (carPicker.DialogResult == DialogResult.OK)
                {
                    CarId = carPicker.SelectedId;
                    Load_Car();
                }
            }
            catch
            {
                MessageBox.Show("Car not selected");
            }
        }

        private void Car_TextBox_Click(object sender, EventArgs e)
        {
            Car_Picker();
        }
        void Load_Car()
        {
            try
            {
                string[] values = SQL_Operation.ReadEntry((int)CarId, "CarId", "CarTable");
                Car_TextBox.Text = Globals.getYear(values[4]) + " " + values[1] + " " + values[2];
                Registration_Label.Text = "Registration: " + values[3];
                Mileage_Label.Text = "Mileage: " + Globals.addCommaToNumber(values[5]) +"km";
                Bodystyle_Label.Text = "Body Style: " + values[11];
                Colour_Label.Text = "Colour: " + values[10];
                NoOfSeats_Label.Text = "Number of seats: " + values[12];
                Transmission_Label.Text = "Transmission: " + values[6];
                FuelType_Label.Text = "Fuel Type: " + values[7];
                Engine_Size_Label.Text = "Engine Size: " + values[8] + "l";
                Power_Label.Text = "Power: " + values[9] + "hp";
                Load_Calendar();
            }
            catch
            {
                MessageBox.Show("An error occured when reading car information");
            }
        }

        private void Car_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
