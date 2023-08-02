namespace ScheduleEditor.Components
{
	partial class MemberTagControl
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
			flowPane = new FlowLayoutPanel();
			cmbx_member = new ComboBox();
			SuspendLayout();
			// 
			// flowPane
			// 
			flowPane.BorderStyle = BorderStyle.FixedSingle;
			flowPane.Location = new Point(3, 3);
			flowPane.Name = "flowPane";
			flowPane.Size = new Size(216, 97);
			flowPane.TabIndex = 0;
			// 
			// cmbx_member
			// 
			cmbx_member.FormattingEnabled = true;
			cmbx_member.Location = new Point(3, 106);
			cmbx_member.Name = "cmbx_member";
			cmbx_member.Size = new Size(132, 28);
			cmbx_member.TabIndex = 1;
			// 
			// MemberTagControl
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Control;
			Controls.Add(cmbx_member);
			Controls.Add(flowPane);
			Name = "MemberTagControl";
			Size = new Size(222, 140);
			ResumeLayout(false);
		}

		#endregion

		private FlowLayoutPanel flowPane;
		private ComboBox cmbx_member;
	}
}
