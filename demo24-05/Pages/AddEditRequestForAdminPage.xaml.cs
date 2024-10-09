using daev5lr.Entities;
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
    /// Логика взаимодействия для AddEditRequestForAdminPage.xaml
    /// </summary>
    public partial class AddEditRequestForAdminPage : Page
    {
        public requests currentRequest = new requests();
        public AddEditRequestForAdminPage(requests requests)
        {
            InitializeComponent();
            if (requests != null )
            {
                currentRequest = requests;
                TbDateAdd.Text = currentRequest.StartDate.Date.ToString();
            }
            else
            {
                TbDateAdd.Text = DateTime.Now.Date.ToString();
            }
            DataContext = currentRequest;
            CbClientID.ItemsSource = App.db.users.ToList();
            CbClimateTechModel.ItemsSource = App.db.climantTechModel.ToList();
            CbClimateTechType.ItemsSource = App.db.climantTechType.ToList();
            CbMasterID.ItemsSource = App.db.users.ToList();
            CbRequestStatus.ItemsSource = App.db.requestStatus.ToList();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentRequest.RequestId == 0)
                {
                    currentRequest.StartDate = DateTime.Now.Date;
                    App.db.requests.Add(currentRequest);
                }
                App.db.SaveChanges();
                MessageBox.Show("Заявка добавлена", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться назад?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }
    }
}
