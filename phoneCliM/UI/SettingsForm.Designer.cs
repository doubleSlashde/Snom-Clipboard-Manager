namespace PhoneCliM.UI {
   partial class SettingsForm{
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.tbIpAddress = new System.Windows.Forms.TextBox();
         this.tbUser = new System.Windows.Forms.TextBox();
         this.tbPassword = new System.Windows.Forms.TextBox();
         this.lblIP = new System.Windows.Forms.Label();
         this.lblUser = new System.Windows.Forms.Label();
         this.lblPassword = new System.Windows.Forms.Label();
         this.lblOwnNumber = new System.Windows.Forms.Label();
         this.tbOwnNumber = new System.Windows.Forms.TextBox();
         this.lblLine = new System.Windows.Forms.Label();
         this.cbAutoStart = new System.Windows.Forms.CheckBox();
         this.buttonPanel.SuspendLayout();
         this.contentPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonPanel
         // 
         this.buttonPanel.Location = new System.Drawing.Point(0, 246);
         this.buttonPanel.Size = new System.Drawing.Size(285, 54);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(169, 15);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(34, 15);
         this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
         // 
         // contentPanel
         // 
         this.contentPanel.Controls.Add(this.cbAutoStart);
         this.contentPanel.Controls.Add(this.lblLine);
         this.contentPanel.Controls.Add(this.tbOwnNumber);
         this.contentPanel.Controls.Add(this.lblOwnNumber);
         this.contentPanel.Controls.Add(this.lblPassword);
         this.contentPanel.Controls.Add(this.lblUser);
         this.contentPanel.Controls.Add(this.lblIP);
         this.contentPanel.Controls.Add(this.tbPassword);
         this.contentPanel.Controls.Add(this.tbUser);
         this.contentPanel.Controls.Add(this.tbIpAddress);
         this.contentPanel.Size = new System.Drawing.Size(285, 247);
         // 
         // tbIpAddress
         // 
         this.tbIpAddress.Location = new System.Drawing.Point(51, 30);
         this.tbIpAddress.Name = "tbIpAddress";
         this.tbIpAddress.Size = new System.Drawing.Size(124, 20);
         this.tbIpAddress.TabIndex = 0;
         this.tbIpAddress.Text = "tbIpAddress";
         // 
         // tbUser
         // 
         this.tbUser.Location = new System.Drawing.Point(51, 74);
         this.tbUser.Name = "tbUser";
         this.tbUser.Size = new System.Drawing.Size(175, 20);
         this.tbUser.TabIndex = 1;
         this.tbUser.Text = "tbUser";
         // 
         // tbPassword
         // 
         this.tbPassword.Location = new System.Drawing.Point(51, 118);
         this.tbPassword.Name = "tbPassword";
         this.tbPassword.PasswordChar = '*';
         this.tbPassword.Size = new System.Drawing.Size(175, 20);
         this.tbPassword.TabIndex = 2;
         this.tbPassword.Text = "tbPassword";
         // 
         // lblIP
         // 
         this.lblIP.AutoSize = true;
         this.lblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblIP.Location = new System.Drawing.Point(48, 12);
         this.lblIP.Name = "lblIP";
         this.lblIP.Size = new System.Drawing.Size(32, 13);
         this.lblIP.TabIndex = 4;
         this.lblIP.Text = "lblIP";
         // 
         // lblUser
         // 
         this.lblUser.AutoSize = true;
         this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblUser.Location = new System.Drawing.Point(48, 57);
         this.lblUser.Name = "lblUser";
         this.lblUser.Size = new System.Drawing.Size(46, 13);
         this.lblUser.TabIndex = 5;
         this.lblUser.Text = "lblUser";
         // 
         // lblPassword
         // 
         this.lblPassword.AutoSize = true;
         this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPassword.Location = new System.Drawing.Point(48, 101);
         this.lblPassword.Name = "lblPassword";
         this.lblPassword.Size = new System.Drawing.Size(74, 13);
         this.lblPassword.TabIndex = 6;
         this.lblPassword.Text = "lblPassword";
         // 
         // lblOwnNumber
         // 
         this.lblOwnNumber.AutoSize = true;
         this.lblOwnNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblOwnNumber.Location = new System.Drawing.Point(50, 149);
         this.lblOwnNumber.Name = "lblOwnNumber";
         this.lblOwnNumber.Size = new System.Drawing.Size(88, 13);
         this.lblOwnNumber.TabIndex = 7;
         this.lblOwnNumber.Text = "lblOwnNumber";
         this.lblOwnNumber.Click += new System.EventHandler(this.label1_Click);
         // 
         // tbOwnNumber
         // 
         this.tbOwnNumber.Location = new System.Drawing.Point(74, 167);
         this.tbOwnNumber.MaxLength = 3;
         this.tbOwnNumber.Name = "tbOwnNumber";
         this.tbOwnNumber.Size = new System.Drawing.Size(46, 20);
         this.tbOwnNumber.TabIndex = 8;
         this.tbOwnNumber.Text = "tbOwnNumber";
         // 
         // lblLine
         // 
         this.lblLine.AutoSize = true;
         this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblLine.Location = new System.Drawing.Point(57, 170);
         this.lblLine.Name = "lblLine";
         this.lblLine.Size = new System.Drawing.Size(44, 13);
         this.lblLine.TabIndex = 9;
         this.lblLine.Text = "lblLine";
         // 
         // cbAutoStart
         // 
         this.cbAutoStart.AutoSize = true;
         this.cbAutoStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cbAutoStart.Location = new System.Drawing.Point(51, 207);
         this.cbAutoStart.Name = "cbAutoStart";
         this.cbAutoStart.Size = new System.Drawing.Size(93, 17);
         this.cbAutoStart.TabIndex = 10;
         this.cbAutoStart.Text = "cbAutoStart";
         this.cbAutoStart.UseVisualStyleBackColor = true;
         // 
         // SettingsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(285, 300);
         this.Name = "SettingsForm";
         this.Text = "SettingsForm";
         this.buttonPanel.ResumeLayout(false);
         this.contentPanel.ResumeLayout(false);
         this.contentPanel.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox tbIpAddress;
      private System.Windows.Forms.TextBox tbUser;
      private System.Windows.Forms.TextBox tbPassword;
      private System.Windows.Forms.Label lblIP;
      private System.Windows.Forms.Label lblUser;
      private System.Windows.Forms.Label lblPassword;
      private System.Windows.Forms.Label lblOwnNumber;
      private System.Windows.Forms.CheckBox cbAutoStart;
      private System.Windows.Forms.Label lblLine;
      private System.Windows.Forms.TextBox tbOwnNumber;
   }
}