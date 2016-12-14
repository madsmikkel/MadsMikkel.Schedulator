using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadsMikkel.Schedulator.Core
{
    public class Station
    {
		public virtual string Name { get; set; }
		public virtual List<Station> Neighbors { get; protected set; }
		public SortedDictionary<Station, Line> LinesToNeigbors { get; protected set; }

    }
}
