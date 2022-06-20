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
    /// Логика взаимодействия для TaskEditAndAddWindow.xaml
    /// </summary>
    public partial class TaskEditAndAddWindow : Window
    {
        Models.Tasks tasks;
        public TaskEditAndAddWindow()
        {
            InitializeComponent();
            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            CBStatus.SelectedIndex = 0;
            DPDateStart.SelectedDate = DateTime.Now;
        }
        public TaskEditAndAddWindow(Models.Tasks task)
        {
            InitializeComponent();
            tasks = task;
            this.DataContext = this;
            TBDescription.Text = tasks.Description;
            TBPrimaryGoal.Text = tasks.Primary_goal;
            CBStatus.ItemsSource = DB_connect.db_connect.db.Status.ToList();
            CBStatus.SelectedItem = tasks.Status;
            DPDateStart.SelectedDate = tasks.BeginningOfWork;
            if (tasks.EndOfWork != null)
                DPDateEnd.SelectedDate = tasks.EndOfWork;
            if (tasks.AllSpentTime != null)
                TBAllTime.Text = tasks.AllSpentTime.ToString();
        }

        private void BTSave_OnClick(object sender, RoutedEventArgs e)
        {
            int? summaTime = null;
            int? allTime;
            DateTime? dateTimeEnd = null;
            if (tasks == null)
            {
                if (TBDescription.Text.Length > 0 && TBPrimaryGoal.Text.Length > 0 && CBStatus.SelectedItem != null &&
                    DPDateStart.SelectedDate != null)
                {
                    if (TBAllTime.Text.Length < 1)
                        allTime = null;
                    else allTime = Convert.ToInt32(TBAllTime.Text);

                    if (DPDateEnd.SelectedDate != null)
                        dateTimeEnd = DPDateEnd.SelectedDate;


                    DB_connect.db_connect.db.Tasks.Add(new Models.Tasks()
                    {
                        Description = TBDescription.Text,
                        Primary_goal = TBPrimaryGoal.Text,
                        AllSpentTime = allTime,
                        BeginningOfWork = Convert.ToDateTime(DPDateStart.SelectedDate),
                        EndOfWork = dateTimeEnd,
                        ID_status = (CBStatus.SelectedItem as Status).ID_status

                    });
                    DB_connect.db_connect.db.SaveChanges();
                    MessageBox.Show("Успех!");
                    this.Close();
                }
                else MessageBox.Show("Заполните все поля");
            }

            if (tasks != null)
            {
                if ((CBStatus.SelectedItem as Status).ID_status == 3 
                     && TBAllTime.Text.Length<1)
                {
                    var listTaskSubdivision = DB_connect.db_connect.db.TaskSubdivision
                        .Where(c => c.ID_task == tasks.ID_task).ToList();

                    var listTaskSubdivisionProverka =
                        listTaskSubdivision.Where(c => c.ID_status == 2 || c.ID_status == 1).FirstOrDefault();

                    if (listTaskSubdivisionProverka == null)
                    {
                        var listSpentTime = listTaskSubdivision.Where(c => c.ID_status == 3);
                        summaTime = 0;
                        foreach (var summ in listTaskSubdivision.Where(c => c.ID_status == 3).ToList())
                        {
                            summaTime = summaTime + summ.SpentTime;
                        }
                        dateTimeEnd = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Не все задания закрыты, что бы высчитать");
                        return;
                    }
                }
                else
                {
                    if (TBAllTime.Text.Length > 0)
                        summaTime = Convert.ToInt32(TBAllTime.Text);
                }
                

                if (TBDescription.Text.Length > 0 && TBPrimaryGoal.Text.Length > 0 && CBStatus.SelectedItem != null &&
                    DPDateStart.SelectedDate != null)
                {
                    if (DPDateEnd.SelectedDate != null)
                        dateTimeEnd = DPDateEnd.SelectedDate;

                    tasks.ID_status = (CBStatus.SelectedItem as Status).ID_status;
                    tasks.AllSpentTime = summaTime;
                    tasks.Description = TBDescription.Text;
                    tasks.Primary_goal = TBPrimaryGoal.Text;
                    tasks.BeginningOfWork = Convert.ToDateTime(DPDateStart.SelectedDate);
                    tasks.EndOfWork = dateTimeEnd;
                    DB_connect.db_connect.db.SaveChanges();
                    MessageBox.Show("Успех!");
                    this.Close();
                }
            }
            
        }
    }
}
