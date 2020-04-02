using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class RequestedProfiles
    {
        public Guid Id { get; set; }
        public Guid RequestFrom { get; set; }
        public string RequestTo1 { get; set; }
        public string RequestTo2 { get; set; }
        public string RequestTo3 { get; set; }
        public string RequestTo4 { get; set; }
        public string RequestTo5 { get; set; }
        public bool IsRequestServed { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}