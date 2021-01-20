using System;

namespace WSR.dtos
{
    public class Auth
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LogInTime { get; set; }
        public DateTime LogOutTime { get; set; }
        public string ExitReason { get; set; }

        public Auth()
        {
            
        }
        public Auth(int id, int userId, DateTime logInTime, DateTime logOutTime, string exitReason)
        {
            Id = id;
            UserId = userId;
            LogInTime = logInTime;
            LogOutTime = logOutTime;
            ExitReason = exitReason;
        }
    }
}