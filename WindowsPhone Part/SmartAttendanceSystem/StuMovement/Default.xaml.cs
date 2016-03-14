using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.StuMovement
{
    public partial class Default : PhoneApplicationPage
    {
        string StuEmail = (string)PhoneApplicationService.Current.State["UserName"];
        string ClassDate = (string)PhoneApplicationService.Current.State["ClassDate"];
        string StuCourseCode = (string)PhoneApplicationService.Current.State["CourseCode"];
        string StuTeachingYear = (string)PhoneApplicationService.Current.State["TeachingYear"];
        string StuSemester = (string)PhoneApplicationService.Current.State["Semester"];

       

        public Default()
        {
            InitializeComponent();
            
            GetMovementStatusList();
            GetClassSummary();
        }

        public void GetMovementStatusList()
        {


            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetStudentMovementAsync(StuEmail, StuSemester, StuTeachingYear, StuCourseCode,ClassDate);
            client.GetStudentMovementCompleted += client_GetStudentMovementCompleted;
        }


        

        public void client_GetStudentMovementCompleted(object sender, ServiceReference1.GetStudentMovementCompletedEventArgs e)
        {
            List<MovementListClass> userList = new List<MovementListClass>();
            try
            {

                var lsdMovementList = e.Result.ToList();
                //List<User> userList = new List<User>();


                foreach (var userData in lsdMovementList)
                {
                    MovementListClass MovementListObj = new MovementListClass();
                    MovementListObj.movementStatus = userData[0].ToString();
                    MovementListObj.timeRecord = userData[1].ToString();

                    userList.Add(MovementListObj);
                }
                //Binding Data to the userListBox
                MovementList.ItemsSource = userList;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }

        }

        public void GetClassSummary()
        {
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetSummaryAsync(StuEmail, StuSemester, StuTeachingYear, StuCourseCode, ClassDate);
            client.GetSummaryCompleted += client_GetSummaryCompleted;
        }
        public void client_GetSummaryCompleted(object sender, ServiceReference1.GetSummaryCompletedEventArgs e)
        {
            summary.Text = e.Result.ToString();

        }

    }

    public class MovementListClass
    {

        private string MovementStatus;
        private string TimeRecord;

        public string movementStatus
        {
            get
            {
                return MovementStatus;
            }
            set
            {
                MovementStatus = value;
            }
        }

        public string timeRecord
        {
            get
            {
                return TimeRecord;
            }
            set
            {
                TimeRecord = value;
            }
        }
    }

}