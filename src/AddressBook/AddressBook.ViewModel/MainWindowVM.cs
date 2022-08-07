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
        //private ObservableCollection<Contact> _contacts;
        private Contact _selectedContact = new Contact();

        public MainWindowVM()
        {
            Contacts = new ObservableCollection<Contact>(ProjectSerializer.LoadFromFile());
        }

        public ObservableCollection<Contact> Contacts { get; set; }

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
