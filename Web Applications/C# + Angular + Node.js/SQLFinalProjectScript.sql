
/****** Object:  Table [dbo].[Users]    Script Date: 17/01/2022 17:56:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[DiscordTokenId] [int] NULL,
	[GithubTokenId] [int] NULL,
	[AppNickname] [varchar](255) NULL,
	[password] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[IdTokens]    Script Date: 17/01/2022 17:55:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IdTokens](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PlatformId] [int] NOT NULL,
	[nickname] [varchar](255) NULL,
	[PlatformUserId] [varchar](255) NOT NULL,
	[exp] [int] NULL,
	[iat] [int] NULL,
	[create_date] [date] NULL,
 CONSTRAINT [PK__IdTokens__658FEEEA09200EBA] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IdTokens] ADD  CONSTRAINT [CONSTRAINT_NAME]  DEFAULT (getdate()) FOR [create_date]
GO



/****** Object:  Table [dbo].[Platforms]    Script Date: 17/01/2022 17:56:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Platforms](
	[PlatformId] [int] NOT NULL,
	[PlatformName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PlatformId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Platforms]
           ([PlatformId]
           ,[PlatformName])
     VALUES
           (0, 'discord')

INSERT INTO [dbo].[Platforms]
           ([PlatformId]
           ,[PlatformName])
     VALUES
           (1, 'github')
