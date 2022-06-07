using System;
using System.Text.RegularExpressions;

namespace AddressBook.Model
{
    /// <summary>
    /// Описание номера телефона.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телфона.
        /// </summary>
        private ulong _number;

        /// <summary>
        /// Возвращает и задаёт номер телфона.
        /// </summary>
        public ulong Number 
        { 
            get { return _number; } 
            
            set 
            {
                string strNumber = Regex.Replace(value.ToString(), "[^0-9]", "");

                if (!isValidated(strNumber)) 
                {
                    throw new ArgumentException("Номер должен начинаться с 7 или 8 и содержать 11 цифр");
                }
                _number = ulong.Parse(strNumber); 
            } 
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="PhoneNumber"/>
        /// </summary>
        /// <param name="number"></param>
        public PhoneNumber(ulong number) 
        {
            Number = number;
        }

        /// <summary>
        /// Создаёт пустой экземпляр класса.
        /// </summary>
        public PhoneNumber() 
        {
         //без него не работает сохранение даных в файл (класс ProjectSerializer).   
        }

        /// <summary>
        /// Проверяет номер на соответствие необходимому формату.
        /// </summary>
        /// <param name="number">Проверяемый номер.</param>
        /// <returns>true - номер соответствует, false - номер не соответствует.</returns>
        private bool isValidated(string number)
        { 
            var regex = new Regex("^(7|8)[0-9]{10}$");

            return regex.IsMatch(number);
        }

        public override string ToString()
        {
            string number = Number.ToString();
            number = number.Length == 12 ? number.Substring(2) : number.Substring(1);

            return string.Format("8 ({0}) {1}-{2} {3}", number.Substring(0, 3),
                number.Substring(3, 3), number.Substring(6, 2), number.Substring(8, 2));
        }
    }
}
