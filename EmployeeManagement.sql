USE [master]
GO
/****** Object:  Database [EmployeeManagement]    Script Date: 21-10-2019 09:14:39 ******/
CREATE DATABASE [EmployeeManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmployeeManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmployeeManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmployeeManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EmployeeManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeManagement] SET QUERY_STORE = OFF
GO
USE [EmployeeManagement]
GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 21-10-2019 09:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 21-10-2019 09:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tblJobID] [int] NOT NULL,
	[tblDepartment] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[HireDate] [datetime] NULL,
	[Salary] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJob]    Script Date: 21-10-2019 09:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJob](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Job] [nvarchar](50) NOT NULL,
	[MinSalary] [decimal](18, 2) NULL,
	[MaxSalary] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tblJob] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 21-10-2019 09:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([ID], [Name], [Password]) VALUES (1, N'sandeep', N'sandeep@123')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
USE [master]
GO
ALTER DATABASE [EmployeeManagement] SET  READ_WRITE 
GO
