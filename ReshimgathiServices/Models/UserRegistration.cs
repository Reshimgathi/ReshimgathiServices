using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ReshimgathiServices.Models
{
    public class UserRegistration
    {
        [JsonProperty("registration")]
        public UserProfileDetail Profile { get; set; }

        [JsonProperty("loginreq")]
        public Login LoginReq { get; set; }
    }

    public class ProfileUpdation
    {
        [JsonProperty("registration")]
        public UserProfileDetail Profile { get; set; }

        [JsonProperty("tabid")]
        public int TabId { get; set; }
    }
}