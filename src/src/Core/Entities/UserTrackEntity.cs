﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

#nullable disable

namespace Featurify.Core.Entities
{
    public partial class UserTrackEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TrackId { get; set; }
        public bool Enable { get; set; }

        public virtual TrackEntity Track { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}