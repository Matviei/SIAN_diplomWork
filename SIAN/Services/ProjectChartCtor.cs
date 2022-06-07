using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using SIAN.Models;

namespace SIAN.Services
{
    internal class ProjectChartCtor
    {
        public static SeriesCollection SeriesCollect { get; set; }

        public static SeriesCollection ChartProject(Tasks selectedTask)
        {

            var TaskSubdd = DB_connect.db_connect.db.TaskSubdivision.Where(c=>c.ID_task == selectedTask.ID_task);
            SeriesCollect = new SeriesCollection();
            foreach (var lev in TaskSubdd)
            {
                SeriesCollect.Add(new PieSeries
                {
                    Title = lev.Description,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lev.SpentTime)) },
                    DataLabels = true
                });
            }

            return SeriesCollect;
        }

        public static SeriesCollection ChartTaskSubdivision(TaskSubdivision selecTaskSubdivision)
        {
            var TaskSubdd = DB_connect.db_connect.db.TaskSchedule.Where(c => c.ID_taskSubdivision == selecTaskSubdivision.ID_taskSubdivision);
            SeriesCollect = new SeriesCollection();
            foreach (var lev in TaskSubdd)
            {
                SeriesCollect.Add(new PieSeries
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
