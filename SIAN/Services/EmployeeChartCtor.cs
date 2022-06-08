using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using SIAN.Models;

namespace SIAN.Services
{
    internal class EmployeeChartCtor
    {
        public static SeriesCollection SeriesCollect { get; set; }

        public static SeriesCollection ChartEmployee(Employee selectedEmployee)
        {

            var TaskSubdd = DB_connect.db_connect.db.TaskSchedule.Where(c => c.ID_employee == selectedEmployee.ID_employee);
            SeriesCollect = new SeriesCollection();
            foreach (var lev in TaskSubdd)
            {
                SeriesCollect.Add(new ColumnSeries()
                {
                    Title = lev.Description,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lev.SpentTime)) },
                    DataLabels = true
                });
            }

            return SeriesCollect;
        }

        public static SeriesCollection ChartEmployee(Employee selectedEmployee, int ID_Status)
        {

            var TaskSubdd = DB_connect.db_connect.db.TaskSchedule.Where(c => c.ID_employee == selectedEmployee.ID_employee && c.ID_status == ID_Status);
            SeriesCollect = new SeriesCollection();
            foreach (var lev in TaskSubdd)
            {
                SeriesCollect.Add(new ColumnSeries()
                {
                    Title = lev.Description,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lev.SpentTime)) },
                    DataLabels = true
                });
            }

            return SeriesCollect;
        }
    }
}
