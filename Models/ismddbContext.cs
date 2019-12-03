using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ismdbackend.Models
{
    public partial class ismddbContext : DbContext
    {
        public ismddbContext()
        {
        }

        public ismddbContext(DbContextOptions<ismddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CambioRiesgos> CambioRiesgos { get; set; }
        public virtual DbSet<Cambios> Cambios { get; set; }
        public virtual DbSet<Capacidad> Capacidad { get; set; }
        public virtual DbSet<CatalogoCliente> CatalogoCliente { get; set; }
        public virtual DbSet<CatalogoTecnico> CatalogoTecnico { get; set; }
        public virtual DbSet<Incidente> Incidente { get; set; }
        public virtual DbSet<ModeloEntrega> ModeloEntrega { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Pruebas> Pruebas { get; set; }
        public virtual DbSet<RecursoCambio> RecursoCambio { get; set; }
        public virtual DbSet<RecursoDetalle> RecursoDetalle { get; set; }
        public virtual DbSet<RecursoEncabezado> RecursoEncabezado { get; set; }
        public virtual DbSet<Requerimiento> Requerimiento { get; set; }
        public virtual DbSet<Riesgo> Riesgo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVM649N\\SQLEXPRESS;Database=ismddb;User Id=Mendez; Password=M3nd3z; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CambioRiesgos>(entity =>
            {
                entity.HasKey(e => e.IdCambioRiego);

                entity.ToTable("cambio_riesgos");

                entity.Property(e => e.IdRiego).IsUnicode(false);
            });

            modelBuilder.Entity<Cambios>(entity =>
            {
                entity.HasKey(e => e.IdCambio);

                entity.ToTable("cambios");

                entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");

                entity.Property(e => e.Razon).IsUnicode(false);

                entity.Property(e => e.Solicitante).IsUnicode(false);
            });

            modelBuilder.Entity<Capacidad>(entity =>
            {
                entity.HasKey(e => e.IdCapacidad)
                    .HasName("PK__capacida__09429A2566712721");

                entity.ToTable("capacidad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatalogoCliente>(entity =>
            {
                entity.HasKey(e => e.IdCatalogoCliente)
                    .HasName("PK__catalogo__4A888C699A053777");

                entity.ToTable("catalogo_cliente");

                entity.Property(e => e.IdCatalogoCliente).ValueGeneratedNever();

                entity.Property(e => e.Ayuda)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Componente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Funcionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatalogoTecNavigation)
                    .WithMany(p => p.CatalogoCliente)
                    .HasForeignKey(d => d.IdCatalogoTec)
                    .HasConstraintName("fk_CatalogoCliente");
            });

            modelBuilder.Entity<CatalogoTecnico>(entity =>
            {
                entity.HasKey(e => e.IdCatalogoTec)
                    .HasName("PK__catalogo__E2584DAC69DF094E");

                entity.ToTable("catalogo_tecnico");

                entity.Property(e => e.Dependencias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRequerimientoNavigation)
                    .WithMany(p => p.CatalogoTecnico)
                    .HasForeignKey(d => d.IdRequerimiento)
                    .HasConstraintName("fk_CatalogoTecnico");
            });

            modelBuilder.Entity<Incidente>(entity =>
            {
                entity.HasKey(e => e.IdIncidente);

                entity.ToTable("incidente");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<ModeloEntrega>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__modelo_e__CC30D30CF0872006");

                entity.ToTable("modelo_entrega");

                entity.Property(e => e.IdProtecto).HasColumnName("idProtecto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__permiso__0D626EC86EC3905A");

                entity.ToTable("permiso");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__proveedo__E8B631AFB98F45A2");

                entity.ToTable("proveedor");

                entity.Property(e => e.Funcionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto);

                entity.ToTable("proyecto");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Encargado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Solicitante)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pruebas>(entity =>
            {
                entity.HasKey(e => e.IdPrueba);

                entity.ToTable("pruebas");

                entity.Property(e => e.Observaciones).IsUnicode(false);
            });

            modelBuilder.Entity<RecursoCambio>(entity =>
            {
                entity.HasKey(e => e.IdRecursoCambio);

                entity.ToTable("recurso_cambio");
            });

            modelBuilder.Entity<RecursoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdRecursoDet)
                    .HasName("PK__recurso___0BBCA806F3A324B5");

                entity.ToTable("recurso_detalle");

                entity.Property(e => e.Capacidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.RecursoDetalle)
                    .HasForeignKey(d => d.IdRecurso)
                    .HasConstraintName("fk_RecursoDetalle");
            });

            modelBuilder.Entity<RecursoEncabezado>(entity =>
            {
                entity.HasKey(e => e.IdRecurso)
                    .HasName("PK__recurso___B91948E96424D415");

                entity.ToTable("recurso_encabezado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requerimiento>(entity =>
            {
                entity.HasKey(e => e.IdRequerimiento)
                    .HasName("PK__requerim__BAFD1D0303F8AC62");

                entity.ToTable("requerimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prioridad)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Programador)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Riesgo>(entity =>
            {
                entity.HasKey(e => e.IdRiesgo)
                    .HasName("PK__riesgo__5D672788A00117DC");

                entity.ToTable("riesgo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__5B65BF97D362F1EB");

                entity.ToTable("usuario");

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
