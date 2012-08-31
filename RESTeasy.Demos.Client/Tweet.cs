using System;
using Newtonsoft.Json;

namespace RESTeasy.Demos.Client
{
	public class Tweet
	{
		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; set; }
		public string Text { get; set; }
		[JsonProperty(PropertyName = "from_user")]
		public string FromUser { get; set; }
		[JsonProperty(PropertyName = "from_user_name")]
		public string FromUserName { get; set; }
	}
}