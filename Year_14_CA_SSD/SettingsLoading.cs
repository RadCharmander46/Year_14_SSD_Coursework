using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;

namespace Year_14_CA_SSD
{
    static class SettingsLoading
    {
        static IFormatter Serialiser = new BinaryFormatter();
        static IFormatter DeSerialiser = new BinaryFormatter();
        public const string SettingsFilePath = "../../Settings/Settings.Dat";
        public static void Save_Settings(Settings settings)
        {
            if (File.Exists(SettingsFilePath))
            {
                File.Delete(SettingsFilePath);
            }
            using (Stream FileStream = File.Open(SettingsFilePath, FileMode.Create))
            {
                Serialiser.Serialize(FileStream, settings);
            }
        }
        public static Settings Load_Settings()
        {
            if (File.Exists(SettingsFilePath))
            {
                using (Stream FileStream = File.Open(SettingsFilePath, FileMode.Open))
                {
                    return (Settings)DeSerialiser.Deserialize(FileStream);
                }
            }
            else
            {
                return new Settings();
            }
        }
    }
}
