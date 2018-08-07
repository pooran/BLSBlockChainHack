USE [bslhack]
GO
/****** Object:  Table [dbo].[Clinica]    Script Date: 8/7/2018 7:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clinica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[FechaDeCreacion1] [datetime] NOT NULL,
	[FechaModificada1] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Clinica_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Farmacia]    Script Date: 8/7/2018 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farmacia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Comuna] [nvarchar](100) NOT NULL,
	[Localidad] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](200) NOT NULL,
	[HoraApertura] [nvarchar](50) NOT NULL,
	[HoraCierre] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Lat] [nvarchar](50) NOT NULL,
	[Long] [nvarchar](50) NOT NULL,
	[Region] [int] NOT NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaModificada] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
	[Regiona] [nvarchar](50) NULL,
	[ComunaId] [nvarchar](50) NULL,
	[LocalidadId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Farmacia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicina]    Script Date: 8/7/2018 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrescripcionId] [int] NOT NULL,
	[NombreMedicamento] [nvarchar](500) NULL,
	[Dosis] [int] NULL,
	[Unidad] [nvarchar](50) NULL,
	[Cada] [int] NULL,
	[UnidadTiempo] [nvarchar](50) NULL,
	[CantidadDias] [int] NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaModificada] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Medicina] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NombreMedicina]    Script Date: 8/7/2018 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NombreMedicina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OfertaId] [int] NOT NULL,
	[MedicinaId] [int] NOT NULL,
	[Marca] [nvarchar](50) NULL,
	[EstaActivo] [nchar](10) NULL,
	[Costo] [bigint] NOT NULL,
 CONSTRAINT [PK_NombreMedicina] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oferta]    Script Date: 8/7/2018 7:05:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oferta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FarmaciaId] [int] NOT NULL,
	[UsusarioId] [int] NOT NULL,
	[PrescripcionId] [int] NOT NULL,
	[EstaActivo] [nchar](10) NULL,
	[Total] [bigint] NOT NULL,
	[SeguroId] [int] NULL,
	[EsAceptado] [bit] NOT NULL,
	[EsRecogido] [bit] NOT NULL,
	[Code] [nvarchar](50) NULL,
 CONSTRAINT [PK_Oferta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 8/7/2018 7:05:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ClinicId] [int] NOT NULL,
	[PacienteId] [nvarchar](50) NULL,
	[Clave] [nvarchar](50) NOT NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaModificada] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescripcion]    Script Date: 8/7/2018 7:06:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescripcion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[PacienteId] [int] NOT NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaModificada] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Prescripcion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 8/7/2018 7:06:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Percentage] [int] NOT NULL,
	[EstaActivo] [nchar](10) NULL,
 CONSTRAINT [PK_Seguro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 8/7/2018 7:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajo]    Script Date: 8/7/2018 7:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaModificada] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Trabajo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/7/2018 7:06:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RUT] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](50) NOT NULL,
	[FechaDeCreacion] [datetime] NOT NULL,
	[FechaModificada] [datetime] NULL,
	[EstaActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioTrabajo]    Script Date: 8/7/2018 7:06:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioTrabajo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[TrabajoId] [int] NOT NULL,
	[EstaActivo] [nchar](10) NULL,
 CONSTRAINT [PK_UsuarioTrabajo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsusarioFarmacia]    Script Date: 8/7/2018 7:06:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsusarioFarmacia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FarmaciaId] [int] NOT NULL,
	[EstaActivo] [nchar](10) NULL,
 CONSTRAINT [PK_UsusarioFarmacia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clinica] ADD  CONSTRAINT [DF_Clinica_FechaDeCreacion1]  DEFAULT (getutcdate()) FOR [FechaDeCreacion1]
GO
ALTER TABLE [dbo].[Clinica] ADD  CONSTRAINT [DF_Clinica_FechaModificada1]  DEFAULT (getutcdate()) FOR [FechaModificada1]
GO
ALTER TABLE [dbo].[Clinica] ADD  CONSTRAINT [DF_Clinica_EstaActivo1]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Farmacia] ADD  CONSTRAINT [DF_Farmacia_FechaDeCreacion]  DEFAULT (getutcdate()) FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Farmacia] ADD  CONSTRAINT [DF_Farmacia_FechaModificada]  DEFAULT (getutcdate()) FOR [FechaModificada]
GO
ALTER TABLE [dbo].[Farmacia] ADD  CONSTRAINT [DF_Farmacia_EstaActivo]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Medicina] ADD  CONSTRAINT [DF_Medicina_FechaDeCreacion]  DEFAULT (getutcdate()) FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Medicina] ADD  CONSTRAINT [DF_Medicina_FechaModificada]  DEFAULT (getutcdate()) FOR [FechaModificada]
GO
ALTER TABLE [dbo].[Medicina] ADD  CONSTRAINT [DF_Medicina_EstaActivo]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Paciente] ADD  CONSTRAINT [DF_Paciente_FechaDeCreacion]  DEFAULT (getutcdate()) FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Paciente] ADD  CONSTRAINT [DF_Paciente_FechaModificada]  DEFAULT (getutcdate()) FOR [FechaModificada]
GO
ALTER TABLE [dbo].[Paciente] ADD  CONSTRAINT [DF_Paciente_EstaActivo]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Prescripcion] ADD  CONSTRAINT [DF_Prescripcion_FechaDeCreacion]  DEFAULT (getutcdate()) FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Prescripcion] ADD  CONSTRAINT [DF_Prescripcion_FechaModificada]  DEFAULT (getutcdate()) FOR [FechaModificada]
GO
ALTER TABLE [dbo].[Prescripcion] ADD  CONSTRAINT [DF_Prescripcion_EstaActivo]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Trabajo] ADD  CONSTRAINT [DF_Trabajo_FechaDeCreacion]  DEFAULT (getutcdate()) FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Trabajo] ADD  CONSTRAINT [DF_Trabajo_FechaModificada]  DEFAULT (getutcdate()) FOR [FechaModificada]
GO
ALTER TABLE [dbo].[Trabajo] ADD  CONSTRAINT [DF_Trabajo_IsActive]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaDeCreacion]  DEFAULT (getutcdate()) FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaModificada]  DEFAULT (getutcdate()) FOR [FechaModificada]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_IsActive]  DEFAULT ((1)) FOR [EstaActivo]
GO
ALTER TABLE [dbo].[Medicina]  WITH CHECK ADD  CONSTRAINT [FK_Medicina_Prescripcion] FOREIGN KEY([PrescripcionId])
REFERENCES [dbo].[Prescripcion] ([Id])
GO
ALTER TABLE [dbo].[Medicina] CHECK CONSTRAINT [FK_Medicina_Prescripcion]
GO
ALTER TABLE [dbo].[NombreMedicina]  WITH CHECK ADD  CONSTRAINT [FK_NombreMedicina_Medicina] FOREIGN KEY([MedicinaId])
REFERENCES [dbo].[Medicina] ([Id])
GO
ALTER TABLE [dbo].[NombreMedicina] CHECK CONSTRAINT [FK_NombreMedicina_Medicina]
GO
ALTER TABLE [dbo].[NombreMedicina]  WITH CHECK ADD  CONSTRAINT [FK_NombreMedicina_Oferta] FOREIGN KEY([OfertaId])
REFERENCES [dbo].[Oferta] ([Id])
GO
ALTER TABLE [dbo].[NombreMedicina] CHECK CONSTRAINT [FK_NombreMedicina_Oferta]
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD  CONSTRAINT [FK_Oferta_Farmacia] FOREIGN KEY([FarmaciaId])
REFERENCES [dbo].[Farmacia] ([Id])
GO
ALTER TABLE [dbo].[Oferta] CHECK CONSTRAINT [FK_Oferta_Farmacia]
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD  CONSTRAINT [FK_Oferta_Prescripcion] FOREIGN KEY([PrescripcionId])
REFERENCES [dbo].[Prescripcion] ([Id])
GO
ALTER TABLE [dbo].[Oferta] CHECK CONSTRAINT [FK_Oferta_Prescripcion]
GO
ALTER TABLE [dbo].[Oferta]  WITH NOCHECK ADD  CONSTRAINT [FK_Oferta_Seguro] FOREIGN KEY([SeguroId])
REFERENCES [dbo].[Seguro] ([Id])
GO
ALTER TABLE [dbo].[Oferta] NOCHECK CONSTRAINT [FK_Oferta_Seguro]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Clinica] FOREIGN KEY([ClinicId])
REFERENCES [dbo].[Clinica] ([Id])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Clinica]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Usuario]
GO
ALTER TABLE [dbo].[Prescripcion]  WITH CHECK ADD  CONSTRAINT [FK_Prescripcion_Paciente] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Paciente] ([Id])
GO
ALTER TABLE [dbo].[Prescripcion] CHECK CONSTRAINT [FK_Prescripcion_Paciente]
GO
ALTER TABLE [dbo].[UsuarioTrabajo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioTrabajo_Trabajo] FOREIGN KEY([TrabajoId])
REFERENCES [dbo].[Trabajo] ([Id])
GO
ALTER TABLE [dbo].[UsuarioTrabajo] CHECK CONSTRAINT [FK_UsuarioTrabajo_Trabajo]
GO
ALTER TABLE [dbo].[UsuarioTrabajo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioTrabajo_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioTrabajo] CHECK CONSTRAINT [FK_UsuarioTrabajo_Usuario]
GO
ALTER TABLE [dbo].[UsusarioFarmacia]  WITH CHECK ADD  CONSTRAINT [FK_UsusarioFarmacia_Farmacia] FOREIGN KEY([FarmaciaId])
REFERENCES [dbo].[Farmacia] ([Id])
GO
ALTER TABLE [dbo].[UsusarioFarmacia] CHECK CONSTRAINT [FK_UsusarioFarmacia_Farmacia]
GO
ALTER TABLE [dbo].[UsusarioFarmacia]  WITH CHECK ADD  CONSTRAINT [FK_UsusarioFarmacia_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsusarioFarmacia] CHECK CONSTRAINT [FK_UsusarioFarmacia_Usuario]
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
