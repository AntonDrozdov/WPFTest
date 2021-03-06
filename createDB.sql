USE [Store]
GO
/****** Object:  Table [dbo].[Goods]    Script Date: 29.10.2015 10:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL CONSTRAINT [DF_Goods_RegistrationDate]  DEFAULT (getdate()),
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
