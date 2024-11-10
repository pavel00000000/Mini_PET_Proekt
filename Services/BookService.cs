using Mini_PET_Proekt.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Mini_PET_Proekt.Services
{

    public interface IBookService
    {
        List<Book> GetBooks();
        void AddBook(Book book);
    }

    public class BookSservice : IBookService
    {
        private readonly MySqlConnection _connection;

        public BookSservice(MySqlConnection connection)
        {
            _connection = connection;
        }

        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            _connection.Open();
            var query = "SELECT * FROM books";
            using (var command = new MySqlCommand(query, _connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt32("Id"),
                        Title = reader.GetString("Title"),
                        Author = reader.GetString("Author"),
                        Year = reader.GetInt32("Year")
                    });
                }
            }
            _connection.Close();
            return books;
        }

        public void AddBook(Book book)
        {
            _connection.Open();
            var query = "INSERT INTO books (Title, Author, Year) VALUES (@Title, @Author, @Year)";
            using (var command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Year", book.Year);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}
