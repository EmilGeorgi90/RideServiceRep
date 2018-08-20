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

namespace something
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgRideHolder.ItemsSource = business.Business.GetData(new System.Data.SqlClient.SqlCommand() { CommandText = "Execute GetData" });
        }

        private void dgRideHolder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgRideHolder.SelectedItem is Entity.Rides ride)
            {
                lblName.Content = ride.Name;
                lblStatus.Content = ride.Status;
                lblCategory.Content = ride.Category;
                lblTotalShutdowns.Content = ride.Reports.Where(c => c.Status == "nedbrud").Count();
                lblDaysSinceLastShutDown.Content = ride.Reports.Where(c => c.ReportTime < DateTime.Now);
            }
        }
    }
}
