using daev5lr.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public RequestPage()
        {
            InitializeComponent();
            listViewRequests.ItemsSource = App.db.requests.ToList();
            if (App.currentUser.Type == 2)
                BtAdd.Visibility = Visibility.Collapsed;

            UpdateRequests();
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            var edit = (sender as Button).DataContext as requests;
            if (App.currentUser.Type == 1)
            {
                NavigationService.Navigate(new AddEditRequestForAdminPage(edit));
            }
            else if (App.currentUser.Type == 2)
            {
                NavigationService.Navigate(new AddCommentsMasterPage());
            }
            else if (App.currentUser.Type == 3)
            {
                NavigationService.Navigate(new AddEditRequestForAdminPage(edit));
            }
            else
            {
                NavigationService.Navigate(new AddRequestForClientPage());
            }    
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            var delete = (sender as Button).DataContext as requests;
            if (MessageBox.Show("Вы уверены, что хотите удалить заявку?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                App.db.requests.Remove(delete);
                App.db.SaveChanges();
                UpdateRequests();
            }
        }
        private void UpdateRequests()
        {
            var request = App.db.requests.ToList();
            if(App.currentUser.Type == 4)
                request = App.db.requests.Where(p => p.ClientID == App.currentUser.UserId).ToList();
            else if(App.currentUser.Type == 2)
                request = App.db.requests.Where(p => p.MasterID == App.currentUser.UserId).ToList();

            //request = request.Where(r => r.RequestId.ToString().ToLower().Contains(TbFind.Text.ToLower())).ToList();
            listViewRequests.ItemsSource = request;
            int countFind = listViewRequests.Items.Count;
            TbFindCount.Text = countFind.ToString() + " из " + App.db.requests.Count();
            if (countFind < 0)
            {
                TbFindCount.Text = "\n по вашему запросу ничего ненайдено";
            }
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            if (App.currentUser.Type == 1)
            {
                NavigationService.Navigate(new AddEditRequestForAdminPage(null));
            }
            else if (App.currentUser.Type == 2)
            {
                NavigationService.Navigate(new AddCommentsMasterPage());
            }
            else if (App.currentUser.Type == 3)
            {
                NavigationService.Navigate(new AddEditRequestForAdminPage(null));
            }
            else
            {
                NavigationService.Navigate(new AddRequestForClientPage());
            }
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться назад?","Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }

        private void TbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateRequests();
        }

        private void BtComment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRequests();
        }
    }
}
