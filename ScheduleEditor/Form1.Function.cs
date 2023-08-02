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
		private int memberCount
		{
			get
			{
				return EditService.Instance?.MemberCount ?? -1;
			}
		}
		private int scheduledMemberCount
		{
			get
			{
				return EditService.Instance?.ScheduledMemberCount ?? -1;
			}
		}


		private void UpdateStatusText(object sender, EventArgs e)
		{
			lblStatus.Text = $"共{memberCount}名队员，已安排{scheduledMemberCount}人";
		}


		private void Initialize()
		{
			EditService.Instance.MemberChanged += UpdateStatusText;
		}
	}
}
