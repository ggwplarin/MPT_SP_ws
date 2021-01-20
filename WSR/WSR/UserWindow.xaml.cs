using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WSR.dtos;

namespace WSR
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly Window _previousWindow;
        private readonly DispatcherTimer _clockTimer;
        private readonly DateTime _sessionStartTime;
        private readonly AuthLogger _logger;
        public UserWindow(Window previousWindow, User user,AuthLogger logger)
        {
            _previousWindow = previousWindow;
            _logger = logger;
            InitializeComponent();
            _sessionStartTime = _logger.SessionStartTime;
            _clockTimer = new DispatcherTimer();
            _clockTimer.Tick+=UpdateClock;
            _clockTimer.Start();
            LblGreeting.Content = $"Hi {user.FirstName}, Welcome to AMONIC Airlines";
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            var time = DateTime.Now - _sessionStartTime;
            LblTimeSpentOnSystem.Content = $"{time.Hours}{time.Minutes}{time.Seconds}";
        }


        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            _logger.Exit("");
        }

        private void UserWindow_OnClosed(object sender, EventArgs e)
        {
            _clockTimer.Stop();
            _previousWindow.Show();
        }
    }
}
