CREATE PROCEDURE [dbo].[World_GetList]

AS
	SELECT 
		[Id],
		[Name],
		[Description]
	FROM
		[dbo].[World]
