DELETE FROM  dbo.score WHERE id >= 0;
DBCC CHECKIDENT ('[score]', RESEED, 0);
--DELETE FROM  dbo.score WHERE id = 9;
