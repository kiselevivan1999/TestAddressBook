using System.Collections.Generic;
using System.Windows;
using AddressBook.Model;
using System.Windows.Controls;
using System;
using AddressBook.ViewModel;
using System.Linq;

namespace AddressBook.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Список контактов выводимых на окно.
        /// </summary>
        private List<Contact> _contacts = new List<Contact>();

        MainWindowVM vm;
        /// <summary>
        /// Инициализирует главное окно.
        /// </summary>
        public MainWindow()
        {            
            InitializeComponent();
            vm = new MainWindowVM();
            //_contacts = ProjectSerializer.LoadFromFile();
            //UpdateListBox();
        }

        /// <summary>
        /// Заполняет поля данными выделенного контакта.
        /// </summary>
        /// <param name="index">Индекс выделенного контакта.</param>
        private void UpdateSelectContact(int index) 
        {
            Contact contact = _contacts[index];

            IdTextBlock.Text = contact.Id.ToString();
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            PatronymicTextBlock.Text = contact.Patronymic;
            PhoneNumberTextBlock.Text = contact.Phone.ToString();
        }

        /// <summary>
        /// Обновляет отображаемый список контактов в ListBox.
        /// </summary>
        private void UpdateListBox()
        { 
            ContactsListBox.Items.Clear();

            foreach (Contact contact in vm.Contacts) 
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
        }

        /// <summary>
        /// Добавляет новый контакт.
        /// </summary>
        private void AddContact() 
        {
            ContactWindow contactWindow = new ContactWindow();

            var random = new Random();
            contactWindow.Contact.Id = _contacts.Count + random.GetHashCode();
            var result = contactWindow.ShowDialog();

            if (!result.Value) 
            {
                return;
            }

            vm.Contacts.Add(contactWindow.Contact);
            //_contacts.Add(contactWindow.Contact);
            //UpdateListBox();
        }

        /// <summary>
        /// Редактирует выделенного контакт.
        /// </summary>
        /// <param name="index">Индекс контакта.</param>
        private void EditContact(int index) 
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.Contact = _contacts[index];
            var result = contactWindow.ShowDialog();

            if (!result.Value)
            {
                return;
            }

            _contacts.RemoveAt(index);
            _contacts.Insert(index, contactWindow.Contact);

            UpdateListBox();
        }

        /// <summary>
        /// Удаление выделенного контакта.
        /// </summary>
        /// <param name="index"></param>
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
            if (ContactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт.");
                return;
            }   
             EditContact(ContactsListBox.SelectedIndex); 
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1) 
            {
                MessageBox.Show("Выберите контакт.");
                return;
            }
            var result = MessageBox.Show("Вы действительно хотите удалить контакт", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) 
            {
                RemoveContact(ContactsListBox.SelectedIndex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотетите выйти?", "Выход", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }

            ProjectSerializer.SaveToFile(vm.Contacts.ToList());
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
