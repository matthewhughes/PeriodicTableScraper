using System;
using System.Net;
using System.IO; 
using System.Collections.Generic;
using HtmlAgilityPack;

namespace PeriodicTableScraper
{
	public class ScrapePeriodicTable
	{
		public static string url;
		public static string Element;
		public static string AtomicNumber;
		public static string AtomicRadius;
		public static string AtomicSymbol;
		public static string MeltingPoint;
		public static string AtomicWeight;
		public static string BoilingPoint;
		public static string ElectronConfiguration;
		public static string OxidationStates;

		public static HtmlDocument GetPage(){
			var WebGet = new HtmlWeb();
			var doc = WebGet.Load(url);
			return doc;
		}

		public static void ScrapeTables(){
			HtmlDocument result = GetPage();

			Element = result.DocumentNode.SelectSingleNode("//h2[@class='feature']").InnerText;
			Console.WriteLine(Element);

			HtmlNode node = result.DocumentNode.SelectSingleNode("//table[@class='data']");
			if (node != null) {
				AtomicNumber = node.SelectSingleNode ("//table[@class='data']/tr[1]/td[2]").InnerText;
				AtomicRadius = node.SelectSingleNode("//table[@class='data']/tr[1]/td[4]").InnerText;
				AtomicSymbol = node.SelectSingleNode("//table[@class='data']/tr[2]/td[2]").InnerText;
				MeltingPoint = node.SelectSingleNode("//table[@class='data']/tr[2]/td[4]").InnerText;
				AtomicWeight = node.SelectSingleNode("//table[@class='data']/tr[3]/td[2]").InnerText;
				BoilingPoint = node.SelectSingleNode("//table[@class='data']/tr[3]/td[4]").InnerText;
				ElectronConfiguration = node.SelectSingleNode("//table[@class='data']/tr[4]/td[2]").InnerText;
				OxidationStates = node.SelectSingleNode("//table[@class='data']/tr[4]/td[4]").InnerText;

				// TODO: write desc somewhere
			}
		}

		public static void PrintResults(){
			Console.WriteLine ("Atomic Number : " + AtomicNumber);
			Console.WriteLine ("Atomic Radius : " + AtomicRadius);
			Console.WriteLine ("Atomic Symbol : " + AtomicSymbol);
			Console.WriteLine ("Melting point : " + MeltingPoint);
			Console.WriteLine ("Atomic Weight : " + AtomicWeight);
			Console.WriteLine ("Boiling Point : " + BoilingPoint);
			Console.WriteLine ("Electron Configuration :" + ElectronConfiguration);
			Console.WriteLine ("Oxidation States : " + OxidationStates);
		}
			
	}
}

