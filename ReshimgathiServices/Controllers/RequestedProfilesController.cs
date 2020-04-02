using ReshimgathiServices.Business;
using ReshimgathiServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReshimgathiServices.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of Requested Profile Operations.
    /// </summary>
    [RoutePrefix("api/request")]
    [CatchException]
    public class RequestedProfilesController : ApiController
    {
        /// <summary>
        /// Get user Requested Profiles based on UserProfileId
        /// </summary>
        /// <returns></returns>
        [Route("checklimit/{id}")]
        [HttpGet]
        public HttpResponseMessage IsTodaysLimitExceeded(Guid id)
        {
            Response<RequestedProfileResponse> upr = new Response<RequestedProfileResponse>();
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                RequestedProfileOperations rpo = new RequestedProfileOperations();
                var userDetails = uop.GetUserProfileDetails(id);

                if (userDetails != null)
                {
                    upr.Message = "User Profile found.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.ResponseObj = new RequestedProfileResponse()
                    {
                        LimitExceeded = rpo.CheckLimitExceededForToday(userDetails.Id),
                    };
                }
                else
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new RequestedProfileResponse()
                    {
                        LimitExceeded = false
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
                upr.ResponseObj = new RequestedProfileResponse()
                {
                    LimitExceeded = false
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }


        /// <summary>
        /// Get user Requested Profiles based on UserProfileId
        /// </summary>
        /// <returns></returns>
        [Route("all/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAllRequests(Guid id)
        {
            Response<AllRequestedProfileResponse> upr = new Response<AllRequestedProfileResponse>();
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                RequestedProfileOperations rpo = new RequestedProfileOperations();
                var userDetails = uop.GetUserProfileDetails(id);

                if (userDetails != null)
                {
                    upr.Message = "User Profile found.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.ResponseObj = new AllRequestedProfileResponse()
                    {
                        RequestedProfiles = rpo.GetAllRequestedProfiles(userDetails.Id),
                    };
                }
                else
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new AllRequestedProfileResponse()
                    {
                        RequestedProfiles = null
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
                upr.ResponseObj = new AllRequestedProfileResponse()
                {
                    RequestedProfiles = null
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }
    }
}
