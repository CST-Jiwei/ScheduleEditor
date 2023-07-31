using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableConverter.Models
{
	[Serializable]
	public class Course
	{
		public string? Name { get; set; }
		public int DayOfWeek { get; set; } // 1-7
		public int StartTime { get; set; }
		public int EndTime { get; set; }
		public bool IsGap { get; set; }
		//no gap
		public int StartWeek { get; set; }
		public int EndWeek { get; set; }
		//has gap week
		public List<int>? Weeks { get; set; }

		/// <summary>
		/// -1为不分单双周，0表示单周，1表示双周
		/// </summary>
		public int IsSingleWeek { get; set; }

		public string? Teacher { get; set; }
		public string? Address { get; set; }
		public string? Type { get; set; }
		public int Hours { get; set; }

		internal Course() { }

		public override string ToString()
		{
			if (IsGap)
			{
				StringBuilder w = new StringBuilder();
				Weeks?.ForEach(x => w.Append(x.ToString()).Append(","));
				return $"{Name} 周{DayOfWeek} 第{StartTime}-{EndTime}节 {w}";
			}
			else
			{
				return $"{Name} 周{DayOfWeek} 第{StartTime}-{EndTime}节 第{StartWeek}-{EndWeek}周 单双周:{IsSingleWeek}";
			}
		}
	}
}
