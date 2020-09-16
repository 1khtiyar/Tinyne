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
    internal class StorageIOService
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
            using (var reader=File.Open(PATH,FileMode.OpenOrCreate))
            {
                StorageData data;
                try
                { 
                    data=(StorageData)serializer.Deserialize(reader);
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

        private async void SaveDataDirectly(StorageData data)
        {
            await Task.Run(() =>
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StorageData));
                using (var reader = File.Open(PATH, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(reader, data);
                }
            });
        }
    }
}
