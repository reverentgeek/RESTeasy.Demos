using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace RESTeasy.Demos.Models
{
	[RestService("/books")]
	public class Books
	{
		public Books() { Page = 1; }
		public int Page { get; set; }
	}

	[RestService("/books"), RestService("/books/{Id}")]
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Author { get; set; }
		public DateTime Published { get; set; }
	}

	public class BookResponse : IHasResponseStatus
	{
		public Book Book { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

	public class BooksResponse : IHasResponseStatus
	{
		public IList<Book> Books { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

}