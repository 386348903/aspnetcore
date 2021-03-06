USE [master]
GO
/****** Object:  Database [DataBase]    Script Date: 03/07/2017 16:40:23 ******/
CREATE DATABASE [DataBase] ON  PRIMARY 
( NAME = N'DataBase', FILENAME = N'D:\桌面\项目\aspnetcore\Dbo\DataBase.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataBase_log', FILENAME = N'D:\桌面\项目\aspnetcore\Dbo\DataBase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataBase] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DataBase] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DataBase] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DataBase] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DataBase] SET ARITHABORT OFF
GO
ALTER DATABASE [DataBase] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DataBase] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DataBase] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DataBase] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DataBase] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DataBase] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DataBase] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DataBase] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DataBase] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DataBase] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DataBase] SET  DISABLE_BROKER
GO
ALTER DATABASE [DataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DataBase] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DataBase] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DataBase] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DataBase] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DataBase] SET  READ_WRITE
GO
ALTER DATABASE [DataBase] SET RECOVERY FULL
GO
ALTER DATABASE [DataBase] SET  MULTI_USER
GO
ALTER DATABASE [DataBase] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DataBase] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataBase', N'ON'
GO
USE [DataBase]
GO
/****** Object:  Table [dbo].[Userone]    Script Date: 03/07/2017 16:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[pwd] [nvarchar](max) NULL,
	[time] [datetime] NULL,
	[role] [nvarchar](max) NULL,
 CONSTRAINT [PK_Userone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Userone] ON
INSERT [dbo].[Userone] ([id], [name], [pwd], [time], [role]) VALUES (3, N'admin', N'!#/)zW??C?JJ??', CAST(0x0000A6EF00000000 AS DateTime), N'管理员')
INSERT [dbo].[Userone] ([id], [name], [pwd], [time], [role]) VALUES (11, N'gx001', N'!#/)zW??C?JJ??', CAST(0x0000A72E016105D1 AS DateTime), N'用户')
INSERT [dbo].[Userone] ([id], [name], [pwd], [time], [role]) VALUES (12, N'gx002', N'!#/)zW??C?JJ??', CAST(0x0000A72E01623501 AS DateTime), N'用户')
SET IDENTITY_INSERT [dbo].[Userone] OFF
/****** Object:  Table [dbo].[user_login]    Script Date: 03/07/2017 16:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[login] [nvarchar](max) NULL,
	[token] [nvarchar](max) NULL,
	[time] [datetime] NULL,
 CONSTRAINT [PK_user_login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[user_login] ON
INSERT [dbo].[user_login] ([id], [name], [login], [token], [time]) VALUES (43, N'gx002', N'1984305', N'1230377', CAST(0x0000A72E01651FD3 AS DateTime))
INSERT [dbo].[user_login] ([id], [name], [login], [token], [time]) VALUES (47, N'gx001', N'2693645', N'4450308', CAST(0x0000A72E016CD425 AS DateTime))
INSERT [dbo].[user_login] ([id], [name], [login], [token], [time]) VALUES (49, N'admin', N'5794815', N'4708147', CAST(0x0000A72E016D444D AS DateTime))
SET IDENTITY_INSERT [dbo].[user_login] OFF
/****** Object:  Table [dbo].[bk]    Script Date: 03/07/2017 16:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[sqly] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[zw] [nvarchar](max) NULL,
	[dw] [nvarchar](max) NULL,
	[jsxq] [nvarchar](max) NULL,
	[time] [datetime] NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_bk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bk] ON
INSERT [dbo].[bk] ([id], [uid], [sqly], [name], [zw], [dw], [jsxq], [time], [type]) VALUES (12, 11, N'我有一个梦想，长大后当一名科学家。', N'徐某某', N'学生', N'树人大学', N'asp.net,ajax,jq,.net core,c++,java', CAST(0x0000A72E01617E2C AS DateTime), 1)
INSERT [dbo].[bk] ([id], [uid], [sqly], [name], [zw], [dw], [jsxq], [time], [type]) VALUES (13, 12, N'我也有一个梦想，那就是上大学。别问我大学是谁！', N'邹某某', N'学生', N'树人', N'java,asp,.net', CAST(0x0000A72E01629414 AS DateTime), -1)
SET IDENTITY_INSERT [dbo].[bk] OFF
/****** Object:  View [dbo].[v_bk]    Script Date: 03/07/2017 16:40:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_bk]
AS
SELECT     dbo.bk.id, dbo.Userone.name, dbo.bk.sqly, dbo.bk.name AS xm, dbo.bk.zw, dbo.bk.dw, dbo.bk.jsxq, dbo.bk.time, dbo.bk.type, dbo.bk.uid
FROM         dbo.bk INNER JOIN
                      dbo.Userone ON dbo.bk.uid = dbo.Userone.id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "bk"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 205
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Userone"
            Begin Extent = 
               Top = 3
               Left = 272
               Bottom = 206
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_bk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_bk'
GO
