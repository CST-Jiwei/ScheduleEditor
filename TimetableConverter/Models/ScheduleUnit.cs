using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimetableConverter.Models
{
	public class ScheduleUnit
	{
		public int week { get; set; }
		public int day { get; set; }

		[JsonInclude]
		private List<string> Section1Members;
		[JsonInclude]
		private List<string> Section2Members;
		[JsonInclude]
		private List<string> Section3Members;
		[JsonInclude]
		private List<string> Section4Members;

		public List<string> GetSectionMembers(int section)
		{
			return section switch
			{
				1 => Section1Members,
				2 => Section2Members,
				3 => Section3Members,
				4 => Section4Members,
				_ => throw new ArgumentOutOfRangeException(),
			};
		}

		internal ScheduleUnit() 
		{
			Section1Members = new();
			Section2Members = new();
			Section3Members = new();
			Section4Members = new();
		}
		internal void Reset()
		{
			Section1Members.Clear();
			Section2Members.Clear();
			Section3Members.Clear();
			Section4Members.Clear();
		}
	}
}
