-- create a database name with onlinegrocery

CREATE SCHEMA admin

------------------------------------------------



CREATE TABLE [Admin].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleName] [nvarchar](150) NOT NULL,
	[IsActive] [bit] NULL,
	[IsEditable] [bit] NOT NULL,
	[UserRoleXml] [xml] NULL,
	[SchoolId] [bigint] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Admin].[UserRole] ADD  CONSTRAINT [DF__UserRole__IsActi__2042BE37]  DEFAULT ((0)) FOR [IsActive]
GO

ALTER TABLE [Admin].[UserRole] ADD  DEFAULT ((0)) FOR [IsEditable]
GO



--------------------------------------------------------------------


/****** Object:  UserDefinedDataType [dbo].[Name]    Script Date: 6/27/2020 9:08:47 PM ******/
CREATE TYPE [dbo].[Name] FROM [nvarchar](150) NULL
GO



-------------------------------------------------------------------



CREATE TABLE [Admin].[UserType](
	[UserTypeID] [smallint] NOT NULL,
	[UserTypeName] [dbo].[Name] NOT NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--------------------------------------------------------------------



CREATE TABLE [Admin].[UserRoleMapping](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




-----------------------------------------------------------------------

CREATE TABLE [Admin].[UserProfileMapping](
	[MappingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AvatarId] [int] NOT NULL,
 CONSTRAINT [PK_UserProfileMapping] PRIMARY KEY CLUSTERED 
(
	[MappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-----------------------------------------------------------------------


CREATE TABLE [Admin].[UserLog](
	[LogId] [uniqueidentifier] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[LogInTime] [datetime] NOT NULL,
	[Ipdetails] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Admin].[UserLog] ADD  DEFAULT (newid()) FOR [LogId]
GO


------------------------------------------------------------------------------

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolId] [bigint] NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](150) NULL,
	[MiddleName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsSuperAdmin] [bit] NOT NULL,
	[OldUserId] [bigint] NULL,
	[FeelId] [int] NULL,
	[CureentStatus] [nvarchar](max) NULL,
	[userRefId] [bigint] NULL,
	[UserImageFilePath] [nvarchar](max) NULL,
	[UserStatus] [int] NULL,
	[LastLogin] [datetime] NULL,
	[SystemLanguageId] [smallint] NULL,
	[PASSWORD] [nvarchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


-----------------------------------------------------------------------------------


CREATE TABLE [Admin].[UserErrorLogs](
	[ErrorLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorText] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[ModuleUrl] [nvarchar](400) NULL,
	[UserIpAddress] [nvarchar](400) NULL,
	[WebServerIpAddress] [nvarchar](400) NULL,
	[ReportingDate] [datetime] NULL,
 CONSTRAINT [PK_UserErrorLogs] PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Admin].[UserErrorLogs]  WITH CHECK ADD  CONSTRAINT [FK_UserErrorLogs_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [Admin].[UserErrorLogs] CHECK CONSTRAINT [FK_UserErrorLogs_Users]
GO



---------------------------------------------------------------------------------------------------------------