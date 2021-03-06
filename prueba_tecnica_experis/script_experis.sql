USE [experis]
GO
/****** Object:  Table [dbo].[candidato]    Script Date: 05/08/2020 15:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[candidato](
	[id_candidato] [int] NOT NULL,
	[nombre] [varchar](70) NULL,
	[email] [varchar](70) NULL,
	[direccion_calle] [varchar](200) NULL,
	[direccion_suite] [varchar](200) NULL,
	[direccion_ciudad] [varchar](200) NULL,
	[direccion_codigo_postal] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
	[sitio_web] [varchar](200) NULL,
	[compañia_nombre] [varchar](200) NULL,
	[compañia_catchPhrase] [varchar](200) NULL,
	[compañia_bs] [varchar](200) NULL,
	[api_id] [int] NOT NULL,
 CONSTRAINT [PK__candidat__3CD1A861F084B022] PRIMARY KEY CLUSTERED 
(
	[id_candidato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[entrevista]    Script Date: 05/08/2020 15:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[entrevista](
	[id_entrevista] [int] IDENTITY(1,1) NOT NULL,
	[candidato_id] [int] NOT NULL,
	[fecha_entrevista] [datetime] NOT NULL,
	[hora_entrevista] [varchar](10) NULL,
	[observaciones] [varchar](300) NULL,
	[tipo_entrevista_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_entrevista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[opciones_tecnologia]    Script Date: 05/08/2020 15:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[opciones_tecnologia](
	[id_opcion] [int] IDENTITY(1,1) NOT NULL,
	[tipo_tecnologia_id] [int] NOT NULL,
	[orden_id] [int] NOT NULL,
	[descripcion] [varchar](70) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_opcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_entrevista]    Script Date: 05/08/2020 15:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_entrevista](
	[id_tipo_entrevista] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_entrevista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_tecnologia]    Script Date: 05/08/2020 15:09:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_tecnologia](
	[id_tipo_tecnologia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_tecnologia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[opciones_tecnologia] ON 

INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (1, 1, 1, N'Asp.Net')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (2, 1, 2, N'MVVM')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (3, 1, 3, N'Ado.Net')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (4, 1, 4, N'Entity FrameWork')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (5, 1, 5, N'LinQ')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (6, 2, 1, N'Java Server Pages')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (7, 2, 2, N'Java Server Faces')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (8, 2, 3, N'Enterprise Java Beans')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (9, 2, 4, N'Java Persistence Api')
INSERT [dbo].[opciones_tecnologia] ([id_opcion], [tipo_tecnologia_id], [orden_id], [descripcion]) VALUES (10, 2, 5, N'Java Messaging Services')
SET IDENTITY_INSERT [dbo].[opciones_tecnologia] OFF
SET IDENTITY_INSERT [dbo].[tipo_entrevista] ON 

INSERT [dbo].[tipo_entrevista] ([id_tipo_entrevista], [descripcion]) VALUES (1, N'Presencial')
INSERT [dbo].[tipo_entrevista] ([id_tipo_entrevista], [descripcion]) VALUES (2, N'telefónica')
INSERT [dbo].[tipo_entrevista] ([id_tipo_entrevista], [descripcion]) VALUES (3, N'remota')
SET IDENTITY_INSERT [dbo].[tipo_entrevista] OFF
SET IDENTITY_INSERT [dbo].[tipo_tecnologia] ON 

INSERT [dbo].[tipo_tecnologia] ([id_tipo_tecnologia], [descripcion]) VALUES (1, N'Microsot .Net')
INSERT [dbo].[tipo_tecnologia] ([id_tipo_tecnologia], [descripcion]) VALUES (2, N'Oracle Java')
SET IDENTITY_INSERT [dbo].[tipo_tecnologia] OFF
ALTER TABLE [dbo].[entrevista]  WITH CHECK ADD  CONSTRAINT [FK__entrevist__candi__30F848ED] FOREIGN KEY([candidato_id])
REFERENCES [dbo].[candidato] ([id_candidato])
GO
ALTER TABLE [dbo].[entrevista] CHECK CONSTRAINT [FK__entrevist__candi__30F848ED]
GO
ALTER TABLE [dbo].[entrevista]  WITH CHECK ADD FOREIGN KEY([tipo_entrevista_id])
REFERENCES [dbo].[tipo_entrevista] ([id_tipo_entrevista])
GO
ALTER TABLE [dbo].[opciones_tecnologia]  WITH CHECK ADD FOREIGN KEY([tipo_tecnologia_id])
REFERENCES [dbo].[tipo_tecnologia] ([id_tipo_tecnologia])
GO
ALTER TABLE [dbo].[opciones_tecnologia]  WITH CHECK ADD FOREIGN KEY([tipo_tecnologia_id])
REFERENCES [dbo].[tipo_tecnologia] ([id_tipo_tecnologia])
GO
