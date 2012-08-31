using System;

namespace RESTeasy.Demos.Client
{
	class Program
	{
		static void Main(string[] args) 
		{
			var demo1 = new HttpClientDemo();
			demo1.SearchTwitterDynamic("devlink");
			//demo1.SearchTwitterStronglyTyped("devlink");

			Console.WriteLine("Searching twitter...");

			//var demo2 = new RestSharpDemo();
			//demo2.SearchTwitter("devlink");

			//var book = new Book
			//	{
			//		Author = "David Neal",
			//		Title = "RavenDB in Action",
			//		Description = "Awesome book on RavenDB",
			//		Published = DateTime.Now.AddYears(1)
			//	};

			//demo1.AddBook(book);
			//demo2.AddBook(book);

			//book.Id = 65;
			//book.Description = "Really awesome book on RavenDB, actually.";
			//demo2.UpdateBook(book);

			//demo2.DeleteBook(book.Id);

			Console.WriteLine("Press any key...");
			Console.ReadKey(true);
		}
	}
}
