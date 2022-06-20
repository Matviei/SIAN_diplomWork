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

namespace SIAN.Views.AnalitikViews
{
    /// <summary>
    /// Логика взаимодействия для AnalitikWindow.xaml
    /// </summary>
    public partial class AnalitikWindow : Window
    {
        public AnalitikWindow()
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
            FrameContent.NavigationService.Navigate(new ActualTaskPage());
        }
    }
}
