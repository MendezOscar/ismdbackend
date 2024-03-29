USE [ismddb]
GO
/****** Object:  Table [dbo].[cambio_riesgos]    Script Date: 11/25/2019 8:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cambio_riesgos](
	[IdCambioRiego] [int] IDENTITY(1,1) NOT NULL,
	[IdRiego] [varchar](max) NULL,
 CONSTRAINT [PK_cambio_riesgos] PRIMARY KEY CLUSTERED 
(
	[IdCambioRiego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cambios]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cambios](
	[IdCambio] [int] IDENTITY(1,1) NOT NULL,
	[Solicitante] [varchar](max) NULL,
	[Razon] [varchar](max) NULL,
 CONSTRAINT [PK_cambios] PRIMARY KEY CLUSTERED 
(
	[IdCambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[capacidad]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[capacidad](
	[IdCapacidad] [int] IDENTITY(1,1) NOT NULL,
	[IdProyecto] [int] NULL,
	[Estado] [varchar](25) NULL,
	[Monto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCapacidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catalogo_cliente]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogo_cliente](
	[IdCatalogoCliente] [int] NOT NULL,
	[IdCatalogoTec] [int] NULL,
	[Componente] [varchar](50) NULL,
	[Funcionalidad] [varchar](50) NULL,
	[Ayuda] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCatalogoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catalogo_tecnico]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogo_tecnico](
	[IdCatalogoTec] [int] IDENTITY(1,1) NOT NULL,
	[IdRequerimiento] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Detalle] [varchar](255) NULL,
	[Dependencias] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCatalogoTec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[incidente]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[incidente](
	[IdIncidente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Descripcion] [varchar](max) NULL,
	[Prioridad] [int] NULL,
	[IdProyecto] [int] NULL,
 CONSTRAINT [PK_incidente] PRIMARY KEY CLUSTERED 
(
	[IdIncidente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[modelo_entrega]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modelo_entrega](
	[IdModelo] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Funcionalidad] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proyecto]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](max) NULL,
	[Solicitante] [varchar](100) NULL,
	[Encargado] [varchar](100) NULL,
	[Documentacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_proyecto] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pruebas]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pruebas](
	[IdPrueba] [int] IDENTITY(1,1) NOT NULL,
	[Proyecto] [int] NOT NULL,
	[Observaciones] [varchar](max) NULL,
 CONSTRAINT [PK_pruebas] PRIMARY KEY CLUSTERED 
(
	[IdPrueba] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recurso_cambio]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recurso_cambio](
	[IdRecursoCambio] [int] IDENTITY(1,1) NOT NULL,
	[RecursoId] [int] NULL,
 CONSTRAINT [PK_recurso_cambio] PRIMARY KEY CLUSTERED 
(
	[IdRecursoCambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recurso_detalle]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recurso_detalle](
	[IdRecursoDet] [int] IDENTITY(1,1) NOT NULL,
	[IdRecurso] [int] NULL,
	[Capacidad] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRecursoDet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recurso_encabezado]    Script Date: 11/25/2019 8:27:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recurso_encabezado](
	[IdRecurso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](255) NULL,
	[Tipo] [varchar](50) NULL,
	[Costo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRecurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[requerimiento]    Script Date: 11/25/2019 8:27:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[requerimiento](
	[IdRequerimiento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](255) NULL,
	[Fecha] [date] NULL,
	[Prioridad] [varchar](25) NULL,
	[Estado] [varchar](25) NULL,
	[Programador] [varchar](50) NULL,
	[IdProyecto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRequerimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[riesgo]    Script Date: 11/25/2019 8:27:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[riesgo](
	[IdRiesgo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](255) NULL,
	[Tipo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRiesgo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 11/25/2019 8:27:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NULL,
	[clave] [varchar](max) NULL,
	[tipo] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[catalogo_cliente]  WITH CHECK ADD  CONSTRAINT [fk_CatalogoCliente] FOREIGN KEY([IdCatalogoTec])
REFERENCES [dbo].[catalogo_tecnico] ([IdCatalogoTec])
GO
ALTER TABLE [dbo].[catalogo_cliente] CHECK CONSTRAINT [fk_CatalogoCliente]
GO
ALTER TABLE [dbo].[catalogo_tecnico]  WITH CHECK ADD  CONSTRAINT [fk_CatalogoTecnico] FOREIGN KEY([IdRequerimiento])
REFERENCES [dbo].[requerimiento] ([IdRequerimiento])
GO
ALTER TABLE [dbo].[catalogo_tecnico] CHECK CONSTRAINT [fk_CatalogoTecnico]
GO
ALTER TABLE [dbo].[recurso_detalle]  WITH CHECK ADD  CONSTRAINT [fk_RecursoDetalle] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[recurso_encabezado] ([IdRecurso])
GO
ALTER TABLE [dbo].[recurso_detalle] CHECK CONSTRAINT [fk_RecursoDetalle]
GO
