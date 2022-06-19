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
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    { 
        Employee employee;
        public EditEmployeeWindow(Employee selectedEmployee)
        {
            
            InitializeComponent();
            employee = selectedEmployee;
            this.DataContext = this;
            LVEmployee.ItemsSource = DB_connect.db_connect.db.Employee.Where(c=>c.ID_employee == selectedEmployee.ID_employee).ToList();
            CBLevel.ItemsSource = DB_connect.db_connect.db.Level.ToList();
            CBLevel.SelectedItem = selectedEmployee.Level;
            CBSubdivision.ItemsSource = DB_connect.db_connect.db.Subdivision.ToList();
            CBSubdivision.SelectedItem = selectedEmployee.Subdivision;
        }
        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void BTCloseApp_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTSaveEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            employee.ID_level = (CBLevel.SelectedItem as Level).ID_level;
            employee.ID_subdivision = (CBSubdivision.SelectedItem as Subdivision).ID_subdivision;
            DB_connect.db_connect.db.SaveChanges();
            MessageBox.Show("Успех!");
            this.Close();
        }
    }
}
