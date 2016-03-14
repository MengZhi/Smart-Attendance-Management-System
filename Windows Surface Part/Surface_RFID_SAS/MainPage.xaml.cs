using Surface_RFID_SAS.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Syndication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Surface_RFID_SAS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
       
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginCheck();
        }
        public async void getinfor()
        {
            Service1Client proxy = new Service1Client();
            string result = await proxy.GreetingMessageAsync("hello");

            ErrorMessage.Text = result;
        
        }
       
        public async void LoginCheck()
        {
            Service1Client proxy = new Service1Client();
            if (username.Text!=null && password.Password!=null && usertype.SelectionBoxItem != null)
            {
                int result = await proxy.CheckLoginAsync(username.Text, password.Password, usertype.SelectedItem.ToString());

                if (result == 1)
                {
                    
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values["UserName"] = username.Text;
                    this.Frame.Navigate(typeof(LecWelcome.Default));
                }
                else if (result == 2)
                {
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values["UserName"] = username.Text;
                    this.Frame.Navigate(typeof(StuWelcome.Default));
                }
                else if (result == 3)
                {
                    ErrorMessage.Text = "Wrong username or password.";
                }
            }
            
            else if (username.Text == null || password.Password == null || usertype.SelectionBoxItem == null)
                ErrorMessage.Text = "Please complete your information.";
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ForgetPassword.Default));
        }
        




        
    }
}
