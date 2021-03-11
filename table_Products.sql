USE [MYDB]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 11/3/2021 21:51:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_code] [nvarchar](10) NULL,
	[Product_name] [nvarchar](50) NULL,
	[Product_type] [nvarchar](20) NULL,
	[Description] [nvarchar](100) NULL,
	[Create_date] [datetime] NULL,
	[Modify_date] [datetime] NULL,
	[Enable] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

