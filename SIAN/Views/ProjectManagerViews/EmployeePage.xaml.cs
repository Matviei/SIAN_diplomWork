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
            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            
        }
        
        private void LVEmployee_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Sort();
        }

        public void Sort()
        {
            var select = LVEmployee.SelectedItem as Employee;
            _seriesCollection = EmployeeChartCtor.ChartEmployee(select);
            var cbList = DB_connect.db_connect.db.TaskSchedule
                .Where(c => c.ID_employee == select.ID_employee).ToList();
            TaskSheduleChart.Series = _seriesCollection;
            if (CBStatus.SelectedIndex > 0)
            {
                var selectCB = (CBStatus.SelectedItem as Status).ID_status;
                if (select != null)
                    cbList =
                        cbList.Where(c =>
                            c.ID_status == selectCB).ToList();
            }

            LVTaskShedule.ItemsSource = cbList;
        }
        private void CBStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
    }
}
