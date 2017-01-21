using MadsMikkel.Schedulator.Core;
using System.Collections.Generic;

namespace MadsMikkel.Schedulator.DataAccess
{
	public class StationHandler: DatabaseFacade
	{
		#region Fields
		QueryExecutor executor; 
		#endregion


		#region Constructor
		public StationHandler()
		{
			 executor = new QueryExecutor("");
		}
		#endregion


		#region Methods
		public List<Station> GetAll<Station>()
		{
			List<Station> allStations = new List<Station>(0);

			return allStations;
		} 
		#endregion
	}
}
