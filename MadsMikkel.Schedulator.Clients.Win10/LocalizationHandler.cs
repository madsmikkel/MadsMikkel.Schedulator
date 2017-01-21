using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadsMikkel.Schedulator.Clients.Win10
{
    public class LocalizationHandler
    {
		/// <summary>
		/// Gets the localization translation table from the server.
		/// </summary>
		/// <param name="language">The language to present in a GUI.</param>
		/// <returns>A table with the specified translations for each GUI textual item.</returns>
		public DataTable GetLocalizationFor(CultureInfo culture)
		{
			DataTable translations;
			translations=new DataTable(tableName: $"{culture.Name}")
			return translations;
		}
    }
}
