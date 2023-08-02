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
			InitializeForm();
			InitializeTable();
			Initialize();
		}

		private Dictionary<int, TableLayoutPanel> tableList;
		private int currentWeek = 1;

		private void InitializeForm()
		{
			this.Text = General.Title;
			//
		}

		private void InitializeTable()
		{
			tableList = new(20);
			//��ʼ��ֵ�������
			for (int w = 1; w <= General.WEEK_LIMIT; w++)
			{
				var table = new ScheduleTablePanel();
				table.Initialize(containPanel.Size);
				for (int d = 1; d <= 5; d++)
				{
					for (int s = 1; s <= 4; s++)
					{
						var tag = new MemberTagControl();
						tag.WeekDaySection = (w, d, s);
						tag.SetService(edit);
						table.Controls.Add(tag, d - 1, s - 2);
					}
				}
				tableList.Add(w, table);
			}
			ChangeTable(1);
		}


		#region �¼�

		private void CreateNewSchedule(object sender, EventArgs e)
		{
			edit.NewEmptySchedule();
			InitializeTable();
		}

		private void LoadScheduleJson(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Json�ļ�|*.json";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var msg = MessageBox.Show(
					$"�Ƿ���json�����ļ�?\n(ע�⣺���뽫�Ḳ��ԭ������)",
					"�Ƿ���",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);
				if (msg == DialogResult.Yes)
				{
					var json = File.ReadAllText(file);
					edit.LoadScheduleJson(json);
				}
			}
		}

		private void SaveScheduleJson(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json�ļ�|*.json";
			dlg.FileName = $"schedule-{General.GetTimestampS()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = edit.GetScheduleJson();
				File.WriteAllText(file, json);
			}
		}

		private void ExportWebJson(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json�ļ�|*.json";
			dlg.FileName = $"ScheduleWebJson-{General.GetTimestampS()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = edit.GetScheduleWebJson();
				File.WriteAllText(file, json);
			}
		}

		private void LoadMemberXlsx(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Excel�ļ�|*.xls;*.xlsx;*.csv";
			dlg.Multiselect = true;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var files = dlg.FileNames;
				var msg = MessageBox.Show(
					$"��{files.Length}���ļ�, �Ƿ����?\n(��Ӳ��Ḳ��ԭ������)",
					"�Ƿ����",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);
				if (msg == DialogResult.Yes)
				{
					edit.AddMemberXlsxFile(files);
				}
			}
		}

		private void LoadMemberListJson(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Json�ļ�|*.json";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var msg = MessageBox.Show(
					$"�Ƿ����?\n(��Ӳ��Ḳ��ԭ������)",
					"�Ƿ����",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				);
				if (msg == DialogResult.Yes)
				{
					edit.AddMemberJson(File.ReadAllText(file));
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
			dlg.Filter = "Json�ļ�|*.json";
			dlg.FileName = $"members-{General.GetTimestampS()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = edit.GetMembersJson();
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
				MessageBox.Show("�Ѿ��ǵ�һ����");
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
				MessageBox.Show("�Ѿ������һ����");
			}
		}

		#endregion

		#region ��������

		private void ChangeTable(int week)
		{
			if (tableList.ContainsKey(week))
			{
				containPanel.Controls.Clear();
				containPanel.Controls.Add(tableList[week]);

				weekCount.Text = $"��{week}��";
			}
		}

		#endregion

		private void Form1_Load(object sender, EventArgs e)
		{

		}


	}
}