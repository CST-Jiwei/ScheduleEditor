﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleEditor.Components
{
	public partial class TagControl : UserControl
	{
		public TagControl()
		{
			InitializeComponent();
		}

		public event EventHandler? CloseEvent;

		private void onClose_Click(object sender, EventArgs e)
		{
			CloseEvent?.Invoke(this, e);
		}

		private void name_Click(object sender, EventArgs e)
		{

		}

		public string NameText
		{
			get => name.Text;
			set => name.Text = value;
		}


	}
}
