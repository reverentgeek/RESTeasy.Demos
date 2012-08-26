using System;
using System.Web.Mvc;
using RESTeasy.Demos.Helpers;
using RESTeasy.Demos.Models;

namespace RESTeasy.Demos.Controllers
{
    public class InitSamplesController : Controller
    {
        //
        // GET: /InitSamples/

        public ActionResult Index()
        {
			using(var session  = RavenHelper.Store.OpenSession())
			{
				var book = new Book
					{
						Author = "Charles Dickens",
						Title = "A Tale of Two Cities",
						Description = "Depicts the plight of the French peasantry leading up to the revolution.",
						Published = new DateTime(1859, 8, 1)
					};
				session.Store(book);
				book = new Book
				{
					Author = "Mark Twain",
					Title = "The Adventures of Tom Sawyer",
					Description = "Clever story about a boy growing up on the Mississippi River.",
					Published = new DateTime(1876, 8, 1)
				};
				session.Store(book);
				book = new Book
				{
					Author = "J.R.R. Tolkein",
					Title = "The Hobbit",
					Description = "Epic adventures of Bilbo Baggins' treasure hunt.",
					Published = new DateTime(1937, 9, 21)
				};
				session.Store(book);
				book = new Book
				{
					Author = "C.S. Lewis",
					Title = "The Lion, the Witch, and the Wardrobe",
					Description = "Four children discover a secret door into the world of Narnia.",
					Published = new DateTime(1950, 10, 16)
				};
				session.Store(book);

				session.SaveChanges();
			}
            return View();
        }

    }
}
