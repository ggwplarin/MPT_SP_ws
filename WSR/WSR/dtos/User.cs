using System;

namespace WSR.dtos
{
    public class User
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }

        public User()
        {
        }

        public User(int id, int officeId, int roleId, string email, string password, string firstName, string lastName, DateTime birthDate, bool active)
        {
            Id = id;
            OfficeId = officeId;
            RoleId = roleId;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthDate;
            Active = active;
        }
    }
}