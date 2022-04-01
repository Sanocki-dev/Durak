namespace DurakUI
{
    partial class frmMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.FormUiDemoTips = new System.Windows.Forms.ToolTip(this.components);
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.pnlPlayer1 = new System.Windows.Forms.Panel();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.miInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCardCount = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlAttacker = new System.Windows.Forms.Panel();
            this.lblComputer2 = new System.Windows.Forms.Label();
            this.pnlDefender = new System.Windows.Forms.Panel();
            this.lblWinner = new System.Windows.Forms.Label();
            this.txtFeed = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.pnlWinner = new System.Windows.Forms.Panel();
            this.cbTrump = new CardBox.ACardBox();
            this.lblComputerRecord = new System.Windows.Forms.Label();
            this.lblPlayerRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            this.mnuMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlWinner.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Arial", 10F);
            this.btnExit.Location = new System.Drawing.Point(43, 786);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(159, 41);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.FormUiDemoTips.SetToolTip(this.btnExit, "Exit the application.");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbDeck
            // 
            this.pbDeck.Location = new System.Drawing.Point(96, 386);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(75, 108);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDeck.TabIndex = 2;
            this.pbDeck.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbDeck, "Click the deck to draw a card.");
            // 
            // pnlPlayer2
            // 
            this.pnlPlayer2.AllowDrop = true;
            this.pnlPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlPlayer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlPlayer2.Location = new System.Drawing.Point(300, 222);
            this.pnlPlayer2.Name = "pnlPlayer2";
            this.pnlPlayer2.Size = new System.Drawing.Size(582, 134);
            this.pnlPlayer2.TabIndex = 17;
            this.FormUiDemoTips.SetToolTip(this.pnlPlayer2, "Click cards to move them to the play area.");
            // 
            // pnlPlayer1
            // 
            this.pnlPlayer1.AllowDrop = true;
            this.pnlPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlPlayer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlPlayer1.Location = new System.Drawing.Point(300, 632);
            this.pnlPlayer1.Name = "pnlPlayer1";
            this.pnlPlayer1.Size = new System.Drawing.Size(582, 143);
            this.pnlPlayer1.TabIndex = 16;
            this.FormUiDemoTips.SetToolTip(this.pnlPlayer1, "Click cards to move them to the play area.");
            // 
            // btnPass
            // 
            this.btnPass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPass.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPass.Location = new System.Drawing.Point(43, 577);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(159, 41);
            this.btnPass.TabIndex = 22;
            this.btnPass.Text = "&Pass";
            this.FormUiDemoTips.SetToolTip(this.btnPass, "Exit the application.");
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnTake
            // 
            this.btnTake.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTake.Font = new System.Drawing.Font("Arial", 10F);
            this.btnTake.Location = new System.Drawing.Point(43, 530);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(159, 41);
            this.btnTake.TabIndex = 23;
            this.btnTake.Text = "&Take";
            this.FormUiDemoTips.SetToolTip(this.btnTake, "Exit the application.");
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInstructions,
            this.miSettings});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(1317, 24);
            this.mnuMainMenu.TabIndex = 0;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // miInstructions
            // 
            this.miInstructions.Font = new System.Drawing.Font("Arial", 10F);
            this.miInstructions.Name = "miInstructions";
            this.miInstructions.Size = new System.Drawing.Size(92, 20);
            this.miInstructions.Text = "&Instructions";
            this.miInstructions.ToolTipText = "Information about this program";
            this.miInstructions.Click += new System.EventHandler(this.miInstructions_Click);
            // 
            // miSettings
            // 
            this.miSettings.Font = new System.Drawing.Font("Arial", 10F);
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(111, 20);
            this.miSettings.Text = "Player&Settings";
            this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
            // 
            // lblCardCount
            // 
            this.lblCardCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCount.ForeColor = System.Drawing.Color.White;
            this.lblCardCount.Location = new System.Drawing.Point(96, 351);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(75, 32);
            this.lblCardCount.TabIndex = 1;
            this.lblCardCount.Text = "88";
            this.lblCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Font = new System.Drawing.Font("Arial", 10F);
            this.btnReset.Location = new System.Drawing.Point(591, 582);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(159, 41);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "&New Game";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlAttacker
            // 
            this.pnlAttacker.AllowDrop = true;
            this.pnlAttacker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlAttacker.Location = new System.Drawing.Point(300, 375);
            this.pnlAttacker.Name = "pnlAttacker";
            this.pnlAttacker.Size = new System.Drawing.Size(582, 132);
            this.pnlAttacker.TabIndex = 14;
            // 
            // lblComputer2
            // 
            this.lblComputer2.BackColor = System.Drawing.Color.DarkGreen;
            this.lblComputer2.Font = new System.Drawing.Font("Arial", 25F);
            this.lblComputer2.ForeColor = System.Drawing.Color.White;
            this.lblComputer2.Location = new System.Drawing.Point(300, 181);
            this.lblComputer2.Name = "lblComputer2";
            this.lblComputer2.Size = new System.Drawing.Size(582, 70);
            this.lblComputer2.TabIndex = 26;
            this.lblComputer2.Text = "Player 2";
            this.lblComputer2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblComputer2.UseCompatibleTextRendering = true;
            // 
            // pnlDefender
            // 
            this.pnlDefender.AllowDrop = true;
            this.pnlDefender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlDefender.Location = new System.Drawing.Point(300, 482);
            this.pnlDefender.Name = "pnlDefender";
            this.pnlDefender.Size = new System.Drawing.Size(582, 132);
            this.pnlDefender.TabIndex = 15;
            // 
            // lblWinner
            // 
            this.lblWinner.BackColor = System.Drawing.Color.DarkRed;
            this.lblWinner.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.White;
            this.lblWinner.Location = new System.Drawing.Point(0, 138);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(1317, 396);
            this.lblWinner.TabIndex = 29;
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFeed
            // 
            this.txtFeed.BackColor = System.Drawing.Color.Gray;
            this.txtFeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFeed.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFeed.ForeColor = System.Drawing.Color.Maroon;
            this.txtFeed.Location = new System.Drawing.Point(926, 181);
            this.txtFeed.Name = "txtFeed";
            this.txtFeed.ReadOnly = true;
            this.txtFeed.Size = new System.Drawing.Size(364, 649);
            this.txtFeed.TabIndex = 30;
            this.txtFeed.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1316, 129);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // lblPlayer
            // 
            this.lblPlayer.BackColor = System.Drawing.Color.DarkGreen;
            this.lblPlayer.Font = new System.Drawing.Font("Arial", 25F);
            this.lblPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPlayer.Location = new System.Drawing.Point(300, 760);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(582, 56);
            this.lblPlayer.TabIndex = 28;
            this.lblPlayer.Text = "Attacker";
            this.lblPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPlayer.UseCompatibleTextRendering = true;
            // 
            // pnlWinner
            // 
            this.pnlWinner.BackColor = System.Drawing.Color.Transparent;
            this.pnlWinner.Controls.Add(this.btnReset);
            this.pnlWinner.Controls.Add(this.lblWinner);
            this.pnlWinner.Location = new System.Drawing.Point(0, 152);
            this.pnlWinner.Name = "pnlWinner";
            this.pnlWinner.Size = new System.Drawing.Size(1317, 708);
            this.pnlWinner.TabIndex = 32;
            // 
            // cbTrump
            // 
            this.cbTrump.CardOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cbTrump.FaceUp = false;
            this.cbTrump.Location = new System.Drawing.Point(124, 405);
            this.cbTrump.Name = "cbTrump";
            this.cbTrump.Rank = CardLibrary.Rank.Ace;
            this.cbTrump.Size = new System.Drawing.Size(107, 75);
            this.cbTrump.Suit = CardLibrary.Suit.Heart;
            this.cbTrump.TabIndex = 27;
            // 
            // lblComputerRecord
            // 
            this.lblComputerRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblComputerRecord.Font = new System.Drawing.Font("Arial", 10F);
            this.lblComputerRecord.ForeColor = System.Drawing.Color.White;
            this.lblComputerRecord.Location = new System.Drawing.Point(300, 181);
            this.lblComputerRecord.Name = "lblComputerRecord";
            this.lblComputerRecord.Size = new System.Drawing.Size(582, 25);
            this.lblComputerRecord.TabIndex = 33;
            this.lblComputerRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblComputerRecord.UseCompatibleTextRendering = true;
            // 
            // lblPlayerRecord
            // 
            this.lblPlayerRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerRecord.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPlayerRecord.ForeColor = System.Drawing.Color.White;
            this.lblPlayerRecord.Location = new System.Drawing.Point(300, 805);
            this.lblPlayerRecord.Name = "lblPlayerRecord";
            this.lblPlayerRecord.Size = new System.Drawing.Size(582, 25);
            this.lblPlayerRecord.TabIndex = 34;
            this.lblPlayerRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayerRecord.UseCompatibleTextRendering = true;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(1317, 855);
            this.Controls.Add(this.pnlWinner);
            this.Controls.Add(this.lblPlayerRecord);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblComputerRecord);
            this.Controls.Add(this.pnlAttacker);
            this.Controls.Add(this.pnlDefender);
            this.Controls.Add(this.lblComputer2);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.pnlPlayer2);
            this.Controls.Add(this.pnlPlayer1);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.lblCardCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.mnuMainMenu);
            this.Controls.Add(this.cbTrump);
            this.Controls.Add(this.txtFeed);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlWinner.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip FormUiDemoTips;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem miInstructions;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Label lblCardCount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Panel pnlAttacker;
        private System.Windows.Forms.Panel pnlPlayer1;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Label lblComputer2;
        private System.Windows.Forms.Panel pnlDefender;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.RichTextBox txtFeed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Panel pnlWinner;
        private CardBox.ACardBox cbTrump;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.Label lblComputerRecord;
        private System.Windows.Forms.Label lblPlayerRecord;
    }
}

