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
    
    public partial class VCLog
    {
        public long VCLogID { get; set; }
        public Nullable<long> consultID { get; set; }
        public Nullable<int> duration { get; set; }
        public string endBy { get; set; }
        public string endReason { get; set; }
        public string logBy { get; set; }
        public Nullable<System.DateTime> cd { get; set; }
    }
}
