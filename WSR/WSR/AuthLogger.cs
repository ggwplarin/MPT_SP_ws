using System;
using System.IO;
using System.Xml.Serialization;
using WSR.DBContexts;
using WSR.dtos;

namespace WSR
{
    [Serializable]
    public class AuthLogger
    {
        private DataContext _db;
        private User _user;
        public DateTime SessionStartTime;
        private string _sessionFilePath;

        public AuthLogger(User user)
        {
            _user = user;
            SessionStartTime = DateTime.Now;
            _sessionFilePath = $"{Environment.CurrentDirectory}\\{_user.Id}.xml";
            if (File.Exists(_sessionFilePath))
            {
                throw new NotImplementedException();
            }
            var serializer = new XmlSerializer(typeof(AuthLogger));
            using TextWriter writer =
                new StreamWriter(_sessionFilePath);
            serializer.Serialize(writer, this);
        }

        public void Exit(string reason)
        {
            _db = new DataContext();
            _db.AuthLog.Add(new Auth
            {
                LogInTime = SessionStartTime,
                LogOutTime = DateTime.Now,
                ExitReason = reason,
                UserId = _user.Id
            });
            _db.SaveChanges();
            File.Delete(_sessionFilePath);
        }
    }
}