USE [ScoreKeeper]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[InserUser]
		@Name = N'jul',
		@Points = 2,
		@Games = 2,
		@LastGame = '2018-07-17 11:47:38.157'

SELECT	'Return Value' = @return_value

GO
