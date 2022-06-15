using System;

namespace AddressBook.Model
{
    /// <summary>
    /// Описывает контакт.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Имя контакта.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия контакта.
        /// </summary>
        private string _sername;

        /// <summary>
        /// Отчество контакта.
        /// </summary>
        private string _patronymic;

        /// <summary>
        /// ID контакта.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Возвращает и задаёт имя.
        /// </summary>
        public string Name 
        {
            get => _name;

            set 
            {
                if (!isValidated(value)) 
                {
                    /*Нужно перед этим ещё один MessageBox вопросительный: "дуюспикинглишь?"*/
                    throw new ArgumentException("Name must be between 2 and 50 characters");
                }
                _name = value;
            } 
        }

        /// <summary>
        /// Возвращает и задаёт фамилию.
        /// </summary>
        public string Surname 
        {
            get => _sername;

            set
            {
                if (!isValidated(value))
                {
                    throw new ArgumentException("Sername must be between 2 and 50 characters");
                }
                _sername = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт отчество.
        /// </summary>
        public string Patronymic 
        {
            get => _patronymic;

            set
            {
                if (!isValidated(value))
                {
                    /*И тут Вася начинет гуглить, что же такое patronymic...
                     *Если умеет, конечно же*/

                    throw new ArgumentException("Patronymic must be between 2 and 50 characters"); /* бывает, что у кого-то нет отчества,
                                                                                                      плюс в задаче сказано только про имя/фамилию*/
                }
                _patronymic = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер телефона
        /// </summary>
        public PhoneNumber Number { get; set; }

        /// <summary>
        /// Проверяет строку на соответствие формату.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true - строка подходит по требованиям, false - строка не прошла проверку.</returns>
        private bool isValidated(string str) 
        {
            // можно проще:
            return str.Length >= 2 && str.Length <= 50;
            // Но, если где-то str станет null, то вывалится Exception. Что увидит пользователь?

            /* if (str.Length >= 2 && str.Length <= 50) 
             {
                 return true;
             }
             return false;*/
        }
    }
}
