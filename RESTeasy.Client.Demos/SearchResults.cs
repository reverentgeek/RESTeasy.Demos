using System.Collections.Generic;
using Newtonsoft.Json;

namespace RESTeasy.Client.Demos
{
	public class SearchResults
	{
		public SearchResults() { Results = new List<Tweet>(); }

		[JsonProperty(PropertyName = "results")]
		public List<Tweet> Results { get; set; }

		[JsonProperty(PropertyName = "results_per_page")]
		public int ResultsPerPage { get; set; }

		public int Page { get; set; }

		[JsonProperty(PropertyName = "next_page")]
		public string NextPage { get; set; }

		[JsonProperty(PropertyName = "refresh_url")]
		public string RefreshUrl { get; set; }
	}
}