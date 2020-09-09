using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SBSCLearn.Models
{
    public partial class SBSCLEARNDBContext : DbContext
    {
        public SBSCLEARNDBContext()
        {
        }

        public SBSCLEARNDBContext(DbContextOptions<SBSCLEARNDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attempt> Attempt { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attempt>(entity =>
            {
                entity.Property(e => e.AttemptId).ValueGeneratedNever();

                entity.Property(e => e.AttemptedDate).HasColumnType("datetime");

                entity.Property(e => e.CourseName).HasMaxLength(50);
                entity.Property(e => e.Category).HasMaxLength(50);
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

             

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });
        }
    }
}
