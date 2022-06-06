using System;
using System.Windows;
using System.Windows.Media;
using AddressBook.Model;

namespace AddressBook.View
{
    /// <summary>
    /// Логика взаимодействия для ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        private Contact _contact = new Contact();

        private Brush _correctColor = Brushes.White;

        private Brush _errorColor = Brushes.Pink;

        

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

        private void SurnameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.Background = _correctColor;
            }
            catch (ArgumentException)
            {
                SurnameTextBox.Background = _errorColor;
            }
        }

        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                Contact.Name = NameTextBox.Text;
                NameTextBox.Background = _correctColor;
            }
            catch (ArgumentException)
            {
                NameTextBox.Background = _errorColor;
            }
        }

        private void PatronymicTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                Contact.Patronymic = PatronymicTextBox.Text;
                PatronymicTextBox.Background = _correctColor;
            }
            catch (ArgumentException)
            {
                PatronymicTextBox.Background = _errorColor;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                Contact.Number = new PhoneNumber(ulong.Parse(PhoneNumberTextBox.Text));
                PhoneNumberTextBox.Background = _correctColor;
            }
            catch (Exception)
            {
                PhoneNumberTextBox.Background = _errorColor;
            }
        }
    }
}
