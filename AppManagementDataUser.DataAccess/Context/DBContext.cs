using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppManagementDataUser.DataAccess.Models;

namespace AppManagementDataUser.DataAccess.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<SkillLevel> SkillLevels { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("skillName");
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.ToTable("SkillLevel");

                entity.Property(e => e.SkillLevelId).HasColumnName("skillLevelID");

                entity.Property(e => e.SkillLevelName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("skillLevelName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => e.Username);

                entity.ToTable("UserProfile");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.Bod)
                    .HasColumnType("date")
                    .HasColumnName("bod");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_UserProfile_User");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.Property(e => e.UserSkillId)
                    .HasMaxLength(50)
                    .HasColumnName("userSkillId");

                entity.Property(e => e.SkillId).HasColumnName("skillID");

                entity.Property(e => e.SkillLevelId).HasColumnName("skillLevelID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_UserSkills_Skill");

                entity.HasOne(d => d.SkillLevel)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillLevelId)
                    .HasConstraintName("FK_UserSkills_SkillLevel");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_UserSkills_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
