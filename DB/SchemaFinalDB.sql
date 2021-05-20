USE [master]
GO
/****** Object:  Database [CARTAV]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Pieza]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[PiezaCliente]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[MultiMediaPieza]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  View [dbo].[VW_PIEZAS_MULTIMEDIAS]    Script Date: 20/05/2021 02:38:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Retorna las piezas y sus totales de multimedia*/
CREATE VIEW [dbo].[VW_PIEZAS_MULTIMEDIAS]
AS
SELECT        IdPieza, NumeroParte, Nombre, Descripcion, Activo, SUM(countDoc) AS countDoc, SUM(countVideo) AS countVideo, SUM(countImg) AS countImg, SUM(countClientes) AS countClientes
FROM            (SELECT        p.IdPieza, p.NumeroParte, p.Nombre, p.Descripcion, p.Activo, CASE m.TipoMedia WHEN 'DOC' THEN COUNT(m.TipoMedia) ELSE 0 END AS countDoc, CASE m.TipoMedia WHEN 'VIDEO' THEN COUNT(m.TipoMedia) 
                                                    ELSE 0 END AS countVideo, CASE m.TipoMedia WHEN 'IMG' THEN COUNT(m.TipoMedia) ELSE 0 END AS countImg, COUNT(pc.ClienteIdCliente) AS countClientes
                          FROM            dbo.Pieza AS p LEFT OUTER JOIN
                                                    dbo.MultiMediaPieza AS m ON p.IdPieza = m.IdPieza LEFT OUTER JOIN
                                                    dbo.PiezaCliente AS pc ON pc.PiezaIdPieza = p.IdPieza LEFT OUTER JOIN
                                                    dbo.Cliente AS c ON c.IdCliente = pc.ClienteIdCliente
                          GROUP BY p.IdPieza, p.NumeroParte, p.Nombre, p.Descripcion, p.Activo, m.TipoMedia) AS U
GROUP BY IdPieza, NumeroParte, Nombre, Descripcion, Activo
GO
/****** Object:  View [dbo].[VW_PIEZA_CLIENTE]    Script Date: 20/05/2021 02:38:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_PIEZA_CLIENTE]
AS
SELECT pc.ClienteIdCliente,pc.PiezaIdPieza,c.Nombre,c.Contacto,c.Email,c.Telefono,pc.Activo FROM PiezaCliente pc LEFT JOIN Cliente C ON PC.ClienteIdCliente=c.IdCliente

GO
/****** Object:  Table [dbo].[MaquinaProceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaquinaProceso](
	[IdMaquinaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[MaquinaIdMaquina] [bigint] NOT NULL,
	[ProcesoIdProceso] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_MaquinaProceso] PRIMARY KEY CLUSTERED 
(
	[IdMaquinaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaMaquina]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Maquina]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  View [dbo].[VW_MAQUINA_PREGUNTAS]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[CentroCosto]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Certificacion]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Departamento]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[DepartamentoNivel1]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[DepartamentoNivel2]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[DepartamentoNivel3]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[DocumentoPiezaProceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Fabricante]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[LineaProduccion]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[MaquinaFisica]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Nave]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[NivelCertificacion]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Operacion]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Perfil]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[PerfilOperacionPermiso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Planta]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[PreguntaMaquinaGeneral]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[PreguntaPieza]    Script Date: 20/05/2021 02:38:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaPieza](
	[IdPreguntaPieza] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[PiezaIdPieza] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__4F0326314772454F] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPiezaGeneral]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
 CONSTRAINT [PK__Pregunta__4F03263192CFAEDE] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaPieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaProceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaProceso](
	[IdPreguntaProceso] [bigint] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
	[Respuesta] [varchar](max) NULL,
	[Orden] [int] NOT NULL,
	[ProcesoIdProceso] [bigint] NOT NULL,
	[IdiomaIdIdioma] [bigint] NOT NULL,
	[NivelCertificacionIdNivelCertificacion] [bigint] NOT NULL,
 CONSTRAINT [PK__Pregunta__2637C0FB04D15390] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaProcesoGeneral]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
 CONSTRAINT [PK__Pregunta__2637C0FB3AF97B58] PRIMARY KEY CLUSTERED 
(
	[IdPreguntaProceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaPtGeneral]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Proceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[ProcesoPiezaMaquina]    Script Date: 20/05/2021 02:38:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcesoPiezaMaquina](
	[PiezaIdPieza] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessLog]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[Puesto]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[ResourceValidacionCampo]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[RespuestaMaquina]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[RespuestaPieza]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[RespuestaProceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[ResultadoMaquina]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[ResultadoPieza]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[ResultadoProceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[TipoAcceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[UnidadNegocio]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
/****** Object:  Table [dbo].[VideoPiezaProceso]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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

SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (1, N'558573', N'OMARIN', N'ALVAREZ', N'ALCANT', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'asdsadsad@asdsad.com', N'558573', 1, NULL, NULL, NULL, 1, 1, 1, 1, 2, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (2, N'558574', N'JOSE', N'ALVAREZ', N'ALCANT', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'correo@asdsad.com', N'558574', 1, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (3, N'558575', N'SERGIO', N'ALVAREZ', N'ALCANT', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'asdsadsad@asdsad.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 2, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (4, N'558576', N'ANTONIO', N'ALVAREZ', N'ALCANT', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'asdsadsad@asdsad.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 2, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (5, N'558577', N'ANDRÉS', N'ALVAREZ', N'ALCANT', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'asdsadsad@asdsad.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 2, 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [NumeroNomina], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [FechaIngreso], [Email], [NominaJefe], [DepartamentoIdDepartamentoNivel0], [DepartamentoIdDepartamentoNivel1], [DepartamentoIdDepartamentoNivel2], [DepartamentoIdDepartamentoNivel3], [IdiomaIdIdioma], [PuestoIdPuesto], [UnidadNegocioIdUnidadNegocio], [CentroCostoIdCentroCosto], [IdPerfil], [Activo]) VALUES (6, N'558578', N'IVÁN', N'ALVAREZ', N'ALCANT', CAST(N'1983-01-12' AS Date), CAST(N'2020-01-02' AS Date), N'asdsadsad@asdsad.com', N'17441', 1, NULL, NULL, NULL, 1, 1, 1, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Fabricante] ON 

INSERT [dbo].[Fabricante] ([IdFabricante], [Nombre], [Contacto], [Email], [Telefono], [Activo]) VALUES (1, N'N/A', N'N/A', N'N/A', N'N/A', 1)
INSERT [dbo].[Fabricante] ([IdFabricante], [Nombre], [Contacto], [Email], [Telefono], [Activo]) VALUES (2, N'Siemens', N'Pedro Fernández', N'pedro.fernadez@siemens.com', N'+52 5555555', 1)
INSERT [dbo].[Fabricante] ([IdFabricante], [Nombre], [Contacto], [Email], [Telefono], [Activo]) VALUES (3, N'GE', N'Alfredo Martínez', N'alfredo.martinez@ge.com', N'+52 5555556', 1)
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
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (2, 1, 2, 1, 0, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (3, 1, 3, 0, 0, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (4, 1, 4, 0, 0, 1, 1)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (5, 1, 5, 0, 0, 1, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (6, 1, 6, 0, 0, 1, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (7, 1, 7, 0, 0, 1, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (8, 1, 8, 0, 0, 1, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (9, 1, 9, 0, 0, 1, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (10, 1, 10, 0, 1, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (11, 1, 11, 0, 1, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (12, 1, 12, 0, 1, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (13, 1, 13, 0, 1, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (14, 1, 14, 0, 1, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (15, 1, 15, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (16, 1, 16, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (17, 1, 17, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (18, 1, 18, 0, 0, 0, 0)
INSERT [dbo].[PerfilOperacionPermiso] ([Id], [IdPerfil], [IdOperacion], [Crear], [Editar], [Eliminar], [Ver]) VALUES (19, 1, 19, 0, 0, 0, 0)
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
/****** Object:  Index [UQ__CentroCo__DBD8185B41179BFB]    Script Date: 20/05/2021 02:38:47 p. m. ******/
ALTER TABLE [dbo].[CentroCosto] ADD UNIQUE NONCLUSTERED 
(
	[IdCentroCostoExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D40133BBB]    Script Date: 20/05/2021 02:38:47 p. m. ******/
ALTER TABLE [dbo].[Departamento] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D5459DE6D]    Script Date: 20/05/2021 02:38:47 p. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel1] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D6C122861]    Script Date: 20/05/2021 02:38:47 p. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel2] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__C342F38D3E2A2EBC]    Script Date: 20/05/2021 02:38:47 p. m. ******/
ALTER TABLE [dbo].[DepartamentoNivel3] ADD UNIQUE NONCLUSTERED 
(
	[IdDepartamentExterno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Puesto__52F767D779B89C5F]    Script Date: 20/05/2021 02:38:47 p. m. ******/
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
               Right = 224
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
