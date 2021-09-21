using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JobPortalDI.ProjModel
{
    public partial class JobportalDIContext : DbContext
    {
        public JobportalDIContext()
        {
        }

        public JobportalDIContext(DbContextOptions<JobportalDIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Logintbl> Logintbls { get; set; }
        public virtual DbSet<Myjob> Myjobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-459\\SQLSERVER26; Database=JobportalDI; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contact_email");

                entity.Property(e => e.ContactUser)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contact_user");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Logintbl>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__logintbl__CBA1B257C5683821");

                entity.ToTable("logintbl");

                entity.HasIndex(e => e.Username, "UQ__logintbl__F3DBC572E0C8539C")
                    .IsUnique();

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Userpass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userpass");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("usertype");
            });

            modelBuilder.Entity<Myjob>(entity =>
            {
                entity.ToTable("myjobs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contact_email");

                entity.Property(e => e.ContactUser)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contact_user");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
