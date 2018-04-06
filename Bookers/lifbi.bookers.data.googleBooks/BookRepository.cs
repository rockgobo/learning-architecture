using lifbi.bookers.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace lifbi.bookers.data.googleBooks
{
    public class BookRepository : IBooksRepository
    {

        public IEnumerable<model.Book> GetAll()
        {
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=WPF").Result;
            }

            BookQuery result = JsonConvert.DeserializeObject<BookQuery>(json);

            //Konvert BookQuery to Book
            List<model.Book> output = new List<model.Book>();
            foreach(Book b in result.Items)
            {
                model.Book newBook = new model.Book();
                newBook.Title = b.BookInfo.Title;
                newBook.Author = b.BookInfo.Authors.Aggregate((x, y) => x + ", " + y);
                newBook.Pages = Convert.ToInt32(b.BookInfo.PageCount);
                newBook.Price = Convert.ToDecimal(b?.SaleInfo?.ListPrice?.Amount);
                output.Add(newBook);
            }
            return output;
        }

        public model.Book GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public model.Book GetMostExpensiveBook()
        {
            throw new NotImplementedException();
        }

        public IQueryable<model.Book> Query()
        {
            throw new NotImplementedException();
        }

        #region Can not be implemented
        public void Save()
        {
            throw new NotImplementedException();
        }
        public void Update(model.Book entity)
        {
            throw new NotImplementedException();
        }
        public void Add(model.Book entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(model.Book entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
