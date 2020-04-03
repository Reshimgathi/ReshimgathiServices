using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Responses
{
    public class UserProfileResponse
    {
        [JsonProperty("userprofiledetails")]
        public UserProfile UserProfileDetails { get; set; }

        [JsonProperty("userprofilepictures")]
        public List<ProfilePicture> UserProfilePictures { get; set; }
    }

    public class UserProfileSaveResponse
    {
        [JsonProperty("isprofilesaved")]
        public bool IsProfileSaved { get; set; }

        [JsonProperty("userprofileid")]
        public Guid UserProfileId { get; set; }
    }
}