namespace syslib32
{
    using System;

    public static class GetSetResolution
    {
        private static readonly double W = System.Windows.SystemParameters.PrimaryScreenWidth;
        private static readonly double H = System.Windows.SystemParameters.PrimaryScreenHeight;

        public static void SaveData()
        {
            System.Collections.Hashtable addresses = new System.Collections.Hashtable {
                {GetSetResolution.W, GetSetResolution.H},
            };
            const string path = @"C:\Program Files\SysInfo\data\";
            if (!System.IO.Directory.Exists(@"C:\Program Files\SysInfo\data\"))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            using (
                System.IO.FileStream fs = new System.IO.FileStream($@"{path}\resolution.dat", System.IO.FileMode.Create)
                )
            {
                try
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(fs, addresses);
                }
                catch (System.Runtime.Serialization.SerializationException e)
                {
                    System.Windows.MessageBox.Show("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        public static void LoadData()
        {
            DEVMODE vDevMode = new DEVMODE();
            System.Collections.Hashtable addresses;
            const string path = @"C:\Program Files\SysInfo\data\";
            System.IO.FileStream fs = new System.IO.FileStream($@"{path}\resolution.dat", System.IO.FileMode.Open);
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                addresses = (System.Collections.Hashtable)formatter.Deserialize(fs);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                System.Windows.MessageBox.Show("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            foreach (System.Collections.DictionaryEntry de in addresses)
            {
                CResolution.ChangeRes(Convert.ToInt32(de.Key), Convert.ToInt32(de.Value),
                    (int)vDevMode.dmDisplayFrequency);
            }
        }
    }
}