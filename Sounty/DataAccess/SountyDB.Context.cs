﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SountyDB : DbContext
    {
        public SountyDB()
            : base("name=SountyDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistsGenre> PlaylistsGenres { get; set; }
        public virtual DbSet<PlaylistsGenresTrack> PlaylistsGenresTracks { get; set; }
        public virtual DbSet<PlaylistsUser> PlaylistsUsers { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<RatingsTrack> RatingsTracks { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrackArtist> TrackArtists { get; set; }
        public virtual DbSet<TracksGenre> TracksGenres { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserSounty> UserSounties { get; set; }
    }
}
