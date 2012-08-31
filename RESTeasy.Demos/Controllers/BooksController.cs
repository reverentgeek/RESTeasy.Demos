using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTeasy.Demos.Helpers;
using RESTeasy.Demos.Models;

namespace RESTeasy.Demos.Controllers
{
    public class BooksController : ApiController
    {
		private const int PageSize = 2;

		public IEnumerable<Book> Get(int id = 0, int page = 1)
        {
			using (var session = RavenHelper.Store.OpenSession())
			{
				var query = session.Query<Book>().OrderBy(x => x.Title)
					.Take(PageSize).Skip((page - 1) * PageSize);

				var books = query.ToList();
				return books;
			}
        }

		public IEnumerable<Book> Get(string version, int id = 0, int page = 1)
		{
			if (version == "v2")
			{
				using (var session = RavenHelper.Store.OpenSession())
				{
					var query = session.Query<Book>().OrderBy(x => x.Title).Take(PageSize).Skip((page - 1)*PageSize);

					var books = query.ToList();
					return books;
				}
			}
			else
			{
				throw new HttpResponseException(
					new HttpResponseMessage(HttpStatusCode.NotImplemented)
						{
							ReasonPhrase = "This version of the API does not implement this Books interface"
						});
			}
		}

        // GET api/books/5
        public Book Get(int id)
        {
			using (var session = RavenHelper.Store.OpenSession())
			{
				var book = session.Load<Book>(id);
				return book;
			}
        }

        // POST api/books
        public HttpResponseMessage Post(Book book)
        {
			using (var session = RavenHelper.Store.OpenSession())
			{
				session.Store(book);
				session.SaveChanges();
				var response = Request.CreateResponse(HttpStatusCode.Created, book);
				response.Headers.Location = new Uri(Request.RequestUri, string.Format("books/{0}", book.Id));
				return response;
			}
        }

        // PUT api/books/5
		public HttpResponseMessage Put(Book book)
        {
			using (var session = RavenHelper.Store.OpenSession())
			{
				var realBook = session.Load<Book>(book.Id);
				realBook.Title = book.Title;
				realBook.Description = book.Description;
				realBook.Author = book.Author;
				realBook.Published = book.Published;

				session.SaveChanges();
				var response = Request.CreateResponse(HttpStatusCode.Accepted, realBook);

				return response;
			}
        }

        // DELETE api/books/5
		public HttpResponseMessage Delete(int id)
        {
			using (var session = RavenHelper.Store.OpenSession())
			{
				var book = session.Load<Book>(id);
				session.Delete(book);

				session.SaveChanges();
				var response = Request.CreateResponse(HttpStatusCode.Accepted, id);

				return response;
			}
        }
    }
}
