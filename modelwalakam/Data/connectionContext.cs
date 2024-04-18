using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using modelwalakam.Models;

namespace modelwalakam.Data
{
    public partial class connectionContext : DbContext
    {
        public connectionContext()
        {
        }

        public connectionContext(DbContextOptions<connectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=connection;Persist Security Info=False;User ID=sa;Password=aptech;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__students__CBA1B2574A76644B");

                entity.ToTable("students");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("userpassword");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__teachers__CBA1B257CAF21A43");

                entity.ToTable("teachers");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("userpassword");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Useremail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("useremail");

                entity.Property(e => e.Username)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("userpassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
