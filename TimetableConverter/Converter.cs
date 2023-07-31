using ExcelDataReader;
using TimetableConverter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableConverter
{
    public static class Converter
    {
        private static string[] baseSplits = { "/", "-------------" };
        private static string[] courseWeekSplits = { "(", ")", "-", "周", "," };

        private static int courseName = 0;
        private static int courseWeekAndTime = 3;
        private static int courseSingleWeek = 4; //if exist


        private static Course? ToCourse(string c)
        {
            Course? course = new Course();
            var strs = c?.Split(baseSplits, StringSplitOptions.RemoveEmptyEntries);
            if (strs == null || strs.Length < 5) return null;

            course.name = strs[courseName];

            var s = strs[courseWeekAndTime].Split("(");
            if (s.Length < 2) return null;
            var time = s[0];
            var week = s[1];

            course.dayOfWeek = int.Parse(time.Substring(0, 1));
            course.startTime = int.Parse(time.Substring(1, 2));
            course.endTime = int.Parse(time.Substring(time.Length - 2, 2));


            if (strs[courseWeekAndTime].Contains(",")) //跳周课
            {
                course.isGap = true;
                week = week.Replace("周", "").Replace(")", "");
                var weeks = week.Split(",");
                course.weeks = new(weeks.Length);
                for (int i = 0; i < weeks.Length; i++)
                {
                    course.weeks[i] = int.Parse(weeks[i]);
                }
            }
            else
            {
                course.isGap = false;
                week = week.Replace("周", string.Empty).Replace(")", string.Empty);
                var weeks = week.Split("-");
                if (weeks.Length == 1)
                {
                    course.startWeek = int.Parse(weeks[0]);
                    course.endWeek = int.Parse(weeks[0]);
                }
                else
                {
                    course.startWeek = int.Parse(weeks[0]);
                    course.endWeek = int.Parse(weeks[1]);
                }
            }
            if (strs[courseSingleWeek] == "单周")
            {
                course.isSingleWeek = 1;
            }
            else if (strs[courseSingleWeek] == "双周")
            {
                course.isSingleWeek = 0;
            }
            else
            {
                course.isSingleWeek = -1;
            }

            return course;
        }

        public static Timetable? ToTimetable(string file)
        {
            Timetable? timetable = null;
            if (File.Exists(file))
            {
                using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
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
                                    var c = ToCourse(reader.GetString(i));
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
                            timetable.stuName = stu;
                            timetable.stuCourses = courses;
                        }
                    }
                }
            }
            return timetable;
        }

    }
}
