using System;
using System.Collections.Generic;
using ManageDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManageDatabaseTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void PassingTest()
		{
			Database database = new Database();
			List<Column> columns = new List<Column>()
			{ new Column("Name", ColumnType.String), new Column("Age", ColumnType.Integer), new Column("HairColor", ColumnType.Color)};
			string equal_column1 = "{\"Name\":\"Vitaliy\", \"Age\" : \"15\", \"HairColor\" : \"r: 10, g:10, b:15\"}";
			List<Row> Reduced = new List<Row>() { new Row(equal_column1) };
			List<Row> Negative = new List<Row>() { new Row(equal_column1) };

			Table tableReduced = new Table() { Columns = columns, Rows = Reduced };
			Table tableNegative = new Table() { Columns = columns, Rows = Negative };

			Table tableResult = new Table() { Columns = columns };

			Assert.AreEqual(database.DifferenceTables(tableReduced, tableNegative), tableResult.GetData());
		}
		[TestMethod]
		public void PassingTest2()
		{
			Database database = new Database();
			List<Column> columns = new List<Column>() 
			{ new Column("Name", ColumnType.String), new Column("Age", ColumnType.Integer), new Column("HairColor", ColumnType.Color) };

			string equal_column1 = "{\"Name\":\"Vitaliy\", \"Age\" : \"20\", \"HairColor\" : \"r: 255, g:255, b:255\"}";
			string difference_column1 = "{\"Name\":\"DifferenceInReduced\", \"Age\" : \"25\", \"HairColor\" : \"r: 14, g:12, b:15\"}";
			string difference_column2 = "{\"Name\":\"DifferenceInNegative\", \"Age\" : \"72\", \"HairColor\" : \"r: 5, g:3, b:15\"}";
			List<Row> Reduced = new List<Row>() { new Row(equal_column1), new Row(difference_column1) };
			List<Row> Negative = new List<Row>() { new Row(equal_column1), new Row(difference_column2) };
			List<Row> Result = new List<Row>() { new Row(difference_column1) };
			Table tableReduced = new Table() { Columns = columns, Rows = Reduced };
			Table tableNegative = new Table() { Columns = columns, Rows = Negative };

			Table tableResult = new Table() { Columns = columns, Rows = Result };

			Assert.AreEqual(database.DifferenceTables(tableReduced, tableNegative), tableResult.GetData());
		}
		[TestMethod]
		public void PassingTest3()
		{

			Column column = new Column("Name", ColumnType.Integer);
			Assert.AreEqual(true, column.Equals(ParserColumns.ParseColumn("Name integer")));
			//Assert.A
		}
		[TestMethod]
		public void PassingTest4()
		{
			Column column = new Column("Colorinvl", ColumnType.ColorInvl, 10, 240);
			Assert.AreEqual(true, column.Equals(ParserColumns.ParseColumn("Colorinvl colorinvl 10 240")));
		}
		[TestMethod]
		public void PassingTest5()
		{
			LevelIn levelIn = new LevelIn();
			Database database = new Database();
			levelIn.LevelUp(database);
			Table table = new Table();
			levelIn.LevelUp(table);
			Assert.AreEqual(typeof(Table), levelIn.GetLevel().GetType());
		}
	}
}
