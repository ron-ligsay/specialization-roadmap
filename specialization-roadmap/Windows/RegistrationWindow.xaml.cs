using MySql.Data.MySqlClient;
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

namespace specialization_roadmap
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DatabaseManager databaseManager = new DatabaseManager();

            // Get all the values from the textboxes
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            string password = boxPassword.Password;
            string cPassword = boxCPassword.Password;

            if (password == cPassword)
            {
                string query = "INSERT INTO user (username, email, password) VALUES(@username, @email, @password)";

                MySqlParameter[] parameters =
               {
                    new MySqlParameter("@username", name),
                    new MySqlParameter("@email", email),
                    new MySqlParameter("@password", password)
                };

                databaseManager.ExecuteNonQuery(query, parameters);

                textBoxName.Text = "";
                textBoxEmail.Text = "";
                boxPassword.Password = "";
                boxCPassword.Password = "";

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password do not match please try again");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
