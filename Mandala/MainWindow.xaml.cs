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
using CefSharp;
using CefSharp.Wpf;
using System.Windows.Controls;

namespace Mandala
{
    public partial class MainWindow : Window
    {
        string StateOfWindows = null;

        ChromiumWebBrowser browser;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBrowser();
        }
        public void InitializeBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser();

            browser.LoadUrl("");
            tabItem1.Content = browser;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePage.Visibility = Visibility.Visible;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            browser.Back();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            browser.Forward();
            HomePage.Visibility = Visibility.Hidden;
        }
        private void btnAddTab_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnResize_Click(object sender, RoutedEventArgs e)
        {
            ResizeWindow();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addressBar_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                {
                    browser.LoadUrl(addressBar.Text);
                    HomePage.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResizeWindow();
        }

        private void ResizeWindow()
        {
            if (StateOfWindows == null || StateOfWindows == "Normal")
            {
                this.WindowState = WindowState.Maximized;
                StateOfWindows = "Maximized";
            }
            else if (StateOfWindows == "Maximized")
            {
                this.WindowState = WindowState.Normal;
                Height = 600;
                Width = 920;
                StateOfWindows = "Normal";
            }
        }

    }

}
