using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.LecStuAttendance
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
            GetStuAttendanceList();
        }
        public void GetStuAttendanceList()
        {


            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetLecStudentAttendanceAsync(StuTeachingYear, StuSemester, StuCourseCode, ClassDate);
            client.GetLecStudentAttendanceCompleted += client_GetLecStudentAttendanceCompleted;
        }


        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (StudentAttendance.SelectedItem == null)
                return;

            var mySelectedItem = StudentAttendance.SelectedItem as StdentListClass;
            PhoneApplicationService.Current.State["StudentName"] = mySelectedItem.firstName + " " + mySelectedItem.lastName;
            PhoneApplicationService.Current.State["MatricNumber"] = mySelectedItem.matricNumber;

            NavigationService.Navigate(new Uri("/StuMovement", UriKind.Relative));

            // Reset selected item to null (no selection)
            StudentAttendance.SelectedItem = null;

        }
        public void client_GetLecStudentAttendanceCompleted(object sender, ServiceReference1.GetLecStudentAttendanceCompletedEventArgs e)
        {
            List<StdentListClass> userList = new List<StdentListClass>();
            try
            {

                var lsdStdentList = e.Result.ToList();
                //List<User> userList = new List<User>();


                foreach (var userData in lsdStdentList)
                {
                    StdentListClass StdentListObj = new StdentListClass();
                    StdentListObj.firstName = userData[0].ToString();
                    StdentListObj.lastName = userData[1].ToString();
                    StdentListObj.matricNumber = userData[2].ToString();
                    StdentListObj.attendanceStatus = userData[3].ToString();

                    userList.Add(StdentListObj);
                }
                //Binding Data to the userListBox
                StudentAttendance.ItemsSource = userList;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri("/LecStatistic", UriKind.Relative));
        }
    }
    public class StdentListClass
    {

        private string FirstName;
        private string LastName;
        private string MatricNumber;
        private string AttendanceStatus;

        public string firstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }

        public string lastName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }
        public string matricNumber
        {
            get
            {
                return MatricNumber;
            }
            set
            {
                MatricNumber = value;
            }
        }

        public string attendanceStatus
        {
            get
            {
                return AttendanceStatus;
            }
            set
            {
                AttendanceStatus = value;
            }
        }
    }
}