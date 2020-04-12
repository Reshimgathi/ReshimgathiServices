using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Responses
{
    public class OTPResponse
    {
        [JsonProperty("isotpsent")]
        public bool IsOTPSent { get; set; }

        [JsonProperty("otp")]
        public int otp { get; set; }

        [JsonProperty("expiredon")]
        public DateTime ExpiredOn { get; set; }
    }

    public class OTPVerifyResponse
    {
        [JsonProperty("isotpverified")]
        public bool IsOTPVerified { get; set; }
    }
}