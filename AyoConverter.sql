USE [master]
GO
/****** Object:  Database [Ayo]    Script Date: 2021/11/18 10:26:28 PM ******/
CREATE DATABASE [Ayo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ayo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Ayo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ayo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Ayo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Ayo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ayo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ayo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ayo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ayo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ayo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ayo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ayo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ayo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ayo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ayo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ayo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ayo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ayo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ayo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ayo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ayo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ayo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ayo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ayo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ayo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ayo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ayo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ayo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ayo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ayo] SET  MULTI_USER 
GO
ALTER DATABASE [Ayo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ayo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ayo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ayo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ayo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ayo] SET QUERY_STORE = OFF
GO
USE [Ayo]
GO
/****** Object:  Table [dbo].[MetricFormula]    Script Date: 2021/11/18 10:26:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetricFormula](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NULL,
	[TypeId] [uniqueidentifier] NULL,
	[UnitFromId] [uniqueidentifier] NULL,
	[UnitToId] [uniqueidentifier] NULL,
	[Formula] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_MetricFormula] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetricType]    Script Date: 2021/11/18 10:26:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetricType](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_MetricType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetricUnit]    Script Date: 2021/11/18 10:26:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetricUnit](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[TypeId] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_MetricUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MetricFormula] ([Id], [Name], [TypeId], [UnitFromId], [UnitToId], [Formula], [IsActive], [CreatedDate]) VALUES (N'9af1e3a3-b3b3-4fa3-8a44-27ddb4fc5c7f', N'Kilometer - Meter', N'e73b8acd-abc4-436b-9f23-9f381bbe2683', N'8c9ca04b-9061-45bb-997c-f013a01d79d2', N'e5686472-ec24-4c74-ba1e-cb5a1157304e', N'(value*1000)', 1, CAST(N'2021-11-18T22:17:16.083' AS DateTime))
INSERT [dbo].[MetricFormula] ([Id], [Name], [TypeId], [UnitFromId], [UnitToId], [Formula], [IsActive], [CreatedDate]) VALUES (N'b432fdfb-5e17-4ddb-9887-490bce147db8', N'Minute - Second', N'bc22f44c-273c-4253-9a08-83b1c228dc0c', N'5e61ca23-6b51-4c61-868c-dea1fda63ebe', N'14bec5c1-ada8-4d53-a202-847c0cb67437', N'(value*60)', 1, CAST(N'2021-11-18T22:22:41.460' AS DateTime))
INSERT [dbo].[MetricFormula] ([Id], [Name], [TypeId], [UnitFromId], [UnitToId], [Formula], [IsActive], [CreatedDate]) VALUES (N'6f17b07b-c73e-4ade-97ec-49114075e5f9', N'Second - Minute', N'bc22f44c-273c-4253-9a08-83b1c228dc0c', N'14bec5c1-ada8-4d53-a202-847c0cb67437', N'5e61ca23-6b51-4c61-868c-dea1fda63ebe', N'(value/60)', 1, CAST(N'2021-11-18T22:22:41.457' AS DateTime))
INSERT [dbo].[MetricFormula] ([Id], [Name], [TypeId], [UnitFromId], [UnitToId], [Formula], [IsActive], [CreatedDate]) VALUES (N'82976642-3dbe-4319-9c47-5aa7520fa846', N'Fahrenheit - Celcuis', N'fa4b5538-8be3-4065-a4ca-d114aba0c22d', N'dd7fea03-f1c0-49b2-82a7-e5ae33c8d9c0', N'6db4cc52-dcd7-4c8f-8254-d2eb4d5ad108', N'(value - 32) * 5/9', 1, CAST(N'2021-11-18T00:01:23.720' AS DateTime))
INSERT [dbo].[MetricFormula] ([Id], [Name], [TypeId], [UnitFromId], [UnitToId], [Formula], [IsActive], [CreatedDate]) VALUES (N'66fb5c7b-7d0d-4b87-874b-b7d6faab2bd7', N'Meter - Kilometer', N'e73b8acd-abc4-436b-9f23-9f381bbe2683', N'e5686472-ec24-4c74-ba1e-cb5a1157304e', N'8c9ca04b-9061-45bb-997c-f013a01d79d2', N'(value/1000)', 1, CAST(N'2021-11-18T22:17:16.070' AS DateTime))
INSERT [dbo].[MetricFormula] ([Id], [Name], [TypeId], [UnitFromId], [UnitToId], [Formula], [IsActive], [CreatedDate]) VALUES (N'84a1e94f-b40f-42a0-ba6c-d4e409192fad', N'Celcuis - Fahrenheit', N'fa4b5538-8be3-4065-a4ca-d114aba0c22d', N'6db4cc52-dcd7-4c8f-8254-d2eb4d5ad108', N'dd7fea03-f1c0-49b2-82a7-e5ae33c8d9c0', N'(value * 9/5) + 32', 1, CAST(N'2021-11-18T00:01:23.717' AS DateTime))
INSERT [dbo].[MetricType] ([Id], [Name], [IsActive], [CreatedDate]) VALUES (N'bc22f44c-273c-4253-9a08-83b1c228dc0c', N'Time', 1, CAST(N'2021-11-18T22:28:53.303' AS DateTime))
INSERT [dbo].[MetricType] ([Id], [Name], [IsActive], [CreatedDate]) VALUES (N'e73b8acd-abc4-436b-9f23-9f381bbe2683', N'Length', 1, CAST(N'2021-11-18T22:29:11.830' AS DateTime))
INSERT [dbo].[MetricType] ([Id], [Name], [IsActive], [CreatedDate]) VALUES (N'fa4b5538-8be3-4065-a4ca-d114aba0c22d', N'Temperature', 1, CAST(N'2021-11-18T22:28:36.990' AS DateTime))
INSERT [dbo].[MetricUnit] ([Id], [Name], [TypeId], [IsActive], [CreatedDate]) VALUES (N'14bec5c1-ada8-4d53-a202-847c0cb67437', N'Second', N'bc22f44c-273c-4253-9a08-83b1c228dc0c', 1, CAST(N'2021-11-18T22:22:37.727' AS DateTime))
INSERT [dbo].[MetricUnit] ([Id], [Name], [TypeId], [IsActive], [CreatedDate]) VALUES (N'e5686472-ec24-4c74-ba1e-cb5a1157304e', N'Meter', N'e73b8acd-abc4-436b-9f23-9f381bbe2683', 1, CAST(N'2021-11-18T22:20:33.337' AS DateTime))
INSERT [dbo].[MetricUnit] ([Id], [Name], [TypeId], [IsActive], [CreatedDate]) VALUES (N'6db4cc52-dcd7-4c8f-8254-d2eb4d5ad108', N'Celcuis', N'fa4b5538-8be3-4065-a4ca-d114aba0c22d', 1, CAST(N'2021-11-18T22:34:24.330' AS DateTime))
INSERT [dbo].[MetricUnit] ([Id], [Name], [TypeId], [IsActive], [CreatedDate]) VALUES (N'5e61ca23-6b51-4c61-868c-dea1fda63ebe', N'Minute', N'bc22f44c-273c-4253-9a08-83b1c228dc0c', 1, CAST(N'2021-11-18T22:22:37.730' AS DateTime))
INSERT [dbo].[MetricUnit] ([Id], [Name], [TypeId], [IsActive], [CreatedDate]) VALUES (N'dd7fea03-f1c0-49b2-82a7-e5ae33c8d9c0', N'Fahrenheit', N'fa4b5538-8be3-4065-a4ca-d114aba0c22d', 1, CAST(N'2021-11-18T22:34:56.003' AS DateTime))
INSERT [dbo].[MetricUnit] ([Id], [Name], [TypeId], [IsActive], [CreatedDate]) VALUES (N'8c9ca04b-9061-45bb-997c-f013a01d79d2', N'Kilometer', N'e73b8acd-abc4-436b-9f23-9f381bbe2683', 1, CAST(N'2021-11-18T22:20:33.367' AS DateTime))
ALTER TABLE [dbo].[MetricFormula] ADD  CONSTRAINT [DF_MetricFormula_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MetricFormula] ADD  CONSTRAINT [DF_MetricFormula_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MetricFormula] ADD  CONSTRAINT [DF_MetricFormula_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[MetricType] ADD  CONSTRAINT [DF_MetricType_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MetricType] ADD  CONSTRAINT [DF_MetricType_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[MetricUnit] ADD  CONSTRAINT [DF_MetricUnit_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MetricUnit] ADD  CONSTRAINT [DF_MetricUnit_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MetricUnit] ADD  CONSTRAINT [DF_MetricUnit_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[MetricFormula]  WITH CHECK ADD  CONSTRAINT [FK_MetricFormula_MetricType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[MetricType] ([Id])
GO
ALTER TABLE [dbo].[MetricFormula] CHECK CONSTRAINT [FK_MetricFormula_MetricType]
GO
ALTER TABLE [dbo].[MetricFormula]  WITH CHECK ADD  CONSTRAINT [FK_MetricFormula_MetricUnit] FOREIGN KEY([UnitFromId])
REFERENCES [dbo].[MetricUnit] ([Id])
GO
ALTER TABLE [dbo].[MetricFormula] CHECK CONSTRAINT [FK_MetricFormula_MetricUnit]
GO
ALTER TABLE [dbo].[MetricFormula]  WITH CHECK ADD  CONSTRAINT [FK_MetricFormula_MetricUnit1] FOREIGN KEY([UnitToId])
REFERENCES [dbo].[MetricUnit] ([Id])
GO
ALTER TABLE [dbo].[MetricFormula] CHECK CONSTRAINT [FK_MetricFormula_MetricUnit1]
GO
ALTER TABLE [dbo].[MetricUnit]  WITH CHECK ADD  CONSTRAINT [FK_MetricUnit_MetricType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[MetricType] ([Id])
GO
ALTER TABLE [dbo].[MetricUnit] CHECK CONSTRAINT [FK_MetricUnit_MetricType]
GO
USE [master]
GO
ALTER DATABASE [Ayo] SET  READ_WRITE 
GO
