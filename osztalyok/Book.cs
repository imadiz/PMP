using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osztalyok
{
    public class Book
    {
        private string PublisherName { get; set; }
        private string Title { get; set; }
        private int YearPublished { get; set; }
        private int PageCount { get; set; }

        public string AllData()
        {
            return $"{PublisherName}: {Title}, {YearPublished} ({PageCount} pages)";
        }
        public Book(string publisherName, string title, int yearPublished, int pageCount)
        {
            PublisherName = publisherName;
            Title = title;
            YearPublished = yearPublished;
            PageCount = pageCount;
        }
    }
}
