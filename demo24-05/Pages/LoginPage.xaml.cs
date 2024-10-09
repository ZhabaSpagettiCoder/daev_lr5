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

namespace daev5lr.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            App.currentUser = null;
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = App.db.users.FirstOrDefault(l => l.Login == TbLogin.Text && l.Password == PbPassword.Password);
            if (login != null)
            {
                App.currentUser = login;
                NavigationService.Navigate(new RequestPage());
            }
            else if (TbLogin.Text == "" || PbPassword.Password == "")
            {
                MessageBox.Show("Не все поля заполнены", "внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Пользователя не существует", "внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
