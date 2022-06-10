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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIAN.Views.EmployeeViews
{
    /// <summary>
    /// Логика взаимодействия для ActualTasks.xaml
    /// </summary>
    public partial class ActualTasks : Page
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public ActualTasks()
        {
            InitializeComponent();
            timer.Interval = 30000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        /// <summary>
        /// Обновление из бд каждые n секунд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

        }
    }
}
