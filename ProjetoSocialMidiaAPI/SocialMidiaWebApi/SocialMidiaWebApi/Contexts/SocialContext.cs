using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMidiaWebApi.Domains;

namespace SocialMidiaWebApi.Contexts
{
    public partial class SocialContext : DbContext
    {
        public SocialContext()
        {
        }

        public SocialContext(DbContextOptions<SocialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoxMensagem> BoxMensagem { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0VF65US\\SQLEXPRESS; Initial Catalog=SocialMidia;integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoxMensagem>(entity =>
            {
                entity.HasKey(e => e.IdBoxMensagem)
                    .HasName("PK__BoxMensa__78701BD25D5AD9EB");

                entity.Property(e => e.IdBoxMensagem)
                    .HasColumnName("idBoxMensagem")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Mensagem>(entity =>
            {
                entity.HasKey(e => e.IdMensagem)
                    .HasName("PK__Mensagem__AAFB640D38B7DC73");

                entity.Property(e => e.IdMensagem).HasColumnName("idMensagem");

                entity.Property(e => e.DataMensagem).HasColumnType("datetime");

                entity.Property(e => e.IdBoxMensagemDestino).HasColumnName("idBoxMensagemDestino");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Mensagem1)
                    .IsRequired()
                    .HasColumnName("Mensagem")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBoxMensagemDestinoNavigation)
                    .WithMany(p => p.Mensagem)
                    .HasForeignKey(d => d.IdBoxMensagemDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mensagem__idBoxM__3F466844");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Mensagem)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mensagem__idUsua__403A8C7D");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF2E2B57B8");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6DA60C6C9");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105343E3CA7DD")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.IdBoxMensagem).HasColumnName("idBoxMensagem");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBoxMensagemNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdBoxMensagem)
                    .HasConstraintName("FK__Usuario__idBoxMe__3C69FB99");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
