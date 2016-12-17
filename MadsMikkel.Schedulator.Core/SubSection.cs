using System;

namespace MadsMikkel.Schedulator.Core
{
	public class SubSection
	{
		decimal startMarker;
		decimal endMarker;
		decimal length;
		float maxIncline;
		float maxDecline;

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

		public SubSection(decimal startMarker, decimal endMarker,
			float maxIncline, float maxDecline)
		{
			if(startMarker < 0 || endMarker < 0 || startMarker == endMarker)
				throw new ArgumentOutOfRangeException();
			this.startMarker = startMarker;
			this.endMarker = endMarker;
			this.Length = Math.Abs(startMarker - endMarker);
			this.maxIncline = maxIncline;
			this.maxDecline = maxDecline;
		}

		public override string ToString()
		{
			return $"Subsection from {startMarker} to {endMarker} is {Length} long with max incline at {maxIncline} degrees, and max decline at {maxDecline} degrees";
		}
	}
}