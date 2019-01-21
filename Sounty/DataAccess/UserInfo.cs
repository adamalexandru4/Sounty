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
    
    public partial class UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInfo()
        {
            this.Friends = new HashSet<Friend>();
            this.Friends1 = new HashSet<Friend>();
            this.Playlists = new HashSet<Playlist>();
            this.PlaylistsUsers = new HashSet<PlaylistsUser>();
            this.RatingsTracks = new HashSet<RatingsTrack>();
        }
    
        public int userInfoId { get; set; }
        public Nullable<int> profileImage { get; set; }
        public Nullable<int> subscriptionId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userAddress { get; set; }
        public string phoneNumber { get; set; }
        public string facebookPage { get; set; }
        public string instagramPage { get; set; }
        public string youtubePage { get; set; }
        public Nullable<System.DateTime> birthDate { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public Nullable<bool> activeStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Friend> Friends1 { get; set; }
        public virtual Image Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistsUser> PlaylistsUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingsTrack> RatingsTracks { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual UserSounty UserSounty { get; set; }
    }
}
