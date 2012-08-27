using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace RESTeasy.Client.Demos
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

		public async void SearchTwitterTyped(string search)
		{
			const string serverAddress = "http://search.twitter.com";

			try
			{
				using (var client = new HttpClient { BaseAddress = new Uri(serverAddress) })
				{
					var response = await client.GetStringAsync("search.json?q=" + search);

					var searchResults = JsonConvert.DeserializeObject<SearchResults>(response);
					foreach (var tweet in searchResults.Tweets)
					{
						Console.WriteLine("{0:MM/dd/yyyy hh:mm}", tweet.Created);
						Console.WriteLine("{0} (@{1})", tweet.FromName, tweet.FromUser);
						Console.WriteLine(tweet.Text);
						Console.WriteLine("");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
