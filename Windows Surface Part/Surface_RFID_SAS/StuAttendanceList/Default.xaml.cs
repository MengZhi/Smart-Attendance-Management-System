﻿using Surface_RFID_SAS.Common;
using Surface_RFID_SAS.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace Surface_RFID_SAS.StuAttendanceList
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for
    /// the currently selected item.
    /// </summary>
    public sealed partial class Default : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public Default()
        {
            this.InitializeComponent();

            // Setup the navigation helper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            // Setup the logical page navigation components that allow
            // the page to only show one pane at a time.
            this.navigationHelper.GoBackCommand = new Surface_RFID_SAS.Common.RelayCommand(() => this.GoBack(), () => this.CanGoBack());
            this.CourseList.SelectionChanged += itemListView_SelectionChanged;

            // Start listening for Window size changes 
            // to change from showing two panes to showing a single pane
            Window.Current.SizeChanged += Window_SizeChanged;
            this.InvalidateVisualState();
            GetStuCourseList();
        }

        void ItemListView_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation())
            {
                this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
            }
            var mySelectedItem = CourseList.SelectedItem as CourseListClass;

            Windows.Storage.ApplicationData.Current.LocalSettings.Values["CourseCode"] = mySelectedItem.courseCode;
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["CourseName"] = mySelectedItem.courseName;
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["TeachingYear"] = mySelectedItem.teachingYear;
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["Semester"] = mySelectedItem.semester;
            GetStuClassList();
        }
        void ItemListView_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation())
            {
                this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
            }
            var mySelectedItem = ClassList.SelectedItem as ClassListClass;
            string ordate = mySelectedItem.classdate.ToString();
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["ClassDate"] = ordate;
           
            this.Frame.Navigate(typeof(StuMovement.Default));
        }
        void itemListView_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();
        }

        public void GetStuCourseList()
        {
            Service1Client proxy = new Service1Client();
            string StuEmail = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["UserName"];

            var lsdCourseList = proxy.GetStudentCourseListAsync(StuEmail).Result.ToList();
            
        
            List<CourseListClass> userList = new List<CourseListClass>();
            try
            {
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

        public void GetStuClassList()
        {
            Service1Client proxy = new Service1Client();
            string StuEmail = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["UserName"];
            string StuCourseName = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["CourseName"];
            string StuCourseCode = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["CourseCode"];
            string StuTeachingYear = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["TeachingYear"];
            string StuSemester = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["Semester"];

            var lsdClassList = proxy.GetStudentClassListAsync(StuEmail, StuSemester, StuTeachingYear, StuCourseCode).Result.ToList();
           
            List<ClassListClass> userList = new List<ClassListClass>();
            try
            {               
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
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Assign a bindable group to Me.DefaultViewModel("Group")
            // TODO: Assign a collection of bindable items to Me.DefaultViewModel("Items")

            if (e.PageState == null)
            {
                // When this is a new page, select the first item automatically unless logical page
                // navigation is being used (see the logical page navigation #region below.)
                if (!this.UsingLogicalPageNavigation() && this.itemsViewSource.View != null)
                {
                    this.itemsViewSource.View.MoveCurrentToFirst();
                }
            }
            else
            {
                // Restore the previously saved state associated with this page
                if (e.PageState.ContainsKey("SelectedItem") && this.itemsViewSource.View != null)
                {
                    // TODO: Invoke Me.itemsViewSource.View.MoveCurrentTo() with the selected
                    //       item as specified by the value of pageState("SelectedItem")

                }
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            if (this.itemsViewSource.View != null)
            {
                // TODO: Derive a serializable navigation parameter and assign it to
                //       pageState("SelectedItem")

            }
        }

        #region Logical page navigation

        // The split page isdesigned so that when the Window does have enough space to show
        // both the list and the dteails, only one pane will be shown at at time.
        //
        // This is all implemented with a single physical page that can represent two logical
        // pages.  The code below achieves this goal without making the user aware of the
        // distinction.

        private const int MinimumWidthForSupportingTwoPanes = 768;

        /// <summary>
        /// Invoked to determine whether the page should act as one logical page or two.
        /// </summary>
        /// <returns>True if the window should show act as one logical page, false
        /// otherwise.</returns>
        private bool UsingLogicalPageNavigation()
        {
            return Window.Current.Bounds.Width < MinimumWidthForSupportingTwoPanes;
        }

        /// <summary>
        /// Invoked with the Window changes size
        /// </summary>
        /// <param name="sender">The current Window</param>
        /// <param name="e">Event data that describes the new size of the Window</param>
        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            this.InvalidateVisualState();
        }

        /// <summary>
        /// Invoked when an item within the list is selected.
        /// </summary>
        /// <param name="sender">The GridView displaying the selected item.</param>
        /// <param name="e">Event data that describes how the selection was changed.</param>
        private void itemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Invalidate the view state when logical page navigation is in effect, as a change
            // in selection may cause a corresponding change in the current logical page.  When
            // an item is selected this has the effect of changing from displaying the item list
            // to showing the selected item's details.  When the selection is cleared this has the
            // opposite effect.
            if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();
        }

        private bool CanGoBack()
        {
            if (this.UsingLogicalPageNavigation() && this.CourseList.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return this.navigationHelper.CanGoBack();
            }
        }
        private void GoBack()
        {
            if (this.UsingLogicalPageNavigation() && this.CourseList.SelectedItem != null)
            {
                // When logical page navigation is in effect and there's a selected item that
                // item's details are currently displayed.  Clearing the selection will return to
                // the item list.  From the user's point of view this is a logical backward
                // navigation.
                this.CourseList.SelectedItem = null;
            }
            else
            {
                this.navigationHelper.GoBack();
            }
        }

        private void InvalidateVisualState()
        {
            var visualState = DetermineVisualState();
            VisualStateManager.GoToState(this, visualState, false);
            this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Invoked to determine the name of the visual state that corresponds to an application
        /// view state.
        /// </summary>
        /// <returns>The name of the desired visual state.  This is the same as the name of the
        /// view state except when there is a selected item in portrait and snapped views where
        /// this additional logical page is represented by adding a suffix of _Detail.</returns>
        private string DetermineVisualState()
        {
            if (!UsingLogicalPageNavigation())
                return "PrimaryView";

            // Update the back button's enabled state when the view state changes
            var logicalPageBack = this.UsingLogicalPageNavigation() && this.CourseList.SelectedItem != null;

            return logicalPageBack ? "SinglePane_Detail" : "SinglePane";
        }

        #endregion

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
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
