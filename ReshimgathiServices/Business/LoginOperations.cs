using ReshimgathiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Business
{
    [CatchException]
    public class LoginOperations
    {
        public Login VerifyLoginCreds(string username, string password)
        {
            LoginModel obj = new LoginModel();

            Login d1 = obj.Select(username, password);

            return d1;
        }
    }
}