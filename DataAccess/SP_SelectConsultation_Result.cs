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
    
    public partial class SP_SelectConsultation_Result
    {
        public long consultID { get; set; }
        public string DLastName { get; set; }
        public string DFirstName { get; set; }
        public string PLastName { get; set; }
        public string PFirstName { get; set; }
        public string review { get; set; }
        public Nullable<int> reviewStar { get; set; }
        public Nullable<System.TimeSpan> startTime { get; set; }
        public Nullable<System.TimeSpan> endTime { get; set; }
        public string duration { get; set; }
    }
}
