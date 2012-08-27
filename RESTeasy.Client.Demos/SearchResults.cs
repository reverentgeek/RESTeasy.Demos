using Newtonsoft.Json;

namespace RESTeasy.Client.Demos
{
	public class SearchResults
	{
		[JsonProperty(PropertyName = "results")]
		public Tweet[] Tweets { get; set; }

		[JsonProperty(PropertyName = "results_per_page")]
		public int ResultsPerPage { get; set; }

		public int Page { get; set; }

		[JsonProperty(PropertyName = "next_page")]
		public string NextPage { get; set; }

		[JsonProperty(PropertyName = "refresh_url")]
		public string RefreshUrl { get; set; }
	}
}