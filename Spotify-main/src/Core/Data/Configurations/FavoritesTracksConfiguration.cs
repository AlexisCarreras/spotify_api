﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Spotify.Core.Data;
using Spotify.Core.Models;
using System;


namespace Spotify.Core.Data.Configurations
{
    public partial class FavoritesTracksConfiguration : IEntityTypeConfiguration<FavoritesTracks>
    {
        public void Configure(EntityTypeBuilder<FavoritesTracks> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.TrackId)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("track_id");

            entity.Property(e => e.UsuarioId)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario_id");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<FavoritesTracks> entity);
    }
}
