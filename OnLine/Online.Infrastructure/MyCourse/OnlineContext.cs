using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Online.Infrastructure.MyCourse
{
    public partial class OnlineContext : DbContext
    {
        public OnlineContext()
        {
        }

        public OnlineContext(DbContextOptions<OnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adm> Adm { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=127.0.0.1;uid=sa;pwd=123;database=Online;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Adm>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK_ADM");

                entity.ToTable("adm");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Aname)
                    .HasColumnName("ANAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("PK_MARK");

                entity.Property(e => e.Mid)
                    .HasColumnName("MID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .HasColumnName("CLASS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Depart)
                    .HasColumnName("DEPART")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Major)
                    .HasColumnName("MAJOR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Score).HasColumnName("SCORE");

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.Sname)
                    .HasColumnName("SNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK_STUDENT");

                entity.Property(e => e.Sid)
                    .HasColumnName("SID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .HasColumnName("CLASS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Depart)
                    .HasColumnName("DEPART")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Major)
                    .HasColumnName("MAJOR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .HasColumnName("SNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK_TEACHER");

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Depart)
                    .HasColumnName("DEPART")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tname)
                    .HasColumnName("TNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasColumnName("TYPE");
            });
        }
    }
}
