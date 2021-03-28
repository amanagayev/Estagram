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
	[description] [nvarchar](max) NULL,
	[likes] [int] DEFAULT 0 NULL,
	[url] [text] NOT NULL
)

CREATE TABLE [dbo].[Comments](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[post_id] [int] NOT NULL,
	[username] [nchar](30) NOT NULL,
	[comment] [nvarchar](max) NOT NULL
)

![EstagramDB - Diagram_0 SSMS](https://user-images.githubusercontent.com/59646712/112737352-07cbc700-8f6b-11eb-991e-23dcefe229b6.png)
