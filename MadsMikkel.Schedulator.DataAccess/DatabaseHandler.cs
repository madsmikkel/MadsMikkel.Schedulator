using System;
using System.Data;
using System.Data.SqlClient;

#if DEBUG
[assembly:
	System.Runtime.CompilerServices.InternalsVisibleTo("MadsMikkel.Schedulator.DataAccess.Tests")]
#endif

namespace MadsMikkel.Schedulator.DataAccess
{

	/// <summary>
	/// Abstract base class for exposing SQL DML functionality.
	/// </summary>
	public abstract class DatabaseFacade
	{
		#region Fields
		protected QueryExecutor executor;
		#endregion


		#region Constructors
		static DatabaseFacade()
		{

		}

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public DatabaseFacade()
		{
			// TODO: load connection string from app.config to query executor.
		}
		#endregion


		#region Nested members
		/// <summary>
		/// Represents a SQL Server transaction executor.
		/// </summary>
		protected class QueryExecutor
		{

			#region Fields
			/// <summary>
			/// The sql connection.
			/// </summary>
			protected SqlConnection connection;
			#endregion


			#region Constructor
			/// <summary>
			/// Initializes a new instance of this class, using the provided connection string.
			/// </summary>
			/// <param name="connectionString"></param>
			internal QueryExecutor(string connectionString)
			{
				if(String.IsNullOrWhiteSpace(connectionString))
				{
					throw new ArgumentException();
				}
				connection = new SqlConnection(connectionString);
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
			}
			#endregion


			#region Methods
			/// <summary>
			/// Gets a filled dataset using the provided SQL statement.
			/// </summary>
			/// <param name="queryString">A SELECT type of SQL statement.</param>
			/// <returns></returns>
			internal DataSet GetDataSet(string queryString)
			{
				using(SqlDataAdapter adapter = new SqlDataAdapter())
				{
					try
					{
						DataSet set = new DataSet();
						adapter.SelectCommand = new SqlCommand();
						adapter.SelectCommand.CommandText = queryString;
						adapter.SelectCommand.Connection = connection;
						DataTable table = new DataTable();
						table.BeginLoadData();
						adapter.Fill(table);
						table.EndLoadData();
						set.EnforceConstraints = false;
						set.Tables.Add(table);
						return set;
					}
					catch(InvalidOperationException)
					{
						throw;
					}
				}
			}

			/// <summary>
			/// Attempts to commit changes to the database, using the provided DataSet.
			/// </summary>
			/// <param name="changeSet">The DataSet containing the changes to the database to be 
			/// made.</param>
			internal void ManipulateData(DataSet changeSet)
			{
				using(SqlDataAdapter adapter = new SqlDataAdapter())
				{
					try
					{
						
					}
					catch(Exception)
					{
						throw;
					}
					finally
					{

					}
				}
			}
			#endregion
		}
		#endregion
	}
}