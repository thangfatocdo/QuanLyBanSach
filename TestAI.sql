USE [BookstoreDB]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 21/05/2025 3:13:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItem_Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[BookId] [int] NULL,
	[BookPrice] [float] NULL,
	[BookQuantity] [int] NULL,
	[CustomerPhone] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItem_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 21/05/2025 3:13:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[CustomerId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[ReceiveDate] [datetime] NULL,
	[TotalPrice] [float] NULL,
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMethodId] [int] NULL,
	[StatusId] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[CustomerName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (1, 1, 1, 20000, 2, N'4')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (2, 1, 2, 200000, 2, N'4')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (3, 2, 4, 343444, 3, N'4')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (4, 2, 6, 323242, 2, N'4')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (5, 4, 1, 32423, 2, N'324324324')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (6, 5, 1, 323223, 23, N'122121')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (7, 3, 1, 32324, 322, N'33')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (8, 6, 4, 32324, 2, N'32323')
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (9, 15, 17, 500000, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (10, 15, 16, 50000, 4, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (11, 15, 15, 50000, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (12, 15, 14, 20000, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (13, 15, 12, 11111, 4, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (14, 15, 10, 111, 5, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (15, 15, 9, 111, 6, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (16, 17, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (17, 17, 16, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (18, 17, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (19, 17, 14, 20000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (20, 18, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (21, 18, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (22, 18, 14, 20000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (23, 19, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (24, 19, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (25, 19, 14, 20000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (26, 20, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (27, 20, 16, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (28, 20, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (29, 20, 14, 20000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (30, 20, 7, 1111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (31, 20, 9, 111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (32, 21, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (33, 21, 16, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (34, 21, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (35, 21, 14, 20000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (36, 22, 1, 50000, 5, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (37, 22, 2, 49999, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (38, 22, 3, 30000, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (39, 22, 4, 111111, 4, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (40, 22, 6, 111111, 2, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (41, 22, 14, 20000, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (42, 22, 12, 11111, 4, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (43, 22, 9, 111, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (44, 22, 10, 111, 2, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (45, 23, 12, 11111, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (46, 23, 10, 111, 5, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (47, 23, 9, 111, 5, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (48, 23, 6, 111111, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (49, 23, 2, 49999, 2, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (50, 23, 1, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (51, 23, 16, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (52, 23, 4, 111111, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (53, 23, 15, 50000, 3, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (54, 23, 3, 30000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (55, 23, 7, 1111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (56, 24, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (57, 24, 16, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (58, 24, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (59, 24, 14, 20000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (60, 24, 12, 11111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (61, 25, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (62, 26, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (63, 26, 16, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (64, 26, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (65, 27, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (66, 27, 15, 50000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (67, 28, 15, 50000, 50, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (68, 29, 20, 100000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (69, 29, 19, 74000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (70, 29, 18, 200000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (71, 29, 17, 500000, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (72, 30, 16, 50000, 10, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (73, 31, 21, 100000, 33, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (74, 32, 12, 11111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (75, 33, 7, 1111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (76, 34, 4, 111111, 1, NULL)
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (77, 35, 12, 11111, 1, NULL)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-27T00:00:00.000' AS DateTime), CAST(N'2025-04-28T00:00:00.000' AS DateTime), 100000, 1, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2024-05-02T00:00:00.000' AS DateTime), 19000, 2, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (5, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2024-02-03T00:00:00.000' AS DateTime), 200000, 3, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2025-04-05T00:00:00.000' AS DateTime), 22000, 4, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2025-04-05T00:00:00.000' AS DateTime), 22000, 5, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2025-04-05T00:00:00.000' AS DateTime), 22000, 6, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T20:19:56.270' AS DateTime), CAST(N'2025-05-18T20:19:56.270' AS DateTime), 1955665, 15, 1, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T21:54:32.330' AS DateTime), CAST(N'2025-05-18T21:54:32.330' AS DateTime), 620000, 17, 1, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T22:17:57.600' AS DateTime), CAST(N'2025-05-18T22:17:57.603' AS DateTime), 570000, 18, 2, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T22:35:40.547' AS DateTime), CAST(N'2025-05-18T22:35:40.547' AS DateTime), 570000, 19, 1, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Văn Đá')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-16T09:30:38.970' AS DateTime), CAST(N'2025-05-19T09:30:38.970' AS DateTime), 621222, 20, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-16T09:44:23.123' AS DateTime), CAST(N'2025-05-19T09:44:23.123' AS DateTime), 620000, 21, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-18T22:03:00.373' AS DateTime), CAST(N'2025-05-21T22:03:00.373' AS DateTime), 1261662, 22, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-19T11:24:03.650' AS DateTime), CAST(N'2025-05-22T11:24:03.650' AS DateTime), 1082218, 23, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (NULL, CAST(N'2025-05-19T12:13:27.737' AS DateTime), CAST(N'2025-05-22T12:13:27.737' AS DateTime), 631111, 24, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Văn Đá')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-19T12:37:47.173' AS DateTime), CAST(N'2025-05-22T12:37:47.173' AS DateTime), 500000, 25, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (NULL, CAST(N'2025-05-19T12:39:08.597' AS DateTime), CAST(N'2025-05-22T12:39:08.597' AS DateTime), 600000, 26, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Văn Đá')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (NULL, CAST(N'2025-05-19T12:43:36.720' AS DateTime), CAST(N'2025-05-22T12:43:36.720' AS DateTime), 550000, 27, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Văn Đá')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-19T20:22:41.567' AS DateTime), CAST(N'2025-05-22T20:22:41.567' AS DateTime), 2500000, 28, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T10:30:46.450' AS DateTime), CAST(N'2025-05-23T10:30:46.450' AS DateTime), 874000, 29, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T10:32:44.970' AS DateTime), CAST(N'2025-05-23T10:32:44.970' AS DateTime), 500000, 30, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T10:36:31.483' AS DateTime), CAST(N'2025-05-23T10:36:31.483' AS DateTime), 3300000, 31, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T12:15:13.060' AS DateTime), CAST(N'2025-05-23T12:15:13.060' AS DateTime), 11111, 32, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T12:18:12.857' AS DateTime), CAST(N'2025-05-23T12:18:12.857' AS DateTime), 1111, 33, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T12:31:22.940' AS DateTime), CAST(N'2025-05-23T12:31:22.940' AS DateTime), 111111, 34, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-20T12:48:55.013' AS DateTime), CAST(N'2025-05-23T12:48:55.013' AS DateTime), 11111, 35, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[OrderStatuses] ([StatusId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatuses]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentMethods] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentMethods]
GO
