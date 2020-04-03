using Newtonsoft.Json;
using System.Collections.Generic;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Responses
{
    public class FavouriteResponse
    {
        [JsonProperty("favouriteprofiles")]
        public List<Favourites> FavouriteProfiles { get; set; }
    }


    public class SaveFavouriteResponse
    {
        [JsonProperty("favouriteprofilessaved")]
        public bool FavouriteProfilesSaved { get; set; }
    }

    public class RemoveFavouriteResponse
    {
        [JsonProperty("favouriteprofilesremoved")]
        public bool FavouriteProfilesRemoved { get; set; }
    }
}