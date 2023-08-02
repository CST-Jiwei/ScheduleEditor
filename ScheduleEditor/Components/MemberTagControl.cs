using ScheduleEditor.Service;
using ScheduleEditor.Utils;
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
		public MemberTagControl(int week, int day, int section)
		{
			InitializeComponent();
			//
			WeekDaySection = (week, day, section);
			//初始化下拉选择框
			availableMembersSourse = new() { DataSource = AvailableMembers };
			cmbx_member.DataSource = availableMembersSourse;
			cmbx_member.SelectedIndex = -1;
			cmbx_member.SelectedIndexChanged += cmbx_member_SelectedValueChanged;
		}

		public (int week, int day, int section) WeekDaySection { get; set; }

		private BindingSource? availableMembersSourse;

		public List<string> AvailableMembers { get; set; } = new();
		public List<string> CurrentMembers { get; set; } = new();
		public void UpdateAvailableMembersList(object sender, EventArgs e)
		{
			AvailableMembers.Clear();
			AvailableMembers.AddRange(EditService.Instance.GetAvailableMembersList(WeekDaySection) ?? new() { "无可用队员" });
			availableMembersSourse?.ResetBindings(false);
		}

		private void AddMember(string name)
		{
			TagControl tag = new() { NameText = name };
			tag.CloseEvent += RemoveMemberTagEvent;
			CurrentMembers.Add(name);
			flowPane.Controls.Add(tag);
			EditService.Instance.AddMemeberArrangement(WeekDaySection, name);
		}

		private void RemoveMemberTagEvent(object sender, EventArgs e)
		{
			TagControl tag = (TagControl)sender;
			CurrentMembers.Remove(tag.NameText);
			flowPane.Controls.Remove(tag);
			EditService.Instance.RemoveMemeberArrangement(WeekDaySection, tag.NameText);
		}

		private void cmbx_member_TextUpdate(object sender, EventArgs e)
		{
			var cmbx = (ComboBox)sender;
			cmbx_member.DroppedDown = true;
			cmbx.SelectedIndex = cmbx.FindString(cmbx.Text);
		}

		private void cmbx_member_SelectedValueChanged(object sender, EventArgs e)
		{
			var cmbx = (ComboBox)sender;
			if (cmbx.SelectedIndex != -1)
			{
				AddMember(cmbx.Text);
			}
		}
	}
}
