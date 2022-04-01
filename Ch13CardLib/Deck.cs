/*
 *  Deck.cs - Creates a Deck instances and is contains mutators to shuffle and accessors to get Class Card objects
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
using System.Linq;

namespace CardLibrary
{
    public class Deck : ICloneable
    {
        /// <summary>
        /// EventHandler for when the last card is drawn
        /// </summary>
        public event EventHandler LastCardDrawn;

        /// <summary>
        /// A static integer that keeps track of the current index of card
        /// </summary>
        private int currentCard = 0;

        /// <summary>
        /// A static integer that keeps track of the number of cards in the deck 
        /// </summary>
        private static int deckCount;

        /// <summary>
        /// A new collection of cards for the deck 
        /// </summary>
        private Cards cards = new Cards();

        /// <summary>
        /// Constructor that will create and assign the 52 cards in a deck.
        /// </summary>
        public Deck()
        {
            currentCard = 0;
            // Gets each suit
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                // Gets each rank 
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    // Sets the cards value 
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
            deckCount = cards.Count();
        }

        /// <summary>
        /// Returns a cards values 
        /// </summary>
        public Card Card
        {
            get
            {
                return Card;
            }
        }

        /// <summary>
        /// Returns amount of cards left in deck
        /// </summary>
        public int CardsRemaining
        {
            get
            {
                return deckCount - currentCard;
            }
        }

        /// <summary>
        /// Accessor for getting a card from the deck using an index
        /// </summary>
        /// <param name="cardNum">The index of the card request</param>
        /// <returns>The rank and suit of the card</returns>
        public Card GetCard(int cardNum)
        {

            // Checks if the index is within the range
            if (cardNum >= 0 && cardNum <= deckCount)
            {
                // Checks if the card is currently the last one and there is an event called LastCardDrawn 
                if ((cardNum == deckCount) && (LastCardDrawn != null))
                {
                    // Call the event handler defined for picking up the last card
                    LastCardDrawn(this, EventArgs.Empty); 
                }
                // Returns a the card
                return cards[cardNum];
            }
            // Otherwise throw an exception
            else
            {
                // Throws the new specific out of range exception 
                throw (new CardOutOfRangeException(cards.Clone() as Cards)); 
            }
        }

        /// <summary>
        /// Accessor for getting the next card from the deck
        /// </summary>
        /// <returns>The rank and suit of the card</returns>
        public Card DrawNextCard()
        {
            // Checks if the index is within the range
            if (CardsRemaining > 0)
            {
                // Checks if the card is currently the last one and there is an event called LastCardDrawn 
                if (CardsRemaining == 1 && (LastCardDrawn != null))
                {
                    // Call the event handler defined for picking up the last card
                    LastCardDrawn(this, EventArgs.Empty);
                }
                // Returns a the card
                return cards[currentCard++];
            }
            // Otherwise throw an exception
            else
            {
                // Throws the new specific out of range exception 
                throw (new CardOutOfRangeException(cards.Clone() as Cards));
            }
        }

        /// <summary>
        /// Shuffle all cards array index value
        /// </summary>
        public void Shuffle()
        {
            // Creates a new deck of cards
            Cards newDeck = new Cards();
            // An array of bools which show if the card has already been moved
            bool[] assigned = new bool[deckCount];

            // Creates a random value so each card is randomly placed
            Random sourceGen = new Random();

            // Goes through the whole deck rearranging its values
            for (int i = 0; i < deckCount; i++)
            {
                int sourceCard = 0;     // Int for cards new index
                bool foundCard = false; // Bool if card was successfully moved 
                
                // Loops until the card is placed
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(deckCount);      // Rand number between 1 and 52 
                    // If the rand number given leads to an card that was already moved it will not replace it
                    if (assigned[sourceCard] == false)    
                        foundCard = true;
                }
                // Sets the bool array so this card is not replaced 
                assigned[sourceCard] = true;
                // Card is added to new deck 
                newDeck.Add(cards[sourceCard]);
            }
            // New deck is copied to old
            newDeck.CopyTo(cards);
        }

        /// <summary>
        /// Deep Copies the deck using a private constructor 
        /// </summary>
        /// <returns>The new deck of cards</returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
        
        /// Private constructor which is only called in the Clone method
        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        /// <summary>
        /// Non-default constructor. Allows aces to be set high.
        /// </summary>
        public Deck(bool isAceHigh) : this()
        {
            currentCard = 0;
            Card.isAceHigh = isAceHigh;
        }
        /// <summary>
        /// Non-default constructor. Allows a trump suit to be used.
        /// </summary>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            currentCard = 0;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Non-default constructor. Allows aces to be set high and a trump suit
        /// to be used.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            currentCard = 0;
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        /// <summary>
        /// CTOR that allows users to select which cards they would like in the deck 
        /// </summary>
        /// <param name="lowest">Lowest desired rank (Ace min)</param>
        /// <param name="highest">Highest desired rank (HighAce max)</param>
        /// <param name="useTrumps">Bool to state if trump cards will be used</param>
        public Deck(Rank lowest, Rank highest, bool useTrumps)
        {
            // Sets the current card back to 0
            currentCard = 0;
            // Gets each suit
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                // Gets each rank 
                for (int rankVal = (int)lowest; rankVal <= (int)highest; rankVal++)
                {
                    // Sets the cards value 
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }

            // Updates the deck size
            deckCount = cards.Count();

            // Sets the trump boolean
            Card.useTrumps = useTrumps;
        }
    }
}