using System.Collections.Generic;
using System.Windows;
using AddressBook.Model;
using System.Windows.Controls;

/*
 * В целом по заданию (после компиляции):
    1. нельзя создать пользователя без отчества (в задаче валидацию проходят только имя и фамилия)
    2. можно создать пользователей с одинаковым Id, если удалить не последнего и добавить нового
    3. приложение называется "MainWindow"
    4. почему нельзя развернуть на весь экран?
    5. интерфейс на английском для кого?
    6. окно "ContactWindow" проглотит строку 8абвгде9521597199
 */

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
        
        /// <summary>
        /// Инициализирует главное окно.
        /// </summary>
        public MainWindow()
        {            
            InitializeComponent();
            _contacts = ProjectSerializer.LoadFromFile();
            UpdateListBox();
        }

        /*ох уж этот CodeBehind...*/

        /// <summary>
        /// Заполняет поля данными выделенного контакта.
        /// </summary>
        /// <param name="index">Индекс выделенного контакта.</param>
        private void UpdateSelectContact(int index) 
        {
                              /*уверен, что такое количество контактов есть? или index >= 0?*/
            Contact contact = _contacts[index];

            IdTextBlock.Text = contact.Id.ToString();
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            PatronymicTextBlock.Text = contact.Patronymic;
            PhoneNumberTextBlock.Text = contact.Number.ToString();
        }

        /// <summary>
        /// Обновляет отображаемый список контактов в ListBox.
        /// </summary>
        private void UpdateListBox()
        { 
            ContactsListBox.Items.Clear(); // уверен, что не может возникнуть иключение?

            foreach (Contact contact in _contacts) 
            {
                ContactsListBox.Items.Add(contact.Surname); // contact или contact.Surname может быть null?
            }
        }

        /// <summary>
        /// Добавляет новый контакт.
        /// </summary>
        private void AddContact() 
        {
            ContactWindow contactWindow = new ContactWindow();

            contactWindow.Contact.Id = _contacts.Count;
            var result = contactWindow.ShowDialog();
            
            if (!result.Value) // а если !result.HasValue ?
            {
                return;
            }
            
            _contacts.Add(contactWindow.Contact);
            UpdateListBox();
        }

        /// <summary>
        /// Редактирует выделенного контакт.
        /// </summary>
        /// <param name="index">Индекс контакта.</param>
        private void EditContact(int index) 
        {
            ContactWindow contactWindow = new ContactWindow();
            /*уверен, что такое количество контактов есть? или index >= 0?*/
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
            /*уверен, что такое количество контактов есть? или index >= 0?*/
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
                MessageBox.Show("Choose contact");
                return;
            }   
             EditContact(ContactsListBox.SelectedIndex); 
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1) 
            {
                MessageBox.Show("Choose contact");
                return;
            }
            /*result можно не выносить в отдельную переменную*/
            var result = MessageBox.Show("You realy want remove this contact?", "Removing", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) 
            {
                RemoveContact(ContactsListBox.SelectedIndex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("You realy want exit?", "Exiting", MessageBoxButton.YesNo);
            /*то же самое, что выше*/
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }

            ProjectSerializer.SaveToFile(_contacts);
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
