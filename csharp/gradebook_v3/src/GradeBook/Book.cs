using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Book
    {
        // List<double> grades = new List<double>();
        List<double> grades;

        // Constructor
        public Book()
        {
            grades = new List<double>();
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
    }
}