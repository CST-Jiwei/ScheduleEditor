using System.Collections.ObjectModel;
using System.Text.Json;
using TimetableConverter;
using TimetableConverter.Models;

namespace ScheduleEditor.Service
{
	public class EditService
	{
		private EditService()
		{

		}

		public static EditService CreateService()
		{

			return new EditService();
		}

		public bool IsDataLoaded => schedule != null;
		private Schedule? schedule;

		public void NewEmptySchedule()
		{
			schedule = Converter.CreateSchedule(null);
		}
		public void LoadScheduleJson(string json)
		{
			NewEmptySchedule();
			if(!string.IsNullOrEmpty(json))
			{

			}
		}
		public string GetScheduleJson()
		{
			return "json";
		}

		public string GetMembersJson()
		{
			var m = schedule?.MemberList.ToList();
			var json = JsonSerializer.Serialize(m);
			return json;
		}

		public void AddMemberXlsxFile(string[]? xlsxPath)
		{
			if(xlsxPath != null)
			{
				if(schedule == null)
				{
					schedule = Converter.CreateSchedule(xlsxPath);
				}
                else
                {
					foreach (var path in xlsxPath)
					{
						var t = Converter.CreateTimetable(path);
						if(t != null)
							schedule.AddMemberTimetable(t);
					}
				}
			}
		}

		/// <param name="jsons">一组储存队员数据的json，每一个都是一个不等长的List</param>
		public void AddMemberJson(string[]? jsons)
		{
			if(jsons != null)
			{

			}
		}

		public string GetScheduleWebJson()
		{
			return "json";
		}

		public ReadOnlyCollection<string?>? GetAvailableMemberList()
		{
			return schedule?.MemberList;
		}

	}
}
