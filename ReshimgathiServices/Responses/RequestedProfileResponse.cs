using Newtonsoft.Json;
using ReshimgathiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Responses
{
    public class RequestedProfileResponse
    {
        [JsonProperty("limitexceeded")]
        public bool LimitExceeded { get; set; }
    }

    public class AllRequestedProfileResponse
    {
        [JsonProperty("requestedprofiles")]
        public List<RequestedProfiles> RequestedProfiles { get; set; }
    }

    public class SaveRequestedProfileResponse
    {
        [JsonProperty("requestedprofilessaved")]
        public bool RequestedProfilesSaved { get; set; }
    }

    public class RemoveRequestedProfileResponse
    {
        [JsonProperty("requestedprofilesremoved")]
        public bool RequestedProfilesRemoved { get; set; }
    }
}