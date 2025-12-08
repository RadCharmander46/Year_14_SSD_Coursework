using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year_14_CA_SSD
{
    [Serializable]
    class Settings
    {
        private string[] openningTimes = { "7:00", "7:00", "7:00", "7:00", "7:00", "7:00", "9:00" };
        private string[] closingTimes = { "18:00", "18:00", "18:00", "18:00", "18:00", "20:00", "15:00" };
        private TimeSpan testDriveCancelNotice = new TimeSpan(24, 0, 0);
        private int minTestDriveAge = 18;
        private int[] mileageLimits = { 0, 100, 200 };
        private decimal mileageFee = 0.5M;
        private decimal[] testDriveCosts = { 0, 80, 175 };
        private int previousCustDiscount = 15;

        public string[] OpenningTimes
        {
            get { return openningTimes; }
            set { openningTimes = value; }
        }
        public string[] ClosingTimes
        {
            get { return closingTimes; }
            set { closingTimes = value; }
        }
        public TimeSpan TestDriveCancelNotice
        {
            get { return testDriveCancelNotice; }
            set { testDriveCancelNotice = value; }
        }
        public int MinTestDriveAge
        {
            get { return minTestDriveAge; }
            set { minTestDriveAge = value; }
        }
        public int[] MileageLimits
        {
            get { return mileageLimits; }
            set { mileageLimits = value; }
        }
        public decimal MileageFee
        { 
            get { return mileageFee; }
            set { mileageFee = value; }
        }
        public decimal[] TestDriveCosts
        {
            get { return testDriveCosts; }
            set { testDriveCosts = value; }
        }
        public int PreviousCustDiscount
        {
            get { return previousCustDiscount; }
            set
            {
                if(value >= 0 && value <= 100)
                {
                    previousCustDiscount = value;
                }
                else
                {
                    throw new SettingsException("Previous Customer Discount is not a percent value (in the range 0 - 100)");
                }
            }
        }
        public void Set_Openning_Time(int day,string time)
        {
            this.openningTimes[day] = time;
        }
        public void Set_Closing_Time (int day, string time)
        {
            this.closingTimes[day] = time;
        }
        public void Set_Mileage_Limit(int testDriveType,int limit)
        {
            this.mileageLimits[testDriveType] = limit;
        }
        public void Set_Test_Drive_Cost(int testDriveType,decimal testDriveCost)
        {
            this.testDriveCosts[testDriveType] = testDriveCost;
        }
        public Settings()
        {

        }
        public Settings(string[] iOpenningTimes,string[] iClosingTimes, TimeSpan iTestDriveCancelNotice,int iMinTestDriveAge,int[] iMileageLimits,decimal iMileageFee,decimal[] iTestDriveCosts,int iPreviousCustDiscount)
        {
            this.OpenningTimes = iOpenningTimes;
            this.ClosingTimes = iClosingTimes;
            this.TestDriveCancelNotice = iTestDriveCancelNotice;
            this.MinTestDriveAge = iMinTestDriveAge;
            this.MileageLimits = iMileageLimits;
            this.MileageFee = iMileageFee;
            this.TestDriveCosts = iTestDriveCosts;
            this.PreviousCustDiscount = iPreviousCustDiscount;
        }
        public void Save()
        {
            SettingsLoading.Save_Settings(this);
        }
    }
    [Serializable]
    class SettingsException : Exception
    {
        public SettingsException() { }
        public SettingsException(string Message) : base(Message) { }
    }
}
