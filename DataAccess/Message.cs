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
    
    public partial class Message
    {
        public long msgID { get; set; }
        public string mesage { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string status { get; set; }
        public Nullable<bool> isRead { get; set; }
        public Nullable<long> replyLink { get; set; }
    }
}
