using sr.DBConnection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sr.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Employee> Employees { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        

        private void VxodBT_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text.Trim();
            string password = PasswordPB.Password.Trim();

            Employees = new List<Employee>(DBConnection.DBConnection.samrab.Employee.ToList());
            Employee currentUser = Employees.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentUser != null)
            {
               
                string loginOne = 123.ToString();
                if (login == loginOne) 
                { 
                    NavigationService.Navigate()
                }
               
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует(((");
            }
        }
    }
}
