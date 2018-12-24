using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TetrisMetro
{
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("title"))
            {
                lblTitle.Text = NavigationContext.QueryString["title"].ToString();
            }

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }
    }
}