USE [master]
GO
/****** Object:  Database [DB_PC_07_Module3]    Script Date: 11/7/2019 3:38:45 PM ******/
CREATE DATABASE [DB_PC_07_Module3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_PC_07_Module3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_PC_07_Module3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_PC_07_Module3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_PC_07_Module3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB_PC_07_Module3] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_PC_07_Module3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_PC_07_Module3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_PC_07_Module3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_PC_07_Module3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_PC_07_Module3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_PC_07_Module3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_PC_07_Module3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_PC_07_Module3] SET  MULTI_USER 
GO
ALTER DATABASE [DB_PC_07_Module3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_PC_07_Module3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_PC_07_Module3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_PC_07_Module3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_PC_07_Module3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_PC_07_Module3] SET QUERY_STORE = OFF
GO
USE [DB_PC_07_Module3]
GO
/****** Object:  Table [dbo].[detail_order]    Script Date: 11/7/2019 3:38:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[header_order_id] [int] NOT NULL,
	[menu_id] [int] NOT NULL,
	[order_price] [decimal](8, 2) NOT NULL,
	[quantity] [int] NOT NULL,
	[order_placed_time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[header_order]    Script Date: 11/7/2019 3:38:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[header_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_made_time] [datetime] NOT NULL,
	[table_number] [int] NOT NULL,
	[customer_name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 11/7/2019 3:38:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu_category_id] [int] NOT NULL,
	[name] [varchar](100) NOT NULL,
	[price] [decimal](8, 2) NOT NULL,
	[description] [varchar](200) NULL,
	[is_favourite] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu_category]    Script Date: 11/7/2019 3:38:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 11/7/2019 3:38:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[header_order_id] [int] NOT NULL,
	[promotion_id] [int] NULL,
	[payment_type] [varchar](20) NOT NULL,
	[amount_to_pay] [decimal](10, 2) NOT NULL,
	[amount_paid] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotion]    Script Date: 11/7/2019 3:38:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promotion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[discount] [decimal](5, 2) NOT NULL,
	[minimum_spent] [decimal](10, 2) NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[detail_order] ON 

INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (1, 1, 6, CAST(50000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T11:13:20.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (2, 1, 9, CAST(20000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T11:13:25.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (3, 2, 2, CAST(97000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T12:00:30.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (4, 2, 3, CAST(50000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T12:00:35.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (5, 2, 10, CAST(10000.00 AS Decimal(8, 2)), 2, CAST(N'2019-10-18T12:00:40.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (6, 3, 4, CAST(100000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T13:01:05.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (7, 3, 6, CAST(50000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T13:01:10.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (8, 3, 5, CAST(45000.00 AS Decimal(8, 2)), 2, CAST(N'2019-10-18T13:05:05.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (9, 3, 9, CAST(20000.00 AS Decimal(8, 2)), 2, CAST(N'2019-10-18T13:05:25.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (10, 3, 10, CAST(10000.00 AS Decimal(8, 2)), 4, CAST(N'2019-10-18T13:05:35.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (11, 4, 1, CAST(55000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T13:28:10.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (12, 4, 3, CAST(50000.00 AS Decimal(8, 2)), 2, CAST(N'2019-10-18T13:28:15.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (13, 3, 15, CAST(10000.00 AS Decimal(8, 2)), 3, CAST(N'2019-10-18T13:30:35.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (14, 3, 14, CAST(25000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T13:30:45.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (15, 5, 17, CAST(30000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T13:55:40.000' AS DateTime))
INSERT [dbo].[detail_order] ([id], [header_order_id], [menu_id], [order_price], [quantity], [order_placed_time]) VALUES (16, 5, 12, CAST(30000.00 AS Decimal(8, 2)), 1, CAST(N'2019-10-18T13:55:44.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[detail_order] OFF
SET IDENTITY_INSERT [dbo].[header_order] ON 

INSERT [dbo].[header_order] ([id], [order_made_time], [table_number], [customer_name]) VALUES (1, CAST(N'2019-10-18T11:13:00.000' AS DateTime), 3, N'Fanny')
INSERT [dbo].[header_order] ([id], [order_made_time], [table_number], [customer_name]) VALUES (2, CAST(N'2019-10-18T12:00:23.000' AS DateTime), 1, N'Rina')
INSERT [dbo].[header_order] ([id], [order_made_time], [table_number], [customer_name]) VALUES (3, CAST(N'2019-10-18T13:00:56.000' AS DateTime), 3, N'Reni')
INSERT [dbo].[header_order] ([id], [order_made_time], [table_number], [customer_name]) VALUES (4, CAST(N'2019-10-18T13:28:00.000' AS DateTime), 4, N'Budiman')
INSERT [dbo].[header_order] ([id], [order_made_time], [table_number], [customer_name]) VALUES (5, CAST(N'2019-10-18T13:30:00.000' AS DateTime), 2, N'Danu')
INSERT [dbo].[header_order] ([id], [order_made_time], [table_number], [customer_name]) VALUES (6, CAST(N'2019-10-18T13:55:31.000' AS DateTime), 5, N'Antika')
SET IDENTITY_INSERT [dbo].[header_order] OFF
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (1, 1, N'Beef Martabak', CAST(55000.00 AS Decimal(8, 2)), N'With sour sweet sauce and pickles', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (2, 1, N'Spaghetti Bolognaise', CAST(97000.00 AS Decimal(8, 2)), N'Spaghettie with minced beef and tomato sauce', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (3, 1, N'Gado gado', CAST(50000.00 AS Decimal(8, 2)), N'Mixed boiled vegetable served with rice cake and peanut sauce', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (4, 1, N'Grilled Sirloin', CAST(200000.00 AS Decimal(8, 2)), N'Steak and fries served with mushroom sauce', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (5, 1, N'Deluxe Burger', CAST(45000.00 AS Decimal(8, 2)), N'Beef patty with melted extra double cheese, tomato, and pickle', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (6, 1, N'Iga Bakar', CAST(50000.00 AS Decimal(8, 2)), N'Served with Sambal Ijo, rice, and soup', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (7, 2, N'Tropical Punch', CAST(40000.00 AS Decimal(8, 2)), N'The perfect blend of cherry, orange and pineapple flavor', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (8, 2, N'Cappuccino', CAST(25000.00 AS Decimal(8, 2)), N'', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (9, 2, N'Juices', CAST(20000.00 AS Decimal(8, 2)), N'Avocado, Pineapple, Orange, Mango', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (10, 2, N'Mineral Water', CAST(10000.00 AS Decimal(8, 2)), N'', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (11, 2, N'Soft Drinks', CAST(15000.00 AS Decimal(8, 2)), N'Cola, Sprite, Fanta', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (12, 3, N'Cheese and choco pancake', CAST(30000.00 AS Decimal(8, 2)), N'With maple or rum sauce', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (13, 3, N'Ice Mochi', CAST(30000.00 AS Decimal(8, 2)), N'Salted Caramel, Rd Bean, Coffee, Green Tea, Chocolate', 1)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (14, 3, N'Tiramisu', CAST(25000.00 AS Decimal(8, 2)), N'', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (15, 4, N'Miso Soup', CAST(10000.00 AS Decimal(8, 2)), N'', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (16, 4, N'Rice', CAST(10000.00 AS Decimal(8, 2)), N'', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (17, 4, N'Mushroom Steak Salad', CAST(30000.00 AS Decimal(8, 2)), N'Served with sesame or thousand islands dressing', 0)
INSERT [dbo].[menu] ([id], [menu_category_id], [name], [price], [description], [is_favourite]) VALUES (18, 4, N'Spicy Edamame', CAST(20000.00 AS Decimal(8, 2)), N'Edamame served with chili flakes', 0)
SET IDENTITY_INSERT [dbo].[menu] OFF
SET IDENTITY_INSERT [dbo].[menu_category] ON 

INSERT [dbo].[menu_category] ([id], [name]) VALUES (1, N'Foods')
INSERT [dbo].[menu_category] ([id], [name]) VALUES (2, N'Drinks')
INSERT [dbo].[menu_category] ([id], [name]) VALUES (3, N'Snacks')
INSERT [dbo].[menu_category] ([id], [name]) VALUES (4, N'Others')
SET IDENTITY_INSERT [dbo].[menu_category] OFF
SET IDENTITY_INSERT [dbo].[payment] ON 

INSERT [dbo].[payment] ([id], [header_order_id], [promotion_id], [payment_type], [amount_to_pay], [amount_paid]) VALUES (1, 1, NULL, N'Cash', CAST(80500.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[payment] ([id], [header_order_id], [promotion_id], [payment_type], [amount_to_pay], [amount_paid]) VALUES (2, 2, 2, N'Credit', CAST(182447.50 AS Decimal(10, 2)), CAST(182447.50 AS Decimal(10, 2)))
INSERT [dbo].[payment] ([id], [header_order_id], [promotion_id], [payment_type], [amount_to_pay], [amount_paid]) VALUES (3, 4, 1, N'Cash', CAST(142600.00 AS Decimal(10, 2)), CAST(150000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[payment] OFF
SET IDENTITY_INSERT [dbo].[promotion] ON 

INSERT [dbo].[promotion] ([id], [code], [discount], [minimum_spent], [start_time], [end_time]) VALUES (1, N'HEMATBGT', CAST(20.00 AS Decimal(5, 2)), CAST(150000.00 AS Decimal(10, 2)), CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2019-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[promotion] ([id], [code], [discount], [minimum_spent], [start_time], [end_time]) VALUES (2, N'KUMPULRAME', CAST(5.00 AS Decimal(5, 2)), CAST(50000.00 AS Decimal(10, 2)), CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2019-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[promotion] ([id], [code], [discount], [minimum_spent], [start_time], [end_time]) VALUES (3, N'TANGGALTUA', CAST(10.00 AS Decimal(5, 2)), CAST(100000.00 AS Decimal(10, 2)), CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-31T00:00:00.000' AS DateTime))
INSERT [dbo].[promotion] ([id], [code], [discount], [minimum_spent], [start_time], [end_time]) VALUES (4, N'ABISGAJIAN', CAST(5.00 AS Decimal(5, 2)), CAST(75000.00 AS Decimal(10, 2)), CAST(N'2019-11-01T00:00:00.000' AS DateTime), CAST(N'2019-11-07T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[promotion] OFF
ALTER TABLE [dbo].[detail_order]  WITH CHECK ADD FOREIGN KEY([header_order_id])
REFERENCES [dbo].[header_order] ([id])
GO
ALTER TABLE [dbo].[detail_order]  WITH CHECK ADD FOREIGN KEY([menu_id])
REFERENCES [dbo].[menu] ([id])
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD FOREIGN KEY([menu_category_id])
REFERENCES [dbo].[menu_category] ([id])
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD FOREIGN KEY([header_order_id])
REFERENCES [dbo].[header_order] ([id])
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD FOREIGN KEY([promotion_id])
REFERENCES [dbo].[promotion] ([id])
GO
USE [master]
GO
ALTER DATABASE [DB_PC_07_Module3] SET  READ_WRITE 
GO
