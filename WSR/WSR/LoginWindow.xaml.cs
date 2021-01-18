using System;
using System.Windows;

namespace WSR
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            switch (AuthticateUser())
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }

        private int AuthticateUser()
        {
            throw new NotImplementedException();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}