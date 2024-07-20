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
	[Email] [nvarchar](200) NULL,
	[Password] [nvarchar](200) NULL,
	[Status] [nvarchar](max) NULL,
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdObject] [int] NOT NULL,
	[IdInput] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[InputPrice] [float] NULL,
	[IdUser] [int] NOT NULL,
	[Status] nvarchar(255) 
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[IdSuplier] [int] NOT NULL,
	[Status] nvarchar(255)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[ObjectDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdObject] [int] NOT NULL,
	[Capacity] [nvarchar](max) NULL,
	[Count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),
FOREIGN KEY ([IdObject]) REFERENCES [dbo].[Object] ([Id])
) ON [PRIMARY]
GO





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Output](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdObject] [int]  NOT NULL,
	[IdOutput] [int]  NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[Count] [int] NULL,
	[Status] [nvarchar](max) NULL,
	[IdUser] [int] NULL,
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOutputInfo] [int] not null,
	[IdCustomer] [int] not null,
	[NameCustomer] [nvarchar](100),
	[Email] [nvarchar](100) not null,
	[Phone] [nvarchar](100) not null,
	[ObjectName] [nvarchar](100) not null,
	[Capacity] nvarchar(100) not null,
	[Quantity] [int] not null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),
) ON [PRIMARY]



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

-- Add foreign keys
ALTER TABLE [dbo].[InputInfo] WITH CHECK ADD FOREIGN KEY([IdInput]) REFERENCES [dbo].[Input] ([Id])
ALTER TABLE [dbo].[InputInfo] WITH CHECK ADD FOREIGN KEY([IdObject]) REFERENCES [dbo].[Object] ([Id])
ALTER TABLE [dbo].[InputInfo] WITH CHECK ADD FOREIGN KEY([IdUser]) REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[Object] WITH CHECK ADD FOREIGN KEY([IdSuplier]) REFERENCES [dbo].[Suplier] ([Id])

ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdOutput]) REFERENCES [dbo].[Output] ([Id])
ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdCustomer]) REFERENCES [dbo].[Customer] ([Id])
ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdObject]) REFERENCES [dbo].[Object] ([Id])
ALTER TABLE [dbo].[OutputInfo] WITH CHECK ADD FOREIGN KEY([IdUser]) REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[Users] WITH CHECK ADD FOREIGN KEY([IdRole]) REFERENCES [dbo].[UserRole] ([Id])

ALTER TABLE [dbo].[BillHistory] WITH CHECK ADD FOREIGN KEY([IdCustomer]) REFERENCES [dbo].[Customer] ([Id])
ALTER TABLE [dbo].[BillHistory] WITH CHECK ADD FOREIGN KEY([IdOutputInfo]) REFERENCES [dbo].[OutputInfo] ([Id])
select * from [Users]
select * from [ObjectDetail]
update users set UserName = 'haiduong175d@gmail.com' where Id = 1
update users set status = '1' where Id = 1
update users set displayname = 'admin' where Id = 1

select * from [OutputInfo]
select * from BillHistory
select * from Customer
select * from Users

update [OutputInfo] set Status = 'process' where Id = 5

update Customer set Phone = '0886543765' where id =1