using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetroCleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                txtSysDetails.Text = UtilityClass.systemInfo();
            }
            catch
            {
                MessageBox.Show("There is a problem in detecting your system information. This app may not be compatible with your OS.\nFor more information please read instruction manual.", "Error Detecting SystemInfo", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private async void btnClean_Click(object sender, RoutedEventArgs e)
        {
            btnClean.IsEnabled = false;
            txtTaskDetails.Text = "";

            if (imgGlass.Visibility == Visibility.Visible)
            {
                UtilityClass.customAnimation(this, "fadeOut", imgGlass);
                UtilityClass.customAnimation(this, "fadeOut", txtGlass);
                await Task.Delay(600);

                imgGlass.Visibility = Visibility.Hidden;
                txtGlass.Visibility = Visibility.Hidden;
            }
            else if (imgPass.Visibility == Visibility.Visible)
            {
                UtilityClass.customAnimation(this, "fadeOut", imgPass);
                UtilityClass.customAnimation(this, "fadeOut", txtPass);
                await Task.Delay(600);

                imgPass.Visibility = Visibility.Hidden;
                txtPass.Visibility = Visibility.Hidden;
            }
            else
            {
                UtilityClass.customAnimation(this, "fadeOut", imgFail);
                UtilityClass.customAnimation(this, "fadeOut", txtFail);
                await Task.Delay(600);

                imgFail.Visibility = Visibility.Hidden;
                txtFail.Visibility = Visibility.Hidden;
            }

            try
            {
                //System cleaning main section
                imgLoading.Visibility = Visibility.Visible;
                txtLoading.Visibility = Visibility.Visible;

                UtilityClass.customAnimation(this, "fadeIn", imgLoading);
                UtilityClass.customAnimation(this, "fadeIn", txtLoading);
                await Task.Delay(600);

                txtTaskDetails.Text = "Initializing process...\n";
                txtTaskDetails.Text += "Calculating files...\n";
                txtTaskDetails.Text += "Start Cleaning...\n";

                String tempPath = System.IO.Path.GetTempPath();
                UtilityClass.deleteAll(tempPath);

                txtTaskDetails.Text += "Cleaning successful...";

                UtilityClass.customAnimation(this, "fadeOut", imgLoading);
                UtilityClass.customAnimation(this, "fadeOut", txtLoading);
                await Task.Delay(600);

                imgLoading.Visibility = Visibility.Hidden;
                txtLoading.Visibility = Visibility.Hidden;
                //=============================================//

                imgPass.Visibility = Visibility.Visible;
                txtPass.Visibility = Visibility.Visible;

                UtilityClass.customAnimation(this, "fadeIn", imgPass);
                UtilityClass.customAnimation(this, "fadeIn", txtPass);
                await Task.Delay(600);
            }
            catch
            {
                txtTaskDetails.Text += "Cleaning failed...\n";
                imgFail.Visibility = Visibility.Visible;
                txtFail.Visibility = Visibility.Visible;

                UtilityClass.customAnimation(this, "fadeIn", imgFail);
                UtilityClass.customAnimation(this, "fadeIn", txtFail);
                await Task.Delay(600);
            }

            btnClean.IsEnabled = true;
        }

        
    }
}
