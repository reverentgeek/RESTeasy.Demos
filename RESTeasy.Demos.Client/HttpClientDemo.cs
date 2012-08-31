using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace RESTeasy.Demos.Client
{
	public class HttpClientDemo
	{
		public async void SearchTwitterDynamic(string search)
		{
			const string serverAddress = "http://search.twitter.com";

			try
			{
				using (var client = new HttpClient {BaseAddress = new Uri(serverAddress)})
				{
					var response = await client.GetStringAsync("search.json?q=" + search);

					var searchResults = JsonConvert.DeserializeObject<dynamic>(response);
					foreach(var result in searchResults.results)
					{
						Console.WriteLine(result.created_at);
						Console.WriteLine("{0} (@{1})", result.from_user_name, result.from_user);
						Console.WriteLine(result.text);
						Console.WriteLine("");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public async void SearchTwitterStronglyTyped(string search)
		{
			const string serverAddress = "http://search.twitter.com";

			try
			{
				using (var client = new HttpClient { BaseAddress = new Uri(serverAddress) })
				{
					var response = await client.GetStringAsync("search.json?q=" + search);

					var searchResults = JsonConvert.DeserializeObject<SearchResults>(response);

					PrintTweets(searchResults.Results);
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void PrintTweets(List<Tweet> tweets)
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
