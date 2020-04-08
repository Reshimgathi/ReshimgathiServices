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

    public class ChangePassword
    {
        [JsonProperty("userprofileid")]
        public Guid UserProfileId { get; set; }

        [JsonProperty("oldpassword")]
        public string OldPassword { get; set; }

        [JsonProperty("newpassword")]
        public string NewPassword { get; set; }
    }
}