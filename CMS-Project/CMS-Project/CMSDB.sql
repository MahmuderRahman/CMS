USE [master]
GO
CREATE DATABASE [CMSDB]

GO
USE [CMSDB]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 12/25/2017 3:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNo] [nvarchar](50) NULL,
	[BankName] [nvarchar](50) NULL,
	[Limit] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/25/2017 3:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/25/2017 3:33:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cards] ON 

INSERT [dbo].[Cards] ([Id], [CardNo], [BankName], [Limit]) VALUES (1, N'ss12365478', N'EBL', CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[Cards] ([Id], [CardNo], [BankName], [Limit]) VALUES (2, N'ms02145986', N'Datch Bangla', CAST(50000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Cards] OFF
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([Id], [CardId], [UserId], [Amount], [Description], [Date]) VALUES (1, 1, 1, CAST(20000 AS Decimal(18, 0)), N'test', CAST(0xAF3D0B00 AS Date))
INSERT [dbo].[Transactions] ([Id], [CardId], [UserId], [Amount], [Description], [Date]) VALUES (2, 1, 1, CAST(20000 AS Decimal(18, 0)), N'test', CAST(0xAF3D0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Address], [ContactNo], [Email]) VALUES (1, N'Mahmud', N'Dhaka', N'01685926589', N'm@gmail.com')
INSERT [dbo].[Users] ([Id], [Name], [Address], [ContactNo], [Email]) VALUES (2, N'Hasan', N'Mirpur', N'01685920365', N'h@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Cards]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
USE [master]
GO
ALTER DATABASE [CMSDB] SET  READ_WRITE 
GO
