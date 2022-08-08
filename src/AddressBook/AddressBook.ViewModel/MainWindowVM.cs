using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AddressBook.Model;

namespace AddressBook.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Contact _selectedContact = new Contact();

        public MainWindowVM()
        {
            //Contacts = new ObservableCollection<Contact>(ProjectSerializer.LoadFromFile());
            Contacts = new ObservableCollection<Contact>();
            Contact contact = new Contact();
            contact.Surname = "Kis";
            contact.Patronymic = "Miay";
            contact.Name = "Кошечка";
            contact.Phone = new PhoneNumber("8 904 999 04 51");
            Contacts.Add(contact);
        }

        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
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
