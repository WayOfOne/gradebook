using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Don's Gradebook");
            book.AddGrade(55.5);
            book.AddGrade(66.6);
            book.AddGrade(55.1234);
            // book.AddGrade(105555);
            book.DisplayStatistics();
        }
    }

}
