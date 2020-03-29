using System;
using Xunit;


namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void ComputeGradesTest1()
        {
            //arange
            var book = new Book("Test");
            book.AddGrade(55.5);
            book.AddGrade(56.5);
            book.AddGrade(99);
            //action
            var (average, low, high, letter, name) = book.ComputeGrades();
            //assert
            Assert.Equal(70.3, average, 1);
            Assert.Equal(55.5, low, 1);
            Assert.Equal(99, high, 1);
            Assert.Equal('C', letter);
            Assert.Equal("Test", name);


        }
    }
}
