using System;

namespace RESTeasy.Client.Demos
{
	class Program
	{
		static void Main(string[] args) 
		{ 
			//var demo1 = new HttpClientDemo();
			
			//demo1.SearchTwitterDynamic("devlink");

			Console.WriteLine("Searching twitter...");

			var demo2 = new RestSharpDemo();
			demo2.SearchTwitter("devlink");

			Console.WriteLine("Press any key...");
			Console.ReadKey(true);
		}
	}
}
