namespace MadsMikkel.Schedulator.Core
{
	public class SubSection
	{
		SectionInfo info;

		public SubSection(SectionInfo info)
		{
			this.Info = info;
		}

		public SectionInfo Info
		{
			get
			{
				return info;
			}

			set
			{
				info = value;
			}
		}
	}
}