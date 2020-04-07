using System;
using System.Linq;

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

        public Guid Save(Login req, Guid userProfileId)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    req.Id = Guid.NewGuid();
                    req.UserProfileId = userProfileId;
                    req.CreateDate = DateTime.Now;
                    req.UpdatedDate = DateTime.Now;

                    var response = db.Logins.Add(req);
                    db.SaveChanges();

                    if (response != null)
                    {
                        return response.Id;
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return Guid.Empty;
        }
    }
}