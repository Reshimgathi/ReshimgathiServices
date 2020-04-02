using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class Favourites
    {
        public Guid Id { get; set; }

        public Guid UserProfileId { get; set; }

        public string FavouriteProfileId { get; set; }

        public bool IsStillFavourite { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}