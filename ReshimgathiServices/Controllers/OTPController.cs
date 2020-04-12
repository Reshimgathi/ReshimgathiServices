using ReshimgathiServices.Business;
using ReshimgathiServices.Requests;
using ReshimgathiServices.Responses;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReshimgathiServices.Controllers
{
    /// <summary>
    /// This controller helps to manage all types of OTP code verification operations.
    /// </summary>
    [RoutePrefix("api/otp")]
    [CatchException]
    public class OTPController : ApiController
    {
        [Route("send/{channel}")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "Send OTP.", typeof(Response<OTPResponse>))]
        public HttpResponseMessage Send(string channel)
        {
            Response<OTPResponse> response = new Response<OTPResponse>();
            OTPOperations op1 = new OTPOperations();
            bool isOtpSent = false;
            try
            {
                if(op1.SendOTP(channel))
                {
                    isOtpSent = true;
                    response.Message = "OTP sent. Please verify on your device.";
                    response.ResponseObj = new OTPResponse()
                    {
                        IsOTPSent = isOtpSent,
                        otp = 000000,
                        ExpiredOn = DateTime.Now.AddMinutes(15),
                    };
                    
                }
                else
                {
                    response.Message = "We got some issues in OTP generation. Please try after some time.";
                    response.ResponseObj = new OTPResponse()
                    {
                        IsOTPSent = isOtpSent,
                        otp = 000000,
                        ExpiredOn = DateTime.Now.AddMinutes(15),
                    };
                }

                response.AdditionalMessage = "Additional note found here.";
                response.HttpStatus = HttpStatusCode.OK.ToString();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Internal Server error. Please contact admin or try after some time.";
                response.AdditionalMessage = e.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                response.ResponseObj = new OTPResponse()
                {
                    IsOTPSent = isOtpSent,
                    otp = 000000,
                    ExpiredOn = DateTime.Now.AddMinutes(15),
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("verify")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "OTP verification.", typeof(Response<OTPVerifyResponse>))]
        public HttpResponseMessage Verify(OTPRequest req)
        {
            Response<OTPVerifyResponse> response = new Response<OTPVerifyResponse>();
            OTPOperations op1 = new OTPOperations();
            bool isOtpVerified = false;
            try
            {
                if (op1.VerifyOTP(req))
                {
                    isOtpVerified = true;
                    response.Message = "OTP sent. Please verify on your device.";
                    response.ResponseObj = new OTPVerifyResponse()
                    {
                        IsOTPVerified = isOtpVerified
                    };
                    
                }
                else
                {
                    response.Message = "OTP verification failed. Please cross check your OTP once again on your device.";
                    response.ResponseObj = new OTPVerifyResponse()
                    {
                        IsOTPVerified = isOtpVerified
                    };
                }

                response.AdditionalMessage = "Additional note found here.";
                response.HttpStatus = HttpStatusCode.OK.ToString();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Internal Server error. Please contact admin or try after some time.";
                response.AdditionalMessage = e.Message;
                response.HttpStatus = HttpStatusCode.InternalServerError.ToString();
                response.ResponseObj = new OTPVerifyResponse()
                {
                    IsOTPVerified = isOtpVerified
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
