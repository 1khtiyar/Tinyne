using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using TinyneProject.Models;

namespace TinyneProject.Services
{
    public class StorageIOService
    {
        readonly string PATH;
        const string Extension = "tdsf";
        const string FileName = "data";

        public StorageIOService()
        {
            PATH = $"{ Environment.CurrentDirectory}\\{FileName}.{Extension}";
        }


        public StorageData Load()
        {
            return LoadDataDirectly();
        }

        private StorageData LoadDataDirectly()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StorageData));
            using (var reader = File.Open(PATH, FileMode.OpenOrCreate))
            {
                StorageData data;
                try
                {
                    data = (StorageData)serializer.Deserialize(reader);
                }
                catch
                {
                    data = new StorageData();
                }
                return data;
            }
        }


        public void Save(StorageData data)
        {
            SaveDataDirectly(data);
        }

        private void SaveDataDirectly(StorageData data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StorageData));
            using (var reader = File.Open(PATH, FileMode.Open))
            {
                serializer.Serialize(reader, data);
            }
        }
    }
}
