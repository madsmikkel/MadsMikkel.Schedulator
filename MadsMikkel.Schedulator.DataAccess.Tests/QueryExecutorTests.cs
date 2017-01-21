using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MadsMikkel.Schedulator.Core;
using MadsMikkel.Schedulator.DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace MadsMikkel.Schedulator.DataAccess.Tests
{
	[TestClass]
	public class QueryExecutorTests
	{
		string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchedulatorDb;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		[TestMethod]
		public void ConnectToDb()
		{
			StationHandler executor = null; 
			try
			{
				executor = new StationHandler(new SqlConnection(connectionString));
			}
			catch(Exception e)
			{
				Assert.Fail($"Exception caught: {e.Message}", e);
			}
			Assert.IsNotNull(executor);
		}

		[TestMethod]
		public void GetDataSet()
		{
			DataSet set = null;
			DataTableCollection tables = null;
			int actual = 0, expected = 1;
			string query = "SELECT * FROM SubSectionInfos";
			StationHandler executor = new StationHandler(new SqlConnection(connectionString));
			var x = executor.SelectRows(query);
			actual = executor.SelectRows(query).Tables.Count;
			Assert.AreEqual(actual > 0, expected > 0);
		}

		[TestMethod]
		public void MyTestMethod()
		{
			DataSet set = null;
			DataTableCollection tables = null;
			string query = "SELECT * FROM SubSectionInfos";
			StationHandler executor = new StationHandler(new SqlConnection(connectionString));
			var x = executor.SelectRows(query);
		}
	}
}
