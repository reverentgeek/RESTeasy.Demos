using System;
using Newtonsoft.Json;

namespace RESTeasy.Client.Demos
{
	public class Tweet
	{
		[JsonProperty(PropertyName = "created_at")]
		public DateTime Created { get; set; }
		public string Text { get; set; }
		[JsonProperty(PropertyName = "from_user")]
		public string FromUser { get; set; }
		[JsonProperty(PropertyName = "from_user_name")]
		public string FromName { get; set; }
	}
}