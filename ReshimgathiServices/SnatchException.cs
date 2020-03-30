using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace ReshimgathiServices
{
    public class SnatchException : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext filterContext)
        {
            Log(filterContext);
        }

        private void Log(ExceptionContext filterContext)
        {
            //log exception here..
            FileUtility file = new FileUtility();
            string path = file.Path + string.Format(file.Name, DateTime.Now.ToString("yyyyMMdd"));
            StackTrace st = new StackTrace(filterContext.Exception, true);
            //Get the first stack frame
            StackFrame frame = st.GetFrame(0);

            var data = new LogErrorFields
            {
                UniqueId = Guid.NewGuid(),
                AppType = Application.MVC,
                DateTime = DateTime.Now.ToString(),
                Namespace = filterContext.Controller.ToString(),
                Controller = filterContext.Controller.ToString(),
                MethodName = frame.GetMethod().Name,
                ErrorCode = filterContext.Exception.HResult.ToString(),
                IsExceptionHandled = filterContext.ExceptionHandled,
                Exception = filterContext.Exception.Message,
                FileName = frame.GetFileName(),
                LineNo = frame.GetFileLineNumber(),
                ColumnNo = frame.GetFileColumnNumber(),
                Version = null,
                Host = filterContext.HttpContext.Request.Url.Host,
                StackTrace = filterContext.Exception.StackTrace,
            };
            string json = JsonConvert.SerializeObject(data);

            file.CreateFile(path, json);
        }
    }

    public class LogErrorFields
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