using System;
using PeriodicTableScraper;


namespace PeriodicTableScraper
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			// Create Database Connection
			StoreResults.CreateConnection();

			//Create Database. 
			StoreResults.CreateDatabase();

			//Create Table
			StoreResults.CreateTable ();

			// Scrape Los Alamos for elements 
			GetData.GetElements();

			//Iterate through elements and scrape each one. 
			foreach (string address in GetData.countries) {

				ScrapePeriodicTable.url = address;
				Console.WriteLine(address);

				ScrapePeriodicTable.ScrapeTables();
				ScrapePeriodicTable.PrintResults();

				StoreResults.AddRecord ();
			}
		}
	}
}
