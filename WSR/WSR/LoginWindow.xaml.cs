﻿using System;
using System.Windows;
using System.Windows.Threading;

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

        private static DispatcherTimer _timer;
        private static int _cooldown = 0;
        private int _attemptsToLogin = 0;

        /// <summary>
        /// Обработка нажатия кнопки Login
        /// Открывает следующее окно основываясь на роли пользователя либо выводит ошибку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            switch (AuthenticateUser(TbUsername.Text, TbPassword.Password))
            {
                case 0:
                    break;
                case 1:
                    var adminWindow = new AdminWindow(this);
                    adminWindow.Show();
                    Hide();
                    break;
                case 2:
                    var userWindow = new UserWindow(this, null);//TODO: заменить null на данные пользователя
                    userWindow.Show();
                    Hide();
                    break;
                default:
                    break;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {

            if (_cooldown != 0)
            {
                BtnLogin.Content = $"Wait({_cooldown})";
                _cooldown--;
            }
            else
            {
                BtnLogin.IsEnabled = true;
                BtnLogin.Content = "Login";
                _timer.Stop();
            }

        }
        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>
        /// 0 - Пользователь не найден;
        /// 1 - Администратор; 
        /// 2 - Обычный пользователь;
        /// 3 - Пользователь заблокирован;
        /// 4 - Некорректные данные;
        /// 5 - Блокировка входа
        /// </returns>
        private int AuthenticateUser(string username, string password)
        {
            //TODO: добавить проверку правильности заполнения
            var usernameValid = true;
            var passwordValid = true;
            if (!(usernameValid & passwordValid)) return 4;
            if (_cooldown != 0) return 5;


            if (false)
            {
                return 2;
            }
            else
            {

                if (_attemptsToLogin < 3)
                {
                    _attemptsToLogin++;
                    return 0;
                }
                _timer = new DispatcherTimer();
                _timer.Tick += TimerTick;
                _timer.Interval = new TimeSpan(0, 0, 0, 1);
                _timer.Start();
                _cooldown = 10;
                BtnLogin.IsEnabled = false;
                BtnLogin.Content = "Wait";
                return 5;
            }

        }
        /// <summary>
        /// Обработка нажатия кнопки Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}