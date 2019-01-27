using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();
            CareTake history = new CareTake();
            history.Momento = book.CreateUndo();

            book.Isbn = "54321";
            book.Title = "Victor Hugo";
            book.Author = "Can Özaytekin";

            book.ShowBook();

            book.RestoreFromUndo(history.Momento);
            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        private DateTime LastEdit { get; set; }

        private void SetLastEdited()
        {
            LastEdit = DateTime.Now;
        }

        public Momento CreateUndo()
        {
            return new Momento(Isbn, Title, Author, LastEdit);
        }

        public void RestoreFromUndo(Momento momento)
        {
            Title = momento.Title;
            Author = momento.Author;
            Isbn = momento.Isbn;
            LastEdit = momento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2},edited:{3}", Isbn, Title, Author, LastEdit);
        }
    }

    class Momento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Momento(string isbn, string title, string author, DateTime lastEdit)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = LastEdited;
        }
    }

    class CareTake
    {
        public Momento Momento { get; set; }
    }
}
