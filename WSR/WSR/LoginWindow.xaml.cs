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
        /// <summary>
        /// Обработка нажатия кнопки Login
        /// Открывает следующее окно основываясь на роли пользователя либо выводит ошибку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            switch (AuthenticateUser(TbUsername.Text,TbPassword.Password))
            {
                case 0:
                    break;
                case 1:
                    var gg = new AdminWindow(this);
                    gg.Show();
                    Hide();
                    break;
                case 2:
                    break;
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
        /// </returns>
        private int AuthenticateUser(string username, string password)
        {
            //TODO: добавить аутентификацию
            return 1;
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