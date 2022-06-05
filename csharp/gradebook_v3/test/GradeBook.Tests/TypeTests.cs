using System;
using Xunit;
// using GradeBook;


namespace GradeBook.Tests
{

    // basically these are types for functions
    // delegates generally goes outisde the class since they itself are a type.
    // You can instantiate an instance/object of this type.
    // still, if needed, this can be put inside a class too.

    // But generally, its outside the class.
    public delegate string WriteLogDelegate(string logMessage);
    public delegate int WriteSample(int number);


    // class objects are ALWAYS "REFERENCE TYPES"/pointers
    // struct objects are VALUE TYPES
    public class TypeTests
    {
        int count = 0;
        

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            // ways to point delegate to a function, these delegates should match the function signatures(return type and paramters)
            // name of the functions dont matter either
            //1. Longhand
            log = new WriteLogDelegate(ReturnMessage);
            //or
            log = ReturnMessage;

            var result = log("Hello!");

            Assert.Equal("Hello!", result);
        }

        [Fact]
        public void TestsMultiDelegate()
        {
            WriteLogDelegate log = ReturnMessage;

            //or
            log += IncrementCount;
            log += ReturnMessage;

            // now all the functions added will be invoked with the same parameter.

            var result = log("Hello!");

            // Assert.Equal("Hello!", result);
            Assert.Equal(3, count);

            


        }

        string ReturnMessage(string message){
            count++;
            return message;
        }

        string IncrementCount(string message){
            count++;
            return message.ToLower();
        }

        int IncreaseByOne(int number){
            return number+1;
        }

        int IncreaseByTwo(int number){
            return number+2;
        }


        // C# automatically takes care of "GARBAGE COLLECTION"
        // after the scope of the object, the .net runtime detetcts that the object is not being used anymore,
        // and cleans and frees up the momeory allocated and used by that class object.

        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            // strings are immutable in C#
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name); // fails, even if the string is a class i.e. reference types
            Assert.Equal("SCOTT", upper);

        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1(){
            var x = GetInt();
            SetInt(x);
            Assert.Equal(3, x);
            SetInt(ref x);

            Assert.NotEqual(3, x);
            Assert.Equal(42, x);
        }

        private void SetInt(Int32 z)
        {
            // Double a = 2;// same as double
            // DateTime dt = 
            z = 42;
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");

            // need to use "ref" while passing parameter by reference
            // can be changed to "out"
            GetBookSetName(out book1, "New Name");
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
        void GetBookSetName(out Book book, string name)
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
