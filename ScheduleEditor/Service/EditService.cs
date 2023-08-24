using SCAUConverter;
using SCAUConverter.Models;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
			schedule = Converter.CreateSchedule();
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}
		/// <summary>
		/// 从二进制文件还原
		/// </summary>
		/// <param name="json"></param>
		public void LoadScheduleBin(byte[] bin)
		{
			if(bin != null)
			{
				using (var stream = new MemoryStream(bin))
				{
					BinaryFormatter bf = new();
#pragma warning disable SYSLIB0011 // 类型或成员已过时
					schedule = (Schedule)bf.Deserialize(stream);
#pragma warning restore SYSLIB0011 // 类型或成员已过时
				}
			}
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}
		/// <summary>
		/// 生成二进制
		/// </summary>
		/// <returns></returns>
		public byte[] GetScheduleBin()
		{
			//TODO
			using (var stream = new MemoryStream())
			{
				BinaryFormatter bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // 类型或成员已过时
				bf.Serialize(stream, schedule);
#pragma warning restore SYSLIB0011 // 类型或成员已过时
				stream.Flush();
				var bin = stream.ToArray();
				return bin;
			}
		}
		/// <summary>
		/// 导出可阅读csv（程序无法接收）
		/// </summary>
		/// <returns></returns>
		internal string GetScheduleCsv()
		{
			return schedule?.GetCsv() ?? string.Empty;
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

		/// <summary>
		/// 导出web使用的json格式（本程序无法读取）
		/// </summary>
		/// <returns></returns>
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

		public List<string>? GetArrangedMemberList((int week, int day, int section) wds)
		{
			return schedule?.GetArrangedMemberList(wds.week, wds.day, wds.section);
		}

		public void ForceUpdate()
		{
			MemberChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
