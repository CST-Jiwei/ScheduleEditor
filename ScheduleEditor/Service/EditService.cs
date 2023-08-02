using SCAUConverter;
using SCAUConverter.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ScheduleEditor.Service
{
	public class EditService
	{
		private EditService() { }
		private static EditService? _instance;
		public static EditService Instance 
		{
			get
			{
				return _instance ??= new EditService();
			} 
		}

		public bool IsDataLoaded => schedule != null;
		private Schedule? schedule;
		public int MemberCount => schedule?.MemberCount ?? 0;
		public int ScheduledMemberCount => schedule?.ScheduledMemberCount ?? 0;
		public event EventHandler? MemberChanged;


		#region 值班表编辑
		public void NewEmptySchedule()
		{
			schedule = Converter.CreateSchedule(null);
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}
		public void LoadScheduleJson(string json)
		{
			NewEmptySchedule();
			if(!string.IsNullOrEmpty(json))
			{
				//TODO
				
			}
			MemberChanged?.Invoke(this, EventArgs.Empty);
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
			MemberChanged?.Invoke(this, EventArgs.Empty);
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
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}

		public string GetScheduleWebJson()
		{
			//TODO
			return "json";
		}

		public void AddMemeberArrangement((int week, int day, int section) wds, string name)
		{
			schedule?.AddArrangement(wds.week, wds.day, wds.section, name);
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}
		public void RemoveMemeberArrangement((int week, int day, int section) wds, string name)
		{
			schedule?.RemoveArrangement(wds.week, wds.day, wds.section, name);
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}
		#endregion

		public List<string>? GetAvailableMembersList((int week, int day, int section) wds)
		{
			return schedule?.GetAvailableMemberList(wds.week, wds.day, wds.section);
		}

	}
}
