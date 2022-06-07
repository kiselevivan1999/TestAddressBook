using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AddressBook.Model
{
    public static class ProjectSerializer
    {

        private static readonly string _fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AddressBook\userdata.xml";

        public static void SaveToFile(List <Contact> contacts) 
        {
            CreateFile();

            var serializer = new XmlSerializer(typeof(List<Contact>));

            using (var sw = new StreamWriter(_fileName)) 
            {
                serializer.Serialize(sw, contacts);
            }
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

            Directory.CreateDirectory(_fileName.Replace("\\userdata.xml", ""));

            using (FileStream fs = File.Create(_fileName)) 
            {
                fs.Dispose();
            }
        }
    }
}
