using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Responses
{
    public class ProfilePicturesResponse
    {

        [JsonProperty("userprofilepictures")]
        public List<ProfilePicture> UserProfilePictures { get; set; }
    }
}