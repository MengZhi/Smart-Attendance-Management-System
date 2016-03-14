using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.ChangePassword
{
    public partial class Default : PhoneApplicationPage
    {
        public Default()
        {
            InitializeComponent();
        }

        public void ChangePassword()
        {
            string username = (string)PhoneApplicationService.Current.State["UserName"].ToString();
            //ErrorMessage.Text = username;
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();            
            client.ChangePasswordAsync(OldPassword.Password,NewPassword.Password,ReNewPassword.Password,username);
            client.ChangePasswordCompleted += client_ChangePasswordCompleted;
        }
        void client_ChangePasswordCompleted(object sender, ServiceReference1.ChangePasswordCompletedEventArgs e)
        {
           
            if (e.Result.ToString() == "0")
            {
                ErrorMessage.Text = "Your passwords not match";
            }
            else if (e.Result.ToString() == "1")
            {
                //PhoneApplicationService.Current.State["UserName"] = username.Text;
                ErrorMessage.Text = "Your password was changed successfully";
                //PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                //root.Navigate(new Uri("/Login", UriKind.Relative));
            }
            else if (e.Result.ToString() == "2")
            {
                //PhoneApplicationService.Current.State["UserName"] = username.Text;
                ErrorMessage.Text = "Your old password is wrong";
                //PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                //root.Navigate(new Uri("/Login", UriKind.Relative));
            }

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangePassword();
        }
    }
}