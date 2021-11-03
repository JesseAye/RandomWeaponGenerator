
namespace FormForWeaponGenerator
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
			this.txtbxWeapon = new System.Windows.Forms.TextBox();
			this.lblWeapon = new System.Windows.Forms.Label();
			this.txtbxClipSize = new System.Windows.Forms.TextBox();
			this.lblClipSize = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtbxWeapon
			// 
			this.txtbxWeapon.Location = new System.Drawing.Point(82, 25);
			this.txtbxWeapon.Name = "txtbxWeapon";
			this.txtbxWeapon.Size = new System.Drawing.Size(270, 27);
			this.txtbxWeapon.TabIndex = 0;
			// 
			// lblWeapon
			// 
			this.lblWeapon.AutoSize = true;
			this.lblWeapon.Location = new System.Drawing.Point(12, 28);
			this.lblWeapon.Name = "lblWeapon";
			this.lblWeapon.Size = new System.Drawing.Size(64, 20);
			this.lblWeapon.TabIndex = 1;
			this.lblWeapon.Text = "Weapon";
			// 
			// txtbxClipSize
			// 
			this.txtbxClipSize.Location = new System.Drawing.Point(84, 58);
			this.txtbxClipSize.Name = "txtbxClipSize";
			this.txtbxClipSize.Size = new System.Drawing.Size(83, 27);
			this.txtbxClipSize.TabIndex = 2;
			// 
			// lblClipSize
			// 
			this.lblClipSize.AutoSize = true;
			this.lblClipSize.Location = new System.Drawing.Point(12, 61);
			this.lblClipSize.Name = "lblClipSize";
			this.lblClipSize.Size = new System.Drawing.Size(66, 20);
			this.lblClipSize.TabIndex = 3;
			this.lblClipSize.Text = "Clip Size";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lblClipSize);
			this.Controls.Add(this.txtbxClipSize);
			this.Controls.Add(this.lblWeapon);
			this.Controls.Add(this.txtbxWeapon);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtbxWeapon;
		private System.Windows.Forms.Label lblWeapon;
		private System.Windows.Forms.TextBox txtbxClipSize;
		private System.Windows.Forms.Label lblClipSize;
	}
}

