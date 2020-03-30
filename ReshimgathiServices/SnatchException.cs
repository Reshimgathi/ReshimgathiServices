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

            var data = new LogErrors
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
}