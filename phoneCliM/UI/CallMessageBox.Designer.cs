namespace PhoneCliM.UI {
   partial class CallMessageBox {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallMessageBox));
         this.panel1 = new System.Windows.Forms.Panel();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.lblText = new System.Windows.Forms.Label();
         this.btnCall = new System.Windows.Forms.Button();
         this.btnSearchBackwards = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.panel1.Controls.Add(this.pictureBox1);
         this.panel1.Controls.Add(this.lblText);
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(400, 84);
         this.panel1.TabIndex = 0;
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
         this.pictureBox1.Location = new System.Drawing.Point(25, 25);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(35, 35);
         this.pictureBox1.TabIndex = 1;
         this.pictureBox1.TabStop = false;
         // 
         // lblText
         // 
         this.lblText.AutoSize = true;
         this.lblText.Location = new System.Drawing.Point(70, 26);
         this.lblText.MaximumSize = new System.Drawing.Size(300, 0);
         this.lblText.Name = "lblText";
         this.lblText.Size = new System.Drawing.Size(38, 13);
         this.lblText.TabIndex = 0;
         this.lblText.Text = "lblText";
         // 
         // btnCall
         // 
         this.btnCall.Location = new System.Drawing.Point(224, 95);
         this.btnCall.Name = "btnCall";
         this.btnCall.Size = new System.Drawing.Size(85, 23);
         this.btnCall.TabIndex = 1;
         this.btnCall.Text = "btnCall";
         this.btnCall.UseVisualStyleBackColor = true;
         this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
         // 
         // btnSearchBackwards
         // 
         this.btnSearchBackwards.Location = new System.Drawing.Point(12, 95);
         this.btnSearchBackwards.Name = "btnSearchBackwards";
         this.btnSearchBackwards.Size = new System.Drawing.Size(127, 23);
         this.btnSearchBackwards.TabIndex = 2;
         this.btnSearchBackwards.Text = "btnSearchBackwards";
         this.btnSearchBackwards.UseVisualStyleBackColor = true;
         this.btnSearchBackwards.Click += new System.EventHandler(this.btnSearchBackwards_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(315, 95);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "btnCancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // CallForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(399, 130);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnSearchBackwards);
         this.Controls.Add(this.btnCall);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CallForm";
         this.ShowIcon = false;
         this.Text = "CallForm";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnCall;
      private System.Windows.Forms.Button btnSearchBackwards;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Label lblText;
      private System.Windows.Forms.PictureBox pictureBox1;
   }
}