using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace TimetableConverter.Models
{
	[Serializable]
	public class Schedule
	{
		public string? timestamp { get; private set; }

		private bool needUpdate = true;

		public ReadOnlyCollection<Timetable> MemberTimetables
		{
			get
			{
				return _memberTimetables.AsReadOnly();
			}
		}
		private List<Timetable> _memberTimetables;
		public void SetMemberTimetables(List<Timetable> timetables)
		{
			updateTimestamp();
			_memberTimetables.Clear();
			_memberTimetables.AddRange(timetables);
		}
		public void AddMemberTimetable(Timetable timetable)
		{
			updateTimestamp();
			_memberTimetables.Add(timetable);
		}
		public bool RemoveMemberTimetable(Timetable timetable)
		{
			updateTimestamp();
			return _memberTimetables.Remove(timetable);
		}

		public ReadOnlyCollection<ScheduleInfo> Arrangement
		{
			get
			{
				return _arrangement.AsReadOnly();
			}
		}
		private List<ScheduleInfo> _arrangement;



		internal Schedule()
		{
			updateTimestamp();
			_memberTimetables = new List<Timetable>();
			_arrangement = new List<ScheduleInfo>();
		}

		private void updateTimestamp()
		{
			timestamp = DateTime.Now.ToString("G");
		}

		public struct ScheduleInfo
		{
			public int week { get; set; }
			public int day { get; set; }
			public int section { get; set; }
			public List<string> members { get; set; }
		}
	}
}
