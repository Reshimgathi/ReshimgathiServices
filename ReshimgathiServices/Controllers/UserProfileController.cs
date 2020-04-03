using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReshimgathiServices.Business;
using ReshimgathiServices.Responses;
using Swashbuckle.Swagger.Annotations;
using ReshimgathiServices.Models;

namespace ReshimgathiServices.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of User Profile Related operations.
    /// </summary>
    [RoutePrefix("api/user")]
    [CatchException]
    public class UserProfileController : ApiController
    {
        /// <summary>
        /// Get user profile based on given profileid
        /// </summary>
        /// <returns></returns>
        [Route("profile/{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "Get User Profile Details By User Profile Id.", typeof(Response<UserProfileResponse>))]
        public HttpResponseMessage GetUserProfile(Guid id)
        {
            Response<UserProfileResponse> upr = new Response<UserProfileResponse>();
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                UserProfilePicturesOperations uppo = new UserProfilePicturesOperations();
                var userDetails = uop.GetUserProfileDetails(id);

                if(userDetails != null)
                {
                    upr.Message = "User Profile found.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.ResponseObj = new UserProfileResponse()
                    {
                        UserProfileDetails = userDetails,
                        UserProfilePictures = uppo.GetUserProfilePictures(userDetails.Id)
                    };
                }
                else
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new UserProfileResponse()
                    {
                        UserProfileDetails = null,
                        UserProfilePictures = null
                    };
                }

                upr.AdditionalMessage = "Additional note found here.";
                upr.HttpStatus = HttpStatusCode.OK.ToString();
                upr.Success = true;
            }
            catch(Exception e)
            {
                upr.Success = false;
                upr.Message = "Internal Server error. Please contact admin or try after some time.";
                upr.AdditionalMessage = e.Message;
                upr.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                upr.ResponseObj = new UserProfileResponse()
                {
                    UserProfileDetails = null,
                    UserProfilePictures = null
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }

        /// <summary>
        /// Get user profile based on given Registration Id
        /// </summary>
        /// <returns></returns>
        [Route("registration/{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "Get User Profile Details By User Registration Id.", typeof(Response<UserProfileResponse>))]
        public HttpResponseMessage GetUserProfileByRegistrationId(int id)
        {
            Response<UserProfileResponse> upr = new Response<UserProfileResponse>();
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                UserProfilePicturesOperations uppo = new UserProfilePicturesOperations();
                var userDetails = uop.GetUserProfileDetails(id);

                if (userDetails != null)
                {
                    upr.Message = "User Profile found.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.ResponseObj = new UserProfileResponse()
                    {
                        UserProfileDetails = userDetails,
                        UserProfilePictures = uppo.GetUserProfilePictures(userDetails.Id)
                    };
                }
                else
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new UserProfileResponse()
                    {
                        UserProfileDetails = null,
                        UserProfilePictures = null
                    };
                }

                upr.AdditionalMessage = "Additional note found here.";
                upr.HttpStatus = HttpStatusCode.OK.ToString();
                upr.Success = true;
            }
            catch (Exception e)
            {
                upr.Success = false;
                upr.Message = "Internal Server error. Please contact admin or try after some time.";
                upr.AdditionalMessage = e.Message;
                upr.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                upr.ResponseObj = new UserProfileResponse()
                {
                    UserProfileDetails = null,
                    UserProfilePictures = null
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }

        /// <summary>
        /// Get user profile based on given profileid
        /// </summary>
        /// <returns></returns>
        [Route("profile/{id}")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "Save User Profile Details By User Profile Id.", typeof(bool))]
        public HttpResponseMessage SaveUserProfile(UserProfile request)
        {
            Response<UserProfileSaveResponse> upr = new Response<UserProfileSaveResponse>();
            bool isProfileSaved = false;
            try
            {
                UserProfileOperations uop = new UserProfileOperations();

                var userDetails = uop.GetUserProfileDetails(request.Id);

                //User already registered. This is not the first time save.
                if (userDetails != null)
                {
                    Guid userProfileId = uop.SaveUserProfileDetails(request);
                    upr.Message = "User Profile found.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.ResponseObj = new UserProfileSaveResponse()
                    {
                        IsProfileSaved = isProfileSaved,
                        UserProfileId = userProfileId
                    };
                }
                else
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new UserProfileSaveResponse()
                    {
                        IsProfileSaved = isProfileSaved,
                        UserProfileId = Guid.Empty
                    };
                }

                upr.AdditionalMessage = "Additional note found here.";
                upr.HttpStatus = HttpStatusCode.OK.ToString();
                upr.Success = true;
            }
            catch (Exception e)
            {
                upr.Success = false;
                upr.Message = "Internal Server error. Please contact admin or try after some time.";
                upr.AdditionalMessage = e.Message;
                upr.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                upr.ResponseObj = new UserProfileSaveResponse()
                {
                    IsProfileSaved = isProfileSaved,
                    UserProfileId = Guid.Empty
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }
    }
}
