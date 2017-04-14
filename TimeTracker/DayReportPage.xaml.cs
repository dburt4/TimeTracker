using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TimeTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DayReportPage : Page
    {

        Report report;

        public DayReportPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            report = (Report)e.Parameter;
            report.printAllActivities();
            this.totalTimeSpentContainer.Text = report.totalTime / 60 + " hrs, " + report.totalTime % 60 + " mins";
            this.totalProductiveTimeSpentContainer.Text = report.totalProductiveTime / 60 + " hrs, " + report.totalProductiveTime % 60 + " mins";
            this.percentTotalTimeSpent.Text = Math.Round(report.percentProductive, 2) + "%";
            this.avgFocusTimeContainer.Text = report.avgFocusTime.ToString() + " mins";
            //this.totalTimeContainer = report.totalTime;
        }

        //private void ReturnToInputLink_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(MainPage));
        //}

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), report.day);

        }
    }
}
