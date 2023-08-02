namespace ScheduleEditor.Components
{
	partial class TagControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			name = new Label();
			close = new Label();
			contextMenuStrip1 = new ContextMenuStrip(components);
			删除ToolStripMenuItem = new ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// name
			// 
			name.AutoSize = true;
			name.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
			name.Location = new Point(3, 10);
			name.Name = "name";
			name.Size = new Size(78, 24);
			name.TabIndex = 0;
			name.Text = "名字测试";
			// 
			// close
			// 
			close.AutoSize = true;
			close.Cursor = Cursors.Hand;
			close.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			close.Location = new Point(83, 9);
			close.Name = "close";
			close.Size = new Size(24, 25);
			close.TabIndex = 1;
			close.Text = "X";
			close.Click += onClose_Click;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 删除ToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(109, 28);
			// 
			// 删除ToolStripMenuItem
			// 
			删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			删除ToolStripMenuItem.Size = new Size(108, 24);
			删除ToolStripMenuItem.Text = "删除";
			// 
			// TagControl
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			BorderStyle = BorderStyle.Fixed3D;
			ContextMenuStrip = contextMenuStrip1;
			Controls.Add(close);
			Controls.Add(name);
			Name = "TagControl";
			Size = new Size(110, 42);
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label name;
		private Label close;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem 删除ToolStripMenuItem;
	}
}
