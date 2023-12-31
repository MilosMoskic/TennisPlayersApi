USE [master]
GO
/****** Object:  Database [TennisPlayers]    Script Date: 14.8.2023. 22:06:15 ******/
CREATE DATABASE [TennisPlayers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TennisPlayers', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TennisPlayers.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TennisPlayers_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TennisPlayers_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TennisPlayers] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TennisPlayers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TennisPlayers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TennisPlayers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TennisPlayers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TennisPlayers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TennisPlayers] SET ARITHABORT OFF 
GO
ALTER DATABASE [TennisPlayers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TennisPlayers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TennisPlayers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TennisPlayers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TennisPlayers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TennisPlayers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TennisPlayers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TennisPlayers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TennisPlayers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TennisPlayers] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TennisPlayers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TennisPlayers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TennisPlayers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TennisPlayers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TennisPlayers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TennisPlayers] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TennisPlayers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TennisPlayers] SET RECOVERY FULL 
GO
ALTER DATABASE [TennisPlayers] SET  MULTI_USER 
GO
ALTER DATABASE [TennisPlayers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TennisPlayers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TennisPlayers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TennisPlayers] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TennisPlayers] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TennisPlayers] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TennisPlayers', N'ON'
GO
ALTER DATABASE [TennisPlayers] SET QUERY_STORE = OFF
GO
USE [TennisPlayers]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14.8.2023. 22:06:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Athletes]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Athletes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[Ranking] [int] NULL,
	[TotalWins] [int] NOT NULL,
	[TotalLoses] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CountryId] [int] NOT NULL,
	[CoachId] [int] NOT NULL,
 CONSTRAINT [PK_Athletes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AthleteSponsors]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AthleteSponsors](
	[AthleteId] [int] NOT NULL,
	[SponsorId] [int] NOT NULL,
 CONSTRAINT [PK_AthleteSponsors] PRIMARY KEY CLUSTERED 
(
	[AthleteId] ASC,
	[SponsorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AthleteTournaments]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AthleteTournaments](
	[AthleteId] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
 CONSTRAINT [PK_AthleteTournaments] PRIMARY KEY CLUSTERED 
(
	[AthleteId] ASC,
	[TournamentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coaches]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coaches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Coaches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Abbreviation] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sponsors]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NetWorth] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Sponsors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournaments]    Script Date: 14.8.2023. 22:06:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournaments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SurfaceType] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Tournaments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Athletes_CoachId]    Script Date: 14.8.2023. 22:06:16 ******/
CREATE NONCLUSTERED INDEX [IX_Athletes_CoachId] ON [dbo].[Athletes]
(
	[CoachId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Athletes_CountryId]    Script Date: 14.8.2023. 22:06:16 ******/
CREATE NONCLUSTERED INDEX [IX_Athletes_CountryId] ON [dbo].[Athletes]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AthleteSponsors_SponsorId]    Script Date: 14.8.2023. 22:06:16 ******/
CREATE NONCLUSTERED INDEX [IX_AthleteSponsors_SponsorId] ON [dbo].[AthleteSponsors]
(
	[SponsorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AthleteTournaments_TournamentId]    Script Date: 14.8.2023. 22:06:16 ******/
CREATE NONCLUSTERED INDEX [IX_AthleteTournaments_TournamentId] ON [dbo].[AthleteTournaments]
(
	[TournamentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tournaments_LocationId]    Script Date: 14.8.2023. 22:06:16 ******/
CREATE NONCLUSTERED INDEX [IX_Tournaments_LocationId] ON [dbo].[Tournaments]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Athletes]  WITH CHECK ADD  CONSTRAINT [FK_Athletes_Coaches_CoachId] FOREIGN KEY([CoachId])
REFERENCES [dbo].[Coaches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Athletes] CHECK CONSTRAINT [FK_Athletes_Coaches_CoachId]
GO
ALTER TABLE [dbo].[Athletes]  WITH CHECK ADD  CONSTRAINT [FK_Athletes_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Athletes] CHECK CONSTRAINT [FK_Athletes_Countries_CountryId]
GO
ALTER TABLE [dbo].[AthleteSponsors]  WITH CHECK ADD  CONSTRAINT [FK_AthleteSponsors_Athletes_AthleteId] FOREIGN KEY([AthleteId])
REFERENCES [dbo].[Athletes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AthleteSponsors] CHECK CONSTRAINT [FK_AthleteSponsors_Athletes_AthleteId]
GO
ALTER TABLE [dbo].[AthleteSponsors]  WITH CHECK ADD  CONSTRAINT [FK_AthleteSponsors_Sponsors_SponsorId] FOREIGN KEY([SponsorId])
REFERENCES [dbo].[Sponsors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AthleteSponsors] CHECK CONSTRAINT [FK_AthleteSponsors_Sponsors_SponsorId]
GO
ALTER TABLE [dbo].[AthleteTournaments]  WITH CHECK ADD  CONSTRAINT [FK_AthleteTournaments_Athletes_AthleteId] FOREIGN KEY([AthleteId])
REFERENCES [dbo].[Athletes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AthleteTournaments] CHECK CONSTRAINT [FK_AthleteTournaments_Athletes_AthleteId]
GO
ALTER TABLE [dbo].[AthleteTournaments]  WITH CHECK ADD  CONSTRAINT [FK_AthleteTournaments_Tournaments_TournamentId] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournaments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AthleteTournaments] CHECK CONSTRAINT [FK_AthleteTournaments_Tournaments_TournamentId]
GO
ALTER TABLE [dbo].[Tournaments]  WITH CHECK ADD  CONSTRAINT [FK_Tournaments_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tournaments] CHECK CONSTRAINT [FK_Tournaments_Locations_LocationId]
GO
USE [master]
GO
ALTER DATABASE [TennisPlayers] SET  READ_WRITE 
GO
