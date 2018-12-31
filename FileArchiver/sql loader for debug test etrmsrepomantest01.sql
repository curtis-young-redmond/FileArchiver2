/*******************************************
This script loads the Test environment so that the FileArchiver can be run on your laptop using the Visual studio and debugging the code.
Target DATA Server:ETRMSNONSOXTESTSQL01/ETRM_SUPPORT
********************************************/
truncate table [FileCleanupConfiguration]
go
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\BATags\PB_223 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 20)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\MeterIntervalData\PB_201 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 19)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\SystemLoad\PB_250 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 18)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\VERForecast\PB_227 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 17)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\GHGData\PB_314 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 16)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\MeterIntervalData\PB_201 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 15)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\SystemLoad\PB_251 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 14)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\VERForecast\PB_226 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 13)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\WebTraderNetDeals\PB_249_252 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 12)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Delete', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\WebTraderUpdate\BP_224 ', N'*.gz', CAST(20 AS Decimal(18, 1)), NULL, 0, 11)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\DATA\EIM\Interfaces\LoadOffice\BATags\PB_223', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\BATags\PB_223 ', 1, 1)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\DATA\EIM\Interfaces\LoadOffice\MeterIntervalData\PB_201', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\MeterIntervalData\PB_201 ', 1, 4)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\DATA\EIM\Interfaces\LoadOffice\SystemLoad\PB_250', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\SystemLoad\PB_250 ', 1, 2)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\DATA\EIM\Interfaces\LoadOffice\VERForecast\PB_227', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\VERForecast\PB_227 ', 1, 3)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\Marketing\GHGData\PB_314', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\GHGData\PB_314 ', 1, 5)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\Marketing\MeterIntervalData\PB_201', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\MeterIntervalData\PB_201 ', 1, 6)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\Marketing\SystemLoad\PB_251', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\SystemLoad\PB_251 ', 1, 7)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\Marketing\VERForecast\PB_226', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\VERForecast\PB_226 ', 1, 8)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\Marketing\WebTraderNetDeals\PB_249_252', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\WebTraderNetDeals\PB_249_252 ', 1, 9)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\Marketing\WebTraderUpdate\BP_224', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\Marketing\WebTraderUpdate\BP_224 ', 1, 10)
INSERT INTO [dbo].[FileCleanupConfiguration] ([CleanUpType], [ServerName], [SourceFolderPath], [SourceFilePattern], [RetentionDays], [DestinationFolderPath], [Compress], [OrderofExecution]) VALUES (N'Archive', N'ETRMSREPOMANTEST01', N'\\ETRMSREPOMANTEST01\Data\EIM\Interfaces\LoadOffice\BATags\WorkingFolder', N'*.*', CAST(0 AS Decimal(18, 1)), N'\\ETRMSREPOMANTEST01\Archive\EIM\Interfaces\LoadOffice\BATags\WorkingFolder', 1, 10)