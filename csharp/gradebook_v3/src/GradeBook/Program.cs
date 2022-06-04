using System;
using System.Collections.Generic;

// # A solution file is used to list all the projest and test files in one place so that 
// # .NET and vscode can understand with a single command which projects to run and
// # which projects to test.

// namespace GradeBook.Math
namespace GradeBook
{

    // as a convention, always have one class in one file Programm class -> Program.cs. Create another for class Book -> Book.cs
    // class Book
    // {

    // }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome, {args[0]}!");
            var book = new Book("Abhijeet's Grade Book");
            // book.GetInputFromUser();
            var book2 = new Book("Abhijsdeet's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            System.Console.WriteLine($"There are {Book.getInstancesCount()} instances of Book class");
            // book.grades.Add(101);// not allowed due to abstraction

            // book.AddGrade(121.4);

            // book.PrintGrades();

            // var book2 = new Book();
            // book2.AddGrade(892.1);

            // book2.AddGrade(121.4);

            // book2.PrintGrades();

            var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);

            book.ShowStatistics();
            // // int x;
            // // x = (int)34.1;
            // double x = 34.1;
            // double y = 15.9;

            // // var a = 15.5; // auto assign datatype, style strongly types, once assigned, giving a different value would raise an error
            // // var b = 14.5;// var always needs to be initialized when defined

            // Console.WriteLine($"Sum of {x} and {y} is: {x+y}");

            // // double[] numbers = new double[3];
            // // var numbers = new double[] { 23.11, 21.2, 34.1, 4.1 };
            // // var numbers = new double[4] { 23.11, 21.2, 34.1, 4.1 };
            // var numbers = new[] { 23.11, 21.2, 34.1, 4.1 }; // no need to say 'double[]'
            // // numbers[0] = 23.11;
            // // numbers[1] = 21.2;
            // // numbers[2] = 34.1;

            // // List<double> grades = new List<double>();
            // // var grades = new List<double>();
            // var grades = new List<double>() { 23.11, 21.2, 34.1, 4.1 };
            // grades.Add(56.1);

            // System.Console.WriteLine(grades.Count);

            // var resultList = 0.0;
            // var averageList = 0.0;
            // foreach (var item in grades)
            // {
            //     resultList+=item;
            // }
            // averageList = resultList/grades.Count;

            // var result = 0.0;
            // var average = 0.0;
            // foreach (var item in numbers) // OR foreach (double item in numbers)
            // {
            //     result += item;
            // }

            // average = result/numbers.Length;

            // Console.WriteLine(numbers[0] + numbers[1] + numbers[2]);

            // System.Console.WriteLine(result);
            // System.Console.WriteLine(resultList);

            // System.Console.WriteLine($"Average: {average}");
            // System.Console.WriteLine($"Average: {averageList}");
            // System.Console.WriteLine($"Average: {averageList:N3}");
            // // try
            // // {
            // //     string name = args[0];
            // // Console.WriteLine("Hello " + name + "!");
            // // Console.WriteLine($"Hello, {name}!"); // string interpolation
            // // }
            // // catch (System.Exception)
            // // {
            // //     Console.WriteLine("Error occured");
            // //     // throw;
            // // }

        }
    }
}
