using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Don's Gradebook");
            var done = false;
            while(!done){
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
            
    }

}
