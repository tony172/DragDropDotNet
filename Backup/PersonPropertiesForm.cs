using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Labs
{
	/// <summary>
	/// Summary description for PersonPropertiesForm.
	/// </summary>
	public class PersonPropertiesForm : System.Windows.Forms.Form
	{		
		private string [] _cities;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _lastNameTextBox;
		private System.Windows.Forms.TextBox _ageTextBox;
		private System.Windows.Forms.ComboBox _cityComboBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PersonPropertiesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			_cities=new string[4]{"Split","Zagreb","Rijeka","Osijek"};
			_cityComboBox.DataSource=_cities;
		}

		public PersonPropertiesForm(Person person):this()
		{
			_nameTextBox.Text=person.Name;
			_lastNameTextBox.Text=person.LastName;
			_ageTextBox.Text=System.Convert.ToString(person.Age);
			_cityComboBox.SelectedItem=person.City;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this._nameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this._lastNameTextBox = new System.Windows.Forms.TextBox();
			this._ageTextBox = new System.Windows.Forms.TextBox();
			this._cityComboBox = new System.Windows.Forms.ComboBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _nameTextBox
			// 
			this._nameTextBox.Location = new System.Drawing.Point(88, 24);
			this._nameTextBox.Name = "_nameTextBox";
			this._nameTextBox.Size = new System.Drawing.Size(248, 20);
			this._nameTextBox.TabIndex = 1;
			this._nameTextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Last Name:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Age:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "City:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _lastNameTextBox
			// 
			this._lastNameTextBox.Location = new System.Drawing.Point(88, 72);
			this._lastNameTextBox.Name = "_lastNameTextBox";
			this._lastNameTextBox.Size = new System.Drawing.Size(248, 20);
			this._lastNameTextBox.TabIndex = 5;
			this._lastNameTextBox.Text = "";
			// 
			// _ageTextBox
			// 
			this._ageTextBox.Location = new System.Drawing.Point(88, 120);
			this._ageTextBox.Name = "_ageTextBox";
			this._ageTextBox.TabIndex = 6;
			this._ageTextBox.Text = "";
			// 
			// _cityComboBox
			// 
			this._cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cityComboBox.Location = new System.Drawing.Point(88, 168);
			this._cityComboBox.Name = "_cityComboBox";
			this._cityComboBox.Size = new System.Drawing.Size(248, 21);
			this._cityComboBox.Sorted = true;
			this._cityComboBox.TabIndex = 7;
			// 
			// _okButton
			// 
			this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._okButton.Location = new System.Drawing.Point(107, 248);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(75, 32);
			this._okButton.TabIndex = 8;
			this._okButton.Text = "OK";
			// 
			// _cancelButton
			// 
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.Location = new System.Drawing.Point(219, 248);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(75, 32);
			this._cancelButton.TabIndex = 9;
			this._cancelButton.Text = "Cancel";
			// 
			// PersonPropertiesForm
			// 
			this.AcceptButton = this._okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this._cancelButton;
			this.ClientSize = new System.Drawing.Size(400, 300);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._cityComboBox);
			this.Controls.Add(this._ageTextBox);
			this.Controls.Add(this._lastNameTextBox);
			this.Controls.Add(this._nameTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PersonPropertiesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Person";
			this.ResumeLayout(false);

		}
		#endregion

		
		public string getNameTextBoxText()
		{
			return _nameTextBox.Text.Trim();
		}

		public string getLastNameTextBoxText()
		{
			return _lastNameTextBox.Text.Trim();
		}

		public string getAgeTextBoxText()
		{
			return _ageTextBox.Text.Trim();
		}

		public string getCityComboBoxText()
		{
			return (string)_cityComboBox.SelectedItem;
		}
		
	}
}
