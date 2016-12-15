using System;

namespace MadsMikkel.Schedulator.Core
{
	public struct SectionInfo
	{
		decimal startMarker;
		decimal endMarker;
		decimal length;
		Inclination maxIncline;
		Declination maxDecline;

		public decimal Length
		{
			get
			{
				return length;
			}

			set
			{
				length = value;
			}
		}

		public SectionInfo(decimal startMarker, decimal endMarker, decimal length,
			Inclination maxIncline, Declination maxDecline)
		{
			if(startMarker < 0 || endMarker < 0 || startMarker == endMarker)
				throw new ArgumentOutOfRangeException();
			this.startMarker = startMarker;
			this.endMarker = endMarker;
			this.length = Math.Abs(startMarker - endMarker);
			this.maxIncline= maxIncline;
			this.maxDecline = maxDecline;
		}
	}
}