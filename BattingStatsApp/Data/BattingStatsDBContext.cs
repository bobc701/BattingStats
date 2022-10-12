using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BattingStatsApp.Models;

namespace BattingStatsApp.Data
{
    public partial class BattingStatsDBContext : DbContext
    {
        public BattingStatsDBContext()
        {
        }

        public BattingStatsDBContext(DbContextOptions<BattingStatsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batting> Battings { get; set; } = null!;
        public virtual DbSet<Master> Masters { get; set; } = null!;
        public virtual DbSet<Pitching> Pitchings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batting>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.TeamId });

                entity.ToTable("Batting");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(6)
                    .HasColumnName("teamID");

                entity.Property(e => e.Ab).HasColumnName("AB");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Cs).HasColumnName("CS");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.LahmanId)
                    .HasMaxLength(10)
                    .HasColumnName("lahmanID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(3)
                    .HasColumnName("lgID");

                entity.Property(e => e.Pa).HasColumnName("PA");

                entity.Property(e => e.PosSummary).HasMaxLength(16);

                entity.Property(e => e.Rbi).HasColumnName("RBI");

                entity.Property(e => e.Sb).HasColumnName("SB");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e._2b).HasColumnName("2B");

                entity.Property(e => e._3b).HasColumnName("3B");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("Master");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.Bats)
                    .HasMaxLength(4)
                    .HasColumnName("bats");

                entity.Property(e => e.BbrefId)
                    .HasMaxLength(10)
                    .HasColumnName("bbrefID");

                entity.Property(e => e.BirthCity)
                    .HasMaxLength(50)
                    .HasColumnName("birthCity");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(50)
                    .HasColumnName("birthCountry");

                entity.Property(e => e.BirthDay).HasColumnName("birthDay");

                entity.Property(e => e.BirthMonth).HasColumnName("birthMonth");

                entity.Property(e => e.BirthState)
                    .HasMaxLength(50)
                    .HasColumnName("birthState");

                entity.Property(e => e.BirthYear).HasColumnName("birthYear");

                entity.Property(e => e.DeathCity)
                    .HasMaxLength(50)
                    .HasColumnName("deathCity");

                entity.Property(e => e.DeathCountry)
                    .HasMaxLength(50)
                    .HasColumnName("deathCountry");

                entity.Property(e => e.DeathDay).HasColumnName("deathDay");

                entity.Property(e => e.DeathMonth).HasColumnName("deathMonth");

                entity.Property(e => e.DeathState)
                    .HasMaxLength(50)
                    .HasColumnName("deathState");

                entity.Property(e => e.DeathYear).HasColumnName("deathYear");

                entity.Property(e => e.Debut)
                    .HasColumnType("datetime")
                    .HasColumnName("debut");

                entity.Property(e => e.FinalGame)
                    .HasColumnType("datetime")
                    .HasColumnName("finalGame");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.LahmanId)
                    .HasMaxLength(10)
                    .HasColumnName("lahmanID");

                entity.Property(e => e.NameFirst)
                    .HasMaxLength(50)
                    .HasColumnName("nameFirst");

                entity.Property(e => e.NameGiven)
                    .HasMaxLength(50)
                    .HasColumnName("nameGiven");

                entity.Property(e => e.NameLast)
                    .HasMaxLength(50)
                    .HasColumnName("nameLast");

                entity.Property(e => e.RetroId)
                    .HasMaxLength(10)
                    .HasColumnName("retroID");

                entity.Property(e => e.Throws)
                    .HasMaxLength(4)
                    .HasColumnName("throws");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.ZplayerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ZPlayerId");
            });

            modelBuilder.Entity<Pitching>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.TeamId });

                entity.ToTable("Pitching");

                entity.Property(e => e.PlayerId)
                    .HasMaxLength(10)
                    .HasColumnName("playerID");

                entity.Property(e => e.YearId).HasColumnName("yearID");

                entity.Property(e => e.Stint).HasColumnName("stint");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(6)
                    .HasColumnName("teamID");

                entity.Property(e => e.Baopp).HasColumnName("BAOpp");

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.Bfp).HasColumnName("BFP");

                entity.Property(e => e.Bk).HasColumnName("BK");

                entity.Property(e => e.Cg).HasColumnName("CG");

                entity.Property(e => e.Er).HasColumnName("ER");

                entity.Property(e => e.Era).HasColumnName("ERA");

                entity.Property(e => e.Gf).HasColumnName("GF");

                entity.Property(e => e.Gidp).HasColumnName("GIDP");

                entity.Property(e => e.Gs).HasColumnName("GS");

                entity.Property(e => e.Hbp).HasColumnName("HBP");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Ibb).HasColumnName("IBB");

                entity.Property(e => e.Ipouts).HasColumnName("IPouts");

                entity.Property(e => e.LahmanId)
                    .HasMaxLength(10)
                    .HasColumnName("lahmanID");

                entity.Property(e => e.LgId)
                    .HasMaxLength(3)
                    .HasColumnName("lgID");

                entity.Property(e => e.Sf).HasColumnName("SF");

                entity.Property(e => e.Sh).HasColumnName("SH");

                entity.Property(e => e.Sho).HasColumnName("SHO");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Sv).HasColumnName("SV");

                entity.Property(e => e.Wp).HasColumnName("WP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
