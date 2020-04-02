using ReshimgathiServices.Business;
using ReshimgathiServices.Models;
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
    /// This controller helps to manage all types of Favourite User Profiles Operations.
    /// </summary>
    [RoutePrefix("api/favourite")]
    [CatchException]
    public class FavouritesController : ApiController
    {
        /// <summary>
        /// Get user profile based on given profileid
        /// </summary>
        /// <returns></returns>
        [Route("profiles/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFavouriteUserProfiles(Guid id)
        {
            Response<FavouriteResponse> upr = new Response<FavouriteResponse>();
            try
            {
                UserProfileOperations uop = new UserProfileOperations();
                FavouritesOperations fav = new FavouritesOperations();
                var userDetails = uop.GetUserProfileDetails(id);

                if (userDetails != null)
                {
                    upr.Message = "User Profile found.";
                    upr.HttpStatus = HttpStatusCode.OK.ToString();
                    upr.ResponseObj = new FavouriteResponse()
                    {
                        FavouriteProfiles = fav.GetFavouriteProfiles(userDetails.Id),
                    };
                }
                else
                {
                    upr.Message = "User Profile Not Found.";
                    upr.ResponseObj = new FavouriteResponse()
                    {
                        FavouriteProfiles = null,
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
                upr.ResponseObj = new FavouriteResponse()
                {
                    FavouriteProfiles = null,
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, upr);
        }
    }
}
