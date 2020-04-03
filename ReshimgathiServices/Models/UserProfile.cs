using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReshimgathiServices.Models
{
    public class UserProfile
    {
        public System.Guid Id { get; set; }
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public bool IsMobileVerified { get; set; }
        public string AlternateMobileNumber { get; set; }
        public bool IsAlternateMobileVerified { get; set; }
        public string EmailId { get; set; }
        public bool IsEmailVerified { get; set; }
        public Nullable<byte> Status { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string SubCaste { get; set; }
        public Nullable<byte> MartialStatus { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<short> height { get; set; }
        public Nullable<short> weight { get; set; }
        public string BloodGroup { get; set; }
        public string Complexion { get; set; }
        public bool PhysicalDisability { get; set; }
        public string DisabilityDetails { get; set; }
        public bool Diet { get; set; }
        public bool IsSpectacles { get; set; }
        public string Rashi { get; set; }
        public string Nakshtra { get; set; }
        public string Charan { get; set; }
        public string Gan { get; set; }
        public string Nadi { get; set; }
        public Nullable<System.TimeSpan> BirthTime { get; set; }
        public string BirthPlace { get; set; }
        public string Devak { get; set; }
        public bool Mangal { get; set; }
        public string LastEducation { get; set; }
        public string EducationStream { get; set; }
        public string Occupation { get; set; }
        public string OccupationCity { get; set; }
        public string OccupationCountry { get; set; }
        public string AnnualIncome { get; set; }
        public string PanCard { get; set; }
        public string AadharCard { get; set; }
        public string ResidenceAddress { get; set; }
        public string MotherName { get; set; }
        public string ParentFullName { get; set; }
        public Nullable<byte> Brothers { get; set; }
        public Nullable<byte> MarriedBrothers { get; set; }
        public Nullable<byte> Sisters { get; set; }
        public Nullable<byte> MarriedSisters { get; set; }
        public string ParentsOccupation { get; set; }
        public string SurnamesOfRelatives { get; set; }
        public string NativeDistrict { get; set; }
        public string NativeCity { get; set; }
        public string NativeTaluka { get; set; }
        public string FamilyWealth { get; set; }
        public string PreferredCities { get; set; }
        public string ExpectedCaste { get; set; }
        public string MaxAgeDifference { get; set; }
        public string ExpectedHeightAbove { get; set; }
        public bool Divorcee { get; set; }
        public string ExpectedOccupation { get; set; }
        public string ExpectedIncome { get; set; }
        public string ExpectedEducation { get; set; }
        public bool IsLiveOnBoarding { get; set; }
        public bool IsPaidProfile { get; set; }
        public bool FreeTrialUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}