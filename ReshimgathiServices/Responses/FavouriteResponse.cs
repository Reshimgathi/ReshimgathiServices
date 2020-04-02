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
}