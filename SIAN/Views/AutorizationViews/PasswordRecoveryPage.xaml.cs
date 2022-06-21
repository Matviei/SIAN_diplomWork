using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using SIAN.Services;

namespace SIAN.Views.AutorizationViews
{
    /// <summary>
    /// Логика взаимодействия для PasswordRecoveryPage.xaml
    /// </summary>
    public partial class PasswordRecoveryPage : Page
    {
        Employee employee;
        public PasswordRecoveryPage()
        {
            InitializeComponent();
        }

        private static string _cod;

        public static string Cod
        {
            get
            {
                return _cod;
            }
            set
            {
                _cod = value;
            }
        }

        private Employee _employee;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
            }
        }
        public static void SendEmail(string email)
        {
            var fromAddress = new MailAddress("sianprojectmanager@gmail.com", "SIAN");
            var toAddress = new MailAddress(email);
            const string fromPassword = "moveeamqdyvovgir";

            var smtp = new SmtpClient
            {
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Восстановление пароля",
                Body = "Ваш код: " + Cod,
            };
            smtp.SendMailAsync(message);
            

           
        }

        public void RandomPassword()
        {
            Random random= new Random();
            string randomcod = random.Next(100000, 999999).ToString();
            Cod = randomcod;

        }

        private void BTBack_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VerificationPage());
        }

        private void BTSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (TBNewPassword1.Text == TBNewPassword1.Text)
            {
                employee = Employee;
                this.DataContext = this;
                employee.Password = TBNewPassword1.Text;
                DB_connect.db_connect.db.SaveChanges();
                MessageBox.Show("Пароль успешно сменен");
                NavigationService.Navigate(new VerificationPage());
            }
            else MessageBox.Show("Пароли не совпадают");
        }

        private void BTMessageShipment_OnClick(object sender, RoutedEventArgs e)
        {
            if (MailChecked.Checked(TBMail.Text))
            {
                Employee = DB_connect.db_connect.db.Employee.Where(c => c.Mail == TBMail.Text)
                    .FirstOrDefault();
                if (Employee != null)
                {
                    RandomPassword();
                    SendEmail(TBMail.Text);
                    MessageBox.Show("На укзанную почту отправлен код");
                }
                else
                {
                    MessageBox.Show("Данная почта не зaрегистрирована!");
                }
                
            }
            else MessageBox.Show("Неверный формат почты");
        }

        private void TBCod_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBCod.Text == Cod)
            {
                SPPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
