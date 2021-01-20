using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WSR.DBContexts;
using WSR.dtos;

namespace WSR
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly Window _previousWindow;
        private readonly DataContext _db;
        private User _user;
        private readonly AuthLogger _logger;
        public AdminWindow(Window previousWindow, User user,AuthLogger logger)
        {
            _previousWindow = previousWindow;
            _db = new DataContext();
            _logger = logger;
            InitializeComponent();
            LoadUsersTable();
            _user = user;
            var officesList = _db.Offices.ToList();
            CbOfficesList.ItemsSource = officesList;
            CbOfficesList.DisplayMemberPath = "Title";
        }

        private void BtnAddUser_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new AddUserDialogWindow();
            if (dialog.ShowDialog()!=true) return;
            var newUser = new User
            {
                OfficeId = dialog.OfficeId,
                RoleId = 2,
                Email = dialog.Email,
                Password = dialog.Password,
                FirstName = dialog.FirstName,
                LastName = dialog.LastName,
                Birthdate = dialog.BirthDate,
                Active = true
            };
            if (_db.Users.FirstOrDefault(u=>u.Email==newUser.Email)!=null)return;
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            _logger.Exit("");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _previousWindow.Show();
        }

        private void BtnChangeRole_OnClick(object sender, RoutedEventArgs e)
        {
            if (CbOfficesList.SelectedItem==null)return;
            var selectedUser = (User) CbOfficesList.SelectedItem;
            _db.Users.First(u=>u==selectedUser).RoleId = (selectedUser.RoleId) switch
            {
                1 => 2,
                2 => 1,
                _ => throw new ArgumentOutOfRangeException()
            };
            _db.SaveChanges();
            LoadUsersTable();
        }

        private void BtnToggleLogin_Click(object sender, RoutedEventArgs e)
        {
            if (CbOfficesList.SelectedItem == null) return;
            _db.Users.First(u=>u== (User)DgUsersTable.SelectedItem).Active ^= true;
            _db.SaveChanges();
            LoadUsersTable();
        }

        private void LoadUsersTable()
        {
            var users = _db.Users.ToList();
            DgUsersTable.ItemsSource = users.Where(u => u.OfficeId == ((Office) CbOfficesList.SelectedItem).Id);
        }

    }
}
