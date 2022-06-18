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
using SIAN.Models;
using SIAN.Views.AnalitikViews;
using SIAN.Views.EmployeeViews;
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

           
            var user = DB_connect.db_connect.db.Employee
                .Where(c => c.Mail == MailTB.Text && c.Password == PBPassword.Password).FirstOrDefault();
            if (user != null)
            {
                SelectedEmployee.Employee = user;
                switch (user.ID_subdivision)
                {
                    case 1:
                        ProjectManagerWindow PW = new ProjectManagerWindow();
                        PW.Show();
                        Application.Current.MainWindow.Close();
                        break;
                    case 2:
                        AnalitikWindow AW = new AnalitikWindow();
                        AW.Show();
                        Application.Current.MainWindow.Close();
                        break;
                    case 3:
                    case 4:
                    case 5:
                        EmployeeWindow EW = new EmployeeWindow();
                        EW.Show();
                        Application.Current.MainWindow.Close();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Некорректные данные");

            }
        }

        private void MailTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MailTB.Text.Length > 0)
                LoginTB.Visibility = Visibility.Hidden;
           
           else if (MailTB.Text.Length < 1)
                LoginTB.Visibility = Visibility.Visible;
        }
    }
}
