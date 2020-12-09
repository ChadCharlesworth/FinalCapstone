USE [master]
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END


/****** Object:  Database [final_capstone]    Script Date: 12/8/2020 6:02:18 PM ******/
CREATE DATABASE [final_capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'final_capstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'final_capstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [final_capstone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [final_capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [final_capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [final_capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [final_capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [final_capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [final_capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [final_capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [final_capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [final_capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [final_capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [final_capstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [final_capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [final_capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [final_capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [final_capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [final_capstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [final_capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [final_capstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [final_capstone] SET  MULTI_USER 
GO
ALTER DATABASE [final_capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [final_capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [final_capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [final_capstone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [final_capstone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [final_capstone] SET QUERY_STORE = OFF
GO
USE [final_capstone]
GO
/****** Object:  Table [dbo].[Forum_Category]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forum_Category](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Forum_Category] PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forum_Message]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forum_Message](
	[Message_ID] [int] IDENTITY(1,1) NOT NULL,
	[Category_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Message_Title] [nvarchar](50) NOT NULL,
	[Message_Body] [nvarchar](max) NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Forum_Message] PRIMARY KEY CLUSTERED 
(
	[Message_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forum_Response]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forum_Response](
	[Response_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Message_ID] [int] NOT NULL,
	[Response_Body] [nvarchar](max) NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Forum_Response] PRIMARY KEY CLUSTERED 
(
	[Response_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pet]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pet](
	[Pet_ID] [int] IDENTITY(1,1) NOT NULL,
	[Owner_ID] [int] NOT NULL,
	[Pet_Name] [varchar](50) NOT NULL,
	[Species] [char](3) NOT NULL,
	[Breed] [varchar](25) NOT NULL,
	[Size] [varchar](25) NOT NULL,
	[Personality] [varchar](50) NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Pet] PRIMARY KEY CLUSTERED 
(
	[Pet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playdate]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playdate](
	[Playdate_ID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Date_Time] [datetime] NOT NULL,
	[Creator_User_ID] [int] NOT NULL,
	[Number_Of_Attendees] [int] NOT NULL,
	[Is_Private] [bit] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Playdate] PRIMARY KEY CLUSTERED 
(
	[Playdate_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playdate_Pet]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playdate_Pet](
	[Playdate_ID] [int] NOT NULL,
	[Pet_ID] [int] NOT NULL,
	[Approval_Status] [varchar](50) NOT NULL,
	[Accepted] [bit] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_Playdate_Pet] PRIMARY KEY CLUSTERED 
(
	[Playdate_ID] ASC,
	[Pet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 12/8/2020 6:02:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password_hash] [varchar](200) NOT NULL,
	[salt] [varchar](200) NOT NULL,
	[user_role] [varchar](50) NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Forum_Category] ADD  CONSTRAINT [DF_Forum_Category_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[Forum_Category] ADD  CONSTRAINT [DF_Forum_Category_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Forum_Message] ADD  CONSTRAINT [DF_Forum_Message_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[Forum_Message] ADD  CONSTRAINT [DF_Forum_Message_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Forum_Response] ADD  CONSTRAINT [DF_Forum_Response_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[Forum_Response] ADD  CONSTRAINT [DF_Forum_Response_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Pet] ADD  CONSTRAINT [DF_Pet_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[Pet] ADD  CONSTRAINT [DF_Pet_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Playdate] ADD  CONSTRAINT [DF_Playdate_Is_Private]  DEFAULT ((0)) FOR [Is_Private]
GO
ALTER TABLE [dbo].[Playdate] ADD  CONSTRAINT [DF_Playdate_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[Playdate] ADD  CONSTRAINT [DF_Playdate_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Playdate_Pet] ADD  CONSTRAINT [DF_Playdate_Pet_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[Playdate_Pet] ADD  CONSTRAINT [DF_Playdate_Pet_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_Created_Date]  DEFAULT (getutcdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Forum_Message]  WITH CHECK ADD  CONSTRAINT [FK_Forum_Message_Category_ID] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Forum_Category] ([Category_ID])
GO
ALTER TABLE [dbo].[Forum_Message] CHECK CONSTRAINT [FK_Forum_Message_Category_ID]
GO
ALTER TABLE [dbo].[Forum_Message]  WITH CHECK ADD  CONSTRAINT [FK_Forum_Message_User_ID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[Forum_Message] CHECK CONSTRAINT [FK_Forum_Message_User_ID]
GO
ALTER TABLE [dbo].[Forum_Response]  WITH CHECK ADD  CONSTRAINT [FK_Forum_Response_Message_ID] FOREIGN KEY([Message_ID])
REFERENCES [dbo].[Forum_Message] ([Message_ID])
GO
ALTER TABLE [dbo].[Forum_Response] CHECK CONSTRAINT [FK_Forum_Response_Message_ID]
GO
ALTER TABLE [dbo].[Forum_Response]  WITH CHECK ADD  CONSTRAINT [FK_Forum_Response_User_ID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[Forum_Response] CHECK CONSTRAINT [FK_Forum_Response_User_ID]
GO
ALTER TABLE [dbo].[Pet]  WITH CHECK ADD  CONSTRAINT [FK_Pet_Owner_ID] FOREIGN KEY([Owner_ID])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[Pet] CHECK CONSTRAINT [FK_Pet_Owner_ID]
GO
ALTER TABLE [dbo].[Playdate]  WITH CHECK ADD  CONSTRAINT [FK_Playdate_Creator_User_ID] FOREIGN KEY([Creator_User_ID])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[Playdate] CHECK CONSTRAINT [FK_Playdate_Creator_User_ID]
GO
ALTER TABLE [dbo].[Playdate_Pet]  WITH CHECK ADD  CONSTRAINT [FK_Playdate_Pet_Pet] FOREIGN KEY([Pet_ID])
REFERENCES [dbo].[Pet] ([Pet_ID])
GO
ALTER TABLE [dbo].[Playdate_Pet] CHECK CONSTRAINT [FK_Playdate_Pet_Pet]
GO
ALTER TABLE [dbo].[Playdate_Pet]  WITH CHECK ADD  CONSTRAINT [FK_Playdate_Pet_Playdate] FOREIGN KEY([Playdate_ID])
REFERENCES [dbo].[Playdate] ([Playdate_ID])
GO
ALTER TABLE [dbo].[Playdate_Pet] CHECK CONSTRAINT [FK_Playdate_Pet_Playdate]
GO
ALTER TABLE [dbo].[Playdate_Pet]  WITH CHECK ADD  CONSTRAINT [CK_Playdate_Pet_Approval_Status] CHECK  (([Approval_Status]='Approved' OR [Approval_Status]='Pending' OR [Approval_Status]='Denied'))
GO
ALTER TABLE [dbo].[Playdate_Pet] CHECK CONSTRAINT [CK_Playdate_Pet_Approval_Status]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Constrain Approval_Status to ''Approved'', ''Pending'', or ''Denied'' for the owner to approve/deny, and for the guest to be able to see the playdate or not.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playdate_Pet', @level2type=N'CONSTRAINT',@level2name=N'CK_Playdate_Pet_Approval_Status'
GO

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

USE [master]
GO
ALTER DATABASE [final_capstone] SET  READ_WRITE 
GO

