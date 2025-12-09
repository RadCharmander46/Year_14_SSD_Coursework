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
        public ManagerSettingsForm()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Apply_Button_Click(object sender, EventArgs e)
        {
            Globals.settings.Set_Opening_Time(0, Monday_Opening_TimePicker.Text);
            Globals.settings.Set_Opening_Time(1, Tuesday_Opening_TimePicker.Text);
            Globals.settings.Set_Opening_Time(2, Wednesday_Opening_TimePicker.Text);
            Globals.settings.Set_Opening_Time(3, Thursday_Opening_TimePicker.Text);
            Globals.settings.Set_Opening_Time(4, Friday_Opening_TimePicker.Text);
            Globals.settings.Set_Opening_Time(5, Saturday_Opening_TimePicker.Text);
            Globals.settings.Set_Opening_Time(6, Sunday_Opening_TimePicker.Text);

            Globals.settings.Set_Closing_Time(0, Monday_Closing_TimePicker.Text);
            Globals.settings.Set_Closing_Time(1, Tuesday_Closing_TimePicker.Text);
            Globals.settings.Set_Closing_Time(2, Wednesday_Closing_TimePicker.Text);
            Globals.settings.Set_Closing_Time(3, Thursday_Closing_TimePicker.Text);
            Globals.settings.Set_Closing_Time(4, Friday_Closing_TimePicker.Text);
            Globals.settings.Set_Closing_Time(5, Saturday_Closing_TimePicker.Text);
            Globals.settings.Set_Closing_Time(6, Sunday_Closing_TimePicker.Text);

            Globals.settings.TestDriveCancelNotice = new TimeSpan((int)Cancel_Days_NumericUpDown.Value,0,0,0);
            Globals.settings.MinTestDriveAge = (int)Min_Age_NumericUpDown.Value;

            Globals.settings.Set_Test_Drive_Cost(0, Half_Hour_Cost_NumericUpDown.Value);
            Globals.settings.Set_Test_Drive_Cost(1, Day_Cost_NumericUpDown.Value);
            Globals.settings.Set_Test_Drive_Cost(2, Weekend_Cost_NumericUpDown.Value);
            Globals.settings.PreviousCustDiscount = (int)Discount_NumericUpDown.Value;

            Globals.settings.Set_Mileage_Limit(0, (int)Half_Hour_Mileage_NumericUpDown.Value);
            Globals.settings.Set_Mileage_Limit(1, (int)Day_Mileage_NumericUpDown.Value);
            Globals.settings.Set_Mileage_Limit(2, (int)Weekend_Mileage_NumericUpDown.Value);
            Globals.settings.MileageFee = Mileage_Fee_NumericUpDown.Value;

            Globals.settings.Save();
        }

        private void Half_Hour_Cost_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Tuesday_TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
