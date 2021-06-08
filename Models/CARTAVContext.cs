﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIRestV2.Models
{
    public partial class CARTAVContext : DbContext
    {
        public CARTAVContext()
        {
        }

        public CARTAVContext(DbContextOptions<CARTAVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CentroCosto> CentroCostos { get; set; }
        public virtual DbSet<Certificacion> Certificacions { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ConfiguracionNivelCertificacion> ConfiguracionNivelCertificacions { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<DepartamentoNivel1> DepartamentoNivel1s { get; set; }
        public virtual DbSet<DepartamentoNivel2> DepartamentoNivel2s { get; set; }
        public virtual DbSet<DepartamentoNivel3> DepartamentoNivel3s { get; set; }
        public virtual DbSet<DocumentoPiezaProceso> DocumentoPiezaProcesos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<LineaProduccion> LineaProduccions { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<MaquinaFisica> MaquinaFisicas { get; set; }
        public virtual DbSet<MaquinaProceso> MaquinaProcesos { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MultiMediaPieza> MultiMediaPiezas { get; set; }
        public virtual DbSet<Nave> Naves { get; set; }
        public virtual DbSet<NivelCertificacion> NivelCertificacions { get; set; }
        public virtual DbSet<Operacion> Operacions { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<PerfilOperacionPermiso> PerfilOperacionPermisos { get; set; }
        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<PiezaCliente> PiezaClientes { get; set; }
        public virtual DbSet<Plantum> Planta { get; set; }
        public virtual DbSet<PreguntaGeneral> PreguntaGenerals { get; set; }
        public virtual DbSet<PreguntaMaquina> PreguntaMaquinas { get; set; }
        public virtual DbSet<PreguntaMaquinaGeneral> PreguntaMaquinaGenerals { get; set; }
        public virtual DbSet<PreguntaPieza> PreguntaPiezas { get; set; }
        public virtual DbSet<PreguntaPiezaGeneral> PreguntaPiezaGenerals { get; set; }
        public virtual DbSet<PreguntaProceso> PreguntaProcesos { get; set; }
        public virtual DbSet<PreguntaProcesoGeneral> PreguntaProcesoGenerals { get; set; }
        public virtual DbSet<PreguntaPtGeneral> PreguntaPtGenerals { get; set; }
        public virtual DbSet<Proceso> Procesos { get; set; }
        public virtual DbSet<ProcesoPiezaMaquina> ProcesoPiezaMaquinas { get; set; }
        public virtual DbSet<ProcessLog> ProcessLogs { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<ResourceValidacionCampo> ResourceValidacionCampos { get; set; }
        public virtual DbSet<RespuestaMaquina> RespuestaMaquinas { get; set; }
        public virtual DbSet<RespuestaPieza> RespuestaPiezas { get; set; }
        public virtual DbSet<RespuestaProceso> RespuestaProcesos { get; set; }
        public virtual DbSet<ResultadoMaquina> ResultadoMaquinas { get; set; }
        public virtual DbSet<ResultadoPieza> ResultadoPiezas { get; set; }
        public virtual DbSet<ResultadoProceso> ResultadoProcesos { get; set; }
        public virtual DbSet<TipoAcceso> TipoAccesos { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoPreguntum> TipoPregunta { get; set; }
        public virtual DbSet<UnidadNegocio> UnidadNegocios { get; set; }
        public virtual DbSet<VideoPiezaProceso> VideoPiezaProcesos { get; set; }
        public virtual DbSet<VwMaquinaPregunta> VwMaquinaPreguntas { get; set; }
        public virtual DbSet<VwPiezaCliente> VwPiezaClientes { get; set; }
        public virtual DbSet<VwPiezasMultimedia> VwPiezasMultimedias { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLOMARIN;Database=CARTAV;Trusted_Connection=False;User ID=sa;Password=O1p5r1r2b3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CentroCosto>(entity =>
            {
                entity.HasKey(e => e.IdCentroCosto)
                    .HasName("PK__CentroCo__EE3651E878DA6E84");

                entity.ToTable("CentroCosto");

                entity.HasIndex(e => e.IdCentroCostoExterno, "UQ__CentroCo__DBD8185BC752D50A")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescCentroCosto)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Certificacion>(entity =>
            {
                entity.HasKey(e => e.IdCertificacion)
                    .HasName("PK__Certific__29FBE98DECAB509B");

                entity.ToTable("Certificacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCertificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCertificador).HasColumnType("datetime");

                entity.Property(e => e.FechaEntrenamiento).HasColumnType("datetime");

                entity.Property(e => e.FechaMentor).HasColumnType("datetime");

                entity.Property(e => e.FechaResponsable).HasColumnType("datetime");

                entity.Property(e => e.TokenCertificador).IsUnicode(false);

                entity.Property(e => e.TokenMentor).IsUnicode(false);

                entity.Property(e => e.TokenResponsable).IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D594664296591F36");

                entity.ToTable("Cliente");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Contacto).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<ConfiguracionNivelCertificacion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguraNivelCertifica);

                entity.ToTable("ConfiguracionNivelCertificacion");

                entity.Property(e => e.IdsPerfilExaminan)
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdsPerfilFirman)
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNivelCertificacionNavigation)
                    .WithMany(p => p.ConfiguracionNivelCertificacions)
                    .HasForeignKey(d => d.IdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracionNivelCertificacionIdNivel_NivelCertificacionID");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433DBB10D2A5");

                entity.ToTable("Departamento");

                entity.HasIndex(e => e.IdDepartamentExterno, "UQ__Departam__C342F38D4F2B2A7B")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Departamento");
            });

            modelBuilder.Entity<DepartamentoNivel1>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentoNivel1)
                    .HasName("PK__Departam__412E0BC3C147D20F");

                entity.ToTable("DepartamentoNivel1");

                entity.HasIndex(e => e.IdDepartamentExterno, "UQ__Departam__C342F38DD4EA060C")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.DepartamentoNivel1s)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartamentoNivel1_Departamento");
            });

            modelBuilder.Entity<DepartamentoNivel2>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentoNivel2)
                    .HasName("PK__Departam__412E0BC0013DD297");

                entity.ToTable("DepartamentoNivel2");

                entity.HasIndex(e => e.IdDepartamentExterno, "UQ__Departam__C342F38DA43DCE66")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNivel1Navigation)
                    .WithMany(p => p.DepartamentoNivel2s)
                    .HasForeignKey(d => d.IdDepartamentoNivel1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartamentoNivel2_DepartamentoNivel1");
            });

            modelBuilder.Entity<DepartamentoNivel3>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentoNivel3)
                    .HasName("PK__Departam__412E0BC1B35F9C9D");

                entity.ToTable("DepartamentoNivel3");

                entity.HasIndex(e => e.IdDepartamentExterno, "UQ__Departam__C342F38DB69A1A8B")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNivel2Navigation)
                    .WithMany(p => p.DepartamentoNivel3s)
                    .HasForeignKey(d => d.IdDepartamentoNivel2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartamentoNivel3_DepartamentoNivel2");
            });

            modelBuilder.Entity<DocumentoPiezaProceso>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoPiezaProceso)
                    .HasName("PK__Document__1008D647ED445A68");

                entity.ToTable("DocumentoPiezaProceso");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PKEmpleado");

                entity.ToTable("Empleado");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno).IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CuentaUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NominaJefe)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NumeroNomina)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel1Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel1)
                    .HasConstraintName("FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel1");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel2Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel2)
                    .HasConstraintName("FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel2");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel3Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel3)
                    .HasConstraintName("FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel3");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_EmpleadoIdiomaIdIdioma");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.IdFabricante)
                    .HasName("PK__Fabrican__1F4C254A64F3097B");

                entity.ToTable("Fabricante");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Contacto).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PKIdioma0BA1525F05C8D52A");

                entity.ToTable("Idioma");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoIdioma)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Idioma1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Idioma");
            });

            modelBuilder.Entity<LineaProduccion>(entity =>
            {
                entity.ToTable("LineaProduccion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionLinea).IsRequired();

                entity.Property(e => e.NombreLinea).IsRequired();

                entity.HasOne(d => d.IdNaveNavigation)
                    .WithMany(p => p.LineaProduccions)
                    .HasForeignKey(d => d.IdNave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineaProduccion_NaveidNave");
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.IdMaquina)
                    .HasName("PK_Maquina_9A2F321BE6366944");

                entity.ToTable("Maquina");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.FabricanteIdFabricanteNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.FabricanteIdFabricante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaFabricante_FabricanteIdFabricante");

                entity.HasOne(d => d.TipoAccesoIdTipoAccesoNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.TipoAccesoIdTipoAcceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaTipoAcceso_TipoAccesoIdTipoAcceso");
            });

            modelBuilder.Entity<MaquinaFisica>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaFisica)
                    .HasName("PK_Maquina_5BE456CBA6BE8746");

                entity.ToTable("MaquinaFisica");

                entity.Property(e => e.Nserie)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("NSerie");

                entity.Property(e => e.Ubicacion).IsUnicode(false);

                entity.HasOne(d => d.LineaProduccionIdLineaProduccionNavigation)
                    .WithMany(p => p.MaquinaFisicas)
                    .HasForeignKey(d => d.LineaProduccionIdLineaProduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaFisicaLineaProduccion_LineaProduccionIdLineaProduccion");

                entity.HasOne(d => d.MaquinaIdMaquinaNavigation)
                    .WithMany(p => p.MaquinaFisicas)
                    .HasForeignKey(d => d.MaquinaIdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaFisicaMaquina_MaquinaIdMaquina");

                entity.HasOne(d => d.NaveIdNaveNavigation)
                    .WithMany(p => p.MaquinaFisicas)
                    .HasForeignKey(d => d.NaveIdNave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaFisicaNave_NaveIdNave");

                entity.HasOne(d => d.PlantaIdPlantaNavigation)
                    .WithMany(p => p.MaquinaFisicas)
                    .HasForeignKey(d => d.PlantaIdPlanta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaFisicaPlanta_PlantaIdPlanta");
            });

            modelBuilder.Entity<MaquinaProceso>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaProceso);

                entity.ToTable("MaquinaProceso");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ProcesoIdProcesoNavigation)
                    .WithMany(p => p.MaquinaProcesos)
                    .HasForeignKey(d => d.ProcesoIdProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaquinaProcesoProceso_ProcesoIdProceso");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.NombreMenu)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MultiMediaPieza>(entity =>
            {
                entity.ToTable("MultiMediaPieza");

                entity.Property(e => e.Extension).HasMaxLength(50);

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Tamanio).HasMaxLength(50);

                entity.Property(e => e.TipoMedia)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(50);

                entity.HasOne(d => d.IdPiezaNavigation)
                    .WithMany(p => p.MultiMediaPiezas)
                    .HasForeignKey(d => d.IdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MultiMediaPieza_MultiMediaPiezaIdPieza");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.MultiMediaPiezas)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MultiMediaIdTipoDocumento_TipoDocumentoId");
            });

            modelBuilder.Entity<Nave>(entity =>
            {
                entity.HasKey(e => e.IdNave)
                    .HasName("PK_Nave_35A7535AAB30ED73");

                entity.ToTable("Nave");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.PlantaIdPlantaNavigation)
                    .WithMany(p => p.Naves)
                    .HasForeignKey(d => d.PlantaIdPlanta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NavePlanta_PlantaIdPlanta");
            });

            modelBuilder.Entity<NivelCertificacion>(entity =>
            {
                entity.HasKey(e => e.IdNivelCertificacion)
                    .HasName("PK_Nivel_2CC43D71AACAD5C8");

                entity.ToTable("NivelCertificacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DescripcionNivelCertificacion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NombreNivelCertificacion).IsRequired();
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.ToTable("Operacion");

                entity.Property(e => e.NombreMenu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NombrePagina)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Operacion1)
                    .IsRequired()
                    .HasColumnName("Operacion");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Menu");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfil");

                entity.Property(e => e.Perfil1)
                    .IsRequired()
                    .HasColumnName("Perfil");
            });

            modelBuilder.Entity<PerfilOperacionPermiso>(entity =>
            {
                entity.ToTable("PerfilOperacionPermiso");

                entity.Property(e => e.Ver)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.PerfilOperacionPermisos)
                    .HasForeignKey(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilOperacionPermiso_Operacion");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.PerfilOperacionPermisos)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilOperacionPermiso_Perfil");
            });

            modelBuilder.Entity<Pieza>(entity =>
            {
                entity.HasKey(e => e.IdPieza)
                    .HasName("PK_Pieza_D20ECB11F4B5FCCF");

                entity.ToTable("Pieza");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NumeroParte).IsRequired();
            });

            modelBuilder.Entity<PiezaCliente>(entity =>
            {
                entity.ToTable("PiezaCliente");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PiezaIdPiezaNavigation)
                    .WithMany(p => p.PiezaClientes)
                    .HasForeignKey(d => d.PiezaIdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PiezaClientePieza_PiezaIdPieza");
            });

            modelBuilder.Entity<Plantum>(entity =>
            {
                entity.HasKey(e => e.IdPlanta)
                    .HasName("PK__Plantas__4096680B551E7DE9");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Planta).IsUnicode(false);
            });

            modelBuilder.Entity<PreguntaGeneral>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaGeneral);

                entity.ToTable("PreguntaGeneral");

                entity.Property(e => e.Pregunta).IsRequired();

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaGenerals)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreguntaGeneral_Idioma");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaGenerals)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreguntaGeneral_NivelCertificacion");

                entity.HasOne(d => d.TipoPreguntaIdTipoPreguntaNavigation)
                    .WithMany(p => p.PreguntaGenerals)
                    .HasForeignKey(d => d.TipoPreguntaIdTipoPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreguntaGeneral_TipoPregunta");
            });

            modelBuilder.Entity<PreguntaMaquina>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaMaquina)
                    .HasName("PK__Pregunta__B63CDED2266C1596");

                entity.ToTable("PreguntaMaquina");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);
            });

            modelBuilder.Entity<PreguntaMaquinaGeneral>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaMaquina)
                    .HasName("PK__Pregunta__31ABB522E63257E4");

                entity.ToTable("PreguntaMaquinaGeneral");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Orden)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaMaquinaGenerals)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Maquina_Generales_Idioma_Idioma_Id_Idioma");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaMaquinaGenerals)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Maquina_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion");
            });

            modelBuilder.Entity<PreguntaPieza>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaPieza)
                    .HasName("PK__Pregunta__4F0326314772454F");

                entity.ToTable("PreguntaPieza");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaPiezas)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Piezas_Idioma_Idioma_Id_Idioma");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaPiezas)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Piezas_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion");

                entity.HasOne(d => d.ProcesoPiezaMaquinaIdProcesoPiezaMaquinaNavigation)
                    .WithMany(p => p.PreguntaPiezas)
                    .HasForeignKey(d => d.ProcesoPiezaMaquinaIdProcesoPiezaMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Piezas_Piezas_Piezas_Id_Pieza");
            });

            modelBuilder.Entity<PreguntaPiezaGeneral>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaPieza)
                    .HasName("PK__Pregunta__4F03263192CFAEDE");

                entity.ToTable("PreguntaPiezaGeneral");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaPiezaGenerals)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Piezas_Generales_Idioma_Idioma_Id_Idioma");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaPiezaGenerals)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Piezas_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion");
            });

            modelBuilder.Entity<PreguntaProceso>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaProceso)
                    .HasName("PK__Pregunta__2637C0FB04D15390");

                entity.ToTable("PreguntaProceso");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaProcesos)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Procesos_Idioma_Idioma_Id_Idioma");

                entity.HasOne(d => d.MaquinaProcesoIdMaquinaProcesoNavigation)
                    .WithMany(p => p.PreguntaProcesos)
                    .HasForeignKey(d => d.MaquinaProcesoIdMaquinaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Procesos_Procesos_Procesos_Id_Proceso");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaProcesos)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Procesos_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion");
            });

            modelBuilder.Entity<PreguntaProcesoGeneral>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaProceso)
                    .HasName("PK__Pregunta__2637C0FB3AF97B58");

                entity.ToTable("PreguntaProcesoGeneral");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaProcesoGenerals)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Procesos_Generales_Idioma_Idioma_Id_Idioma");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaProcesoGenerals)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Procesos_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion");
            });

            modelBuilder.Entity<PreguntaPtGeneral>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaPt)
                    .HasName("PK__Pregunta__5DAB046FB9BE4BBB");

                entity.ToTable("PreguntaPtGeneral");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntaPtGenerals)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Pt_Generales_Idioma_Idioma_Id_Idioma");

                entity.HasOne(d => d.NivelCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntaPtGenerals)
                    .HasForeignKey(d => d.NivelCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Preguntas_Pt_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdProceso)
                    .HasName("PK__Procesos__4D1766E4A1132DCA");

                entity.ToTable("Proceso");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo).IsRequired();

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcesoPiezaMaquina>(entity =>
            {
                entity.HasKey(e => e.IdProcesoPiezaMaquina);

                entity.ToTable("ProcesoPiezaMaquina");

                entity.HasOne(d => d.MaquinaProcesoIdMaquinaProcesoNavigation)
                    .WithMany(p => p.ProcesoPiezaMaquinas)
                    .HasForeignKey(d => d.MaquinaProcesoIdMaquinaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcesoPiezaMaquina_MaquinaProceso");

                entity.HasOne(d => d.PiezaIdPiezaNavigation)
                    .WithMany(p => p.ProcesoPiezaMaquinas)
                    .HasForeignKey(d => d.PiezaIdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcesoPiezaMaquina_Pieza");
            });

            modelBuilder.Entity<ProcessLog>(entity =>
            {
                entity.ToTable("ProcessLog");

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("IP");

                entity.Property(e => e.Respuesta).IsRequired();
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK__Puesto__ADAC6B9C50424103");

                entity.ToTable("Puesto");

                entity.HasIndex(e => e.IdPuestoExterno, "UQ__Puesto__52F767D7736CD6F1")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescPuesto)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResourceValidacionCampo>(entity =>
            {
                entity.HasKey(e => e.IdReglaValidacion)
                    .HasName("PK_Validaciones_Resource");

                entity.ToTable("ResourceValidacionCampo");

                entity.Property(e => e.CodigoErrorRequerido).HasDefaultValueSql("((0))");

                entity.Property(e => e.Formato)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Ninguno')");

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Requerido).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoDato)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'string')");
            });

            modelBuilder.Entity<RespuestaMaquina>(entity =>
            {
                entity.HasKey(e => e.IdRespuestaMaquina)
                    .HasName("PK__Respuest__FED33680247A3C19");

                entity.ToTable("RespuestaMaquina");

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.PreguntaMaquinaIdPreguntaMaquinaNavigation)
                    .WithMany(p => p.RespuestaMaquinas)
                    .HasForeignKey(d => d.PreguntaMaquinaIdPreguntaMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Respuestas_Maquina_Preguntas_Maquina_Preguntas_Maquina_Id_Pregunta_Maquina");

                entity.HasOne(d => d.ResultadoMaquinaIdResultadoMaquinaNavigation)
                    .WithMany(p => p.RespuestaMaquinas)
                    .HasForeignKey(d => d.ResultadoMaquinaIdResultadoMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Respuestas_Maquina_Resultados_Maquina_Resultados_Maquina_Id_Resultado_Maquina");
            });

            modelBuilder.Entity<RespuestaPieza>(entity =>
            {
                entity.HasKey(e => e.IdResultadoPieza)
                    .HasName("PK__Respuest__50209975041817B2");

                entity.ToTable("RespuestaPieza");

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.PreguntaPiezaIdPreguntaPiezaNavigation)
                    .WithMany(p => p.RespuestaPiezas)
                    .HasForeignKey(d => d.PreguntaPiezaIdPreguntaPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Respuestas_Pieza_Preguntas_Piezas_Preguntas_Piezas_Id_Pregunta_Pieza");

                entity.HasOne(d => d.ResultadoPiezaIdResultadoPiezaNavigation)
                    .WithMany(p => p.RespuestaPiezas)
                    .HasForeignKey(d => d.ResultadoPiezaIdResultadoPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Respuestas_Pieza_Resultados_Pieza_Resultados_Pieza_Id_Resultado_Pieza");
            });

            modelBuilder.Entity<RespuestaProceso>(entity =>
            {
                entity.HasKey(e => e.IdRespuestaProceso)
                    .HasName("PK__Respuest__AC46E28229D53350");

                entity.ToTable("RespuestaProceso");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.PreguntaProcesoIdPreguntaProcesoNavigation)
                    .WithMany(p => p.RespuestaProcesos)
                    .HasForeignKey(d => d.PreguntaProcesoIdPreguntaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Respuestas_Proceso_Preguntas_Procesos_Preguntas_Procesos_Id_Pregunta_Proceso");

                entity.HasOne(d => d.ResultadoProcesoIdResultadoProcesoNavigation)
                    .WithMany(p => p.RespuestaProcesos)
                    .HasForeignKey(d => d.ResultadoProcesoIdResultadoProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Respuestas_Proceso_Resultados_Proceso_Resultados_Proceso_Id_Resultado_Proceso");
            });

            modelBuilder.Entity<ResultadoMaquina>(entity =>
            {
                entity.HasKey(e => e.IdResultadoMaquina)
                    .HasName("PK__Resultad__162906BB0C0F7D30");

                entity.ToTable("ResultadoMaquina");
            });

            modelBuilder.Entity<ResultadoPieza>(entity =>
            {
                entity.HasKey(e => e.IdResultadoPieza)
                    .HasName("PK__Resultad__502099757E64E5C2");

                entity.ToTable("ResultadoPieza");
            });

            modelBuilder.Entity<ResultadoProceso>(entity =>
            {
                entity.HasKey(e => e.IdResultadoProceso)
                    .HasName("PK__Resultad__CCF7C4ED209CF435");

                entity.ToTable("ResultadoProceso");
            });

            modelBuilder.Entity<TipoAcceso>(entity =>
            {
                entity.HasKey(e => e.IdTipoAcceso)
                    .HasName("PK__TipoAcce__F55E50EC1DED2A6A");

                entity.ToTable("TipoAcceso");

                entity.Property(e => e.DescTipoAcceso)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TipoDocumento");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.TipoDocumento1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TipoDocumento");
            });

            modelBuilder.Entity<TipoPreguntum>(entity =>
            {
                entity.HasKey(e => e.IdTipoPregunta);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UnidadNegocio>(entity =>
            {
                entity.HasKey(e => e.IdUnidadNegocio)
                    .HasName("PK__UnidadNe__E33E25955C0835F8");

                entity.ToTable("UnidadNegocio");

                entity.Property(e => e.DescUnidadNegocio)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VideoPiezaProceso>(entity =>
            {
                entity.HasKey(e => e.IdVideoPiezaProceso)
                    .HasName("PK__VideoPie__89EBF911C9D938DE");

                entity.ToTable("VideoPiezaProceso");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwMaquinaPregunta>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_MAQUINA_PREGUNTAS");

                entity.Property(e => e.CountPreguntas).HasColumnName("countPreguntas");

                entity.Property(e => e.CountProcesos).HasColumnName("countProcesos");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPiezaCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_PIEZA_CLIENTE");

                entity.Property(e => e.Contacto).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<VwPiezasMultimedia>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_PIEZAS_MULTIMEDIAS");

                entity.Property(e => e.CountClientes).HasColumnName("countClientes");

                entity.Property(e => e.CountDoc).HasColumnName("countDoc");

                entity.Property(e => e.CountImg).HasColumnName("countImg");

                entity.Property(e => e.CountVideo).HasColumnName("countVideo");

                entity.Property(e => e.CountWorkflow).HasColumnName("countWorkflow");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NumeroParte).IsRequired();
            });

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.HasKey(e => e.IdWorkFlow);

                entity.ToTable("Workflow");

                entity.HasOne(d => d.PiezaIdPiezaNavigation)
                    .WithMany(p => p.Workflows)
                    .HasForeignKey(d => d.PiezaIdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Pieza");

                entity.HasOne(d => d.ProcesoIdProcesoNavigation)
                    .WithMany(p => p.Workflows)
                    .HasForeignKey(d => d.ProcesoIdProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Proceso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
