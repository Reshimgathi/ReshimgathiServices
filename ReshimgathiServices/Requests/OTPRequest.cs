using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Requests
{
    public class OTPRequest
    {
        [JsonProperty("mobile")]
        public int mobile { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("otp")]
        public int otp { get; set; }
    }
}