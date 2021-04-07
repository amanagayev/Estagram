To Create Database:
_________________

USE [master]

CREATE DATABASE [EstagramDB]

_________________

use [EstagramDB]

_________________

CREATE TABLE [dbo].[Posts](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[picture] [text] NOT NULL,
	[description] [nvarchar](max) NULL
)

CREATE TABLE [dbo].[Comments](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[post_id] [int] NOT NULL,
	[username] [nchar](30) NOT NULL,
	[comment1] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[Likes](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[post_id] [int] NOT NULL,
	[likes] [int] DEFAULT 0 NOT NULL
)

![db](https://user-images.githubusercontent.com/59646712/113355691-d297ee00-9349-11eb-9f26-13599e174c49.png)
