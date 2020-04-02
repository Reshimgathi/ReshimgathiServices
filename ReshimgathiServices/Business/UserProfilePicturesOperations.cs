using ReshimgathiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Business
{
    public class UserProfilePicturesOperations
    {
        public List<ProfilePicture> GetUserProfilePictures(Guid userProfileID)
        {
            UserProfilePicturesModel uppm = new UserProfilePicturesModel();
            List<UserProfilePicture> pictures = uppm.Select(userProfileID);

            var profilePics = MappingUserProfilePicures(pictures);

            return profilePics;
        }

        private List<ProfilePicture> MappingUserProfilePicures(List<UserProfilePicture> pics)
        {
            List<ProfilePicture> pictures = new List<ProfilePicture>();

            foreach (var pic in pics)
                pictures.Add(new ProfilePicture() {
                    Id = pic.Id,
                    UserProfileId = pic.UserProfileId,
                    ImageURL = pic.ImageURL,
                    IsDefaultPicture = pic.IsDefaultPicture,
                    Status = pic.Status,
                    CreateDate = pic.CreateDate,
                    UpdatedDate = pic.UpdatedDate,
                });

            return pictures;
        }
    }
}