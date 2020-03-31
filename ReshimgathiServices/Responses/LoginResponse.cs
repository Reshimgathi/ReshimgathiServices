using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Responses
{
    /// <summary>
    /// Login Response
    /// </summary>
    public class LoginResponse
    {
        [JsonProperty("httpstatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("responseobj")]
        public LoginSuccess ResponseObj { get;  set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("additionalmessage")]
        public string AdditionalMessage { get; set; }
    }

    public class LoginSuccess
    {
        [JsonProperty("loginstatus")]
        public bool LoginStatus { get; set; }

        [JsonProperty("userprofiledetails")]
        public UserProfile UserProfileDetails { get; set; }
    }
}