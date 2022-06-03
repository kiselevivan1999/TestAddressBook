using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace AddressBook.Model
{
    public static class ProjectSerializer
    {
        private static readonly string _fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AddressBook\userdata.xml";

        private static XmlDocument xmlDoc = new XmlDocument();

        public static void SaveToFile(Contact contact) 
        {
            CreateFile();

            XmlElement newElem = xmlDoc.CreateElement("price");
            newElem.InnerText = "10.95";
            xmlDoc.DocumentElement.AppendChild(newElem);


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            
            XmlWriter writer = XmlWriter.Create("data.xml", settings);
            xmlDoc.Save(writer);

        }

        public static Contact LoadFromFile()
        {
            CreateFile();

            return null;
        }


        private static void CreateFile() 
        {
            if (File.Exists(_fileName)) 
            {
                return;
            }

            Directory.CreateDirectory(_fileName.Replace("\\user.xml", ""));

            using (FileStream fs = File.Create(_fileName)) 
            {
                fs.Dispose();
            }
        }
    }
}
