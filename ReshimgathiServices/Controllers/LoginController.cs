using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReshimgathiServices.Business;
using ReshimgathiServices.Requests;
using ReshimgathiServices.Responses;

namespace ReshimgathiServices.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of Login operations.
    /// </summary>
    [RoutePrefix("api/login")]
    [CatchException]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Verify Username and password.
        /// </summary>
        /// <returns></returns>
        [Route("verify")]
        [HttpPost]
        public HttpResponseMessage VerifyLoginDetails(LoginRequest req)
        {
            Response<LoginResponse> lor = new Response<LoginResponse>();
            bool isValidCreds = false;
            try
            {
                LoginOperations loginOp = new LoginOperations();
                var loginDetails = loginOp.VerifyLoginCreds(req.Username, req.Password);

                if(loginDetails != null)
                {
                    isValidCreds = true;
                }
                
                if (isValidCreds)
                {
                    UserProfileOperations uop = new UserProfileOperations();
                    UserProfilePicturesOperations uppo = new UserProfilePicturesOperations();
                    lor.Message = "User found. Welcome to Reshimgathi Matrimony !!";
                    lor.ResponseObj = new LoginResponse()
                    {
                        LoginStatus = true,
                        UserProfileDetails = uop.GetUserProfileDetails(loginDetails.UserProfileId),
                        UserProfilePictures = uppo.GetUserProfilePictures(loginDetails.UserProfileId)
                    };
                } 
                else
                {
                    lor.Message = "User Not Found !! Please try with correct login Creds.";
                    lor.ResponseObj = new LoginResponse()
                    {
                        LoginStatus = false,
                        UserProfileDetails = null,
                        UserProfilePictures = null
                    };
                } 

                lor.AdditionalMessage = "Additional note found here.";
                lor.HttpStatus = HttpStatusCode.OK.ToString();
                lor.Success = true;
            }
            catch(Exception e)
            {
                lor.Success = false;
                lor.Message = "Internal Server error. Please contact admin or try after some time.";
                lor.AdditionalMessage = e.Message;
                lor.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                lor.ResponseObj = new LoginResponse()
                {
                    LoginStatus = false,
                    UserProfileDetails = null,
                    UserProfilePictures = null
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, lor);
        }
    }
}
