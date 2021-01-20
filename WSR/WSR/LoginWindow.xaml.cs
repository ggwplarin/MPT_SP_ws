using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WSR.DBContexts;
using WSR.dtos;

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
        private DataContext db;

        /// <summary>
        /// Обработка нажатия кнопки Login
        /// Открывает следующее окно основываясь на роли пользователя либо выводит ошибку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {

            var user = AuthenticateUser(TbUsername.Text, TbPassword.Password);
            if (user == null) return;
            if (!user.Active) MessageBox.Show("Ваш профиль был заблокирован администратором.");
            var logger = new AuthLogger(user);
            switch (user.RoleId)
            {
                case 1:
                    var adminWindow = new AdminWindow(this, user,logger);
                    adminWindow.Show();
                    Hide();
                    break;
                case 2:
                    var userWindow = new UserWindow(this, user,logger);
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
        private User AuthenticateUser(string username, string password)
        {
            var ok = true;
            ok &= !string.IsNullOrWhiteSpace(username);
            ok &= !string.IsNullOrWhiteSpace(password);
            if (!ok) return null;
            if (_cooldown != 0) return null;
            db = new DataContext();
            var user = db.Users.FirstOrDefault(u => u.Email == username && u.Password == password);
            if (user!=null)
            {
                return user;
            }
            else
            {
                
                if (_attemptsToLogin < 3)
                {
                    _attemptsToLogin++;
                    return null;
                }
                _timer = new DispatcherTimer();
                _timer.Tick += TimerTick;
                _timer.Interval = new TimeSpan(0, 0, 0, 1);
                _timer.Start();
                _cooldown = 10;
                BtnLogin.IsEnabled = false;
                BtnLogin.Content = "Wait";
                return null;
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