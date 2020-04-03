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
    }
}