using System;
using ReshimgathiServices.Models;

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

        public Guid SaveLoginDetails(Login request, Guid userProfileId)
        {
            Guid loginId = Guid.Empty;
            try
            {
                LoginModel obj = new LoginModel();
                loginId = obj.Save(request, userProfileId);
            }
            catch(Exception e)
            {
                throw e;
            }

            return loginId;
        }
    }
}