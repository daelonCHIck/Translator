using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Переводчик.Server
{
    public partial class TranslatorDBContext : DbContext
    {
        public TranslatorDBContext()
        {
        }

        public TranslatorDBContext(DbContextOptions<TranslatorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<Translation> Translation { get; set; }
        public virtual DbSet<Translator> Translator { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Lab116-p;Database=TranslatorDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journal>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LangFrom).HasColumnName("Lang_from");

                entity.Property(e => e.LangTo).HasColumnName("Lang_to");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.LangFromNavigation)
                    .WithMany(p => p.JournalLangFromNavigation)
                    .HasForeignKey(d => d.LangFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Journal_Translation");

                entity.HasOne(d => d.LangToNavigation)
                    .WithMany(p => p.JournalLangToNavigation)
                    .HasForeignKey(d => d.LangTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Journal_Translation1");
            });

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LangName)
                    .IsRequired()
                    .HasColumnName("Lang name")
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<Translator>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Chin)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Corea)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Deu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Eng)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Jap)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Rus)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Journal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
