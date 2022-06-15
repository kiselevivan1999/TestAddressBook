using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AddressBook.Model
{
    /// <summary>
    /// Описывает класс работы с файлом.
    /// </summary>
    public static class ProjectSerializer
    {
        /// <summary>
        /// Полный путь до файла, куда будут сохранятся пользователькие данные.
        /// </summary>
        private static readonly string _fileName = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AddressBook\userdata.xml";

        /// <summary>
        /// Сохранение контактов в файл.
        /// </summary>
        /// <param name="contacts">Список контактов.</param>
        public static void SaveToFile(List <Contact> contacts) 
        {
            CreateFile();

            var serializer = new XmlSerializer(typeof(List<Contact>));

            using (var sw = new StreamWriter(_fileName)) 
            {
                serializer.Serialize(sw, contacts);
            }
        }

        /// <summary>
        /// Выгрузка данных из файла.
        /// </summary>
        /// <returns></returns>
        public static List<Contact> LoadFromFile()
        {
            CreateFile();
            /*в этом юзинге же ты нигде не диспозишь fs, почему тогда в CreateFile это делаешь?*/
            using (var fs = new FileStream(_fileName, FileMode.Open))
            {
                var xtr = new XmlTextReader(fs); // а почему ридер не через using?
                var serializer = new XmlSerializer(typeof(List<Contact>));
                var contacts = new List<Contact>();
                
                try
                {
                    contacts = (List<Contact>)serializer.Deserialize(xtr);
                }
                catch(InvalidOperationException) 
                {
                    return contacts; // а смысл тут возвращать, когда после try/catch всё равно та же коллекция возвращается?
                }

                return contacts; 
            }
        }

        /// <summary>
        /// Создание полного пути вместе с файлом. 
        /// </summary>
        private static void CreateFile() 
        {
            if (File.Exists(_fileName)) 
            {
                return;
            }

            Directory.CreateDirectory(_fileName.Replace("\\userdata.xml", ""));

            using (FileStream fs = File.Create(_fileName)) 
            {
                fs.Dispose(); // почитай, вспомни, зачем нужны using
            }
        }
    }
}
