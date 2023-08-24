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
		public List<string> ArrangedMembers { get; set; } = new();
		public void Update(object sender, EventArgs e)
		{
			AvailableMembers.Clear();
			AvailableMembers.AddRange(EditService.Instance.GetAvailableMembersList(WeekDaySection) ?? new() { "无可用队员" });

			ArrangedMembers.Clear();
			ArrangedMembers.AddRange(EditService.Instance.GetArrangedMemberList(WeekDaySection) ?? new());
			flowPane.Controls.Clear();
			foreach(var member in ArrangedMembers) 
			{
				AddMemberTag(member);	
			}
			//再将已安排的队员从待定中去掉
			AvailableMembers.RemoveAll(x => ArrangedMembers.Contains(x));
			availableMembersSourse?.ResetBindings(false);
		}

		public void ClearArrangement()
		{
			AvailableMembers.AddRange(ArrangedMembers);
			foreach (var member in ArrangedMembers) 
			{
				EditService.Instance.RemoveMemeberArrangement(WeekDaySection, member);
			}
			flowPane.Controls.Clear();
			ArrangedMembers.Clear();
			availableMembersSourse?.ResetBindings(false);
		}

		public void Copy(MemberTagControl? other)
		{
			if(other is not null)
			{
				//TODO
			}
		}
		
		/// <summary>
		/// 仅添加Tag
		/// </summary>
		/// <param name="name"></param>
		private void AddMemberTag(string name)
		{
			TagControl tag = new() { NameText = name };
			tag.CloseEvent += RemoveMemberTagEvent;
			flowPane.Controls.Add(tag);
		}
		
		/// <summary>
		/// 添加队员安排
		/// </summary>
		/// <param name="name"></param>
		private void AddMember(string name)
		{
			AddMemberTag(name);
			ArrangedMembers.Add(name);
			AvailableMembers.Remove(name);
			availableMembersSourse?.ResetBindings(false);
			EditService.Instance.AddMemeberArrangement(WeekDaySection, name);
		}

		private void RemoveMemberTagEvent(object sender, EventArgs e)
		{
			TagControl tag = (TagControl)sender;
			ArrangedMembers.Remove(tag.NameText);
			AvailableMembers.Add(tag.NameText);
			availableMembersSourse?.ResetBindings(false);
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
			if (cmbx.SelectedIndex != -1 && cmbx.Text != "无可用队员")
			{
				AddMember(cmbx.Text);
			}
		}
	}
}
