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
using SIAN.Views.ProjectManagerViews;

namespace SIAN.Views.AutorizationViews
{
    /// <summary>
    /// Логика взаимодействия для VerificationPage.xaml
    /// </summary>
    public partial class VerificationPage : Page
    {
        public VerificationPage()
        {
            InitializeComponent();
        }
        private void PasswordRetrivalButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PasswordRecoveryPage());
        }

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectManagerWindow PW = new ProjectManagerWindow();
            PW.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
