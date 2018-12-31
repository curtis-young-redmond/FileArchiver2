USE [ETRM_Support]
GO

/****** Object:  Table [dbo].[FileCleanupConfiguration]    Script Date: 12/6/2018 2:15:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileCleanupConfiguration](
	[CleanUpType] [nvarchar](10) NOT NULL,
	[ServerName] [nvarchar](500) NOT NULL,
	[SourceFolderPath] [nvarchar](500) NOT NULL,
	[SourceFilePattern] [nvarchar](50) NOT NULL,
	[RetentionDays] [numeric](18, 0) NOT NULL,
	[DestinationFolderPath] [nvarchar](500) NULL,
	[Compress] [bit] NOT NULL,
	[OrderofExecution] [int] NOT NULL,
 CONSTRAINT [PK_FileCleanupConfiguration] PRIMARY KEY CLUSTERED 
(
	[SourceFolderPath] ASC,
	[OrderofExecution] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FileCleanupConfiguration] ADD  DEFAULT ((1)) FOR [Compress]
GO


