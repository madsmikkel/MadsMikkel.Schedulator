using System;
using System.Collections.Generic;

namespace MadsMikkel.Schedulator.Core
{
	public class Section
	{
		protected decimal length;
		protected List<SubSection> subSections;


		public Section(IEnumerable<SubSection> subSections)
		{
			if(subSections == null)
				throw new ArgumentNullException();
			this.subSections = subSections as List<SubSection>;
			if(this.subSections.Count > 0)
				foreach(SubSection subSection in this.subSections)
					this.length += subSection.Length;
			else throw new ArgumentOutOfRangeException();
		}


		public override string ToString()
		{
			return $"Section length: {length}";
		}

		public List<SubSection> SubSections
		{
			get
			{
				return subSections;
			}

			set
			{
				subSections = value;
			}
		}
	}
}