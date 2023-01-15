CREATE DATABASE [example_db]
GO

USE [example_db]
GO

/************/

CREATE TABLE USERS(
	[USER_ID] [nvarchar](50) NOT NULL PRIMARY KEY,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EMAIL] [nvarchar](50) NOT NULL,
	[PASS] [nvarchar](50) NOT NULL,
	[USER_TYPE] [varchar](1) NOT NULL,
)
GO

/************/


create table Files
(
	[FILE_ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TITLE] [nvarchar](100) NOT NULL,
	[UPLOAD_DATE] [datetime] NOT NULL,
	[USER_ID] [nvarchar](50) NOT NULL FOREIGN KEY REFERENCES USERS(USER_ID),
	[PATH] [varchar](100) NOT NULL,
	[NOTES] [nvarchar](100) NULL,
	[DOWNLOAD] [int] NOT NULL,
);
GO