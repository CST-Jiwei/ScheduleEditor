using ScheduleEditor.Service;
using ScheduleEditor.Utils;
using ScheduleEditor.Components;

namespace ScheduleEditor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//顺序不能变
			Initialize();
			InitializeTable();
		}

		private Dictionary<int, ScheduleTablePanel> tableDict;
		private int currentWeek = 1;

		private void InitializeTable()
		{
			tableDict = new(20);
			//初始化值班表区域
			for (int w = 1; w <= General.WEEK_LIMIT; w++)
			{
				var table = new ScheduleTablePanel();
				table.Initialize(containPanel.Size, w);
				for (int d = 1; d <= 5; d++)
				{
					for (int s = 1; s <= 4; s++)
					{
						var tag = new MemberTagControl(w, d, s);
						table.Controls.Add(tag, d - 1, s - 2);
					}
				}
				tableDict.Add(w, table);
			}
			ChangeTable(1);
		}


		#region 事件

		private void CreateNewSchedule(object sender, EventArgs e)
		{
			EditService.Instance.NewEmptySchedule();
			InitializeTable();
		}

		private void LoadScheduleBin(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Bin文件|*.bin";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var msg = MessageBox.Show(
					$"是否导入数据文件?\n(注意：导入将会覆盖原有数据)",
					"是否导入",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);
				if (msg == DialogResult.Yes)
				{
					var bin = File.ReadAllBytes(file);
					EditService.Instance.LoadScheduleBin(bin);
				}
			}
		}

		private void SaveScheduleBin(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = ".bin文件|*.bin";
			dlg.FileName = $"schedule-{General.GetTimeStampForFileName()}.bin";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var bin = EditService.Instance.GetScheduleBin();
				File.WriteAllBytes(file, bin);
			}
		}

		private void ExportWebJson(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.FileName = $"ScheduleWebJson-{General.GetTimeStampForFileName()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = EditService.Instance.GetScheduleWebJson();
				File.WriteAllText(file, json);
			}
		}

		private void ExportCsv(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Csv文件|*.csv";
			dlg.FileName = $"ScheduleCsv-{General.GetTimeStampForFileName()}.csv";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var csv = EditService.Instance.GetScheduleCsv();
				File.WriteAllText(file, csv);
			}
		}

		private void LoadMemberXlsx(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Excel文件|*.xls;*.xlsx;*.csv";
			dlg.Multiselect = true;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var files = dlg.FileNames;
				var msg = MessageBox.Show(
					$"共{files.Length}个文件, 是否添加?\n(添加不会覆盖原有数据)",
					"是否添加",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);
				if (msg == DialogResult.Yes)
				{
					EditService.Instance.AddMemberXlsxFile(files);
				}
			}
		}

		private void LoadMemberListJson(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var msg = MessageBox.Show(
					$"是否添加?\n(添加不会覆盖原有数据)",
					"是否添加",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);
				if (msg == DialogResult.Yes)
				{
					EditService.Instance.AddMemberJson(File.ReadAllText(file));
				}
			}
		}

		private void OpenMemberListForm(object sender, EventArgs e)
		{
			var form = new MemberListForm();
			form.ShowDialog();
		}

		private void saveMemberJson_Click(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.FileName = $"members-{General.GetTimeStampForFileName()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = EditService.Instance.GetMembersJson();
				File.WriteAllText(file, json);
			}
		}

		private void btnToPre_Click(object sender, EventArgs e)
		{
			if (currentWeek > 1)
			{
				currentWeek--;
				ChangeTable(currentWeek);
			}
			else
			{
				MessageBox.Show("已经是第一周了");
			}
		}

		private void btnToNext_Click(object sender, EventArgs e)
		{
			if (currentWeek < 20)
			{
				currentWeek++;
				ChangeTable(currentWeek);
			}
			else
			{
				MessageBox.Show("已经是最后一周了");
			}
		}

		private void btn_ForceUpdate_Click(object sender, EventArgs e)
		{
			tableDict[currentWeek].UpdateAllUnit();
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			//TODO
			tableDict[currentWeek].ClearAllUnit();
			tableDict[currentWeek].UpdateAllUnit();
		}

		private void btn_copy_Click(object sender, EventArgs e)
		{
			if (currentWeek != 1)
			{
				tableDict[currentWeek].CopyFrom(tableDict[currentWeek - 1]);
			}
		}

		#endregion

		#region 辅助方法

		private void ChangeTable(int week)
		{
			if (tableDict.ContainsKey(week))
			{
				containPanel.Controls.Clear();
				containPanel.Controls.Add(tableDict[week]);
				tableDict[week].UpdateAllUnit();
				weekCount.Text = $"第{week}周";
				if (week == 1)
				{
					btnToPre.Enabled = false;
					btn_copy.Enabled = false;
				}
				else
				{
					btnToPre.Enabled = true;
					btn_copy.Enabled = true;
					if (week == 20)
					{
						btnToNext.Enabled = false;
					}
					else
					{
						btnToNext.Enabled = true;
					}
				}
			}
		}

		#endregion
	}
}