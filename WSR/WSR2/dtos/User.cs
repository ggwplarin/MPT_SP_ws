using System;

namespace WSR2.dtos
{
    public class User
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int OfficeID { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }

        public User()
        {
            
        }
        public User(int id, int roleId, int officeId, string email, string firstname, string lastname, DateTime birthdate, bool active)
        {
            ID = id;
            RoleID = roleId;
            OfficeID = officeId;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Birthdate = birthdate;
            Active = active;
        }
    }
}