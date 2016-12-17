using System;
using System.Data;
using System.Data.SqlClient;

#if DEBUG
[assembly: 
	System.Runtime.CompilerServices.InternalsVisibleTo("MadsMikkel.Schedulator.DataAccess.Tests")]
#endif
namespace MadsMikkel.Schedulator.DataAccess
{

	internal class QueryExecutor
	{
		protected SqlConnection connection;

		internal QueryExecutor(SqlConnection connection)
		{
			if(connection == null)
				throw new ArgumentNullException();
			try
			{
				connection.Open();
				connection.Close();
			}
			catch(SqlException)
			{
				throw;
			}
			catch(InvalidOperationException)
			{
				throw;
			}
			catch(System.Configuration.ConfigurationException)
			{
				throw;
			}
			this.connection = connection;
		}

		internal DataSet SelectRows(string queryString)
		{
			DataSet dataSet = new DataSet();
			using(connection)
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				adapter.SelectCommand = new SqlCommand(queryString, connection);
				try
				{
					adapter.Fill(dataSet);
				}
				catch(InvalidOperationException)
				{
					throw;
				}
			}
			return dataSet;
		}
	}
}
