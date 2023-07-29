using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace specialization_roadmap
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IDatabaseManager databaseManager;

        public LoginWindow()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get all the values from the textboxes
            string email = textBoxEmail.Text;
            string password = boxPassword.Password;

            if (IsValidUser(email, password))
            {
                // Successful login
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private bool IsValidUser(string email, string password)
        {
            string query = "SELECT * FROM user WHERE email = @email AND password = @password";
            MySqlParameter[] parameters =
            {
            new MySqlParameter("@email", email),
            new MySqlParameter("@password", password)
        };

            DataTable dataTable = databaseManager.ExecuteQuery(query, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                string column1Value = row["username"].ToString();
                MessageBox.Show($"Welcome, {column1Value}!");
                return true;
            }

            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }

}
