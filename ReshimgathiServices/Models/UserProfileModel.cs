using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        public Guid Save(UserProfileDetail req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    req.Id = Guid.NewGuid();
                    req.Status = 1;
                    req.IsMobileVerified = true;
                    req.RegistrationId = db.UserProfileDetails.Select(x => x.RegistrationId).Max() + 1;
                    req.CreateDate = DateTime.Now;
                    req.UpdatedDate = DateTime.Now;

                    var response = db.UserProfileDetails.Add(req);
                    db.SaveChanges();

                    if (response != null)
                    {
                        return response.Id;
                    }
                }

                
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        //Console.WriteLine(message);
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return Guid.Empty;
        }

        public bool Update(UserProfile req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    var profile = db.UserProfileDetails.Where(x => x.Id == req.Id).FirstOrDefault();

                    //Map only required fields.
                    profile = MapUserProfileRequest(req);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public Guid UpdatePersonalDetails(UserProfileDetail req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    var profile = db.UserProfileDetails
                                    .Where(x => x.Id == req.Id).FirstOrDefault();

                    profile.FirstName = req.FirstName;
                    profile.MiddleName = req.LastName;
                    profile.AlternateMobileNumber = req.AlternateMobileNumber;
                    profile.EmailId = req.EmailId;
                    profile.Gender = req.Gender;
                    profile.Religion = req.Religion;
                    profile.Caste = req.Caste;
                    profile.SubCaste = req.SubCaste;
                    profile.MartialStatus = req.MartialStatus;
                    profile.DOB = req.DOB;
                    profile.height = req.height;
                    profile.weight = req.weight;
                    profile.BloodGroup = req.BloodGroup;
                    profile.Complexion = req.Complexion;
                    profile.PhysicalDisability = req.PhysicalDisability;
                    profile.DisabilityDetails = req.DisabilityDetails;
                    profile.Diet = req.Diet;
                    profile.IsSpectacles = req.IsSpectacles;
                    profile.UpdatedDate = DateTime.Now;

                    db.SaveChanges();

                    return profile.Id;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        //Console.WriteLine(message);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Guid.Empty;
        }

        public Guid UpdateHoroscopeDetails(UserProfileDetail req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    var profile = db.UserProfileDetails
                                    .Where(x => x.Id == req.Id).FirstOrDefault();

                    profile.Rashi = req.Rashi;
                    profile.Nakshtra = req.Nakshtra;
                    profile.Charan = req.Charan;
                    profile.Gan = req.Gan;
                    profile.Nadi = req.Nadi;
                    profile.BirthTime = req.BirthTime;
                    profile.BirthPlace = req.BirthPlace;
                    profile.Devak = req.Devak;
                    profile.Mangal = req.Mangal;
                    profile.UpdatedDate = DateTime.Now;

                    db.SaveChanges();

                    return profile.Id;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry
                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        //Console.WriteLine(message);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Guid.Empty;
        }

        public Guid UpdateEducationalDetails(UserProfileDetail req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    var profile = db.UserProfileDetails
                                    .Where(x => x.Id == req.Id).FirstOrDefault();

                    profile.LastEducation = req.LastEducation;
                    profile.EducationStream = req.EducationStream;
                    profile.Occupation = req.Occupation;
                    profile.OccupationCity = req.OccupationCity;
                    profile.OccupationCountry = req.OccupationCountry;
                    profile.AnnualIncome = req.AnnualIncome;
                    profile.PanCard = req.PanCard;
                    profile.AadharCard = req.AadharCard;
                    profile.UpdatedDate = DateTime.Now;

                    db.SaveChanges();

                    return profile.Id;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry
                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        //Console.WriteLine(message);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Guid.Empty;
        }

        public Guid UpdateFamilyBackgroundDetails(UserProfileDetail req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    var profile = db.UserProfileDetails
                                    .Where(x => x.Id == req.Id).FirstOrDefault();

                    profile.ResidenceAddress = req.ResidenceAddress;
                    profile.MotherName = req.MotherName;
                    profile.ParentFullName = req.ParentFullName;
                    profile.Brothers = req.Brothers;
                    profile.MarriedBrothers = req.MarriedBrothers;
                    profile.Sisters = req.Sisters;
                    profile.MarriedSisters = req.MarriedSisters;
                    profile.ParentsOccupation = req.ParentsOccupation;
                    profile.SurnamesOfRelatives = req.SurnamesOfRelatives;
                    profile.NativeDistrict = req.NativeDistrict;
                    profile.NativeCity = req.NativeCity;
                    profile.NativeTaluka = req.NativeTaluka;
                    profile.FamilyWealth = req.FamilyWealth;
                    profile.UpdatedDate = DateTime.Now;

                    db.SaveChanges();

                    return profile.Id;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        //Console.WriteLine(message);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Guid.Empty;
        }

        public Guid UpdateExpectationDetails(UserProfileDetail req)
        {
            try
            {
                using (ReshimgathiDBContext db = new ReshimgathiDBContext())
                {
                    var profile = db.UserProfileDetails
                                    .Where(x => x.Id == req.Id).FirstOrDefault();

                    profile.PreferredCities = req.PreferredCities;
                    profile.ExpectedCaste = req.ExpectedCaste;
                    profile.MaxAgeDifference = req.MaxAgeDifference;
                    profile.ExpectedHeightAbove = req.ExpectedHeightAbove;
                    profile.Divorcee = req.Divorcee;
                    profile.ExpectedOccupation = req.ExpectedOccupation;
                    profile.ExpectedIncome = req.ExpectedIncome;
                    profile.ExpectedEducation = req.ExpectedEducation;
                    profile.UpdatedDate = DateTime.Now;

                    db.SaveChanges();

                    return profile.Id;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        //Console.WriteLine(message);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
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
                Gender = req.Gender,
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
            };
        }
    }
}