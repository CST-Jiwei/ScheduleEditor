namespace ScheduleEditor
{
	partial class MemberListForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tabControl1 = new TabControl();
			allMember = new TabPage();
			weekView = new TabPage();
			button2 = new Button();
			panel1 = new Panel();
			button1 = new Button();
			memberListBox = new ListBox();
			tabControl1.SuspendLayout();
			allMember.SuspendLayout();
			weekView.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(allMember);
			tabControl1.Controls.Add(weekView);
			tabControl1.Location = new Point(12, 12);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(1288, 656);
			tabControl1.TabIndex = 0;
			// 
			// allMember
			// 
			allMember.Controls.Add(memberListBox);
			allMember.Location = new Point(4, 29);
			allMember.Name = "allMember";
			allMember.Padding = new Padding(3);
			allMember.Size = new Size(1280, 623);
			allMember.TabIndex = 0;
			allMember.Text = "队员总览";
			allMember.UseVisualStyleBackColor = true;
			// 
			// weekView
			// 
			weekView.Controls.Add(button2);
			weekView.Controls.Add(panel1);
			weekView.Controls.Add(button1);
			weekView.Location = new Point(4, 29);
			weekView.Name = "weekView";
			weekView.Padding = new Padding(3);
			weekView.Size = new Size(1280, 623);
			weekView.TabIndex = 1;
			weekView.Text = "按每周查看";
			weekView.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(1219, 272);
			button2.Name = "button2";
			button2.Size = new Size(55, 30);
			button2.TabIndex = 2;
			button2.Text = ">>";
			button2.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			panel1.Location = new Point(67, 6);
			panel1.Name = "panel1";
			panel1.Size = new Size(1146, 611);
			panel1.TabIndex = 1;
			// 
			// button1
			// 
			button1.Location = new Point(6, 272);
			button1.Name = "button1";
			button1.Size = new Size(55, 30);
			button1.TabIndex = 0;
			button1.Text = "<<";
			button1.UseVisualStyleBackColor = true;
			// 
			// memberListBox
			// 
			memberListBox.FormattingEnabled = true;
			memberListBox.ItemHeight = 20;
			memberListBox.Location = new Point(6, 6);
			memberListBox.Name = "memberListBox";
			memberListBox.Size = new Size(1268, 604);
			memberListBox.TabIndex = 0;
			// 
			// MemberListForm
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1312, 680);
			Controls.Add(tabControl1);
			Name = "MemberListForm";
			Text = "MemberListForm";
			tabControl1.ResumeLayout(false);
			allMember.ResumeLayout(false);
			weekView.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage allMember;
		private TabPage weekView;
		private Button button2;
		private Panel panel1;
		private Button button1;
		private ListBox memberListBox;
	}
}