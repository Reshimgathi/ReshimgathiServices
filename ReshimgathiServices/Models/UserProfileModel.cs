using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class UserProfileModel
    {
        public UserProfileDetail Select(Guid userProfileId)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.UserProfileDetails.Where(x=> x.Id == userProfileId).FirstOrDefault();

                return response;
            }
        }

        public UserProfileDetail Select(int userRegId)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.UserProfileDetails.Where(x => x.RegistrationId == userRegId).FirstOrDefault();

                return response;
            }
        }
    }
}