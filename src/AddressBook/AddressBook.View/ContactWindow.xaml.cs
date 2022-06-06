using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
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

        private ToolTip _numberToolTip = new ToolTip();

        private ToolTip _stringToolTip = new ToolTip();

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
                _contact = value;
                
                UpdateWindow();          
            }
        }

        public void UpdateContact() 
        {
            _contact.Surname = SurnameTextBox.Text;
            _contact.Name = NameTextBox.Text;
            _contact.Patronymic = PatronymicTextBox.Text;
            _contact.Number = new PhoneNumber(ulong.Parse(PhoneNumberTextBox.Text));
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

        private void SurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.Background = _correctColor;
            }
            catch (ArgumentException ex)
            {
                SurnameTextBox.Background = _errorColor;

                _stringToolTip.Content = ex.Message;
                SurnameTextBox.ToolTip = _stringToolTip;
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.Background = _correctColor;
            }
            catch (ArgumentException ex)
            {
                NameTextBox.Background = _errorColor;

                _stringToolTip.Content = ex.Message;
                NameTextBox.ToolTip = _stringToolTip;
            }
        }

        private void PatronymicTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Patronymic = PatronymicTextBox.Text;
                PatronymicTextBox.Background = _correctColor;
            }
            catch (ArgumentException ex)
            {
                PatronymicTextBox.Background = _errorColor;

                _stringToolTip.Content = ex.Message;
                PatronymicTextBox.ToolTip = _stringToolTip;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _contact.Number = new PhoneNumber(ulong.Parse(PhoneNumberTextBox.Text));
                PhoneNumberTextBox.Background = _correctColor;

            }
            catch (Exception ex)
            {
                PhoneNumberTextBox.Background = _errorColor;

                _numberToolTip.Content = ex.Message;
                PhoneNumberTextBox.ToolTip = _numberToolTip;
            }
        }
    }
}
