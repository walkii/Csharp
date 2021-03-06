USE [master]
GO
/****** Object:  Database [ScoreKeeper]    Script Date: 7/17/2018 2:12:33 PM ******/
CREATE DATABASE [ScoreKeeper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScoreKeeper', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ScoreKeeper.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ScoreKeeper_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ScoreKeeper_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ScoreKeeper] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScoreKeeper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScoreKeeper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScoreKeeper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScoreKeeper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScoreKeeper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScoreKeeper] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScoreKeeper] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ScoreKeeper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScoreKeeper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScoreKeeper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScoreKeeper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScoreKeeper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScoreKeeper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScoreKeeper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScoreKeeper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScoreKeeper] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScoreKeeper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScoreKeeper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScoreKeeper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScoreKeeper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScoreKeeper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScoreKeeper] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScoreKeeper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScoreKeeper] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ScoreKeeper] SET  MULTI_USER 
GO
ALTER DATABASE [ScoreKeeper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScoreKeeper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScoreKeeper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScoreKeeper] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ScoreKeeper] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ScoreKeeper]
GO
/****** Object:  Table [dbo].[score]    Script Date: 7/17/2018 2:12:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[score](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[NAME] [nvarchar](100) NULL,
	[POINTS] [int] NULL,
	[GAMES] [int] NULL,
	[LASTGAME] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InserUser]    Script Date: 7/17/2018 2:12:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InserUser]
	-- Add the parameters for the stored procedure here
	 @Name NVARCHAR (255),
	 @Points int,
	 @Games int,
	 @LastGame datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @ID int
    SELECT @ID = ID FROM score WHERE Name = @Name;
	SELECT @ID;
	IF @ID IS NULL
		INSERT INTO dbo.score  VALUES (@Name, @Points, @Games,@LastGame);  
	ELSE
		UPDATE score SET POINTS = @Points , GAMES= @Games, LASTGAME=@LastGame WHERE ID = @ID;
	--Select * from score;
END
GO
USE [master]
GO
ALTER DATABASE [ScoreKeeper] SET  READ_WRITE 
GO
