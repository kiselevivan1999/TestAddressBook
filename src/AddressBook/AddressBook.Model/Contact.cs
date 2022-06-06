using System;

namespace AddressBook.Model
{
    public class Contact
    {

        private string _name;

        private string _sername;

        private string _patronymic;

        public int Id { get; set; }
        
        public string Name 
        {
            get => _name;

            set 
            {
                if (!isCorrectLenght(value)) 
                {
                    throw new ArgumentException("Name must be between 2 and 50 characters");
                }
            } 
        }

        public string Surname 
        {
            get => _sername;

            set
            {
                if (!isCorrectLenght(value))
                {
                    throw new ArgumentException("Sername must be between 2 and 50 characters");
                }
            }
        }

        public string Patronymic 
        {
            get => _patronymic;

            set
            {
                if (!isCorrectLenght(value))
                {
                    throw new ArgumentException("Patronymic must be between 2 and 50 characters");
                }
            }
        }

        public PhoneNumber Number { get; set; }


        private bool isCorrectLenght(string str) 
        {
            if (str.Length >= 2 && str.Length <= 50) 
            {
                return true;
            }
            return false;
        }
    }
}
