using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAUConverter
{
	internal static class Config
	{
		//
		public static readonly string[] baseSplits = { "/", "-------------" };
		public static readonly string[] courseWeekSplits = { "(", ")", "-", "周", "," };

		//课程字符串中的索引
		public readonly static int courseName = 0;
		public static readonly int courseTeacher = 1;
		public readonly static int courseTypeAndHours = 2;
		public static readonly int courseWeekAndTime = 3;
		public readonly static int courseSingleWeek = 4; //单双周
		public static readonly int courseAddress = 4;
		public readonly static int courseAddress_sw = 5; //如果没有单双周则为4，否则为5

		//
		public readonly static int WEEK_LIMIT = 20;
		public static readonly int DAY_LIMIT = 7;
	}
}
