using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReshimgathiServices.Business;
using ReshimgathiServices.Responses;
using Swashbuckle.Swagger.Annotations;
using ReshimgathiServices.Models;
using System.Collections.Generic;

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
        /// User Profile Registration in Phase I.
        /// </summary>
        /// <returns></returns>
        [Route("registration")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "Register User Profile Details in Phase I.", typeof(Response<UserProfileSaveResponse>))]
        public HttpResponseMessage RegisterUserProfileInPhaseI(UserRegistration request)
        {
            Response<UserProfileSaveResponse> upr = new Response<UserProfileSaveResponse>();
            bool isProfileCreated = false;
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                LoginOperations lop = new LoginOperations();

                //User profile registration firsttime. This is not the first time save.
                Guid userProfileId = uop.SaveUserProfileDetails(request.Profile);

                Guid loginId = lop.SaveLoginDetails(request.LoginReq, userProfileId);

                if (userProfileId != Guid.Empty && loginId != Guid.Empty)
                {
                    isProfileCreated = true;
                    upr.Message = "User Profile is Created.";
                    upr.ResponseObj = new UserProfileSaveResponse()
                    {
                        IsProfileSaved = isProfileCreated,
                        UserProfileId = userProfileId
                    };
                }
                else
                {
                    upr.Message = "User Profile is not saved. Server has rejected your request. Please contact administrator. ";
                    upr.ResponseObj = new UserProfileSaveResponse()
                    {
                        IsProfileSaved = isProfileCreated,
                        UserProfileId = userProfileId
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
                    IsProfileSaved = isProfileCreated,
                    UserProfileId = Guid.Empty
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }

        /// <summary>
        /// User Profile Registration in Phase I.
        /// </summary>
        /// <returns></returns>
        [Route("registration/{id}")]
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, "Register User Profile Details in Phase I.", typeof(Response<UserProfileUpdateResponse>))]
        public HttpResponseMessage RegisterUserProfileInPhaseII(ProfileUpdation request)
        {
            Response<UserProfileUpdateResponse> upr = new Response<UserProfileUpdateResponse>();
            bool isProfileUpdated = false;
            try
            {
                UserProfileOperations uop = new UserProfileOperations();

                var userDetails = uop.GetUserProfileDetails(request.Profile.Id);
                if(userDetails == null)
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new UserProfileUpdateResponse()
                    {
                        IsProfileUpdated = isProfileUpdated,
                        UserProfileId = request.Profile.Id
                    };
                    upr.AdditionalMessage = "Additional note found here.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.Success = true;

                    return Request.CreateResponse(HttpStatusCode.OK, upr);
                }

                //User profile registration firsttime. This is not the first time save.
                Guid userProfileId = uop.UpdateUserProfileDetails(request.Profile, request.TabId);

                if (userProfileId != Guid.Empty)
                {
                    isProfileUpdated = true;
                    upr.Message = "User Profile is Updated.";
                    upr.ResponseObj = new UserProfileUpdateResponse()
                    {
                        IsProfileUpdated = isProfileUpdated,
                        UserProfileId = userProfileId
                    };
                }
                else
                {
                    upr.Message = "User Profile is not updated. Server has rejected your request. Please contact administrator. ";
                    upr.ResponseObj = new UserProfileUpdateResponse()
                    {
                        IsProfileUpdated = isProfileUpdated,
                        UserProfileId = userProfileId
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
                upr.ResponseObj = new UserProfileUpdateResponse()
                {
                    IsProfileUpdated = isProfileUpdated,
                    UserProfileId = Guid.Empty
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }
    }
}
