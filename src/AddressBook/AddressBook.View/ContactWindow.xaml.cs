using System.Windows;
using AddressBook.Model;

namespace AddressBook.View
{
    /// <summary>
    /// Логика взаимодействия для ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        private Contact _contact = new Contact();

        public ContactWindow()
        {
            InitializeComponent();
        }

        public Contact Contact {
            
            get 
            {
                return _contact;
            }

            set 
            {
                Contact = value;
                UpdateWindow();
            }
        }

        public void UpdateContact() 
        {
            Contact.Surname = SurnameTextBox.Text;
            Contact.Name = NameTextBox.Text;
            Contact.Patronymic = PatronymicTextBox.Text;
            Contact.Number = new PhoneNumber(ulong.Parse(PhoneNumberTextBox.Text));
        }

        public void UpdateWindow() 
        {
            IdTextBlock.Text = Contact.Id.ToString();
            SurnameTextBox.Text = Contact.Surname;
            NameTextBox.Text = Contact.Name;
            PatronymicTextBox.Text = Contact.Patronymic;
            PhoneNumberTextBox.Text = Contact.Number.ToString();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateContact();

            DialogResult = true;

            Close();        
        }

        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }
    }
}
