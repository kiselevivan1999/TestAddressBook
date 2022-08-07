using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AddressBook.Model;

namespace AddressBook.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private List<Contact> _contacts = new List<Contact>();
        private Contact _selectedContact = new Contact();

        public MainWindowVM()
        {
            _contacts = ProjectSerializer.LoadFromFile();
        }

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged("SelectedPhone");
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
