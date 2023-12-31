USE [master]
GO
/****** Object:  Database [PC_01]    Script Date: 18/08/2021 10:05:51 ******/
CREATE DATABASE [PC_01]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PC_01', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PC_01.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PC_01_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PC_01_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PC_01] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PC_01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PC_01] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PC_01] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PC_01] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PC_01] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PC_01] SET ARITHABORT OFF 
GO
ALTER DATABASE [PC_01] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PC_01] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PC_01] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PC_01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PC_01] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PC_01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PC_01] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PC_01] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PC_01] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PC_01] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PC_01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PC_01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PC_01] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PC_01] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PC_01] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PC_01] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PC_01] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PC_01] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PC_01] SET  MULTI_USER 
GO
ALTER DATABASE [PC_01] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PC_01] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PC_01] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PC_01] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PC_01] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PC_01] SET QUERY_STORE = OFF
GO
USE [PC_01]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[password] [varchar](64) NOT NULL,
	[phone_number] [varchar](200) NOT NULL,
	[address] [varchar](200) NOT NULL,
	[date_of_birth] [date] NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HourlyRates]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HourlyRates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[membership_id] [int] NOT NULL,
	[vehicle_type_id] [int] NOT NULL,
	[value] [decimal](10, 2) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_HourlyRates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[membership_id] [int] NOT NULL,
	[name] [varchar](200) NOT NULL,
	[email] [varchar](200) NOT NULL,
	[phone_number] [varchar](200) NOT NULL,
	[address] [varchar](200) NOT NULL,
	[date_of_birth] [date] NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membership]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParkingData]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[license_plate] [varchar](20) NULL,
	[vehicle_id] [int] NULL,
	[employee_id] [int] NOT NULL,
	[hourly_rates_id] [int] NOT NULL,
	[datetime_in] [datetime] NOT NULL,
	[datetime_out] [datetime] NOT NULL,
	[amount_to_pay] [decimal](10, 2) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_ParkingData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vehicle_type_id] [int] NOT NULL,
	[member_id] [int] NOT NULL,
	[license_plate] [varchar](20) NOT NULL,
	[notes] [varchar](200) NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 18/08/2021 10:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[last_updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (1, N'Laurel Vang', N'pellentesque.massa.lobortis@fringillacursus.net', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'1-181-155-6849', N'Ap #735-828 Magna. Rd.', CAST(N'1989-04-19' AS Date), N'Female', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (2, N'Daniel Cervantes', N'Praesent.luctus@egestasSed.ca', N'7dee848708b11ad455f358d04d47a70065b37dc4423d744fa9eab81fb1086d67', N'1-146-372-5842', N'Ap #118-7803 A St.', CAST(N'1985-07-24' AS Date), N'Female', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (3, N'Sophia Cooley', N'tellus.lorem.eu@suscipit.edu', N'da3f0ee9e00124a839b456e93038310d935de13f254a2762212e57b7c28dbfb1', N'1-691-593-4518', N'P.O. Box 918  7534 Sit Ave', CAST(N'1988-05-16' AS Date), N'Female', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (4, N'Paula Sanford', N'ut.eros@accumsan.com', N'a7a65b5c533b6bb9df0a0f31f236b2c3adbd19df28d9e6763d4c754db9dbcdbb', N'1-120-886-4114', N'Ap #594-3475 Lorem Avenue', CAST(N'1980-10-01' AS Date), N'Male', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (5, N'Anthony Mcintosh', N'ipsum@non.com', N'86e4a97ffaebe688393983536ae4d160085c4251f39d006849817da9263d13bc', N'1-858-819-4192', N'P.O. Box 712  1123 Sem Av.', CAST(N'1982-01-17' AS Date), N'Male', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (6, N'Giacomo Merrill', N'Nunc.sollicitudin.commodo@pellentesque.net', N'89fce7ab67a52f8e3187525d5e5635ccc3cff122324f174c9296a7cf7016400c', N'1-597-208-4825', N'P.O. Box 141  1506 Cras Ave', CAST(N'1991-06-12' AS Date), N'Male', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (7, N'Clinton Rhodes', N'ridiculus.mus@purusactellus.co.uk', N'e759a5fbb2476c0e95d86901d0a8ce0727cdedc89182bd6c747b0a3ec7df5781', N'1-858-735-8932', N'378-3448 Aliquet Rd.', CAST(N'1997-03-15' AS Date), N'Female', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (8, N'Howard Peters', N'enim.Curabitur@rutrumurna.com', N'273cce6c2b6144cdaaeea059c33989511ee4bc3fca9d83ab62aa1474948c6362', N'1-938-432-2020', N'3595 Justo Avenue', CAST(N'1998-07-18' AS Date), N'Male', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (9, N'Eagan Griffin', N'tempor.est.ac@dictumsapien.edu', N'b29b15b020c7397bafaffc6069486173e0b80fad582b619ed60fc749c8af7947', N'1-294-696-7151', N'9008 Dignissim. Street', CAST(N'1983-03-10' AS Date), N'Male', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Employee] ([id], [name], [email], [password], [phone_number], [address], [date_of_birth], [gender], [created_at], [last_updated_at], [deleted_at]) VALUES (10, N'Aristotle Rivers', N'erat.volutpat.Nulla@cursuset.net', N'ef8f3125dbddb62a2053fa74c4422907c0695bccf73445471f80b2324d12b852', N'1-823-449-5494', N'Ap #322-4296 Cras Rd.', CAST(N'1996-06-20' AS Date), N'Female', CAST(N'2021-08-18T09:59:48.220' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Membership] ON 

INSERT [dbo].[Membership] ([id], [name], [created_at], [last_updated_at], [deleted_at]) VALUES (1, N'Non Member', CAST(N'2021-08-18T10:01:28.823' AS DateTime), NULL, NULL)
INSERT [dbo].[Membership] ([id], [name], [created_at], [last_updated_at], [deleted_at]) VALUES (2, N'Regular', CAST(N'2021-08-18T10:01:28.823' AS DateTime), NULL, NULL)
INSERT [dbo].[Membership] ([id], [name], [created_at], [last_updated_at], [deleted_at]) VALUES (3, N'VIP', CAST(N'2021-08-18T10:01:28.823' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Membership] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleType] ON 

INSERT [dbo].[VehicleType] ([id], [name], [created_at], [last_updated_at], [deleted_at]) VALUES (1, N'Motorcycle', CAST(N'2021-08-18T10:04:12.500' AS DateTime), NULL, NULL)
INSERT [dbo].[VehicleType] ([id], [name], [created_at], [last_updated_at], [deleted_at]) VALUES (2, N'Car', CAST(N'2021-08-18T10:04:12.500' AS DateTime), NULL, NULL)
INSERT [dbo].[VehicleType] ([id], [name], [created_at], [last_updated_at], [deleted_at]) VALUES (3, N'Truck', CAST(N'2021-08-18T10:04:12.500' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[HourlyRates] ADD  CONSTRAINT [DF_HourlyRates_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Membership] ADD  CONSTRAINT [DF_Membership_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[VehicleType] ADD  CONSTRAINT [DF_VehicleType_created_at]  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[HourlyRates]  WITH CHECK ADD  CONSTRAINT [FK_HourlyRates_Membership] FOREIGN KEY([membership_id])
REFERENCES [dbo].[Membership] ([id])
GO
ALTER TABLE [dbo].[HourlyRates] CHECK CONSTRAINT [FK_HourlyRates_Membership]
GO
ALTER TABLE [dbo].[HourlyRates]  WITH CHECK ADD  CONSTRAINT [FK_HourlyRates_VehicleType] FOREIGN KEY([vehicle_type_id])
REFERENCES [dbo].[VehicleType] ([id])
GO
ALTER TABLE [dbo].[HourlyRates] CHECK CONSTRAINT [FK_HourlyRates_VehicleType]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Membership] FOREIGN KEY([membership_id])
REFERENCES [dbo].[Membership] ([id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Membership]
GO
ALTER TABLE [dbo].[ParkingData]  WITH CHECK ADD  CONSTRAINT [FK_ParkingData_Employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[ParkingData] CHECK CONSTRAINT [FK_ParkingData_Employee]
GO
ALTER TABLE [dbo].[ParkingData]  WITH CHECK ADD  CONSTRAINT [FK_ParkingData_HourlyRates] FOREIGN KEY([hourly_rates_id])
REFERENCES [dbo].[HourlyRates] ([id])
GO
ALTER TABLE [dbo].[ParkingData] CHECK CONSTRAINT [FK_ParkingData_HourlyRates]
GO
ALTER TABLE [dbo].[ParkingData]  WITH CHECK ADD  CONSTRAINT [FK_ParkingData_Vehicle] FOREIGN KEY([vehicle_id])
REFERENCES [dbo].[Vehicle] ([id])
GO
ALTER TABLE [dbo].[ParkingData] CHECK CONSTRAINT [FK_ParkingData_Vehicle]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Member] FOREIGN KEY([member_id])
REFERENCES [dbo].[Member] ([id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Member]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleType] FOREIGN KEY([vehicle_type_id])
REFERENCES [dbo].[VehicleType] ([id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleType]
GO
USE [master]
GO
ALTER DATABASE [PC_01] SET  READ_WRITE 
GO
