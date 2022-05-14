using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Book
    {
        // List<double> grades = new List<double>();
        List<double> grades;
        private string name;

        static private int instanceCount = 0;

        // Constructor
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
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
            grades.Add(grade);
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
            var result = 0.0;
            var highGrade = double.MinValue; // smallest possible double value
            var lowGrade = double.MaxValue; // smallest possible double value
            foreach (var grade in grades)
            {
                // if (grade > highGrade)
                // {
                // highGrade = grade;
                // OR 
                highGrade = Math.Max(highGrade, grade);
                lowGrade = Math.Min(lowGrade, grade);

                // }
                result += grade;
            }
            result /= grades.Count;

            Console.WriteLine($"The average grade is {result:N1}");
            Console.WriteLine($"The highest grade is {highGrade:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");
        }
    }
}