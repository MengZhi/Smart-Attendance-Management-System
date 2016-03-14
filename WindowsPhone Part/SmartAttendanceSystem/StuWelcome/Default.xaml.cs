using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.StuWelcome
{
    public partial class Default : PhoneApplicationPage
    {
        public Default()
        {
            InitializeComponent();
            StuInfo();
            //UserName.Text = "Welcome : " + (string)PhoneApplicationService.Current.State["UserName"];
        }

        public void StuInfo()
        {
            string StuEmail = (string)PhoneApplicationService.Current.State["UserName"];
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetBasicInfoStuAsync(StuEmail);
            client.GetBasicInfoStuCompleted += client_GetBasicInfoStuCompleted;
        }
        void client_GetBasicInfoStuCompleted(object sender, ServiceReference1.GetBasicInfoStuCompletedEventArgs e)
        {
            var LecInfoArray = e.Result.ToArray();
            UserInfo.Text = "Welcome: " + (string)PhoneApplicationService.Current.State["UserName"] + "\nStudent Name: " + LecInfoArray[0] + "\n" + "Student No.: " + LecInfoArray[1];
        }
    }
}