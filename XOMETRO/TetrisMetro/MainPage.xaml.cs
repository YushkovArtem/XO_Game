using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Resources;

namespace TetrisMetro
{    

    public partial class MainPage : PhoneApplicationPage
    {
        public string programName { get { return "МОЕ ПРИЛОЖЕНИЕ"; } }

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGoToGame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePage.xaml?title=" + Uri.EscapeDataString(programName), UriKind.Relative));
        }

        private void btnGoToHelp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml?title=" + Uri.EscapeDataString(programName), UriKind.Relative));
        }
    }
}