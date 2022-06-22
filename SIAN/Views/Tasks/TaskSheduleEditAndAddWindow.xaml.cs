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

namespace SIAN.Views.Tasks
{
    /// <summary>
    /// Логика взаимодействия для TaskSheduleEditAndAddWindow.xaml
    /// </summary>
    public partial class TaskSheduleEditAndAddWindow : Window
    {
        TaskSchedule taskSchedules;
        public TaskSheduleEditAndAddWindow()
        {
            InitializeComponent();
            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            CBStatus.SelectedIndex = 0;

            CBTask.ItemsSource = DB_connect.db_connect.db.Tasks.Where(c=>c.ID_status==1).ToList();

            CBEmployee.ItemsSource = DB_connect.db_connect.db.Employee.ToList();

            CBPrioritet.ItemsSource = DB_connect.db_connect.db.Prioritet.ToList();
            CBPrioritet.SelectedIndex = 0;

            CBTaskSubdivision.ItemsSource = DB_connect.db_connect.db.TaskSubdivision.ToList();

            DPDateStart.SelectedDate = DateTime.Now;
        }
        public TaskSheduleEditAndAddWindow(TaskSchedule taskSchedule)
        {
            InitializeComponent();
            taskSchedules = taskSchedule;
            this.DataContext = this;

            TBDescription.Text = taskSchedules.Description;

            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            CBStatus.SelectedItem = taskSchedules.Status;

            CBTask.ItemsSource = DB_connect.db_connect.db.Tasks.ToList();
            CBTask.SelectedItem = taskSchedules.Tasks;

            CBEmployee.ItemsSource = DB_connect.db_connect.db.Employee.ToList();
            CBEmployee.SelectedItem = taskSchedules.Employee;

            CBPrioritet.ItemsSource = DB_connect.db_connect.db.Prioritet.ToList();
            CBPrioritet.SelectedItem = taskSchedules.Prioritet;

            CBTaskSubdivision.ItemsSource = DB_connect.db_connect.db.TaskSubdivision.ToList();
            CBTaskSubdivision.SelectedItem = taskSchedules.TaskSubdivision;

            DPDateStart.SelectedDate = taskSchedules.Date;

            if (taskSchedules.Comment != null)
                TBComment.Text = taskSchedules.Comment;

            if (taskSchedules.SpentTime != null)
                TBSpentTime.Text = taskSchedules.SpentTime.ToString();

            if (taskSchedules.Deadline != null)
                DPDateEnd.SelectedDate = taskSchedules.Deadline;

        }
        private void BTSave_OnClick(object sender, RoutedEventArgs e)
        {
            int? time = null;
            string? comment = null;
            DateTime? date = null;
            if (taskSchedules == null)
            {
                if (CBStatus.SelectedItem != null && CBPrioritet.SelectedItem != null &&
                    CBEmployee.SelectedItem != null && CBTask.SelectedItem != null &&
                    CBTaskSubdivision.SelectedItem != null && TBDescription.Text.Length > 0 &&
                    DPDateStart.SelectedDate != null)
                {
                    if (TBSpentTime.Text.Length > 0)
                        time = Convert.ToInt32(TBSpentTime.Text);

                    if (DPDateEnd.SelectedDate != null)
                        date = DPDateEnd.SelectedDate;

                    if (TBComment.Text.Length>0)
                        comment = TBComment.Text;

                    DB_connect.db_connect.db.TaskSchedule.Add(new TaskSchedule()
                    {
                        ID_status = (CBStatus.SelectedItem as Status).ID_status,
                        ID_prioritet = (CBPrioritet.SelectedItem as Prioritet).ID_prioritet,
                        ID_employee = (CBEmployee.SelectedItem as Employee).ID_employee,
                        ID_task = (CBTask.SelectedItem as Models.Tasks).ID_task,
                        ID_taskSubdivision = (CBTaskSubdivision.SelectedItem as TaskSubdivision).ID_taskSubdivision,
                        Description = TBDescription.Text,
                        Date = Convert.ToDateTime(DPDateStart.SelectedDate),
                        Comment = comment,
                        Deadline = date,
                        SpentTime = time

                    });
                    DB_connect.db_connect.db.SaveChanges();
                    MessageBox.Show("Успех");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
            }
            else
            {
                if ((CBStatus.SelectedItem as Status).ID_status == 3)
                {
                    if (TBSpentTime.Text.Length < 1)
                    {
                        MessageBox.Show("При закрытии - время должно быть указано");
                        return;
                    }
                    date = DateTime.Now;
                    time = Convert.ToInt32(TBSpentTime.Text);
                }
                if (TBComment.Text.Length > 0)
                    comment = TBComment.Text;
                if (CBStatus.SelectedItem != null && CBPrioritet.SelectedItem != null &&
                    CBEmployee.SelectedItem != null && CBTask.SelectedItem != null &&
                    CBTaskSubdivision.SelectedItem != null && TBDescription.Text.Length > 0 &&
                    DPDateStart.SelectedDate != null)
                {
                    if (DPDateEnd.SelectedDate != null)
                        date = DPDateEnd.SelectedDate;
                    taskSchedules.ID_status = (CBStatus.SelectedItem as Status).ID_status;
                    taskSchedules.ID_task = (CBTask.SelectedItem as Models.Tasks).ID_task;
                    taskSchedules.Comment = comment;
                    taskSchedules.Date = Convert.ToDateTime(DPDateStart.SelectedDate);
                    taskSchedules.Deadline = date;
                    taskSchedules.SpentTime = time;
                    taskSchedules.ID_taskSubdivision =
                        (CBTaskSubdivision.SelectedItem as TaskSubdivision).ID_taskSubdivision;
                    taskSchedules.ID_prioritet = (CBPrioritet.SelectedItem as Prioritet).ID_prioritet;
                    taskSchedules.ID_employee = (CBEmployee.SelectedItem as Employee).ID_employee;
                    taskSchedules.Description = TBDescription.Text;
                    DB_connect.db_connect.db.SaveChanges();
                    MessageBox.Show("Успех");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }
            }
        }

        private void CBTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBTask.SelectedItem != null)
            {
                var selected = (CBTask.SelectedItem as Models.Tasks).ID_task;
                CBTaskSubdivision.ItemsSource =
                    DB_connect.db_connect.db.TaskSubdivision.Where(c => c.ID_task == selected).ToList();
            }
        }

        private void CBTaskSubdivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBTaskSubdivision.SelectedItem != null)
            {
                var selected = (CBTaskSubdivision.SelectedItem as TaskSubdivision).ID_subdivision;
                CBEmployee.ItemsSource = DB_connect.db_connect.db.Employee.Where(c=>c.ID_subdivision == selected).ToList();
            }
        }
    }
}
