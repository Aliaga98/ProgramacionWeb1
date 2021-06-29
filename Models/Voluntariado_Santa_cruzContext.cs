using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Login_Proyecto.Models
{
    public partial class Voluntariado_Santa_cruzContext : DbContext
    {
        public Voluntariado_Santa_cruzContext()
        {
        }

        public Voluntariado_Santa_cruzContext(DbContextOptions<Voluntariado_Santa_cruzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetalleDonacion> DetalleDonacion { get; set; }
        public virtual DbSet<DetalleVoluntarios> DetalleVoluntarios { get; set; }
        public virtual DbSet<Donadores> Donadores { get; set; }
        public virtual DbSet<Organizacion> Organizacion { get; set; }
        public virtual DbSet<Recolecion> Recolecion { get; set; }
        public virtual DbSet<Voluntariado> Voluntariado { get; set; }
        public virtual DbSet<Voluntario> Voluntario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localHost;Database=Voluntariado_Santa_cruz;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleDonacion>(entity =>
            {
                entity.ToTable("detalle_donacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdDonador).HasColumnName("idDonador");

                entity.Property(e => e.IdRecoleccion).HasColumnName("idRecoleccion");

                entity.HasOne(d => d.IdDonadorNavigation)
                    .WithMany(p => p.DetalleDonacion)
                    .HasForeignKey(d => d.IdDonador)
                    .HasConstraintName("FK__detalle_d__idDon__46E78A0C");

                entity.HasOne(d => d.IdRecoleccionNavigation)
                    .WithMany(p => p.DetalleDonacion)
                    .HasForeignKey(d => d.IdRecoleccion)
                    .HasConstraintName("FK__detalle_d__idRec__47DBAE45");
            });

            modelBuilder.Entity<DetalleVoluntarios>(entity =>
            {
                entity.ToTable("detalle_voluntarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdActi).HasColumnName("idActi");

                entity.Property(e => e.IdVolun).HasColumnName("idVolun");

                entity.HasOne(d => d.IdActiNavigation)
                    .WithMany(p => p.DetalleVoluntarios)
                    .HasForeignKey(d => d.IdActi)
                    .HasConstraintName("FK__detalle_v__idAct__3E52440B");

                entity.HasOne(d => d.IdVolunNavigation)
                    .WithMany(p => p.DetalleVoluntarios)
                    .HasForeignKey(d => d.IdVolun)
                    .HasConstraintName("FK__detalle_v__idVol__3F466844");
            });

            modelBuilder.Entity<Donadores>(entity =>
            {
                entity.ToTable("donadores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.ToTable("organizacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .HasColumnName("sede")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Socios).HasColumnName("socios");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recolecion>(entity =>
            {
                entity.ToTable("recolecion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Beneficiarios)
                    .HasColumnName("beneficiarios")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.IdOrga).HasColumnName("idOrga");

                entity.Property(e => e.Lugar)
                    .HasColumnName("lugar")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Necesidaes)
                    .HasColumnName("necesidaes")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOrgaNavigation)
                    .WithMany(p => p.Recolecion)
                    .HasForeignKey(d => d.IdOrga)
                    .HasConstraintName("FK__recolecio__idOrg__440B1D61");
            });

            modelBuilder.Entity<Voluntariado>(entity =>
            {
                entity.ToTable("voluntariado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cupos).HasColumnName("cupos");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrganizacion).HasColumnName("idOrganizacion");

                entity.Property(e => e.Lugar)
                    .HasColumnName("lugar")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.Voluntariado)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .HasConstraintName("FK__voluntari__idOrg__398D8EEE");
            });

            modelBuilder.Entity<Voluntario>(entity =>
            {
                entity.ToTable("voluntario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ci).HasColumnName("ci");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnName("departamento")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.TelefonoEmergencia).HasColumnName("telefonoEmergencia");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
