using System;

namespace WSR.dtos
{
    public class User
    {
        public int ID { get; set; }
        public int OfficeID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public User()
        {
        }

        public User(int id, int officeId, int roleId, string email, string password, string firstname, string lastName, DateTime birthDate)
        {
            ID = id;
            OfficeID = officeId;
            RoleID = roleId;
            Email = email;
            Password = password;
            Firstname = firstname;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}