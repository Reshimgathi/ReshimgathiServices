using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class UserProfileModel
    {
        public UserProfileDetail Select(Guid userProfileId)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.UserProfileDetails.Where(x=> x.Id == userProfileId).FirstOrDefault();

                return response;
            }
        }

        public UserProfileDetail Select(int userRegId)
        {
            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.UserProfileDetails.Where(x => x.RegistrationId == userRegId).FirstOrDefault();

                return response;
            }
        }

        public Guid Save(UserProfile req)
        {
            UserProfileDetail profile = MapUserProfileRequest(req);

            using (ReshimgathiDBContext db = new ReshimgathiDBContext())
            {
                var response = db.UserProfileDetails.Add(profile);
                db.SaveChanges();

                if (response != null)
                {
                    return response.Id;
                }
            }

            return Guid.Empty;
        }

        private static UserProfileDetail MapUserProfileRequest(UserProfile req)
        {
            return new UserProfileDetail()
            {
                Id = req.Id,
                RegistrationId = req.RegistrationId,
                FirstName = req.FirstName,
                MiddleName = req.MiddleName,
                LastName = req.LastName,
                MobileNumber = req.MobileNumber,
                IsMobileVerified = req.IsMobileVerified,
                AlternateMobileNumber = req.AlternateMobileNumber,
                IsAlternateMobileVerified = req.IsAlternateMobileVerified,
                EmailId = req.EmailId,
                IsEmailVerified = req.IsEmailVerified,
                Status = req.Status,
                Religion = req.Religion,
                Caste = req.Caste,
                SubCaste = req.SubCaste,
                MartialStatus = req.MartialStatus,
                DOB = req.DOB,
                height = req.height,
                weight = req.weight,
                BloodGroup = req.BloodGroup,
                Complexion = req.Complexion,
                PhysicalDisability = req.PhysicalDisability,
                DisabilityDetails = req.DisabilityDetails,
                Diet = req.Diet,
                IsSpectacles = req.IsSpectacles,
                Rashi = req.Rashi,
                Nakshtra = req.Nakshtra,
                Charan = req.Charan,
                Gan = req.Gan,
                Nadi = req.Nadi,
                BirthTime = req.BirthTime,
                BirthPlace = req.BirthPlace,
                Devak = req.Devak,
                Mangal = req.Mangal,
                LastEducation = req.LastEducation,
                EducationStream = req.EducationStream,
                Occupation = req.Occupation,
                OccupationCity = req.OccupationCity,
                OccupationCountry = req.OccupationCountry,
                AnnualIncome = req.AnnualIncome,
                PanCard = req.PanCard,
                AadharCard = req.AadharCard,
                ResidenceAddress = req.ResidenceAddress,
                MotherName = req.MotherName,
                ParentFullName = req.ParentFullName,
                Brothers = req.Brothers,
                MarriedBrothers = req.MarriedBrothers,
                Sisters = req.Sisters,
                MarriedSisters = req.MarriedSisters,
                ParentsOccupation = req.ParentsOccupation,
                SurnamesOfRelatives = req.SurnamesOfRelatives,
                NativeDistrict = req.NativeDistrict,
                NativeCity = req.NativeCity,
                NativeTaluka = req.NativeTaluka,
                FamilyWealth = req.FamilyWealth,
                PreferredCities = req.PreferredCities,
                ExpectedCaste = req.ExpectedCaste,
                MaxAgeDifference = req.MaxAgeDifference,
                ExpectedHeightAbove = req.ExpectedHeightAbove,
                Divorcee = req.Divorcee,
                ExpectedOccupation = req.ExpectedOccupation,
                ExpectedIncome = req.ExpectedIncome,
                ExpectedEducation = req.ExpectedEducation,
                IsLiveOnBoarding = req.IsLiveOnBoarding,
                IsPaidProfile = req.IsPaidProfile,
                FreeTrialUser = req.FreeTrialUser,
                CreateDate = req.CreateDate,
                UpdatedDate = req.UpdatedDate
            };
        }
    }
}