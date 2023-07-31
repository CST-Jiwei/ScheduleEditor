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
			ListViewItem listViewItem5 = new ListViewItem("21");
			ListViewItem listViewItem6 = new ListViewItem("11");
			ListViewItem listViewItem7 = new ListViewItem("212");
			ListViewItem listViewItem8 = new ListViewItem("121");
			Data = new TabPage();
			btnSaveJson = new Button();
			btnLoadJson = new Button();
			memberListView = new ListView();
			btnLoad = new Button();
			label1 = new Label();
			Edit = new TabPage();
			lblStatus = new Label();
			tableLayoutPanel1 = new TableLayoutPanel();
			tabControl1 = new TabControl();
			Data.SuspendLayout();
			Edit.SuspendLayout();
			tabControl1.SuspendLayout();
			SuspendLayout();
			// 
			// Data
			// 
			Data.Controls.Add(btnSaveJson);
			Data.Controls.Add(btnLoadJson);
			Data.Controls.Add(memberListView);
			Data.Controls.Add(btnLoad);
			Data.Controls.Add(label1);
			Data.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Data.Location = new Point(4, 29);
			Data.Margin = new Padding(3, 4, 3, 4);
			Data.Name = "Data";
			Data.Size = new Size(1229, 694);
			Data.TabIndex = 2;
			Data.Text = "数据管理";
			Data.UseVisualStyleBackColor = true;
			// 
			// btnSaveJson
			// 
			btnSaveJson.Location = new Point(552, 643);
			btnSaveJson.Name = "btnSaveJson";
			btnSaveJson.Size = new Size(230, 40);
			btnSaveJson.TabIndex = 12;
			btnSaveJson.Text = "保存值班表Json文件";
			btnSaveJson.UseVisualStyleBackColor = true;
			btnSaveJson.Click += btnSaveJson_Click;
			// 
			// btnLoadJson
			// 
			btnLoadJson.Location = new Point(287, 643);
			btnLoadJson.Name = "btnLoadJson";
			btnLoadJson.Size = new Size(230, 40);
			btnLoadJson.TabIndex = 11;
			btnLoadJson.Text = "导入值班表Json文件";
			btnLoadJson.UseVisualStyleBackColor = true;
			btnLoadJson.Click += btnLoadJson_Click;
			// 
			// memberListView
			// 
			memberListView.Items.AddRange(new ListViewItem[] { listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
			memberListView.Location = new Point(10, 7);
			memberListView.Name = "memberListView";
			memberListView.Size = new Size(1216, 623);
			memberListView.TabIndex = 10;
			memberListView.UseCompatibleStateImageBehavior = false;
			memberListView.View = View.SmallIcon;
			// 
			// btnLoad
			// 
			btnLoad.Location = new Point(32, 643);
			btnLoad.Name = "btnLoad";
			btnLoad.Size = new Size(160, 40);
			btnLoad.TabIndex = 6;
			btnLoad.Text = "导入xlsx文件";
			btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += btnLoad_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(32, 7);
			label1.Name = "label1";
			label1.Size = new Size(0, 27);
			label1.TabIndex = 9;
			// 
			// Edit
			// 
			Edit.Controls.Add(lblStatus);
			Edit.Controls.Add(tableLayoutPanel1);
			Edit.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Edit.Location = new Point(4, 29);
			Edit.Margin = new Padding(3, 4, 3, 4);
			Edit.Name = "Edit";
			Edit.Padding = new Padding(3, 4, 3, 4);
			Edit.Size = new Size(1229, 694);
			Edit.TabIndex = 0;
			Edit.Text = "值班表编辑";
			Edit.UseVisualStyleBackColor = true;
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Location = new Point(6, 650);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(432, 27);
			lblStatus.TabIndex = 1;
			lblStatus.Text = "暂无数据，请先导入值班表数据或导入队员课表";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 5;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.Location = new Point(6, 7);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
			tableLayoutPanel1.Size = new Size(1217, 626);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(Edit);
			tabControl1.Controls.Add(Data);
			tabControl1.Location = new Point(14, 13);
			tabControl1.Margin = new Padding(3, 4, 3, 4);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(1237, 727);
			tabControl1.TabIndex = 0;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1263, 753);
			Controls.Add(tabControl1);
			ForeColor = Color.Black;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Margin = new Padding(3, 4, 3, 4);
			Name = "Form1";
			Text = "值班表编辑器";
			Data.ResumeLayout(false);
			Data.PerformLayout();
			Edit.ResumeLayout(false);
			Edit.PerformLayout();
			tabControl1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabPage Data;
		private TabPage Edit;
		private TabControl tabControl1;
		private Label label1;
		private ListView memberListView;
		private Button btnLoad;
		private Button btnLoadJson;
		private Button btnSaveJson;
		private TableLayoutPanel tableLayoutPanel1;
		private Label lblStatus;
	}
}