using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
using LiveCharts;
using SIAN.Models;
using SIAN.Services;


namespace SIAN.Views.ProjectManagerViews
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private SeriesCollection _seriesCollection;

        public SeriesCollection SeriesCollect
        {
            get
            {
                return _seriesCollection;
            }
            set
            {
                _seriesCollection = value;
            }
        }
        public EmployeePage()
        {
            InitializeComponent();
            LVEmployee.ItemsSource = DB_connect.db_connect.db.Employee.ToList();
            
            var StattusList = DB_connect.db_connect.db.Status.ToList();
            StattusList.Insert(0,new Status { Description = "Все"});
            CBStatus.ItemsSource = StattusList;
            CBStatus.SelectedIndex= 0;

        }
        
        private void LVEmployee_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedEmployee = LVEmployee.SelectedItem as Employee;
            Sort();

        }

        private Employee _selecectEmployee;

        public Employee SelectedEmployee
        {
            get
            {
                return _selecectEmployee;
            }
            set
            {
                _selecectEmployee=value;
            }
        }
        public void Sort()
        {
            var TaskSheduleList = DB_connect.db_connect.db.TaskSchedule.ToList();
            if (LVEmployee.SelectedItem != null)
            {
                TaskSheduleList = TaskSheduleList.Where(c => c.ID_employee == SelectedEmployee.ID_employee).ToList();


                _seriesCollection = EmployeeChartCtor.ChartEmployee(SelectedEmployee);

                if (CBStatus.SelectedIndex > 0)
                {
                    var selectCB = (CBStatus.SelectedItem as Status).ID_status;
                    TaskSheduleList =
                        TaskSheduleList.Where(c =>
                            c.ID_status == selectCB).ToList();
                    _seriesCollection = EmployeeChartCtor.ChartEmployee(SelectedEmployee, selectCB);
                }

                LVTaskShedule.ItemsSource = TaskSheduleList;
                TaskSheduleChart.Series = _seriesCollection;
            }
            

        }
        private void CBStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }

        private void BTDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow AEW = new AddEmployeeWindow();
            AEW.ShowDialog();
            LVEmployee.ItemsSource = DB_connect.db_connect.db.Employee.ToList();
        }



        private void BTEditEmployee_OnClick(object sender, RoutedEventArgs e)
        {

            if (LVEmployee.SelectedItem != null)
            {
                var selected = (LVEmployee.SelectedItem as Employee).ID_employee;
                EditEmployeeWindow EEW = new EditEmployeeWindow(SelectedEmployee);
                EEW.ShowDialog();
                LVEmployee.ItemsSource = DB_connect.db_connect.db.Employee.ToList();
            }
        }
    }
}
