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

namespace SIAN.Views.EmployeeViews
{
    /// <summary>
    /// Логика взаимодействия для SelectedTaskSheduleWindow.xaml
    /// </summary>
    public partial class SelectedTaskSheduleWindow : Window
    {
        TaskSchedule taskSchedules;
        public SelectedTaskSheduleWindow(TaskSchedule taskSchedule)
        {
            InitializeComponent();
            taskSchedules = taskSchedule;
            this.DataContext = this;
            TBProjectName.Text = taskSchedules.Tasks.Primary_goal;
            TBDecriptionTask.Text = taskSchedules.Tasks.Description;
            TBTaskSubdivision.Text = taskSchedules.TaskSubdivision.Description;
            TBDateStart.Text = taskSchedules.CultureDateStart.ToString();
            if (taskSchedules.Deadline != null)
                TBDateEnd.Text = taskSchedules.CultureDateEnd.ToString();

            if (taskSchedules.Comment != null)
                TBComment.Text = taskSchedules.Comment;

            if (taskSchedules.SpentTime != null)
                TBTime.Text = taskSchedules.SpentTime.ToString();

            TBNameTaskshedule.Text = taskSchedules.Description;

            TBPrioritet.Text = taskSchedules.Prioritet.Name;

        }

        private void BTSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (TBComment.Text.Length > 0 && TBTime.Text.Length > 0)
            {
                taskSchedules.ID_status = 2;
                taskSchedules.Comment = TBComment.Text;
                taskSchedules.SpentTime = Convert.ToInt32(TBTime.Text);
                DB_connect.db_connect.db.SaveChanges();
                MessageBox.Show("Успех");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните доступные поля");
            }
        }

        private void BTBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
