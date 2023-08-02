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
			foreach(ColumnStyle col in RowStyles)
			{
				col.SizeType = SizeType.Percent;
				col.Width = 20;
			}
			foreach(RowStyle row in ColumnStyles)
			{
				row.SizeType = SizeType.Percent;
				row.Height = 25;
			}
			Size = size;

		}
	}
}
