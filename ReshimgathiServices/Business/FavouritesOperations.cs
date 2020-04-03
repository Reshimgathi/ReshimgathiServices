using ReshimgathiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Business
{
    public class FavouritesOperations
    {
        public List<Favourites> GetFavouriteProfiles(Guid userProfileID)
        {
            FavouriteModel upm = new FavouriteModel();
            List<Favourite> details = upm.Select(userProfileID);

            var favourites = MappingFavouritesProfiles(details);

            return favourites;
        }

        public bool SaveFavouriteProfile(Favourites favourite)
        {
            FavouriteModel upm = new FavouriteModel();
            var savedId = upm.Save(favourite);

            if (savedId != Guid.Empty)
                return true;

            return false;
        }

        public bool DeleteFavouriteProfile(Favourites favourite)
        {
            FavouriteModel upm = new FavouriteModel();

            return upm.Delete(favourite);
        }

        private List<Favourites> MappingFavouritesProfiles(List<Favourite> favs)
        {
            List<Favourites> favourites = new List<Favourites>();

            foreach (var fav in favs)
                favourites.Add(new Favourites()
                {
                    Id = fav.Id,
                    UserProfileId = fav.UserProfileId,
                    FavouriteProfileId = fav.FavouriteProfileId,
                    IsStillFavourite = fav.IsStillFavourite,
                    CreateDate = fav.CreateDate,
                    UpdatedDate = fav.UpdatedDate,
                });

            return favourites;
        }
    }
}