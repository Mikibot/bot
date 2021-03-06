﻿using Miki.API.Imageboards.Interfaces;
using Miki.Utility;
using Newtonsoft.Json;

namespace Miki.API.Imageboards.Objects
{
	public class CatImage : ILinkable
	{
		public string Url => File;
		public string Tags => "";
		public string SourceUrl => "";
        public string Score => "N/A";
		public string Provider => "Cat";

		[JsonProperty("file")]
		public string File { get; set; }
	}
}