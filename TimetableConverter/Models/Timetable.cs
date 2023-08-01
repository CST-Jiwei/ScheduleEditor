﻿using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace TimetableConverter.Models
{
	[Serializable]
	public class Timetable
	{
		public string? StuName { get; set; }
		public string? StuID { get; set; }

		public ReadOnlyCollection<Course> StuCourses
		{
			get
			{
				if (_stuCourses is null)
				{
					_stuCourses = new List<Course>();
				}
				return _stuCourses.AsReadOnly();
			}
		}
		private List<Course> _stuCourses;
		public void SetStuCourses(List<Course> lc)
		{
			_stuCourses.Clear();
			_stuCourses.AddRange(lc);
			needUpdate = true;
		}
		public void AddStuCourse(Course course)
		{
			_stuCourses.Add(course);
			needUpdate = true;
		}
		public bool RemoveStuCourse(Course course)
		{
			needUpdate = true;
			return _stuCourses.Remove(course);
		}

		[JsonIgnore]
		public ReadOnlyCollection<FreeTime> FreeTimes
		{
			get
			{
				if (needUpdate)
				{
					_freeTimes.Clear();
					_freeTimes.AddRange(genfreeTime());
					needUpdate = false;
				}
				return _freeTimes.AsReadOnly();
			}
		}
		private List<FreeTime> _freeTimes;
		private bool needUpdate = true; //是否需要更新FreeTimes
		private List<FreeTime> genfreeTime()
		{
			var freeTime = new List<FreeTime>(Config.WEEK_LIMIT);
			for (int w = 1; w <= Config.WEEK_LIMIT; w++)
			{
				bool[,] free = new bool[4, 7];
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 7; j++)
					{
						free[i, j] = true;
					}
				}
				freeTime.Add(new FreeTime
				{
					week = w,
					available = free
				});
			}
			foreach (var c in StuCourses)
			{
				var sec = checkTime(c.StartTime, c.EndTime);

				if (sec.Item1 == -1 || sec.Item2 == -1 || sec.Item1 == 5 || sec.Item2 == 5) continue;

				if (c.IsGap)
				{
					foreach (var w in c.Weeks)
					{
						for (int i = sec.Item1; i <= sec.Item2; i++)
						{
							freeTime.Find(x => x.week == w).available[i - 1, c.DayOfWeek - 1] = false;
						}
					}
				}
				else
				{
					for (int w = c.StartWeek; w <= c.EndWeek; w++)
					{
						if (c.IsSingleWeek == -1 || (c.IsSingleWeek == 1 && w % 2 == 1) || (c.IsSingleWeek == 0 && w % 2 == 0))
						{
							for (int i = sec.Item1; i <= sec.Item2; i++)
							{
								freeTime.Find(x => x.week == w).available[i - 1, c.DayOfWeek - 1] = false;
							}
						}
					}
				}
			}
			return freeTime;
		}

		internal Timetable()
		{
			_stuCourses = new List<Course>();
			_freeTimes = new List<FreeTime>();
		}

		private (int, int) checkTime(int s, int e)
		{
			//第一班1-2，第二班3-4，第三班8-9，第四班10-11
			var _check = (int s) =>
			{
				if (s >= 1 && s <= 2) return 1;
				if (s >= 3 && s <= 5) return 2;
				if (s >= 8 && s <= 9) return 3;
				if (s >= 10 && s <= 12) return 4;
				if (s >= 13 && s <= 15) return 5;
				return -1;
			};
			return (_check(s), _check(e));
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			var free = genfreeTime();
			sb.Append($"姓名:{StuName} 学号:{StuID}\n");
			foreach (var c in StuCourses)
			{
				sb.Append(c.ToString()).Append("\n");
			}
			for (int i = 0; i < 18; i++)
			{
				sb.Append($"第{free[i].week}周\n");
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < 7; k++)
					{
						sb.Append(free[i].available[j, k] ? " O " : " X ");
					}
					sb.Append("\n");
				}
			}
			return sb.ToString();
		}

		public struct FreeTime
		{
			public int week;
			public bool[,] available;
		}
	}

}
