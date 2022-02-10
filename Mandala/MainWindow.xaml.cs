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

namespace Mandala
{
    public partial class MainWindow : Window
    {
        ChromiumWebBrowser browser;
        public MainWindow()
        {
            InitializeComponent();
            InitializeBrowser();
        }
        public void InitializeBrowser()
        {
            browser = new ChromiumWebBrowser();
            browser.LoadUrl("https://google.com");
            tabItem1.Content = browser;

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            browser.LoadUrl(adressBar.Text);
        }

        private void adressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                browser.LoadUrl(adressBar.Text);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            browser.Back();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            browser.Forward();
        }
    }
}
