using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TimeTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private static DateTime lastTime;
        Day day;
        ObservableCollection<string> options = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            day = new Day();
            options.Add("Productive");
            options.Add("Unproductive");
            Debug.WriteLine("Made a new day!");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Debug.WriteLine("Navigated to this page: " + e.Parameter);
            if(e.Parameter != "")
            {
                //Boolean isFromOtherPage = (Boolean)e.Parameter;
                day = (Day)e.Parameter;
                
                this.InputGroupStarting.Visibility = Visibility.Collapsed;
                this.InputGroupNormal.Visibility = Visibility.Visible;
                
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox activityInput = ActivityNameInput;
            //Debug.WriteLine("Clicked! + " + activityInput.Text);
            String isProductive = ProductiveComboBox.SelectedValue.ToString();
            Activity activity = new Activity(activityInput.Text, day.lastTime);
            activity.isProductive = isProductive == "Productive" ? true : false;
            day.AddActivity(activity);
            day.PrintAllActivities();
            activityInput.Text = "";
            lastActivityContainer.Text = activity.activityName + " (" + activity.timeSpent + " mins)";
            day.lastTime = DateTime.Now;

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.InputGroupStarting.Visibility = Visibility.Collapsed;
            this.InputGroupNormal.Visibility = Visibility.Visible;
            day.lastTime = DateTime.Now;
            //Debug.WriteLine ("Clicked this button");
        }

        private void SeeReportButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DayReportPage), new Report(day));
        }

    }
}
