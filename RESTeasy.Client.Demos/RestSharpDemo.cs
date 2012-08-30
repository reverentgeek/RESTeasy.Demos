using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RESTeasy.Client.Demos
{
	public class RestSharpDemo
	{
		public void SearchTwitter(string search)
		{
			var client = new RestClient("http://search.twitter.com");
			var request = new RestRequest("search.json", Method.GET);
			request.AddParameter("q", search);
			
			// Return results as string
			// var response = client.Execute(request);
			// var content = response.Content;

			var response = client.Execute<SearchResults>(request);
			PrintTweets(response.Data.Results);
		}

		public void PrintTweets(List<Tweet> tweets)
		{
			foreach (var tweet in tweets)
			{
				Console.WriteLine("{0:MM/dd/yyyy hh:mm}", tweet.CreatedAt);
				Console.WriteLine("{0} (@{1})", tweet.FromUserName, tweet.FromUser);
				Console.WriteLine(tweet.Text);
				Console.WriteLine("");
			}
			
		}
	}
}
