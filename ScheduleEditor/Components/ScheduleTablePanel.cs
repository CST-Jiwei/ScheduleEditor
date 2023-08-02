using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleEditor.Components
{
	public partial class ScheduleTablePanel : TableLayoutPanel
	{
		public void Initialize(Size size)
		{
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
	}
}
