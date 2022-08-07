using System.ComponentModel;
using System.Runtime.CompilerServices;
using AddressBook.Model;

namespace AddressBook.ViewModel
{
    public class ContactVM : INotifyPropertyChanged
    {
        private Contact contact;

        public ContactVM(Contact c)
        {
            contact = c;
        }

        public int Id
        {
            get { return contact.Id; }
            set
            {
                contact.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Surname
        {
            get { return contact.Surname; }
            set
            {
                contact.Surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Name
        {
            get { return contact.Name; }
            set
            {
                contact.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Patronymic
        {
            get { return contact.Patronymic; }
            set
            {
                contact.Patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        public string Number
        {
            get { return contact.Phone.ToString(); }
            set
            {
                contact.Phone = new PhoneNumber(value);
                OnPropertyChanged("PhoneNumber");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}