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
    /// Логика взаимодействия для TaskSubdivisionEditAndAddWindow.xaml
    /// </summary>
    public partial class TaskSubdivisionEditAndAddWindow : Window
    {
        TaskSubdivision taskSubdivisions;
        public TaskSubdivisionEditAndAddWindow()
        {
            InitializeComponent();
            DPDate.SelectedDate = DateTime.Now;
            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            CBStatus.SelectedIndex = 0;
            CBSubdivision.ItemsSource = DB_connect.db_connect.db.Subdivision.ToList();

            CBTask.ItemsSource = DB_connect.db_connect.db.Tasks.Where(c=>c.ID_status == 1).ToList();
        }

        public TaskSubdivisionEditAndAddWindow(TaskSubdivision taskSubdivision)
        {
            InitializeComponent();
            taskSubdivisions = taskSubdivision;
            this.DataContext = this;

            TBDescription.Text = taskSubdivisions.Description;
            
            if (taskSubdivisions.SpentTime !=null)
                TBSpentTime.Text = taskSubdivisions.SpentTime.ToString();
            if (taskSubdivisions.Date !=null)
                DPDate.SelectedDate = taskSubdivisions.Date;

            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            CBStatus.SelectedItem = taskSubdivisions.Status;

            CBSubdivision.ItemsSource = DB_connect.db_connect.db.Subdivision.ToList();
            CBSubdivision.SelectedItem = taskSubdivisions.Subdivision;

            CBTask.ItemsSource = DB_connect.db_connect.db.Tasks.ToList();
            CBTask.SelectedItem = taskSubdivisions.Tasks;
        }

        private void BTSave_OnClick(object sender, RoutedEventArgs e)
        {
            int? time = null;
            DateTime? date = null;
            int? summaTime = null;
            if (taskSubdivisions == null)
            {
                if (TBDescription.Text.Length > 0 && CBStatus.SelectedItem != null &&
                    CBSubdivision.SelectedItem != null && CBTask.SelectedItem != null)
                {
                    if (DPDate.SelectedDate != null)
                        date = DPDate.SelectedDate;
                    if (TBSpentTime.Text.Length > 0)
                        time = Convert.ToInt32(TBSpentTime.Text);
                    DB_connect.db_connect.db.TaskSubdivision.Add(new TaskSubdivision()
                    {
                        Description = TBDescription.Text,
                        ID_status = (CBStatus.SelectedItem as Status).ID_status,
                        ID_subdivision = (CBSubdivision.SelectedItem as Subdivision).ID_subdivision,
                        ID_task = (CBTask.SelectedItem as Models.Tasks).ID_task,
                        Date = date,
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
                if ((CBStatus.SelectedItem as Status).ID_status == 3
                    && TBSpentTime.Text.Length < 1)
                {
                    var selectedTask = DB_connect.db_connect.db.TaskSchedule
                        .Where(c => c.ID_taskSubdivision == taskSubdivisions.ID_taskSubdivision).ToList();
                    var chekced = selectedTask.Where(c => c.ID_status == 2 || c.ID_status == 1).FirstOrDefault();
                    if (chekced == null)
                    {
                        var listSpentTime = selectedTask.Where(c => c.ID_status == 3);
                        summaTime = 0;
                        foreach (var summ in selectedTask.Where(c => c.ID_status == 3).ToList())
                        {
                            summaTime = summaTime + summ.SpentTime;
                        }
                        date = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Не все задания закрыты, чтобы высчитать");
                        return;
                    }

                }
                else
                {
                    if (TBSpentTime.Text.Length > 0)
                    summaTime = Convert.ToInt32(TBSpentTime.Text);

                }

                if (TBDescription.Text.Length > 0 && CBStatus.SelectedItem != null &&
                    CBSubdivision.SelectedItem != null && CBTask.SelectedItem != null)
                {
                    if (DPDate.SelectedDate != null)
                        date = DPDate.SelectedDate;
                    
                    taskSubdivisions.Description = TBDescription.Text;
                    taskSubdivisions.Date = date;
                    taskSubdivisions.ID_status = (CBStatus.SelectedItem as Status).ID_status;
                    taskSubdivisions.ID_task = (CBTask.SelectedItem as Models.Tasks).ID_task;
                    taskSubdivisions.ID_subdivision = (CBSubdivision.SelectedItem as Subdivision).ID_subdivision;
                    taskSubdivisions.SpentTime = summaTime;
                    DB_connect.db_connect.db.SaveChanges();
                    MessageBox.Show("Успех!");
                    this.Close();
                }
            }
        }
    }
}

