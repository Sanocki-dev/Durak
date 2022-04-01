namespace DurakUI
{
    partial class frmInstructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstructions));
            this.btnExit = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.pbxInstructions = new System.Windows.Forms.PictureBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInstructions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(24, 787);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(720, 37);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // rtbInfo
            // 
            this.rtbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbInfo.Location = new System.Drawing.Point(0, 0);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(777, 493);
            this.rtbInfo.TabIndex = 2;
            this.rtbInfo.Text = "";
            // 
            // pbxInstructions
            // 
            this.pbxInstructions.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxInstructions.ErrorImage")));
            this.pbxInstructions.Image = ((System.Drawing.Image)(resources.GetObject("pbxInstructions.Image")));
            this.pbxInstructions.Location = new System.Drawing.Point(0, 0);
            this.pbxInstructions.Name = "pbxInstructions";
            this.pbxInstructions.Size = new System.Drawing.Size(777, 493);
            this.pbxInstructions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxInstructions.TabIndex = 3;
            this.pbxInstructions.TabStop = false;
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Arial", 8F);
            this.lblInstructions.Location = new System.Drawing.Point(21, 554);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(744, 57);
            this.lblInstructions.TabIndex = 6;
            this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.Location = new System.Drawing.Point(21, 696);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(747, 88);
            this.label2.TabIndex = 8;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8F);
            this.label3.Location = new System.Drawing.Point(21, 611);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(747, 76);
            this.label3.TabIndex = 7;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8F);
            this.label1.Location = new System.Drawing.Point(21, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(744, 51);
            this.label1.TabIndex = 9;
            this.label1.Text = "Goal:\r\nThe goal of Durak is to get rid of all of your cards before your opponent," +
    " and if you are the last one left with cards you are declared the DURAK!";
            // 
            // frmInstructions
            // 
            this.AcceptButton = this.btnExit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(777, 851);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.pbxInstructions);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstructions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructions";
            ((System.ComponentModel.ISupportInitialize)(this.pbxInstructions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.PictureBox pbxInstructions;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}