USE [AdventureWorks2008]
GO

/****** Object:  Table [HumanResources].[EmployeePhoto]    Script Date: 03/20/2015 05:18:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [HumanResources].[EmployeePhoto](
	[BusinessEntityID] [int] NOT NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_EmployeePhoto] PRIMARY KEY CLUSTERED 
(
	[BusinessEntityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
