GO

CREATE TABLE [dbo].[Equipos](
	[Id_equipo] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Partidos] [int] NULL,
	[Estado] [varchar](1) NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFinal] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[equipoModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_equipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Futbolista](
	[Id_jugador] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Activo] [varchar](1) NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFinal] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
	[futbolistaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_jugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HistoricoEquipos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FutbolistaId] [int] NOT NULL,
	[EquipoId] [int] NOT NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFinal] [datetime] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HistoricoEquipos]  WITH CHECK ADD FOREIGN KEY([EquipoId])
REFERENCES [dbo].[Equipos] ([Id_equipo])
GO

ALTER TABLE [dbo].[HistoricoEquipos]  WITH CHECK ADD FOREIGN KEY([FutbolistaId])
REFERENCES [dbo].[Futbolista] ([Id_jugador])
GO