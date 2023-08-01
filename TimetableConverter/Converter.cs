using ExcelDataReader;
using TimetableConverter.Models;

namespace TimetableConverter
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


            if (strs[Config.courseWeekAndTime].Contains(",")) //跳周课
            {
                course.IsGap = true;
                week = week.Replace("周", "").Replace(")", "");
                var weeks = week.Split(",");
                course.Weeks = new(weeks.Length);
                for (int i = 0; i < weeks.Length; i++)
                {
                    course.Weeks[i] = int.Parse(weeks[i]);
                }
            }
            else
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

        public static Schedule CreateEmptySchedule()
        {
			return new Schedule();
        }

        public static Schedule? CreateScheduleFromFile(string path)
        {

        }

    }
}
