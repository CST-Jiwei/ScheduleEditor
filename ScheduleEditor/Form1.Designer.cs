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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			btnToNext = new Button();
			btnToPre = new Button();
			lblStatus = new Label();
			weekCount = new Label();
			containPanel = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			memberTagControl1 = new Components.MemberTagControl();
			ScheduleData = new ToolStripMenuItem();
			m_NewSche = new ToolStripMenuItem();
			toolStripSeparator3 = new ToolStripSeparator();
			m_SaveJson = new ToolStripMenuItem();
			m_LoadJson = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			m_ImportWebJson = new ToolStripMenuItem();
			Member = new ToolStripMenuItem();
			m_AddXlsx = new ToolStripMenuItem();
			m_AddJson = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			m_OpenMemberList = new ToolStripMenuItem();
			saveMemberJson = new ToolStripMenuItem();
			menuStrip2 = new MenuStrip();
			containPanel.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			menuStrip2.SuspendLayout();
			SuspendLayout();
			// 
			// btnToNext
			// 
			btnToNext.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
			btnToNext.Location = new Point(1335, 321);
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
			lblStatus.Location = new Point(26, 672);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(453, 30);
			lblStatus.TabIndex = 5;
			lblStatus.Text = "暂无数据，请先导入值班表数据或新建值班表";
			// 
			// weekCount
			// 
			weekCount.AutoSize = true;
			weekCount.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
			weekCount.Location = new Point(10, 43);
			weekCount.Name = "weekCount";
			weekCount.Size = new Size(72, 26);
			weekCount.TabIndex = 9;
			weekCount.Text = "第xx周";
			// 
			// containPanel
			// 
			containPanel.Controls.Add(tableLayoutPanel1);
			containPanel.Location = new Point(74, 63);
			containPanel.Name = "containPanel";
			containPanel.Size = new Size(1255, 606);
			containPanel.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 5;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.Controls.Add(memberTagControl1, 1, 1);
			tableLayoutPanel1.Location = new Point(3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.Size = new Size(1249, 581);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// memberTagControl1
			// 
			memberTagControl1.AvailableMembers = (List<string>)resources.GetObject("memberTagControl1.AvailableMembers");
			memberTagControl1.BackColor = SystemColors.Control;
			memberTagControl1.Location = new Point(252, 148);
			memberTagControl1.Name = "memberTagControl1";
			memberTagControl1.Size = new Size(243, 135);
			memberTagControl1.TabIndex = 0;
			memberTagControl1.WeekDaySection = ((int, int, int))resources.GetObject("memberTagControl1.WeekDaySection");
			// 
			// ScheduleData
			// 
			ScheduleData.DropDownItems.AddRange(new ToolStripItem[] { m_NewSche, toolStripSeparator3, m_SaveJson, m_LoadJson, toolStripSeparator1, m_ImportWebJson });
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
			m_SaveJson.Text = "保存至Json";
			m_SaveJson.Click += SaveScheduleJson;
			// 
			// m_LoadJson
			// 
			m_LoadJson.Name = "m_LoadJson";
			m_LoadJson.Size = new Size(229, 26);
			m_LoadJson.Text = "读取Json";
			m_LoadJson.Click += LoadScheduleJson;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(226, 6);
			// 
			// m_ImportWebJson
			// 
			m_ImportWebJson.Name = "m_ImportWebJson";
			m_ImportWebJson.Size = new Size(229, 26);
			m_ImportWebJson.Text = "导出网页端可读Json";
			m_ImportWebJson.Click += ExportWebJson;
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
			menuStrip2.Size = new Size(1403, 28);
			menuStrip2.TabIndex = 1;
			menuStrip2.Text = "menuStrip2";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1403, 715);
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
			Load += Form1_Load;
			containPanel.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
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
		private TableLayoutPanel tableLayoutPanel1;
		private ToolStripMenuItem Datas;
		private ToolStripMenuItem m_NewSche;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripMenuItem m_SaveJson;
		private ToolStripMenuItem m_LoadJson;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem m_ImportWebJson;
		private ToolStripMenuItem Member;
		private ToolStripMenuItem m_AddXlsx;
		private ToolStripMenuItem m_AddJson;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem m_OpenMemberList;
		private MenuStrip menuStrip2;
		private Components.MemberTagControl memberTagControl1;
		private ToolStripMenuItem saveMemberJson;
		private ToolStripMenuItem ScheduleData;
	}
}