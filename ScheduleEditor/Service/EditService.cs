using SCAUConverter;
using SCAUConverter.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

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
				//TODO
			}
		}
		public string GetScheduleJson()
		{
			//TODO
			return "json";
		}

		public string GetMembersJson()
		{
			var m = schedule?.MemberTimetables;
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

		public void AddMemberJson(string? json)
		{
			if(json != null)
			{
				var list = JsonSerializer.Deserialize<List<Timetable>>(json);
				if(list != null)
				{
					foreach(var t in list)
					{
						schedule?.AddMemberTimetable(t);
					}
				}
			}
		}

		public string GetScheduleWebJson()
		{
			//TODO
			return "json";
		}

		public ReadOnlyCollection<string?>? GetAvailableMemberList()
		{
			//TODO
			return schedule?.MemberList;
		}

	}
}
