using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace Labs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class AppForm : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.Panel panel1;
        private IContainer components;
        public static List<MyLabel> myLabels;
		public AppForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            myLabels = new List<MyLabel>();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(272, 355);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DoubleClick += new System.EventHandler(this.ShowPersonData_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Name";
            this.columnHeader2.Width = 128;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "New Person";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(272, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 355);
            this.panel1.TabIndex = 1;
            // 
            // AppForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(576, 355);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Menu = this.mainMenu1;
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab3_4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AppForm());
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			PersonPropertiesForm ppf=new PersonPropertiesForm();
			ppf.ShowDialog(this);
			if(ppf.DialogResult==DialogResult.OK)
			{
				try
				{
					string name=ppf.getNameTextBoxText();
					string lastName=ppf.getLastNameTextBoxText();
					int age=System.Convert.ToInt32(ppf.getAgeTextBoxText());
					string city=ppf.getCityComboBoxText();
					Person p=new Person(name,lastName,age,city);

					string[] str=new string[2]{name,lastName};
					ListViewItem lvi=new ListViewItem(str);
					lvi.Tag=p;
					listView1.Items.Add(lvi);

					///
					MyLabel label=new MyLabel(p.Index);
                    myLabels.Add(label);
					panel1.Controls.Add(label);


				}
				catch
				{
					
				}

			}
			ppf.Dispose();
		
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			if(listView1.SelectedItems.Count>0)
			{
				contextMenu1.MenuItems.Clear();

				MenuItem menuItem1 = new MenuItem("Show Person data");
				menuItem1.Click += new System.EventHandler(this.ShowPersonData_Click);
				contextMenu1.MenuItems.Add(menuItem1);				

			}
		}

		private void ShowPersonData_Click(object sender, System.EventArgs e)
		{
			if(listView1.SelectedItems.Count>0)
			{
				ListViewItem lvi=listView1.SelectedItems[0];
				Person p=(Person)lvi.Tag;

				PersonPropertiesForm ppf=new PersonPropertiesForm(p);
				ppf.ShowDialog(this);
				if(ppf.DialogResult==DialogResult.OK)
				{
					try
					{
						p.Name=ppf.getNameTextBoxText();
						p.LastName=ppf.getLastNameTextBoxText();
						p.Age=System.Convert.ToInt32(ppf.getAgeTextBoxText());
						p.City=ppf.getCityComboBoxText();
					
						lvi.SubItems[0].Text=p.Name;
						lvi.SubItems[1].Text=p.LastName;
					}
					catch
					{
					
					}

				}
				ppf.Dispose();
			}

		}

		private void listView1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
            listView1.AllowDrop = false;
			ListViewItem dragedLvi = (ListViewItem)e.Item;
															
			if(DragDropEffects.Move==listView1.DoDragDrop(dragedLvi,DragDropEffects.Move)) 
			{
				listView1.Items.Remove(dragedLvi);
                listView1.AllowDrop = true;
			}
		}

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
           
            e.Effect = DragDropEffects.Move;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
                listView1.Items.Add(lvi);
            
        }
    }
}
