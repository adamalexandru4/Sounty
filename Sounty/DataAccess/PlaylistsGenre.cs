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
    
    public partial class PlaylistsGenre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlaylistsGenre()
        {
            this.PlaylistsGenresTracks = new HashSet<PlaylistsGenresTrack>();
        }
    
        public int playlistId { get; set; }
        public string playlistName { get; set; }
        public Nullable<int> imageId { get; set; }
        public Nullable<int> followers { get; set; }
    
        public virtual Image Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistsGenresTrack> PlaylistsGenresTracks { get; set; }
    }
}