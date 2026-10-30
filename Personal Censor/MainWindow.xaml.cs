using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Personal_Censor
{
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point offset;
        private double mouseWheelSensitivity = 0.1; //opacity too much and too little? change here!
        public MainWindow()
        {
            //InitializeComponent();
            //this.PreviewMouseWheel += Grid_PreviewMouseWheel; LLM said to add this here, but it doesn't seem to do anything?
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            offset = e.GetPosition(this);
        }
        
        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPos = e.GetPosition(this);
                this.Left += currentPos.X - offset.X;
                this.Top += currentPos.Y - offset.Y;
            }
        }

        private void Grid_TitleMouseDown(object sender, MouseEventArgs e)
        {
            titleText.Visibility = Visibility.Hidden; //might be useful???
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel.Visibility = panel.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        private void BorderlessButton_Click(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Hidden;
        }

        private void Grid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0 && mainGrid.Opacity > mouseWheelSensitivity * 2)
            {
                mainGrid.Opacity -= mouseWheelSensitivity;
            }
            else if (e.Delta > 0 && mainGrid.Opacity < 1)
            {
                mainGrid.Opacity += mouseWheelSensitivity;
            }
            //e.Handled = true; idk
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e) // Title Bar Button
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
