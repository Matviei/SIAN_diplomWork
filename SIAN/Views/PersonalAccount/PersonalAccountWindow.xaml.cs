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
using System.Windows.Shapes;
using SIAN.Models;
using SIAN.Services;

namespace SIAN.Views.PersonalAccount
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountWindow.xaml
    /// </summary>
    public partial class PersonalAccountWindow : Window
    {
        Employee employee;
        public PersonalAccountWindow()
        {
            InitializeComponent();
            employee = SelectedEmployee.Employee;
            this.DataContext = this;
            TBName.Text =employee.Name;
            TBSurname.Text = employee.Surname;
            TBMail.Text = employee.Mail;
            TBNumberPhone.Text = employee.Number_Phone;
        }
        private void BTCloseApp_OnClick(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void BTMAximazeApp_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;

            }
            else this.WindowState = WindowState.Maximized;

        }

        private void BTMinimazeApp_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BTEditPassword_OnClick(object sender, RoutedEventArgs e)
        {
            if (SPPasswordRetrieval.Visibility == Visibility.Hidden)
            {
                SPPasswordRetrieval.Visibility= Visibility.Visible;
                return;
            }

            if (SPPasswordRetrieval.Visibility == Visibility.Visible)
            {
                if (TBNewPassword2.Text.Length > 0 && TBStartPassword.Text.Length > 0 && TBNewPassword1.Text.Length > 0)
                {
                    if (TBStartPassword.Text != SelectedEmployee.Employee.Password)
                    {
                        MessageBox.Show("Не правильный старый пароль");
                        return;
                    }

                    if (TBNewPassword1.Text != TBNewPassword2.Text)
                    {
                        MessageBox.Show("Новые пароли не совпадают");
                        return;
                    }
                    employee.Password = TBNewPassword2.Text;
                    MessageBox.Show("Пароль успешно изменен!");
                    SPPasswordRetrieval.Visibility = Visibility.Hidden;
                    TBNewPassword1.Text = "";
                    TBNewPassword2.Text = "";
                    TBStartPassword.Text = "";
                }
                else MessageBox.Show("Заполните все поля");
            }

        }

        private void BTSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (TBName.Text.Length > 0 && TBSurname.Text.Length > 0 && TBMail.Text.Length > 0 &&
                TBNumberPhone.Text.Length > 0)
            {
                if (!MailChecked.Checked(TBMail.Text))
                {
                    MessageBox.Show("Неверный формат почты");
                    return;
                }
                employee.Name = TBName.Text;
                employee.Surname = TBSurname.Text;
                employee.Mail = TBMail.Text;
                employee.Number_Phone = TBNumberPhone.Text;
                DB_connect.db_connect.db.SaveChanges();
                SelectedEmployee.Employee = employee;
                this.Close();
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void BTEditEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            TBName.IsEnabled = true;
            TBSurname.IsEnabled = true;
            TBMail.IsEnabled = true;
            TBNumberPhone.IsEnabled = true;

        }
    }
}
