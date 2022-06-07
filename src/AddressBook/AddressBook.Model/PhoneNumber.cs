using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBook.Model
{
    public class PhoneNumber
    {
        private ulong _number;

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

        public PhoneNumber(ulong number) 
        {
            Number = number;
        }

        public PhoneNumber() 
        {
            
        }

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
