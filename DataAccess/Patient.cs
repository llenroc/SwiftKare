//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Conditions = new HashSet<Condition>();
            this.Consultations = new HashSet<Consultation>();
            this.ConsultationROS = new HashSet<ConsultationRO>();
            this.Medications = new HashSet<Medication>();
            this.PatientAllergies = new HashSet<PatientAllergy>();
            this.PatientFamilyHXes = new HashSet<PatientFamilyHX>();
            this.PatientSurgeries = new HashSet<PatientSurgery>();
            this.UserFiles = new HashSet<UserFile>();
        }
    
        public long patientID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string secretQuestion1 { get; set; }
        public string secretQuestion2 { get; set; }
        public string secretQuestion3 { get; set; }
        public string secretAnswer1 { get; set; }
        public string secretAnswer2 { get; set; }
        public string secretAnswer3 { get; set; }
        public string gender { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string homePhone { get; set; }
        public string cellPhone { get; set; }
        public string zip { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string languages { get; set; }
        public byte[] picture { get; set; }
        public string cb { get; set; }
        public Nullable<System.DateTime> cd { get; set; }
        public string mb { get; set; }
        public Nullable<System.DateTime> md { get; set; }
        public Nullable<bool> active { get; set; }
        public string userId { get; set; }
        public string pharmacy { get; set; }
        public Nullable<long> pharmacyid { get; set; }
        public string title { get; set; }
        public string suffix { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> weight { get; set; }
        public string timezone { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Nullable<double> lat { get; set; }
        public Nullable<double> lon { get; set; }
        public string iOSToken { get; set; }
        public string AndroidToken { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Condition> Conditions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultationRO> ConsultationROS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medication> Medications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientFamilyHX> PatientFamilyHXes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientSurgery> PatientSurgeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFile> UserFiles { get; set; }
    }
}
