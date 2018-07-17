USE [ScoreKeeper]
GO
/****** Object:  Table [dbo].[score]    Script Date: 7/17/2018 11:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[score](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[NAME] [nvarchar](100) NULL,
	[POINTS] [int] NULL,
	[GAMES] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InserUser]    Script Date: 7/17/2018 11:09:13 AM ******/
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
	 @Games int
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
		INSERT INTO dbo.score  VALUES (@Name, @Points, @Games);  
	ELSE
		UPDATE score SET POINTS = @Points , GAMES= @Games WHERE ID = @ID;
	--Select * from score;
END
GO
