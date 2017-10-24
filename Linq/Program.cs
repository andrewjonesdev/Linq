using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            /*var cheapBooks = new List<Book>();
            foreach (var book in books)
            {
                if(book.Price <10)
                {
                    cheapBooks.Add(book);
                }
            }*/

            //LINQ Query Operators Syntax for more clean
            var cheaperBooks = from b in books
                               where b.Price < 10
                               orderby b.Title
                               select b;
            var cheaperBookTitles = from b in books
                                    where b.Price < 10
                                    orderby b.Title
                                    select b.Title;

            //LINQ Extension Methods Syntax for more in depth
            var cheapBooks = books
                                .Where(b => b.Price < 10)
                                .OrderBy(b => b.Title);
            var cheapBookTitles = books
                                    .Where(b => b.Price < 10)
                                    .OrderBy(b => b.Title)
                                    .Select(b => b.Title);
            //books.OrderBy(b => b.Title);
            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title + " " + book.Price);
            }

            Console.WriteLine();

            foreach (var book in cheapBookTitles)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();

            var bookOne = books.Single(b => b.Title == "ASP.NET MVC");
            Console.WriteLine(bookOne.Title + " " + bookOne.Price);

            Console.WriteLine();

            var bookTwo = books.SingleOrDefault(b => b.Title == "ASP.NET MVC++");
            if (bookTwo == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(bookTwo.Title + " " + bookTwo.Price);
            }

            Console.WriteLine();

            var bookThree = bookTwo==null?("null"): (bookTwo.Title + " " + bookTwo.Price);
            Console.WriteLine(bookThree);

            Console.WriteLine();
            var bookFour = books.FirstOrDefault(b => b.Title == "C# Advanced Topics");
            var bookFive = bookFour == null ? ("null") : (bookFour.Title + " " + bookFour.Price);
            Console.WriteLine(bookFive);

            Console.WriteLine();
            var bookSix = books.LastOrDefault(b => b.Title == "C# Advanced Topics");
            var bookSeven = bookSix == null ? ("null") : (bookSix.Title + " " + bookSix.Price);
            Console.WriteLine(bookSeven);

            Console.WriteLine();
            var pagedBooks = books.Skip(2).Take(3);
            foreach (var book in pagedBooks)
            {
                Console.WriteLine(book.Title + " " + book.Price);
            }

            Console.WriteLine();
            var count = books.Count();
            Console.WriteLine(count + " books");

            Console.WriteLine();
            var max = books.Max(b => b.Price);
            Console.WriteLine("$" + max);

            Console.WriteLine();
            var min = books.Min(b => b.Price);
            Console.WriteLine("$" + min);

            Console.WriteLine();
            var sum = books.Sum(b => b.Price);
            Console.WriteLine("$" + sum);

            Console.WriteLine();
            var avg = books.Average(b => b.Price);
            Console.WriteLine("$" + avg);
            //Func<int, int, int> add = (a, b) => a + b;
            //Console.WriteLine(add(2, 3));
        }

        private static float CalculateDiscount(float price)
        {
            return 0;
        }

    
    }
}
