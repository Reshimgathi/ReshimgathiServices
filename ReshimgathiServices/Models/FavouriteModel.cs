using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class FavouriteModel
    {
        public List<Favourite> Select(Guid userProfileId)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.Favourites.Where(x => x.UserProfileId == userProfileId).ToList();

                return response;
            }
        }
    }
}