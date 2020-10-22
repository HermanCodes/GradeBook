using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Hello, welcome to the gradebook software to start please enter the name for your new gradebook:");

            var gradeBookName = Console.ReadLine();
            var book = new Book($"{gradeBookName} gradebook");

            Console.WriteLine("The hello program will now ask you to enter your grades.");

            for (var i = 0; i >= 0; i++)
            {
                Console.WriteLine($"Please enter a grade or enter 'q' to quit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    double grade = Double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}:");
            Console.WriteLine($"The average grade is {stats.Average:N2}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The average letter grade is {stats.Letter}.");

        }
    }
}


