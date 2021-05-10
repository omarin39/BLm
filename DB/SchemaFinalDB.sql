USE [master]
GO
/****** Object:  Database [CARTAV]    Script Date: 10/05/2021 04:32:15 p. m. ******/
CREATE DATABASE [CARTAV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CARTAV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLOMARIN\MSSQL\DATA\CARTAV.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CARTAV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLOMARIN\MSSQL\DATA\CARTAV_log.ldf' , SIZE = 335872KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CARTAV] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CARTAV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CARTAV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CARTAV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CARTAV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CARTAV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CARTAV] SET ARITHABORT OFF 
GO
ALTER DATABASE [CARTAV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CARTAV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CARTAV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CARTAV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CARTAV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CARTAV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CARTAV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CARTAV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CARTAV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CARTAV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CARTAV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CARTAV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CARTAV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CARTAV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CARTAV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CARTAV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CARTAV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CARTAV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CARTAV] SET  MULTI_USER 
GO
ALTER DATABASE [CARTAV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CARTAV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CARTAV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CARTAV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CARTAV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CARTAV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CARTAV] SET QUERY_STORE = OFF
GO
USE [CARTAV]
GO
/****** Object:  Table [dbo].[Pieza]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pieza](
	[IdPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[NumeroParte] [nvarchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Pieza_D20ECB11F4B5FCCF] PRIMARY KEY CLUSTERED 
(
	[IdPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MultiMediaPieza]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiMediaPieza](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPieza] [bigint] NOT NULL,
	[IdTipoDocumento] [bigint] NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Version] [nvarchar](50) NULL,
	[Recertificacion] [bit] NULL,
	[Ruta] [nvarchar](max) NULL,
	[TipoMedia] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_MultiMediaPieza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_PIEZAS_MULTIMEDIAS]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Retorna las piezas y sus totales de multimedia
CREATE VIEW [dbo].[VW_PIEZAS_MULTIMEDIAS] AS
	SELECT  p.IdPieza,
			p.NumeroParte,
			p.Nombre,
			p.Descripcion,
			p.Activo, 
		case m.TipoMedia when 'DOC' then count(m.TipoMedia) else 0
			end countDoc,
		case m.TipoMedia  when 'VIDEO' then count(m.TipoMedia) else 0
			end countVideo,
		case m.TipoMedia  when 'IMG' then count(m.TipoMedia) else 0
			end countImg
	FROM Pieza p left join MultiMediaPieza m on(p.IdPieza=m.IdPieza)
	group by   p.IdPieza,p.NumeroParte,p.Nombre,p.Descripcion,p.Activo,m.TipoMedia;
GO
/****** Object:  Table [dbo].[CentroCosto]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CentroCosto](
	[IdCentroCosto] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCentroCostoExterno] [bigint] NOT NULL,
	[DescCentroCosto] [varchar](max) NOT NULL,
	[DuenoCeco] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCentroCosto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificacion]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificacion](
	[IdCertificacion] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaEntrenamiento] [datetime] NOT NULL,
	[FechaCertificacion] [datetime] NULL,
	[IdCertificador] [bigint] NULL,
	[TokenCertificador] [varchar](max) NULL,
	[FechaCertificador] [datetime] NULL,
	[IdMentor] [bigint] NULL,
	[TokenMentor] [varchar](max) NULL,
	[FechaMentor] [datetime] NULL,
	[IdResponsable] [bigint] NULL,
	[TokenResponsable] [varchar](max) NULL,
	[FechaResponsable] [datetime] NULL,
	[Resultado] [float] NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCertificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Contacto] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Telefono] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDepartamento] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDepartamentExterno] [bigint] NOT NULL,
	[Departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartamentoNivel1]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartamentoNivel1](
	[IdDepartamentoNivel1] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDepartamento] [bigint] NOT NULL,
	[IdDepartamentExterno] [bigint] NOT NULL,
	[Departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamentoNivel1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartamentoNivel2]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartamentoNivel2](
	[IdDepartamentoNivel2] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDepartamento] [bigint] NOT NULL,
	[IdDepartamentoNivel1] [bigint] NOT NULL,
	[IdDepartamentExterno] [bigint] NOT NULL,
	[Departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamentoNivel2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartamentoNivel3]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartamentoNivel3](
	[IdDepartamentoNivel3] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDepartamento] [bigint] NOT NULL,
	[IdDepartamentoNivel2] [bigint] NOT NULL,
	[IdDepartamentExterno] [bigint] NOT NULL,
	[Departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamentoNivel3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentoPiezaProceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentoPiezaProceso](
	[IdDocumentoPiezaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Url] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDocumentoPiezaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [bigint] IDENTITY(1,1) NOT NULL,
	[NumeroNomina] [varchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[ApellidoPaterno] [varchar](max) NOT NULL,
	[ApellidoMaterno] [varchar](max) NULL,
	[FechaNacimiento] [date] NOT NULL,
	[FechaIngreso] [date] NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[NominaJefe] [varchar](max) NOT NULL,
	[DepartamentoIdDepartamentoNivel0] [bigint] NOT NULL,
	[DepartamentoIdDepartamentoNivel1] [bigint] NULL,
	[DepartamentoIdDepartamentoNivel2] [bigint] NULL,
	[DepartamentoIdDepartamentoNivel3] [bigint] NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[PuestoIdPuesto] [bigint] NOT NULL,
	[UnidadNegocioIdUnidadNegocio] [bigint] NOT NULL,
	[CentroCostoIdCentroCosto] [bigint] NOT NULL,
	[IdPerfil] [bigint] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PKEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fabricante]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fabricante](
	[IdFabricante] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Contacto] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Telefono] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFabricante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [bigint] IDENTITY(1,1) NOT NULL,
	[CodigoIdioma] [varchar](10) NOT NULL,
	[Idioma] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PKIdioma0BA1525F05C8D52A] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineaProduccion]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineaProduccion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNave] [bigint] NOT NULL,
	[NombreLinea] [nvarchar](max) NOT NULL,
	[DescripcionLinea] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_LineaProduccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquina]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquina](
	[IdMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Modelo] [varchar](max) NOT NULL,
	[MaquinaPt] [bit] NOT NULL,
	[CantidadAccesoMultiple] [int] NOT NULL,
	[FabricanteIdFabricante] [bigint] NOT NULL,
	[TipoAccesoIdTipoAcceso] [bigint] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Maquina_9A2F321BE6366944] PRIMARY KEY CLUSTERED 
(
	[IdMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaquinaFisica]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaFisica](
	[IdMaquinaFisica] [bigint] IDENTITY(1,1) NOT NULL,
	[NSerie] [varchar](max) NOT NULL,
	[Ubicacion] [varchar](max) NULL,
	[MaquinaIdMaquina] [bigint] NOT NULL,
	[NaveIdNave] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Maquina_5BE456CBA6BE8746] PRIMARY KEY CLUSTERED 
(
	[IdMaquinaFisica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaquinaProceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaProceso](
	[MaquinaIdMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[ProcesoIdProceso] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreMenu] [nvarchar](100) NOT NULL,
	[Icon] [nvarchar](50) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PKMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nave]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nave](
	[IdNave] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[PlantaIdPlanta] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Nave_35A7535AAB30ED73] PRIMARY KEY CLUSTERED 
(
	[IdNave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelCertificacion]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelCertificacion](
	[IdNivelCertificacion] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreNivelCertificacion] [nvarchar](max) NOT NULL,
	[DescripcionNivelCertificacion] [varchar](max) NOT NULL,
	[DificultadNivelCertificacion] [int] NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Nivel_2CC43D71AACAD5C8] PRIMARY KEY CLUSTERED 
(
	[IdNivelCertificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Operacion] [nvarchar](max) NOT NULL,
	[NombreMenu] [nvarchar](50) NOT NULL,
	[NombrePagina] [nvarchar](50) NOT NULL,
	[IdMenu] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Operacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Perfil] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PKPerfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilOperacionPermiso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilOperacionPermiso](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPerfil] [bigint] NOT NULL,
	[IdOperacion] [bigint] NOT NULL,
	[Crear] [bit] NOT NULL,
	[Editar] [bit] NOT NULL,
	[Eliminar] [bit] NOT NULL,
	[Ver] [bit] NOT NULL,
 CONSTRAINT [PK_PerfilOperacionPermiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PiezaCliente]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PiezaCliente](
	[ClienteIdCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[PiezaIdPieza] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planta]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planta](
	[IdPlanta] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPlantaExterno] [bigint] NULL,
	[Acronimo] [varchar](max) NOT NULL,
	[Planta] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Plantas__4096680B551E7DE9] PRIMARY KEY CLUSTERED 
(
	[IdPlanta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaMaquina]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaMaquina](
	[IdPreguntaMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Orden] [int] NOT NULL,
	[MaquinaIdMaquina] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPreguntaMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaMaquinaGeneral]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaMaquinaGeneral](
	[IdPreguntaMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Orden] [varchar](max) NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__31ABB522E63257E4] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPieza]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaPieza](
	[IdPreguntaPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Orden] [int] NOT NULL,
	[PiezaIdPieza] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPiezaGeneral]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaPiezaGeneral](
	[IdPreguntaPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Orden] [int] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaProceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaProceso](
	[IdPreguntaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Orden] [int] NOT NULL,
	[ProcesoIdProceso] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPreguntaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaProcesoGeneral]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaProcesoGeneral](
	[IdPreguntaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Orden] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPreguntaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPtGeneral]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaPtGeneral](
	[IdPreguntaPt] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proceso](
	[IdProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Procesos__4D1766E4A1132DCA] PRIMARY KEY CLUSTERED 
(
	[IdProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcesoPiezaMaquina]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcesoPiezaMaquina](
	[PiezaIdPieza] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessLog]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IP] [nvarchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Respuesta] [nvarchar](max) NOT NULL,
	[Codigo] [bigint] NOT NULL,
 CONSTRAINT [PK_ProcessLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[IdPuesto] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPuestoExterno] [bigint] NOT NULL,
	[DescPuesto] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceValidacionCampo]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceValidacionCampo](
	[IdReglaValidacion] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[TipoDato] [nvarchar](50) NOT NULL,
	[TamañoCampo] [int] NOT NULL,
	[Requerido] [bit] NULL,
	[Formato] [nvarchar](50) NULL,
	[CodigoErrorRequerido] [int] NULL,
	[MensajeErrorRequerido] [nvarchar](max) NULL,
	[CodigoErrorFormato] [int] NULL,
	[MensajeErrorFormato] [nvarchar](max) NULL,
 CONSTRAINT [PK_Validaciones_Resource] PRIMARY KEY CLUSTERED 
(
	[IdReglaValidacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RespuestaMaquina]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RespuestaMaquina](
	[IdRespuestaMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Resultado] [float] NOT NULL,
	[ResultadoMaquinaIdResultadoMaquina] [bigint] NOT NULL,
	[PreguntaMaquinaIdPreguntaMaquina] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRespuestaMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RespuestaPieza]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RespuestaPieza](
	[IdResultadoPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Resultado] [float] NOT NULL,
	[ResultadoPiezaIdResultadoPieza] [bigint] NOT NULL,
	[PreguntaPiezaIdPreguntaPieza] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdResultadoPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RespuestaProceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RespuestaProceso](
	[IdRespuestaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
	[Resultado] [float] NOT NULL,
	[ResultadoProcesoIdResultadoProceso] [bigint] NOT NULL,
	[PreguntaProcesoIdPreguntaProceso] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRespuestaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadoMaquina]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadoMaquina](
	[IdResultadoMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Resultado] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdResultadoMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadoPieza]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadoPieza](
	[IdResultadoPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Resultado] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdResultadoPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadoProceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadoProceso](
	[IdResultadoProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Resultado] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdResultadoProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAcceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAcceso](
	[IdTipoAcceso] [bigint] IDENTITY(1,1) NOT NULL,
	[DescTipoAcceso] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoAcceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[TipoDocumento] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadNegocio]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadNegocio](
	[IdUnidadNegocio] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUnidadNegocioExterno] [bigint] NOT NULL,
	[DescUnidadNegocio] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUnidadNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoPiezaProceso]    Script Date: 10/05/2021 04:32:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoPiezaProceso](
	[IdVideoPiezaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Url] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVideoPiezaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [CodigoIdioma], [Idioma], [Activo]) VALUES (1, N'es-MX', N'Español (México)', 1)
INSERT [dbo].[Idioma] ([IdIdioma], [CodigoIdioma], [Idioma], [Activo]) VALUES (2, N'en-US', N'English', 1)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [NombreMenu], [Icon], [Activo]) VALUES (1, N'Administracion', N'fas fa-users-cog', 1)
INSERT [dbo].[Menu] ([Id], [NombreMenu], [Icon], [Activo]) VALUES (2, N'Empleados', N'fas fa-diagnoses', 1)
INSERT [dbo].[Menu] ([Id], [NombreMenu], [Icon], [Activo]) VALUES (3, N'CartaVersatilidad', N'fas fa-chalkboard-teacher', 1)
INSERT [dbo].[Menu] ([Id], [NombreMenu], [Icon], [Activo]) VALUES (4, N'NecesidadesCertificacion', N'fas fa-tasks', 1)
INSERT [dbo].[Menu] ([Id], [NombreMenu], [Icon], [Activo]) VALUES (5, N'Reportes', N'fas fa-chart-line', 1)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Operacion] ON 

INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (1, N'MaquinasPTrabajo', N'MaquinasPTrabajo', N'MaquinasPTrabajo', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (2, N'Procesos', N'Procesos', N'Procesos', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (3, N'Piezas', N'Piezas', N'Piezas', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (4, N'Clientes', N'Clientes', N'Clientes', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (5, N'MaquinasPTFisicas', N'MaquinasPTFisicas', N'MaquinasPTFisicas', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (6, N'Plantas', N'Plantas', N'Plantas', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (7, N'Permisos', N'Permisos', N'AdmPermisos', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (8, N'Perfiles', N'Perfiles', N'AdmPerfiles', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (9, N'Fabricantes', N'Fabricantes', N'Fabricantes', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (10, N'NivelesCertificacion', N'NivelesCertificacion', N'NivelesCertificacion', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (11, N'PreguntasGrales', N'PreguntasGrales', N'PreguntasGrales', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (12, N'Certificaciones', N'Certificaciones', N'Certificaciones', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (13, N'NecesidadesCertifica', N'NecesidadesCertifica', N'NecesidadesCertifica', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (14, N'Examenes', N'Examenes', N'Examenes', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (15, N'EmpPerfiles', N'EmpPerfiles', N'EmpPerfiles', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (16, N'AsignaCapacita', N'AsignaCapacita', N'AsignaCapacita', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (17, N'FirmasPendientes', N'FirmasPendientes', N'FirmasPendientes', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (18, N'CapacitacionesCaduca', N'CapacitacionesCaduca', N'CapacitacionesCaduca', 2, 1)
SET IDENTITY_INSERT [dbo].[Operacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Perfil], [Activo]) VALUES (1, N'Administrador', 1)
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[PerfilOperacionPermiso] ON 

INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (1, 1, 1, 1, 0, 0, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (2, 1, 2, 1, 0, 0, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (3, 1, 3, 0, 0, 0, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (4, 1, 4, 0, 0, 0, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (5, 1, 5, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (6, 1, 6, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (7, 1, 7, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (8, 1, 8, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (9, 1, 9, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (10, 1, 10, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (11, 1, 11, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (12, 1, 12, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (13, 1, 13, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (14, 1, 14, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (15, 1, 15, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (16, 1, 16, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (17, 1, 17, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (18, 1, 18, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[PerfilOperacionPermiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Pieza] ON 

INSERT [dbo].[Pieza] ([IdPieza], [NumeroParte], [Nombre], [Descripcion], [Activo]) VALUES (1, N'80A821169/170', N'Cubierta frontal interna izq/der', N'Cubierta frontal interna izq/der', 1)
SET IDENTITY_INSERT [dbo].[Pieza] OFF
GO
SET IDENTITY_INSERT [dbo].[Proceso] ON 

INSERT [dbo].[Proceso] ([IdProceso], [Codigo], [Nombre], [Descripcion], [Activo]) VALUES (1, N'OP 1000-10', N'Manufactura', N'Fabricación de suspensiones', 1)
SET IDENTITY_INSERT [dbo].[Proceso] OFF
GO
SET IDENTITY_INSERT [dbo].[ProcessLog] ON 

INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (1, N'::1', CAST(N'2021-05-08T01:39:11.747' AS DateTime), N'Operation (OPERACIÓN = AddPerfil)Type: PerfilProperties (N = 4)  Id (Int64): 1
  Perfil1 (String): Administrador
  Activo (Boolean): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (20, N'::1', CAST(N'2021-05-10T11:09:02.047' AS DateTime), N'Operation (OPERACIÓN = AddMultimediaPieza)Type: MultiMediaPiezaProperties (N = 11)  Id (Int64): 0
  IdPieza (Int64): 1
  IdTipoDocumento (Nullable`1): 2
  Nombre (String): asd
  Descripcion (String): addsads
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): multimedia/documentos/cv omar alvarez alcantara.docx
  TipoMedia (String): DOC
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_MultiMediaPieza_MultiMediaPiezaIdPieza". The conflict occurred in database "CARTAV", table "dbo.Pieza", column ''IdPieza''.
The statement has been terminated.', 400)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (21, N'::1', CAST(N'2021-05-10T11:09:52.740' AS DateTime), N'Operation (OPERACIÓN = AddMultimediaPieza)Type: MultiMediaPiezaProperties (N = 11)  Id (Int64): 0
  IdPieza (Int64): 1
  IdTipoDocumento (Nullable`1): 2
  Nombre (String): asd
  Descripcion (String): addsads
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): multimedia/documentos/cv omar alvarez alcantara.docx
  TipoMedia (String): DOC
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_MultiMediaPieza_MultiMediaPiezaIdPieza". The conflict occurred in database "CARTAV", table "dbo.Pieza", column ''IdPieza''.
The statement has been terminated.', 400)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (22, N'::1', CAST(N'2021-05-10T11:14:12.360' AS DateTime), N'Operation (OPERACIÓN = AddProceso)Type: ProcesoProperties (N = 6)  IdProceso (Int64): 1
  Codigo (String): OP 1000-10
  Nombre (String): Manufactura
  Descripcion (String): Fabricación de suspensiones
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (23, N'::1', CAST(N'2021-05-10T11:15:04.053' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 1
  IdPerfil (Int64): 1
  IdOperacion (Int64): 1
  Crear (Boolean): True
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): True
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (24, N'::1', CAST(N'2021-05-10T11:15:04.093' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 2
  IdPerfil (Int64): 1
  IdOperacion (Int64): 2
  Crear (Boolean): True
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): True
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (25, N'::1', CAST(N'2021-05-10T11:15:04.110' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 3
  IdPerfil (Int64): 1
  IdOperacion (Int64): 3
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): True
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (26, N'::1', CAST(N'2021-05-10T11:15:04.113' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 4
  IdPerfil (Int64): 1
  IdOperacion (Int64): 4
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): True
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (27, N'::1', CAST(N'2021-05-10T11:15:04.127' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 5
  IdPerfil (Int64): 1
  IdOperacion (Int64): 5
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (28, N'::1', CAST(N'2021-05-10T11:15:04.130' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 6
  IdPerfil (Int64): 1
  IdOperacion (Int64): 6
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (29, N'::1', CAST(N'2021-05-10T11:15:04.137' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 7
  IdPerfil (Int64): 1
  IdOperacion (Int64): 7
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (30, N'::1', CAST(N'2021-05-10T11:15:04.147' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 8
  IdPerfil (Int64): 1
  IdOperacion (Int64): 8
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (31, N'::1', CAST(N'2021-05-10T11:15:04.160' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 9
  IdPerfil (Int64): 1
  IdOperacion (Int64): 9
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (32, N'::1', CAST(N'2021-05-10T11:15:04.167' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 10
  IdPerfil (Int64): 1
  IdOperacion (Int64): 10
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (33, N'::1', CAST(N'2021-05-10T11:15:04.173' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 11
  IdPerfil (Int64): 1
  IdOperacion (Int64): 11
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (34, N'::1', CAST(N'2021-05-10T11:15:04.180' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 12
  IdPerfil (Int64): 1
  IdOperacion (Int64): 12
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (35, N'::1', CAST(N'2021-05-10T11:15:04.187' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 13
  IdPerfil (Int64): 1
  IdOperacion (Int64): 13
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (36, N'::1', CAST(N'2021-05-10T11:15:04.197' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 14
  IdPerfil (Int64): 1
  IdOperacion (Int64): 14
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (37, N'::1', CAST(N'2021-05-10T11:15:04.200' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 15
  IdPerfil (Int64): 1
  IdOperacion (Int64): 15
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (38, N'::1', CAST(N'2021-05-10T11:15:04.210' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 16
  IdPerfil (Int64): 1
  IdOperacion (Int64): 16
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (39, N'::1', CAST(N'2021-05-10T11:15:04.213' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 17
  IdPerfil (Int64): 1
  IdOperacion (Int64): 17
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (40, N'::1', CAST(N'2021-05-10T11:15:04.223' AS DateTime), N'Operation (OPERACIÓN = UpdatePerfilOperacionPermiso)Type: PerfilOperacionPermisoProperties (N = 9)  Id (Int64): 18
  IdPerfil (Int64): 1
  IdOperacion (Int64): 18
  Crear (Boolean): False
  Editar (Boolean): False
  Eliminar (Boolean): False
  Ver (Nullable`1): False
  IdOperacionNavigation (Operacion): 
  IdPerfilNavigation (Perfil): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (41, N'::1', CAST(N'2021-05-10T14:47:40.753' AS DateTime), N'Operation (OPERACIÓN = AddPieza)Type: PiezaProperties (N = 7)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der
  Descripcion (String): Cubierta frontal interna izq/der
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (42, N'::1', CAST(N'2021-05-10T15:19:32.017' AS DateTime), N'Operation (OPERACIÓN = AddMultimediaPieza)Type: MultiMediaPiezaProperties (N = 11)  Id (Int64): 3
  IdPieza (Int64): 1
  IdTipoDocumento (Nullable`1): 2
  Nombre (String): asd
  Descripcion (String): addsads
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): multimedia/documentos/cv omar alvarez alcantara.docx
  TipoMedia (String): DOC
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'OK', 200)
SET IDENTITY_INSERT [dbo].[ProcessLog] OFF
GO
SET IDENTITY_INSERT [dbo].[ResourceValidacionCampo] ON 

INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (1, N'noNomina', N'int', 100, 1, N'Ninguno', 412, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 429, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (2, N'Nombre', N'string', 250, 1, N'Ninguno', 413, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 430, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (3, N'apellIdoPaterno', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 414, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (4, N'apellIdoMaterno', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 415, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (5, N'fechaNacimiento', N'date', 10, 1, N'Y/m/d', 416, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 410, N'no cumple con el Formato de fechas (yyyy/mm/dd)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (6, N'fechaIngreso', N'date', 10, 0, N'Y/m/d', 417, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 411, N'no cumple con el Formato de fechas aaaa/mm/dd')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (7, N'email', N'email', 250, 0, N'Ninguno', 418, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 423, N'no contiene un @ o no cumple con el Formato de email (usuario@dominio.com)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (8, N'IdPlanta', N'int', 10, 1, N'Ninguno', 442, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 443, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (9, N'DescripcionPlanta', N'string', 250, 1, N'Ninguno', 419, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 424, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (10, N'IdDepartamento', N'int', 10, 1, N'Ninguno', 444, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 445, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (11, N'departamento', N'string', 250, 1, N'Ninguno', 420, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 425, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (12, N'IdDepNivel1', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (13, N'DepNivel1', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (14, N'IdDepNivel2', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (15, N'DepNivel2', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (16, N'IdDepNivel3', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (17, N'DepNivel3', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (18, N'IdPuesto', N'int', 10, 1, N'Ninguno', 446, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 447, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (19, N'Puesto', N'string', 250, 1, N'Ninguno', 421, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 426, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (20, N'nominaJefe', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (21, N'IdUnidad', N'int', 10, 1, N'Ninguno', 448, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 449, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (22, N'Unidad', N'string', 250, 1, N'Ninguno', 431, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 432, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (23, N'IdCeCo', N'int', 10, 1, N'Ninguno', 450, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 451, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (24, N'CeCo', N'string', 250, 1, N'Ninguno', 433, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 434, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (25, N'NoCentros', N'string', 250, 1, N'Ninguno', 436, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 436, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (26, N'dueno', N'string', 255, 1, N'Ninguno', 437, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (27, N'Id_depa_externo', N'string', 255, 1, N'Ninguno', 440, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (28, N'Id_Puesto_externo', N'string', 255, 1, N'Ninguno', 441, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamañoCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (29, N'AcronimoPlanta', N'string', 255, 1, N'Ninguno', 0, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
SET IDENTITY_INSERT [dbo].[ResourceValidacionCampo] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([Id], [Descripcion], [TipoDocumento]) VALUES (1, N'Tipo Predeterminado para Media', N'CVDEF')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion], [TipoDocumento]) VALUES (2, N'Documento Dummy', N'HOE')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
GO
/****** Object:  Index [UQ__CentroCo__DBD8185B05AF8232]    Script Date: 10/05/2021 04:32:16 p. m. ******/
ALTER TABLE [dbo].[CentroCosto] ADD UNIQUE NONCLUSTERED 
(
	[IdCentroCostoExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38DC9E9DB4E]    Script Date: 10/05/2021 04:32:16 p. m. ******/
ALTER TABLE [dbo].[Departamento] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D7255FE32]    Script Date: 10/05/2021 04:32:16 p. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel1] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38DE0593B5B]    Script Date: 10/05/2021 04:32:16 p. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel2] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D1C4AF28C]    Script Date: 10/05/2021 04:32:16 p. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel3] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Puesto__52F767D7DF5E6DDE]    Script Date: 10/05/2021 04:32:16 p. m. ******/
ALTER TABLE [dbo].[Puesto] ADD UNIQUE NONCLUSTERED 
(
	[IdPuestoExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CentroCosto] ADD  CONSTRAINT [DF_Centro_costo_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Certificacion] ADD  CONSTRAINT [DF_Certificaciones_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Clientes_Estatus]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Departamento] ADD  CONSTRAINT [DF_Departamento_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[DepartamentoNivel1] ADD  CONSTRAINT [DF_DepartamentoNivel1Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[DepartamentoNivel2] ADD  CONSTRAINT [DF_DepartamentNivel2Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[DepartamentoNivel3] ADD  CONSTRAINT [DF_DepartamentoNivel3Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[DocumentoPiezaProceso] ADD  CONSTRAINT [DF_Documentos_pieza_proceso_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Empleado] ADD  CONSTRAINT [DF_EmpleadoActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Fabricante] ADD  CONSTRAINT [DF_FabricanteEstado]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Idioma] ADD  CONSTRAINT [DF_IdiomaActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[LineaProduccion] ADD  CONSTRAINT [DF_LineaProduccionActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Maquina] ADD  CONSTRAINT [DF_MaquinaActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[MaquinaProceso] ADD  CONSTRAINT [DF_MaquinProcesosActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Nave] ADD  CONSTRAINT [DF_NaveActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[NivelCertificacion] ADD  CONSTRAINT [DF_NivelCertificacionEstado]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso] ADD  CONSTRAINT [DF_PerfilOperacionPermisoCrear]  DEFAULT ((0)) FOR [Crear]
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso] ADD  CONSTRAINT [DF_PerfilOperacionPermisoEditar]  DEFAULT ((0)) FOR [Editar]
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso] ADD  CONSTRAINT [DF_PerfilOperacionPermisoEliminar]  DEFAULT ((0)) FOR [Eliminar]
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso] ADD  CONSTRAINT [DF_PerfilOperacionPermisoVer]  DEFAULT ((1)) FOR [Ver]
GO
ALTER TABLE [dbo].[Pieza] ADD  CONSTRAINT [DF_PiezaActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PiezaCliente] ADD  CONSTRAINT [DF_PiezaClienteActivo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Planta] ADD  CONSTRAINT [DF_Plantas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PreguntaMaquina] ADD  CONSTRAINT [DF_Preguntas_maquina_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PreguntaMaquinaGeneral] ADD  CONSTRAINT [DF_Preguntas_Maquina_Generales_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PreguntaPieza] ADD  CONSTRAINT [DF_Preguntas_Piezas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[PreguntaPtGeneral] ADD  CONSTRAINT [DF_Preguntas_Pt_Generales_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Proceso] ADD  CONSTRAINT [DF_Procesos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Puesto] ADD  CONSTRAINT [DF_Puestos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[ResourceValidacionCampo] ADD  CONSTRAINT [DF_Resource_Validaciones_ampos_Tipo_dato]  DEFAULT (N'string') FOR [TipoDato]
GO
ALTER TABLE [dbo].[ResourceValidacionCampo] ADD  CONSTRAINT [DF_Resource_Validaciones_ampos_Tamaño_Campo]  DEFAULT ((0)) FOR [TamañoCampo]
GO
ALTER TABLE [dbo].[ResourceValidacionCampo] ADD  CONSTRAINT [DF_Table_1_Requerido]  DEFAULT ((0)) FOR [Requerido]
GO
ALTER TABLE [dbo].[ResourceValidacionCampo] ADD  CONSTRAINT [DF_Resource_Validaciones_Campos_Formato]  DEFAULT (N'Ninguno') FOR [Formato]
GO
ALTER TABLE [dbo].[ResourceValidacionCampo] ADD  CONSTRAINT [DF_Resource_Validaciones_Campos_Codigo_Error_Requerido]  DEFAULT ((0)) FOR [CodigoErrorRequerido]
GO
ALTER TABLE [dbo].[DepartamentoNivel1]  WITH CHECK ADD  CONSTRAINT [FK_DepartamentoNivel1_Departamento] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamento] ([IdDepartamento])
GO
ALTER TABLE [dbo].[DepartamentoNivel1] CHECK CONSTRAINT [FK_DepartamentoNivel1_Departamento]
GO
ALTER TABLE [dbo].[DepartamentoNivel2]  WITH CHECK ADD  CONSTRAINT [FK_DepartamentoNivel2_DepartamentoNivel1] FOREIGN KEY([IdDepartamentoNivel1])
REFERENCES [dbo].[DepartamentoNivel1] ([IdDepartamentoNivel1])
GO
ALTER TABLE [dbo].[DepartamentoNivel2] CHECK CONSTRAINT [FK_DepartamentoNivel2_DepartamentoNivel1]
GO
ALTER TABLE [dbo].[DepartamentoNivel3]  WITH CHECK ADD  CONSTRAINT [FK_DepartamentoNivel3_DepartamentoNivel2] FOREIGN KEY([IdDepartamentoNivel2])
REFERENCES [dbo].[DepartamentoNivel2] ([IdDepartamentoNivel2])
GO
ALTER TABLE [dbo].[DepartamentoNivel3] CHECK CONSTRAINT [FK_DepartamentoNivel3_DepartamentoNivel2]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_EmpleadoIdiomaIdIdioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_EmpleadoIdiomaIdIdioma]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoCentroCosto_CentroCostoIdCentroCosto] FOREIGN KEY([CentroCostoIdCentroCosto])
REFERENCES [dbo].[CentroCosto] ([IdCentroCosto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoCentroCosto_CentroCostoIdCentroCosto]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel0] FOREIGN KEY([DepartamentoIdDepartamentoNivel0])
REFERENCES [dbo].[Departamento] ([IdDepartamento])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel0]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel1] FOREIGN KEY([DepartamentoIdDepartamentoNivel1])
REFERENCES [dbo].[DepartamentoNivel1] ([IdDepartamentoNivel1])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel1]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel2] FOREIGN KEY([DepartamentoIdDepartamentoNivel2])
REFERENCES [dbo].[DepartamentoNivel2] ([IdDepartamentoNivel2])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel2]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel3] FOREIGN KEY([DepartamentoIdDepartamentoNivel3])
REFERENCES [dbo].[DepartamentoNivel3] ([IdDepartamentoNivel3])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoDepartamento_DepartamentoIdDepartamentoNivel3]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoPuesto_PuestoIdPuesto] FOREIGN KEY([PuestoIdPuesto])
REFERENCES [dbo].[Puesto] ([IdPuesto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoPuesto_PuestoIdPuesto]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoUnidadNegocio_UnidadNegocioIdUnidadNegocio] FOREIGN KEY([UnidadNegocioIdUnidadNegocio])
REFERENCES [dbo].[UnidadNegocio] ([IdUnidadNegocio])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_EmpleadoUnidadNegocio_UnidadNegocioIdUnidadNegocio]
GO
ALTER TABLE [dbo].[LineaProduccion]  WITH CHECK ADD  CONSTRAINT [FK_LineaProduccion_NaveidNave] FOREIGN KEY([IdNave])
REFERENCES [dbo].[Nave] ([IdNave])
GO
ALTER TABLE [dbo].[LineaProduccion] CHECK CONSTRAINT [FK_LineaProduccion_NaveidNave]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFabricante_FabricanteIdFabricante] FOREIGN KEY([FabricanteIdFabricante])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_MaquinaFabricante_FabricanteIdFabricante]
GO
ALTER TABLE [dbo].[Maquina]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaTipoAcceso_TipoAccesoIdTipoAcceso] FOREIGN KEY([TipoAccesoIdTipoAcceso])
REFERENCES [dbo].[TipoAcceso] ([IdTipoAcceso])
GO
ALTER TABLE [dbo].[Maquina] CHECK CONSTRAINT [FK_MaquinaTipoAcceso_TipoAccesoIdTipoAcceso]
GO
ALTER TABLE [dbo].[MaquinaFisica]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFisicaMaquina_MaquinaIdMaquina] FOREIGN KEY([MaquinaIdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[MaquinaFisica] CHECK CONSTRAINT [FK_MaquinaFisicaMaquina_MaquinaIdMaquina]
GO
ALTER TABLE [dbo].[MaquinaFisica]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFisicaNave_NaveIdNave] FOREIGN KEY([NaveIdNave])
REFERENCES [dbo].[Nave] ([IdNave])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[MaquinaFisica] CHECK CONSTRAINT [FK_MaquinaFisicaNave_NaveIdNave]
GO
ALTER TABLE [dbo].[MaquinaProceso]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaProcesoProceso_ProcesoIdProceso] FOREIGN KEY([ProcesoIdProceso])
REFERENCES [dbo].[Proceso] ([IdProceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[MaquinaProceso] CHECK CONSTRAINT [FK_MaquinaProcesoProceso_ProcesoIdProceso]
GO
ALTER TABLE [dbo].[MultiMediaPieza]  WITH CHECK ADD  CONSTRAINT [FK_MultiMediaIdTipoDocumento_TipoDocumentoId] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TipoDocumento] ([Id])
GO
ALTER TABLE [dbo].[MultiMediaPieza] CHECK CONSTRAINT [FK_MultiMediaIdTipoDocumento_TipoDocumentoId]
GO
ALTER TABLE [dbo].[MultiMediaPieza]  WITH CHECK ADD  CONSTRAINT [FK_MultiMediaPieza_MultiMediaPiezaIdPieza] FOREIGN KEY([IdPieza])
REFERENCES [dbo].[Pieza] ([IdPieza])
GO
ALTER TABLE [dbo].[MultiMediaPieza] CHECK CONSTRAINT [FK_MultiMediaPieza_MultiMediaPiezaIdPieza]
GO
ALTER TABLE [dbo].[Nave]  WITH CHECK ADD  CONSTRAINT [FK_NavePlanta_PlantaIdPlanta] FOREIGN KEY([PlantaIdPlanta])
REFERENCES [dbo].[Planta] ([IdPlanta])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Nave] CHECK CONSTRAINT [FK_NavePlanta_PlantaIdPlanta]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Menu] FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Menu]
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilOperacionPermiso_Operacion] FOREIGN KEY([IdOperacion])
REFERENCES [dbo].[Operacion] ([Id])
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso] CHECK CONSTRAINT [FK_PerfilOperacionPermiso_Operacion]
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso]  WITH CHECK ADD  CONSTRAINT [FK_PerfilOperacionPermiso_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[PerfilOperacionPermiso] CHECK CONSTRAINT [FK_PerfilOperacionPermiso_Perfil]
GO
ALTER TABLE [dbo].[PiezaCliente]  WITH CHECK ADD  CONSTRAINT [FK_PiezaClientePieza_PiezaIdPieza] FOREIGN KEY([PiezaIdPieza])
REFERENCES [dbo].[Pieza] ([IdPieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PiezaCliente] CHECK CONSTRAINT [FK_PiezaClientePieza_PiezaIdPieza]
GO
ALTER TABLE [dbo].[PreguntaMaquina]  WITH CHECK ADD  CONSTRAINT [Preguntas_Maquina_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaMaquina] CHECK CONSTRAINT [Preguntas_Maquina_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaMaquina]  WITH CHECK ADD  CONSTRAINT [Preguntas_Maquina_Maquinas_Maquinas_Id_Maquina] FOREIGN KEY([MaquinaIdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaMaquina] CHECK CONSTRAINT [Preguntas_Maquina_Maquinas_Maquinas_Id_Maquina]
GO
ALTER TABLE [dbo].[PreguntaMaquina]  WITH CHECK ADD  CONSTRAINT [Preguntas_Maquina_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaMaquina] CHECK CONSTRAINT [Preguntas_Maquina_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[PreguntaMaquinaGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Maquina_Generales_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaMaquinaGeneral] CHECK CONSTRAINT [Preguntas_Maquina_Generales_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaMaquinaGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Maquina_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaMaquinaGeneral] CHECK CONSTRAINT [Preguntas_Maquina_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[PreguntaPieza]  WITH CHECK ADD  CONSTRAINT [Preguntas_Piezas_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPieza] CHECK CONSTRAINT [Preguntas_Piezas_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaPieza]  WITH CHECK ADD  CONSTRAINT [Preguntas_Piezas_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPieza] CHECK CONSTRAINT [Preguntas_Piezas_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[PreguntaPieza]  WITH CHECK ADD  CONSTRAINT [Preguntas_Piezas_Piezas_Piezas_Id_Pieza] FOREIGN KEY([PiezaIdPieza])
REFERENCES [dbo].[Pieza] ([IdPieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPieza] CHECK CONSTRAINT [Preguntas_Piezas_Piezas_Piezas_Id_Pieza]
GO
ALTER TABLE [dbo].[PreguntaPiezaGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Piezas_Generales_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPiezaGeneral] CHECK CONSTRAINT [Preguntas_Piezas_Generales_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaPiezaGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Piezas_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPiezaGeneral] CHECK CONSTRAINT [Preguntas_Piezas_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[PreguntaProceso]  WITH CHECK ADD  CONSTRAINT [Preguntas_Procesos_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaProceso] CHECK CONSTRAINT [Preguntas_Procesos_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaProceso]  WITH CHECK ADD  CONSTRAINT [Preguntas_Procesos_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaProceso] CHECK CONSTRAINT [Preguntas_Procesos_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[PreguntaProceso]  WITH CHECK ADD  CONSTRAINT [Preguntas_Procesos_Procesos_Procesos_Id_Proceso] FOREIGN KEY([ProcesoIdProceso])
REFERENCES [dbo].[Proceso] ([IdProceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaProceso] CHECK CONSTRAINT [Preguntas_Procesos_Procesos_Procesos_Id_Proceso]
GO
ALTER TABLE [dbo].[PreguntaProcesoGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Procesos_Generales_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaProcesoGeneral] CHECK CONSTRAINT [Preguntas_Procesos_Generales_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaProcesoGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Procesos_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaProcesoGeneral] CHECK CONSTRAINT [Preguntas_Procesos_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[PreguntaPtGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Pt_Generales_Idioma_Idioma_Id_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPtGeneral] CHECK CONSTRAINT [Preguntas_Pt_Generales_Idioma_Idioma_Id_Idioma]
GO
ALTER TABLE [dbo].[PreguntaPtGeneral]  WITH CHECK ADD  CONSTRAINT [Preguntas_Pt_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PreguntaPtGeneral] CHECK CONSTRAINT [Preguntas_Pt_Generales_Niveles_Certificacion_Niveles_Certificacion_Id_Nivel_Certificacion]
GO
ALTER TABLE [dbo].[ProcesoPiezaMaquina]  WITH CHECK ADD  CONSTRAINT [Procesos_Piezas_Maquinas_Piezas_Piezas_Id_Pieza] FOREIGN KEY([PiezaIdPieza])
REFERENCES [dbo].[Pieza] ([IdPieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ProcesoPiezaMaquina] CHECK CONSTRAINT [Procesos_Piezas_Maquinas_Piezas_Piezas_Id_Pieza]
GO
ALTER TABLE [dbo].[RespuestaMaquina]  WITH CHECK ADD  CONSTRAINT [Respuestas_Maquina_Preguntas_Maquina_Preguntas_Maquina_Id_Pregunta_Maquina] FOREIGN KEY([PreguntaMaquinaIdPreguntaMaquina])
REFERENCES [dbo].[PreguntaMaquina] ([IdPreguntaMaquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RespuestaMaquina] CHECK CONSTRAINT [Respuestas_Maquina_Preguntas_Maquina_Preguntas_Maquina_Id_Pregunta_Maquina]
GO
ALTER TABLE [dbo].[RespuestaMaquina]  WITH CHECK ADD  CONSTRAINT [Respuestas_Maquina_Resultados_Maquina_Resultados_Maquina_Id_Resultado_Maquina] FOREIGN KEY([ResultadoMaquinaIdResultadoMaquina])
REFERENCES [dbo].[ResultadoMaquina] ([IdResultadoMaquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RespuestaMaquina] CHECK CONSTRAINT [Respuestas_Maquina_Resultados_Maquina_Resultados_Maquina_Id_Resultado_Maquina]
GO
ALTER TABLE [dbo].[RespuestaPieza]  WITH CHECK ADD  CONSTRAINT [Respuestas_Pieza_Preguntas_Piezas_Preguntas_Piezas_Id_Pregunta_Pieza] FOREIGN KEY([PreguntaPiezaIdPreguntaPieza])
REFERENCES [dbo].[PreguntaPieza] ([IdPreguntaPieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RespuestaPieza] CHECK CONSTRAINT [Respuestas_Pieza_Preguntas_Piezas_Preguntas_Piezas_Id_Pregunta_Pieza]
GO
ALTER TABLE [dbo].[RespuestaPieza]  WITH CHECK ADD  CONSTRAINT [Respuestas_Pieza_Resultados_Pieza_Resultados_Pieza_Id_Resultado_Pieza] FOREIGN KEY([ResultadoPiezaIdResultadoPieza])
REFERENCES [dbo].[ResultadoPieza] ([IdResultadoPieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RespuestaPieza] CHECK CONSTRAINT [Respuestas_Pieza_Resultados_Pieza_Resultados_Pieza_Id_Resultado_Pieza]
GO
ALTER TABLE [dbo].[RespuestaProceso]  WITH CHECK ADD  CONSTRAINT [Respuestas_Proceso_Preguntas_Procesos_Preguntas_Procesos_Id_Pregunta_Proceso] FOREIGN KEY([PreguntaProcesoIdPreguntaProceso])
REFERENCES [dbo].[PreguntaProceso] ([IdPreguntaProceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RespuestaProceso] CHECK CONSTRAINT [Respuestas_Proceso_Preguntas_Procesos_Preguntas_Procesos_Id_Pregunta_Proceso]
GO
ALTER TABLE [dbo].[RespuestaProceso]  WITH CHECK ADD  CONSTRAINT [Respuestas_Proceso_Resultados_Proceso_Resultados_Proceso_Id_Resultado_Proceso] FOREIGN KEY([ResultadoProcesoIdResultadoProceso])
REFERENCES [dbo].[ResultadoProceso] ([IdResultadoProceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RespuestaProceso] CHECK CONSTRAINT [Respuestas_Proceso_Resultados_Proceso_Resultados_Proceso_Id_Resultado_Proceso]
GO
USE [master]
GO
ALTER DATABASE [CARTAV] SET  READ_WRITE 
GO
