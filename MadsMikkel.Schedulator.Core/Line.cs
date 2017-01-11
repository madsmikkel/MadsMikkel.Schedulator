using System;
using System.Collections;
using System.Collections.Generic;

namespace MadsMikkel.Schedulator.Core
{
	public class Line
	{
		ArrayList line;
		public Line(List<Station> stations)
		{
			line = new ArrayList(stations.Count*2-1);
			for(int i = 0; i < stations.Count; i++)
			{
				line.Insert(i * 2, stations[i]);
				foreach(KeyValuePair<Section, Station> kv in stations[i].SectionsToNeigbors)
					if(i < stations.Count - 1)
						if(kv.Value == stations[i])
							line.Insert(i * 2 - 1, kv.Key);

			}
		}

		public override string ToString()
		{
			string s = String.Empty;
			for(int i = 0; i < line.Count; i++)
			{
				s += line[i].ToString();
			}
			return s;
		}
	}
}
