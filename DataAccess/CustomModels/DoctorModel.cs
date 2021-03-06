﻿using System;
namespace DataAccess.CustomModels
{
    public class DoctorModel
    {
        public long doctorID { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string userId { get; set; }
        public string secretQuestion1 { get; set; }
        public string secretQuestion2 { get; set; }
        public string secretQuestion3 { get; set; }
        
        public byte[] picture { get; set; }
        public string ProfilePhotoBase64 { get; set; }
        public string secretAnswer1 { get; set; }
        public string secretAnswer2 { get; set; }
        public string secretAnswer3 { get; set; }
        public string title { get; set; }
        public string timeZone { get; set; }
        public string timeZoneoffset { get; set; }
        public string role { get; set; }
        public string iOSToken { get; set; }
        public string AndroidToken { get; set; }

        public Nullable<bool> active { get; set; }
        public Nullable<bool> status { get; set; }
    }
    public class DoctorDataset
    {
        public string ProfilePhotoBase64 { get; set; }
        public long doctorID { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public byte[] picture { get; set; }
        public string languageName { get; set; }
        public string specialityName { get; set; }
        public int? reviewStar { get; set; }

    }

    public class TimeZoneModel
    {
        public string zonename { get; set; }
        public string zoneoffset { get; set; }
        
    }

    public class DocConsultationReport
    {
        public long doctorid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    public class PatConsultationReport
    {
        public long patientid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
