using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEditor.Utils
{
	public static class General
	{
		public static string GetTimestamp()
		{
			return DateTime.Now.ToString("yyyyMMddHHmmssff");
		}

		public static string GetDate()
		{
			return DateTime.Now.ToString("yyyyMMdd");
		}
	}
}
