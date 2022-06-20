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
using SIAN.Views.AnalitikViews;
using SIAN.Views.PersonalAccount;

namespace SIAN.Views.ProjectManagerViews
{
    /// <summary>
    /// Логика взаимодействия для ProjectManagerWindow.xaml
    /// </summary>
    public partial class ProjectManagerWindow : Window
    {
        
        public ProjectManagerWindow()
        {
            InitializeComponent();
            RBStatiscikPage.IsChecked = true;
        }

        private void BTCloseApp_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BTMAximazeApp_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                
            }
            else this.WindowState = WindowState.Maximized;
        }

        private void BTMinimazeApp_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void RBStatiscikPage_OnChecked(object sender, RoutedEventArgs e)
        {
            if (RBStatiscikPage.IsChecked == true)
                FrameContent.NavigationService.Navigate(new StatistikPage());
        }

        private void RBEmployeePage_OnChecked(object sender, RoutedEventArgs e)
        {
            if (RBEmployeePage.IsChecked == true)
                FrameContent.NavigationService.Navigate(new EmployeePage());
        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void RBKabinet_OnChecked(object sender, RoutedEventArgs e)
        {
            PersonalAccountWindow PAW = new PersonalAccountWindow();
            PAW.ShowDialog();
            RBStatiscikPage.IsChecked = true;
        }

        private void RBActualTasks_OnChecked(object sender, RoutedEventArgs e)
        {
            if (RBActualTasks.IsChecked == true)
                FrameContent.NavigationService.Navigate(new ActualTaskPage());
        }
    }
}
