using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReshimgathiServices.Responses
{
    public class UserProfileDetailsResponse
    {
        [JsonProperty("httpstatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("responseobj")]
        public UserProfileDetail ResponseObj { get; set; }

        [JsonProperty("statuscode")]
        public bool StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("additionalmessage")]
        public string AdditionalMessage { get; set; }
    }
}