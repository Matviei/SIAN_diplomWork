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

namespace SIAN.Views.ProjectManagerViews
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
            CBSubdivision.ItemsSource = DB_connect.db_connect.db.Subdivision.ToList();
            CBSubdivision.SelectedIndex = 0;
            CBLevel.ItemsSource = DB_connect.db_connect.db.Level.ToList();
            CBLevel.SelectedIndex = 0;
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

        private void BTGeneratePassword_OnClick(object sender, RoutedEventArgs e)
        {
            TBPaswword.Text = CreatePassword(10);
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private void BTSaveEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (TBSurname.Text.Length > 0 && TBName.Text.Length > 0 && TBMail.Text.Length > 0 &&
                TBNumberPhone.Text.Length>0 && TBPaswword.Text.Length > 0)
            {
                DB_connect.db_connect.db.Employee.Add(new Employee()
                {
                    Surname = TBSurname.Text,
                    Name = TBName.Text,
                    Mail = TBMail.Text,
                    Number_Phone = TBNumberPhone.Text,
                    Password = TBPaswword.Text,
                    ID_level = (CBLevel.SelectedItem as Level).ID_level,
                    ID_subdivision = (CBSubdivision.SelectedItem as Subdivision).ID_subdivision,
                    ID_staffStatus = 1

                });
                DB_connect.db_connect.db.SaveChanges();
                MessageBox.Show("Сотрудник " + TBSurname.Text + " " + TBName.Text + " успешно зарегистрирован!");
                ProjectManagerWindow PMW = new ProjectManagerWindow();
                PMW.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Ошибка добавления! Перепроверьте");
            }
        }
    }
}
