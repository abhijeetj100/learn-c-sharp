using System.Collections.Generic;
using System;

namespace GradeBook
{
    // default access specifier: internal, this class can only be used inside the same project
    public class Book
    {
        // List<double> grades = new List<double>();
        private List<double> grades;


        // properties
        // // 1. Longhand syntax - the approach that required the most typings (keystrokes)

        // private string name;

        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             // for every set (setter) there will a implicit variable with the name "value"
        //             name = value;
        //         }
        //         else
        //         {
        //             throw new Exception("Book name entered is either Empty or Null");
        //         }
        //     }
        // }

        // 2. Shorthand - auto property
        public string Name
        {
            get;  // can only read name from outside the class
            // private set; // cannot set property from outside the class
            set;
        }

        // readonly - can either initialize or set in a constructor
        readonly string category = "Science";

        public const string CAT = "Science"; // generally as per convension, written as public and in uppercase letters

        static private int instanceCount = 0;

        // Constructor - these can be overloaded too
        public Book(string name)
        {
            category = "";
            // CAT = ""; // more strict that readonly
            grades = new List<double>();
            Name = name;
            incrementCount();
        }

        public List<double> GetGrades()
        {
            // category = ""; // will give an error as its readonly.
            return grades;
        }

        public void GetInputFromUser()
        {
            // var inputsize = 0;
            // Console.WriteLine("Enter the input size:");
            // inputsize = int.Parse(Console.ReadLine());

            // for (var index = 0; index < inputsize; index++)
            // {
            //     Console.WriteLine($"Enter grade no: {index+1}");
            //     var grade = double.Parse(Console.ReadLine());
            //     AddGrade(grade);
            // }
            // OR

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // catch(Exception ex)// this will catch ALL exceptions
                // {
                //     Console.WriteLine(ex.Message);
                //     // throw; // in case we need to still throw the exceptions
                // }
                finally
                {
                    Console.WriteLine("**");
                }


            }

            Console.WriteLine("Grades added successfully!");
        }

        void incrementCount()
        {
            instanceCount++;
        }

        static public int getInstancesCount()
        {
            return instanceCount;
        }

        // in function overloading, function signatures should differe
        // Function signature - func name, parameters. Does NOT include the return type.
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
            // if(letter == 'A'){
            //     AddGrade(90);
            // }
            // else if(letter == 'B'){
            //     AddGrade(80);
            // }
        }

        public void AddGrade(double grade)
        {
            // comparing float numbers is not advised
            // instead, do
            // ref: https://www.geeksforgeeks.org/problem-in-comparing-floating-point-numbers-and-how-to-compare-them-correctly/
            // if(Math.Abs(grade-100) < 1e-9){

            // }
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value");
                throw new ArgumentException($"Invalid grade: {nameof(grade)}");
            }
        }

        public void PrintGrades()
        {
            Console.WriteLine("Grades added are:");
            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }
        }

        public void ShowStatistics()
        {
            var result = GetStatistics();

            Console.WriteLine($"For the book named: {Name}");
            Console.WriteLine($"The average grade is {result.Average:N1}");
            Console.WriteLine($"The highest grade is {result.High:N1}");
            Console.WriteLine($"The lowest grade is {result.Low:N1}");
            Console.WriteLine($"The letter grade is {result.Letter}");
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            // by default, .NET runtime will set all the properties when class is
            // intantiated for the time to 0 (bits off)
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            // var result = 0.0;
            // var highGrade = double.MinValue; // smallest possible double value
            // var lowGrade = double.MaxValue; // smallest possible double value
            foreach (var grade in grades)
            {
                if (grade == 42.1)
                {
                    // break;
                    continue;
                    // goto done;
                }
                // if (grade > highGrade)
                // {
                // highGrade = grade;
                // OR 
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);

                // }
                result.Average += grade;
            }
            // var index = 0;
            // if (grades.Count > 0)
            // {
            //     do
            //     {
            //         result.High = Math.Max(result.High, grades[index]);
            //         result.Low = Math.Min(result.Low, grades[index]);
            //         result.Average += grades[index];
            //         index += 1;
            //     } while (index < grades.Count);
            // }

            // var index = 0;
            // while (index < grades.Count)
            // {
            //     result.High = Math.Max(result.High, grades[index]);
            //     result.Low = Math.Min(result.Low, grades[index]);
            //     result.Average += grades[index];
            //     index += 1;
            // }

            // for (var index = 0; index < grades.Count; index += 1)
            // {
            //     result.High = Math.Max(result.High, grades[index]);
            //     result.Low = Math.Min(result.Low, grades[index]);
            //     result.Average += grades[index];
            // }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            // done:
            return result;
        }
    }
}
