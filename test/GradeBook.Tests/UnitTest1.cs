using System;
using Xunit;


namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arange
            var book = new Book("");
            book.AddGrade(55.5);
            book.AddGrade(56.5);
            book.AddGrade(99);
            //action
            var (average, low, high) = book.ComputeGrades();
            //assert
            Assert.Equal(average, 70.3, 1);
            Assert.Equal(low, 55.5, 1);
            Assert.Equal(high, 99, 1);

        }
    }
}
