using System;
using Newtonsoft.Json;

namespace ReshimgathiServices.Requests
{
    /// <summary>
    /// Login Request
    /// </summary>
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}