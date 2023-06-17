/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2017 (14.0.1000)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [ChefBD]
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
INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'клиент')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'администратор')
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'admin', N'1', N'Раиль', N'Дмитриевич', N'Мошков', N'898', N'mosh@mail.ru', N'me.jpg', N'ГотэмСити', 2)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'afonya', N'1', N'Афанасий ', N'Анатольевич', N'Воронин ', N'+7 (986) 390-56-36', N'AfanasiyVoronin228', N'66.jpg', N'617504, г. ГотэмСити, ул. Шлюзовая, дом 120, квартира 475', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'bulg', N'1', N'Ярослава ', N'Анатольевна', N'Булгакова', N'+7 (947) 661-27-62', N'YaroslavaBulgakova386', N'21.jpg', N'352080, г. ГотэмСити, ул. Грузинская Б., дом 132, квартира 905', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'buyer1', N'1', N'Дмитрий', N'Антонович', N'Григорьев', N'8695645454', N'1', N'Search.png', N'352080, г. ГотэмСити, ул. Мышинская, дом 13, квартира 666', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'client', N'1', N'Иван', N'Иванович', N'Иванов', N'+7 (980) 065-36-18', N'AntipVoloshtuk117', N'ыфв.jpg', N'641020, г. ГотэмСити, ул. Солянский туп, дом 108, квартира 126', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'fomina', N'1', N'Августа ', N'Закировна', N'Фомина', N'+7 (927) 791-38-92', N'AvgustaFomina481', N'ff.jpg', N'624990, г. ГотэмСити, ул. Ключ-Камышенское плато, дом 86, квартира 419', 1)
INSERT [dbo].[Client] ([UserName], [Password], [FirstName], [MiddleName], [LastName], [Phone], [Email], [Photo], [Address], [RoleId]) VALUES (N'ksu', N'1', N'Ксения ', N'Антоновна', N'Тарская', N'+7 (956) 444-79-41', N'KseniyaTarskaya686', N'fdsfds.jpg', N'692405, г. ГотэмСити, ул. Радищевская Ниж., дом 56, квартира 420', 1)
SET IDENTITY_INSERT [dbo].[GoodFeedBack] ON 

INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (6, N'afonya', 21, N'Вкусно, огонь', 5, CAST(N'2023-06-10' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (7, N'bulg', 21, N'Понравилось', 4, CAST(N'2023-05-13' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (8, N'bulg', 26, N'Насыщенный вкус, мне очень понравилось', 5, CAST(N'2023-06-08' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (9, N'bulg', 28, N'Отличное сочетание вкусов', 4, CAST(N'2023-06-16' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (10, N'bulg', 32, N'На вкус не очень, много ароматизаторов', 3, CAST(N'2023-06-14' AS Date))
INSERT [dbo].[GoodFeedBack] ([Id], [ClientUserName], [GoodId], [Info], [Rate], [Date]) VALUES (11, N'bulg', 30, N'На любителя, деквушке понравился', 4, CAST(N'2023-06-15' AS Date))
SET IDENTITY_INSERT [dbo].[GoodFeedBack] OFF
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (1, N'Создана', N'#FFFF6347')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (2, N'Принята', N'#FF4BA5F0')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (3, N'В пути', N'#FFCFE668')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (4, N'Доставлена', N'#FF8CEE8C')
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserName], [DateStart], [Address], [ContactPhone], [TotalPrice], [DeliveryTime], [StatusId]) VALUES (33, N'bulg', CAST(N'2023-06-18T00:16:47.777' AS DateTime), N'352080, г. ГотэмСити, ул. Грузинская Б., дом 132, квартира 905', N'+7 (947) 661-27-62', 1248, CAST(N'01:16:47.7765524' AS Time), 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderGood] ON 

INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (58, 33, 29, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (59, 33, 30, 1)
INSERT [dbo].[OrderGood] ([Id], [OrderId], [GoodId], [Count]) VALUES (60, 33, 32, 2)
SET IDENTITY_INSERT [dbo].[OrderGood] OFF
