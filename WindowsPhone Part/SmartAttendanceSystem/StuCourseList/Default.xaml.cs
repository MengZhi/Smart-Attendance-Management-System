using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace SmartAttendanceSystem.StuCourseList
{
    public partial class Default : PhoneApplicationPage
    {
        //List<User> userList = new List<User>();
        public Default()
        {
            InitializeComponent();
            //GetBasic();
            //DataContext = App.;
            GetStuCourseList();
        }

        
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (CourseList.SelectedItem == null)
                return;

            var mySelectedItem = CourseList.SelectedItem as CourseListClass;

            PhoneApplicationService.Current.State["CourseCode"] = mySelectedItem.courseCode;
            PhoneApplicationService.Current.State["CourseName"] = mySelectedItem.courseName;
            PhoneApplicationService.Current.State["TeachingYear"] = mySelectedItem.teachingYear;
            PhoneApplicationService.Current.State["Semester"] = mySelectedItem.semester;
            
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/StuCourseList", UriKind.Relative));

            // Reset selected item to null (no selection)
            CourseList.SelectedItem = null;
           
        }


        public void GetStuCourseList()
        {
            string StuEmail = (string)PhoneApplicationService.Current.State["UserName"];
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetStudentCourseListAsync(StuEmail);
            client.GetStudentCourseListCompleted+=client_GetStudentCourseListCompleted;
        }
        




        public void client_GetStudentCourseListCompleted(object sender, ServiceReference1.GetStudentCourseListCompletedEventArgs e)
        {
            List<CourseListClass> userList = new List<CourseListClass>();
            try{
            
                var lsdCourseList = e.Result.ToList();
                //List<User> userList = new List<User>();


                foreach (var userData in lsdCourseList)
                {
                    CourseListClass courseListObj = new CourseListClass();
                    courseListObj.riid = userData[0].ToString();
                    courseListObj.courseCode = userData[1].ToString();
                    courseListObj.courseName = userData[2].ToString();
                    courseListObj.teachingYear = userData[3].ToString();
                    courseListObj.semester = userData[4].ToString();

                    userList.Add(courseListObj);
                }
                //Binding Data to the userListBox
                CourseList.ItemsSource = userList;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }

        }
    }
       
    
        //}

    public class CourseListClass
    {

        private string RIId;
        private string CourseCode;
        private string CourseName;
        private string TeachingYear;
        private string Semester;



        public string riid
        {
            get
            {
                return RIId;
            }
            set
            {
                RIId = value;
            }
        }

        public string courseCode
        {
            get
            {
                return CourseCode;
            }
            set
            {
                CourseCode = value;
            }
        }
        public string courseName
        {
            get
            {
                return CourseName;
            }
            set
            {
                CourseName = value;
            }
        }

        public string teachingYear
        {
            get
            {
                return TeachingYear;
            }
            set
            {
                TeachingYear = value;
            }
        }

        public string semester
        {
            get
            {
                return Semester;
            }
            set
            {
                Semester = value;
            }
        }
    }
}