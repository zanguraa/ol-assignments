UPDATE credo_test.dbo.Authors 
SET Age = 39
WHERE Age = 43;


  DELETE FROM credo_test.dbo.Books
  WHERE Title = 'test';

  SELECT Name
  FROM credo_test.dbo.Authors 
  ORDER BY Name ASC

  SELECT * 
  FROM credo_test.dbo.Books
  WHERE YearPublished BETWEEN 1999 AND 2000;

  SELECT a.Name, COUNT(b.Id)
  FROM credo_test.dbo.Authors a
  INNER JOIN credo_test.dbo.Books b ON a.Id = b.AuthorId
  GROUP BY a.Name

   SELECT a.Name, COUNT(b.Id)
  FROM credo_test.dbo.Authors a
  INNER JOIN credo_test.dbo.Books b ON a.Id = b.AuthorId
  GROUP BY a.Name
  HAVING a.Name = 'Shota Rustaveli'