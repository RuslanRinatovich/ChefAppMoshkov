USE [master]
GO
/****** Object:  Database [ChefBD]    Script Date: 18.06.2023 23:03:37 ******/
CREATE DATABASE [ChefBD]

GO
USE [ChefBD]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Photo] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Client_1] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Good]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Good](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Photo] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Weight] [float] NOT NULL,
 CONSTRAINT [PK_Good] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoodFeedBack]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodFeedBack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientUserName] [nvarchar](100) NOT NULL,
	[GoodId] [int] NOT NULL,
	[Info] [nvarchar](1000) NULL,
	[Rate] [float] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_GoodFeedBack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[ContactPhone] [nvarchar](50) NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[DeliveryTime] [time](7) NULL,
	[StatusId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderGood]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderGood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[GoodId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_OrderGood] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 18.06.2023 23:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Title]) VALUES (1, N'Роллы')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (2, N'Сеты и комбо')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (3, N'Горячие роллы')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (4, N'Пицца')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (5, N'Классические роллы')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (6, N'Закуски')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (7, N'Напитки')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (8, N'Десерты')
INSERT [dbo].[Category] ([Id], [Title]) VALUES (9, N'Соусы')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'admin', N'1', N'Раиль', N'Дмитриевич', N'Мошков', N'898', N'mosh@mail.ru', N'1me.jpg', N'ГотэмСити', 2)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'afonya', N'1', N'Афанасий ', N'Анатольевич', N'Воронин ', N'+7 (986) 390-56-36', N'AfanasiyVoronin228', N'66.jpg', N'617504, г. ГотэмСити, ул. Шлюзовая, дом 120, квартира 475', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'bulg', N'1', N'Ярослава ', N'Анатольевна', N'Булгакова', N'+7 (947) 661-27-62', N'YaroslavaBulgakova386', N'21.jpg', N'352080, г. ГотэмСити, ул. Грузинская Б., дом 132, квартира 905', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'buyer1', N'1', N'Дмитрий', N'Антонович', N'Григорьев', N'8695645454', N'1', N'Search.png', N'352080, г. ГотэмСити, ул. Мышинская, дом 13, квартира 666', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'client', N'1', N'Иван', N'Иванович', N'Иванов', N'+7 (980) 065-36-18', N'AntipVoloshtuk117', N'ыфв.jpg', N'641020, г. ГотэмСити, ул. Солянский туп, дом 108, квартира 126', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'fomina', N'1', N'Августа ', N'Закировна', N'Фомина', N'+7 (927) 791-38-92', N'AvgustaFomina481', N'ff.jpg', N'624990, г. ГотэмСити, ул. Ключ-Камышенское плато, дом 86, квартира 419', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'ksu', N'1', N'Ксения ', N'Антоновна', N'Тарская', N'+7 (956) 444-79-41', N'KseniyaTarskaya686', N'fdsfds.jpg', N'692405, г. ГотэмСити, ул. Радищевская Ниж., дом 56, квартира 420', 1)
GO
SET IDENTITY_INSERT [dbo].[Good] ON 

INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (21, 1, N'Филадельфия с огурцом', N'11.png', 441, 300)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (22, 1, N'Филадельфия с авокадо', N'12.png', 469, 300)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (23, 1, N'Пирамида ролл', N'13.png', 410, 255)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (24, 1, N'Манчестер ролл', N'14.png', 336, 332)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (25, 3, N'Горячий цезарь', N'15.png', 311, 377)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (26, 3, N'Дубай горячий ролл', N'16.png', 430, 340)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (27, 3, N'Чикен Чиз горячий', N'17.png', 318, 345)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (28, 3, N'Киото горячий ролл', N'8.png', 313, 325)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (29, 4, N'Пепперони пицца', N'19.png', 518, 545)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (30, 4, N'Ранчо пицца', N'110.png', 510, 710)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (31, 4, N'Сырный цыпленок пицца', N'211.png', 498, 545)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (32, 7, N'Лимонад - Классический', N'212.png', 110, 500)
INSERT [dbo].[Good] ([Id], [CategoryId], [Name], [Photo], [Price], [Weight]) VALUES (33, 7, N'Лимонад - Мум бай', N'213.png', 110, 500)
SET IDENTITY_INSERT [dbo].[Good] OFF
GO
SET IDENTITY_INSERT [dbo].[GoodFeedBack] ON 

INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (6, N'afonya', 21, N'Вкусно, огонь', 5, CAST(N'2023-06-10' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (7, N'bulg', 21, N'Понравилось', 4, CAST(N'2023-05-13' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (8, N'bulg', 26, N'Насыщенный вкус, мне очень понравилось', 5, CAST(N'2023-06-08' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (9, N'bulg', 28, N'Отличное сочетание вкусов', 4, CAST(N'2023-06-16' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (10, N'bulg', 32, N'На вкус не очень, много ароматизаторов', 3, CAST(N'2023-06-14' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (11, N'bulg', 30, N'На любителя, деквушке понравился', 4, CAST(N'2023-06-15' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (12, N'client', 32, N'Вкусный лимонад', 4, CAST(N'2023-06-18' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (13, N'client', 31, N'Классная пицца. Много курицы', 5, CAST(N'2023-06-17' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (14, N'ksu', 25, N'вкусные роллы', 5, CAST(N'2023-06-18' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (15, N'bulg', 24, N'Очень вкусный', 5, CAST(N'2023-06-18' AS Date))
SET IDENTITY_INSERT [dbo].[GoodFeedBack] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserName], [DateStart], [Address], [ContactPhone], [TotalPrice], [DeliveryTime], [StatusId]) VALUES (33, N'bulg', CAST(N'2023-06-18T00:16:47.777' AS DateTime), N'352080, г. ГотэмСити, ул. Грузинская Б., дом 132, квартира 905', N'+7 (947) 661-27-62', 1248, CAST(N'01:16:47.7765524' AS Time), 3)
INSERT [dbo].[Order] ([Id], [UserName], [DateStart], [Address], [ContactPhone], [TotalPrice], [DeliveryTime], [StatusId]) VALUES (34, N'client', CAST(N'2023-06-18T20:11:03.520' AS DateTime), N'641020, г. ГотэмСити, ул. Солянский туп, дом 108, квартира 126', N'+7 (980) 065-36-18', 423, CAST(N'21:11:03.5198627' AS Time), 4)
INSERT [dbo].[Order] ([Id], [UserName], [DateStart], [Address], [ContactPhone], [TotalPrice], [DeliveryTime], [StatusId]) VALUES (35, N'client', CAST(N'2023-06-18T21:36:07.733' AS DateTime), N'641020, г. ГотэмСити, ул. Солянский туп, дом 108, квартира 126', N'+7 (980) 065-36-18', 1663, CAST(N'22:36:07.7337457' AS Time), 1)
INSERT [dbo].[Order] ([Id], [UserName], [DateStart], [Address], [ContactPhone], [TotalPrice], [DeliveryTime], [StatusId]) VALUES (36, N'bulg', CAST(N'2023-06-18T22:41:28.310' AS DateTime), N'352080, г. ГотэмСити, ул. Грузинская Б., дом 132, квартира 905', N'+7 (947) 661-27-62', 1274, CAST(N'23:41:28.3086937' AS Time), 1)
INSERT [dbo].[Order] ([Id], [UserName], [DateStart], [Address], [ContactPhone], [TotalPrice], [DeliveryTime], [StatusId]) VALUES (37, N'client', CAST(N'2023-06-18T23:01:33.590' AS DateTime), N'641020, г. ГотэмСити, ул. Солянский туп, дом 108, квартира 126', N'+7 (980) 065-36-18', 1153, CAST(N'23:01:33' AS Time), 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderGood] ON 

INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (58, 33, 29, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (59, 33, 30, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (60, 33, 32, 2)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (61, 34, 28, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (62, 34, 32, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (63, 35, 28, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (64, 35, 26, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (65, 35, 23, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (66, 35, 30, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (67, 36, 25, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (68, 36, 26, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (69, 36, 28, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (70, 36, 32, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (71, 36, 33, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (72, 37, 28, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (73, 37, 23, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (74, 37, 26, 1)
SET IDENTITY_INSERT [dbo].[OrderGood] OFF
GO
INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'клиент')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'администратор')
GO
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (1, N'Создана', N'#FFFF6347')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (2, N'Принята', N'#FF4BA5F0')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (3, N'В пути', N'#FFCFE668')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (4, N'Доставлена', N'#FF8CEE8C')
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Role]
GO
ALTER TABLE [dbo].[Good]  WITH CHECK ADD  CONSTRAINT [FK_Good_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Good] CHECK CONSTRAINT [FK_Good_Category]
GO
ALTER TABLE [dbo].[GoodFeedBack]  WITH CHECK ADD  CONSTRAINT [FK_GoodFeedBack_Client] FOREIGN KEY([ClientUserName])
REFERENCES [dbo].[Client] ([UserName])
GO
ALTER TABLE [dbo].[GoodFeedBack] CHECK CONSTRAINT [FK_GoodFeedBack_Client]
GO
ALTER TABLE [dbo].[GoodFeedBack]  WITH CHECK ADD  CONSTRAINT [FK_GoodFeedBack_Good] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([Id])
GO
ALTER TABLE [dbo].[GoodFeedBack] CHECK CONSTRAINT [FK_GoodFeedBack_Good]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client1] FOREIGN KEY([UserName])
REFERENCES [dbo].[Client] ([UserName])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[OrderGood]  WITH CHECK ADD  CONSTRAINT [FK_OrderGood_Good] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Good] ([Id])
GO
ALTER TABLE [dbo].[OrderGood] CHECK CONSTRAINT [FK_OrderGood_Good]
GO
ALTER TABLE [dbo].[OrderGood]  WITH CHECK ADD  CONSTRAINT [FK_OrderGood_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderGood] CHECK CONSTRAINT [FK_OrderGood_Order]
GO
USE [master]
GO
ALTER DATABASE [ChefBD] SET  READ_WRITE 
GO
