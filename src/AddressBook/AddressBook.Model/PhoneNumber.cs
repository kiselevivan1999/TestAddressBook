using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBook.Model
{
    internal class PhoneNumber
    {
        private string _number;

        public string Number 
        { 
            get { return _number; } 
            
            set 
            {
                if (!isValidated(value)) 
                {
                    throw new ArgumentException("Номер должен начинаться с 7 или 8 и содержать 11 цифр");
                }
                _number = FormatNumber(value); 
            } 
        }

        private bool isValidated(string number)
        {
            number = Regex.Replace(number, "[^0-9]", "");

            var regex = new Regex("^8|7[0-9]{10}");

            return regex.IsMatch(number);
        }

        private string FormatNumber(string number) 
        {
            number = number.Length == 12 ? number.Substring(2) : number.Substring(1);
         
            return string.Format("8 ({0}) {1}-{2} {3}", number.Substring(0, 2), 
                number.Substring(3, 5), number.Substring(6, 7), number.Substring(8, 9));
        }
    }
}
