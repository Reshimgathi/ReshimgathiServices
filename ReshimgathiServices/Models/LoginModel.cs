using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    [CatchException]
    public class LoginModel
    {
        public Guid Add(Login data)
        {
            Login record = new Login();
            record.Id = Guid.NewGuid();
            record.UserProfileId = Guid.NewGuid();
            record.Username = data.Username;
            record.Password = data.Password;
            record.IsVerified = false;
            record.CreateDate = DateTime.Now;
            record.UpdatedDate = DateTime.Now;

            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.Logins.Add(record);
                db.SaveChanges();
                if (response != null)
                {
                    return record.Id;
                }
            }

            return Guid.Empty;
        }

        public Login Select(string username, string password)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                Login user = db.Logins.Where(x => x.Username == username && x.Password == password).FirstOrDefault();

                return user;
            }
        }
    }
}