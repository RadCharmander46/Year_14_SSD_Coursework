using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Year_14_CA_SSD
{
    public partial class ManagerSettingsForm : Form
    {
        public event EventHandler Back;
        public ManagerSettingsForm()
        {
            InitializeComponent();
        }

        private void Apply_Button_Click(object sender, EventArgs e)
        {
            if (Monday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(0, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:ss"));
                Globals.settings.Set_Closing_Time(0, new DateTime(1, 1, 1, 1, 0, 0).ToString("HH:ss"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(0, Monday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(0, Monday_Closing_TimePicker.Value.ToString("HH:mm"));
            }

            if(Tuesday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(1, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(1, new DateTime(1, 1, 1, 1, 1, 0).ToString("HH:mm"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(1, Tuesday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(1, Tuesday_Closing_TimePicker.Value.ToString("HH:mm"));
            }

            if (Wednesday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(2, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(2, new DateTime(1, 1, 1, 1, 1, 0).ToString("HH:mm"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(2, Wednesday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(2, Wednesday_Closing_TimePicker.Value.ToString("HH:mm"));
            }

            if (Thursday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(3, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(3, new DateTime(1, 1, 1, 1, 1, 0).ToString("HH:mm"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(3, Thursday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(3, Thursday_Closing_TimePicker.Value.ToString("HH:mm"));
            }

            if (Friday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(4, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(4, new DateTime(1, 1, 1, 1, 1, 0).ToString("HH:mm"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(4, Friday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(4, Friday_Closing_TimePicker.Value.ToString("HH:mm"));
            }

            if (Saturday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(5, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(5, new DateTime(1, 1, 1, 1, 1, 0).ToString("HH:mm"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(5, Saturday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(5, Saturday_Closing_TimePicker.Value.ToString("HH:mm"));
            }

            if (Sunday_Closed_CheckBox.Checked)
            {
                Globals.settings.Set_Opening_Time(6, new DateTime(1, 1, 1, 23, 59, 59).ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(6, new DateTime(1, 1, 1, 1, 1, 0).ToString("HH:mm"));
            }
            else
            {
                Globals.settings.Set_Opening_Time(6, Sunday_Opening_TimePicker.Value.ToString("HH:mm"));
                Globals.settings.Set_Closing_Time(6, Sunday_Closing_TimePicker.Value.ToString("HH:mm"));
            }



            Globals.settings.TestDriveCancelNotice = new TimeSpan((int)Cancel_Days_NumericUpDown.Value,0,0,0);
            Globals.settings.CleaningTimeBetweeenTestDrives = new TimeSpan((int)Cleaning_Time_NumericUpDown.Value, 0, 0);
            Globals.settings.MinTestDriveAge = (int)Min_Age_NumericUpDown.Value;

            Globals.settings.Set_Test_Drive_Cost(0, Half_Hour_Cost_NumericUpDown.Value);
            Globals.settings.Set_Test_Drive_Cost(1, Day_Cost_NumericUpDown.Value);
            Globals.settings.Set_Test_Drive_Cost(2, Weekend_Cost_NumericUpDown.Value);
            Globals.settings.PreviousCustDiscount = (int)Discount_NumericUpDown.Value;
            Globals.settings.LicenseExpiryAdvance = new TimeSpan((int)Expiry_Notice_NumericUpDown.Value,0,0,0);
            Globals.settings.DepositPercent = (int)Deposit_Percent_NumericUpDown.Value;

            Globals.settings.Set_Mileage_Limit(0, (int)Half_Hour_Mileage_NumericUpDown.Value);
            Globals.settings.Set_Mileage_Limit(1, (int)Day_Mileage_NumericUpDown.Value);
            Globals.settings.Set_Mileage_Limit(2, (int)Weekend_Mileage_NumericUpDown.Value);
            Globals.settings.MileageFee = Mileage_Fee_NumericUpDown.Value;

            Globals.settings.LateFee = Late_Fee_NumericUpDown.Value;
            Globals.settings.TimeBeforeLate = new TimeSpan((int)Hours_Before_Late_NumericUpDown.Value, 0, 0);

            Globals.settings.Save();

            if (Back != null)
            {
                Back.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }

        private void ManagerSettingsForm_Load(object sender, EventArgs e)
        {
            if(DayIsClosed(0))
            {
                Monday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Monday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[0]);
                Monday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[0]);
            }

            if (DayIsClosed(1))
            {
                Tuesday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Tuesday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[1]);
                Tuesday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[1]);
            }

            if (DayIsClosed(2))
            {
                Wednesday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Wednesday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[2]);
                Wednesday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[2]);
            }

            if (DayIsClosed(3))
            {
                Thursday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Thursday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[3]);
                Thursday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[3]);
            }

            if (DayIsClosed(4))
            {
                Friday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Friday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[4]);
                Friday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[4]);
            }

            if (DayIsClosed(5))
            {
                Saturday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Saturday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[5]);
                Saturday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[5]);
            }

            if (DayIsClosed(6))
            {
                Sunday_Closed_CheckBox.Checked = true;
            }
            else
            {
                Sunday_Opening_TimePicker.Value = Convert.ToDateTime(Globals.settings.OpenningTimes[6]);
                Sunday_Closing_TimePicker.Value = Convert.ToDateTime(Globals.settings.ClosingTimes[6]);
            }
            Cancel_Days_NumericUpDown.Value = Globals.settings.TestDriveCancelNotice.Days;
            Min_Age_NumericUpDown.Value = Globals.settings.MinTestDriveAge;
            Cleaning_Time_NumericUpDown.Value = Globals.settings.CleaningTimeBetweeenTestDrives.Hours;

            Half_Hour_Cost_NumericUpDown.Value = Globals.settings.TestDriveCosts[0];
            Day_Cost_NumericUpDown.Value = Globals.settings.TestDriveCosts[1];
            Weekend_Cost_NumericUpDown.Value = Globals.settings.TestDriveCosts[2];
            Discount_NumericUpDown.Value = Globals.settings.PreviousCustDiscount;

            Half_Hour_Mileage_NumericUpDown.Value = Globals.settings.MileageLimits[0];
            Day_Mileage_NumericUpDown.Value = Globals.settings.MileageLimits[1];
            Weekend_Mileage_NumericUpDown.Value = Globals.settings.MileageLimits[2];
            Mileage_Fee_NumericUpDown.Value = Globals.settings.MileageFee;
        }
        bool DayIsClosed(int day)
        {
            if(Convert.ToDateTime(Globals.settings.OpenningTimes[day]) > Convert.ToDateTime(Globals.settings.ClosingTimes[day]))
            {
                return true;
            }
            return false;
        }

        private void Default_Button_Click(object sender, EventArgs e)
        {
            Monday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 7, 0, 0);
            Monday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 18, 0, 0);
            Tuesday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 7, 0, 0);
            Tuesday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 18, 0, 0);
            Wednesday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 7, 0, 0);
            Wednesday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 18, 0, 0);
            Thursday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 7, 0, 0);
            Thursday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 18, 0, 0);
            Friday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 7, 0, 0);
            Friday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 18, 0, 0);
            Saturday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 7, 0, 0);
            Saturday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 20, 0, 0);
            Sunday_Opening_TimePicker.Value = new DateTime(1970, 1, 1, 9, 0, 0);
            Sunday_Closing_TimePicker.Value = new DateTime(1970, 1, 1, 15, 0, 0);
            Monday_Closed_CheckBox.Checked = false;
            Tuesday_Closed_CheckBox.Checked = false;
            Wednesday_Closed_CheckBox.Checked = false;
            Thursday_Closed_CheckBox.Checked = false;
            Friday_Closed_CheckBox.Checked = false;
            Saturday_Closed_CheckBox.Checked = false;
            Sunday_Closed_CheckBox.Checked = false;


            Cancel_Days_NumericUpDown.Value = 1;
            Min_Age_NumericUpDown.Value = 18;
            Cleaning_Time_NumericUpDown.Value = 4;
            Expiry_Notice_NumericUpDown.Value = 30;
            Deposit_Percent_NumericUpDown.Value = 10;
            Half_Hour_Cost_NumericUpDown.Value = 0;
            Day_Cost_NumericUpDown.Value = 80;
            Weekend_Cost_NumericUpDown.Value = 175;
            Discount_NumericUpDown.Value = 15;

            Half_Hour_Mileage_NumericUpDown.Value = 0;
            Day_Mileage_NumericUpDown.Value = 100;
            Weekend_Mileage_NumericUpDown.Value = 200;
            Mileage_Fee_NumericUpDown.Value = 0.5M;

            Late_Fee_NumericUpDown.Value = 5;
            Hours_Before_Late_NumericUpDown.Value = 2;
        }

        private void Monday_Closed_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Monday_Closed_CheckBox.Checked)
            {
                Monday_Opening_TimePicker.Enabled = false;
                Monday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Monday_Opening_TimePicker.Enabled = true;
                Monday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Tuesday_Closed_TextBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Tuesday_Closed_CheckBox.Checked)
            {
                Tuesday_Opening_TimePicker.Enabled = false;
                Tuesday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Tuesday_Opening_TimePicker.Enabled = true;
                Tuesday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Wednesday_Closed_TextBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Wednesday_Closed_CheckBox.Checked)
            {
                Wednesday_Opening_TimePicker.Enabled = false;
                Wednesday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Wednesday_Opening_TimePicker.Enabled = true;
                Wednesday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Thursday_Closed_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Thursday_Closed_CheckBox.Checked)
            {
                Thursday_Opening_TimePicker.Enabled = false;
                Thursday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Thursday_Opening_TimePicker.Enabled = true;
                Thursday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Friday_Closed_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Friday_Closed_CheckBox.Checked)
            {
                Friday_Opening_TimePicker.Enabled = false;
                Friday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Friday_Opening_TimePicker.Enabled = true;
                Friday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Saturday_Closed_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Saturday_Closed_CheckBox.Checked)
            {
                Saturday_Opening_TimePicker.Enabled = false;
                Saturday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Saturday_Opening_TimePicker.Enabled = true;
                Saturday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Sunday_Closed_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Sunday_Closed_CheckBox.Checked)
            {
                Sunday_Opening_TimePicker.Enabled = false;
                Sunday_Closing_TimePicker.Enabled = false;
            }
            else
            {
                Sunday_Opening_TimePicker.Enabled = true;
                Sunday_Closing_TimePicker.Enabled = true;
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            if(Back != null)
            {
                Back.Invoke(this, EventArgs.Empty);
            }
            this.Close();
        }
    }
}
