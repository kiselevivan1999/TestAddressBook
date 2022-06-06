using System.Collections.Generic;
using System.Windows;
using AddressBook.Model;
using System.Windows.Controls;

namespace AddressBook.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> _contacts = new List<Contact>();
        public MainWindow()
        {            
            InitializeComponent();

        }

        private void UpdateSelectContact(int index) 
        {
            Contact contact = _contacts[index];

            IdTextBlock.Text = contact.Id.ToString();
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            PatronymicTextBlock.Text = contact.Patronymic;
            PhoneNumberTextBlock.Text = contact.Number.ToString();
        }

        private void UpdateListBox()
        { 
            ContactsListBox.Items.Clear();

            foreach (Contact contact in _contacts) 
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
        }

        private void AddContact() 
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.Contact.Id = _contacts.Count;
            var result = contactWindow.ShowDialog();
            
            _contacts.Add(contactWindow.Contact);
            UpdateListBox();
        }

        private void EditContact() 
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.Show();


        }

        private void RemoveContact(int index) 
        {
            _contacts.RemoveAt(index);
            UpdateListBox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddContact();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditContact();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1) 
            {
                MessageBox.Show("Choose contact");
                return;
            }
            var result = MessageBox.Show("You realy want remove this contact?", "Removing", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) 
            {
                RemoveContact(ContactsListBox.SelectedIndex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("You realy want exit?", "Exiting", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }

            //ProjectSerializer.SaveToFile(_contacts);
        }

        private void ContactsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1) 
            {
                return;
            }
            UpdateSelectContact(ContactsListBox.SelectedIndex);
        }
    }
}
