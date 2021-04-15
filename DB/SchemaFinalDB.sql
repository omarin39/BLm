USE [master]
GO
/****** Object:  Database [Carta_v]    Script Date: 15/04/2021 12:30:22 p. m. ******/
CREATE DATABASE [Carta_v]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Carta_v', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLOMARIN\MSSQL\DATA\Carta_v.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Carta_v_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLOMARIN\MSSQL\DATA\Carta_v_log.ldf' , SIZE = 335872KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Carta_v] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Carta_v].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Carta_v] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Carta_v] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Carta_v] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Carta_v] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Carta_v] SET ARITHABORT OFF 
GO
ALTER DATABASE [Carta_v] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Carta_v] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Carta_v] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Carta_v] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Carta_v] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Carta_v] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Carta_v] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Carta_v] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Carta_v] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Carta_v] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Carta_v] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Carta_v] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Carta_v] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Carta_v] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Carta_v] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Carta_v] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Carta_v] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Carta_v] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Carta_v] SET  MULTI_USER 
GO
ALTER DATABASE [Carta_v] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Carta_v] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Carta_v] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Carta_v] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Carta_v] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Carta_v] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Carta_v] SET QUERY_STORE = OFF
GO
USE [Carta_v]
GO
/****** Object:  Table [dbo].[Centro_costo]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centro_costo](
	[id_centro_costo] [bigint] IDENTITY(1,1) NOT NULL,
	[id_centro_costo_ext] [bigint] NOT NULL,
	[desc_centro_costo] [varchar](max) NOT NULL,
	[dueno_ceco] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_centro_costo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificaciones]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificaciones](
	[id_certificacion] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha_entrenamiento] [datetime] NOT NULL,
	[fecha_certificacion] [datetime] NULL,
	[id_certificador] [bigint] NULL,
	[token_certificador] [varchar](max) NULL,
	[fecha_certificador] [datetime] NULL,
	[id_mentor] [bigint] NULL,
	[token_mentor] [varchar](max) NULL,
	[fecha_mentor] [datetime] NULL,
	[id_responsable] [bigint] NULL,
	[token_responsable] [varchar](max) NULL,
	[fecha_responsable] [datetime] NULL,
	[resultado] [float] NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_certificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[contacto] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[telefono] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[id_departamento] [bigint] IDENTITY(1,1) NOT NULL,
	[id_departament_ext] [bigint] NOT NULL,
	[departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento_nivel1]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento_nivel1](
	[id_departamento_nivel1] [bigint] IDENTITY(1,1) NOT NULL,
	[id_departamento] [bigint] NOT NULL,
	[id_departament_ext] [bigint] NOT NULL,
	[departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_departamento_nivel1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento_nivel2]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento_nivel2](
	[id_departamento_nivel2] [bigint] IDENTITY(1,1) NOT NULL,
	[id_departamento] [bigint] NOT NULL,
	[id_departamento_nivel1] [bigint] NOT NULL,
	[id_departament_ext] [bigint] NOT NULL,
	[departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_departamento_nivel2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento_nivel3]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento_nivel3](
	[id_departamento_nivel3] [bigint] IDENTITY(1,1) NOT NULL,
	[id_departamento] [bigint] NOT NULL,
	[id_departamento_nivel2] [bigint] NOT NULL,
	[id_departament_ext] [bigint] NOT NULL,
	[departamento] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_departamento_nivel3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentos_pieza_proceso]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentos_pieza_proceso](
	[id_documento_pieza_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[url] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_documento_pieza_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[id_empleado] [bigint] IDENTITY(1,1) NOT NULL,
	[n_nomina] [varchar](max) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[apellido_paterno] [varchar](max) NOT NULL,
	[apellido_materno] [varchar](max) NULL,
	[f_nacimiento] [date] NOT NULL,
	[f_ingreso] [date] NOT NULL,
	[email] [varchar](max) NOT NULL,
	[nomina_jefe] [varchar](max) NOT NULL,
	[Departamento_id_departamento_nivel0] [bigint] NOT NULL,
	[Departamento_id_departamento_nivel1] [bigint] NULL,
	[Departamento_id_departamento_nivel2] [bigint] NULL,
	[Departamento_id_departamento_nivel3] [bigint] NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[Puestos_id_puesto] [bigint] NOT NULL,
	[Unidad_negocio_id_unidad_negocio] [bigint] NOT NULL,
	[Centro_costo_id_centro_costo] [bigint] NOT NULL,
	[Id_Perfil] [bigint] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fabricante]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fabricante](
	[id_fabricante] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[contacto] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[telefono] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_fabricante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[id_idioma] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo_Idioma] [varchar](10) NOT NULL,
	[idioma] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Idioma__0BA1525F05C8D52A] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquinas]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquinas](
	[id_maquina] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[modelo] [varchar](max) NOT NULL,
	[maquina_pt] [bit] NOT NULL,
	[cantidad_acceso_multiple] [int] NOT NULL,
	[Fabricante_id_fabricante] [bigint] NOT NULL,
	[Tipo_acceso_id_tipo_acceso] [bigint] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Maquinas__9A2F321BE6366944] PRIMARY KEY CLUSTERED 
(
	[id_maquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Máquinas_fisicas]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Máquinas_fisicas](
	[id_maquina_fisica] [bigint] IDENTITY(1,1) NOT NULL,
	[n_serie] [varchar](max) NOT NULL,
	[ubicacion] [varchar](max) NULL,
	[Maquinas_id_maquina] [bigint] NOT NULL,
	[Naves_id_nave] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Máquinas__5BE456CBA6BE8746] PRIMARY KEY CLUSTERED 
(
	[id_maquina_fisica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maquinas_procesos]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maquinas_procesos](
	[Maquinas_id_maquina] [bigint] IDENTITY(1,1) NOT NULL,
	[Procesos_id_proceso] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre_Menu] [nvarchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Naves]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Naves](
	[id_nave] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[Plantas_id_planta] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Naves__35A7535AAB30ED73] PRIMARY KEY CLUSTERED 
(
	[id_nave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Niveles_certificacion]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Niveles_certificacion](
	[id_nivel_certificacion] [bigint] IDENTITY(1,1) NOT NULL,
	[desc_nivel_certificacion] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_nivel_certificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Operacion] [nvarchar](max) NOT NULL,
	[Nombre_Menu] [nvarchar](50) NOT NULL,
	[Nombre_Pagina] [nvarchar](50) NOT NULL,
	[Id_Menu] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Operaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil_Operacion_Permiso]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil_Operacion_Permiso](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Perfil] [bigint] NOT NULL,
	[Id_Operacion] [bigint] NOT NULL,
	[Crear] [bit] NOT NULL,
	[Editar] [bit] NOT NULL,
	[Eliminar] [bit] NOT NULL,
	[Ver] [bit] NOT NULL,
 CONSTRAINT [PK_Perfil_Operacion_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Perfil] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Piezas]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Piezas](
	[id_pieza] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[descripción] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Piezas_Clientes]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Piezas_Clientes](
	[Clientes_id_cliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Piezas_id_pieza] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plantas]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plantas](
	[id_planta] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Planta_Ext] [bigint] NULL,
	[acronimo] [varchar](max) NOT NULL,
	[planta] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Plantas__4096680B551E7DE9] PRIMARY KEY CLUSTERED 
(
	[id_planta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_maquina]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_maquina](
	[id_pregunta_maquina] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [int] NOT NULL,
	[Maquinas_id_maquina] [bigint] NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pregunta_maquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_maquina_generales]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_maquina_generales](
	[id_pregunta_maquina] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [varchar](max) NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Pregunta__31ABB522E63257E4] PRIMARY KEY CLUSTERED 
(
	[id_pregunta_maquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_piezas]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_piezas](
	[id_pregunta_pieza] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [int] NOT NULL,
	[Piezas_id_pieza] [bigint] NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pregunta_pieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_piezas_generales]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_piezas_generales](
	[id_pregunta_pieza] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [int] NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pregunta_pieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_procesos]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_procesos](
	[id_pregunta_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [int] NOT NULL,
	[Procesos_id_proceso] [bigint] NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pregunta_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_procesos_generales]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_procesos_generales](
	[id_pregunta_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [bigint] NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pregunta_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas_pt_generales]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas_pt_generales](
	[id_pregunta_pt] [bigint] IDENTITY(1,1) NOT NULL,
	[pregunta] [varchar](max) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[orden] [int] NOT NULL,
	[idioma_id_idioma] [bigint] NOT NULL,
	[niveles_certificacion_id_nivel_certificacion] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pregunta_pt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Procesos]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procesos](
	[id_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Procesos_piezas_maquinas]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procesos_piezas_maquinas](
	[Piezas_id_pieza] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessLog]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessLog](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[IP] [nvarchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Respuesta] [nvarchar](max) NOT NULL,
	[Codigo] [bigint] NOT NULL,
 CONSTRAINT [PK_ProcessLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[id_puesto] [bigint] IDENTITY(1,1) NOT NULL,
	[id_puesto_ext] [bigint] NOT NULL,
	[desc_puesto] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource_validaciones_campos]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource_validaciones_campos](
	[Id_Regla_validacion] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Tipo_dato] [nvarchar](50) NOT NULL,
	[Tamaño_campo] [int] NOT NULL,
	[Requerido] [bit] NULL,
	[Formato] [nvarchar](50) NULL,
	[Codigo_error_requerido] [int] NULL,
	[Mensaje_error_requerido] [nvarchar](max) NULL,
	[Codigo_error_formato] [int] NULL,
	[Mensaje_error_formato] [nvarchar](max) NULL,
 CONSTRAINT [PK_Validaciones_Resource] PRIMARY KEY CLUSTERED 
(
	[Id_Regla_validacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas_maquina]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas_maquina](
	[id_respuesta_maquina] [bigint] IDENTITY(1,1) NOT NULL,
	[respuesta] [varchar](max) NULL,
	[resultado] [float] NOT NULL,
	[resultados_maquina_id_resultado_máquina] [bigint] NOT NULL,
	[Preguntas_maquina_id_pregunta_maquina] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_respuesta_maquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas_pieza]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas_pieza](
	[id_resultado_pieza] [bigint] IDENTITY(1,1) NOT NULL,
	[respuesta] [varchar](max) NULL,
	[resultado] [float] NOT NULL,
	[Resultados_pieza_id_resultado_pieza] [bigint] NOT NULL,
	[Preguntas_piezas_id_pregunta_pieza] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_resultado_pieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas_proceso]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas_proceso](
	[id_respuesta_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[respuesta] [varchar](max) NOT NULL,
	[resultado] [float] NOT NULL,
	[Resultados_proceso_id_resultado_proceso] [bigint] NOT NULL,
	[Preguntas_procesos_id_pregunta_proceso] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_respuesta_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resultados_maquina]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resultados_maquina](
	[id_resultado_máquina] [bigint] IDENTITY(1,1) NOT NULL,
	[resultado] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_resultado_máquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resultados_pieza]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resultados_pieza](
	[id_resultado_pieza] [bigint] IDENTITY(1,1) NOT NULL,
	[resultado] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_resultado_pieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resultados_proceso]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resultados_proceso](
	[id_resultado_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[resultado] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_resultado_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_acceso]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_acceso](
	[id_tipo_acceso] [bigint] IDENTITY(1,1) NOT NULL,
	[desc_tipo_acceso] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_acceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidad_negocio]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad_negocio](
	[id_unidad_negocio] [bigint] IDENTITY(1,1) NOT NULL,
	[id_unidad_negocio_ext] [bigint] NOT NULL,
	[desc_unidad_negocio] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_unidad_negocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videos_pieza_proceso]    Script Date: 15/04/2021 12:30:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos_pieza_proceso](
	[id_video_pieza_proceso] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[url] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_video_pieza_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([id_idioma], [Codigo_Idioma], [idioma], [Activo]) VALUES (1, N'es-MX', N'Español (México)', 1)
INSERT [dbo].[Idioma] ([id_idioma], [Codigo_Idioma], [idioma], [Activo]) VALUES (2, N'es-ES', N'Español (España)', 1)
INSERT [dbo].[Idioma] ([id_idioma], [Codigo_Idioma], [idioma], [Activo]) VALUES (3, N'en-US', N'English', 1)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [Nombre_Menu], [Activo]) VALUES (1, N'Administracion', 1)
INSERT [dbo].[Menu] ([Id], [Nombre_Menu], [Activo]) VALUES (2, N'Empleados', 1)
INSERT [dbo].[Menu] ([Id], [Nombre_Menu], [Activo]) VALUES (3, N'CartaVersatilidad', 1)
INSERT [dbo].[Menu] ([Id], [Nombre_Menu], [Activo]) VALUES (4, N'NecesidadesCertificacion', 1)
INSERT [dbo].[Menu] ([Id], [Nombre_Menu], [Activo]) VALUES (5, N'Reportes', 1)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO

SET IDENTITY_INSERT [dbo].[Operaciones] ON 

INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (1, N'MaquinasPTrabajo', N'MaquinasPTrabajo', N'MaquinasPTrabajo', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (2, N'Procesos', N'Procesos', N'Procesos', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (3, N'Piezas', N'Piezas', N'Piezas', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (4, N'Clientes', N'Clientes', N'Clientes', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (5, N'MaquinasPTFisicas', N'MaquinasPTFisicas', N'MaquinasPTFisicas', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (6, N'Plantas', N'Plantas', N'Plantas', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (7, N'Permisos', N'Permisos', N'AdmPermisos', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (8, N'Perfiles', N'Perfiles', N'AdmPerfiles', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (9, N'Fabricantes', N'Fabricantes', N'Fabricantes', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (10, N'NivelesCertificacion', N'NivelesCertificacion', N'NivelesCertificacion', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (11, N'PreguntasGrales', N'PreguntasGrales', N'PreguntasGrales', 1, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (12, N'Certificaciones', N'Certificaciones', N'Certificaciones', 2, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (13, N'NecesidadesCertifica', N'NecesidadesCertifica', N'NecesidadesCertifica', 2, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (14, N'Examenes', N'Examenes', N'Examenes', 2, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (15, N'EmpPerfiles', N'EmpPerfiles', N'EmpPerfiles', 2, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (16, N'AsignaCapacita', N'AsignaCapacita', N'AsignaCapacita', 2, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (17, N'FirmasPendientes', N'FirmasPendientes', N'FirmasPendientes', 2, 1)
INSERT [dbo].[Operaciones] ([Id], [Operacion], [Nombre_Menu], [Nombre_Pagina], [Id_Menu], [Activo]) VALUES (18, N'CapacitacionesCaduca', N'CapacitacionesCaduca', N'CapacitacionesCaduca', 2, 1)
SET IDENTITY_INSERT [dbo].[Operaciones] OFF
GO

SET IDENTITY_INSERT [dbo].[Resource_validaciones_campos] ON 

INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (1, N'noNomina', N'int', 100, 1, N'Ninguno', 412, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 429, N'supera el maximo permitido de caracteres (10)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (2, N'nombre', N'string', 250, 1, N'Ninguno', 413, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 430, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (3, N'apellidoPaterno', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 414, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (4, N'apellidoMaterno', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 415, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (5, N'fechaNacimiento', N'date', 10, 1, N'Y/m/d', 416, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 410, N'no cumple con el formato de fechas (yyyy/mm/dd)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (6, N'fechaIngreso', N'date', 10, 0, N'Y/m/d', 417, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 411, N'no cumple con el formato de fechas aaaa/mm/dd')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (7, N'email', N'email', 250, 0, N'Ninguno', 418, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 423, N'no contiene un @ o no cumple con el formato de email (usuario@dominio.com)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (8, N'idPlanta', N'int', 10, 1, N'Ninguno', 442, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 443, N'supera el maximo permitido de caracteres (10)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (9, N'planta', N'string', 250, 1, N'Ninguno', 419, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 424, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (10, N'idDepartamento', N'int', 10, 1, N'Ninguno', 444, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 445, N'supera el maximo permitido de caracteres (10)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (11, N'departamento', N'string', 250, 1, N'Ninguno', 420, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 425, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (12, N'idDepNivel1', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (13, N'DepNivel1', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (14, N'idDepNivel2', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (15, N'DepNivel2', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (16, N'idDepNivel3', N'int', 10, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (17, N'DepNivel3', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (18, N'idPuesto', N'int', 10, 1, N'Ninguno', 446, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 447, N'supera el maximo permitido de caracteres (10)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (19, N'puesto', N'string', 250, 1, N'Ninguno', 421, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 426, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (20, N'nominaJefe', N'string', 250, 0, N'Ninguno', 0, N'Ninguno', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (21, N'idUnidad', N'int', 10, 1, N'Ninguno', 448, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 449, N'supera el maximo permitido de caracteres (10)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (22, N'unidad', N'string', 250, 1, N'Ninguno', 431, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 432, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (23, N'idCeCo', N'int', 10, 1, N'Ninguno', 450, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 451, N'supera el maximo permitido de caracteres (10)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (24, N'CeCo', N'string', 250, 1, N'Ninguno', 433, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 434, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (25, N'NoCentros', N'string', 250, 1, N'Ninguno', 436, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 436, N'supera el maximo permitido de caracteres (250)')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (26, N'dueno', N'string', 255, 1, N'Ninguno', 437, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (27, N'id_depa_externo', N'string', 255, 1, N'Ninguno', 440, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
INSERT [dbo].[Resource_validaciones_campos] ([Id_Regla_validacion], [Nombre], [Tipo_dato], [Tamaño_campo], [Requerido], [Formato], [Codigo_error_requerido], [Mensaje_error_requerido], [Codigo_error_formato], [Mensaje_error_formato]) VALUES (28, N'id_puesto_externo', N'string', 255, 1, N'Ninguno', 441, N'es requerido, esta vacio o el valor es null, por favor ingrese información', 0, N'Ninguno')
SET IDENTITY_INSERT [dbo].[Resource_validaciones_campos] OFF
GO
/****** Object:  Index [UQ__Centro_c__758708068C83546B]    Script Date: 15/04/2021 12:30:23 p. m. ******/
ALTER TABLE [dbo].[Centro_costo] ADD UNIQUE NONCLUSTERED 
(
	[id_centro_costo_ext] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__E1680BCFE536ACDE]    Script Date: 15/04/2021 12:30:23 p. m. ******/
ALTER TABLE [dbo].[Departamento] ADD UNIQUE NONCLUSTERED 
(
	[id_departament_ext] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__E1680BCFE8A970D8]    Script Date: 15/04/2021 12:30:23 p. m. ******/
ALTER TABLE [dbo].[Departamento_nivel1] ADD UNIQUE NONCLUSTERED 
(
	[id_departament_ext] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__E1680BCFED9D53DB]    Script Date: 15/04/2021 12:30:23 p. m. ******/
ALTER TABLE [dbo].[Departamento_nivel2] ADD UNIQUE NONCLUSTERED 
(
	[id_departament_ext] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Departam__E1680BCF543F7D94]    Script Date: 15/04/2021 12:30:23 p. m. ******/
ALTER TABLE [dbo].[Departamento_nivel3] ADD UNIQUE NONCLUSTERED 
(
	[id_departament_ext] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Puestos__7CA8668D072791DB]    Script Date: 15/04/2021 12:30:23 p. m. ******/
ALTER TABLE [dbo].[Puestos] ADD UNIQUE NONCLUSTERED 
(
	[id_puesto_ext] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Centro_costo] ADD  CONSTRAINT [DF_Centro_costo_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Certificaciones] ADD  CONSTRAINT [DF_Certificaciones_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Estatus]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Departamento] ADD  CONSTRAINT [DF_Departamento_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Departamento_nivel1] ADD  CONSTRAINT [DF_Departamento_nivel1_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Departamento_nivel2] ADD  CONSTRAINT [DF_Departamento_nivel2_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Departamento_nivel3] ADD  CONSTRAINT [DF_Departamento_nivel3_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Documentos_pieza_proceso] ADD  CONSTRAINT [DF_Documentos_pieza_proceso_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [DF_Empleados_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Fabricante] ADD  CONSTRAINT [DF_Fabricante_Estado]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Idioma] ADD  CONSTRAINT [DF_Idioma_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Maquinas] ADD  CONSTRAINT [DF_Maquinas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Maquinas_procesos] ADD  CONSTRAINT [DF_Maquinas_procesos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Naves] ADD  CONSTRAINT [DF_Naves_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Niveles_certificacion] ADD  CONSTRAINT [DF_Niveles_certificacion_Estado]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso] ADD  CONSTRAINT [DF_Perfil_Operacion_Permiso_Crear]  DEFAULT ((0)) FOR [Crear]
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso] ADD  CONSTRAINT [DF_Perfil_Operacion_Permiso_Editar]  DEFAULT ((0)) FOR [Editar]
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso] ADD  CONSTRAINT [DF_Perfil_Operacion_Permiso_Eliminar]  DEFAULT ((0)) FOR [Eliminar]
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso] ADD  CONSTRAINT [DF_Perfil_Operacion_Permiso_Ver]  DEFAULT ((1)) FOR [Ver]
GO
ALTER TABLE [dbo].[Piezas] ADD  CONSTRAINT [DF_Piezas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Piezas_Clientes] ADD  CONSTRAINT [DF_Piezas_Clientes_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Plantas] ADD  CONSTRAINT [DF_Plantas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Preguntas_maquina] ADD  CONSTRAINT [DF_Preguntas_maquina_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Preguntas_maquina_generales] ADD  CONSTRAINT [DF_Preguntas_maquina_generales_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Preguntas_piezas] ADD  CONSTRAINT [DF_Preguntas_piezas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Procesos] ADD  CONSTRAINT [DF_Procesos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Puestos] ADD  CONSTRAINT [DF_Puestos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Resource_validaciones_campos] ADD  CONSTRAINT [DF_Resource_validaciones_ampos_Tipo_dato]  DEFAULT (N'string') FOR [Tipo_dato]
GO
ALTER TABLE [dbo].[Resource_validaciones_campos] ADD  CONSTRAINT [DF_Resource_validaciones_ampos_Tamaño_campo]  DEFAULT ((0)) FOR [Tamaño_campo]
GO
ALTER TABLE [dbo].[Resource_validaciones_campos] ADD  CONSTRAINT [DF_Table_1_requerido]  DEFAULT ((0)) FOR [Requerido]
GO
ALTER TABLE [dbo].[Resource_validaciones_campos] ADD  CONSTRAINT [DF_Resource_validaciones_campos_Formato]  DEFAULT (N'Ninguno') FOR [Formato]
GO
ALTER TABLE [dbo].[Resource_validaciones_campos] ADD  CONSTRAINT [DF_Resource_validaciones_campos_Codigo_error_requerido]  DEFAULT ((0)) FOR [Codigo_error_requerido]
GO
ALTER TABLE [dbo].[Departamento_nivel1]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_nivel1_Departamento] FOREIGN KEY([id_departamento])
REFERENCES [dbo].[Departamento] ([id_departamento])
GO
ALTER TABLE [dbo].[Departamento_nivel1] CHECK CONSTRAINT [FK_Departamento_nivel1_Departamento]
GO
ALTER TABLE [dbo].[Departamento_nivel2]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_nivel2_Departamento_nivel1] FOREIGN KEY([id_departamento_nivel1])
REFERENCES [dbo].[Departamento_nivel1] ([id_departamento_nivel1])
GO
ALTER TABLE [dbo].[Departamento_nivel2] CHECK CONSTRAINT [FK_Departamento_nivel2_Departamento_nivel1]
GO
ALTER TABLE [dbo].[Departamento_nivel3]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_nivel3_Departamento_nivel2] FOREIGN KEY([id_departamento_nivel2])
REFERENCES [dbo].[Departamento_nivel2] ([id_departamento_nivel2])
GO
ALTER TABLE [dbo].[Departamento_nivel3] CHECK CONSTRAINT [FK_Departamento_nivel3_Departamento_nivel2]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_centro_costo_centro_costo_id_centro_costo] FOREIGN KEY([Centro_costo_id_centro_costo])
REFERENCES [dbo].[Centro_costo] ([id_centro_costo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_centro_costo_centro_costo_id_centro_costo]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel0] FOREIGN KEY([Departamento_id_departamento_nivel0])
REFERENCES [dbo].[Departamento] ([id_departamento])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel0]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel1] FOREIGN KEY([Departamento_id_departamento_nivel1])
REFERENCES [dbo].[Departamento_nivel1] ([id_departamento_nivel1])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel1]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel2] FOREIGN KEY([Departamento_id_departamento_nivel2])
REFERENCES [dbo].[Departamento_nivel2] ([id_departamento_nivel2])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel2]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel3] FOREIGN KEY([Departamento_id_departamento_nivel3])
REFERENCES [dbo].[Departamento_nivel3] ([id_departamento_nivel3])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_departamento_departamento_id_departamento_nivel3]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_mpleados_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_mpleados_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_puestos_puestos_id_puesto] FOREIGN KEY([Puestos_id_puesto])
REFERENCES [dbo].[Puestos] ([id_puesto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_puestos_puestos_id_puesto]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [empleados_unidad_negocio_unidad_negocio_id_unidad_negocio] FOREIGN KEY([Unidad_negocio_id_unidad_negocio])
REFERENCES [dbo].[Unidad_negocio] ([id_unidad_negocio])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [empleados_unidad_negocio_unidad_negocio_id_unidad_negocio]
GO
ALTER TABLE [dbo].[Maquinas]  WITH CHECK ADD  CONSTRAINT [maquinas_fabricante_fabricante_id_fabricante] FOREIGN KEY([Fabricante_id_fabricante])
REFERENCES [dbo].[Fabricante] ([id_fabricante])
GO
ALTER TABLE [dbo].[Maquinas] CHECK CONSTRAINT [maquinas_fabricante_fabricante_id_fabricante]
GO
ALTER TABLE [dbo].[Maquinas]  WITH CHECK ADD  CONSTRAINT [maquinas_tipo_acceso_tipo_acceso_id_tipo_acceso] FOREIGN KEY([Tipo_acceso_id_tipo_acceso])
REFERENCES [dbo].[Tipo_acceso] ([id_tipo_acceso])
GO
ALTER TABLE [dbo].[Maquinas] CHECK CONSTRAINT [maquinas_tipo_acceso_tipo_acceso_id_tipo_acceso]
GO
ALTER TABLE [dbo].[Máquinas_fisicas]  WITH CHECK ADD  CONSTRAINT [máquinas_fisicas_maquinas_maquinas_id_maquina] FOREIGN KEY([Maquinas_id_maquina])
REFERENCES [dbo].[Maquinas] ([id_maquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Máquinas_fisicas] CHECK CONSTRAINT [máquinas_fisicas_maquinas_maquinas_id_maquina]
GO
ALTER TABLE [dbo].[Máquinas_fisicas]  WITH CHECK ADD  CONSTRAINT [máquinas_fisicas_naves_naves_id_nave] FOREIGN KEY([Naves_id_nave])
REFERENCES [dbo].[Naves] ([id_nave])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Máquinas_fisicas] CHECK CONSTRAINT [máquinas_fisicas_naves_naves_id_nave]
GO
ALTER TABLE [dbo].[Maquinas_procesos]  WITH CHECK ADD  CONSTRAINT [maquinas_procesos_procesos_procesos_id_proceso] FOREIGN KEY([Procesos_id_proceso])
REFERENCES [dbo].[Procesos] ([id_proceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Maquinas_procesos] CHECK CONSTRAINT [maquinas_procesos_procesos_procesos_id_proceso]
GO
ALTER TABLE [dbo].[Naves]  WITH CHECK ADD  CONSTRAINT [naves_plantas_plantas_id_planta] FOREIGN KEY([Plantas_id_planta])
REFERENCES [dbo].[Plantas] ([id_planta])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Naves] CHECK CONSTRAINT [naves_plantas_plantas_id_planta]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Menu] FOREIGN KEY([Id_Menu])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Menu]
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Operacion_Permiso_Operacion] FOREIGN KEY([Id_Operacion])
REFERENCES [dbo].[Operaciones] ([Id])
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso] CHECK CONSTRAINT [FK_Perfil_Operacion_Permiso_Operacion]
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Operacion_Permiso_Perfiles] FOREIGN KEY([Id_Perfil])
REFERENCES [dbo].[Perfiles] ([Id])
GO
ALTER TABLE [dbo].[Perfil_Operacion_Permiso] CHECK CONSTRAINT [FK_Perfil_Operacion_Permiso_Perfiles]
GO
ALTER TABLE [dbo].[Piezas_Clientes]  WITH CHECK ADD  CONSTRAINT [piezas_clientes_piezas_piezas_id_pieza] FOREIGN KEY([Piezas_id_pieza])
REFERENCES [dbo].[Piezas] ([id_pieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Piezas_Clientes] CHECK CONSTRAINT [piezas_clientes_piezas_piezas_id_pieza]
GO
ALTER TABLE [dbo].[Preguntas_maquina]  WITH CHECK ADD  CONSTRAINT [preguntas_maquina_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_maquina] CHECK CONSTRAINT [preguntas_maquina_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_maquina]  WITH CHECK ADD  CONSTRAINT [preguntas_maquina_maquinas_maquinas_id_maquina] FOREIGN KEY([Maquinas_id_maquina])
REFERENCES [dbo].[Maquinas] ([id_maquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_maquina] CHECK CONSTRAINT [preguntas_maquina_maquinas_maquinas_id_maquina]
GO
ALTER TABLE [dbo].[Preguntas_maquina]  WITH CHECK ADD  CONSTRAINT [preguntas_maquina_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_maquina] CHECK CONSTRAINT [preguntas_maquina_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Preguntas_maquina_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_maquina_generales_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_maquina_generales] CHECK CONSTRAINT [preguntas_maquina_generales_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_maquina_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_maquina_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_maquina_generales] CHECK CONSTRAINT [preguntas_maquina_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Preguntas_piezas]  WITH CHECK ADD  CONSTRAINT [preguntas_piezas_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_piezas] CHECK CONSTRAINT [preguntas_piezas_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_piezas]  WITH CHECK ADD  CONSTRAINT [preguntas_piezas_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_piezas] CHECK CONSTRAINT [preguntas_piezas_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Preguntas_piezas]  WITH CHECK ADD  CONSTRAINT [preguntas_piezas_piezas_piezas_id_pieza] FOREIGN KEY([Piezas_id_pieza])
REFERENCES [dbo].[Piezas] ([id_pieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_piezas] CHECK CONSTRAINT [preguntas_piezas_piezas_piezas_id_pieza]
GO
ALTER TABLE [dbo].[Preguntas_piezas_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_piezas_generales_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_piezas_generales] CHECK CONSTRAINT [preguntas_piezas_generales_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_piezas_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_piezas_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_piezas_generales] CHECK CONSTRAINT [preguntas_piezas_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Preguntas_procesos]  WITH CHECK ADD  CONSTRAINT [preguntas_procesos_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_procesos] CHECK CONSTRAINT [preguntas_procesos_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_procesos]  WITH CHECK ADD  CONSTRAINT [preguntas_procesos_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_procesos] CHECK CONSTRAINT [preguntas_procesos_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Preguntas_procesos]  WITH CHECK ADD  CONSTRAINT [preguntas_procesos_procesos_procesos_id_proceso] FOREIGN KEY([Procesos_id_proceso])
REFERENCES [dbo].[Procesos] ([id_proceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_procesos] CHECK CONSTRAINT [preguntas_procesos_procesos_procesos_id_proceso]
GO
ALTER TABLE [dbo].[Preguntas_procesos_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_procesos_generales_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_procesos_generales] CHECK CONSTRAINT [preguntas_procesos_generales_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_procesos_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_procesos_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_procesos_generales] CHECK CONSTRAINT [preguntas_procesos_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Preguntas_pt_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_pt_generales_idioma_idioma_id_idioma] FOREIGN KEY([idioma_id_idioma])
REFERENCES [dbo].[Idioma] ([id_idioma])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_pt_generales] CHECK CONSTRAINT [preguntas_pt_generales_idioma_idioma_id_idioma]
GO
ALTER TABLE [dbo].[Preguntas_pt_generales]  WITH CHECK ADD  CONSTRAINT [preguntas_pt_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion] FOREIGN KEY([niveles_certificacion_id_nivel_certificacion])
REFERENCES [dbo].[Niveles_certificacion] ([id_nivel_certificacion])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Preguntas_pt_generales] CHECK CONSTRAINT [preguntas_pt_generales_niveles_certificacion_niveles_certificacion_id_nivel_certificacion]
GO
ALTER TABLE [dbo].[Procesos_piezas_maquinas]  WITH CHECK ADD  CONSTRAINT [procesos_piezas_maquinas_piezas_piezas_id_pieza] FOREIGN KEY([Piezas_id_pieza])
REFERENCES [dbo].[Piezas] ([id_pieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Procesos_piezas_maquinas] CHECK CONSTRAINT [procesos_piezas_maquinas_piezas_piezas_id_pieza]
GO
ALTER TABLE [dbo].[Respuestas_maquina]  WITH CHECK ADD  CONSTRAINT [respuestas_maquina_preguntas_maquina_preguntas_maquina_id_pregunta_maquina] FOREIGN KEY([Preguntas_maquina_id_pregunta_maquina])
REFERENCES [dbo].[Preguntas_maquina] ([id_pregunta_maquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Respuestas_maquina] CHECK CONSTRAINT [respuestas_maquina_preguntas_maquina_preguntas_maquina_id_pregunta_maquina]
GO
ALTER TABLE [dbo].[Respuestas_maquina]  WITH CHECK ADD  CONSTRAINT [respuestas_maquina_resultados_maquina_resultados_maquina_id_resultado_máquina] FOREIGN KEY([resultados_maquina_id_resultado_máquina])
REFERENCES [dbo].[resultados_maquina] ([id_resultado_máquina])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Respuestas_maquina] CHECK CONSTRAINT [respuestas_maquina_resultados_maquina_resultados_maquina_id_resultado_máquina]
GO
ALTER TABLE [dbo].[Respuestas_pieza]  WITH CHECK ADD  CONSTRAINT [respuestas_pieza_preguntas_piezas_preguntas_piezas_id_pregunta_pieza] FOREIGN KEY([Preguntas_piezas_id_pregunta_pieza])
REFERENCES [dbo].[Preguntas_piezas] ([id_pregunta_pieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Respuestas_pieza] CHECK CONSTRAINT [respuestas_pieza_preguntas_piezas_preguntas_piezas_id_pregunta_pieza]
GO
ALTER TABLE [dbo].[Respuestas_pieza]  WITH CHECK ADD  CONSTRAINT [respuestas_pieza_resultados_pieza_resultados_pieza_id_resultado_pieza] FOREIGN KEY([Resultados_pieza_id_resultado_pieza])
REFERENCES [dbo].[Resultados_pieza] ([id_resultado_pieza])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Respuestas_pieza] CHECK CONSTRAINT [respuestas_pieza_resultados_pieza_resultados_pieza_id_resultado_pieza]
GO
ALTER TABLE [dbo].[Respuestas_proceso]  WITH CHECK ADD  CONSTRAINT [respuestas_proceso_preguntas_procesos_preguntas_procesos_id_pregunta_proceso] FOREIGN KEY([Preguntas_procesos_id_pregunta_proceso])
REFERENCES [dbo].[Preguntas_procesos] ([id_pregunta_proceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Respuestas_proceso] CHECK CONSTRAINT [respuestas_proceso_preguntas_procesos_preguntas_procesos_id_pregunta_proceso]
GO
ALTER TABLE [dbo].[Respuestas_proceso]  WITH CHECK ADD  CONSTRAINT [respuestas_proceso_resultados_proceso_resultados_proceso_id_resultado_proceso] FOREIGN KEY([Resultados_proceso_id_resultado_proceso])
REFERENCES [dbo].[Resultados_proceso] ([id_resultado_proceso])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Respuestas_proceso] CHECK CONSTRAINT [respuestas_proceso_resultados_proceso_resultados_proceso_id_resultado_proceso]
GO
USE [master]
GO
ALTER DATABASE [Carta_v] SET  READ_WRITE 
GO
