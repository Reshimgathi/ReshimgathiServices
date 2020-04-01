using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class ProfilePicture
    {
        public System.Guid Id { get; set; }

        public Nullable<System.Guid> UserProfileId { get; set; }

        public string ImageURL { get; set; }

        public bool IsDefaultPicture { get; set; }

        public Nullable<byte> Status { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}