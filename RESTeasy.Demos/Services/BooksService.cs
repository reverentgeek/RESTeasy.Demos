using System;
using System.Linq;
using RESTeasy.Demos.Helpers;
using RESTeasy.Demos.Models;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace RESTeasy.Demos.Services
{
	

	public class BooksService : RestServiceBase<Books>
	{
		private const int PageSize = 30;
		
		public override object OnGet(Books request)
		{
			var response = new BooksResponse();
			try
			{
				using (var session = RavenHelper.Store.OpenSession())
				{
					var query = session.Query<Book>().OrderBy(x => x.Title)
						.Take(PageSize).Skip((request.Page - 1) * PageSize);

					response.Books = query.ToList();
					return response;
				}

			}
			catch (Exception ex)
			{
				response.ResponseStatus = new ResponseStatus("500", ex.Message);
				return response;
			}
		}
	}

	public class BookService : RestServiceBase<Book>
	{
		public override object OnGet(Book request)
		{
			var response = new BookResponse();
			try
			{
				using (var session = RavenHelper.Store.OpenSession())
				{
					var book = session.Load<Book>(request.Id);
					response.Book = book;
					if (book == null)
					{
						response.ResponseStatus = new ResponseStatus("404", "Book not found");
					}
					return response;
				}

			}
			catch (Exception ex)
			{
				response.ResponseStatus = new ResponseStatus("500", ex.Message);
				return response;
			}
		}

		public override object OnPost(Book request)
		{
			var response = new BookResponse();
			try
			{
				using (var session = RavenHelper.Store.OpenSession())
				{
					var book = new Book
						{
							Title = request.Author, 
							Description = request.Description, 
							Author = request.Author, 
							Published = request.Published
						};
					
					session.Store(book);
					session.SaveChanges();
					response.Book = book;

					return response;
				}

			}
			catch (Exception ex)
			{
				response.ResponseStatus = new ResponseStatus("500", ex.Message);
				return response;
			}
		}

		public override object OnPut(Book request)
		{
			var response = new BookResponse();
			try
			{
				using (var session = RavenHelper.Store.OpenSession())
				{
					var book = session.Load<Book>(request.Id);
					if (book == null)
					{
						response.ResponseStatus = new ResponseStatus("404", "Book not found");
						return response;
					}
					book.Title = request.Author;
					book.Description = request.Description;
					book.Author = request.Author;
					book.Published = request.Published;

					session.SaveChanges();
					response.Book = book;

					return response;
				}

			}
			catch (Exception ex)
			{
				response.ResponseStatus = new ResponseStatus("500", ex.Message);
				return response;
			}
		}

		public override object OnDelete(Book request)
		{
			var response = new BookResponse();
			try
			{
				using (var session = RavenHelper.Store.OpenSession())
				{
					var book = session.Load<Book>(request.Id);
					if (book == null)
					{
						response.ResponseStatus = new ResponseStatus("404", "Book not found");
						return response;
					}
					session.Delete(book);
					session.SaveChanges();
					// response.ResponseStatus = new ResponseStatus("202");

					return response;
				}

			}
			catch (Exception ex)
			{
				response.ResponseStatus = new ResponseStatus("500", ex.Message);
				return response;
			}
		}
	}

}