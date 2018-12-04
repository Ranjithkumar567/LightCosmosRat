﻿/*
 * Created by SharpDevelop.
 * User: robit
 * Date: 28/10/2018
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace LightCosmosRat
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	public partial class MainForm : Form
	{
		bool ClientMakerStarted;
		void StatusHandler(Object tbt){
			TextBox tb = (TextBox)tbt;
			while(true){
				Thread.Sleep(3000);
				if(ClientMakerStarted){
					tb.Text = "Client maker running...";
				}
				else{
					tb.Text = "Ready...";
				}
			}
		}
		Thread t;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			CheckForIllegalCrossThreadCalls = false;
			ClientMakerStarted = false;
		}
		void Button1Click(object sender, EventArgs e)
		{
			new Form1().Show();
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			t = new Thread(StatusHandler);
			t.Start(textBox1);
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			t.Abort();
		}
		void Button3Click(object sender, EventArgs e)
		{
			MessageBox.Show("This software was developed by Robitec97 ","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		void Button2Click(object sender, EventArgs e)
		{
			new Form2().Show();
		}
	}
}
