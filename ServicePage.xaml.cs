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

namespace YarullinAutoService
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();

            ComboType.SelectedIndex = 0;    

            UpdateServices(null, null);
        }
	
	public void ButtonClick(object sender ,RoutedEventArgs e){
	    Manager.MainFrame.Navigate(new AddEditPage());
	}
    private void UpdateServices(object sender, EventArgs e)
    {
            var services = YarullinAutoServiceEntities.Context.Services.ToList();


            if (ComboType.SelectedIndex == 0)
            {
                services = services.Where(p => Convert.ToInt32(p.Discount) >= 0 && Convert.ToInt32(p.Discount) <= 100).ToList();
            }
            if (ComboType.SelectedIndex == 1)
            {
                services = services.Where(p => Convert.ToInt32(p.Discount) >= 0 && Convert.ToInt32(p.Discount) < 5).ToList();
            }
            if (ComboType.SelectedIndex == 2)
            {
                services = services.Where(p => Convert.ToInt32(p.Discount) >= 5 && Convert.ToInt32(p.Discount) < 15).ToList();
            }
            if (ComboType.SelectedIndex == 3)
            {
                services = services.Where(p => Convert.ToInt32(p.Discount) >= 15 && Convert.ToInt32(p.Discount) <= 30).ToList();
            }
            if (ComboType.SelectedIndex == 4)
            {
                services = services.Where(p => Convert.ToInt32(p.Discount) >= 30 && Convert.ToInt32(p.Discount) < 70).ToList();
            }
            if (ComboType.SelectedIndex == 5)
            {
                services = services.Where(p => Convert.ToInt32(p.Discount) >= 70 && Convert.ToInt32(p.Discount) <= 100).ToList();
            }

            if (RButtonDown.IsChecked.Value)
            {
                services = services.OrderBy(p => p.Cost).ToList();
            }

            if (RButtonUp.IsChecked.Value)
            {
                services = services.OrderByDescending(p => p.Cost).ToList();

            }

            services = services.Where(p => p.Title.Contains(TBoxSearch.Text)).ToList();

            ServiceListView.ItemsSource = services;

        }
    }
    
}
