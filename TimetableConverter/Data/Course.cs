using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableConverter.Data
{
	[Serializable]
	internal class Course
	{
		public string? name { get; set; }
		public int dayOfWeek { get; set; } // 1-7
		public int startTime { get; set; }
		public int endTime { get; set; }
		public bool isGap { get; set; }
		//no gap
		public int startWeek { get; set; }
		public int endWeek { get; set; }
		//has gap week
		public List<int> weeks { get; set; }

		/// <summary>
		/// -1为不分单双周，0表示单周，1表示双周
		/// </summary>
		public int isSingleWeek { get; set; }

		public override string ToString()
		{
			if (isGap)
			{
				StringBuilder w = new StringBuilder();
				weeks.ForEach(x => w.Append(x.ToString()).Append(","));
				return $"{name} 周{dayOfWeek} 第{startTime}-{endTime}节 {w}";
			}
			else
			{
				return $"{name} 周{dayOfWeek} 第{startTime}-{endTime}节 第{startWeek}-{endWeek}周 单双周:{isSingleWeek}";
			}
		}
	}
}
