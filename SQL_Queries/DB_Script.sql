USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 6/9/2017 2:11:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](25) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 6/9/2017 2:11:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](25) NULL,
	[lastName] [varchar](50) NULL,
	[specialty] [varchar](25) NULL
) ON [PRIMARY]
GO
