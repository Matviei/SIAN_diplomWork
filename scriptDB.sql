USE [TimeMangerDB]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08.06.2022 13:20:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID_employee] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[Surname] [nchar](10) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Number_Phone] [nvarchar](10) NOT NULL,
	[ID_level] [int] NULL,
	[Photo] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[ID_subdivision] [int] NOT NULL,
	[ID_staffStatus] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID_employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[ID_level] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[ID_level] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID_role] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffStatus]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffStatus](
	[ID_staffStatus] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StaffStatus] PRIMARY KEY CLUSTERED 
(
	[ID_staffStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID_status] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subdivision]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subdivision](
	[ID_subdivision] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subdivision] PRIMARY KEY CLUSTERED 
(
	[ID_subdivision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[ID_task] [int] IDENTITY(1,1) NOT NULL,
	[Primary_goal] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AllSpentTime] [int] NULL,
	[ID_status] [int] NOT NULL,
	[BeginningOfWork] [date] NOT NULL,
	[EndOfWork] [date] NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[ID_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskSchedule]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskSchedule](
	[ID_taskSchedule] [int] IDENTITY(1,1) NOT NULL,
	[ID_taskSubdivision] [int] NOT NULL,
	[ID_employee] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[SpentTime] [int] NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ID_status] [int] NOT NULL,
 CONSTRAINT [PK_TaskSchedule] PRIMARY KEY CLUSTERED 
(
	[ID_taskSchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskSubdivision]    Script Date: 08.06.2022 13:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskSubdivision](
	[ID_taskSubdivision] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[SpentTime] [int] NULL,
	[Date] [date] NOT NULL,
	[ID_status] [int] NOT NULL,
	[ID_subdivision] [int] NOT NULL,
	[ID_task] [int] NOT NULL,
 CONSTRAINT [PK_TaskSubdivision] PRIMARY KEY CLUSTERED 
(
	[ID_taskSubdivision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID_employee], [Password], [Surname], [Name], [Number_Phone], [ID_level], [Photo], [Mail], [ID_subdivision], [ID_staffStatus]) VALUES (1, N'qwerty', N'Сунцов    ', N'Матвей    ', N'9508101746', NULL, NULL, N'matviei1109@yandex.ru', 1, 1)
INSERT [dbo].[Employee] ([ID_employee], [Password], [Surname], [Name], [Number_Phone], [ID_level], [Photo], [Mail], [ID_subdivision], [ID_staffStatus]) VALUES (2, N'1234', N'Мусин     ', N'Раниль    ', N'112', 1, NULL, N'matviei1109@yandex.ru', 2, 1)
INSERT [dbo].[Employee] ([ID_employee], [Password], [Surname], [Name], [Number_Phone], [ID_level], [Photo], [Mail], [ID_subdivision], [ID_staffStatus]) VALUES (3, N'1234', N'Сафин     ', N'Амир      ', N'228', 2, NULL, N'228', 3, 1)
INSERT [dbo].[Employee] ([ID_employee], [Password], [Surname], [Name], [Number_Phone], [ID_level], [Photo], [Mail], [ID_subdivision], [ID_staffStatus]) VALUES (4, N'1234', N'Шакиров   ', N'Ильназ    ', N'1', 3, NULL, N'1', 4, 1)
INSERT [dbo].[Employee] ([ID_employee], [Password], [Surname], [Name], [Number_Phone], [ID_level], [Photo], [Mail], [ID_subdivision], [ID_staffStatus]) VALUES (5, N'1234', N'Сапаров   ', N'Данил     ', N'1', 1, NULL, N'1', 5, 1)
INSERT [dbo].[Employee] ([ID_employee], [Password], [Surname], [Name], [Number_Phone], [ID_level], [Photo], [Mail], [ID_subdivision], [ID_staffStatus]) VALUES (9, N'1', N'Тестер    ', N'Тестиро   ', N'1', 1, NULL, N'1', 2, 2)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[Level] ([ID_level], [Description]) VALUES (1, N'Junior')
INSERT [dbo].[Level] ([ID_level], [Description]) VALUES (2, N'Middle')
INSERT [dbo].[Level] ([ID_level], [Description]) VALUES (3, N'Senior')
GO
INSERT [dbo].[StaffStatus] ([ID_staffStatus], [Description]) VALUES (1, N'В штате')
INSERT [dbo].[StaffStatus] ([ID_staffStatus], [Description]) VALUES (2, N'В архиве')
GO
INSERT [dbo].[Status] ([ID_status], [Description]) VALUES (1, N'В процессе')
INSERT [dbo].[Status] ([ID_status], [Description]) VALUES (2, N'Готов')
INSERT [dbo].[Status] ([ID_status], [Description]) VALUES (3, N'В архив')
GO
INSERT [dbo].[Subdivision] ([ID_subdivision], [Description]) VALUES (1, N'Руководитель проекта')
INSERT [dbo].[Subdivision] ([ID_subdivision], [Description]) VALUES (2, N'Разработчик')
INSERT [dbo].[Subdivision] ([ID_subdivision], [Description]) VALUES (3, N'Дизайнер')
INSERT [dbo].[Subdivision] ([ID_subdivision], [Description]) VALUES (4, N'Аналитик')
INSERT [dbo].[Subdivision] ([ID_subdivision], [Description]) VALUES (5, N'Тестировщик')
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([ID_task], [Primary_goal], [Description], [AllSpentTime], [ID_status], [BeginningOfWork], [EndOfWork]) VALUES (1, N'Написание диплома', N'Написать ИС по теме: Контроль времени работы сотрудников', NULL, 1, CAST(N'2022-05-16' AS Date), NULL)
INSERT [dbo].[Tasks] ([ID_task], [Primary_goal], [Description], [AllSpentTime], [ID_status], [BeginningOfWork], [EndOfWork]) VALUES (3, N'Написание  модулей', N'Добавить WEB API', NULL, 1, CAST(N'2022-06-07' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskSchedule] ON 

INSERT [dbo].[TaskSchedule] ([ID_taskSchedule], [ID_taskSubdivision], [ID_employee], [Date], [Comment], [SpentTime], [Description], [ID_status]) VALUES (2, 1, 1, CAST(N'2022-05-31' AS Date), N'сделать тест', 10, N'Сделать модуль регистрации', 2)
INSERT [dbo].[TaskSchedule] ([ID_taskSchedule], [ID_taskSubdivision], [ID_employee], [Date], [Comment], [SpentTime], [Description], [ID_status]) VALUES (3, 1, 2, CAST(N'2022-05-31' AS Date), N'сделать тест', 5, N'Сделать модуль авторизации', 2)
INSERT [dbo].[TaskSchedule] ([ID_taskSchedule], [ID_taskSubdivision], [ID_employee], [Date], [Comment], [SpentTime], [Description], [ID_status]) VALUES (4, 2, 1, CAST(N'2022-06-08' AS Date), N'сделать тест', 7, N'Сделать валидацию данных', 1)
INSERT [dbo].[TaskSchedule] ([ID_taskSchedule], [ID_taskSubdivision], [ID_employee], [Date], [Comment], [SpentTime], [Description], [ID_status]) VALUES (5, 2, 2, CAST(N'2022-07-09' AS Date), N'cсделать тест', 4, N'Сделать валидацию для пароля', 1)
INSERT [dbo].[TaskSchedule] ([ID_taskSchedule], [ID_taskSubdivision], [ID_employee], [Date], [Comment], [SpentTime], [Description], [ID_status]) VALUES (7, 2, 1, CAST(N'2022-07-09' AS Date), N'сделать тест', 3, N'Валидация пароля', 2)
INSERT [dbo].[TaskSchedule] ([ID_taskSchedule], [ID_taskSubdivision], [ID_employee], [Date], [Comment], [SpentTime], [Description], [ID_status]) VALUES (8, 2, 1, CAST(N'2022-06-06' AS Date), N'сделать тест', 6, N'Валидация параметров', 2)
SET IDENTITY_INSERT [dbo].[TaskSchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskSubdivision] ON 

INSERT [dbo].[TaskSubdivision] ([ID_taskSubdivision], [Description], [SpentTime], [Date], [ID_status], [ID_subdivision], [ID_task]) VALUES (1, N'Сделать авторизацию и регистрацию', 15, CAST(N'2022-05-31' AS Date), 1, 1, 1)
INSERT [dbo].[TaskSubdivision] ([ID_taskSubdivision], [Description], [SpentTime], [Date], [ID_status], [ID_subdivision], [ID_task]) VALUES (2, N'Сделать валидацию для регитрации', 14, CAST(N'2022-06-07' AS Date), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[TaskSubdivision] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Level] FOREIGN KEY([ID_level])
REFERENCES [dbo].[Level] ([ID_level])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Level]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_StaffStatus] FOREIGN KEY([ID_staffStatus])
REFERENCES [dbo].[StaffStatus] ([ID_staffStatus])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_StaffStatus]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Subdivision] FOREIGN KEY([ID_subdivision])
REFERENCES [dbo].[Subdivision] ([ID_subdivision])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Subdivision]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Status] FOREIGN KEY([ID_status])
REFERENCES [dbo].[Status] ([ID_status])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Status]
GO
ALTER TABLE [dbo].[TaskSchedule]  WITH CHECK ADD  CONSTRAINT [FK_TaskSchedule_Employee] FOREIGN KEY([ID_employee])
REFERENCES [dbo].[Employee] ([ID_employee])
GO
ALTER TABLE [dbo].[TaskSchedule] CHECK CONSTRAINT [FK_TaskSchedule_Employee]
GO
ALTER TABLE [dbo].[TaskSchedule]  WITH CHECK ADD  CONSTRAINT [FK_TaskSchedule_Status] FOREIGN KEY([ID_status])
REFERENCES [dbo].[Status] ([ID_status])
GO
ALTER TABLE [dbo].[TaskSchedule] CHECK CONSTRAINT [FK_TaskSchedule_Status]
GO
ALTER TABLE [dbo].[TaskSchedule]  WITH CHECK ADD  CONSTRAINT [FK_TaskSchedule_TaskSubdivision] FOREIGN KEY([ID_taskSubdivision])
REFERENCES [dbo].[TaskSubdivision] ([ID_taskSubdivision])
GO
ALTER TABLE [dbo].[TaskSchedule] CHECK CONSTRAINT [FK_TaskSchedule_TaskSubdivision]
GO
ALTER TABLE [dbo].[TaskSubdivision]  WITH CHECK ADD  CONSTRAINT [FK_TaskSubdivision_Status] FOREIGN KEY([ID_status])
REFERENCES [dbo].[Status] ([ID_status])
GO
ALTER TABLE [dbo].[TaskSubdivision] CHECK CONSTRAINT [FK_TaskSubdivision_Status]
GO
ALTER TABLE [dbo].[TaskSubdivision]  WITH CHECK ADD  CONSTRAINT [FK_TaskSubdivision_Subdivision] FOREIGN KEY([ID_subdivision])
REFERENCES [dbo].[Subdivision] ([ID_subdivision])
GO
ALTER TABLE [dbo].[TaskSubdivision] CHECK CONSTRAINT [FK_TaskSubdivision_Subdivision]
GO
ALTER TABLE [dbo].[TaskSubdivision]  WITH CHECK ADD  CONSTRAINT [FK_TaskSubdivision_Tasks] FOREIGN KEY([ID_task])
REFERENCES [dbo].[Tasks] ([ID_task])
GO
ALTER TABLE [dbo].[TaskSubdivision] CHECK CONSTRAINT [FK_TaskSubdivision_Tasks]
GO
