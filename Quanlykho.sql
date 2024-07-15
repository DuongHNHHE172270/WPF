USE [master]
GO

CREATE DATABASE [QuanLyKhoDienThoai]
GO
USE [QuanLyKhoDienThoai]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input](
	[Id] [nvarchar](128) NOT NULL,
	[DateInput] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputInfo]    Script Date: 26-Feb-18 6:29:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputInfo](
	[Id] [nvarchar](128) NOT NULL,
	[IdObject] [nvarchar](128) NOT NULL,
	[IdInput] [nvarchar](128) NOT NULL,
	[Count] [int] NULL,
	[InputPrice] [float] NULL,
	[OutputPrice] [float] NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Object]    Script Date: 26-Feb-18 6:29:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[Id] [nvarchar](128) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[IdSuplier] [int] NOT NULL,
	[Status] nvarchar(255)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Output](
	[Id] [nvarchar](128) NOT NULL,
	[DateOutput] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputInfo](
	[Id] [nvarchar](128) NOT NULL,
	[IdObject] [nvarchar](128) NOT NULL,
	[IdOutputInfo] [nvarchar](128) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[Count] [int] NULL,
	[Status] [nvarchar](max) NULL,
	foreign key (Id) references OutPut(Id),
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[Status] nvarchar(255)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[IdRole] [int] NOT NULL,
	Status nvarchar(255)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'RongK9', N'admin', N'123456', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nhân viên', N'staff', N'123456', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF

-- Add default values for InputInfo table
ALTER TABLE [dbo].[InputInfo] ADD DEFAULT ((0)) FOR [InputPrice]
ALTER TABLE [dbo].[InputInfo] ADD DEFAULT ((0)) FOR [OutputPrice]

-- Add foreign keys
ALTER TABLE [dbo].[InputInfo] WITH CHECK ADD FOREIGN KEY([IdInput]) REFERENCES [dbo].[Input] ([Id])
ALTER TABLE [dbo].[InputInfo] WITH CHECK ADD FOREIGN KEY([IdObject]) REFERENCES [dbo].[Object] ([Id])
ALTER TABLE [dbo].[InputInfo] WITH CHECK ADD FOREIGN KEY([IdUser]) REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[Object] WITH CHECK ADD FOREIGN KEY([IdSuplier]) REFERENCES [dbo].[Suplier] ([Id])

ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdCustomer]) REFERENCES [dbo].[Customer] ([Id])
ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdObject]) REFERENCES [dbo].[Object] ([Id])
ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdUser]) REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[Users] WITH CHECK ADD FOREIGN KEY([IdRole]) REFERENCES [dbo].[UserRole] ([Id])

select * from [Users]
update [Users]
set Status = '0'
where Id = 2
delete from  [Users] where Id = 3
select * from Object

