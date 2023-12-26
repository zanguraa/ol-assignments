SELECT AuthorId,
COUNT(*) AS NumberOfBooks
FROM [credo_test].[dbo].Books
GROUP BY AuthorId
HAVING COUNT(*) > 2

CREATE INDEX indx_yearPublished
ON [credo_test].[dbo].Books(YearPublished)


INSERT INTO credo_test.dbo.Books (AuthorId, Title, YearPublished)
VALUES (4, 'mgelkaca', 2000);

SELECT Authors.Name, Books.Title FROM
credo_test.dbo.Authors 
 JOIN credo_test.dbo.Books  ON [credo_test].[dbo].Books.AuthorId = [credo_test].[dbo].Authors.Id

 --5. Create a view that shows the list of authors along with the number of books they have written.--
 CREATE VIEW AuthorBookCountView AS
SELECT
    A.Id AS AuthorId,
    A.Name AS AuthorName,
    COUNT(B.Id) AS BookCount
FROM
    credo_test.dbo.Authors A
LEFT JOIN
    credo_test.dbo.Books B ON A.Id = B.AuthorId
GROUP BY
    A.Id, A.Name;

	SELECT * FROM [AuthorBookCountView];