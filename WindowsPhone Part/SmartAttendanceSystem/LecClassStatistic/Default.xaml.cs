using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.LecClassStatistic
{
    public partial class Default : PhoneApplicationPage
    {
        string SClassDate = (string)PhoneApplicationService.Current.State["ClassDate"];
        string SCourseName = (string)PhoneApplicationService.Current.State["CourseName"];
        string SCourseCode = (string)PhoneApplicationService.Current.State["CourseCode"];
        string STeachingYear = (string)PhoneApplicationService.Current.State["TeachingYear"];
        string SSemester = (string)PhoneApplicationService.Current.State["Semester"];


        public Default()
        {
            InitializeComponent();
            GetClassStatic();
        }

        public void GetClassStatic()
        {
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetClassStatisticInfoAsync(SSemester, STeachingYear, SCourseCode, SClassDate);
            client.GetClassStatisticInfoCompleted += client_GetClassStatisticInfoCompleted;
        }

        void client_GetClassStatisticInfoCompleted(object sender, ServiceReference1.GetClassStatisticInfoCompletedEventArgs e)
        {
            string[] ClassSummary = e.Result.ToArray();

            CourseName.Text = SCourseName;
            CourseCode.Text = SCourseCode;
            TeachingYear.Text = STeachingYear;
            Semester.Text = SSemester;
            ClassDate.Text = SClassDate;
            SutdentNum.Text=ClassSummary[0];
            AttendStudentNum.Text = ClassSummary[1];
            AttendStudentPer.Text=ClassSummary[4];
            IncomStuNum.Text = ClassSummary[2];
            IncomPer.Text=ClassSummary[5];
            AbsStuNum.Text=ClassSummary[3];
            AbsPer.Text = ClassSummary[6];
        }


    }
}