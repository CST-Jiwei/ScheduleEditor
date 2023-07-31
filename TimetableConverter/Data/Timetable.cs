using System.Text;

namespace TimetableConverter.Data
{
	[Serializable]
	internal class Timetable
	{
		public string? stuName { get; set; }
		public string? stuID { get; set; }
		public List<Course>? stuCourses { get; set; }

		public List<FreeTime> genfreeTime()
		{
			var freeTime = new List<FreeTime>(18);
			for (int w = 1; w <= 18; w++)
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
			foreach (var c in stuCourses)
			{
				var sec = checkTime(c.startTime, c.endTime);

				if (sec.Item1 == -1 || sec.Item2 == -1 || sec.Item1 == 5 || sec.Item2 == 5) continue;

				if (c.isGap)
				{
					foreach (var w in c.weeks)
					{
						for (int i = sec.Item1; i <= sec.Item2; i++)
						{
							freeTime.Find(x => x.week == w).available[i - 1, c.dayOfWeek - 1] = false;
						}
					}
				}
				else
				{
					for (int w = c.startWeek; w <= c.endWeek; w++)
					{
						if (c.isSingleWeek == -1 || (c.isSingleWeek == 1 && w % 2 == 1) || (c.isSingleWeek == 0 && w % 2 == 0))
						{
							for (int i = sec.Item1; i <= sec.Item2; i++)
							{
								freeTime.Find(x => x.week == w).available[i - 1, c.dayOfWeek - 1] = false;
							}
						}
					}
				}
			}
			return freeTime;
		}

		private (int, int) checkTime(int s, int e) //第一班1-2，第二班3-4，第三班8-9，第四班10-11
		{
			var _check = (int s) => {
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
			sb.Append($"姓名:{stuName} 学号:{stuID}\n");
			foreach (var c in stuCourses)
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

		internal struct FreeTime
		{
			public int week;
			public bool[,] available;
		}
	}

}
