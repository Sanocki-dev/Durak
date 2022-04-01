/**
 * MainForm.cs - The MainForm of the FormUIDemo Project
 * 
 * This project demonstrates adding and removing form controls dynamically. It also shows
 * relocating controls by clicking and by dragging. 
 *  
 * @author      Thom MacDonald <thom.macdonald@durhamcollege.ca>
 * @version     2.0
 * @since       2018-03-23
 * @see         <video link>
 */


/** IMAGE ATTRIBUTION
*   ==================
*   Original playing card images created by Byron Knowll 
*   (http://byronknoll.blogspot.ca/2011/03/vector-playing-cards.html) and released into the 
*   public domain. Downloaded on 23 March 2018 from 
*   https://code.google.com/archive/p/vector-playing-cards/
*   
*   Original card back image created by Michael Schwarzenberger 
*   (https://pixabay.com/en/users/blickpixel-52945/) and released under Creative Commons 
*   CC0 (https://creativecommons.org/publicdomain/zero/1.0/deed.en). Downloaded on 23 March 2018 
*   from https://pixabay.com/en/playing-card-back-pattern-568200/ 
*/

using MyCardBox;
using DemoCardsLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormUIDemo
{

    public partial class frmMainForm : Form
    {
        #region FIELDS AND PROPERTIES

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        //private const int POP = 25;
        
        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>
        //static private Size regularSize = new Size(75, 107);

        /// <summary>
        /// Used to generate PlayingCard objects from a Deck
        /// </summary>
        private CardDealer myDealer = new CardDealer(new Deck(false));

        /// <summary>
        /// About form.
        /// </summary>
        private frmAboutForm aboutForm;

        /// <summary>
        /// Refers to the card being dragged from one panel to another.
        /// </summary>
        //private CardBox dragCard;

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
        /// Initializes the card dealer/deck on form Load.
        /// </summary>
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            // Set the deck image to a card back image
            pbDeck.Image = (new PlayingCard()).GetCardImage();
            // Wire the out of cards event handler 
            myDealer.OutOfCards += myDealer_OutOfCards;
            // Show the number of cards in the deck
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
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
            // Reset the card dealer
            ResetDealer();

            // Set option back to click
            optClick.Checked = true;
        }

        /// <summary>
        /// Resets the card dealer when the options are changed.
        /// </summary>
        private void optClick_CheckedChanged(object sender, EventArgs e)
        {
            ResetDealer();
        }

        /// <summary>
        /// Shows an About dialog.
        /// </summary>
        private void miAbout_Click(object sender, EventArgs e)
        {

            // If the About form has not been instantiated yet...
            if (aboutForm == null)
            {
                // Instantiate a new About form
                aboutForm = new frmAboutForm();
            }
            // Show the form as a dialog
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Deal a card or reset the deck on clicking the deck.
        /// </summary>
        private void pbDeck_Click(object sender, EventArgs e)
        {
            
            // If the deck is empty (no image)
            if (pbDeck.Image == null)
            {
                ResetDealer(); 
            }
            else
            {
                //PlayingCard card = new PlayingCard();
                //if (myDealer.DrawCard(ref card, true))
                //{
                //    // Create a new CardBox control based on the card drawn
                //    //CardBox aCardBox = new CardBox(card);

                //    // Wire events handlers to the new control
                //    if (optClick.Checked)
                //    {
                //        //aCardBox.Click += CardBox_Click; // Click to move
                //    }
                //    else
                //    {
                //        //aCardBox.MouseDown += CardBox_MouseDown; // Drag to move
                //        //aCardBox.DragEnter += CardBox_DragEnter; // Drag over a card
                //        //aCardBox.DragDrop += CardBox_DragDrop;   // Drop on a card
                //    }

                //    //aCardBox.MouseEnter += CardBox_MouseEnter; // "POP" visual effect
                //    //aCardBox.MouseLeave += CardBox_MouseLeave; // Regular visual effect

                //    //Add the new control to the appropriate panel
                //    //pnlCardHome.Controls.Add(aCardBox);
                //    //Realign the controls in the panel so they appear correctly.
                //    //RealignCards(pnlCardHome);
                //}
            }
            // Display the number of cards remaining in the deck. 
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
        }

        /// <summary>
        /// Removes the card back image when the deck is out of cards.
        /// </summary>
        private void myDealer_OutOfCards(object sender, EventArgs e)
        {
            pbDeck.Image = null;
        }

        /// <summary>
        /// Make the mouse pointer a "move" pointer when a drag enters a Panel.
        /// </summary>
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            // Make the mouse pointer a "move" pointer
            //e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// Move a card/control when it is dropped from one Panel to another.
        /// </summary>
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            //// If there is a CardBox to move
            //if (dragCard != null)
            //{
            //    // Determine which Panel is which
            //    Panel thisPanel = sender as Panel;
            //    Panel fromPanel = dragCard.Parent as Panel;

            //    // If neither panel is null (no conversion issue)
            //    if (thisPanel != null && fromPanel != null)
            //    {
            //        // if the Panels are not the same 
            //        // (this would happen if a card is dragged from one spot in the Panel to another)
            //        if (thisPanel != fromPanel)
            //        {
            //            // Remove the card from the Panel it started in
            //            fromPanel.Controls.Remove(dragCard);
            //            // Add the card to the Panel it was dropped in 
            //            thisPanel.Controls.Add(dragCard);
            //            // Realign cards in both Panels
            //            RealignCards(thisPanel);
            //            RealignCards(fromPanel);
            //        }
            //    }
            //}
        }

        #endregion

        #region CARD BOX EVENT HANDLERS

        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {
            //// Convert sender to a CardBox
            //CardBox aCardBox = sender as CardBox;
            //// If the conversion worked
            //if (aCardBox != null)
            //{
            //    // Enlarge the card for visual effect
            //    aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);
            //    // move the card to the top edge of the panel.
            //    aCardBox.Top = 0;
            //}
        }

        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            //// Convert sender to a CardBox
            //CardBox aCardBox = sender as CardBox;
            //// If the conversion worked
            //if (aCardBox != null)
            //{
            //    // resize the card back to regular size
            //    aCardBox.Size = regularSize;
            //    // move the card down to accommodate for the smaller size.
            //    aCardBox.Top = POP;
            //}
        }

        /// <summary>
        /// Initiate a card move on the start of a drag.
        /// </summary>
        private void CardBox_MouseDown(object sender, MouseEventArgs e)
        {
            //// Set dragCard 
            //dragCard = sender as CardBox;
            //// If the conversion worked
            //if (dragCard != null)
            //{
            //    // Set the data to be dragged and the allowed effect dragging will have.
            //    DoDragDrop(dragCard, DragDropEffects.Move);
            //}
        }

        /// <summary>
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            //// Convert sender to a CardBox
            //MyCardBox.CardBox aCardBox = sender as MyCardBox.CardBox;

            //// If the conversion worked
            //if (aCardBox != null)
            //{
            //    if (aCardBox.Parent == pnlCardHome)
            //    {
            //        // Remove the card from the home panel
            //        pnlCardHome.Controls.Remove(aCardBox);
            //        // Add the control to the play panel
            //        pnlPlay.Controls.Add(aCardBox);
            //    }
            //    else
            //    {
            //        // Remove the card from the play panel
            //        pnlPlay.Controls.Remove(aCardBox);
            //        // Add the control to the home panel
            //        pnlCardHome.Controls.Add(aCardBox);
            //    }

            //    // Realign the cards 
            //    RealignCards(pnlPlay);
            //    RealignCards(pnlCardHome);
            //}
        }

        /// <summary>
        /// When a drag is enters a card, enter the parent panel instead.
        /// </summary>
        private void CardBox_DragEnter(object sender, DragEventArgs e)
        {
            //// Convert sender to a CardBox
            //MyCardBox.CardBox aCardBox = sender as MyCardBox.CardBox;

            //// If the conversion worked
            //if (aCardBox != null)
            //{
            //    // Do the operation on the parent panel instead
            //    Panel_DragEnter(aCardBox.Parent, e);
            //}
        }

        /// <summary>
        /// When a drag is dropped on a card, drop on the parent panel instead.
        /// </summary>
        private void CardBox_DragDrop(object sender, DragEventArgs e)
        {
            //// Convert sender to a CardBox
            //MyCardBox.CardBox aCardBox = sender as MyCardBox.CardBox;

            //// If the conversion worked
            //if (aCardBox != null)
            //{
            //    // Do the operation on the parent panel instead
            //    Panel_DragDrop(aCardBox.Parent, e);
            //}
        }

        #endregion

        #region HELPER METHODS
        
        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            //// Determine the number of cards/controls in the panel.
            //int myCount = panelHand.Controls.Count;

            //// If there are any cards in the panel
            //if (myCount > 0)
            //{
            //    // Determine how wide one card/control is.
            //    int cardWidth = panelHand.Controls[0].Width;

            //    // Determine where the left-hand edge of a card/control placed 
            //    // in the middle of the panel should be  
            //    int startPoint = (panelHand.Width - cardWidth) / 2;

            //    // An offset for the remaining cards
            //    int offset = 0;

            //    // If there are more than one cards/controls in the panel
            //    if (myCount > 1)
            //    {
            //        // Determine what the offset should be for each card based on the 
            //        // space available and the number of card/controls
            //        offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);

            //        // If the offset is bigger than the card/control width, i.e. there is lots of room, 
            //        // set the offset to the card width. The cards/controls will not overlap at all.
            //        if (offset > cardWidth)
            //            offset = cardWidth;

            //        // Determine width of all the cards/controls 
            //        int allCardsWidth = (myCount - 1) * offset + cardWidth;

            //        // Set the start point to where the left-hand edge of the "first" card should be.
            //        startPoint = (panelHand.Width - allCardsWidth) / 2;
            //    }

            //    // Aligning the cards: Note that I align them in reserve order from how they
            //    // are stored in the controls collection. This is so that cards on the left 
            //    // appear underneath cards to the right. This allows the user to see the rank
            //    // and suit more easily.

            //    // Align the "first" card (which is the last control in the collection)
            //    panelHand.Controls[myCount - 1].Top = POP;
            //    System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
            //    panelHand.Controls[myCount - 1].Left = startPoint;

            //    // for each of the remaining controls, in reverse order.
            //    for (int index = myCount - 2; index >= 0; index--)
            //    {
            //        // Align the current card
            //        panelHand.Controls[index].Top = POP;
            //        panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
            //    }
            //}

        }

        /// <summary>
        /// Clears the panels and reloads the deck.
        /// </summary>
        void ResetDealer()
        {
            // Clear the panels
            pnlCardHome.Controls.Clear();
            pnlPlay.Controls.Clear();

            // Load the card dealer 
            myDealer.LoadCardDealer();

            // Set the image to a card back
            pbDeck.Image = (new PlayingCard()).GetCardImage();

            // Display the number of cards remaining in the deck. 
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
        }
        #endregion

    }
}
