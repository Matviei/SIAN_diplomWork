using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using SIAN.Views.Tasks;

namespace SIAN.Views.AnalitikViews
{
    /// <summary>
    /// Логика взаимодействия для ActualTaskPage.xaml
    /// </summary>
    public partial class ActualTaskPage : Page
    {
        public ActualTaskPage()
        {
            InitializeComponent();
            LVProject.ItemsSource = DB_connect.db_connect.db.Tasks.ToList();
            var statusList = DB_connect.db_connect.db.Status.ToList();
            statusList.Insert(0,new Status()
            {
                ID_status = 0,
                Description = "Все"
            });
            CBStatus.ItemsSource = statusList;
            CBStatus.SelectedIndex = 0;
        }

        private void MIAddProject_OnClick(object sender, RoutedEventArgs e)
        {
            TaskEditAndAddWindow taskWindow = new TaskEditAndAddWindow();
            taskWindow.ShowDialog();
            Sort();
            LVProject.ItemsSource = DB_connect.db_connect.db.Tasks.ToList();
        }

        private void MIEditProject_OnClick(object sender, RoutedEventArgs e)
        {
            if (LVProject.SelectedItem != null)
            {
                var selectedProject = LVProject.SelectedItem as Models.Tasks;
                TaskEditAndAddWindow taskWindow = new TaskEditAndAddWindow(selectedProject);
                taskWindow.ShowDialog();
                Sort();
                LVProject.ItemsSource = DB_connect.db_connect.db.Tasks.ToList();
            }
        }

        private void MIAddTaskSubdivision_OnClick(object sender, RoutedEventArgs e)
        {
            TaskSubdivisionEditAndAddWindow TSW = new TaskSubdivisionEditAndAddWindow();
            TSW.ShowDialog();
            Sort();
        }

        private void MIEditTaskSubdivision_OnClick(object sender, RoutedEventArgs e)
        {
            if (LVTaskSubdivixion.SelectedItem != null)
            {
                var selectedTaskSubdivision = LVTaskSubdivixion.SelectedItem as TaskSubdivision;
                TaskSubdivisionEditAndAddWindow TSW = new TaskSubdivisionEditAndAddWindow(selectedTaskSubdivision);
                TSW.ShowDialog();
                Sort();
            }
        }

        private void MIAddTaskShedule_OnClick(object sender, RoutedEventArgs e)
        {
            TaskSheduleEditAndAddWindow TSW = new TaskSheduleEditAndAddWindow();
            TSW.ShowDialog();
            Sort();
        }

        private void MIEditTaskShedule_OnClick(object sender, RoutedEventArgs e)
        {
            if (LVTaskShedule.SelectedItem != null)
            {
                var selectedTaskshedule = LVTaskShedule.SelectedItem as TaskSchedule;
                TaskSheduleEditAndAddWindow TSW = new TaskSheduleEditAndAddWindow(selectedTaskshedule);
                TSW.ShowDialog();
                Sort();
            }
        }


        private void LVProject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTasks = LVProject.SelectedItem as Models.Tasks;
            Sort();

        }

        private void LVTaskSubdivixion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTasksSubdivision = LVTaskSubdivixion.SelectedItem as TaskSubdivision;
           Sort();
        }

        private void Sort()
        {
            
            var listTaskSubdivision = DB_connect.db_connect.db.TaskSubdivision.ToList();
            var listTaskShedule = DB_connect.db_connect.db.TaskSchedule.ToList();
            if (SelectedTasks != null)
            {
                listTaskSubdivision = listTaskSubdivision.Where(c => c.ID_task == SelectedTasks.ID_task).ToList();
                listTaskShedule = listTaskShedule.Where(c => c.ID_task == SelectedTasks.ID_task).ToList();
            }
            if (SelectedTasksSubdivision != null)
            {
                listTaskShedule = listTaskShedule.Where(c => c.ID_taskSubdivision == SelectedTasksSubdivision.ID_taskSubdivision).ToList();
            }

            if (SelectedStatus != null)
            {
                if (SelectedStatus.ID_status != 0)
                listTaskShedule = listTaskShedule.Where(c => c.ID_status == SelectedStatus.ID_status).ToList();
                

            }


            LVTaskShedule.ItemsSource = listTaskShedule.ToList();
            LVTaskSubdivixion.ItemsSource = listTaskSubdivision.ToList();
        }

        private void CBStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                SelectedStatus = CBStatus.SelectedItem as Status;
                Sort();

        }
        private Models.Tasks _selectedTasks;

        public Models.Tasks SelectedTasks
        {
            get
            {
                return _selectedTasks;
            }
            set
            {
                _selectedTasks = value;
            }
        }

        private TaskSubdivision _selectedTaskSubdivision;

        public TaskSubdivision SelectedTasksSubdivision
        {
            get
            {
                return _selectedTaskSubdivision;
            }
            set
            {
                _selectedTaskSubdivision = value;
            }
        }

        private Status _selectedStatus;

        public Status SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
            }
        }

        private void BTRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            DB_connect.db_connect.db = new TimeMangerDBEntities();
            Sort();
        }
    }
}
