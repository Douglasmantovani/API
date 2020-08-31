using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LojaDeGames.Domains;

namespace LojaDeGames.Contexts
{
    public partial class LojaDeGamesContext : DbContext
    {
        public LojaDeGamesContext()
        {
        }

        public LojaDeGamesContext(DbContextOptions<LojaDeGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrinho> Carrinho { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Estudio> Estudio { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0VF65US\\SQLEXPRESS; Initial Catalog=LojaDeGames;integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.HasKey(e => e.IdCarrinho)
                    .HasName("PK__Carrinho__3A1F27A2EE1AA8F0");

                entity.Property(e => e.IdCarrinho).HasColumnName("idCarrinho");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.IdJogo2).HasColumnName("idJogo2");

                entity.Property(e => e.IdJogo3).HasColumnName("idJogo3");

                entity.Property(e => e.ValorContido)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.CarrinhoIdJogoNavigation)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK__Carrinho__idJogo__4316F928");

                entity.HasOne(d => d.IdJogo2Navigation)
                    .WithMany(p => p.CarrinhoIdJogo2Navigation)
                    .HasForeignKey(d => d.IdJogo2)
                    .HasConstraintName("FK__Carrinho__idJogo__440B1D61");

                entity.HasOne(d => d.IdJogo3Navigation)
                    .WithMany(p => p.CarrinhoIdJogo3Navigation)
                    .HasForeignKey(d => d.IdJogo3)
                    .HasConstraintName("FK__Carrinho__idJogo__44FF419A");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__48B99DB7D6D9DB87");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.Cvv)
                    .HasColumnName("CVV")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DataCompra).HasColumnType("date");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.IdJogo2).HasColumnName("idJogo2");

                entity.Property(e => e.IdJogo3).HasColumnName("idJogo3");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeTitular)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCartao)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Validade).HasColumnType("date");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.CompraIdJogoNavigation)
                    .HasForeignKey(d => d.IdJogo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compra__idJogo__4E88ABD4");

                entity.HasOne(d => d.IdJogo2Navigation)
                    .WithMany(p => p.CompraIdJogo2Navigation)
                    .HasForeignKey(d => d.IdJogo2)
                    .HasConstraintName("FK__Compra__idJogo2__4F7CD00D");

                entity.HasOne(d => d.IdJogo3Navigation)
                    .WithMany(p => p.CompraIdJogo3Navigation)
                    .HasForeignKey(d => d.IdJogo3)
                    .HasConstraintName("FK__Compra__idJogo3__5070F446");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compra__idUsuari__4D94879B");
            });

            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.IdEstudio)
                    .HasName("PK__Estudio__F31FDB3603FB9E42");

                entity.Property(e => e.IdEstudio).HasColumnName("idEstudio");

                entity.Property(e => e.NomeEstudio)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.IdJogo)
                    .HasName("PK__Jogo__05C4E6654CF203DD");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.Caminho)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Capa).HasColumnType("image");

                entity.Property(e => e.DataLan).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdEstudio).HasColumnName("idEstudio");

                entity.Property(e => e.Promocao).HasDefaultValueSql("((0))");

                entity.Property(e => e.TituloJogo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.Jogo)
                    .HasForeignKey(d => d.IdEstudio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jogo__idEstudio__3C69FB99");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFFF9E585EF");

                entity.HasIndex(e => e.NomeTipoUsuario)
                    .HasName("UQ__TipoUsua__C6FB90A818D940C4")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A609C4ECE5");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105342D55D088")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdCarrinho).HasColumnName("idCarrinho");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCarrinhoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdCarrinho)
                    .HasConstraintName("FK__Usuario__idCarri__49C3F6B7");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__idTipoU__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
