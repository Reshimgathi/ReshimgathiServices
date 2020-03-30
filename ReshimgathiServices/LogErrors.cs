using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices
{
    public class LogErrors
    {
        public Guid UniqueId { get; set; }

        public Application AppType { get; set; }

        public string DateTime { get; set; }

        public string Namespace { get; set; }

        public string Controller { get; set; }

        public bool? IsExceptionHandled { get; set; }

        public string Exception { get; set; }

        public string ErrorCode { get; set; }

        public string FileName { get; set; }

        public string MethodName { get; set; }

        public int LineNo { get; set; }

        public int ColumnNo { get; set; }

        public string StackTrace { get; set; }

        public string Host { get; set; }

        public string Version { get; set; }
    }

    public enum Application
    {
        MVC = 0,
        WebApi = 1
    }
}