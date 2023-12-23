

  CREATE PROCEDURE Add_NewBook1
    @AuthorAge INT,
    @AuthorName NVARCHAR(255),
	@BookTitle NVARCHAR(255),
    @PublicationYear INT,
	@AuthorId INT
AS
BEGIN
    INSERT INTO Authors(Age, Name)
    VALUES (@AuthorAge, @AuthorName);
	INSERT INTO Books(Title, YearPublished, AuthorId)
	VALUES(@BookTitle, @PublicationYear, @AuthorId);
END

EXEC Add_NewBook1 @AuthorAge = 35, @AuthorName = 'Vazha Gelashvili', @BookTitle = 'Mglis Biliki', @PublicationYear = 2001, @AuthorId= 9;

	CREATE TRIGGER AfterDeleteOrInsert
	ON Books 
	AFTER Delete, Insert
	AS
	BEGIN
    DECLARE @AuthorID INT;
	SELECT @AuthorID = AuthorID FROM INSERTED;

    UPDATE Author
    SET BookCount = BookCount + 1
    WHERE AuthorID = @AuthorID;
END;