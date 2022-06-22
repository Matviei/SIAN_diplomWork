using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIAN.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;

namespace SIAN.Views.EmployeeViews
{
    /// <summary>
    /// Логика взаимодействия для ActualTasks.xaml
    /// </summary>
    public partial class ActualTasks : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        public ActualTasks()
        {
            InitializeComponent();
           
           
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LVTaskShedule.ItemsSource = DB_connect.db_connect.db.TaskSchedule.Where(c => c.ID_employee == Models.SelectedEmployee.Employee.ID_employee && c.ID_status == 1).ToList();
            
            dt.Interval = TimeSpan.FromSeconds(15);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void dtTicker(object sender, EventArgs e)
        {
            DB_connect.db_connect.db = new TimeMangerDBEntities();
            LVTaskShedule.ItemsSource = null;
            LVTaskShedule.ItemsSource = DB_connect.db_connect.db.TaskSchedule.Where(c => c.ID_employee == Models.SelectedEmployee.Employee.ID_employee && c.ID_status == 1).ToList();
        }

        private void LVTaskShedule_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LVTaskShedule.SelectedItem != null)
            {
                var selected = LVTaskShedule.SelectedItem as TaskSchedule;
                SelectedTaskSheduleWindow STSW = new SelectedTaskSheduleWindow(selected);
                dt.Stop();
                STSW.ShowDialog();
                dt.Start();
                DB_connect.db_connect.db = new TimeMangerDBEntities();
                LVTaskShedule.ItemsSource = DB_connect.db_connect.db.TaskSchedule.Where(c => c.ID_employee == Models.SelectedEmployee.Employee.ID_employee && c.ID_status == 1).ToList();
                DB_connect.db_connect.db.SaveChanges();
                
            }
        }
    }
}
