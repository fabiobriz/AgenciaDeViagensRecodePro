using Microsoft.EntityFrameworkCore;
using AgenciaDeViagensRecodePro.Models;

namespace AgenciaDeViagensRecodePro.Models
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Hospedagem> Hospedagem { get; set; }
        public virtual DbSet<Pacote> Pacote { get; set; }
        public virtual DbSet<Passagem> Passagem { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=agenciaturismo;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466421B693E39");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Cliente__C1F89731B42930D4")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hospedagem>(entity =>
            {
                entity.ToTable("Hospedagem");

                entity.HasKey(e => e.IdHospedagem)
                    .HasName("PK__Hospedag__AAF786D5B01D56DB");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pacote>(entity =>
            {
                entity.ToTable("Pacote");

                entity.HasKey(e => e.IdPacote)
                    .HasName("PK__Pacote__40CE6F9C81CBDAD2");

                entity.Property(e => e.FkClienteIdCliente).HasColumnName("fk_Cliente_IdCliente");

                entity.Property(e => e.FkHospedagemIdHospedagem).HasColumnName("fk_Hospedagem_IdHospedagem");

                entity.Property(e => e.FkPassagemIdPassagem).HasColumnName("fk_Passagem_IdPassagem");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkClienteIdClienteNavigation)
                    .WithMany(p => p.Pacote)
                    .HasForeignKey(d => d.FkClienteIdCliente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pacote_2");

                entity.HasOne(d => d.FkHospedagemIdHospedagemNavigation)
                    .WithMany(p => p.Pacote)
                    .HasForeignKey(d => d.FkHospedagemIdHospedagem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pacote_4");

                entity.HasOne(d => d.FkPassagemIdPassagemNavigation)
                    .WithMany(p => p.Pacote)
                    .HasForeignKey(d => d.FkPassagemIdPassagem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pacote_3");
            });

            modelBuilder.Entity<Passagem>(entity =>
            {
                entity.ToTable("Passagem");

                entity.HasKey(e => e.IdPassagem)
                    .HasName("PK__Passagem__9509808BB723CE3A");

                entity.Property(e => e.DataChegada).HasColumnType("datetime");

                entity.Property(e => e.DataPartida).HasColumnType("datetime");

                entity.Property(e => e.LocalChegada)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalPartida)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.ToTable("Contato");

                entity.HasKey(e => e.IdContato);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mensagem)
                   .HasMaxLength(500)
                   .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
