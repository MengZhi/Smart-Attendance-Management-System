using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.LecWelcome
{
    public partial class Default : PhoneApplicationPage
    {
        public Default()
        {
            InitializeComponent();
            LecInfo();
            //UserInfo.Text = "Welcome : " + (string)PhoneApplicationService.Current.State["UserName"];
        }
        public void LecInfo()
        {
            string LecEmail = (string)PhoneApplicationService.Current.State["UserName"];
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetBasicInfoLecAsync(LecEmail);
            client.GetBasicInfoLecCompleted += client_GetBasicInfoLecCompleted;
        }
        void client_GetBasicInfoLecCompleted(object sender, ServiceReference1.GetBasicInfoLecCompletedEventArgs e)
        {
            var LecInfoArray = e.Result.ToArray();
            UserInfo.Text = "Welcome: "+ (string)PhoneApplicationService.Current.State["UserName"]+"\nStaff Name: " + LecInfoArray[0] + "\n" + "Staff No.: " + LecInfoArray[1];
        }

        
    }
}