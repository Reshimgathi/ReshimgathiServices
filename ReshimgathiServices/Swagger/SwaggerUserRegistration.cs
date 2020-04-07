using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ReshimgathiServices.Swagger
{
    public class SwaggerUserRegistration
    {
        [JsonProperty("registration")]
        public SwaggerUserProfileDetail Profile { get; set; }

        [JsonProperty("loginreq")]
        public SwaggerLogin LoginReq { get; set; }
    }

    public class SwaggerUserProfileDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public bool Gender { get; set; }
    }

    public class SwaggerLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}