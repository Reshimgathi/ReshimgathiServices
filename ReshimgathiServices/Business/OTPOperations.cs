using ReshimgathiServices.Models;
using ReshimgathiServices.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Business
{
    public class OTPOperations
    {
        public int otp = 000000;

        public bool SendOTP(string channel)
        {
            bool isOTPSent = false;
            try
            {
                otp = GenerateOTP();
                isOTPSent = SendOTPThroughMsgApiCall(channel);
                if(isOTPSent)
                {
                    OTPModel omod = new OTPModel();
                    Guid otpId = omod.Save(channel, otp);

                    if (otpId != Guid.Empty)
                        isOTPSent = true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
           
            return isOTPSent;

        }

        public bool SendOTPThroughMsgApiCall(string channel)
        {
            //paid message sending service api call here
            return true;
        }

        public bool VerifyOTP(OTPRequest req)
        {
            bool isOtpVerified = false;

            if(string.IsNullOrWhiteSpace(req.email))
            {
                try
                {
                    OTPModel omod = new OTPModel();

                    return omod.Verify(req);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            return isOtpVerified;
        }

        public int GenerateOTP()
        {
            try
            {
                Random generator = new Random();
                String otp = generator.Next(0, 999999).ToString("D6");

                return Convert.ToInt32(otp);
            }
            catch(Exception e)
            {
                throw e;
            }  
        }
    }
}