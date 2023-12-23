SELECT AuthorId,
COUNT(*) AS NumberOfBooks
FROM [credo_test].[dbo].Books
GROUP BY AuthorId
HAVING COUNT(*) > 2

CREATE INDEX indx_yearPublished
ON [credo_test].[dbo].Books(YearPublished)



