using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Data;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using SmartAttendanceSystem.ServiceReference1;

namespace SmartAttendanceSystem.ForgetPassword
{
    public partial class Default : PhoneApplicationPage
    {
        public Default()
        {
            InitializeComponent();
        }

        
        


        public void ForgetPassword()
        {
            Service1Client proxy = new Service1Client();
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.ForgetPasswordAsync(UserName.Text, UserNumber.Text);
            client.ForgetPasswordCompleted += client_ForgetPasswordCompleted;
        }
        void client_ForgetPasswordCompleted(object sender, ServiceReference1.ForgetPasswordCompletedEventArgs e)
        {
            if (e.Result.ToString() == "1")
            {
                ErrorMessage.Text = "Your password changed succesfully";
                //PhoneApplicationService.Current.State["UserName"] = username.Text;
                //PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                //root.Navigate(new Uri("/Login", UriKind.Relative));
            }
            else if (e.Result.ToString() == "2")
            {
                //PhoneApplicationService.Current.State["UserName"] = username.Text;
                ErrorMessage.Text = "Your matric/stuff number and/or E-mail address have error";
                //PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                //root.Navigate(new Uri("/Login", UriKind.Relative));
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ForgetPassword();
            //
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
            //root.Navigate(new Uri("/MainPage", UriKind.Relative));
        }
    }
}