using System;

namespace RESTeasy.Demos.Library
{
	public interface IBook
	{
		int Id { get; set; }
		string Title { get; set; }
		string Description { get; set; }
		string Author { get; set; }
		DateTime Published { get; set; }
	}
}
