using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class RequestedProfileModel
    {
        public List<RequestContact> Select(Guid userProfileId, bool today = false)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.RequestContacts.Where(x => x.RequestFrom == userProfileId);

                if (today)
                {
                    response = response.Where(x => x.CreateDate == DateTime.Now.Date);
                }

                return response.ToList();
            }
        }

        public Guid Save(RequestedProfiles req)
        {
            RequestContact r1 = new RequestContact()
            {
                Id = Guid.NewGuid(),
                RequestFrom = req.RequestFrom,
                RequestTo1 = req.RequestTo1,
                RequestTo2 = req.RequestTo2,
                RequestTo3 = req.RequestTo3,
                RequestTo4 = req.RequestTo4,
                RequestTo5 = req.RequestTo5,
                IsRequestServed = req.IsRequestServed,
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.RequestContacts.Add(r1);
                db.SaveChanges();

                if (response != null)
                {
                    return response.Id;
                }
            }

            return Guid.Empty;
        }

        public bool Delete(RequestedProfiles req)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var myFavourite = db.RequestContacts
                                    .Where(x => x.RequestFrom == req.RequestFrom)
                                    .Where(x => x.IsRequestServed == false).First();

                myFavourite.IsRequestServed = true;
                myFavourite.UpdatedDate = DateTime.Now;
                db.SaveChanges();

                return true;
            }
        }
    }
}