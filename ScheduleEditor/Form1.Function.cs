using ScheduleEditor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEditor
{
	public partial class Form1 : Form
	{
		private static string statusText_Empty = "暂无数据，请先导入值班表数据或新建值班表";
		private static string statusText_OK = "请及时保存数据";
		private static string statusText_NoMember = "未导入队员数据，请先导入队员数据";

		private EditService edit;

		private void Initialize()
		{
			edit = EditService.CreateService();

		}
	}
}
