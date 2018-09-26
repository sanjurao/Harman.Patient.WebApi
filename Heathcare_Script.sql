IF  NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'HealthCareMainDB')
    BEGIN
        CREATE DATABASE [HealthCareMainDB];
END;

USE [HealthCareMainDB]
GO

/****** Object:  Table [dbo].[tblCodeDesc]    Script Date: 9/23/2018 9:37:04 AM ******/
IF EXISTS(SELECT 1 FROM sys.objects AS O WHERE O.name = 'tblCodeDesc' AND O.[type] = 'U')
    DROP TABLE [dbo].[tblCodeDesc]
GO

/****** Object:  Table [dbo].[tblCodeDesc]    Script Date: 9/23/2018 9:37:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCodeDesc](
	[CodeTableId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[InsertDate] [date] NULL,
	[Updatedate] [nchar](10) NULL,
 CONSTRAINT [PK_tblCodeDesc] PRIMARY KEY CLUSTERED 
(
	[CodeTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF EXISTS (SELECT 1  FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_tblTelephone_tblPatient') AND parent_object_id = OBJECT_ID(N'dbo.tblTelephone'))
  ALTER TABLE [dbo].[tblTelephone] DROP CONSTRAINT [FK_tblTelephone_tblPatient]
GO


/****** Object:  Table [dbo].[tblPatient]    Script Date: 9/23/2018 11:34:17 PM ******/
IF EXISTS(SELECT 1 FROM sys.objects AS O WHERE O.name = 'tblPatient' AND O.[type] = 'U')
   DROP TABLE [dbo].[tblPatient]
GO


CREATE TABLE [dbo].[tblPatient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[SurName] [nvarchar](100) NOT NULL,
	[Gender] [int] NOT NULL,
	[DOB] [date] NULL,
	[InsertDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tblPatient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[tblTelephone]    Script Date: 9/23/2018 10:00:45 AM ******/
IF EXISTS(SELECT 1 FROM sys.objects AS O WHERE O.name = 'tblTelephone' AND O.[type] = 'U')
   DROP TABLE [dbo].[tblTelephone]
GO

USE [HealthCareMainDB]
GO

/****** Object:  Table [dbo].[tblTelephone]    Script Date: 9/23/2018 11:34:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblTelephone](
	[TelephoneId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NULL,
	[CodeTableId] [int] NULL,
	[PatientId] [int] NULL,
	[InsertDate] [date] NULL,
	[UpdateDate] [date] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[TelephoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblTelephone]  WITH CHECK ADD  CONSTRAINT [FK_tblTelephone_tblPatient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[tblPatient] ([PatientId])
GO

ALTER TABLE [dbo].[tblTelephone] CHECK CONSTRAINT [FK_tblTelephone_tblPatient]
GO


