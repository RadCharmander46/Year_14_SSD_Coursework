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
            Globals.settings.Set_Test_Drive_Cost(1, Day_Cost_NumericUpDown.Value);
            Globals.settings.Save();
        }
    }
}
