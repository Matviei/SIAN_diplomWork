using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using LiveCharts;
using SIAN.Models;
using SIAN.Services;

namespace SIAN.Views.ProjectManagerViews
{
    /// <summary>
    /// Логика взаимодействия для StatistikPage.xaml
    /// </summary>
    public partial class StatistikPage : Page
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
   

        public StatistikPage()
        {
            InitializeComponent();

            LVProject.ItemsSource = DB_connect.db_connect.db.Tasks.ToList();
        }

        private void LVProject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVProject.SelectedItem != null)
            {
                var select = LVProject.SelectedItem as Tasks;
                _seriesCollection = ProjectChartCtor.ChartProject(select);
                PieChart.Series = _seriesCollection;
                LVTaskSubdivixion.ItemsSource = DB_connect.db_connect.db.TaskSubdivision
                    .Where(c => c.ID_task == select.ID_task).ToList();
            }
        }

        private void LVTaskSubdivixion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVTaskSubdivixion.SelectedItem != null)
            {
                var select = LVTaskSubdivixion.SelectedItem as TaskSubdivision;
                _seriesCollection = ProjectChartCtor.ChartTaskSubdivision(select);
                PieChart.Series = _seriesCollection;
            }
        }
    }
}
