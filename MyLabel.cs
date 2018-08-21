using System;
using System.Windows.Forms;
using System.Drawing;

namespace Labs
{
	/// <summary>
	/// Summary description for MyLabel.
	/// </summary>
	public class MyLabel:System.Windows.Forms.Label
    {
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private bool _isOdd;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private int myIndex;

		public MyLabel(int index)
		{
            InitializeComponent();
            myIndex = index;
			int width=250;
			int height=80;

			this.Text=System.Convert.ToString(index);
			this.Size=new Size(width,height);			
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

			this.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.AllowDrop=true;

			int n=index/2;
			if((index %2)==0)
			{
				_isOdd=false;
				this.Location=new Point(width,(n-1)*height);
			}
			else
			{
				_isOdd=true;				
				this.Location=new Point(0,n*height);
			}

			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragEnter);
			this.DragLeave += new System.EventHandler(this.MyLabel_DragLeave);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyLabel_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseDown);
            this.toolStripMenuItem1.Click += ToolStripMenuItem1_Click;

           
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Person p = (Person)(((ListViewItem)this.Tag).Tag);
            new PersonPropertiesForm(p).ShowDialog();
            
        }

        private void MyLabel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{			
            
			MyLabel label =(MyLabel)sender;
			ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
			Person inMovePerson = (Person)lvi.Tag;
			
			bool isOddInMovePerson;
			if(inMovePerson.Index % 2==0)
			{
				isOddInMovePerson=false;
			}
			else 
			{
				isOddInMovePerson=true;
			}

			if(label.Tag==null && (isOddInMovePerson==this._isOdd)) 
			{
				label.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;
				e.Effect = DragDropEffects.Move;
			}
            
		}

		private void MyLabel_DragLeave(object sender, System.EventArgs e)
		{
			MyLabel label =(MyLabel)sender;
			if(label.BorderStyle== System.Windows.Forms.BorderStyle.FixedSingle)
			{
				label.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;				
			}
		}

		private void MyLabel_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{					
			ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
			Person dropedPerson = (Person)lvi.Tag;
			
			this.Text=dropedPerson.Name+" "+dropedPerson.LastName;
            this.Tag=lvi;
			this.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;
		}

       

        private void MyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && this.Tag!=null)
            {
                AppForm.myLabels.ForEach(delegate (MyLabel l)
                {
                    l.AllowDrop = false;
                });
                if (DragDropEffects.Move == DoDragDrop(this.Tag, DragDropEffects.Move))
                {
                    this.Tag = null;
                    this.Text = myIndex.ToString();
                }
            }
            if(e.Button == MouseButtons.Right && this.Tag!=null)
            {
                contextMenuStrip2.Show(this, new Point(e.X, e.Y));
            }
            AppForm.myLabels.ForEach(delegate (MyLabel l)
            {
                l.AllowDrop = true;
            });

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(110, 26);
          //  this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem1.Text = "Details";
            // 
            // MyLabel
            // 
            //this.ContextMenuStrip = this.contextMenuStrip2;
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        
    }
}
