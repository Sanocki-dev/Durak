/**
 * PlayerSettings.cs - This form was created to add some special features for the game.
 * 
 * @author      GROUP 08 
 * @author      Mike Sanocki 
 * @author      Kyle St Amant
 * @author      Giselle Jairam
 * @author      Abdee Seyed Buhary 
 * 
 * @version     4.1
 * @since       April 2020
 */

using CardLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurakUI
{
    public partial class frmPlayerSettings : Form
    {
        /// <summary>
        /// A player object so we can change the human players attributes
        /// </summary>
        private Player myPlayer = new Player(Color.Blue, "Player 1");

        /// <summary>
        /// A player object so we can change the computer players attributes
        /// </summary>
        private Player myComputer = new Player(Color.DarkRed, "Player 2");


        public frmPlayerSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used to set and retrieve the human players attributes
        /// </summary>
        public Player aPlayer
        {
            get { return myPlayer; }
            set { myPlayer = value; }
        }

        /// <summary>
        /// Used to set and retrieve the computer players attributes
        /// </summary>
        public Player aComputer
        {
            get { return myComputer; }
            set { myComputer = value; }
        }

        /// <summary>
        /// Returns the selected deck size back to main form 
        /// </summary>
        public bool deckSize
        {
            get
            {
                // Checks which radio button was clicked and returns a bool on whether or not the 
                // full deck will be used 
                if (rdo52Cards.Checked == true)
                    return true;
                else
                    return false;
            }
        }


        /// <summary>
        /// A color panel that 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlComputerColor_Click(object sender, EventArgs e)
        {
            // Creates a color dialog object for selecting a color
            ColorDialog color = new ColorDialog();

            // Shows the color dialog and checks if the user clicked 'OK'
            if (color.ShowDialog() == DialogResult.OK)
            {
                // Sets the panel to the color
                pnlComputerColor.BackColor = color.Color;
                // Changed the preview text color
                lblComputer.ForeColor = color.Color;
                // Sets the computers color 
                myComputer.aColor = color.Color;
            }
        }

        private void pnlPlayerColor_Click(object sender, EventArgs e)
        {
            // Creates a color dialog object for selecting a color
            ColorDialog color = new ColorDialog();

            // Shows the color dialog and checks if the user clicked 'OK'
            if (color.ShowDialog() == DialogResult.OK)
            {
                // Sets the panel to the color
                pnlPlayerColor.BackColor = color.Color;
                // Changed the preview text color
                lblPlayer.ForeColor = color.Color;
                // Sets the computers color
                myPlayer.aColor = color.Color;
            }
        }

        /// <summary>
        /// Checks the text fields before sending the data back to the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Sets up two stings for the players names
            String playerName = txtPlayerName.Text.Trim();
            String computerName = txtComputerName.Text.Trim();


            // Checks if the user entered in a name for the player
            if (playerName.Length != 0)
            {
                // Sets the new name
                myPlayer.Name = playerName;
            }

            // Checks if the user entered in a name for the player
            if (computerName.Length != 0)
            {
                // Sets the new name
                myComputer.Name = computerName;
            }
        }

        /// <summary>
        /// Updates the preview window to show player names and color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlayerName_Leave(object sender, EventArgs e)
        {
            // Checks if the player has entered a name 
            if (txtPlayerName.Text.Trim().Length != 0)
                // Updates the preview
                lblPlayer.Text = txtPlayerName.Text + " has played the 10 of Spade's";
        }

        /// <summary>
        /// Updates the preview window to show player names and color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComputerName_Leave(object sender, EventArgs e)
        {
            // Checks if the player has entered a name 
            if (txtPlayerName.Text.Trim().Length != 0)
                // Updates the preview
                lblComputer.Text = txtComputerName.Text + " has played the King of Spade's";
        }
    }
}