using System;
using System.Data.SQLite;

namespace PeriodicTableScraper
{
	public class StoreResults
	{

		public static SQLiteConnection Connection;
		public static SQLiteCommand Command;
		public static string CreateTableString;
		public static string InsertTableString;


		public static void CreateDatabase(){
			SQLiteConnection.CreateFile("PeriodicTable.sqlite");
		}

		public static void CreateConnection(){
			Connection =
				new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
			Connection.Open();
		}

		public static void CreateTable(){
			CreateTableString = "CREATE TABLE Periodic_Table (" +
				"Element VARCHAR(100)," +
				"AtomicNumber VARCHAR(10)," +
				"AtomicRadius VARCHAR(100)," +
				"AtomicSymbol VARCHAR(10)," +
				"MeltingPoint VARCHAR(10)," +
				"BoilingPoint VARCHAR(10)," +
				"ElectronConfiguration VARCHAR(10)," +
				"OxidationStates VARCHAR(10))";

			Command = new SQLiteCommand(CreateTableString, Connection);
			Command.ExecuteNonQuery();
		}

		public static void AddRecord(){
			InsertTableString = String.Format("INSERT INTO Periodic_Table (Element, AtomicNumber,  AtomicRadius" +
				", AtomicSymbol, MeltingPoint, BoilingPoint, ElectronConfiguration, OxidationStates) VALUES" +
				"({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", ScrapePeriodicTable.Element, ScrapePeriodicTable.AtomicNumber,
				ScrapePeriodicTable.AtomicRadius, ScrapePeriodicTable.AtomicSymbol, ScrapePeriodicTable.MeltingPoint,
				ScrapePeriodicTable.BoilingPoint, ScrapePeriodicTable.ElectronConfiguration, ScrapePeriodicTable.OxidationStates);

			Command = new SQLiteCommand (InsertTableString, Connection);
			Command.ExecuteNonQuery();

		}


	


	}
}

