using System;
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        // Fact is attched to Test1()
         // Fact is one of the attribute in C#
        // XUnit will look for methods that have [Fact] attched to them and execute them as unit tests.
        // Rest would be considered as normal functions or as per their own attached attributes.
        [Fact]
        public void Test1()
        {

            // generally unit test is broken into 3 sections

            //1. Arrange section, put all your data here

            var x = 5;
            var y = 2;
            var expected = 10;

            //2. Act section, do something that produces a result
            var actual = x*y;

            //3. Assert section, assertions
            Assert.Equal(expected, actual);
        }
    }
}
