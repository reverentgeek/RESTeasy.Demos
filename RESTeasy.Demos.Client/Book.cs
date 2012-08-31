using System;
using RESTeasy.Demos.Library;

namespace RESTeasy.Demos.Client
{
	public class Book : IBook
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Author { get; set; }
		public DateTime Published { get; set; }
	}
}
