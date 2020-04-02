using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReshimgathiServices.Business;
using ReshimgathiServices.Responses;

namespace ReshimgathiServices.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of User Profile Related operations.
    /// </summary>
    [RoutePrefix("api/pictures")]
    [CatchException]
    public class ProfilePicturesController : ApiController
    {
        /// <summary>
        /// Get user profile pictures based on given profileid
        /// </summary>
        /// <returns></returns>
        [Route("get/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUserProfilePictures(Guid id)
        {
            Response<ProfilePicturesResponse> uppr = new Response<ProfilePicturesResponse>();
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                UserProfilePicturesOperations uppo = new UserProfilePicturesOperations();
                var userDetails = uop.GetUserProfileDetails(id);

                if (userDetails != null)
                {
                    uppr.Message = "User Profile Pictures found.";
                    uppr.HttpStatus = HttpStatusCode.OK.ToString();
                    uppr.ResponseObj = new ProfilePicturesResponse()
                    {
                        UserProfilePictures = uppo.GetUserProfilePictures(id)
                    };
                }
                else
                {
                    uppr.Message = "User Profile Pictures Not Found.";
                    uppr.ResponseObj = new ProfilePicturesResponse()
                    {
                        UserProfilePictures = null
                    };
                }

                uppr.AdditionalMessage = "Additional note found here.";
                uppr.HttpStatus = HttpStatusCode.OK.ToString();
                uppr.Success = true;
            }
            catch (Exception e)
            {
                uppr.Success = false;
                uppr.Message = "Internal Server error. Please contact admin or try after some time.";
                uppr.AdditionalMessage = e.Message;
                uppr.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                uppr.ResponseObj = new ProfilePicturesResponse()
                {
                    UserProfilePictures = null
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, uppr);
        } 
    }
}
