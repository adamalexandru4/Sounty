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
    
    public partial class Concert
    {
        public int concertId { get; set; }
        public Nullable<int> artistId { get; set; }
        public Nullable<System.DateTime> dateConcert { get; set; }
        public string locationConcert { get; set; }
    
        public virtual Artist Artist { get; set; }
    }
}
