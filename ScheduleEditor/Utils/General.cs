using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEditor.Utils
{
	public static class General
	{
		//
		public static readonly string Name = "计维排班表编辑器";
		public static readonly string Version = "v0.1";
		public static string Title => $"{Name} {Version}";

		//
		public readonly static int WEEK_LIMIT = 20;
		public static readonly int DAY_LIMIT = 7;

		private readonly static CultureInfo zh_CN = new CultureInfo("zh-CN");

		public static string GetTimeStampForFileName()
		{
			return DateTime.Now.ToString("yyyyMMddHHmmssff");
		}

		public static string GetTimestampS()
		{
			return DateTime.Now.ToString("s", zh_CN);
		}
		public static DateTime FromTimestampS(string timestamp)
		{
			return DateTime.ParseExact(timestamp, "s", zh_CN);
		}


	}
}
