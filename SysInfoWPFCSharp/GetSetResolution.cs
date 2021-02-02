using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using static SysInfo.CResolution;
using static System.Windows.MessageBox;

namespace SysInfo
{
    internal static class GetSetResolution
    {
        private static readonly double _w = SystemParameters.PrimaryScreenWidth;
        private static readonly double _h = SystemParameters.PrimaryScreenHeight;

        internal static void SaveData()
        {
            Hashtable addresses = new Hashtable { { _w, _h } };
            string path = @"C:\Program Files\SysInfo\data\";
            Directory.CreateDirectory(path);
            using (FileStream fs = new FileStream(path: $@"{path}\resolution.dat", mode: FileMode.Create))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, addresses);
                }
                catch (SerializationException e)
                {
                    Show("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        internal static void LoadData()
        {
            DEVMODE vDevMode = new DEVMODE();
            Hashtable addresses;
            string path = @"C:\Program Files\SysInfo\data\";
            FileStream fs = new FileStream($@"{path}\resolution.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                addresses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Show("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            foreach (DictionaryEntry de in addresses)
            {
                ChangeRes(Convert.ToInt32(de.Key), Convert.ToInt32(de.Value), (int)vDevMode.dmDisplayFrequency);
            }
        }
    }
}