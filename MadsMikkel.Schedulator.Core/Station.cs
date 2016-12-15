using System;
using System.Collections.Generic;
using System.Linq;

namespace MadsMikkel.Schedulator.Core
{
	public class Station
	{
		protected string name;
		protected Dictionary<Section, Station> linesToNeighbors;

		public Station() : this(String.Empty) { }

		public Station(string name) : this(name, null){}

		public Station(string name, Dictionary<Section, Station> linesToNeighbors)
		{
			this.name = name ?? String.Empty;
			this.linesToNeighbors = linesToNeighbors ?? new Dictionary<Section, Station>(0);
		}

		public void Add(Station neighbor, Section lineToNeighbor)
		{
			if(neighbor == null || lineToNeighbor == null)
				throw new ArgumentNullException();
			else if(!this.linesToNeighbors.Keys.Contains(lineToNeighbor) &&
				!this.linesToNeighbors.Values.Contains(neighbor))
				this.linesToNeighbors.Add(lineToNeighbor, neighbor);
		}

		public virtual string Name { get; set; }
		public Dictionary<Section, Station> LinesToNeigbors { get; protected set; }

	}


}