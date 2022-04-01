/*
 *  Player.cs - Creates a Player object that will keep track of their name, wins, losses and a color 
 * 
 *  @author      GROUP 08 
 *  @author      Mike Sanocki 
 *  @author      Kyle St Amant
 *  @author      Giselle Jairam
 *  @author      Abdee Seyed Buhary 
 *  
 *  @version     4.0
 *  @since       April 2020
 * 
 */

using System;
using System.Drawing;

namespace CardLibrary
{
    /// <summary>
    /// A player class that will keep track of player wins and loses as
    /// well as some basic information about the player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// A count of the amount of loses
        /// </summary>
        private int myLossCount;

        /// <summary>
        /// A count of the amount of wins
        /// </summary>
        private int myWinCount;

        /// <summary>
        /// A string to hold the players name
        /// </summary>
        private String myName;

        /// <summary>
        /// A Color that will be shown to represent the player 
        /// </summary>
        private Color myColor;

        /// <summary>
        /// A integer to hold the number of current players will be used
        /// for naming computers 
        /// </summary>
        private static int playerCount = 1;

        /// <summary>
        /// CTOR - sets the default values for the player 
        /// </summary>
        public Player()
        {
            myLossCount = 0;
            myWinCount = 0;
            myColor = Color.Black;
            myName = "Player " + playerCount++;
        }

        /// <summary>
        /// CTOR - sets custom player attributes 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="name"></param>
        public Player(Color aColor, String name)
        {
            myLossCount = 0;
            myWinCount = 0;
            myColor = aColor;
            myName = name;
        }

        /// <summary>
        /// Returns and sets the players name
        /// </summary>
        public String Name
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }

        /// <summary>
        /// Returns and sets the players text color
        /// </summary>
        public Color aColor
        {
            get
            {
                return myColor;
            }
            set
            {
                myColor = value;
            }
        }

        /// <summary>
        /// Returns and sets the players win count
        /// </summary>
        public int Wins
        {
            get
            {
                return myWinCount;
            }
            set
            {
                myWinCount = value;
            }
        }

        /// <summary>
        /// Returns and sets the players loss count
        /// </summary>
        public int Loss
        {
            get
            {
                return myLossCount;
            }
            set
            {
                myLossCount = value;
            }
        }

        /// <summary>
        /// If there is a winner the winner will get a point added for win count and 
        /// every other player will get a loss 
        /// </summary>
        /// <param name="winner"></param>
        public void Winner(Player winner, Player loser)
        {
            winner.Wins += 1;
            loser.Loss += 1;
        }

        /// <summary>
        /// To string which displays the players information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Display the rank and suit
            return myName + " has a W/L record of " + myWinCount + "/" + myLossCount;
        }

    }
}
