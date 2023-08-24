using ExcelDataReader;
using SCAUConverter.Models;
using System.Text.Json;

namespace SCAUConverter
{
	public static class Converter
	{

		/// <summary>
		/// 创建单个课程对象
		/// 课程字符串错误将返回null
		/// </summary>
		internal static Course? CreateCourse(string c)
		{
			Course? course = new Course();
			var strs = c?.Split(Config.baseSplits, StringSplitOptions.RemoveEmptyEntries);
			if (strs == null || strs.Length < 5) return null;

			course.Name = strs[Config.courseName];

			course.Teacher = strs[Config.courseTeacher];

			var th = strs[Config.courseTypeAndHours].Split(":");
			course.Type = th[0];
			course.Hours = int.Parse(th[1]);

			var s = strs[Config.courseWeekAndTime].Split("(");
			if (s.Length < 2) return null;
			var time = s[0];
			var week = s[1];

			course.DayOfWeek = int.Parse(time.Substring(0, 1));
			course.StartTime = int.Parse(time.Substring(1, 2));
			course.EndTime = int.Parse(time.Substring(time.Length - 2, 2));


			if (strs[Config.courseWeekAndTime].Contains(",")) //间隔周
			{
				course.IsGap = true;
				course.Weeks = new();
				if (strs[Config.courseWeekAndTime].Contains("-")) //既间隔周，又连续周
				{
					week = week.Replace("周", "").Replace(")", "");
					var weekGroups = week.Split(',');
					foreach(var group in weekGroups)
					{
						if(group.Contains("-"))
						{
							var g = group.Split("-");
							if (g.Length == 2)
							{
								var start = int.Parse(g[0]);
								var end = int.Parse(g[1]);
								for (int i = start; i <= end; i++)
								{
									course.Weeks.Add(i);
								}
							}
						}
						else
						{
							var tryR = int.TryParse(group, out var wk);
							if(tryR)
							{
								course.Weeks.Add(wk);
							}
						}
                    }
				}
				else
				{
					week = week.Replace("周", "").Replace(")", "");
					var weeks = week.Split(",");
					for (int i = 0; i < weeks.Length; i++)
					{
						course.Weeks.Add(int.Parse(weeks[i]));//?
					}
				}
			}
			else //连续周
			{
				course.IsGap = false;
				week = week.Replace("周", string.Empty).Replace(")", string.Empty);
				var weeks = week.Split("-");
				if (weeks.Length == 1)
				{
					course.StartWeek = int.Parse(weeks[0]);
					course.EndWeek = int.Parse(weeks[0]);
				}
				else
				{
					course.StartWeek = int.Parse(weeks[0]);
					course.EndWeek = int.Parse(weeks[1]);
				}
			}
			if (strs[Config.courseSingleWeek] == "单周")
			{
				course.IsSingleWeek = 1;
				course.Address = strs[Config.courseAddress_sw];
			}
			else if (strs[Config.courseSingleWeek] == "双周")
			{
				course.IsSingleWeek = 0;
				course.Address = strs[Config.courseAddress_sw];
			}
			else
			{
				course.IsSingleWeek = -1;
				course.Address = strs[Config.courseAddress];
			}

			return course;
		}

		/// <summary>
		/// 创建学生课程表对象
		/// 文件路径错误将返回null
		/// </summary>
		public static Timetable? CreateTimetable(string filePath)
		{
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			Timetable? timetable = null;
			if (File.Exists(filePath))
			{
				using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						string stu = "";
						List<Course> courses = new();
						reader.Read();
						var header = reader.GetString(0);
						if (header != null)
						{
							stu = header.Split(' ')[1];
						}
						do
						{
							while (reader.Read())
							{
								for (var i = 0; i < reader.FieldCount; i++)
								{
									var c = CreateCourse(reader.GetString(i));
									if (c != null)
									{
										courses.Add(c);
									}
								}
							}
						} while (reader.NextResult());
						if (courses.Count > 0)
						{
							timetable = new Timetable();
							timetable.StuName = stu;
							timetable.SetStuCourses(courses);
						}
					}
				}
			}
			return timetable;
		}

		/// <summary>
		/// 创建值班表对象
		/// 默认返回空课程表
		/// </summary>
		/// <param name="paths"></param>
		/// <returns></returns>
		public static Schedule CreateSchedule(string[]? paths = null)
		{
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			var sch = new Schedule();
			if (paths != null && paths.Length != 0)
			{
				foreach (var path in paths)
				{
					var timetable = CreateTimetable(path);
					if (timetable != null)
					{
						sch.AddMemberTimetable(timetable);
					}
				}
			}
			return sch;
		}

		public static Schedule? CreateSchedule(string json)
		{
			var sch = JsonSerializer.Deserialize<Schedule>(json);
			return sch;
		}

	}
}
