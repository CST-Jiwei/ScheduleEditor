namespace ScheduleEditor
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnToNext = new Button();
			btnToPre = new Button();
			lblStatus = new Label();
			weekCount = new Label();
			containPanel = new Panel();
			ScheduleData = new ToolStripMenuItem();
			m_NewSche = new ToolStripMenuItem();
			toolStripSeparator3 = new ToolStripSeparator();
			m_SaveJson = new ToolStripMenuItem();
			m_LoadJson = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			m_ExportWebJson = new ToolStripMenuItem();
			m_ExportCsv = new ToolStripMenuItem();
			Member = new ToolStripMenuItem();
			m_AddXlsx = new ToolStripMenuItem();
			m_AddJson = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			m_OpenMemberList = new ToolStripMenuItem();
			saveMemberJson = new ToolStripMenuItem();
			menuStrip2 = new MenuStrip();
			btn_copy = new Button();
			btn_Clear = new Button();
			btn_ForceUpdate = new Button();
			menuStrip2.SuspendLayout();
			SuspendLayout();
			// 
			// btnToNext
			// 
			btnToNext.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			btnToNext.Location = new Point(1414, 321);
			btnToNext.Name = "btnToNext";
			btnToNext.Size = new Size(56, 48);
			btnToNext.TabIndex = 7;
			btnToNext.Text = ">>";
			btnToNext.UseVisualStyleBackColor = true;
			btnToNext.Click += btnToNext_Click;
			// 
			// btnToPre
			// 
			btnToPre.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			btnToPre.Location = new Point(12, 321);
			btnToPre.Name = "btnToPre";
			btnToPre.Size = new Size(56, 48);
			btnToPre.TabIndex = 6;
			btnToPre.Text = "<<";
			btnToPre.UseVisualStyleBackColor = true;
			btnToPre.Click += btnToPre_Click;
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
			lblStatus.ForeColor = Color.Red;
			lblStatus.Location = new Point(12, 814);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(453, 30);
			lblStatus.TabIndex = 5;
			lblStatus.Text = "暂无数据，请先导入值班表数据或新建值班表";
			// 
			// weekCount
			// 
			weekCount.AutoSize = true;
			weekCount.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
			weekCount.Location = new Point(3, 44);
			weekCount.Name = "weekCount";
			weekCount.Size = new Size(72, 26);
			weekCount.TabIndex = 9;
			weekCount.Text = "第xx周";
			// 
			// containPanel
			// 
			containPanel.Location = new Point(74, 43);
			containPanel.Name = "containPanel";
			containPanel.Size = new Size(1334, 763);
			containPanel.TabIndex = 0;
			// 
			// ScheduleData
			// 
			ScheduleData.DropDownItems.AddRange(new ToolStripItem[] { m_NewSche, toolStripSeparator3, m_SaveJson, m_LoadJson, toolStripSeparator1, m_ExportWebJson, m_ExportCsv });
			ScheduleData.Name = "ScheduleData";
			ScheduleData.Size = new Size(53, 24);
			ScheduleData.Text = "数据";
			// 
			// m_NewSche
			// 
			m_NewSche.Name = "m_NewSche";
			m_NewSche.Size = new Size(229, 26);
			m_NewSche.Text = "新建空白值班表";
			m_NewSche.Click += CreateNewSchedule;
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new Size(226, 6);
			// 
			// m_SaveJson
			// 
			m_SaveJson.Name = "m_SaveJson";
			m_SaveJson.Size = new Size(229, 26);
			m_SaveJson.Text = "保存数据文件";
			m_SaveJson.Click += SaveScheduleBin;
			// 
			// m_LoadJson
			// 
			m_LoadJson.Name = "m_LoadJson";
			m_LoadJson.Size = new Size(229, 26);
			m_LoadJson.Text = "读取数据文件";
			m_LoadJson.Click += LoadScheduleBin;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(226, 6);
			// 
			// m_ExportWebJson
			// 
			m_ExportWebJson.Name = "m_ExportWebJson";
			m_ExportWebJson.Size = new Size(229, 26);
			m_ExportWebJson.Text = "导出网页端可读Json";
			m_ExportWebJson.Click += ExportWebJson;
			// 
			// m_ExportCsv
			// 
			m_ExportCsv.Name = "m_ExportCsv";
			m_ExportCsv.Size = new Size(229, 26);
			m_ExportCsv.Text = "导出csv文件";
			m_ExportCsv.Click += ExportCsv;
			// 
			// Member
			// 
			Member.DropDownItems.AddRange(new ToolStripItem[] { m_AddXlsx, m_AddJson, toolStripSeparator2, m_OpenMemberList, saveMemberJson });
			Member.Name = "Member";
			Member.Size = new Size(53, 24);
			Member.Text = "队员";
			// 
			// m_AddXlsx
			// 
			m_AddXlsx.Name = "m_AddXlsx";
			m_AddXlsx.Size = new Size(241, 26);
			m_AddXlsx.Text = "添加队员Xlsx课表文件";
			m_AddXlsx.Click += LoadMemberXlsx;
			// 
			// m_AddJson
			// 
			m_AddJson.Name = "m_AddJson";
			m_AddJson.Size = new Size(241, 26);
			m_AddJson.Text = "添加队员Json文件";
			m_AddJson.Click += LoadMemberListJson;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(238, 6);
			// 
			// m_OpenMemberList
			// 
			m_OpenMemberList.Name = "m_OpenMemberList";
			m_OpenMemberList.Size = new Size(241, 26);
			m_OpenMemberList.Text = "查看队员列表";
			m_OpenMemberList.Click += OpenMemberListForm;
			// 
			// saveMemberJson
			// 
			saveMemberJson.Name = "saveMemberJson";
			saveMemberJson.Size = new Size(241, 26);
			saveMemberJson.Text = "保存队员数据";
			saveMemberJson.Click += saveMemberJson_Click;
			// 
			// menuStrip2
			// 
			menuStrip2.ImageScalingSize = new Size(20, 20);
			menuStrip2.Items.AddRange(new ToolStripItem[] { ScheduleData, Member });
			menuStrip2.Location = new Point(0, 0);
			menuStrip2.Name = "menuStrip2";
			menuStrip2.Padding = new Padding(7, 2, 0, 2);
			menuStrip2.Size = new Size(1482, 28);
			menuStrip2.TabIndex = 1;
			menuStrip2.Text = "menuStrip2";
			// 
			// btn_copy
			// 
			btn_copy.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
			btn_copy.Location = new Point(1292, 812);
			btn_copy.Name = "btn_copy";
			btn_copy.Size = new Size(116, 32);
			btn_copy.TabIndex = 10;
			btn_copy.Text = "复制上一周";
			btn_copy.UseVisualStyleBackColor = true;
			btn_copy.Visible = false;
			btn_copy.Click += btn_copy_Click;
			// 
			// btn_Clear
			// 
			btn_Clear.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
			btn_Clear.Location = new Point(1223, 812);
			btn_Clear.Name = "btn_Clear";
			btn_Clear.Size = new Size(63, 32);
			btn_Clear.TabIndex = 11;
			btn_Clear.Text = "清空";
			btn_Clear.UseVisualStyleBackColor = true;
			btn_Clear.Click += btn_Clear_Click;
			// 
			// btn_ForceUpdate
			// 
			btn_ForceUpdate.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
			btn_ForceUpdate.Location = new Point(1146, 812);
			btn_ForceUpdate.Name = "btn_ForceUpdate";
			btn_ForceUpdate.Size = new Size(71, 32);
			btn_ForceUpdate.TabIndex = 12;
			btn_ForceUpdate.Text = "刷新";
			btn_ForceUpdate.UseVisualStyleBackColor = true;
			btn_ForceUpdate.Click += btn_ForceUpdate_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1482, 853);
			Controls.Add(btn_ForceUpdate);
			Controls.Add(btn_Clear);
			Controls.Add(btn_copy);
			Controls.Add(containPanel);
			Controls.Add(weekCount);
			Controls.Add(btnToNext);
			Controls.Add(btnToPre);
			Controls.Add(lblStatus);
			Controls.Add(menuStrip2);
			Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			ForeColor = Color.Black;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MainMenuStrip = menuStrip2;
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			Name = "Form1";
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "值班表编辑器";
			menuStrip2.ResumeLayout(false);
			menuStrip2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btnToNext;
		private Button btnToPre;
		private Label lblStatus;
		private Label weekCount;
		private Panel containPanel;
		private ToolStripMenuItem Datas;
		private ToolStripMenuItem m_NewSche;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripMenuItem m_SaveJson;
		private ToolStripMenuItem m_LoadJson;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem m_ExportWebJson;
		private ToolStripMenuItem Member;
		private ToolStripMenuItem m_AddXlsx;
		private ToolStripMenuItem m_AddJson;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem m_OpenMemberList;
		private MenuStrip menuStrip2;
		private ToolStripMenuItem saveMemberJson;
		private ToolStripMenuItem ScheduleData;
		private Button btn_copy;
		private Button btn_Clear;
		private Button btn_ForceUpdate;
		private ToolStripMenuItem m_ExportCsv;
	}
}