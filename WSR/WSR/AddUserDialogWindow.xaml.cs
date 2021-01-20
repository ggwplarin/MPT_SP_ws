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
using WSR.dtos;

namespace WSR
{
    /// <summary>
    /// Логика взаимодействия для AddUserDialogWindow.xaml
    /// </summary>
    public partial class AddUserDialogWindow : Window
    {
        
        public AddUserDialogWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var ok = true;
            ok &= !string.IsNullOrWhiteSpace(TbEmail.Text);
            ok &= !string.IsNullOrWhiteSpace(TbFirstName.Text);
            ok &= !string.IsNullOrWhiteSpace(TbLastName.Text);
            ok &= !string.IsNullOrWhiteSpace(PbPassword.Password);
            ok &= CbOffice.SelectedItem != null;
            ok &= DpBirthDate.SelectedDate != null;
            if(!ok)return;
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string Email => TbEmail.Text;
        public string FirstName => TbFirstName.Text;
        public string LastName => TbLastName.Text;
        public int OfficeId => ((Office) CbOffice.SelectedItem).Id;
        public DateTime BirthDate=>(DateTime) DpBirthDate.SelectedDate;
        public string Password=>PbPassword.Password;
    }
}
