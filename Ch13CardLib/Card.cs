/*
 *  Card.cs - Creates instances of playing card object with rank and suit attributes
 * 
 *  @author      GROUP 08 
 *  @author      Mike Sanocki 
 *  @author      Kyle St Amant
 *  @author      Giselle Jairam
 *  @author      Abdee Seyed Buhary 
 * 
 *  @version     4.0
 *  @since       April 2020
 */

using System;
using System.Drawing;

namespace CardLibrary
{
    /// <summary>
    /// A card class which has the attributes of a playing card
    /// </summary>
    public class Card : ICloneable
    {
        // Two public properties of a playing card set to read-only
        protected Rank myRank;
        protected Suit mySuit;
        protected bool faceUp = false;

        /// <summary>
        /// Constructor - Sets the playing cards suit and rank
        /// </summary>
        /// <param name="newSuit">Playing cards suit</param>
        /// <param name="newRank">Playing cards rank</param>
        public Card(Suit newSuit = Suit.Heart , Rank newRank = Rank.Ace)
        {
            mySuit = newSuit;
            myRank = newRank;
        }

        /// <summary>
        /// Default constructor which doesn't do anything 
        /// </summary>
        private Card()
        {
        }

        /// <summary>
        /// Accessor for playing card suit
        /// </summary>
        public Suit Suit
        {
            get
            {
                return mySuit;
            }
            set
            {
                mySuit = value;
            }
        }
        
        /// <summary>
        /// Accessor for playing card rank
        /// </summary>
        public Rank Rank
        {
            get
            {
                return myRank;
            }
            set
            {
                myRank = value;
            }
        }

        /// <summary>
        /// Accessor for the playing card face up status 
        /// </summary>
        public bool FaceUp
        {
            get
            {
                return faceUp;
            }
            set
            {
                faceUp = value;
            }
        }

        /// <summary>
        /// To string which displays the playing cards information 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Checks if the card is face up
            if (faceUp)
            {
                // Display the rank and suit
                return "The " + myRank + " of " + mySuit + "'s";
            }
            // Otherwise it is face down
            else
            {
                return "Face Down";
            }
        }

        /// <summary>
        /// Shallow copy of the Card objects
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Flag for the trump usage. If true, trumps are values higher than cards of other suits
        /// </summary>
        public static bool useTrumps = false;

        /// <summary>
        /// Trump suit to use if useTrumps is true
        /// </summary>
        public static Suit trump = Suit.Club;

        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;

        /// <summary>
        /// Overrides the == operator to check if the suits and rank of a card match
        /// </summary>
        /// <param name="card1">First card</param>
        /// <param name="card2">Second card to compare</param>
        /// <returns>Boolean if the cards are the same or not</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.Suit == card2.Suit) && (card1.Rank == card2.Rank);
        }

        /// <summary>
        /// Overrides the != operator to check if the suits and rank of a card are different
        /// </summary>
        /// <param name="card1">First card</param>
        /// <param name="card2">Second card to compare</param>
        /// <returns>Boolean stating if the cards match</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        /// <summary>
        /// Overrides the Equals() operator to check if the suits and rank of a card are the same
        /// </summary>
        /// <param name="card">The card that you want to see is equal</param>
        /// <returns>Boolean stating if the cards are equal</returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        /// <summary>
        /// Overrides the GetHashCode() operator giving it a new value 
        /// </summary>
        /// <returns>The new hashCode value</returns>
        public override int GetHashCode()
        {
            return (int)Rank * 100 + (int)Suit *10 + ((faceUp)?1:0);
        }

        /// <summary>
        /// Overrides the > operator using the trump, suit or rank
        /// </summary>
        /// <param name="card1">First card</param>
        /// <param name="card2">Second card to compare</param>
        /// <returns>Boolean stating if the first card is > than the other</returns>
        public static bool operator >(Card card1, Card card2)
        {
            // If the suits match then find out which is higher otherwise
            if (card1.Suit == card2.Suit)
            {
                // Checks if ace is considered a high card 
                if (isAceHigh)
                {
                    // Checks if the first cards rank is ace
                    if (card1.Rank == Rank.Ace)
                    {
                        // Checks if the seconds card value is an ace
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else // Otherwise 
                    {
                        // Checks if the second card is an ace
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else // Otherwise compare the rank integer value
                            return (card1.Rank > card2.Rank);
                    }
                }
                else // Otherwise just compares the Rank integer value
                {
                    return (card1.Rank > card2.Rank);
                }
            }
            else // Otherwise check if one of them is a trump 
            {
                // Checks if trumps are being used and the second card isnt a trump card
                if (useTrumps && (card2.Suit == Card.trump))
                {
                    return false;
                }
                // Otherwise ...
                else
                {
                    // Checks if ace is high and the rank of the first card is an ace
                    if (isAceHigh && card1.Rank == Rank.Ace)
                    {
                        // Checks if the seconds card value is also ace
                        if (card2.Rank == Rank.Ace)
                            return (card1.Rank > card2.Rank);
                        else // Otherwise first card is higher
                            return true;
                    }
                    // Otherwise checks the ranks 
                    else
                    {
                        // Checks if the second card is an ace
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else // Otherwise compare the rank integer value
                            return (card1.Rank > card2.Rank);
                    }
                }
            }
        }

        /// <summary>
        /// Overrides the < operator using the trump, suit or rank
        /// </summary>
        /// <param name="card1">First card</param>
        /// <param name="card2">Compare Card</param>
        /// <returns>Boolean stating if the first card is < than the other </returns>
        public static bool operator <(Card card1, Card card2)
        {
            // Uses the > operator just opposite
            return !(card1 >= card2);
        }

        /// <summary>
        /// Overrides the >= operator using the trump, suit or rank
        /// </summary>
        /// <param name="card1">First card</param>
        /// <param name="card2">Compare Card</param>
        /// <returns>Boolean stating if the first card is >= than the other </returns>
        public static bool operator >=(Card card1, Card card2)
        {
            // If the suits match then find out which is higher otherwise
            if (card1.Suit == card2.Suit)
            {
                // Checks if ace is considered a high card 
                if (isAceHigh)
                {
                    // Checks if the first card value is an ace
                    if (card1.Rank == Rank.Ace)
                    {
                        return true;
                    }
                    else // Otherwise
                    {
                        // Checks if the seconds card value is an ace
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else // Otherwise compare the ranks value
                            return (card1.Rank >= card2.Rank);
                    }
                }
                else // Otherwise compare the rank values
                {
                    return (card1.Rank >= card2.Rank);
                }
            }
            else // Otherwise 
            {
                // Check if the card is a trump card
                if (useTrumps && (card2.Suit == Card.trump))
                    return false;
                else // Otherwise
                {
                    // Checks if the first card value is an ace
                    if (card1.Rank == Rank.Ace && isAceHigh)
                    {
                        // Checks if the seconds card value is an ace
                        if (card2.Rank == Rank.Ace)
                            return true;
                        else // Otherwise compare the ranks value
                            return (card1.Rank >= card2.Rank);
                    }
                    else
                    {
                        // Checks if the seconds card value is an ace
                        if (card2.Rank == Rank.Ace)
                            return false;
                        else // Otherwise compare the ranks value
                            return (card1.Rank >= card2.Rank);
                    }
                }
            }
        }

        /// <summary>
        /// Overrides the <= operator using the trump, suit or rank
        /// </summary>
        /// <param name="card1">First card</param>
        /// <param name="card2">Compare Card</param>
        /// <returns>Boolean stating if the first card is <= than the other </returns>
        public static bool operator <=(Card card1, Card card2)
        {
            // Just uses the inverse of the >= operator 
            return !(card1 > card2);
        }

		/// <summary>
		/// Gets the image associated with the card from the resource file 
		/// </summary>
		/// <returns>An image corresponding to the playing card</returns>
		public Image GetCardImage()
		{
			string imageName;   // The name of the image in the resource file
			Image cardImage;    // Holds the image

            // If the card is not face up
            if (!faceUp)
            {
                // Set image to the "Back"
                imageName = "Back";
            }
            else // Otherwise the card is face up
            {
			    // Sets the image name to Suit_Rank
			    imageName = mySuit.ToString() + "_" + myRank.ToString();
            }
			// Sets the image to the appropriate object we get from the resource file
			cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;

			return cardImage;
		}
    }
}