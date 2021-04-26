using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIRest.Models
{
    public partial class Carta_vContext : DbContext
    {
        public Carta_vContext()
        {
        }

        public Carta_vContext(DbContextOptions<Carta_vContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CentroCosto> CentroCostos { get; set; }
        public virtual DbSet<Certificacione> Certificaciones { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<DepartamentoNivel1> DepartamentoNivel1s { get; set; }
        public virtual DbSet<DepartamentoNivel2> DepartamentoNivel2s { get; set; }
        public virtual DbSet<DepartamentoNivel3> DepartamentoNivel3s { get; set; }
        public virtual DbSet<DocumentosPiezaProceso> DocumentosPiezaProcesos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<LineasProduccion> LineasProduccions { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<MaquinasProceso> MaquinasProcesos { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MáquinasFisica> MáquinasFisicas { get; set; }
        public virtual DbSet<Nafe> Naves { get; set; }
        public virtual DbSet<NivelesCertificacion> NivelesCertificacions { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<PerfilOperacionPermiso> PerfilOperacionPermisos { get; set; }
        public virtual DbSet<Perfile> Perfiles { get; set; }
        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<PiezasCliente> PiezasClientes { get; set; }
        public virtual DbSet<Planta> Plantas { get; set; }
        public virtual DbSet<PreguntasMaquina> PreguntasMaquinas { get; set; }
        public virtual DbSet<PreguntasMaquinaGenerale> PreguntasMaquinaGenerales { get; set; }
        public virtual DbSet<PreguntasPieza> PreguntasPiezas { get; set; }
        public virtual DbSet<PreguntasPiezasGenerale> PreguntasPiezasGenerales { get; set; }
        public virtual DbSet<PreguntasProceso> PreguntasProcesos { get; set; }
        public virtual DbSet<PreguntasProcesosGenerale> PreguntasProcesosGenerales { get; set; }
        public virtual DbSet<PreguntasPtGenerale> PreguntasPtGenerales { get; set; }
        public virtual DbSet<Proceso> Procesos { get; set; }
        public virtual DbSet<ProcesosPiezasMaquina> ProcesosPiezasMaquinas { get; set; }
        public virtual DbSet<ProcessLog> ProcessLogs { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<ResourceValidacionesCampo> ResourceValidacionesCampos { get; set; }
        public virtual DbSet<RespuestasMaquina> RespuestasMaquinas { get; set; }
        public virtual DbSet<RespuestasPieza> RespuestasPiezas { get; set; }
        public virtual DbSet<RespuestasProceso> RespuestasProcesos { get; set; }
        public virtual DbSet<ResultadosMaquina> ResultadosMaquinas { get; set; }
        public virtual DbSet<ResultadosPieza> ResultadosPiezas { get; set; }
        public virtual DbSet<ResultadosProceso> ResultadosProcesos { get; set; }
        public virtual DbSet<TipoAcceso> TipoAccesos { get; set; }
        public virtual DbSet<UnidadNegocio> UnidadNegocios { get; set; }
        public virtual DbSet<VideosPiezaProceso> VideosPiezaProcesos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Carta_v;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CentroCosto>(entity =>
            {
                entity.HasKey(e => e.IdCentroCosto)
                    .HasName("PK__Centro_c__5E1304C043316CBB");

                entity.ToTable("Centro_costo");

                entity.HasIndex(e => e.IdCentroCostoExt, "UQ__Centro_c__7587080653A75364")
                    .IsUnique();

                entity.Property(e => e.IdCentroCosto).HasColumnName("id_centro_costo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescCentroCosto)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("desc_centro_costo");

                entity.Property(e => e.DuenoCeco).HasColumnName("dueno_ceco");

                entity.Property(e => e.IdCentroCostoExt).HasColumnName("id_centro_costo_ext");
            });

            modelBuilder.Entity<Certificacione>(entity =>
            {
                entity.HasKey(e => e.IdCertificacion)
                    .HasName("PK__Certific__D22535EE77990156");

                entity.Property(e => e.IdCertificacion).HasColumnName("id_certificacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCertificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_certificacion");

                entity.Property(e => e.FechaCertificador)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_certificador");

                entity.Property(e => e.FechaEntrenamiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_entrenamiento");

                entity.Property(e => e.FechaMentor)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_mentor");

                entity.Property(e => e.FechaResponsable)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_responsable");

                entity.Property(e => e.IdCertificador).HasColumnName("id_certificador");

                entity.Property(e => e.IdMentor).HasColumnName("id_mentor");

                entity.Property(e => e.IdResponsable).HasColumnName("id_responsable");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.Property(e => e.TokenCertificador)
                    .IsUnicode(false)
                    .HasColumnName("token_certificador");

                entity.Property(e => e.TokenMentor)
                    .IsUnicode(false)
                    .HasColumnName("token_mentor");

                entity.Property(e => e.TokenResponsable)
                    .IsUnicode(false)
                    .HasColumnName("token_responsable");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__677F38F5A0D78E87");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Contacto)
                    .IsUnicode(false)
                    .HasColumnName("contacto");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__64F37A16289A04FF");

                entity.ToTable("Departamento");

                entity.HasIndex(e => e.IdDepartamentExt, "UQ__Departam__E1680BCF2063EF81")
                    .IsUnique();

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.IdDepartamentExt).HasColumnName("id_departament_ext");
            });

            modelBuilder.Entity<DepartamentoNivel1>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentoNivel1)
                    .HasName("PK__Departam__93BE9ABD28C8817B");

                entity.ToTable("Departamento_nivel1");

                entity.HasIndex(e => e.IdDepartamentExt, "UQ__Departam__E1680BCF95BE7B16")
                    .IsUnique();

                entity.Property(e => e.IdDepartamentoNivel1).HasColumnName("id_departamento_nivel1");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.IdDepartamentExt).HasColumnName("id_departament_ext");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.DepartamentoNivel1s)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_nivel1_Departamento");
            });

            modelBuilder.Entity<DepartamentoNivel2>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentoNivel2)
                    .HasName("PK__Departam__93BE9ABEF9444593");

                entity.ToTable("Departamento_nivel2");

                entity.HasIndex(e => e.IdDepartamentExt, "UQ__Departam__E1680BCF40CD7F69")
                    .IsUnique();

                entity.Property(e => e.IdDepartamentoNivel2).HasColumnName("id_departamento_nivel2");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.IdDepartamentExt).HasColumnName("id_departament_ext");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdDepartamentoNivel1).HasColumnName("id_departamento_nivel1");

                entity.HasOne(d => d.IdDepartamentoNivel1Navigation)
                    .WithMany(p => p.DepartamentoNivel2s)
                    .HasForeignKey(d => d.IdDepartamentoNivel1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_nivel2_Departamento_nivel1");
            });

            modelBuilder.Entity<DepartamentoNivel3>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentoNivel3)
                    .HasName("PK__Departam__93BE9ABF17D487A1");

                entity.ToTable("Departamento_nivel3");

                entity.HasIndex(e => e.IdDepartamentExt, "UQ__Departam__E1680BCF96F82C9C")
                    .IsUnique();

                entity.Property(e => e.IdDepartamentoNivel3).HasColumnName("id_departamento_nivel3");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.IdDepartamentExt).HasColumnName("id_departament_ext");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdDepartamentoNivel2).HasColumnName("id_departamento_nivel2");

                entity.HasOne(d => d.IdDepartamentoNivel2Navigation)
                    .WithMany(p => p.DepartamentoNivel3s)
                    .HasForeignKey(d => d.IdDepartamentoNivel2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_nivel3_Departamento_nivel2");
            });

            modelBuilder.Entity<DocumentosPiezaProceso>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoPiezaProceso)
                    .HasName("PK__Document__5AE3C5B294EB7CE6");

                entity.ToTable("Documentos_pieza_proceso");

                entity.Property(e => e.IdDocumentoPiezaProceso).HasColumnName("id_documento_pieza_proceso");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno)
                    .IsUnicode(false)
                    .HasColumnName("apellido_materno");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("apellido_paterno");

                entity.Property(e => e.CentroCostoIdCentroCosto).HasColumnName("Centro_costo_id_centro_costo");

                entity.Property(e => e.DepartamentoIdDepartamentoNivel0).HasColumnName("Departamento_id_departamento_nivel0");

                entity.Property(e => e.DepartamentoIdDepartamentoNivel1).HasColumnName("Departamento_id_departamento_nivel1");

                entity.Property(e => e.DepartamentoIdDepartamentoNivel2).HasColumnName("Departamento_id_departamento_nivel2");

                entity.Property(e => e.DepartamentoIdDepartamentoNivel3).HasColumnName("Departamento_id_departamento_nivel3");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FIngreso)
                    .HasColumnType("date")
                    .HasColumnName("f_ingreso");

                entity.Property(e => e.FNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("f_nacimiento");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NNomina)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("n_nomina");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NominaJefe)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nomina_jefe");

                entity.Property(e => e.PuestosIdPuesto).HasColumnName("Puestos_id_puesto");

                entity.Property(e => e.UnidadNegocioIdUnidadNegocio).HasColumnName("Unidad_negocio_id_unidad_negocio");

                entity.HasOne(d => d.CentroCostoIdCentroCostoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CentroCostoIdCentroCosto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_centro_costo_centro_costo_id_centro_costo");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel0Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel0)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_departamento_departamento_id_departamento_nivel0");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel1Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel1)
                    .HasConstraintName("empleados_departamento_departamento_id_departamento_nivel1");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel2Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel2)
                    .HasConstraintName("empleados_departamento_departamento_id_departamento_nivel2");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNivel3Navigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoIdDepartamentoNivel3)
                    .HasConstraintName("empleados_departamento_departamento_id_departamento_nivel3");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_mpleados_idioma_id_idioma");

                entity.HasOne(d => d.PuestosIdPuestoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.PuestosIdPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_puestos_puestos_id_puesto");

                entity.HasOne(d => d.UnidadNegocioIdUnidadNegocioNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.UnidadNegocioIdUnidadNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("empleados_unidad_negocio_unidad_negocio_id_unidad_negocio");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.IdFabricante)
                    .HasName("PK__Fabrican__01CEE911756A7838");

                entity.ToTable("Fabricante");

                entity.Property(e => e.IdFabricante).HasColumnName("id_fabricante");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Contacto)
                    .IsUnicode(false)
                    .HasColumnName("contacto");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PK__Idioma__0BA1525F05C8D52A");

                entity.ToTable("Idioma");

                entity.Property(e => e.IdIdioma).HasColumnName("id_idioma");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoIdioma)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Idioma");

                entity.Property(e => e.Idioma1)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("idioma");
            });

            modelBuilder.Entity<LineasProduccion>(entity =>
            {
                entity.ToTable("Lineas_Produccion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionLinea)
                    .IsRequired()
                    .HasColumnName("Descripcion_Linea");

                entity.Property(e => e.IdNave).HasColumnName("Id_Nave");

                entity.Property(e => e.NombreLinea)
                    .IsRequired()
                    .HasColumnName("Nombre_Linea");

                entity.HasOne(d => d.IdNaveNavigation)
                    .WithMany(p => p.LineasProduccions)
                    .HasForeignKey(d => d.IdNave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lineas_Produccion_Naves_id_Naves");
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.IdMaquina)
                    .HasName("PK__Maquinas__9A2F321BE6366944");

                entity.Property(e => e.IdMaquina).HasColumnName("id_maquina");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CantidadAccesoMultiple).HasColumnName("cantidad_acceso_multiple");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FabricanteIdFabricante).HasColumnName("Fabricante_id_fabricante");

                entity.Property(e => e.MaquinaPt).HasColumnName("maquina_pt");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoAccesoIdTipoAcceso).HasColumnName("Tipo_acceso_id_tipo_acceso");

                entity.HasOne(d => d.FabricanteIdFabricanteNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.FabricanteIdFabricante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("maquinas_fabricante_fabricante_id_fabricante");

                entity.HasOne(d => d.TipoAccesoIdTipoAccesoNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.TipoAccesoIdTipoAcceso)
                    .HasConstraintName("maquinas_tipo_acceso_tipo_acceso_id_tipo_acceso");
            });

            modelBuilder.Entity<MaquinasProceso>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Maquinas_procesos");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MaquinasIdMaquina)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Maquinas_id_maquina");

                entity.Property(e => e.ProcesosIdProceso).HasColumnName("Procesos_id_proceso");

                entity.HasOne(d => d.ProcesosIdProcesoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProcesosIdProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("maquinas_procesos_procesos_procesos_id_proceso");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.NombreMenu)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Nombre_Menu");
            });

            modelBuilder.Entity<MáquinasFisica>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaFisica)
                    .HasName("PK__Máquinas__5BE456CBA6BE8746");

                entity.ToTable("Máquinas_fisicas");

                entity.Property(e => e.IdMaquinaFisica).HasColumnName("id_maquina_fisica");

                entity.Property(e => e.MaquinasIdMaquina).HasColumnName("Maquinas_id_maquina");

                entity.Property(e => e.NSerie)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("n_serie");

                entity.Property(e => e.NavesIdNave).HasColumnName("Naves_id_nave");

                entity.Property(e => e.Ubicacion)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.MaquinasIdMaquinaNavigation)
                    .WithMany(p => p.MáquinasFisicas)
                    .HasForeignKey(d => d.MaquinasIdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("máquinas_fisicas_maquinas_maquinas_id_maquina");

                entity.HasOne(d => d.NavesIdNaveNavigation)
                    .WithMany(p => p.MáquinasFisicas)
                    .HasForeignKey(d => d.NavesIdNave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("máquinas_fisicas_naves_naves_id_nave");
            });

            modelBuilder.Entity<Nafe>(entity =>
            {
                entity.HasKey(e => e.IdNave)
                    .HasName("PK__Naves__35A7535AAB30ED73");

                entity.Property(e => e.IdNave).HasColumnName("id_nave");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PlantasIdPlanta).HasColumnName("Plantas_id_planta");

                entity.HasOne(d => d.PlantasIdPlantaNavigation)
                    .WithMany(p => p.Naves)
                    .HasForeignKey(d => d.PlantasIdPlanta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("naves_plantas_plantas_id_planta");
            });

            modelBuilder.Entity<NivelesCertificacion>(entity =>
            {
                entity.HasKey(e => e.IdNivelCertificacion)
                    .HasName("PK__Niveles___2CC43D71AACAD5C8");

                entity.ToTable("Niveles_certificacion");

                entity.Property(e => e.IdNivelCertificacion).HasColumnName("id_nivel_certificacion");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.DescNivelCertificacion)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("desc_nivel_certificacion");

                entity.Property(e => e.DificultadNivelCertificacion).HasColumnName("dificultad_nivel_certificacion");

                entity.Property(e => e.NombreNivelCertificacion)
                    .IsRequired()
                    .HasColumnName("nombre_nivel_certificacion");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");

                entity.Property(e => e.NombreMenu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Menu");

                entity.Property(e => e.NombrePagina)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Pagina");

                entity.Property(e => e.Operacion).IsRequired();

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operaciones_Menu");
            });

            modelBuilder.Entity<PerfilOperacionPermiso>(entity =>
            {
                entity.ToTable("Perfil_Operacion_Permiso");

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.Ver)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.PerfilOperacionPermisos)
                    .HasForeignKey(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perfil_Operacion_Permiso_Operacion");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.PerfilOperacionPermisos)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perfil_Operacion_Permiso_Perfiles");
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.Property(e => e.Perfil).IsRequired();
            });

            modelBuilder.Entity<Pieza>(entity =>
            {
                entity.HasKey(e => e.IdPieza)
                    .HasName("PK__Piezas__D20ECB116B350167");

                entity.Property(e => e.IdPieza).HasColumnName("id_pieza");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripción)
                    .IsUnicode(false)
                    .HasColumnName("descripción");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<PiezasCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Piezas_Clientes");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientesIdCliente)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Clientes_id_cliente");

                entity.Property(e => e.PiezasIdPieza).HasColumnName("Piezas_id_pieza");

                entity.HasOne(d => d.PiezasIdPiezaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PiezasIdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("piezas_clientes_piezas_piezas_id_pieza");
            });

            modelBuilder.Entity<Planta>(entity =>
            {
                entity.HasKey(e => e.IdPlanta)
                    .HasName("PK__Plantas__4096680B551E7DE9");

                entity.Property(e => e.IdPlanta).HasColumnName("id_planta");

                entity.Property(e => e.Acronimo)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("acronimo");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdPlantaExt).HasColumnName("Id_Planta_Ext");

                entity.Property(e => e.Planta1)
                    .IsUnicode(false)
                    .HasColumnName("planta");
            });

            modelBuilder.Entity<PreguntasMaquina>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaMaquina)
                    .HasName("PK__Pregunta__31ABB522C336E622");

                entity.ToTable("Preguntas_maquina");

                entity.Property(e => e.IdPreguntaMaquina).HasColumnName("id_pregunta_maquina");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.MaquinasIdMaquina).HasColumnName("Maquinas_id_maquina");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasMaquinas)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_maquina_idioma_idioma_id_idioma");

                entity.HasOne(d => d.MaquinasIdMaquinaNavigation)
                    .WithMany(p => p.PreguntasMaquinas)
                    .HasForeignKey(d => d.MaquinasIdMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_maquina_maquinas_maquinas_id_maquina");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasMaquinas)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_maquina_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");
            });

            modelBuilder.Entity<PreguntasMaquinaGenerale>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaMaquina)
                    .HasName("PK__Pregunta__31ABB522E63257E4");

                entity.ToTable("Preguntas_maquina_generales");

                entity.Property(e => e.IdPreguntaMaquina).HasColumnName("id_pregunta_maquina");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("orden");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasMaquinaGenerales)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_maquina_generales_idioma_idioma_id_idioma");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasMaquinaGenerales)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_maquina_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");
            });

            modelBuilder.Entity<PreguntasPieza>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaPieza)
                    .HasName("PK__Pregunta__C79E1446F63A09B4");

                entity.ToTable("Preguntas_piezas");

                entity.Property(e => e.IdPreguntaPieza).HasColumnName("id_pregunta_pieza");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.PiezasIdPieza).HasColumnName("Piezas_id_pieza");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasPiezas)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_piezas_idioma_idioma_id_idioma");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasPiezas)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_piezas_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");

                entity.HasOne(d => d.PiezasIdPiezaNavigation)
                    .WithMany(p => p.PreguntasPiezas)
                    .HasForeignKey(d => d.PiezasIdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_piezas_piezas_piezas_id_pieza");
            });

            modelBuilder.Entity<PreguntasPiezasGenerale>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaPieza)
                    .HasName("PK__Pregunta__C79E1446FF5BA54C");

                entity.ToTable("Preguntas_piezas_generales");

                entity.Property(e => e.IdPreguntaPieza).HasColumnName("id_pregunta_pieza");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasPiezasGenerales)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_piezas_generales_idioma_idioma_id_idioma");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasPiezasGenerales)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_piezas_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");
            });

            modelBuilder.Entity<PreguntasProceso>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaProceso)
                    .HasName("PK__Pregunta__2C6BB8CD465C0352");

                entity.ToTable("Preguntas_procesos");

                entity.Property(e => e.IdPreguntaProceso).HasColumnName("id_pregunta_proceso");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.ProcesosIdProceso).HasColumnName("Procesos_id_proceso");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasProcesos)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_procesos_idioma_idioma_id_idioma");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasProcesos)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_procesos_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");

                entity.HasOne(d => d.ProcesosIdProcesoNavigation)
                    .WithMany(p => p.PreguntasProcesos)
                    .HasForeignKey(d => d.ProcesosIdProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_procesos_procesos_procesos_id_proceso");
            });

            modelBuilder.Entity<PreguntasProcesosGenerale>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaProceso)
                    .HasName("PK__Pregunta__2C6BB8CD9738309E");

                entity.ToTable("Preguntas_procesos_generales");

                entity.Property(e => e.IdPreguntaProceso).HasColumnName("id_pregunta_proceso");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasProcesosGenerales)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_procesos_generales_idioma_idioma_id_idioma");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasProcesosGenerales)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_procesos_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");
            });

            modelBuilder.Entity<PreguntasPtGenerale>(entity =>
            {
                entity.HasKey(e => e.IdPreguntaPt)
                    .HasName("PK__Pregunta__7F004930074D9B01");

                entity.ToTable("Preguntas_pt_generales");

                entity.Property(e => e.IdPreguntaPt).HasColumnName("id_pregunta_pt");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdiomaIdIdioma).HasColumnName("idioma_id_idioma");

                entity.Property(e => e.NivelesCertificacionIdNivelCertificacion).HasColumnName("niveles_certificacion_id_nivel_certificacion");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.HasOne(d => d.IdiomaIdIdiomaNavigation)
                    .WithMany(p => p.PreguntasPtGenerales)
                    .HasForeignKey(d => d.IdiomaIdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_pt_generales_idioma_idioma_id_idioma");

                entity.HasOne(d => d.NivelesCertificacionIdNivelCertificacionNavigation)
                    .WithMany(p => p.PreguntasPtGenerales)
                    .HasForeignKey(d => d.NivelesCertificacionIdNivelCertificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preguntas_pt_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdProceso)
                    .HasName("PK__Procesos__4D1766E4A1132DCA");

                entity.Property(e => e.IdProceso).HasColumnName("id_proceso");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo).IsRequired();

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ProcesosPiezasMaquina>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Procesos_piezas_maquinas");

                entity.Property(e => e.PiezasIdPieza).HasColumnName("Piezas_id_pieza");

                entity.HasOne(d => d.PiezasIdPiezaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PiezasIdPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("procesos_piezas_maquinas_piezas_piezas_id_pieza");
            });

            modelBuilder.Entity<ProcessLog>(entity =>
            {
                entity.ToTable("ProcessLog");

                entity.Property(e => e.Id).HasColumnName("id");

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
                    .HasName("PK__Puestos__123AAB991D623203");

                entity.HasIndex(e => e.IdPuestoExt, "UQ__Puestos__7CA8668D432D3681")
                    .IsUnique();

                entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DescPuesto)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("desc_puesto");

                entity.Property(e => e.IdPuestoExt).HasColumnName("id_puesto_ext");
            });

            modelBuilder.Entity<ResourceValidacionesCampo>(entity =>
            {
                entity.HasKey(e => e.IdReglaValidacion)
                    .HasName("PK_Validaciones_Resource");

                entity.ToTable("Resource_validaciones_campos");

                entity.Property(e => e.IdReglaValidacion).HasColumnName("Id_Regla_validacion");

                entity.Property(e => e.CodigoErrorFormato).HasColumnName("Codigo_error_formato");

                entity.Property(e => e.CodigoErrorRequerido)
                    .HasColumnName("Codigo_error_requerido")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Formato)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Ninguno')");

                entity.Property(e => e.MensajeErrorFormato).HasColumnName("Mensaje_error_formato");

                entity.Property(e => e.MensajeErrorRequerido).HasColumnName("Mensaje_error_requerido");

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Requerido).HasDefaultValueSql("((0))");

                entity.Property(e => e.TamañoCampo).HasColumnName("Tamaño_campo");

                entity.Property(e => e.TipoDato)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_dato")
                    .HasDefaultValueSql("(N'string')");
            });

            modelBuilder.Entity<RespuestasMaquina>(entity =>
            {
                entity.HasKey(e => e.IdRespuestaMaquina)
                    .HasName("PK__Respuest__749DA964944BA114");

                entity.ToTable("Respuestas_maquina");

                entity.Property(e => e.IdRespuestaMaquina).HasColumnName("id_respuesta_maquina");

                entity.Property(e => e.PreguntasMaquinaIdPreguntaMaquina).HasColumnName("Preguntas_maquina_id_pregunta_maquina");

                entity.Property(e => e.Respuesta)
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.Property(e => e.ResultadosMaquinaIdResultadoMáquina).HasColumnName("resultados_maquina_id_resultado_máquina");

                entity.HasOne(d => d.PreguntasMaquinaIdPreguntaMaquinaNavigation)
                    .WithMany(p => p.RespuestasMaquinas)
                    .HasForeignKey(d => d.PreguntasMaquinaIdPreguntaMaquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_maquina_preguntas_maquina_preguntas_maquina_id_pregunta_maquina");

                entity.HasOne(d => d.ResultadosMaquinaIdResultadoMáquinaNavigation)
                    .WithMany(p => p.RespuestasMaquinas)
                    .HasForeignKey(d => d.ResultadosMaquinaIdResultadoMáquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_maquina_resultados_maquina_resultados_maquina_id_resultado_máquina");
            });

            modelBuilder.Entity<RespuestasPieza>(entity =>
            {
                entity.HasKey(e => e.IdResultadoPieza)
                    .HasName("PK__Respuest__52B6D7005EB3D31A");

                entity.ToTable("Respuestas_pieza");

                entity.Property(e => e.IdResultadoPieza).HasColumnName("id_resultado_pieza");

                entity.Property(e => e.PreguntasPiezasIdPreguntaPieza).HasColumnName("Preguntas_piezas_id_pregunta_pieza");

                entity.Property(e => e.Respuesta)
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.Property(e => e.ResultadosPiezaIdResultadoPieza).HasColumnName("Resultados_pieza_id_resultado_pieza");

                entity.HasOne(d => d.PreguntasPiezasIdPreguntaPiezaNavigation)
                    .WithMany(p => p.RespuestasPiezas)
                    .HasForeignKey(d => d.PreguntasPiezasIdPreguntaPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_pieza_preguntas_piezas_preguntas_piezas_id_pregunta_pieza");

                entity.HasOne(d => d.ResultadosPiezaIdResultadoPiezaNavigation)
                    .WithMany(p => p.RespuestasPiezas)
                    .HasForeignKey(d => d.ResultadosPiezaIdResultadoPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_pieza_resultados_pieza_resultados_pieza_id_resultado_pieza");
            });

            modelBuilder.Entity<RespuestasProceso>(entity =>
            {
                entity.HasKey(e => e.IdRespuestaProceso)
                    .HasName("PK__Respuest__37929BC2D45E87DA");

                entity.ToTable("Respuestas_proceso");

                entity.Property(e => e.IdRespuestaProceso).HasColumnName("id_respuesta_proceso");

                entity.Property(e => e.PreguntasProcesosIdPreguntaProceso).HasColumnName("Preguntas_procesos_id_pregunta_proceso");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.Property(e => e.ResultadosProcesoIdResultadoProceso).HasColumnName("Resultados_proceso_id_resultado_proceso");

                entity.HasOne(d => d.PreguntasProcesosIdPreguntaProcesoNavigation)
                    .WithMany(p => p.RespuestasProcesos)
                    .HasForeignKey(d => d.PreguntasProcesosIdPreguntaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_proceso_preguntas_procesos_preguntas_procesos_id_pregunta_proceso");

                entity.HasOne(d => d.ResultadosProcesoIdResultadoProcesoNavigation)
                    .WithMany(p => p.RespuestasProcesos)
                    .HasForeignKey(d => d.ResultadosProcesoIdResultadoProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("respuestas_proceso_resultados_proceso_resultados_proceso_id_resultado_proceso");
            });

            modelBuilder.Entity<ResultadosMaquina>(entity =>
            {
                entity.HasKey(e => e.IdResultadoMáquina)
                    .HasName("PK__resultad__175525A12B8036D1");

                entity.ToTable("resultados_maquina");

                entity.Property(e => e.IdResultadoMáquina).HasColumnName("id_resultado_máquina");

                entity.Property(e => e.Resultado).HasColumnName("resultado");
            });

            modelBuilder.Entity<ResultadosPieza>(entity =>
            {
                entity.HasKey(e => e.IdResultadoPieza)
                    .HasName("PK__Resultad__52B6D7006E31DB68");

                entity.ToTable("Resultados_pieza");

                entity.Property(e => e.IdResultadoPieza).HasColumnName("id_resultado_pieza");

                entity.Property(e => e.Resultado).HasColumnName("resultado");
            });

            modelBuilder.Entity<ResultadosProceso>(entity =>
            {
                entity.HasKey(e => e.IdResultadoProceso)
                    .HasName("PK__Resultad__C1326147AADA5CEB");

                entity.ToTable("Resultados_proceso");

                entity.Property(e => e.IdResultadoProceso).HasColumnName("id_resultado_proceso");

                entity.Property(e => e.Resultado).HasColumnName("resultado");
            });

            modelBuilder.Entity<TipoAcceso>(entity =>
            {
                entity.HasKey(e => e.IdTipoAcceso)
                    .HasName("PK__Tipo_acc__6EE6B2189A8D8C7F");

                entity.ToTable("Tipo_acceso");

                entity.Property(e => e.IdTipoAcceso).HasColumnName("id_tipo_acceso");

                entity.Property(e => e.DescTipoAcceso)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("desc_tipo_acceso");
            });

            modelBuilder.Entity<UnidadNegocio>(entity =>
            {
                entity.HasKey(e => e.IdUnidadNegocio)
                    .HasName("PK__Unidad_n__EDCD772EC9D55773");

                entity.ToTable("Unidad_negocio");

                entity.Property(e => e.IdUnidadNegocio).HasColumnName("id_unidad_negocio");

                entity.Property(e => e.DescUnidadNegocio)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("desc_unidad_negocio");

                entity.Property(e => e.IdUnidadNegocioExt).HasColumnName("id_unidad_negocio_ext");
            });

            modelBuilder.Entity<VideosPiezaProceso>(entity =>
            {
                entity.HasKey(e => e.IdVideoPiezaProceso)
                    .HasName("PK__Videos_p__E63D2BD8DC59EBB1");

                entity.ToTable("Videos_pieza_proceso");

                entity.Property(e => e.IdVideoPiezaProceso).HasColumnName("id_video_pieza_proceso");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
