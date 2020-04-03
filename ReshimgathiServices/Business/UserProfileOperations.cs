using ReshimgathiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Business
{
    public class UserProfileOperations
    {
        public UserProfile GetUserProfileDetails(Guid userProfileID)
        {
            UserProfileModel upm = new UserProfileModel();
            UserProfileDetail details =  upm.Select(userProfileID);

            var user = MappingUserProfile(details);
            return user;
        }

        public UserProfile GetUserProfileDetails(int userRegId)
        {
            UserProfileModel upm = new UserProfileModel();
            UserProfileDetail details = upm.Select(userRegId);

            var user = MappingUserProfile(details);
            return user;
        }

        public Guid SaveUserProfileDetails(UserProfile request)
        {
            UserProfileModel upm = new UserProfileModel();
            Guid userProfileId = upm.Save(request);

            return userProfileId;
        }

        private UserProfile MappingUserProfile(UserProfileDetail details)
        {
            UserProfile u1 = new UserProfile() {
                Id = details.Id,
                RegistrationId = details.RegistrationId,
                FirstName = details.FirstName,
                MiddleName = details.MiddleName,
                LastName = details.LastName,
                MobileNumber = details.MobileNumber,
                IsMobileVerified = details.IsMobileVerified,
                AlternateMobileNumber = details.AlternateMobileNumber,
                IsAlternateMobileVerified = details.IsAlternateMobileVerified,
                EmailId = details.EmailId,
                IsEmailVerified = details.IsEmailVerified,
                Status = details.Status,
                Religion = details.Religion,
                Caste = details.Caste,
                SubCaste = details.SubCaste,
                MartialStatus = details.MartialStatus,
                DOB = details.DOB,
                height = details.height,
                weight = details.weight,
                BloodGroup = details.BloodGroup,
                Complexion = details.Complexion,
                PhysicalDisability = details.PhysicalDisability,
                DisabilityDetails = details.DisabilityDetails,
                Diet = details.Diet,
                IsSpectacles = details.IsSpectacles,
                Rashi = details.Rashi,
                Nakshtra = details.Nakshtra,
                Charan = details.Charan,
                Gan = details.Gan,
                Nadi = details.Nadi,
                BirthTime = details.BirthTime,
                BirthPlace = details.BirthPlace,
                Devak = details.Devak,
                Mangal = details.Mangal,
                LastEducation = details.LastEducation,
                EducationStream = details.EducationStream,
                Occupation = details.Occupation,
                OccupationCity = details.OccupationCity,
                OccupationCountry = details.OccupationCountry,
                AnnualIncome = details.AnnualIncome,
                PanCard = details.PanCard,
                AadharCard = details.AadharCard,
                ResidenceAddress = details.ResidenceAddress,
                MotherName = details.MotherName,
                ParentFullName = details.ParentFullName,
                Brothers = details.Brothers,
                MarriedBrothers = details.MarriedBrothers,
                Sisters = details.Sisters,
                MarriedSisters = details.MarriedSisters,
                ParentsOccupation = details.ParentsOccupation,
                SurnamesOfRelatives = details.SurnamesOfRelatives,
                NativeDistrict = details.NativeDistrict,
                NativeCity = details.NativeCity,
                NativeTaluka = details.NativeTaluka,
                FamilyWealth = details.FamilyWealth,
                PreferredCities = details.PreferredCities,
                ExpectedCaste = details.ExpectedCaste,
                MaxAgeDifference = details.MaxAgeDifference,
                ExpectedHeightAbove = details.ExpectedHeightAbove,
                Divorcee = details.Divorcee,
                ExpectedOccupation = details.ExpectedOccupation,
                ExpectedIncome = details.ExpectedIncome,
                ExpectedEducation = details.ExpectedEducation,
                IsLiveOnBoarding = details.IsLiveOnBoarding,
                IsPaidProfile = details.IsPaidProfile,
                FreeTrialUser = details.FreeTrialUser,
                CreateDate = details.CreateDate,
                UpdatedDate = details.UpdatedDate
            };

            return u1;
        }
    }
}