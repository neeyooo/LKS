USE [master]
GO
/****** Object:  Database [DB_PC_07_Module1]    Script Date: 11/7/2019 8:37:32 AM ******/
CREATE DATABASE [DB_PC_07_Module1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_PC_07_Module1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_PC_07_Module1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_PC_07_Module1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DB_PC_07_Module1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB_PC_07_Module1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_PC_07_Module1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_PC_07_Module1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_PC_07_Module1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_PC_07_Module1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_PC_07_Module1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_PC_07_Module1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_PC_07_Module1] SET  MULTI_USER 
GO
ALTER DATABASE [DB_PC_07_Module1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_PC_07_Module1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_PC_07_Module1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_PC_07_Module1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_PC_07_Module1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_PC_07_Module1] SET QUERY_STORE = OFF
GO
USE [DB_PC_07_Module1]
GO
/****** Object:  Table [dbo].[detail_order]    Script Date: 11/7/2019 8:37:32 AM ******/
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
 CONSTRAINT [PK_detail_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[header_order]    Script Date: 11/7/2019 8:37:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[header_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_made_time] [datetime] NOT NULL,
	[table_number] [int] NOT NULL,
	[customer_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_header_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 11/7/2019 8:37:32 AM ******/
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
	[is_favorite] [bit] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu_category]    Script Date: 11/7/2019 8:37:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_menu_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 11/7/2019 8:37:32 AM ******/
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
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotion]    Script Date: 11/7/2019 8:37:32 AM ******/
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
 CONSTRAINT [PK_promotion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[detail_order]  WITH CHECK ADD  CONSTRAINT [FK_detail_order_header_order] FOREIGN KEY([header_order_id])
REFERENCES [dbo].[header_order] ([id])
GO
ALTER TABLE [dbo].[detail_order] CHECK CONSTRAINT [FK_detail_order_header_order]
GO
ALTER TABLE [dbo].[detail_order]  WITH CHECK ADD  CONSTRAINT [FK_detail_order_menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[menu] ([id])
GO
ALTER TABLE [dbo].[detail_order] CHECK CONSTRAINT [FK_detail_order_menu]
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD  CONSTRAINT [FK_menu_menu_category] FOREIGN KEY([menu_category_id])
REFERENCES [dbo].[menu_category] ([id])
GO
ALTER TABLE [dbo].[menu] CHECK CONSTRAINT [FK_menu_menu_category]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_header_order] FOREIGN KEY([header_order_id])
REFERENCES [dbo].[header_order] ([id])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_header_order]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [FK_payment_promotion] FOREIGN KEY([promotion_id])
REFERENCES [dbo].[promotion] ([id])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [FK_payment_promotion]
GO
USE [master]
GO
ALTER DATABASE [DB_PC_07_Module1] SET  READ_WRITE 
GO
