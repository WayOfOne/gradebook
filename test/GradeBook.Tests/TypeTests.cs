using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
       
            var book = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal(book.name, "Book 1" );
            Assert.Equal(book2.name, "Book 2");

        }

        [Fact]
        public void ReferenceSameObject()
        {
       
            var book = GetBook("Book 1");
            var book2 = book;
            Assert.Same(book, book2);
            Assert.True(Object.ReferenceEquals(book, book2));
        }


        Book GetBook(string name)
        {
            return new Book(name);

        }
    }
}
