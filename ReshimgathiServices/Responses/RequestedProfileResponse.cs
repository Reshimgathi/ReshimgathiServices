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
}