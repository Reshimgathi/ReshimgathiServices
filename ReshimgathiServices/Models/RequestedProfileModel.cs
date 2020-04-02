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
                var response = db.RequestContacts.Where(x => x.RequestFrom == userProfileId).ToList();

                //if(today)
                //{
                //    response = response.Where(x=> x.CreateDate == DateTime.Now.Date);
                //}

                return response;
            }
        }
    }
}