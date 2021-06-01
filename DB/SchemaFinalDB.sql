USE [master]
GO
/****** Object:  Database [CARTAV]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Workflow]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workflow](
	[IdWorkFlow] [bigint] IDENTITY(1,1) NOT NULL,
	[PiezaIdPieza] [bigint] NOT NULL,
	[ProcesoIdProceso] [bigint] NOT NULL,
	[Tiempo] [int] NULL,
	[Orden] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[IdWorkFlow] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pieza]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
	[Reentrenar] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PiezaCliente]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PiezaCliente](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClienteIdCliente] [bigint] NOT NULL,
	[PiezaIdPieza] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_PiezaCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MultiMediaPieza]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiMediaPieza](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPieza] [bigint] NOT NULL,
	[IdTipoDocumento] [bigint] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Version] [nvarchar](50) NULL,
	[Recertificacion] [bit] NULL,
	[Ruta] [nvarchar](max) NULL,
	[TipoMedia] [nvarchar](50) NOT NULL,
	[Extension] [nvarchar](50) NULL,
	[Tamanio] [nvarchar](50) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_MultiMediaPieza] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_PIEZAS_MULTIMEDIAS]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Retorna las piezas y sus totales de multimedia*/
CREATE VIEW [dbo].[VW_PIEZAS_MULTIMEDIAS]
AS
SELECT        IdPieza, NumeroParte, Nombre, Descripcion, Activo, SUM(countDoc) AS countDoc, SUM(countVideo) AS countVideo, SUM(countImg) AS countImg, SUM(countClientes) AS countClientes, SUM(countWorkflow) 
                         AS countWorkflow
FROM            (SELECT        p.IdPieza, p.NumeroParte, p.Nombre, p.Descripcion, p.Activo, CASE m.TipoMedia WHEN 'DOC' THEN COUNT(m.TipoMedia) ELSE 0 END AS countDoc, CASE m.TipoMedia WHEN 'VIDEO' THEN COUNT(m.TipoMedia) 
                                                    ELSE 0 END AS countVideo, CASE m.TipoMedia WHEN 'IMG' THEN COUNT(m.TipoMedia) ELSE 0 END AS countImg, COUNT(pc.ClienteIdCliente) AS countClientes, COUNT(wf.PiezaIdPieza) AS countWorkflow
                          FROM            dbo.Pieza AS p LEFT OUTER JOIN
                                                    dbo.MultiMediaPieza AS m ON p.IdPieza = m.IdPieza LEFT OUTER JOIN
                                                    dbo.PiezaCliente AS pc ON pc.PiezaIdPieza = p.IdPieza LEFT OUTER JOIN
                                                    dbo.Cliente AS c ON c.IdCliente = pc.ClienteIdCliente LEFT OUTER JOIN
                                                    dbo.Workflow AS wf ON p.IdPieza = wf.PiezaIdPieza
                          GROUP BY p.IdPieza, p.NumeroParte, p.Nombre, p.Descripcion, p.Activo, m.TipoMedia) AS U
GROUP BY IdPieza, NumeroParte, Nombre, Descripcion, Activo
GO
/****** Object:  View [dbo].[VW_PIEZA_CLIENTE]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_PIEZA_CLIENTE]
AS
SELECT        pc.Id, pc.ClienteIdCliente, pc.PiezaIdPieza, C.Nombre, C.Contacto, C.Email, C.Telefono, pc.Activo
FROM            dbo.PiezaCliente AS pc LEFT OUTER JOIN
                         dbo.Cliente AS C ON pc.ClienteIdCliente = C.IdCliente
GO
/****** Object:  Table [dbo].[MaquinaProceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaProceso](
	[IdMaquinaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[MaquinaIdMaquina] [bigint] NOT NULL,
	[ProcesoIdProceso] [bigint] NOT NULL,
	[UsaPreguntaEstandar] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_MaquinaProceso] PRIMARY KEY CLUSTERED 
(
	[IdMaquinaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaMaquina]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaMaquina](
	[IdPreguntaMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[MaquinaIdMaquina] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__B63CDED2266C1596] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquina]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
	[TipoAccesoIdTipoAcceso] [bigint] NOT NULL,
	[UsaPreguntaEstandar] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Maquina_9A2F321BE6366944] PRIMARY KEY CLUSTERED 
(
	[IdMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_MAQUINA_PREGUNTAS]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_MAQUINA_PREGUNTAS]
AS
SELECT        m.IdMaquina, m.Nombre, m.Descripcion, m.Modelo, m.MaquinaPt, m.CantidadAccesoMultiple, m.FabricanteIdFabricante, m.TipoAccesoIdTipoAcceso, m.UsaPreguntaEstandar, m.Activo, COUNT(pm.IdPreguntaMaquina) AS countPreguntas,
                  COUNT(pro.MaquinaIdMaquina) AS countProcesos
FROM     dbo.Maquina AS m LEFT OUTER JOIN
                  dbo.PreguntaMaquina AS pm ON m.IdMaquina = pm.MaquinaIdMaquina LEFT OUTER JOIN
                  dbo.MaquinaProceso AS pro ON m.IdMaquina = pro.MaquinaIdMaquina GROUP BY m.IdMaquina, m.Nombre, m.Descripcion, m.Modelo, m.MaquinaPt, m.CantidadAccesoMultiple, m.FabricanteIdFabricante, m.TipoAccesoIdTipoAcceso, m.UsaPreguntaEstandar, m.Activo
GO
/****** Object:  Table [dbo].[CentroCosto]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Certificacion]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Departamento]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[DepartamentoNivel1]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[DepartamentoNivel2]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[DepartamentoNivel3]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[DocumentoPiezaProceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [bigint] IDENTITY(1,1) NOT NULL,
	[NumeroNomina] [varchar](max) NOT NULL,
	[CuentaUsuario] [varchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[Fabricante]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[LineaProduccion]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[MaquinaFisica]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaFisica](
	[IdMaquinaFisica] [bigint] IDENTITY(1,1) NOT NULL,
	[NSerie] [varchar](max) NOT NULL,
	[Ubicacion] [varchar](max) NULL,
	[MaquinaPt] [bit] NOT NULL,
	[MaquinaIdMaquina] [bigint] NOT NULL,
	[PlantaIdPlanta] [bigint] NOT NULL,
	[NaveIdNave] [bigint] NOT NULL,
	[LineaProduccionIdLineaProduccion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Maquina_5BE456CBA6BE8746] PRIMARY KEY CLUSTERED 
(
	[IdMaquinaFisica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Nave]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[NivelCertificacion]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Operacion]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Perfil]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Perfil] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PKPerfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilOperacionPermiso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Planta]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[PreguntaGeneral]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaGeneral](
	[IdPreguntaGeneral] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [nvarchar](max) NOT NULL,
	[Respuesta] [nvarchar](max) NULL,
	[Orden] [int] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[TipoPreguntaIdTipoPregunta] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_PreguntaGeneral] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaGeneral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaMaquinaGeneral]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaMaquinaGeneral](
	[IdPreguntaMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
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
/****** Object:  Table [dbo].[PreguntaPieza]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaPieza](
	[IdPreguntaPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[ProcesoPiezaMaquinaIdProcesoPiezaMaquina] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__4F0326314772454F] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPiezaGeneral]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaPiezaGeneral](
	[IdPreguntaPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__4F03263192CFAEDE] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaProceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaProceso](
	[IdPreguntaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[MaquinaProcesoIdMaquinaProceso] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__2637C0FB04D15390] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaProcesoGeneral]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaProcesoGeneral](
	[IdPreguntaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__2637C0FB3AF97B58] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPtGeneral]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Proceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proceso](
	[IdProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Dificultad] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Procesos__4D1766E4A1132DCA] PRIMARY KEY CLUSTERED 
(
	[IdProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcesoPiezaMaquina]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcesoPiezaMaquina](
	[IdProcesoPiezaMaquina] [bigint] IDENTITY(1,1) NOT NULL,
	[PiezaIdPieza] [bigint] NOT NULL,
	[MaquinaProcesoIdMaquinaProceso] [bigint] NOT NULL,
	[UsaPreguntaEstandar] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_ProcesoPiezaMaquina] PRIMARY KEY CLUSTERED 
(
	[IdProcesoPiezaMaquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessLog]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[Puesto]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[ResourceValidacionCampo]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceValidacionCampo](
	[IdReglaValidacion] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[TipoDato] [nvarchar](50) NOT NULL,
	[TamanioCampo] [int] NOT NULL,
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
/****** Object:  Table [dbo].[RespuestaMaquina]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[RespuestaPieza]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[RespuestaProceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[ResultadoMaquina]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[ResultadoPieza]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[ResultadoProceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[TipoAcceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[TipoPregunta]    Script Date: 31/05/2021 10:02:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPregunta](
	[IdTipoPregunta] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TipoPregunta] PRIMARY KEY CLUSTERED 
(
	[IdTipoPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadNegocio]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
/****** Object:  Table [dbo].[VideoPiezaProceso]    Script Date: 31/05/2021 10:02:00 a. m. ******/
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
SET IDENTITY_INSERT [dbo].[CentroCosto] ON 

INSERT [dbo].[CentroCosto] ([IdCentroCosto], [IdCentroCostoExterno], [DescCentroCosto], [DuenoCeco], [Activo]) VALUES (1, 2314, N'SUELDOS1', 253, 1)
SET IDENTITY_INSERT [dbo].[CentroCosto] OFF
GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([IdDepartamento], [IdDepartamentExterno], [Departamento], [Activo]) VALUES (1, 12, N'DEPARTAMENTO0321123', 1)
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [CuentaUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (1, N'2610', N'omar.alvarez', N'OMAR', N'ALVAREZ', N'ALCANTARA', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'omar.alvarez@bocar.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [CuentaUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (2, N'34425', N'gerardo.hernandez.f', N'GERARDO', N'HERNÁNDEZ', N'FADIÑO', CAST(N'1978-01-03' AS Date), CAST(N'2019-01-01' AS Date), N'gerardo.hernandez.f@bocar.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [CuentaUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (3, N'21042', N'adria.arguelles', N'ADRIAN', N'ARGUELLES', N'BECERRIL', CAST(N'1984-01-31' AS Date), CAST(N'2012-01-11' AS Date), N'adria.arguelles@bocar.com', N'21042', 1, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [CuentaUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (4, N'2611', N'laura.zemeno', N'LAURA', N'ZERMEÑO', N'PICHARDO', CAST(N'1997-01-02' AS Date), CAST(N'2021-01-01' AS Date), N'laura.zemeno@bocar.com', N'2611', 1, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [CuentaUsuario], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (5, N'558577', N'jorge.bernal', N'JORGE', N'BERNAL', N'GARCÍA', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'jorge.bernal@bocar.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Fabricante] ON 

INSERT [dbo].[Fabricante] ([IdFabricante], [Nombre], [Contacto], [Email], [Telefono], [Activo]) VALUES (1, N'N/A', N'N/A', N'N/A', N'N/A', 1)
SET IDENTITY_INSERT [dbo].[Fabricante] OFF
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
SET IDENTITY_INSERT [dbo].[MultiMediaPieza] ON 

INSERT [dbo].[MultiMediaPieza] ([Id], [IdPieza], [IdTipoDocumento], [Nombre], [Descripcion], [Version], [Recertificacion], [Ruta], [TipoMedia], [Extension], [Tamanio], [Activo]) VALUES (1, 1, 2, N'Documento1.2', N'Documento1.2', N'1.0', 1, N'/documentos/documento1.2.rtf', N'DOC', N'.rtf', N'460', 0)
SET IDENTITY_INSERT [dbo].[MultiMediaPieza] OFF
GO
SET IDENTITY_INSERT [dbo].[NivelCertificacion] ON 

INSERT [dbo].[NivelCertificacion] ([IdNivelCertificacion], [NombreNivelCertificacion], [DescripcionNivelCertificacion], [DificultadNivelCertificacion], [Color], [Activo]) VALUES (1, N'Principiante', N'Nivel de principiante. Debe operar bajo supervisión', 1, N'#eda507', 1)
INSERT [dbo].[NivelCertificacion] ([IdNivelCertificacion], [NombreNivelCertificacion], [DescripcionNivelCertificacion], [DificultadNivelCertificacion], [Color], [Activo]) VALUES (2, N'Básico', N'Nivel básico', 2, N'#ecdd13', 1)
INSERT [dbo].[NivelCertificacion] ([IdNivelCertificacion], [NombreNivelCertificacion], [DescripcionNivelCertificacion], [DificultadNivelCertificacion], [Color], [Activo]) VALUES (3, N'Intermedio', N'Nivel intermedio', 3, N'#53e60f', 1)
INSERT [dbo].[NivelCertificacion] ([IdNivelCertificacion], [NombreNivelCertificacion], [DescripcionNivelCertificacion], [DificultadNivelCertificacion], [Color], [Activo]) VALUES (4, N'Avanzado', N'Nivel avanzado. Puede hacer labores de mentor', 4, N'#18d9fb', 1)
SET IDENTITY_INSERT [dbo].[NivelCertificacion] OFF
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
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (11, N'RegLog', N'RegLog', N'RegLog', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (12, N'PreguntasGrales', N'PreguntasGrales', N'PreguntasGrales', 1, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (13, N'Certificaciones', N'Certificaciones', N'Certificaciones', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (14, N'NecesidadesCertifica', N'NecesidadesCertifica', N'NecesidadesCertifica', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (15, N'Examenes', N'Examenes', N'Examenes', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (16, N'EmpPerfiles', N'EmpPerfiles', N'EmpPerfiles', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (17, N'AsignaCapacita', N'AsignaCapacita', N'AsignaCapacita', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (18, N'FirmasPendientes', N'FirmasPendientes', N'FirmasPendientes', 2, 1)
INSERT [dbo].[Operacion] ([Id], [Operacion], [NombreMenu], [NombrePagina], [IdMenu], [Activo]) VALUES (19, N'CapacitacionesCaduca', N'CapacitacionesCaduca', N'CapacitacionesCaduca', 2, 1)
SET IDENTITY_INSERT [dbo].[Operacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Perfil], [Descripcion], [Activo]) VALUES (1, N'Administrador', N'Administrador con todos los permisos en la plataforma', 1)
INSERT [dbo].[Perfil] ([Id], [Perfil], [Descripcion], [Activo]) VALUES (2, N'Usuario', N'Solo algunos permisos para la plataforma', 1)
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[PerfilOperacionPermiso] ON 

INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (2, 1, 2, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (3, 1, 3, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (4, 1, 4, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (5, 1, 5, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (6, 1, 6, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (7, 1, 7, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (8, 1, 8, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (9, 1, 9, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (10, 1, 10, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (11, 1, 11, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (12, 1, 12, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (13, 1, 13, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (14, 1, 14, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (15, 1, 15, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (16, 1, 16, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (17, 1, 17, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (18, 1, 18, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (19, 1, 19, 1, 1, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (20, 2, 1, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (21, 2, 2, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (22, 2, 3, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (23, 2, 4, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (24, 2, 5, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (25, 2, 6, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (26, 2, 7, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (27, 2, 8, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (28, 2, 9, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (29, 2, 10, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (30, 2, 11, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (31, 2, 12, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (32, 2, 13, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (33, 2, 14, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (34, 2, 15, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (35, 2, 16, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (36, 2, 17, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (37, 2, 18, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (38, 2, 19, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[PerfilOperacionPermiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Pieza] ON 

INSERT [dbo].[Pieza] ([IdPieza], [NumeroParte], [Nombre], [Descripcion], [Activo]) VALUES (1, N'80A821169/170', N'Cubierta frontal interna izq/der ffffff', N'Cubierta frontal interna izq/der eeeeeeeeeee', 1)
SET IDENTITY_INSERT [dbo].[Pieza] OFF
GO
SET IDENTITY_INSERT [dbo].[Planta] ON 

INSERT [dbo].[Planta] ([IdPlanta], [IdPlantaExterno], [Acronimo], [Planta], [Activo]) VALUES (1, 111, N'BOLERMA', N'Bocar Lerma', 1)
INSERT [dbo].[Planta] ([IdPlanta], [IdPlantaExterno], [Acronimo], [Planta], [Activo]) VALUES (2, 113, N'AUCHI', N'Planta de Chihuahua', 1)
SET IDENTITY_INSERT [dbo].[Planta] OFF
GO
SET IDENTITY_INSERT [dbo].[Proceso] ON 

INSERT [dbo].[Proceso] ([IdProceso], [Codigo], [Nombre], [Descripcion], [Dificultad], [Activo]) VALUES (1, N'OP 1000-10', N'Maquinado', N'Maquinado', 1, 1)
SET IDENTITY_INSERT [dbo].[Proceso] OFF
GO
SET IDENTITY_INSERT [dbo].[ProcessLog] ON 

INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (1, N'::1', CAST(N'2021-05-27T06:20:03.470' AS DateTime), N'Operation (OPERACIÓN = AddPlanta)Type: PlantumProperties (N = 7)  IdPlanta (Int64): 1
  IdPlantaExterno (Nullable`1): 111
  Acronimo (String): BOLERMA
  Planta (String): Bocar Lerma
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (2, N'::1', CAST(N'2021-05-27T06:20:03.843' AS DateTime), N'Operation (OPERACIÓN = AddDepartamento)Type: DepartamentoProperties (N = 5)  IdDepartamento (Int64): 1
  IdDepartamentExterno (Int64): 12
  Departamento1 (String): DEPARTAMENTO0321123
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (3, N'::1', CAST(N'2021-05-27T06:20:03.980' AS DateTime), N'Operation (OPERACIÓN = AddPuesto)Type: PuestoProperties (N = 4)  IdPuesto (Int64): 1
  IdPuestoExterno (Int64): 9
  DescPuesto (String): PUESTO66666
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (4, N'::1', CAST(N'2021-05-27T06:20:04.130' AS DateTime), N'Operation (OPERACIÓN = AddUnidadNeg)Type: UnidadNegocioProperties (N = 3)  IdUnidadNegocio (Int64): 1
  IdUnidadNegocioExterno (Int64): 0
  DescUnidadNegocio (String): AUMA SERVICIOS, S.A. DE C.V.
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (5, N'::1', CAST(N'2021-05-27T06:20:04.297' AS DateTime), N'Operation (OPERACIÓN = AddCECO)Type: CentroCostoProperties (N = 5)  IdCentroCosto (Int64): 1
  IdCentroCostoExterno (Int64): 2314
  DescCentroCosto (String): SUELDOS1
  DuenoCeco (Int64): 253
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (6, N'::1', CAST(N'2021-05-27T06:20:04.620' AS DateTime), N'Operation (OPERACIÓN = AddEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 1
  NumeroNomina (String): 2610
  CuentaUsuario (String): omar.alvarez
  Nombre (String): OMAR
  ApellidoPaterno (String): ALVAREZ
  ApellidoMaterno (String): ALCANTARA
  FechaNacimiento (DateTime): 12/01/1983 12:09:00 a. m.
  FechaIngreso (DateTime): 02/01/2020 12:01:00 a. m.
  Email (String): omar.alvarez@bocar.com
  NominaJefe (String): 17441
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 2
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (7, N'::1', CAST(N'2021-05-27T06:20:04.870' AS DateTime), N'Operation (OPERACIÓN = AddEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 2
  NumeroNomina (String): 34425
  CuentaUsuario (String): gerardo.hernandez.f
  Nombre (String): GERARDO
  ApellidoPaterno (String): HERNÁNDEZ
  ApellidoMaterno (String): FADIÑO
  FechaNacimiento (DateTime): 03/01/1978 12:07:00 a. m.
  FechaIngreso (DateTime): 01/01/2019 12:11:00 a. m.
  Email (String): gerardo.hernandez.f@bocar.com
  NominaJefe (String): 17441
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 2
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (8, N'::1', CAST(N'2021-05-27T06:20:04.883' AS DateTime), N'Operation (OPERACIÓN = AddPlanta)Type: PlantumProperties (N = 7)  IdPlanta (Int64): 2
  IdPlantaExterno (Nullable`1): 113
  Acronimo (String): AUCHI
  Planta (String): Planta de Chihuahua
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (9, N'::1', CAST(N'2021-05-27T06:20:04.897' AS DateTime), N'Operation (OPERACIÓN = AddEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 3
  NumeroNomina (String): 21042
  CuentaUsuario (String): adria.arguelles
  Nombre (String): ADRIAN
  ApellidoPaterno (String): ARGUELLES
  ApellidoMaterno (String): BECERRIL
  FechaNacimiento (DateTime): 31/01/1984 12:08:00 a. m.
  FechaIngreso (DateTime): 11/01/2012 12:09:00 a. m.
  Email (String): adria.arguelles@bocar.com
  NominaJefe (String): 17441
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 2
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (10, N'::1', CAST(N'2021-05-27T06:20:04.940' AS DateTime), N'Operation (OPERACIÓN = AddEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): laura.zemeno
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:04:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:02:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 17441
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 2
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (11, N'::1', CAST(N'2021-05-27T06:20:04.960' AS DateTime), N'Operation (OPERACIÓN = AddEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 5
  NumeroNomina (String): 558577
  CuentaUsuario (String): jorge.bernal
  Nombre (String): JORGE
  ApellidoPaterno (String): BERNAL
  ApellidoMaterno (String): GARCÍA
  FechaNacimiento (DateTime): 12/01/1983 12:09:00 a. m.
  FechaIngreso (DateTime): 02/01/2020 12:01:00 a. m.
  Email (String): jorge.bernal@bocar.com
  NominaJefe (String): 17441
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 2
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (12, N'::1', CAST(N'2021-05-27T09:38:51.960' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 3
  NumeroNomina (String): 21042
  CuentaUsuario (String): adria.arguelles
  Nombre (String): ADRIAN
  ApellidoPaterno (String): ARGUELLES
  ApellidoMaterno (String): BECERRIL
  FechaNacimiento (DateTime): 31/01/1984 12:00:00 a. m.
  FechaIngreso (DateTime): 11/01/2012 12:00:00 a. m.
  Email (String): adria.arguelles@bocar.com
  NominaJefe (String): 21042
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (13, N'::1', CAST(N'2021-05-27T09:39:33.887' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 3
  NumeroNomina (String): 21042
  CuentaUsuario (String): adria.arguelles
  Nombre (String): ADRIAN
  ApellidoPaterno (String): ARGUELLES
  ApellidoMaterno (String): BECERRIL
  FechaNacimiento (DateTime): 31/01/1984 12:00:00 a. m.
  FechaIngreso (DateTime): 11/01/2012 12:00:00 a. m.
  Email (String): adria.arguelles@bocar.com
  NominaJefe (String): 21042
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (14, N'::1', CAST(N'2021-05-27T09:41:13.303' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 3
  NumeroNomina (String): 21042
  CuentaUsuario (String): adria.arguelles
  Nombre (String): ADRIAN
  ApellidoPaterno (String): ARGUELLES
  ApellidoMaterno (String): BECERRIL
  FechaNacimiento (DateTime): 31/01/1984 12:00:00 a. m.
  FechaIngreso (DateTime): 11/01/2012 12:00:00 a. m.
  Email (String): adria.arguelles@bocar.com
  NominaJefe (String): 21042
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (15, N'::1', CAST(N'2021-05-27T09:52:43.043' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (16, N'::1', CAST(N'2021-05-27T09:52:43.290' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'Cannot insert the value NULL into column ''CuentaUsuario'', table ''CARTAV.dbo.Empleado''; column does not allow nulls. UPDATE fails.
The statement has been terminated.', 400)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (17, N'::1', CAST(N'2021-05-27T09:53:21.877' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (18, N'::1', CAST(N'2021-05-27T09:53:21.933' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'Cannot insert the value NULL into column ''CuentaUsuario'', table ''CARTAV.dbo.Empleado''; column does not allow nulls. UPDATE fails.
The statement has been terminated.', 400)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (19, N'::1', CAST(N'2021-05-27T09:56:17.577' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (20, N'::1', CAST(N'2021-05-27T09:56:17.927' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'Cannot insert the value NULL into column ''CuentaUsuario'', table ''CARTAV.dbo.Empleado''; column does not allow nulls. UPDATE fails.
The statement has been terminated.', 400)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (21, N'::1', CAST(N'2021-05-27T09:56:35.130' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (22, N'::1', CAST(N'2021-05-27T09:57:55.913' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (23, N'::1', CAST(N'2021-05-27T09:58:05.953' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): 
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'Cannot insert the value NULL into column ''CuentaUsuario'', table ''CARTAV.dbo.Empleado''; column does not allow nulls. UPDATE fails.
The statement has been terminated.', 400)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (24, N'::1', CAST(N'2021-05-27T10:03:00.433' AS DateTime), N'Operation (OPERACIÓN = UpdateEmpleado)Type: EmpleadoProperties (N = 24)  IdEmpleado (Int64): 4
  NumeroNomina (String): 2611
  CuentaUsuario (String): laura.zemeno
  Nombre (String): LAURA
  ApellidoPaterno (String): ZERMEÑO
  ApellidoMaterno (String): PICHARDO
  FechaNacimiento (DateTime): 02/01/1997 12:00:00 a. m.
  FechaIngreso (DateTime): 01/01/2021 12:00:00 a. m.
  Email (String): laura.zemeno@bocar.com
  NominaJefe (String): 2611
  DepartamentoIdDepartamentoNivel0 (Int64): 1
  DepartamentoIdDepartamentoNivel1 (Nullable`1): 
  DepartamentoIdDepartamentoNivel2 (Nullable`1): 
  DepartamentoIdDepartamentoNivel3 (Nullable`1): 
  IdiomaIdIdioma (Int64): 1
  PuestoIdPuesto (Int64): 1
  UnidadNegocioIdUnidadNegocio (Int64): 1
  CentroCostoIdCentroCosto (Int64): 1
  IdPerfil (Nullable`1): 1
  Activo (Nullable`1): True
  DepartamentoIdDepartamentoNivel1Navigation (DepartamentoNivel1): 
  DepartamentoIdDepartamentoNivel2Navigation (DepartamentoNivel2): 
  DepartamentoIdDepartamentoNivel3Navigation (DepartamentoNivel3): 
  IdiomaIdIdiomaNavigation (Idioma): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (25, N'::1', CAST(N'2021-05-27T11:19:57.023' AS DateTime), N'Operation (OPERACIÓN = AddPieza)Type: PiezaProperties (N = 9)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der
  Descripcion (String): Cubierta frontal interna izq/der
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (26, N'::1', CAST(N'2021-05-27T11:34:09.943' AS DateTime), N'Operation (OPERACIÓN = UpdatePieza)Type: PiezaProperties (N = 9)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der asdsadsadsda
  Descripcion (String): Cubierta frontal interna izq/der
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (27, N'::1', CAST(N'2021-05-27T11:35:00.637' AS DateTime), N'Operation (OPERACIÓN = AddProceso)Type: ProcesoProperties (N = 8)  IdProceso (Int64): 1
  Codigo (String): OP 1000-10
  Nombre (String): Maquinado
  Descripcion (String): Maquinado
  Dificultad (Int32): 1
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (28, N'::1', CAST(N'2021-05-27T11:35:06.393' AS DateTime), N'Operation (OPERACIÓN = UpdateProceso)Type: ProcesoProperties (N = 8)  IdProceso (Int64): 1
  Codigo (String): OP 1000-10
  Nombre (String): Maquinado asdsadsad
  Descripcion (String): Maquinadoasdsadasd
  Dificultad (Int32): 1
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (29, N'::1', CAST(N'2021-05-27T11:35:14.050' AS DateTime), N'Operation (OPERACIÓN = UpdateProceso)Type: ProcesoProperties (N = 8)  IdProceso (Int64): 1
  Codigo (String): OP 1000-10
  Nombre (String): Maquinado
  Descripcion (String): Maquinado
  Dificultad (Int32): 1
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (30, N'::1', CAST(N'2021-05-27T11:53:10.083' AS DateTime), N'Operation (OPERACIÓN = UpdatePieza)Type: PiezaProperties (N = 9)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der
  Descripcion (String): Cubierta frontal interna izq/der
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (31, N'::1', CAST(N'2021-05-27T11:58:32.190' AS DateTime), N'Operation (OPERACIÓN = UpdatePieza)Type: PiezaProperties (N = 9)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der ffffff
  Descripcion (String): Cubierta frontal interna izq/der
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (32, N'::1', CAST(N'2021-05-27T12:00:41.307' AS DateTime), N'Operation (OPERACIÓN = UpdatePieza)Type: PiezaProperties (N = 9)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der
  Descripcion (String): Cubierta frontal interna izq/der
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (33, N'::1', CAST(N'2021-05-31T09:53:24.683' AS DateTime), N'Operation (OPERACIÓN = AddMultimediaPieza)Type: MultiMediaPiezaProperties (N = 14)  Id (Int64): 1
  IdPieza (Int64): 1
  IdTipoDocumento (Int64): 2
  Nombre (String): Documento1
  Descripcion (String): Documento1
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): /documentos/documento1.rtf
  TipoMedia (String): DOC
  Extension (String): .rtf
  Tamanio (String): 460
  Activo (Boolean): True
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (34, N'::1', CAST(N'2021-05-31T09:54:30.513' AS DateTime), N'Operation (OPERACIÓN = UpdateMultimediaPieza)Type: MultiMediaPiezaProperties (N = 14)  Id (Int64): 1
  IdPieza (Int64): 1
  IdTipoDocumento (Int64): 2
  Nombre (String): Documento1
  Descripcion (String): Documento1
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): /documentos/documento1.rtf
  TipoMedia (String): DOC
  Extension (String): .rtf
  Tamanio (String): 439
  Activo (Boolean): True
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (35, N'::1', CAST(N'2021-05-31T09:59:49.117' AS DateTime), N'Operation (OPERACIÓN = UpdatePieza)Type: PiezaProperties (N = 9)  IdPieza (Int64): 1
  NumeroParte (String): 80A821169/170
  Nombre (String): Cubierta frontal interna izq/der ffffff
  Descripcion (String): Cubierta frontal interna izq/der eeeeeeeeeee
  Activo (Nullable`1): True
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (36, N'::1', CAST(N'2021-05-31T10:00:19.060' AS DateTime), N'Operation (OPERACIÓN = UpdateMultimediaPieza)Type: MultiMediaPiezaProperties (N = 14)  Id (Int64): 1
  IdPieza (Int64): 1
  IdTipoDocumento (Int64): 2
  Nombre (String): Documento1.2
  Descripcion (String): Documento1.2
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): /documentos/documento1.2.rtf
  TipoMedia (String): DOC
  Extension (String): .rtf
  Tamanio (String): 460
  Activo (Boolean): True
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'OK', 200)
INSERT [dbo].[ProcessLog] ([Id], [IP], [Fecha], [Data], [Respuesta], [Codigo]) VALUES (37, N'::1', CAST(N'2021-05-31T10:00:48.317' AS DateTime), N'Operation (OPERACIÓN = UpdateMultimediaPieza)Type: MultiMediaPiezaProperties (N = 14)  Id (Int64): 1
  IdPieza (Int64): 1
  IdTipoDocumento (Int64): 2
  Nombre (String): Documento1.2
  Descripcion (String): Documento1.2
  Version (String): 1.0
  Recertificacion (Nullable`1): True
  Ruta (String): /documentos/documento1.2.rtf
  TipoMedia (String): DOC
  Extension (String): .rtf
  Tamanio (String): 460
  Activo (Boolean): False
  IdPiezaNavigation (Pieza): 
  IdTipoDocumentoNavigation (TipoDocumento): 
', N'OK', 200)
SET IDENTITY_INSERT [dbo].[ProcessLog] OFF
GO
SET IDENTITY_INSERT [dbo].[Puesto] ON 

INSERT [dbo].[Puesto] ([IdPuesto], [IdPuestoExterno], [DescPuesto], [Activo]) VALUES (1, 9, N'PUESTO66666', 1)
SET IDENTITY_INSERT [dbo].[Puesto] OFF
GO
SET IDENTITY_INSERT [dbo].[ResourceValidacionCampo] ON 

INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (1, N'noNomina', N'int', 100, 1, N'Ninguno', 412, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 429, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (2, N'Nombre', N'string', 250, 1, N'Ninguno', 413, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 430, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (3, N'apellIdoPaterno', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 414, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (4, N'apellIdoMaterno', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 415, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (5, N'fechaNacimiento', N'date', 10, 1, N'Y/m/d', 416, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 410, N'no cumple con el Formato de fechas (yyyy/mm/dd)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (6, N'fechaIngreso', N'date', 10, 0, N'Y/m/d', 417, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 411, N'no cumple con el Formato de fechas aaaa/mm/dd')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (7, N'email', N'email', 250, 0, N'Ninguno', 418, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 423, N'no contiene un @ o no cumple con el Formato de email (usuario@dominio.com)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (8, N'IdPlanta', N'int', 10, 1, N'Ninguno', 442, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 443, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (9, N'DescripcionPlanta', N'string', 250, 1, N'Ninguno', 419, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 424, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (10, N'IdDepartamento', N'int', 10, 1, N'Ninguno', 444, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 445, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (11, N'departamento', N'string', 250, 1, N'Ninguno', 420, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 425, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (12, N'IdDepNivel1', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (13, N'DepNivel1', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (14, N'IdDepNivel2', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (15, N'DepNivel2', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (16, N'IdDepNivel3', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (17, N'DepNivel3', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (18, N'IdPuesto', N'int', 10, 1, N'Ninguno', 446, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 447, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (19, N'Puesto', N'string', 250, 1, N'Ninguno', 421, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 426, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (20, N'nominaJefe', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (21, N'IdUnidad', N'int', 10, 1, N'Ninguno', 448, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 449, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (22, N'Unidad', N'string', 250, 1, N'Ninguno', 431, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 432, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (23, N'IdCeCo', N'int', 10, 1, N'Ninguno', 450, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 451, N'supera el maximo permitIdo de caracteres (10)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (24, N'CeCo', N'string', 250, 1, N'Ninguno', 433, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 434, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (25, N'NoCentros', N'string', 250, 1, N'Ninguno', 436, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 436, N'supera el maximo permitIdo de caracteres (250)')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (26, N'dueno', N'string', 255, 1, N'Ninguno', 437, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (27, N'Id_depa_externo', N'string', 255, 1, N'Ninguno', 440, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (28, N'Id_Puesto_externo', N'string', 255, 1, N'Ninguno', 441, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (29, N'AcronimoPlanta', N'string', 255, 1, N'Ninguno', 0, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[ResourceValidacionCampo] ([IdReglaValidacion], [Nombre], [TipoDato], [TamanioCampo], [Requerido], [Formato], [CodigoErrorRequerido], [MensajeErrorRequerido], [CodigoErrorFormato], [MensajeErrorFormato]) VALUES (30, N'CuentaUsuario', N'string', 50, 1, N'Ninguno', 413, N'es Requerido, esta vacio o el valor es null, por favor ingrese información', 430, N'supera el maximo permitIdo de caracteres (250)')
SET IDENTITY_INSERT [dbo].[ResourceValidacionCampo] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoAcceso] ON 

INSERT [dbo].[TipoAcceso] ([IdTipoAcceso], [DescTipoAcceso]) VALUES (1, N'UsuarioUnico')
INSERT [dbo].[TipoAcceso] ([IdTipoAcceso], [DescTipoAcceso]) VALUES (2, N'UsuarioMultiple')
INSERT [dbo].[TipoAcceso] ([IdTipoAcceso], [DescTipoAcceso]) VALUES (3, N'MaquinaMultiple')
SET IDENTITY_INSERT [dbo].[TipoAcceso] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([Id], [Descripcion], [TipoDocumento]) VALUES (1, N'Tipo Predeterminado para Media', N'CVDEF')
INSERT [dbo].[TipoDocumento] ([Id], [Descripcion], [TipoDocumento]) VALUES (2, N'Documento Dummy', N'HOE')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPregunta] ON 

INSERT [dbo].[TipoPregunta] ([IdTipoPregunta], [Nombre]) VALUES (1, N'Maquina   ')
INSERT [dbo].[TipoPregunta] ([IdTipoPregunta], [Nombre]) VALUES (2, N'Proceso   ')
INSERT [dbo].[TipoPregunta] ([IdTipoPregunta], [Nombre]) VALUES (3, N'Pieza     ')
SET IDENTITY_INSERT [dbo].[TipoPregunta] OFF
GO
SET IDENTITY_INSERT [dbo].[UnidadNegocio] ON 

INSERT [dbo].[UnidadNegocio] ([IdUnidadNegocio], [IdUnidadNegocioExterno], [DescUnidadNegocio]) VALUES (1, 0, N'AUMA SERVICIOS, S.A. DE C.V.')
SET IDENTITY_INSERT [dbo].[UnidadNegocio] OFF
GO
/****** Object:  Index [UQ__CentroCo__DBD8185BC752D50A]    Script Date: 31/05/2021 10:02:01 a. m. ******/
ALTER TABLE [dbo].[CentroCosto] ADD UNIQUE NONCLUSTERED 
(
	[IdCentroCostoExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D4F2B2A7B]    Script Date: 31/05/2021 10:02:01 a. m. ******/
ALTER TABLE [dbo].[Departamento] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38DD4EA060C]    Script Date: 31/05/2021 10:02:01 a. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel1] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38DA43DCE66]    Script Date: 31/05/2021 10:02:01 a. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel2] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38DB69A1A8B]    Script Date: 31/05/2021 10:02:01 a. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel3] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Puesto__52F767D7736CD6F1]    Script Date: 31/05/2021 10:02:01 a. m. ******/
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
ALTER TABLE [dbo].[Maquina] ADD  CONSTRAINT [DF_Maquina_FabricanteIdFabricante]  DEFAULT ((0)) FOR [FabricanteIdFabricante]
GO
ALTER TABLE [dbo].[Maquina] ADD  CONSTRAINT [DF_Maquina_TipoAccesoIdTipoAcceso]  DEFAULT ((0)) FOR [TipoAccesoIdTipoAcceso]
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
ALTER TABLE [dbo].[ResourceValidacionCampo] ADD  CONSTRAINT [DF_Resource_Validaciones_ampos_Tamanio_Campo]  DEFAULT ((0)) FOR [TamanioCampo]
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
ALTER TABLE [dbo].[MaquinaFisica]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFisicaLineaProduccion_LineaProduccionIdLineaProduccion] FOREIGN KEY([LineaProduccionIdLineaProduccion])
REFERENCES [dbo].[LineaProduccion] ([Id])
GO
ALTER TABLE [dbo].[MaquinaFisica] CHECK CONSTRAINT [FK_MaquinaFisicaLineaProduccion_LineaProduccionIdLineaProduccion]
GO
ALTER TABLE [dbo].[MaquinaFisica]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFisicaMaquina_MaquinaIdMaquina] FOREIGN KEY([MaquinaIdMaquina])
REFERENCES [dbo].[Maquina] ([IdMaquina])
GO
ALTER TABLE [dbo].[MaquinaFisica] CHECK CONSTRAINT [FK_MaquinaFisicaMaquina_MaquinaIdMaquina]
GO
ALTER TABLE [dbo].[MaquinaFisica]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFisicaNave_NaveIdNave] FOREIGN KEY([NaveIdNave])
REFERENCES [dbo].[Nave] ([IdNave])
GO
ALTER TABLE [dbo].[MaquinaFisica] CHECK CONSTRAINT [FK_MaquinaFisicaNave_NaveIdNave]
GO
ALTER TABLE [dbo].[MaquinaFisica]  WITH CHECK ADD  CONSTRAINT [FK_MaquinaFisicaPlanta_PlantaIdPlanta] FOREIGN KEY([PlantaIdPlanta])
REFERENCES [dbo].[Planta] ([IdPlanta])
GO
ALTER TABLE [dbo].[MaquinaFisica] CHECK CONSTRAINT [FK_MaquinaFisicaPlanta_PlantaIdPlanta]
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
ALTER TABLE [dbo].[PreguntaGeneral]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaGeneral_Idioma] FOREIGN KEY([IdiomaIdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[PreguntaGeneral] CHECK CONSTRAINT [FK_PreguntaGeneral_Idioma]
GO
ALTER TABLE [dbo].[PreguntaGeneral]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaGeneral_NivelCertificacion] FOREIGN KEY([NivelCertificacionIdNivelCertificacion])
REFERENCES [dbo].[NivelCertificacion] ([IdNivelCertificacion])
GO
ALTER TABLE [dbo].[PreguntaGeneral] CHECK CONSTRAINT [FK_PreguntaGeneral_NivelCertificacion]
GO
ALTER TABLE [dbo].[PreguntaGeneral]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaGeneral_TipoPregunta] FOREIGN KEY([TipoPreguntaIdTipoPregunta])
REFERENCES [dbo].[TipoPregunta] ([IdTipoPregunta])
GO
ALTER TABLE [dbo].[PreguntaGeneral] CHECK CONSTRAINT [FK_PreguntaGeneral_TipoPregunta]
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
ALTER TABLE [dbo].[PreguntaPieza]  WITH CHECK ADD  CONSTRAINT [Preguntas_Piezas_Piezas_Piezas_Id_Pieza] FOREIGN KEY([ProcesoPiezaMaquinaIdProcesoPiezaMaquina])
REFERENCES [dbo].[ProcesoPiezaMaquina] ([IdProcesoPiezaMaquina])
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
ALTER TABLE [dbo].[PreguntaProceso]  WITH CHECK ADD  CONSTRAINT [Preguntas_Procesos_Procesos_Procesos_Id_Proceso] FOREIGN KEY([MaquinaProcesoIdMaquinaProceso])
REFERENCES [dbo].[MaquinaProceso] ([IdMaquinaProceso])
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
ALTER TABLE [dbo].[ProcesoPiezaMaquina]  WITH CHECK ADD  CONSTRAINT [FK_ProcesoPiezaMaquina_MaquinaProceso] FOREIGN KEY([MaquinaProcesoIdMaquinaProceso])
REFERENCES [dbo].[MaquinaProceso] ([IdMaquinaProceso])
GO
ALTER TABLE [dbo].[ProcesoPiezaMaquina] CHECK CONSTRAINT [FK_ProcesoPiezaMaquina_MaquinaProceso]
GO
ALTER TABLE [dbo].[ProcesoPiezaMaquina]  WITH CHECK ADD  CONSTRAINT [FK_ProcesoPiezaMaquina_Pieza] FOREIGN KEY([PiezaIdPieza])
REFERENCES [dbo].[Pieza] ([IdPieza])
GO
ALTER TABLE [dbo].[ProcesoPiezaMaquina] CHECK CONSTRAINT [FK_ProcesoPiezaMaquina_Pieza]
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
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Pieza] FOREIGN KEY([PiezaIdPieza])
REFERENCES [dbo].[Pieza] ([IdPieza])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Pieza]
GO
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Proceso] FOREIGN KEY([ProcesoIdProceso])
REFERENCES [dbo].[Proceso] ([IdProceso])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Proceso]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "m"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 275
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pm"
            Begin Extent = 
               Top = 0
               Left = 378
               Bottom = 130
               Right = 681
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_MAQUINA_PREGUNTAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_MAQUINA_PREGUNTAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "pc"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 136
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_PIEZA_CLIENTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_PIEZA_CLIENTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[20] 2[34] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "U"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_PIEZAS_MULTIMEDIAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_PIEZAS_MULTIMEDIAS'
GO
USE [master]
GO
ALTER DATABASE [CARTAV] SET  READ_WRITE 
GO
