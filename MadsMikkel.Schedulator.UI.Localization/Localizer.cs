using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadsMikkel.Schedulator.UI.Localization
{
	/// <summary>
	/// Localizes the UI.
	/// </summary>
    public class Localizer
    {
		/// <summary>
		/// The current culture.
		/// </summary>
		private CultureInfo currentCulture;

		public Localizer()
		{
			
		}

		public void SetUICulture(string language)
		{
			if(String.IsNullOrWhiteSpace(language))
			{
				throw new ArgumentException(
					"The specified language must have a value", 
					$"{nameof(language)}"
					);
			}
		}

		protected CultureInfo CurrentCulture
		{
			get
			{
				return currentCulture;
			}

			set
			{
				currentCulture = value;
			}
		}
	}
}
