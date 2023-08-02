using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SCAUConverter
{
	internal static class Exporting
	{
		public static JsonSerializerOptions Options = new JsonSerializerOptions()
		{
			WriteIndented = true,
			IncludeFields = false,
		};



	}
}
