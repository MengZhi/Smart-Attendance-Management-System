using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SmartAttendanceSystem.LecClassList
{
    public partial class Default : PhoneApplicationPage
    {
        string LecEmail = (string)PhoneApplicationService.Current.State["UserName"];
        string LecCourseName = (string)PhoneApplicationService.Current.State["CourseName"];
        string LecCourseCode = (string)PhoneApplicationService.Current.State["CourseCode"];
        string LecTeachingYear = (string)PhoneApplicationService.Current.State["TeachingYear"];
        string LecSemester = (string)PhoneApplicationService.Current.State["Semester"];

        public Default()
        {
            InitializeComponent();
            CourseCode.Text = "Course Code: " + (string)PhoneApplicationService.Current.State["CourseCode"];
            CourseName.Text = "Course Name: " + (string)PhoneApplicationService.Current.State["CourseName"];
            TeachingYear.Text = "Teaching Year: " + (string)PhoneApplicationService.Current.State["TeachingYear"];
            Semester.Text = "Semester: " + (string)PhoneApplicationService.Current.State["Semester"];
            GetLecClassList();
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
            NavigationService.Navigate(new Uri("/LecClassList", UriKind.Relative));

            // Reset selected item to null (no selection)
            ClassList.SelectedItem = null;

        }
        public void GetLecClassList()
        {
            SmartAttendanceSystem.ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.GetLecturerClassListAsync(LecSemester, LecTeachingYear, LecCourseCode);
            client.GetLecturerClassListCompleted += client_GetLecturerClassListCompleted;
        }



        public void client_GetLecturerClassListCompleted(object sender, ServiceReference1.GetLecturerClassListCompletedEventArgs e)
        {
            List<ClassListClass> userList = new List<ClassListClass>();
            try
            {

                var lsdClassList = e.Result.ToList();
                //List<User> userList = new List<User>();


                foreach (var userData in lsdClassList)
                {
                    ClassListClass classListObj = new ClassListClass();
                    classListObj.buildingNumber = userData[1].ToString();
                    classListObj.roomNumber = userData[2].ToString();
                    classListObj.classdate = userData[3].ToString();
                    classListObj.starttime = userData[4].ToString();
                    classListObj.endtime = userData[5].ToString();
                    

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
        private string BuildingNumber;
        private string RoomNumber;        
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

        public string buildingNumber
        {
            get
            {
                return BuildingNumber;
            }
            set
            {
                BuildingNumber = value;
            }
        }
        public string roomNumber
        {
            get
            {
                return RoomNumber;
            }
            set
            {
                RoomNumber = value;
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