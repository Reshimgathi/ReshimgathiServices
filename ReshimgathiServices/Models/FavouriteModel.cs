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

        public Guid Save(Favourites favourite)
        {
            Favourite f1 = new Favourite() {    
                   Id = Guid.NewGuid(),
                   UserProfileId = favourite.UserProfileId,
                   FavouriteProfileId = favourite.FavouriteProfileId,
                   IsStillFavourite = favourite.IsStillFavourite,
                   CreateDate = DateTime.Now,
                   UpdatedDate = DateTime.Now
            };

            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.Favourites.Add(f1);
                db.SaveChanges();

                if (response != null)
                {
                    return response.Id;
                }
            }

            return Guid.Empty;
        }

        public bool Delete(Favourites favourite)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var myFavourite = db.Favourites
                                    .Where(x => x.UserProfileId == favourite.UserProfileId)
                                    .Where(x => x.FavouriteProfileId == favourite.FavouriteProfileId)
                                    .Where(x => x.IsStillFavourite == true).First();

                myFavourite.IsStillFavourite = false;
                myFavourite.UpdatedDate = DateTime.Now;
                db.SaveChanges();

                return true;
            }
        }
    }
}