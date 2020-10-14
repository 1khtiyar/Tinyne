using System;
using System.IO;
using System.Xml.Serialization;

using TinyneProject.Models;

namespace TinyneProject.Services
{
    public class StorageIOService
    {
        private readonly string PATH;
        private const string Extension = "tdsf";
        private const string FileName = "data";

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
            File.Delete(PATH);

            using (var reader = File.Open(PATH, FileMode.OpenOrCreate))
            {
                serializer.Serialize(reader, data);
            }
        }
    }
}
