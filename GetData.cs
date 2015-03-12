using System;
using System.Net;
using System.IO; 
using System.Collections.Generic;
using HtmlAgilityPack;


namespace PeriodicTableScraper
{
	public static class GetData
	{

		public static string url = "http://periodic.lanl.gov/index.shtml";
		public static List<string> countries = new List<string>();

		// Get Document

		public static HtmlDocument GetPage(){
			var WebGet = new HtmlWeb();
			var doc = WebGet.Load(url);
			return doc;
		}

		// Get Countries 

		public static void GetCountries(){

			HtmlDocument result = GetPage();

			foreach (HtmlNode node in result.DocumentNode.SelectNodes("//u/strong/a"))
			{
				var val = node.Attributes["href"].Value; 
				countries.Add("http://periodic.lanl.gov/" + val);
			}

		}

	}
}