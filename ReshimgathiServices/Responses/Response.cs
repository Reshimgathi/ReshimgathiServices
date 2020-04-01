using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Responses
{
    /// <summary>
    /// Login Response
    /// </summary>
    public class Response<T>
    {
        [JsonProperty("httpstatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("responseobj")]
        public T ResponseObj { get;  set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("additionalmessage")]
        public string AdditionalMessage { get; set; }
    }
}