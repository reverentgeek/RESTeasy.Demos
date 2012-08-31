using System;
using System.Collections.Generic;
using RESTeasy.Demos.Library;
using RestSharp;

namespace RESTeasy.Demos.Client
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

		public void AddBook(IBook book) 
		{ 
			var client = new RestClient("http://rest.test.com/services");
			var request = new RestRequest("books", Method.POST);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(book);

			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}

		public void UpdateBook(IBook book)
		{
			var client = new RestClient("http://rest.test.com/services");
			var request = new RestRequest("books", Method.PUT);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(book);

			var response = client.Execute(request);
			Console.WriteLine(response.Content);	
		}

		public void DeleteBook(int id)
		{
			var client = new RestClient("http://rest.test.com/services");
			var request = new RestRequest("books", Method.DELETE);
			request.AddParameter("Id", id);

			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}
	}
}
