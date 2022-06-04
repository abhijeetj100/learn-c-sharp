using System;
using Xunit;
// using GradeBook;


namespace GradeBook.Tests
{
    public class BookTests
    {
        // Fact is attched to Test1()
        // Fact is one of the attribute in C#
        // XUnit will look for methods that have [Fact] attched to them and execute them as unit tests.
        // Rest would be considered as normal functions or as per their own attached attributes.
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {

            // generally unit test is broken into 3 sections

            //1. Arrange section, put all your data here
            var book = new Book("");// we need to tell the C# compiler to lookfor this class in some other project
                                    // so update the NuGet <PackageRference> in .csproj file
                                    // using class in the same project is fine
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            // run `dotnet add`
            // ` dotnet add reference ../../src/GradeBook/GradeBook.csproj`

            //2. Act section, do something that produces a result
            var result = book.GetStatistics();

            //3. Assert section, assertions
            Assert.Equal(85.7, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.5, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void AddGradeOnlyIfInRange()
        {
            var book = new Book("");

            try
            {
                book.AddGrade(101);

            }
            catch (Exception ex)
            {
                Assert.Equal("Invalid grade: grade", ex.Message);
            }



            Assert.Empty(book.grades);
        }
    }
}
