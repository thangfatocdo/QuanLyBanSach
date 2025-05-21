USE [BookstoreDB]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[AuthorId] [int] NULL,
	[CategoryId] [int] NULL,
	[PublisherId] [int] NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[BookId] [int] NULL,
	[Quantity] [int] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Alias] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[Password] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryDetail]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[ImportId] [int] NULL,
	[BookId] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Iep_Id] [int] NULL,
	[Type] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryExport]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryExport](
	[UserId] [int] NULL,
	[Export_Date] [datetime] NULL,
	[Iep_Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
 CONSTRAINT [PK_InventoryExport] PRIMARY KEY CLUSTERED 
(
	[Iep_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryImport]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryImport](
	[ImportId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ImportDate] [datetime] NULL,
	[Note] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ImportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 18/05/2025 11:59:29 CH ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 18/05/2025 11:59:29 CH ******/
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
/****** Object:  Table [dbo].[OrderStatuses]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatuses](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[PaymentMethodId] [int] IDENTITY(1,1) NOT NULL,
	[MethodName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistic]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistic](
	[Title] [nvarchar](100) NULL,
	[Total_BooksSold] [int] NULL,
	[Total_Customers] [int] NULL,
	[Total_Orders] [int] NULL,
	[Total_Quantity] [int] NULL,
	[YearRevenue] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/05/2025 11:59:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Role] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 
GO
INSERT [dbo].[Authors] ([AuthorId], [AuthorName]) VALUES (1, N'Do Huu Thang')
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (1, N'Ngữ Văn', 1, 1, 1, CAST(50000.00 AS Decimal(10, 2)), N'Xin Chao', N'sach-giao-khoa-ngu-van-lop-6.jpg', CAST(N'2025-04-20T10:46:57.013' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (2, N'Toán', 1, 2, 1, CAST(49999.00 AS Decimal(10, 2)), N'JJSDVMVSV', N'toan-lop-5-nxb-giao-duc.jpg', CAST(N'2025-04-20T13:40:50.920' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (3, N'Đại Số', 1, 2, 1, CAST(30000.00 AS Decimal(10, 2)), N'Đại Số', N'sach-giao-khoa-dai-so-va-giai-tich-11-co-ban.png', CAST(N'2025-04-20T21:13:14.713' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (4, N'The Bible', 1, 1, 1, CAST(111111.00 AS Decimal(10, 2)), N'1111', N'280111.jpg', CAST(N'2025-04-26T16:17:35.693' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (6, N'Little Red Book', 1, 2, 1, CAST(111111.00 AS Decimal(10, 2)), N'', N'9798707538155.jpg', CAST(N'2025-04-26T16:18:27.730' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (7, N'Quran
Koran', 1, 2, 1, CAST(1111.00 AS Decimal(10, 2)), N'', N'istockphoto-815768296-1024x1024.jpg', CAST(N'2025-04-26T16:18:45.050' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (9, N'Xinhua Dictionary', 1, 2, 1, CAST(111.00 AS Decimal(10, 2)), N'', N'Xinhua_zidian.jpg', CAST(N'2025-04-26T16:19:05.783' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (10, N'Don Quixote', 1, 1, 1, CAST(111.00 AS Decimal(10, 2)), N'', N'51KzbusN2VL._AC_UF1000,1000_QL80_.jpg', CAST(N'2025-04-26T16:19:16.453' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (12, N'Truyền thuyết thiếu lâm', 1, 1, 1, CAST(11111.00 AS Decimal(10, 2)), N'11111', N'book-covers-big-2019101610.jpg', CAST(N'2025-04-27T18:55:18.277' AS DateTime))
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (14, N'Những Người khốn khổ', 1, 1, 1, CAST(20000.00 AS Decimal(10, 2)), N'Những người khốn khổ là câu chuyện về xã hội nước Pháp trong khoảng hơn 20 năm đầu thế kỉ 19 kể từ thời điểm Napoleon I lên ngôi và vài thập niên sau đó. Nhân vật chính của tiểu thuyết là Jean Valjean, một cựu tù khổ sai tìm cách chuộc lại những lỗi lầm gây ra thời trai trẻ. Bộ tiểu thuyết không chỉ nói tới bản chất của cái tốt, cái xấu, của luật pháp, mà tác phẩm còn là cuốn bách khoa thư đồ sộ về lịc sử, kiến trúc của Paris, nền chính trị, triết lý, luật pháp, công lý, tín ngưỡng của nước Pháp nửa đầu thế kỷ 19.', N'hh_bia_1_nhung_nguoi_khon_kho_1_8aec34095c624ee4b0bfdf628df1e20d_master.jpg', NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (15, N'Hoàng tử bé', 1, 1, 1, CAST(50000.00 AS Decimal(10, 2)), N'Hoàng Tử Bé (Song Ngữ Việt-Anh)

Hoàng tử bé được xuất bản lần đầu năm 1943 của nhà văn, phi công người Pháp Antoine de Saint-exupéry là một trong những cuốn tiểu thuyết kinh điển nổi tiếng nhất mọi thời đại. Câu chuyện ngắn gọn về cuộc gặp gỡ diệu kỳ giữa viên phi công bị rơi máy bay và Hoàng tử bé giữa sa mạc Sa-ha-ra hoang vu. Hành tinh quê hương và các mối quan hệ của hoàng tử bé dần hé lộ: Tình bạn, tình yêu thương của Hoàng tử bé dành cho bông hồng duy nhất, tình cảm sâu sắc dành cho chú cáo.

Không những vậy, thông qua các cuộc gặp gỡ trong chuyến du ngoạn tới các hành tinh khác nhau của hoàng tử bé cũng chứa đựng triết lý nhân sinh sâu sắc về các kiểu người trong xã hội hiện đại.

Thật không ngoa khi khẳng định, mỗi câu chữ trong cuốn sách này đều đầy triết lý và mỗi người, mỗi lứa tuổi và mỗi hoàn cảnh khi đọc sẽ có những cảm nhận riêng.

Thành tích

Tính đến nay, tác phẩm Hoàng tử bé (Le Petit Prince) đã được dịch sang 300 ngôn ngữ, trở thành cuốn sách được chuyển thể ra nhiều ngôn ngữ nhất trên thế giới chỉ sau Kinh Thánh. Với hàng trăm triệu bản in trên toàn thế giới, Hoàng tử bé được coi là một trong những tác phẩm bán chạy nhất của nhân loại và vẫn tiếp tục được xuất bản hằng năm với rất nhiều phiên bản khác nhau.

Cuốn sách thiếu nhi có kèm truyện tranh độc đáo với phiên bản truyện song ngữ Anh Việt giúp các em nhỏ học tiếng Anh, giải trí, tăng vốn từ vựng, rèn luyện EQ, IQ. Có thể coi đây là cuốn sách vượt xa các cuốn sách đương thời như: Harry Potter, Nhóc Nicolas, Kính vạn hoa, Lũ trẻ hư nhất quả đất, Chuyện con mèo dạy hải âu bay...

Cuốn sách được xếp vào top 100 cuốn sách hay nhất thế kỷ XX.

Điểm khác biệt của phiên bản song ngữ Việt-Anh này so với các phiên bản khác có trên thị trường:

Phần tiếng Anh là bản dịch của Katherine Wood – một bản dịch vô cùng được yêu thích bởi những người nói tiếng Anh trên khắp thế giới.

Đây là phiên bản Hoàng tử bé song ngữ Anh-Việt duy nhất có kết hợp chọn từ vựng tiếng Anh giúp các em nhỏ học tiếng Anh, giải trí, tăng vốn từ vựng với những đoạn hội thoại đậm chất văn học, nuôi dưỡng và rèn luyện trí thông mình cảm xúc (EQ) và cảm nhận tác phẩm kinh điển này bằng cả hai thứ tiếng.

Trình bày song song hai ngôn ngữ giúp học tiếng Anh (hoặc người nước ngoài học tiếng Việt) một cách dễ dàng cùng phần ghi chú từ vựng vô cùng sáng tạo, độc đáo.

Sách song ngữ nhưng giá bìa không hề cao hơn sách tiếng Việt, còn được tặng kèm link download phiên bản audio cho các độc giả muốn nghe truyện bằng tiếng Anh.', N'bia-1_6_6.jpg', NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (16, N'Lập Trình C giá rẻ', 1, 2, 1, CAST(50000.00 AS Decimal(10, 2)), N'Lập Trình C', N'lap trinh c.jpg', NULL)
GO
INSERT [dbo].[Books] ([BookId], [Title], [AuthorId], [CategoryId], [PublisherId], [Price], [Description], [ImageUrl], [CreatedAt]) VALUES (17, N'Nhà Giả Kim bản đẹp', 1, 1, 1, CAST(500000.00 AS Decimal(10, 2)), N'Nhà Giả Kim
sách bán chạy nhất', N'nhagiakim.jpg', NULL)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (41, 16, 1, 6, CAST(N'2025-05-16T14:40:58.620' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (42, 16, 2, 1, CAST(N'2025-05-16T14:41:00.323' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (43, 16, 4, 13, CAST(N'2025-05-16T14:41:21.237' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (44, 16, 3, 5, CAST(N'2025-05-16T14:42:06.873' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (45, 16, 7, 3, CAST(N'2025-05-16T14:47:11.257' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (46, 16, 6, 10, CAST(N'2025-05-16T15:35:49.383' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (59, 4, 12, 3, CAST(N'2025-05-18T22:03:27.893' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (60, 4, 10, 4, CAST(N'2025-05-18T22:03:29.997' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (61, 4, 9, 4, CAST(N'2025-05-18T22:03:31.973' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (62, 4, 6, 3, CAST(N'2025-05-18T22:03:33.323' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (63, 4, 2, 2, CAST(N'2025-05-18T22:03:34.210' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (64, 4, 1, 1, CAST(N'2025-05-18T22:03:35.007' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (65, 4, 16, 1, CAST(N'2025-05-18T22:44:24.787' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (66, 4, 4, 3, CAST(N'2025-05-18T22:44:39.290' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (67, 4, 15, 3, CAST(N'2025-05-18T22:44:50.887' AS DateTime))
GO
INSERT [dbo].[CartItems] ([CartItemId], [CustomerId], [BookId], [Quantity], [CreatedAt]) VALUES (68, 4, 3, 1, CAST(N'2025-05-18T22:45:10.550' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Alias]) VALUES (1, N'Văn Học', N'van-hoc')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Alias]) VALUES (2, N'Toán Học', N'toan-hoc')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Alias]) VALUES (3, N'Triết', N'triet')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Alias]) VALUES (4, N'Khoa học viễn tưởng', N'khoa-hoc-vien-tuong')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Alias]) VALUES (5, N'sinh', N'sinh')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (4, N'Đỗ Hữu Thắng', N'03252200', N'yendaotg@gmail.com', N'efafAFaffw', N'dohuuthang')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (5, N'Đỗ Hữu Nghị', NULL, N'dohuuthang@gmail.com', NULL, N'dohuuthang')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (6, N'Nguyễn Văn A', NULL, N'abc@gmail.com', NULL, N'thanglolo1090')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (7, N'Nguyễn Xuân son', N'03503255', NULL, N'dada', N'thanglolo1090')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (8, N'Lưu Bá Ôn', N'015625632', N'yaasuio@gmail.com', N'abc đường abc', N'thanglolo1090')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (9, N'alo', N'01335224', N'yendaotg', N'nfeahodiqa', N'Thang')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (10, N'testabc', N'02226500', N'yendaotgw@gmail.com', N'aerfeaw', N'thanglolo')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (14, N'Nguyễn Văn B', N'01853241895', N'abcxyz@gmail.com', N'123 điện biên phủ phường 5', N'matkhau')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (15, N'Nguyễn Văn B', N'039855465225', N'abc@gmail.com', N'abc duong abc', N'Thang')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (16, N'Đỗ Hữu A ', NULL, N'abczxhnfnn@gmail.com', NULL, N'thanglolo1090')
GO
INSERT [dbo].[Customers] ([CustomerId], [FullName], [Phone], [Email], [Address], [Password]) VALUES (17, N'Nguyễn Văn C', NULL, N'NguyenVanC@gmail.com', NULL, N'thanglolo1090')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryDetail] ON 
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (1, 1, 1, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (2, 1, 2, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (3, 2, 1, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (4, 2, 4, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (5, 4, 1, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (6, 5, 2, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (7, 5, 4, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (8, 5, 10, 20, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (9, 17, 1, 10, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (19, 18, 1, 10, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (20, 18, 2, 10, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (21, 19, 12, 5, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (22, 19, 15, 10, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (23, 19, 10, 20, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (24, 20, 15, 40, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (25, 20, 16, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (26, 20, 14, 30, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (27, 21, 17, 20, NULL, N'Import')
GO
INSERT [dbo].[InventoryDetail] ([DetailId], [ImportId], [BookId], [Quantity], [Iep_Id], [Type]) VALUES (28, 21, 16, 30, NULL, N'Import')
GO
SET IDENTITY_INSERT [dbo].[InventoryDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryExport] ON 
GO
INSERT [dbo].[InventoryExport] ([UserId], [Export_Date], [Iep_Id], [OrderId]) VALUES (1, NULL, 1, 1)
GO
INSERT [dbo].[InventoryExport] ([UserId], [Export_Date], [Iep_Id], [OrderId]) VALUES (1, NULL, 2, 2)
GO
INSERT [dbo].[InventoryExport] ([UserId], [Export_Date], [Iep_Id], [OrderId]) VALUES (1, NULL, 3, 3)
GO
SET IDENTITY_INSERT [dbo].[InventoryExport] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryImport] ON 
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (1, 1, CAST(N'2025-12-05T00:00:00.000' AS DateTime), N'Nhap lan dau')
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (2, 1, CAST(N'2025-04-28T17:02:38.203' AS DateTime), N'')
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (4, 1, CAST(N'2025-04-28T17:09:03.647' AS DateTime), N'')
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (5, 1, CAST(N'2025-04-28T20:46:18.000' AS DateTime), N'')
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (17, 1, CAST(N'2025-05-05T18:18:29.860' AS DateTime), NULL)
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (18, 1, CAST(N'2025-05-05T18:18:29.860' AS DateTime), NULL)
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (19, 1, CAST(N'2025-05-05T22:06:45.463' AS DateTime), NULL)
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (20, 1, CAST(N'2025-05-07T22:10:41.903' AS DateTime), NULL)
GO
INSERT [dbo].[InventoryImport] ([ImportId], [UserId], [ImportDate], [Note]) VALUES (21, 1, CAST(N'2025-05-09T08:28:38.283' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[InventoryImport] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (1, 1, 1, 20000, 2, N'4')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (2, 1, 2, 200000, 2, N'4')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (3, 2, 4, 343444, 3, N'4')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (4, 2, 6, 323242, 2, N'4')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (5, 4, 1, 32423, 2, N'324324324')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (6, 5, 1, 323223, 23, N'122121')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (7, 3, 1, 32324, 322, N'33')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (8, 6, 4, 32324, 2, N'32323')
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (9, 15, 17, 500000, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (10, 15, 16, 50000, 4, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (11, 15, 15, 50000, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (12, 15, 14, 20000, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (13, 15, 12, 11111, 4, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (14, 15, 10, 111, 5, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (15, 15, 9, 111, 6, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (16, 17, 17, 500000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (17, 17, 16, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (18, 17, 15, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (19, 17, 14, 20000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (20, 18, 17, 500000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (21, 18, 15, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (22, 18, 14, 20000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (23, 19, 17, 500000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (24, 19, 15, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (25, 19, 14, 20000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (26, 20, 17, 500000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (27, 20, 16, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (28, 20, 15, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (29, 20, 14, 20000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (30, 20, 7, 1111, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (31, 20, 9, 111, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (32, 21, 17, 500000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (33, 21, 16, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (34, 21, 15, 50000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (35, 21, 14, 20000, 1, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (36, 22, 1, 50000, 5, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (37, 22, 2, 49999, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (38, 22, 3, 30000, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (39, 22, 4, 111111, 4, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (40, 22, 6, 111111, 2, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (41, 22, 14, 20000, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (42, 22, 12, 11111, 4, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (43, 22, 9, 111, 3, NULL)
GO
INSERT [dbo].[OrderItems] ([OrderItem_Id], [OrderId], [BookId], [BookPrice], [BookQuantity], [CustomerPhone]) VALUES (44, 22, 10, 111, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-27T00:00:00.000' AS DateTime), CAST(N'2025-04-28T00:00:00.000' AS DateTime), 100000, 1, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2024-05-02T00:00:00.000' AS DateTime), 19000, 2, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (5, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2024-02-03T00:00:00.000' AS DateTime), 200000, 3, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2025-04-05T00:00:00.000' AS DateTime), 22000, 4, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2025-04-05T00:00:00.000' AS DateTime), 22000, 5, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-04-05T00:00:00.000' AS DateTime), CAST(N'2025-04-05T00:00:00.000' AS DateTime), 22000, 6, 1, 1, N'13 đường abc', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T20:19:56.270' AS DateTime), CAST(N'2025-05-18T20:19:56.270' AS DateTime), 1955665, 15, 1, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T21:54:32.330' AS DateTime), CAST(N'2025-05-18T21:54:32.330' AS DateTime), 620000, 17, 1, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T22:17:57.600' AS DateTime), CAST(N'2025-05-18T22:17:57.603' AS DateTime), 570000, 18, 2, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-15T22:35:40.547' AS DateTime), CAST(N'2025-05-18T22:35:40.547' AS DateTime), 570000, 19, 1, 1, N'faefaf, eawfeawf, eafweawf, fasfawe, Việt Nam', N'Đỗ Văn Đá')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-16T09:30:38.970' AS DateTime), CAST(N'2025-05-19T09:30:38.970' AS DateTime), 621222, 20, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-16T09:44:23.123' AS DateTime), CAST(N'2025-05-19T09:44:23.123' AS DateTime), 620000, 21, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
GO
INSERT [dbo].[Orders] ([CustomerId], [OrderDate], [ReceiveDate], [TotalPrice], [OrderId], [PaymentMethodId], [StatusId], [Address], [CustomerName]) VALUES (4, CAST(N'2025-05-18T22:03:00.373' AS DateTime), CAST(N'2025-05-21T22:03:00.373' AS DateTime), 1261662, 22, 1, 1, N'10 Nguyễn Tuyển, Bình Trưng Tây, 2, Hồ Chí Minh, Việt Nam', N'Đỗ Hữu Thắng')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatuses] ON 
GO
INSERT [dbo].[OrderStatuses] ([StatusId], [StatusName]) VALUES (1, N'Chờ duyệt')
GO
INSERT [dbo].[OrderStatuses] ([StatusId], [StatusName]) VALUES (2, N'Đã duyệt')
GO
INSERT [dbo].[OrderStatuses] ([StatusId], [StatusName]) VALUES (3, N'Đang giao')
GO
INSERT [dbo].[OrderStatuses] ([StatusId], [StatusName]) VALUES (4, N'Đã giao')
GO
INSERT [dbo].[OrderStatuses] ([StatusId], [StatusName]) VALUES (5, N'Đã hủy')
GO
INSERT [dbo].[OrderStatuses] ([StatusId], [StatusName]) VALUES (6, N'Trả hàng')
GO
SET IDENTITY_INSERT [dbo].[OrderStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentMethods] ON 
GO
INSERT [dbo].[PaymentMethods] ([PaymentMethodId], [MethodName]) VALUES (1, N'Chuyển khoản')
GO
INSERT [dbo].[PaymentMethods] ([PaymentMethodId], [MethodName]) VALUES (2, N'Thanh toán khi nhận hàng')
GO
SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 
GO
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [Address], [Phone]) VALUES (1, N'Tre', N'99 Nguyen Tu Nghiem', N'032146363')
GO
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [Role]) VALUES (1, N'admin', N'admin', N'Đỗ Hữu Thắng', N'admin')
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [Role]) VALUES (2, N'thang', N'thanglolo', N'Nguyễn Hữu Thắng', NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [Role]) VALUES (3, N'user1', N'MatKhau', N'Nguyễn Văn Đậu', NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [Role]) VALUES (4, N'Thang2', N'thang', N'Nguyễn Hữu Thắng', NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FullName], [Role]) VALUES (5, N'user4', N'thang', N'Nguyen Van C', NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E4CCC668D8]    Script Date: 18/05/2025 11:59:29 CH ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CartItems] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[InventoryImport] ADD  DEFAULT (getdate()) FOR [ImportDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('Admin') FOR [Role]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Books]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Customers]
GO
ALTER TABLE [dbo].[InventoryDetail]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
GO
ALTER TABLE [dbo].[InventoryDetail]  WITH CHECK ADD FOREIGN KEY([ImportId])
REFERENCES [dbo].[InventoryImport] ([ImportId])
GO
ALTER TABLE [dbo].[InventoryDetail]  WITH CHECK ADD  CONSTRAINT [FK_InventoryDetail_InventoryExport] FOREIGN KEY([Iep_Id])
REFERENCES [dbo].[InventoryExport] ([Iep_Id])
GO
ALTER TABLE [dbo].[InventoryDetail] CHECK CONSTRAINT [FK_InventoryDetail_InventoryExport]
GO
ALTER TABLE [dbo].[InventoryExport]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[InventoryExport]  WITH CHECK ADD  CONSTRAINT [FK_InventoryExport_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[InventoryExport] CHECK CONSTRAINT [FK_InventoryExport_Orders]
GO
ALTER TABLE [dbo].[InventoryImport]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
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
