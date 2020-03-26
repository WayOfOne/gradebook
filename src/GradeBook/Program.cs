using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Don's Gradebook");
            book.AddGrade(40.5);
            book.AddGrade(50.5);
            book.AddGrade(60.5);
            // book.AddGrade(105555);
            book.DisplayStatistics();
        }
    }

}
