using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Don's Gradebook");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            while(true){
                System.Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    break;
                }
                
                try{
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(InvalideGradeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            book.DisplayStatistics();
        }

        static void OnGradeAdded(object sender, GradeAddedArgs e)
        {
            System.Console.WriteLine($"Grade {e.Message} added into {sender.ToString()}");
        }
            
    }

}
