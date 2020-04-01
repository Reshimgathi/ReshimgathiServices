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
}