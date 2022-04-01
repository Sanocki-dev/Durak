/**
 * MainForm.cs - The main form for the Durak Card game
 * 
 * This form will be acting as the hub for the durak card game between a
 * human player and a computer.
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

using CardBox;
using CardLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DurakUI
{

    public partial class frmMainForm : Form
    {
        #region FIELDS AND PROPERTIES

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 25;

        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>
        static private Size regularSize = new Size(75, 107);

        /// <summary>
        /// Used to generate Card objects from a Deck
        /// </summary>
        private Deck myDealer = null;

        /// <summary>
        /// Instructions form.
        /// </summary>
        private frmInstructions instructionsForm;

        /// <summary>
        /// Settings form.
        /// </summary>
        private frmPlayerSettings settingsForm;

        /// <summary>
        /// Refers to what turn is currently being played
        /// </summary>
        private int currentRound = 0;

        /// <summary>
        /// Refers to the players status of being the defender
        /// </summary>
        private bool isDefender = false;

        /// <summary>
        /// Refers to the players status of being the current player 
        /// </summary>
        private bool isPlaying = true;

        /// <summary>
        /// References the two player areas
        /// </summary>
        Panel[] playerArea = new Panel[2];

        /// <summary>
        /// References the list of ranks that will be played 
        /// </summary>
        private List<Rank> playedRanks = new List<Rank>();

        /// <summary>
        /// A string that will be used to update the log 
        /// </summary>
        private string feedText = "";

        /// <summary>
        /// Players player object that will keep track of wins and loses as well as a name
        /// </summary>
        Player human = new Player();

        /// <summary>
        /// Computers player object that will keep track of wins and loses as well as a name
        /// </summary>
        Player computer = new Player();

        /// <summary>
        /// A bool that will show if the deck being used is a full one or not
        /// </summary>
        private bool isFullDeck;

        #endregion

        #region FORM AND STATIC CONTROL EVENT HANDLERS

        /// <summary>
        /// Constructor for frmMainForm
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calls the method to set up the game
        /// </summary>
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            // Gets player settings 
            PlayerSettings();
            SetupGame();
        }

        /// <summary>
        /// Removes the card back image when the deck is out of cards.
        /// </summary>
        private void myDealer_OutOfCards(object sender, EventArgs e)
        {
            pbDeck.Image = null;
        }

        #endregion

        #region CARD BOX EVENT HANDLERS

        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        private void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            ACardBox aCardBox = sender as ACardBox;
            if (isPlaying && aCardBox.Parent == pnlPlayer1)
            {
                // Checks if the player is the defender 
                if (isDefender && pnlAttacker.Controls.Count != 0)
                {
                    ACardBox playedCard = (ACardBox)pnlAttacker.Controls[currentRound];

                    // Checks if the card box suit matches that of the previously played card
                    if (aCardBox.Suit == playedCard.Suit)
                    {
                        // If it is the same suit is the rank of the hovered card greater than the played one or a trump
                        if (aCardBox.Rank > playedCard.Rank)
                        {
                            // Enlarge the card for visual effect
                            aCardBox.Size = new Size(regularSize.Width, regularSize.Height);
                            // move the card to the top edge of the panel.
                            aCardBox.Top = 0;
                        }
                    }
                    // Otherwise.... Checks if the hovered card is a trump 
                    else if (aCardBox.Suit == Card.trump)
                    {
                        // Enlarge the card for visual effect
                        aCardBox.Size = new Size(regularSize.Width, regularSize.Height);
                        // move the card to the top edge of the panel.
                        aCardBox.Top = 0;
                    }
                }
                // Otherwise.... He is the attacker 
                else
                {
                    // If the conversion worked
                    if (aCardBox != null && playedRanks.Contains(aCardBox.Rank) || currentRound == 0)
                    {

                        // Enlarge the card for visual effect
                        aCardBox.Size = new Size(regularSize.Width, regularSize.Height);
                        // move the card to the top edge of the panel.
                        aCardBox.Top = 0;

                    }
                }
            }
        }

        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        private void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            ACardBox aCardBox = sender as ACardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // resize the card back to regular size
                aCardBox.Size = new Size(regularSize.Width, regularSize.Height);
                // move the card down to accommodate for the smaller size.
                aCardBox.Top = POP;
            }
        }

        /// <summary>
        /// When a CardBox is clicked, move the card to the play area
        /// </summary>
        private void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            ACardBox aCardBox = sender as ACardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // if the card is in the home panel...
                if (aCardBox.Parent == pnlPlayer1 && isPlaying)
                {
                    // Checks if the player is the defender
                    if (isDefender)
                    {
                        // Gets the card played by the attacker
                        ACardBox playedCard = (ACardBox)pnlAttacker.Controls[currentRound];

                        // Checks if the suit of the card clicked matches the suit of the played card or is a trump
                        if ((aCardBox.Suit == playedCard.Suit && aCardBox.Rank > playedCard.Rank) || aCardBox.Suit == Card.trump)
                        {
                            pnlPlayer1.Controls.Remove(aCardBox);   // Remove the card from the home panel
                            pnlDefender.Controls.Add(aCardBox);     // Add the control to the play panel
                            playedRanks.Add(aCardBox.Rank);         // Add the Rank to the list of ranks played

                            // Adds to the log
                            feedText = human.Name + " has played " + aCardBox.ToString() + "." + Environment.NewLine;
                            UpdateFeed(human.aColor, feedText);

                            // Realign the cards 
                            RealignCards(pnlPlayer1);
                            AllignPlayArea(false);


                            // Checks if the player played the last card
                            if (currentRound == 8)
                            {
                                NextBout(true);
                            }
                            // Otherwise.... check if the player has won if true no attack
                            else if (!(WinCheck(pnlPlayer1)))
                            {
                                isPlaying = false;  // Players turn is over
                                ComputerAttacker(); // Computer attacks
                            }
                        }
                        // Otherwise....
                        else
                        {
                            // Displays a message saying the player cannot play the card
                            feedText = human.Name + " cannot play this card." + Environment.NewLine;
                            UpdateFeed(human.aColor, feedText);
                        }
                    }
                    // Otherwise.... Player is the attacker
                    else
                    {
                        // Checks if the cards rank clicked is in the list of played ranks or it is the first turn
                        if ((playedRanks.Contains(aCardBox.Rank) || currentRound == 0))
                        {
                            pnlPlayer1.Controls.Remove(aCardBox);   // Remove the card from the home panel
                            pnlAttacker.Controls.Add(aCardBox);     // Add the control to the play panel
                            playedRanks.Add(aCardBox.Rank);         // Add the Rank to the list of ranks played

                            feedText = human.Name + " has played " + aCardBox.ToString() + "." + pnlAttacker.Controls.Count + Environment.NewLine;
                            UpdateFeed(human.aColor, feedText);

                            // Realign the cards 
                            AllignPlayArea(true);
                            RealignCards(pnlPlayer1);

                            // Checks if the player won 
                            if (!(WinCheck(pnlPlayer1)))
                            {
                                isPlaying = false;  // Players turn is over
                                ComputerDefense();  // Computer defends
                            }
                        }
                        // Otherwise....
                        else
                        {
                            // Displays a message saying the player cannot play the card
                            feedText = human.Name + " cannot play this card." + Environment.NewLine;
                            UpdateFeed(human.aColor, feedText);
                        }
                    }
                }
            }
        }

        #endregion

        #region COMPUTER MOVES

        /// <summary>
        /// Method in which the computer will choose the best card for attacking
        /// </summary>
        private void ComputerAttacker()
        {
            ACardBox playableCard = null;        // Card object to hold the playable card
            Boolean hasPlayableCard = false;     // If the method has found a playable card

            // Goes through each of the cards in the computers hand to find the best card 
            foreach (ACardBox nextCard in pnlPlayer2.Controls)
            {
                // Checks if it is the first attack 
                if (currentRound == 0)
                {
                    // Checks that there isn't a playable card set
                    if (!(hasPlayableCard))
                    {
                        playableCard = nextCard;  // Makes the current card the playable card
                        hasPlayableCard = true;
                    }
                    // If the playableCard is a trump but the new one is not
                    else if (playableCard.Suit == Card.trump && nextCard.Suit != Card.trump)
                    {
                        // Sets the card to the new lowest
                        playableCard = nextCard;
                    }
                    // Otherwise....
                    else
                    {
                        // Checks if the old rank is smaller than the new
                        if (playableCard.Rank > nextCard.Rank)
                        {
                            if (!(nextCard.Suit == Card.trump && playableCard.Suit != Card.trump))
                            {
                                // Sets the card to the new lowest
                                playableCard = nextCard;
                            }
                        }
                    }
                }
                // Otherwise 
                else
                {
                    // If the card rank has already been played
                    if (playedRanks.Contains(nextCard.Rank))
                    {
                        // Checks that there isn't a playable card set
                        if (!(hasPlayableCard))
                        {
                            playableCard = nextCard;  // Makes the current card the playable card
                            hasPlayableCard = true;
                        }
                        // If the playableCard is a trump but the new one is not
                        else if (playableCard.Suit == Card.trump && nextCard.Suit != Card.trump)
                        {
                            // Sets the card to the new lowest
                            playableCard = nextCard;
                        }
                        // Otherwise....
                        else
                        {
                            // Checks if the old rank is smaller than the new
                            if (playableCard.Rank > nextCard.Rank)
                            {
                                if (!(nextCard.Suit == Card.trump && playableCard.Suit != Card.trump))
                                {
                                    // Sets the card to the new lowest
                                    playableCard = nextCard;
                                }
                            }
                        }
                    }
                }
            }

            // Checks if there is a playable card
            if (playableCard != null)
            {
                // Preparing the cardBox for use
                playableCard.FaceUp = true;                           // Makes card face up

                pnlPlayer2.Controls.Remove(playableCard);             // Removes card from the computers hand
                pnlAttacker.Controls.Add(playableCard);               // Adds the card to the play field
                playedRanks.Add(playableCard.Rank);                   // Adds the played card rank to the list of ranks previously played

                // Tells the feed what computer is making a move 
                feedText = computer.Name + " is Attacking with the " + playableCard.ToString() + "." + Environment.NewLine;
                UpdateFeed(computer.aColor, feedText);

                // Realigns the players hand
                RealignCards(pnlPlayer2);

                // Realigns the play area
                AllignPlayArea(true);

                // Sets the variable so player can make a move 
                isPlaying = true;

                // Checks if the computer has won the game
                WinCheck(pnlPlayer2);
            }
            // Otherwise....
            else
            {
                // Defender has won this round
                feedText = human.Name + " has been successful! Cards go to discard pile." + Environment.NewLine;
                UpdateFeed(human.aColor, feedText);
                NextBout(true);
            }
        }

        /// <summary>
        /// Method in which the computer will choose the best card for defense
        /// </summary>
        private void ComputerDefense()
        {
            ACardBox playableCard = null;                                   // Card object to hold the playable card
            Boolean hasPlayableCard = false;                                // If the method has found a playable card
            ACardBox previousCard = (ACardBox)pnlAttacker.Controls[currentRound];   // Gets the last played card value

            // Goes through each of the defenders cards to find a playable one
            foreach (ACardBox newCard in pnlPlayer2.Controls)
            {
                // Checks if the card is the same suit as the previous card 
                if (newCard.Suit == previousCard.Suit)
                {
                    // Checks if the rank of the new card is higher than the played one
                    if (newCard.Rank > previousCard.Rank)
                    {
                        // If there is no low card yet 
                        if (!(hasPlayableCard))
                        {
                            // Assigns the new playable card
                            hasPlayableCard = true;
                            playableCard = newCard;
                        }

                        // Checks if the new cards rank is lower than the previous low or if the previous low was a trump
                        if (newCard.Rank < playableCard.Rank || playableCard.Suit == Card.trump)
                        {
                            // Assigns the new playable card
                            playableCard = newCard;
                        }
                    }
                }
                // Otherwise if the cards suit is a trump
                else if (newCard.Suit == Card.trump)
                {
                    // Checks if there is already a low card
                    if (!(hasPlayableCard))
                    {
                        // Assigns the new playable card
                        playableCard = newCard;
                        hasPlayableCard = true;
                    }

                    // Checks if the new cards rank is lower than the previous cards rank
                    if (newCard.Rank < playableCard.Rank && playableCard.Suit == Card.trump)
                    {
                        // Assigns the new playable card
                        hasPlayableCard = true;
                        playableCard = newCard;
                    }
                }
            }

            // If the computer has a playable card
            if (playableCard != null)
            {
                playableCard.FaceUp = true;                           // Makes card face up

                // Tells the feed what computer is making a move 
                feedText = computer.Name + " is defending with the " + playableCard.ToString() + "." + Environment.NewLine;
                UpdateFeed(computer.aColor, feedText);

                pnlPlayer2.Controls.Remove(playableCard);           // Removes card from the computers hand
                pnlDefender.Controls.Add(playableCard);                   // Adds the card to the play field
                playedRanks.Add(playableCard.Rank);                   // Adds the played card rank to the list of ranks previously played

                // Realigns the players hand
                RealignCards(pnlPlayer2);
                // Realigns the play area
                AllignPlayArea(false);
                isPlaying = true;

                // Checks if the computer has won the game
                WinCheck(pnlPlayer2);

                // Checks if the defender has defended 8 times
                if (currentRound == 6)
                {
                    NextBout(true);
                }
            }
            // Otherwise....
            else
            {
                // Displays the computers move and realigns the play areas 
                feedText = computer.Name + " cannot defend." + Environment.NewLine;
                UpdateFeed(computer.aColor, feedText);

                PickUp(1);

                // Starts the next bout
                NextBout(false);
            }
        }

        #endregion

        #region GAME SETUP

        /// <summary>
        /// A dialog box that will give the player options for the game 
        /// </summary>
        private void PlayerSettings()
        {
            // If the settings form has not been instantiated yet...
            if (settingsForm == null)
            {
                // Instantiate a new settings form
                settingsForm = new frmPlayerSettings();
            }

            // Show the form as a dialog
            if (settingsForm.ShowDialog() == DialogResult.OK || settingsForm.ShowDialog() == DialogResult.Cancel)
            {
                // Sets the new players name and color
                human.aColor = settingsForm.aPlayer.aColor;
                human.Name = settingsForm.aPlayer.Name;
                lblPlayer.BackColor = settingsForm.aPlayer.aColor;
                lblPlayerRecord.Text = human.ToString();

                // Sets the new computers name and color
                computer.aColor = settingsForm.aComputer.aColor;
                computer.Name = settingsForm.aComputer.Name;
                lblComputer2.BackColor = settingsForm.aComputer.aColor;
                lblComputerRecord.Text = computer.ToString();
               // Gets the deck size from the form
               isFullDeck = settingsForm.deckSize;
            }
        }

        /// <summary>
        /// Method that looks in player hands to find the player with the lowest trump card
        /// </summary>
        private void FindLowestTrump()
        {
            // Index of panel that has the lowest trump card
            int hasLowest = 0;
            bool noLow = true;
            // The lowest trump value 
            Card trump = null;

            // Loops until all panels are examined 
            for (int index = 0; index < 2; index++)
            {
                // Goes through each of the cards in the panel 
                foreach (ACardBox cards in playerArea[index].Controls)
                {
                    // If the suit of the card is a trump
                    if (cards.Suit == Card.trump)
                    {
                        // If there was no previous trump found
                        if (noLow)
                        {
                            noLow = false;
                            // Sets the value of the new trump
                            trump = cards.Card;
                            hasLowest = index;
                        }

                        // If the new trump is lower rank than the last
                        if (cards.Rank < trump.Rank)
                        {
                            // Sets the value of the new trump
                            trump = cards.Card;
                            hasLowest = index;
                        }
                    }
                }
            }

            // If there was no trump card in this set
            if (noLow)
            {
                SetupGame();    // Recalls the method until someone has a trump 
            }
            // Otherwise
            else
            {
                // Adds to the feed 
                feedText = (hasLowest == 0 ? human.Name : computer.Name) + " is the attacker." + Environment.NewLine;
                UpdateFeed(Color.White, feedText);
            }

            // Checks if the lowest card belonged to the player
            if (hasLowest == 0)
                isDefender = false; // Player is not the defender
            // Otherwise
            else
                isDefender = true;  // Sets the player as the defender

            SetupForm();

        }

        /// <summary>
        /// Method to setup the game at the beginning
        /// </summary>
        private void SetupGame()
        {
            // Displays the time and date of when the game started 
            txtFeed.Clear();
            feedText = "New game started on " + System.DateTime.Now.ToString() + Environment.NewLine;
            UpdateFeed(Color.White, feedText);
            pnlWinner.Visible = false;

            // Clears the players hands if any where present
            pnlPlayer1.Controls.Clear();
            pnlPlayer2.Controls.Clear();
            pnlAttacker.Controls.Clear();
            pnlDefender.Controls.Clear();

            // Clears anything that may be in the played ranks
            playedRanks.Clear();

            // Resets the round to 0 
            currentRound = 0;

            // Makes the deck depending on the previous settings 
            if (isFullDeck)
            {
                // Creates the dealer with cards from two to high ace
                myDealer = new Deck(Rank.Two, Rank.HighAce, true);
            }
            else
            {
                // Creates the dealer with cards from 6 to high ace
                myDealer = new Deck(Rank.Six, Rank.HighAce, true);
            }

            // Set the deck image to a card back image
            pbDeck.Image = (new Card()).GetCardImage();

            // Wire the out of cards event handler 
            myDealer.LastCardDrawn += myDealer_OutOfCards;
            myDealer.Shuffle();

            // Show the number of cards left in the deck in the deck
            lblCardCount.Text = myDealer.CardsRemaining.ToString();

            // Assigns the playArea their panels
            playerArea[0] = pnlPlayer1;
            playerArea[1] = pnlPlayer2;

            // Deals the cards to all the players
            DealCards();

            // Pulls the next card as the trump card.
            Card trumpCard = myDealer.DrawNextCard();
            Card.trump = trumpCard.Suit;    // Sets the trump suit

            // Displays the trump card under the deck
            cbTrump.Visible = true;
            trumpCard.FaceUp = true;
            cbTrump.Card = trumpCard;

            // Adds to the log showing what the trump was 
            feedText = "Trump card is " + trumpCard.ToString() + "." + Environment.NewLine;
            UpdateFeed(Color.White, feedText);

            // Finds the lowest trump for first player
            FindLowestTrump();
        }


        /// <summary>
        /// This method will change some of the buttons properties and 
        /// text so as the defender you do not have attacker abilities
        /// </summary>
        void SetupForm()
        {
            // Checks if the defender is human
            if (isDefender)
            {
                // Sets the buttons according to the defender status
                btnPass.Enabled = false;
                btnTake.Enabled = true;

                // Sets the labels
                lblPlayer.Text = "DEFENDER";
                lblComputer2.Text = "ATTACKER";
                ComputerAttacker(); // Computer will attack 
            }
            // Otherwise....
            else
            {
                // Sets the buttons according to the defender status
                btnTake.Enabled = false;
                btnPass.Enabled = true;

                // Sets the labels
                lblComputer2.Text = "DEFENDER";
                lblPlayer.Text = "ATTACKER";
                isPlaying = true;   // Player will attack
            }
        }

        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Sets up the next round of durak 
        /// </summary>
        /// <param name="hasDefended">Was the defender successful</param>
        private void NextBout(bool hasDefended)
        {

            // The defender was successful
            if (hasDefended)
            {
                // Played cards go to discard 
                pnlAttacker.Controls.Clear();
                pnlDefender.Controls.Clear();

                // Changes the defender to the other player
                if (isDefender)
                    isDefender = false; // Computer Defender
                else
                    isDefender = true;  // Player Defender
            }
            // Otherwise....
            else
            {
                // Checks if the defender was the player 
                if (isDefender)
                {
                    PickUp(0);              // Player must pick up the cards
                    isDefender = true;      // Keeps the player as the defender
                }
                // Otherwise....
                else
                {
                    PickUp(1);              // Computer must pick up the cards
                    isDefender = false;     // Keeps the computer as the defender
                }
            }

            playedRanks.Clear();    // Clears the list of played ranks 
            FillHands();            // Refills the players hands 
            currentRound = 0;       // Reset the turn counter and times passed 

            feedText = (isDefender ? human.Name : computer.Name) + " is the new defender." + Environment.NewLine;
            UpdateFeed(Color.White, feedText);

            SetupForm();    // Sets up the form for the next bout
        }


        /// <summary>
        /// Checks if the game has a winner 
        /// </summary>
        bool WinCheck(Panel players)
        {
            // Checks if the deck is empty and the play area is also empty
            if (myDealer.CardsRemaining == 0 && players.Controls.Count == 0)
            {
                // Checks if the winner is the player
                if (players.Name == "pnlPlayer1")
                {
                    human.Winner(human, computer);
                    lblWinner.Text = human.Name + " has won Computer is the durak" + Environment.NewLine + human.ToString();
                }
                // Otherwise....
                else
                {
                    computer.Winner(computer, human);
                    lblWinner.Text = computer.Name + " has won you are the durak" + Environment.NewLine + computer.ToString();
                }

                // Disables the buttons for the next round
                pnlWinner.Visible = true;
                btnTake.Enabled = false;
                btnPass.Enabled = false;

                // Has winner return true 
                return true;
            }
            // Otherwise....
            else
            {
                // No winner false
                return false;
            }
        }

        /// <summary>
        /// Method in charge of organizing the play areas cards 
        /// </summary>
        /// <param name="isAttacking"></param>
        private void AllignPlayArea(bool isAttacking)
        {

            // If the card played was for the attacker
            if (isAttacking)
            {
                // Sets the card position
                pnlAttacker.Controls[currentRound].Top = POP;
                pnlAttacker.Controls[currentRound].Left = 55 + (80 * currentRound);
            }
            // Otherwise....
            else
            {
                // Sets the card position
                pnlDefender.Controls[currentRound].Top = POP;
                pnlDefender.Controls[currentRound].Left = 55 + (80 * currentRound);

                // Increments the round 
                currentRound++;
            }

        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;
            string myPanel = panelHand.Name;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                    {
                        offset = cardWidth;
                    }

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;
                }

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }

                // Goes through each card making sure they are horizontal and face down
                for (int card = 0; card < panelHand.Controls.Count; card++)
                {
                    ACardBox cards = (ACardBox)panelHand.Controls[card];
                    cards.CardOrientation = Orientation.Vertical;

                    // Checks which panel is being aligned so that they can be faced properly 
                    if (panelHand.Name != playerArea[0].Name)
                        cards.FaceUp = false;
                    else
                        cards.FaceUp = true;
                }
            }

        }

        /// <summary>
        /// Updates the feed to have the players color and some description of what just happened
        /// </summary>
        /// <param name="color"></param>
        /// <param name="feedText"></param>
        void UpdateFeed(Color color, string feedText)
        {
            txtFeed.SelectionColor = color;
            txtFeed.SelectedText = feedText;
            txtFeed.ScrollToCaret();
        }


        #endregion

        #region DEALING METHODS
        /// <summary>
        /// Deals the appropriate amount of playing cards to each of the people playing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealCards()
        {
            for (int i = 0; i <= 5; i++)
            {
                // Create a new card
                Card[] playerCard = new Card[4];

                // Draw a card from the card dealer. If it worked...
                if (myDealer.CardsRemaining > 0)
                {
                    playerCard[0] = myDealer.DrawNextCard();
                    playerCard[1] = myDealer.DrawNextCard();

                    // Create a new CardBox control based on the card drawn
                    ACardBox[] aPlayerCard = new ACardBox[2];
                    aPlayerCard[0] = new ACardBox(playerCard[0]);
                    aPlayerCard[1] = new ACardBox(playerCard[1]);

                    WireCards(aPlayerCard[0]);

                    // Add the new control to the appropriate panel
                    playerArea[0].Controls.Add(aPlayerCard[0]);
                    playerArea[1].Controls.Add(aPlayerCard[1]);
                }
            }

            // Realign the controls in the panel so they appear correctly.
            RealignCards(pnlPlayer1);
            RealignCards(pnlPlayer2);
            // Display the number of cards remaining in the deck. 
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
        }


        /// <summary>
        /// Fills each of the players hands back to 6 cards 
        /// </summary>
        private void FillHands()
        {
            // Default index of attacker and defender 
            int[] hands = { 0, 1 };

            // If the player was the defender 
            if (isDefender)
            {
                // Changes the index of both
                hands = new[] { 1, 0 };
            }

            // Goes through each of the players 
            for (int index = 0; index < hands.Length; index++)
            {
                // Goes through each hand add one until they have 6 cards starting with the attacker 
                for (int count = playerArea[hands[index]].Controls.Count; count < 6; count++)
                {
                    // Checks if the dealer is out of cards
                    if (myDealer.CardsRemaining != 0)
                    {
                        // Gets the next card in the deck 
                        ACardBox card = new ACardBox(myDealer.DrawNextCard());

                        // Checks if the cards added are for the player
                        if (playerArea[hands[index]].Name == "pnlPlayer1")
                        {
                            // Adds wiring for card events
                            WireCards(card);
                        }

                        // If not adds the cards to the players area to make 6
                        playerArea[hands[index]].Controls.Add(card);
                        RealignCards(playerArea[hands[index]]);
                    }
                    // Checks if the trump card has been dealt
                    else if (cbTrump.Visible == true)
                    {
                        // Creates a new card with the trumps value and assigns it to a cardbox
                        Card trump = new Card(cbTrump.Suit, cbTrump.Rank);
                        ACardBox lastCard = new ACardBox(trump);

                        // Checks if the player is receiving the trump to add events 
                        if (playerArea[hands[index]].Name == "pnlPlayer1")
                            WireCards(lastCard);

                        // Gives the trump card to the player
                        playerArea[hands[index]].Controls.Add(lastCard);
                        RealignCards(playerArea[hands[index]]);

                        // Sets the trump card to null
                        cbTrump.Visible = false;
                    }
                    // Otherwise....
                    else
                    {
                        count = 6;  // Finish the loop
                    }
                }
            }

            // Changes the count of the deck
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
        }

        /// <summary>
        /// A method which will take all the cards out of the play area and put it into someones hand 
        /// </summary>
        /// <param name="defender">Index of person picking up</param>
        private void PickUp(int defender)
        {
            Panel[] playArea = { pnlAttacker, pnlDefender };

            currentRound = 0;   // Resets the round to 0

            // A Card box that will be used to move from one area to the next 
            ACardBox playingCard = null;

            // Goes through each of the two panels 
            for (int index = 0; index < playArea.Length; index++)
            {
                // Goes through each of the cards in the play area 
                for (int card = 0; card < playArea[index].Controls.Count;)
                {
                    // Fills the Card box value
                    playingCard = (ACardBox)playArea[index].Controls[card];

                    // Adds to the feed
                    feedText = (isDefender ? human.Name : computer.Name) + " has picked up " + playingCard.ToString() + Environment.NewLine;
                    UpdateFeed(Color.White, feedText);

                    if (isDefender)
                    {
                        // Adds wiring for card events
                        WireCards(playingCard);
                    }
                    else
                    {
                        // Removes wiring for card events
                        RemoveWire(playingCard);
                    }

                    // Adds the card to the defenders hand
                    pnlAttacker.Controls.Remove(playingCard);
                    playerArea[defender].Controls.Add(playingCard);
                }
            }

            FillHands();

            // Realigns cards for the defender
            RealignCards(playerArea[defender]);
        }

        /// <summary>
        /// Wires the cardbox events for the players cards
        /// </summary>
        /// <param name="card"></param>
        private void WireCards(ACardBox card)
        {
            // Wire CardBox_Click
            card.Click += CardBox_Click;
            card.MouseEnter += CardBox_MouseEnter; // wire CardBox_MouseEnter for the "POP" visual effect
            card.MouseLeave += CardBox_MouseLeave; // wire CardBox_MouseLeave for the regular visual effect
        }

        /// <summary>
        /// Removes the cardbox wiring whenever the card leaves the players hand
        /// </summary>
        /// <param name="card"></param>
        private void RemoveWire(ACardBox card)
        {
            // Wire CardBox_Click
            card.Click -= CardBox_Click;
            card.MouseEnter -= CardBox_MouseEnter; // wire CardBox_MouseEnter for the "POP" visual effect
            card.MouseLeave -= CardBox_MouseLeave; // wire CardBox_MouseLeave for the regular visual effect
        }

        #endregion

        #region BUTTONS

        /// <summary>
        /// When the player cannot defend the attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTake_Click(object sender, EventArgs e)
        {
            // Makes the player pick up 
            NextBout(false);
        }

        /// <summary>
        /// When the attacker cannot make a move they can pass 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            // Starts the next bout with the defender being successful
            NextBout(true);
        }

        /// <summary>
        /// Closes the current form.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears the panels and resets the card dealer.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Hides the winner panel
            pnlWinner.Visible = false;
            // Gives the option to edit settings 
            PlayerSettings();
            // Reset the card dealer
            SetupGame();
        }

        /// <summary>
        /// Shows an Instruction dialog.
        /// </summary>
        private void miInstructions_Click(object sender, EventArgs e)
        {

            // If the instructions form has not been instantiated yet...
            if (instructionsForm == null)
            {
                // Instantiate a new instructions form
                instructionsForm = new frmInstructions();
            }
            // Show the form as a dialog
            instructionsForm.ShowDialog();
        }

        /// <summary>
        /// Shows an player settings dialog.
        /// </summary>
        private void miSettings_Click(object sender, EventArgs e)
        {
            // Gets player settings 
            PlayerSettings();
        }

        #endregion

    }
}
