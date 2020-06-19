using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private readonly Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneNumber.Text = contact.Phone;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneNumber.Text;

            using (var connection = new SQLiteConnection(App.databasePath))
            {
                connection.Delete(contact);
            }

            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SQLiteConnection(App.databasePath))
            {
                connection.Update(contact);
            }

            Close();
        }
    }
}
