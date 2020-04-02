using ReshimgathiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Business
{
    public class RequestedProfileOperations
    {
        public bool CheckLimitExceededForToday(Guid userProfileID)
        {
            RequestedProfileModel upm = new RequestedProfileModel();
            List<RequestContact> details = upm.Select(userProfileID, true);

            if (details.Count() == 0)
            {
                return false;
            }

            return true;
        }

        public List<RequestedProfiles> GetAllRequestedProfiles(Guid userProfileID)
        {
            RequestedProfileModel upm = new RequestedProfileModel();
            List<RequestContact> details = upm.Select(userProfileID);

            var requestDetails = MappingRequestedProfiles(details);

            return requestDetails;
        }

        private List<RequestedProfiles> MappingRequestedProfiles(List<RequestContact> details)
        {
            List<RequestedProfiles> requests = new List<RequestedProfiles>();

            foreach (var detail in details)
                requests.Add(new RequestedProfiles()
                {
                    Id = detail.Id,
                    RequestFrom = detail.RequestFrom,
                    RequestTo1 = detail.RequestTo1,
                    RequestTo2 = detail.RequestTo2,
                    RequestTo3 = detail.RequestTo3,
                    RequestTo4 = detail.RequestTo4,
                    RequestTo5 = detail.RequestTo5,
                    IsRequestServed = detail.IsRequestServed,
                    CreateDate = detail.CreateDate,
                    UpdatedDate = detail.UpdatedDate,
                });

            return requests;
        }
    }
}