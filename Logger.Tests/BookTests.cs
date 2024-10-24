using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Theory]
    [InlineData("ISBN", 1998, "Title", "First", "Last", "Middle")]
    public void Constructor_AllParamaters_MakesRecord(string isbn, int publicationYear, string title, string first, string last, string middle)
    {
        //Arrange
        string expectedIsbn = "ISBN";
        string expectedFirst = "First";
        string expectedMiddle = "Middle";
        string expectedLast = "Last";
        int expectedPublicationYear = 1998;
        string expectedTitle = "Title";

        //Act
        Book book = new(isbn, publicationYear, title, first, last, middle);

        //Assert
        Assert.NotNull(book);
        Assert.Equal(book.Isbn, expectedIsbn);
        Assert.Equal(book.Author.First, expectedFirst);
        Assert.Equal(book.Author.Middle, expectedMiddle);
        Assert.Equal(book.Author.Last, expectedLast);
        Assert.Equal(book.PublicationYear, expectedPublicationYear);
        Assert.Equal(book.Title, expectedTitle);
    }

    [Theory]
    [InlineData("ISBN", 1998, "Title", "First", "Last")]
    public void Constructor_AllParamatersExceptMiddle_MakesRecord(string isbn, int publicationYear, string title, string first, string last)
    {
        //Arrange
        string expectedIsbn = "ISBN";
        string expectedFirst = "First";
        string expectedLast = "Last";
        int expectedPublicationYear = 1998;
        string expectedTitle = "Title";

        //Act
        Book book = new(isbn, publicationYear, title, first, last);

        //Assert
        Assert.NotNull(book);
        Assert.Equal(book.Isbn, expectedIsbn);
        Assert.Equal(book.Author.First, expectedFirst);
        Assert.Equal(book.Author.Last, expectedLast);
        Assert.Equal(book.PublicationYear, expectedPublicationYear);
        Assert.Equal(book.Title, expectedTitle);
    }

    [Theory]
    [InlineData(null, 1998, "Title", "First", "Last", "Middle")]
    [InlineData("ISBN", 0, "Title", "First", "Last", "Middle")]
    [InlineData("ISBN", 1998, null, "First", "Last", "Middle")]
    [InlineData("ISBN", 1998, "Title", null, "Last", "Middle")]
    [InlineData("ISBN", 1998, "Title", "First", null, "Middle")]
    public void Constructor_BadParamaters_ThrowsException(string? isbn, int publicationYear, string? title, string? first, string? last, string? middle)
    {
        //Arrange

        //Act

        //Assert
        Assert.ThrowsAny<ArgumentException>(() => new Book(isbn!, publicationYear, title!, first!, last!, middle));
    }

    [Theory]
    [InlineData("0135972264", 2020, "Essential C#", "Mark", "Michaelis")]
    public void ParseName_AllParamatersExceptMiddle_ValidBookInformation(string isbn, int publicationYear, string title, string first, string last)
    {
        //Arrange
        Book book = new (isbn, publicationYear, title, first, last);

        //Act
        string expectedName = "Essential C# by Mark Michaelis, year: 2020, ISBN: 0135972264";
        string actualName = book.Name;

        //Assert
        Assert.Equal(expectedName, actualName);
    }

    [Theory]
    [InlineData("0593135229", 2021, "Project Hail Mary", "Andy", "Weir", "Taylor")]
    public void ParseName_AllParamaters_ValidBookInformation(string isbn, int publicationYear, string title, string first, string last, string middle)
    {
        //Arrange
        Book book = new (isbn, publicationYear, title, first, last, middle);

        //Act
        string expectedName = "Project Hail Mary by Andy Taylor Weir, year: 2021, ISBN: 0593135229";
        string actualName = book.Name;

        //Assert
        Assert.Equal(expectedName, actualName);
    }

    [Fact]
    public void Constructor_MatchingBook_ReturnsTrue()
    {
        //Arrange
        Book book1 = new("isbn", 1998, "Title", "First", "Last", "Middle");
        Book book2 = new("isbn", 1998, "Title", "First", "Last", "Middle");
        Book book3 = book1;

        //Act

        //Assert
        Assert.False(book1.Equals(book2));
        Assert.True(book1.Equals(book3));
        Assert.False(book1 == book2);
        Assert.True(book1 != book2);
        Assert.Same(book1,book3);

    }
}