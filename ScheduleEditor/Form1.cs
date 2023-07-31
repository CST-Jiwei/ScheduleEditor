
using ScheduleEditor.Service;
using ScheduleEditor.Utils;

namespace ScheduleEditor
{
	public partial class Form1 : Form
	{
		private EditService editService;

		private event EventHandler<EventArgs> OnScheduleChanged;
		

		private void Init()
		{
			schedule = new Schedule();
			editService = new EditService();
			
		}



		public Form1()
		{
			InitializeComponent();
			
			Init();
		}


		private void changeLabel(bool ok)
		{
			lblStatus.Visible = !ok;
		}

		private void btnLoad_Click(object sender, EventArgs e)
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
					foreach (var file in files)
					{
						//TODO
					}
					changeLabel(true);
				}
			}
		}

		private void btnLoadJson_Click(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.Multiselect = false;
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var files = dlg.FileNames;
				var msg = MessageBox.Show(
					$"是否导入json数据文件?\n(注意：导入将会覆盖原有数据)",
					"是否导入",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning
				);
				if (msg == DialogResult.Yes)
				{
					var json = File.ReadAllText(file);
					//TODO
					changeLabel(true);
				}
			}
		}

		private void btnSaveJson_Click(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.Filter = "Json文件|*.json";
			dlg.FileName = $"schedule-{General.GetDate()}.json";
			dlg.AddExtension = true;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var file = dlg.FileName;
				var json = "";
				//TODO
				File.WriteAllText(file, json);
			}
		}
	}
}