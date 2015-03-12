using System;
using PeriodicTableScraper;
using HtmlAgilityPack;
using ScrapySharp.Core;
using ScrapySharp.Html.Parsing;
using ScrapySharp.Extensions;

namespace PeriodicTableScraper
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			GetData.GetCountries ();

			foreach (string address in GetData.countries) {

				ScrapePeriodicTable.url = address;
				Console.WriteLine (address);

				ScrapePeriodicTable.ScrapeTables();
				ScrapePeriodicTable.PrintResults();
			}
		}
	}
}
