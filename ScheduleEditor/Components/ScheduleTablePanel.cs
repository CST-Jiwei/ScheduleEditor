using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEditor.Components
{
	public partial class ScheduleTablePanel : TableLayoutPanel
	{
		public int Week;
		public void Initialize(Size size, int week)
		{
			Week = week;
			ColumnCount = 5;
			RowCount = 4;
			BackColor = SystemColors.Control;
			AutoSize = false;
			CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			for(int i = 0; i < ColumnCount; i++)
			{
				ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
			}
			for(int i = 0; i < RowCount; i++)
			{
				RowStyles.Add(new RowStyle(SizeType.Percent, 25));
			}
			Size = size;
		}

		public void ClearAllUnit()
		{
			//TODO
			foreach (MemberTagControl tag in Controls)
			{
				tag.ClearArrangement();
			}

		}

		public void CopyFrom(ScheduleTablePanel table)
		{
			//TODO
			for (int d = 1; d <= 5; d++)
			{
				for (int s = 1; s <= 4; s++)
				{
					var origin = table.GetControlFromPosition(d - 1, s - 1) as MemberTagControl;
					var receiver = this.GetControlFromPosition(d - 1, s - 1) as MemberTagControl;
					receiver?.Copy(origin);
				}
			}
		}

		public void UpdateAllUnit()
		{
			foreach(MemberTagControl tag in Controls)
			{
				tag.Update(this, EventArgs.Empty);
			}
		}
	}
}
