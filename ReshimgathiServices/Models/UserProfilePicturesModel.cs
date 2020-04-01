using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class UserProfilePicturesModel
    {
        public List<UserProfilePicture> Select(Guid? userProfileId)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.UserProfilePictures.Where(x => x.Status == 1).ToList();

                return response;
            }
        }
    }
}