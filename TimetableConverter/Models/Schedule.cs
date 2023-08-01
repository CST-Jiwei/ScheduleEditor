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

		private List<Timetable> _memberTimetables;
		public ReadOnlyCollection<Timetable> MemberTimetables
		{
			get
			{
				return _memberTimetables.AsReadOnly();
			}
		}
		/// <summary>
		/// 设置队员列表（将会重置排班表，若未保存将会丢失）
		/// </summary>
		public void SetMemberTimetables(List<Timetable> timetables)
		{
			Reset();
			_memberTimetables.Clear();
			_memberTimetables.AddRange(timetables);
		}
		public void AddMemberTimetable(Timetable timetable)
		{
			Update();
			_memberTimetables.Add(timetable);
		}
		public bool RemoveMemberTimetable(string member)
		{
			if(IsMemberScheduled(member))
			{
				var loc = _scheduledMembers[member];
				_arrangements.Remove((loc.week, loc.day));
				_scheduledMembers.Remove(member);
				_memberTimetables.Remove(_memberTimetables.Find(t => t.StuName == member));
				Update();
				return true;
			}
			return false;
		}

		private Dictionary<string, (int week, int day)> _scheduledMembers;
		public (int week, int day) GetMember(string member)
		{
			var tryR = _scheduledMembers.TryGetValue(member, out (int week, int day) memberSchedule);
			if (tryR)
			{
				return memberSchedule;
			}
			return (-1, -1);
		}
		public bool IsMemberScheduled(string member)
		{
			return _scheduledMembers.ContainsKey(member);
		}

		private Dictionary<(int week, int day), ScheduleUnit> _arrangements;
		public ScheduleUnit? GetUnit(int week, int day)
		{
			var tryR = _arrangements.TryGetValue((week, day), out ScheduleUnit? unit);
			if (tryR)
			{
				return unit;
			}
			return null;
		}
		public ReadOnlyCollection<ScheduleUnit> Arrangements
		{
			get
			{
				return _arrangements.Values.ToList().AsReadOnly();
			}
		}
		public void AddArrangement(int week, int day, int section, string member)
		{
			Update();
			if (_arrangements.ContainsKey((week, day)))
			{
				_arrangements[(week, day)].GetSectionMembers(section).Add(member);
			}
		}
		public void RemoveArrangement(int week, int day, int section, string member)
		{
			Update();
			if(_arrangements.ContainsKey((week, day)))
			{
				_arrangements[(week, day)].GetSectionMembers(section).Remove(member);
			}
		}

		internal Schedule()
		{
			_memberTimetables = new();
			_arrangements = new();
			_scheduledMembers = new();
			initialize();
		}

		private void initialize()
		{
			Update();
			for(int w = 1; w <= Config.WEEK_LIMIT; w++)
			{
				for(int d = 1; d <= Config.DAY_LIMIT; d++)
				{
					_arrangements.Add((w, d), new());
				}
			}
		}

		public void Reset()
		{
			timestamp = DateTime.Now.ToString("G");
			for (int w = 1; w <= Config.WEEK_LIMIT; w++)
			{
				for (int d = 1; d <= Config.DAY_LIMIT; d++)
				{
					_arrangements[(w, d)].Reset();
				}
			}
			_scheduledMembers.Clear();
			_memberTimetables.Clear();
		}


		public void Update()
		{
			timestamp = DateTime.Now.ToString("G");
			
		}

	}
}
