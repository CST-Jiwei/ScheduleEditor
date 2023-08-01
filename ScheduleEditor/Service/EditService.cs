using TimetableConverter;
using TimetableConverter.Models;

namespace ScheduleEditor.Service
{
	internal class EditService
	{
		private EditService()
		{

		}

		public static EditService CreateService()
		{

			return new EditService();
		}

		private Schedule? schedule;

		public void LoadSchedule(string path)
		{

		}

		public void SaveSchedule(string path)
		{

		}

		public void NewSchedule()
		{
			schedule = Converter.CreateEmptySchedule();
		}

		public void ExportSchedule()
		{

		}

	}
}
