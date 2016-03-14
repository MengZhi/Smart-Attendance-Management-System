using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.LecStuMovement
{
    public partial class Default : PhoneApplicationPage
    {
        
        string ClassDate = (string)PhoneApplicationService.Current.State["ClassDate"];
        string StuCourseCode = (string)PhoneApplicationService.Current.State["CourseCode"];
        string StuTeachingYear = (string)PhoneApplicationService.Current.State["TeachingYear"];
        string StuSemester = (string)PhoneApplicationService.Current.State["Semester"];
        string StudentName = (string)PhoneApplicationService.Current.State["StudentName"];
        string MatricNum = (string)PhoneApplicationService.Current.State["MatricNumber"];

        public Default()
        {
            InitializeComponent();
            StuName.Text = StudentName;
            MatricNumber.Text = MatricNum;
            LecGetStudentMovementList();
            GetClassSummary();
        }
        public void GetClassSummary()
        {
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetSummary2Async(MatricNum, StuSemester, StuTeachingYear, StuCourseCode, ClassDate);
            client.GetSummary2Completed += client_GetSummary2Completed;
        }
        public void client_GetSummary2Completed(object sender, ServiceReference1.GetSummary2CompletedEventArgs e)
        {
            summary.Text = e.Result.ToString();

        }

        public void LecGetStudentMovementList()
        {


            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.LecGetStudentMovementAsync(MatricNum, StuSemester, StuTeachingYear, StuCourseCode, ClassDate);
            client.LecGetStudentMovementCompleted += client_LecGetStudentMovementCompleted;
        }
        public void client_LecGetStudentMovementCompleted(object sender, ServiceReference1.LecGetStudentMovementCompletedEventArgs e)
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