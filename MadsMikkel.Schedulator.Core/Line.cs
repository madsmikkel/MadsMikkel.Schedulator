using System;
using System.Collections;
using System.Collections.Generic;

namespace MadsMikkel.Schedulator.Core
{
	public class Line: ICollection
	{
		/// <summary>
		/// ArrayList of stations in even indices, and sections in odd indices.
		/// </summary>
		protected ArrayList line;

		/// <summary>
		/// Initializes a new instance of this class. Uses the specified list of stations to create an arraylist
		/// of stations and sections. Stations are at even indices, in the order they are in the specified list 
		/// of stations, and the sections between stations are at odd indices.
		/// </summary>
		/// <param name="stations">The list of stations used to generate the line.</param>
		public Line(List<Station> stations)
		{
			// Initialize the ArrayList with the known number of indices:
			line = new ArrayList(stations.Count * 2 - 1);

			// For each station, we must get the list of section to its neighbors. Then we must determine the exact 
			// section between tthis station and the next.			
			for(int i = 1; i <= stations.Count; i++)
			{
				line.Insert(i - 1, stations[i - 1]);
				foreach(KeyValuePair<Section, Station> kv in stations[i - 1].SectionsToNeigbors)
					if(i < stations.Count - 1)
						if(kv.Value == stations[i])
							line.Insert(i * 2 - 1, kv.Key);
			}
		}

		public virtual object this[int index]
		{
			get
			{
				if(index < line.Count)
					return line[index];
				else throw new IndexOutOfRangeException();
			}
			set
			{
				if(index < line.Count)
					if((index % 2 == 0 && value is Station) || (index % 2 != 0 && value is Section))
						line[index] = value;
					else throw new ArgumentException();
				else throw new IndexOutOfRangeException();
			}
		}

		public int Count
		{
			get
			{
				return ((ICollection)line).Count;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return ((ICollection)line).IsSynchronized;
			}
		}

		public object SyncRoot
		{
			get
			{
				return ((ICollection)line).SyncRoot;
			}
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)line).CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return ((ICollection)line).GetEnumerator();
		}

		public override string ToString()
		{
			string s = String.Empty;
			for(int i = 0; i < line.Count; i++)
				s += line[i].ToString() + "\n";
			return s;
		}
	}
}
