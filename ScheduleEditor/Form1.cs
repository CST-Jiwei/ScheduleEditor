using ScheduleEditor.Service;
using ScheduleEditor.Utils;


namespace ScheduleEditor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			InitializeForm();
			Initialize();
		}

		#region ���������ط��� 

		private void InitializeForm()
		{
			this.Text = General.Title;
		}

		private void changeLabel()
		{

		}


		#endregion

		#region �¼�

		private void CreateNewSchedule(object sender, EventArgs e)
		{

		}

		private void LoadJson(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Json�ļ�|*.json";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var files = dlg.FileNames;
				var msg = MessageBox.Show(
					$"�Ƿ���json�����ļ�?\n(ע�⣺���뽫�Ḳ��ԭ������)",
					"�Ƿ���",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);
				if (msg == DialogResult.Yes)
				{
					var json = File.ReadAllText(file);
					//TODO
				}
			}
		}

		private void SaveJson(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json�ļ�|*.json";
			dlg.FileName = $"schedule-{General.GetTimestampS()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = "";
				//TODO
				File.WriteAllText(file, json);
			}
		}

		private void ImportWebJson(object sender, EventArgs e)
		{

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
					foreach (var file in files)
					{
						//TODO
					}
				}
			}
		}

		private void LoadMemberJson(object sender, EventArgs e)
		{

		}

		private void OpenMemberList(object sender, EventArgs e)
		{
			var form = new MemberListForm();
			form.ShowDialog();
		}

		private void btnToPre_Click(object sender, EventArgs e)
		{

		}

		private void btnToNext_Click(object sender, EventArgs e)
		{

		}

		#endregion
	}
}