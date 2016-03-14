using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Globalization;

namespace SmartAttendanceSystem.StuClassList
{
    public partial class Default : PhoneApplicationPage
    {

        string StuEmail = (string)PhoneApplicationService.Current.State["UserName"];
        string StuCourseName = (string)PhoneApplicationService.Current.State["CourseName"];
        string StuCourseCode = (string)PhoneApplicationService.Current.State["CourseCode"];
        string StuTeachingYear = (string)PhoneApplicationService.Current.State["TeachingYear"];
        string StuSemester = (string)PhoneApplicationService.Current.State["Semester"];

        public Default()
        {
            InitializeComponent();
            CourseCode.Text ="Course Code: "+ (string)PhoneApplicationService.Current.State["CourseCode"];
            CourseName.Text ="Course Name: "+ (string)PhoneApplicationService.Current.State["CourseName"];
            TeachingYear.Text ="Teaching Year: "+ (string)PhoneApplicationService.Current.State["TeachingYear"];
            Semester.Text ="Semester: "+ (string)PhoneApplicationService.Current.State["Semester"];
            GetStuClassList();
        }

        public void GetStuClassList()
        {
            

            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetStudentClassListAsync(StuEmail, StuSemester, StuTeachingYear, StuCourseCode);
            client.GetStudentClassListCompleted += client_GetStudentClassListCompleted;
        }


        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (ClassList.SelectedItem == null)
                return;


            var mySelectedItem = ClassList.SelectedItem as ClassListClass;
            string ordate = mySelectedItem.classdate.ToString();          
            PhoneApplicationService.Current.State["ClassDate"] = ordate;           

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/StuClassList", UriKind.Relative));

            // Reset selected item to null (no selection)
            ClassList.SelectedItem = null;

        }


        public void client_GetStudentClassListCompleted(object sender, ServiceReference1.GetStudentClassListCompletedEventArgs e)
        {
            List<ClassListClass> userList = new List<ClassListClass>();
            try
            {

                var lsdClassList = e.Result.ToList();
                //List<User> userList = new List<User>();


                foreach (var userData in lsdClassList)
                {
                    ClassListClass classListObj = new ClassListClass();
                    classListObj.classdate = userData[1].ToString();
                    classListObj.attendancestatus = userData[2].ToString();
                    classListObj.starttime = userData[3].ToString();
                    classListObj.endtime = userData[4].ToString();
                    

                    userList.Add(classListObj);
                }
                //Binding Data to the userListBox
                ClassList.ItemsSource = userList;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }

        }
    }

    public class ClassListClass
    {

        private string ClassDate;
        private string AttendanceStatus;
        private string StartTime;
        private string EndTime;
        //private string Semester;



        public string classdate
        {
            get
            {
                return ClassDate;
            }
            set
            {
                ClassDate = value;
            }
        }

        public string attendancestatus
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
        public string starttime
        {
            get
            {
                return StartTime;
            }
            set
            {
                StartTime = value;
            }
        }

        public string endtime
        {
            get
            {
                return EndTime;
            }
            set
            {
                EndTime = value;
            }
        }
    }
}