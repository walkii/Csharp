USE [ScoreKeeper]
GO
/****** Object:  StoredProcedure [dbo].[InserUser]    Script Date: 7/16/2018 2:57:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InserUser]
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
