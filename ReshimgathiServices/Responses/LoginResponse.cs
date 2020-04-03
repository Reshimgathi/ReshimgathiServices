using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Responses
{
    public class LoginResponse
    {
        [JsonProperty("loginstatus")]
        public bool LoginStatus { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userprofileid")]
        public Guid UserProfileId { get; set; }

        //[JsonProperty("userprofiledetails")]
        //public UserProfile UserProfileDetails { get; set; }

        //[JsonProperty("userprofilepictures")]
        //public List<ProfilePicture> UserProfilePictures { get; set; }
    }
}