//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sounty.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class RatingsTrack
    {
        public int uselessId { get; set; }
        public int userId { get; set; }
        public int trackId { get; set; }
        public int rating { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual Track Track { get; set; }
    }
}
