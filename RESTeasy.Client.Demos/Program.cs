using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTeasy.Client.Demos
{
	class Program
	{
		static void Main(string[] args) 
		{ 
			var demo1 = new HttpClientDemo();
			
			demo1.SearchTwitter("devlink");

			Console.WriteLine("Searching twitter...");
			Console.ReadKey(true);
		}
	}
}
