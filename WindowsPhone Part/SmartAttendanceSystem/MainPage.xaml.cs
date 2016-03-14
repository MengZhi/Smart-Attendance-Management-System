using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SmartAttendanceSystem.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Phone.Testing;

namespace SmartAttendanceSystem
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        //public void matricnumber()
        //{
        //    SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        //    client.GetDatabaseAsync();
        //    client.GetDatabaseCompleted += client_GetDatabaseCompleted;
        //}

        public void LoginCheck()
        {
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            if (usertype.SelectionBoxItem != null)
                client.CheckLoginAsync(username.Text, password.Password, usertype.SelectionBoxItem.ToString());
            else
                ErrorMessage.Text = "Please choose your user type.";
            client.CheckLoginCompleted += client_CheckLoginCompleted;
        }
        void client_CheckLoginCompleted(object sender, ServiceReference1.CheckLoginCompletedEventArgs e)
        {
            if (e.Result.ToString()=="1")
            {
                PhoneApplicationService.Current.State["UserName"] = username.Text;
                PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                root.Navigate(new Uri("/LecWelcome", UriKind.Relative));            
            }
            else if (e.Result.ToString() == "2")
            {
                PhoneApplicationService.Current.State["UserName"] = username.Text;
                PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                root.Navigate(new Uri("/StuWelcome", UriKind.Relative));
            }
            else if (e.Result.ToString() == "3")
            {
                ErrorMessage.Text = "Wrong username or password.";
            }
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginCheck();
        }

        
    }
}