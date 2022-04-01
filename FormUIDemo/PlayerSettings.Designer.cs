namespace DurakUI
{
    partial class frmPlayerSettings
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
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.cdPlayerColors = new System.Windows.Forms.ColorDialog();
            this.pnlPlayerColor = new System.Windows.Forms.Panel();
            this.pnlComputerColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblComputer = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdo36Cards = new System.Windows.Forms.RadioButton();
            this.rdo52Cards = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPlayerName.Location = new System.Drawing.Point(158, 51);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(175, 23);
            this.txtPlayerName.TabIndex = 0;
            this.txtPlayerName.Leave += new System.EventHandler(this.txtPlayerName_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Computer Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComputerName
            // 
            this.txtComputerName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtComputerName.Location = new System.Drawing.Point(158, 86);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(175, 23);
            this.txtComputerName.TabIndex = 2;
            this.txtComputerName.Leave += new System.EventHandler(this.txtComputerName_Leave);
            // 
            // pnlPlayerColor
            // 
            this.pnlPlayerColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayerColor.Location = new System.Drawing.Point(339, 51);
            this.pnlPlayerColor.Name = "pnlPlayerColor";
            this.pnlPlayerColor.Size = new System.Drawing.Size(110, 23);
            this.pnlPlayerColor.TabIndex = 4;
            this.pnlPlayerColor.Click += new System.EventHandler(this.pnlPlayerColor_Click);
            // 
            // pnlComputerColor
            // 
            this.pnlComputerColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComputerColor.Location = new System.Drawing.Point(339, 86);
            this.pnlComputerColor.Name = "pnlComputerColor";
            this.pnlComputerColor.Size = new System.Drawing.Size(110, 23);
            this.pnlComputerColor.TabIndex = 5;
            this.pnlComputerColor.Click += new System.EventHandler(this.pnlComputerColor_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(336, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Color";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPlayer
            // 
            this.lblPlayer.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPlayer.ForeColor = System.Drawing.Color.Black;
            this.lblPlayer.Location = new System.Drawing.Point(9, 11);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(379, 23);
            this.lblPlayer.TabIndex = 7;
            this.lblPlayer.Text = "Player has played the 10 of Spade\'s";
            this.lblPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComputer
            // 
            this.lblComputer.Font = new System.Drawing.Font("Arial", 10F);
            this.lblComputer.ForeColor = System.Drawing.Color.Black;
            this.lblComputer.Location = new System.Drawing.Point(9, 34);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(403, 23);
            this.lblComputer.TabIndex = 8;
            this.lblComputer.Text = "Computer has played the King of Spade\'s";
            this.lblComputer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.Location = new System.Drawing.Point(339, 266);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(110, 37);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Confirm";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lblPlayer);
            this.panel1.Controls.Add(this.lblComputer);
            this.panel1.Location = new System.Drawing.Point(37, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 68);
            this.panel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(55, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Deck Size";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdo36Cards
            // 
            this.rdo36Cards.AutoSize = true;
            this.rdo36Cards.Checked = true;
            this.rdo36Cards.Font = new System.Drawing.Font("Arial", 10F);
            this.rdo36Cards.ForeColor = System.Drawing.Color.White;
            this.rdo36Cards.Location = new System.Drawing.Point(158, 266);
            this.rdo36Cards.Name = "rdo36Cards";
            this.rdo36Cards.Size = new System.Drawing.Size(84, 20);
            this.rdo36Cards.TabIndex = 12;
            this.rdo36Cards.TabStop = true;
            this.rdo36Cards.Text = "36 Cards";
            this.rdo36Cards.UseVisualStyleBackColor = true;
            // 
            // rdo52Cards
            // 
            this.rdo52Cards.AutoSize = true;
            this.rdo52Cards.Font = new System.Drawing.Font("Arial", 10F);
            this.rdo52Cards.ForeColor = System.Drawing.Color.White;
            this.rdo52Cards.Location = new System.Drawing.Point(158, 289);
            this.rdo52Cards.Name = "rdo52Cards";
            this.rdo52Cards.Size = new System.Drawing.Size(84, 20);
            this.rdo52Cards.TabIndex = 13;
            this.rdo52Cards.Text = "52 Cards";
            this.rdo52Cards.UseVisualStyleBackColor = true;
            // 
            // frmPlayerSettings
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.CancelButton = this.btnSubmit;
            this.ClientSize = new System.Drawing.Size(481, 340);
            this.Controls.Add(this.rdo52Cards);
            this.Controls.Add(this.rdo36Cards);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlComputerColor);
            this.Controls.Add(this.pnlPlayerColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComputerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlayerName);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlayerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerSettings";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.ColorDialog cdPlayerColors;
        private System.Windows.Forms.Panel pnlPlayerColor;
        private System.Windows.Forms.Panel pnlComputerColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdo36Cards;
        private System.Windows.Forms.RadioButton rdo52Cards;
    }
}