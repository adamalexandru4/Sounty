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
    
    public partial class PlaylistTrack
    {
        public int uselessId { get; set; }
        public Nullable<int> playlistId { get; set; }
        public Nullable<int> trackId { get; set; }
        public Nullable<bool> favoriteFlag { get; set; }
    
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
