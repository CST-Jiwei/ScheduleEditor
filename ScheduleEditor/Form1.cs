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
			Initialize();
			InitializeForm();
			InitializeTable();
		}

		private Dictionary<int, ScheduleTablePanel> tableList;
		private int currentWeek = 1;

		private void InitializeForm()
		{
			this.Text = General.Title;
			//
			UpdateStatusText(this, EventArgs.Empty);
		}

		private void InitializeTable()
		{
			tableList = new(20);
			//初始化值班表区域
			for (int w = 1; w <= General.WEEK_LIMIT; w++)
			{
				var table = new ScheduleTablePanel();
				table.Initialize(containPanel.Size);
				for (int d = 1; d <= 5; d++)
				{
					for (int s = 1; s <= 4; s++)
					{
						var tag = new MemberTagControl(w, d, s);
						table.Controls.Add(tag, d - 1, s - 2);
					}
				}
				tableList.Add(w, table);
			}
			ChangeTable(1);
		}


		#region 事件

		private void CreateNewSchedule(object sender, EventArgs e)
		{
			EditService.Instance.NewEmptySchedule();
			InitializeTable();
		}

		private void LoadScheduleJson(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var msg = MessageBox.Show(
					$"是否导入json数据文件?\n(注意：导入将会覆盖原有数据)",
					"是否导入",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);
				if (msg == DialogResult.Yes)
				{
					var json = File.ReadAllText(file);
					EditService.Instance.LoadScheduleJson(json);
				}
			}
		}

		private void SaveScheduleJson(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.FileName = $"schedule-{General.GetTimeStampForFileName()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = EditService.Instance.GetScheduleJson();
				File.WriteAllText(file, json);
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
			tableList[currentWeek].UpdateAllUnit();
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			tableList[currentWeek].UpdateAllUnit();
		}

		private void btn_copy_Click(object sender, EventArgs e)
		{

		}

		#endregion

		#region 辅助方法

		private void ChangeTable(int week)
		{
			if (tableList.ContainsKey(week))
			{
				containPanel.Controls.Clear();
				containPanel.Controls.Add(tableList[week]);
				tableList[week].UpdateAllUnit();
				weekCount.Text = $"第{week}周";
			}
		}

		#endregion
	}
}