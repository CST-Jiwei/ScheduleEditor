using ScheduleEditor.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleEditor.Components
{
	public partial class MemberTagControl : UserControl
	{
		public MemberTagControl()
		{
			InitializeComponent();
			_currentMembers = new();

			//初始化下拉选择框
			cmbx_member.DataSource = AvailableMembers;
		}

		private EditService? editService;
		public void SetService(EditService s)
		{
			editService = s;
		}

		public List<string?>? AvailableMembers { get; set; }

		public ReadOnlyCollection<string> CurrentMembers => _currentMembers.AsReadOnly();
		private List<string> _currentMembers;

		public (int week, int day, int section) WeekDaySection { get; set; }

		private void AddMember(string name)
		{
			TagControl tag = new() { NameText = name };
			tag.CloseEvent += RemoveMemberTag_CloseClick;
			_currentMembers.Add(name);
			flowPane.Controls.Add(tag);
		}

		private void RemoveMemberTag_CloseClick(object sender, EventArgs e)
		{
			TagControl tag = (TagControl)sender;
			_currentMembers.Remove(tag.NameText);
			flowPane.Controls.Remove(tag);
		}

	}
}
