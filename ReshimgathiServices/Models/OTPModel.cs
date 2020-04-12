using ReshimgathiServices.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class OTPModel
    {
        public Guid Save(string channel, int otp)
        {
            OTPVerification r1 = new OTPVerification()
            {
                Id = Guid.NewGuid(),
                Type = channel,
                OTP = otp,
                CreateDate = DateTime.Now,
            };

            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.OTPVerifications.Add(r1);
                db.SaveChanges();

                if (response != null)
                {
                    return response.Id;
                }
            }

            return Guid.Empty;
        }

        public bool Verify(OTPRequest req)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.OTPVerifications.Select(x=> x.Type == req.mobile.ToString() &&
                                                              x.OTP == req.otp);

                if (response != null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}