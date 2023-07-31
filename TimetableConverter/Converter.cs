using ExcelDataReader;
using TimetableConverter.Models;

namespace TimetableConverter
{
    public static class Converter
    {
        private static string[] baseSplits = { "/", "-------------" };
        private static string[] courseWeekSplits = { "(", ")", "-", "周", "," };

        //课程字符串中的索引
        private static int courseName = 0;
        private static int courseTeacher = 1;
        private static int courseTypeAndHours = 2;
        private static int courseWeekAndTime = 3;
		private static int courseSingleWeek = 4; //单双周
		private static int courseAddress = 4; 
        private static int courseAddress_sw = 5; //如果没有单双周则为4，否则为5

		/// <summary>
		/// 创建单个课程对象
		/// 课程字符串错误将返回null
		/// </summary>
		internal static Course? CreateCourse(string c)
        {
            Course? course = new Course();
            var strs = c?.Split(baseSplits, StringSplitOptions.RemoveEmptyEntries);
            if (strs == null || strs.Length < 5) return null;

            course.Name = strs[courseName];

            course.Teacher = strs[courseTeacher];

            var th = strs[courseTypeAndHours].Split(":");
            course.Type = th[0];
            course.Hours = int.Parse(th[1]);

            var s = strs[courseWeekAndTime].Split("(");
            if (s.Length < 2) return null;
            var time = s[0];
            var week = s[1];

            course.DayOfWeek = int.Parse(time.Substring(0, 1));
            course.StartTime = int.Parse(time.Substring(1, 2));
            course.EndTime = int.Parse(time.Substring(time.Length - 2, 2));


            if (strs[courseWeekAndTime].Contains(",")) //跳周课
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
            if (strs[courseSingleWeek] == "单周")
            {
                course.IsSingleWeek = 1;
                course.Address = strs[courseAddress_sw];
            }
            else if (strs[courseSingleWeek] == "双周")
            {
                course.IsSingleWeek = 0;
				course.Address = strs[courseAddress_sw];
			}
            else
            {
                course.IsSingleWeek = -1;
				course.Address = strs[courseAddress];
			}

            return course;
        }

		/// <summary>
        /// 创建学生课程表对象
		/// 文件路径错误将返回null
		/// </summary>
		internal static Timetable? CreateTimetable(string filePath)
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

        public static Schedule CreateSchedule()
        {
            //TODO
			return new Schedule();
        }

    }
}
