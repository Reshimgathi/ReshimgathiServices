using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace ReshimgathiServices
{
    public class CatchException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            Log(filterContext);
        }

        private void Log(HttpActionExecutedContext filterContext)
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
                AppType = Application.WebApi,
                DateTime = DateTime.Now.ToString(),
                Namespace = filterContext.ActionContext.ControllerContext.Controller.ToString(),
                Controller = filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                ErrorCode = filterContext.Exception.HResult.ToString(),
                IsExceptionHandled = null,
                Exception = filterContext.Exception.Message,
                FileName = frame.GetFileName(),
                MethodName = frame.GetMethod().Name,
                LineNo = frame.GetFileLineNumber(),
                ColumnNo = frame.GetFileColumnNumber(),
                Version = filterContext.Request.Version.ToString(),
                Host = filterContext.Request.RequestUri.Host,
                StackTrace = filterContext.Exception.StackTrace,
            };
            string json = JsonConvert.SerializeObject(data);

            file.CreateFile(path, json);
        }
    }
}