using System.Collections.Generic;
using System;

namespace GradeBook
{
    // default access specifier: internal, this class can only be used inside the same project
    public class Book
    {
        // List<double> grades = new List<double>();
        public List<double> grades;
        public string Name;

        static private int instanceCount = 0;

        // Constructor
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
            incrementCount();
        }

        void incrementCount()
        {
            instanceCount++;
        }

        static public int getInstacesCount()
        {
            return instanceCount;
        }

        public void AddGrade(double grade)
        {
            // comparing float numbers is not advised
            // instead, do
            // ref: https://www.geeksforgeeks.org/problem-in-comparing-floating-point-numbers-and-how-to-compare-them-correctly/
            // if(Math.Abs(grade-100) < 1e-9){

            // }
            if(grade <= 100 && grade >=0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value");
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

            Console.WriteLine($"The average grade is {result.Average:N1}");
            Console.WriteLine($"The highest grade is {result.High:N1}");
            Console.WriteLine($"The lowest grade is {result.Low:N1}");
        }

        public Statistics GetStatistics(){
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
                // if (grade > highGrade)
                // {
                // highGrade = grade;
                // OR 
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);

                // }
                result.Average += grade;
            }
            result.Average /= grades.Count;
            return result;
        }
    }
}