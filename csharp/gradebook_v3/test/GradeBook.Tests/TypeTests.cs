using System;
using Xunit;
// using GradeBook;


namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");

            // need to use "ref" while passing parameter by reference
            // can be changed to "out"
            GetBookSetName(ref book1, "New Name");
            // this test proves that the only the value of book1
            //  is passed to the
            // function and not the reference to book1.

            Assert.Equal("New Name", book1.Name);
        }

        // in C#, "ref" is used for passing parameter by reference.
        // passes the reference to book1 and not the value inside book1

        // OR "out", but there C# assumes that this object was never
        // initialized and you need to give some value to this parameter,
        // otherwise the C# compiler would give you error.
        void GetBookSetName(ref Book book, string name)
        {
            //constructs a new Book object and replaces the value of 
            // memory location coming from the test which was copied from the 
            // test function and is thus replaced here.
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");

            GetBookSetName(book1, "New Name");
            // this test proves that the only the value of book1
            //  is passed to the
            // function and not the reference to book1.

            Assert.Equal("Book1", book1.Name);
        }

        // in C#, parameters by default ALWAYSSS are passed by "value"
        // it just so happens in this case that the value of book1 is a 
        // pointer, hence the original book memory location changed when 
        // updating name.
        // But still the "book" gets the value inside "book1" that is the 
        // address of the "Book1" object.
        void GetBookSetName(Book book, string name)
        {
            //constructs a new Book object and replaces the value of 
            // memory location coming from the test which was copied from the 
            // test function and is thus replaced here.
            book = new Book(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");

            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        // in C#, parameters by default ALWAYSSS are passed by "value"
        // it just so happens in this case that the value of book1 is a 
        // pointer, hence the original book memory location changed when 
        // updating name.
        // But still the "book" gets the value inside "book1" that is the 
        // address of the "Book1" object.
        void SetName(Book book, string name)
        {
            book.Name = name;
        }

        // Fact is attched to Test1()
        // Fact is one of the attribute in C#
        // XUnit will look for methods that have [Fact] attched to them and execute them as unit tests.
        // Rest would be considered as normal functions or as per their own attached attributes.
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.NotEqual(book1, book2);
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            book2.Name = book1.Name + '!';

            Assert.Equal(book1, book2);
            Assert.Equal("Book1!", book1.Name);
            Assert.Equal("Book1!", book2.Name);

            // OR
            // checks if the objects are pointing to the same 
            // instance of the object in memory
            Assert.Same(book1, book2); 

            // OR
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

    // "object" is the lowest base type in .NET
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
