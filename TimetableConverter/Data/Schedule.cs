using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TimetableConverter.Data
{
	internal class Schedule
	{
		public string timestamp { get; set; }

		private List<Timetable> memberTimetables;

		private List<ScheduleInfo> arrangement;

		public Schedule()
		{
			//timestamp = 
			memberTimetables = new List<Timetable>();
			arrangement = new List<ScheduleInfo>();
		}


		public string ToJson()
		{
			return "{}";
		}

		public void FromJson(string json)
		{

		}

		internal struct ScheduleInfo
		{
			public int week { get; set; }
			public int day { get; set; }
			public int section { get; set; }
			public List<string> members { get; set; }
		}
	}
}
