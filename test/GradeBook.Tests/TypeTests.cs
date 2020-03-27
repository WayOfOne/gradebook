using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void PassByValueTest()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void PassByRefTest()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
 
            var book1 = GetBook("Book 1");
            CanSetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
       
            var book = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal(book.Name, "Book 1" );
            Assert.Equal(book2.Name, "Book 2");

        }

        [Fact]
        public void ReferenceSameObject()
        {
       
            var book = GetBook("Book 1");
            var book2 = book;
            Assert.Same(book, book2);
            Assert.True(Object.ReferenceEquals(book, book2));
        }

        private void CanSetName(Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName( ref Book book, string name)
        {
            book = new Book(name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
