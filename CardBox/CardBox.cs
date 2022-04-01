/**
 *	CardBox.cs -	The CardBox Class
 *	
 *	@author			Thom MacDonald
 *	@author			Mike Sanocki 100532504
 *	@version		1.0
 *	@since			02/2020
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using CardLibrary;

namespace CardBox
{
    /// <summary>
    /// A control to use in a Windows Forms Application that displays a playing card.
    /// </summary>
    public partial class ACardBox : UserControl
    {
        #region FIELDS AND PROPERTIES

        /// <summary>
        /// Card Property:	Sets/Gets the underlying Card object.
        /// </summary>
        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                UpdateCardImage();      // Updates the card image
            }
            get
            {
                return myCard;
            }
        }

        /// <summary>
        /// Suit Property:	Sets/Gets the underlying Card object's Suit.
        /// </summary>
        public Suit Suit
        {
            set
            {
                myCard.Suit = value;
                UpdateCardImage();      // Updates the card image
            }
            get
            {
                return myCard.Suit;
            }
        }

        /// <summary>
        /// Rank Property:	Sets/Gets the underlying Card object's Rank.
        /// </summary>
        public Rank Rank
        {
            set
            {
                myCard.Rank = value;
                UpdateCardImage();      // Updates the card image
            }
            get
            {
                return myCard.Rank;
            }
        }

        /// <summary>
        /// FaceUp Property: Sets/Gets the underlying Card object's faceUp Property.
        /// </summary>
        public bool FaceUp
        {
            set
            {
                // If value is different than the underlying card's FaceUp property
                if (myCard.FaceUp != value) // Then the card is flipping over
                {
                    myCard.FaceUp = value;  // Change the card's FaceUp property
                    UpdateCardImage();      // Updates the card image

                    // If there is an event handler for CardFlipping in the client program
                    if (CardFlipped != null)
                        CardFlipped(this, new EventArgs()); // Call it
                }
            }
            get
            {
                return Card.FaceUp;
            }
        }

        /// <summary>
        /// CardOrientation Property: Sets/Gets the Orientation of the card. If setting this property 
        /// changes the state of control, swaps the height and width of the control and updates the image
        /// </summary>
        private Orientation myOrientation;
        public Orientation CardOrientation
        {
            set
            {
                // If value is different than myOrientation
                if (myOrientation != value)
                {
                    myOrientation = value;  // Change the orientation
                                            // Swap the height and width of the control
                    this.Size = new Size(Size.Height, Size.Width);
                    // Update the card image.
                    UpdateCardImage();
                }
            }
            get
            {
                return myOrientation;
            }
        }

        /// <summary>
        /// UpdateCardImage Helper Method: sets the PictureBox image using the underlying card and the orientation.
        /// </summary>
        private void UpdateCardImage()
        {
            // Set the image using the underlying card.
            pbMyPictureBox.Image = myCard.GetCardImage();

            // If the orientation is horizontal.
            if (myOrientation == Orientation.Horizontal)
            {
                // Rotate the image.
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// CTOR:	Constructs the control with a new card, oriented vertically.
        /// </summary>
        public ACardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;   // Set the orientation to vertical.
            myCard = new Card();                    // Creates a new underlying card.

        }

        /// <summary>
        ///// CTOR (Card,Orientation)	Constructs the control using parameters
        /// </summary>
        /// <param name="card">Underlying Card Object</param>
        /// <param name="orientation">Orientation enumeration. Vertical by default</param>
        public ACardBox(Card card, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = orientation;    // Set the orientation
            myCard = card;                  // Set the underlying card.
        }
        #endregion

        #region EVENTS AND HANDLERS

        /// <summary>
        /// An event handler for the form load
        /// </summary>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();      // Updates card image
        }

        /// <summary>
        /// An event the client program can handle when the card flips face up/down
        /// </summary>
        public event EventHandler CardFlipped;

        /// <summary>
        /// An event the client program can handle when the card is hovered
        /// </summary>
        new public event EventHandler MouseEnter;

        /// <summary>
        /// An event the client program can handle when the card is un-hovered
        /// </summary>
        new public event EventHandler MouseLeave;

        /// <summary>
        /// An event the client program can handle when the user clicks the control
        /// </summary>
        new public event EventHandler Click;

        /// <summary>
        /// An event the client program can handle when the user clicks down on the control
        /// </summary>
        new public event MouseEventHandler MouseDown;

        /// <summary>
        /// An event the client program can handle when the user drags the control
        /// </summary>
        new public event DragEventHandler DragDrop;

        /// <summary>
        /// An event the client program can handle when the user drag drops the control
        /// </summary>
        new public event DragEventHandler DragEnter;

        /// <summary>
        /// An event handler for the user hovering the picture box control
        /// </summary>
        private void pbMyPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEnter != null)  // If there is a handler for clicking the control in the client program 
                MouseEnter(this, e); // Call it
        }

        /// <summary>
        /// An event handler for the user un-hovering the picture box control
        /// </summary>
        private void pbMyPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeave != null)  // If there is a handler for clicking the control in the client program 
                MouseLeave(this, e); // Call it
        }

        /// <summary>
        /// An event handler for the user clicking the picture box control
        /// </summary>
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null)  // If there is a handler for clicking the control in the client program 
                Click(this, e); // Call it
        }

        /// <summary>
        /// An event handler for the user clicks down the picture box control
        /// </summary>
        private void pbMyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)  // If there is a handler for clicking the control in the client program 
                MouseDown(this, e); // Call it
        }

        /// <summary>
        /// An event handler for the user drags the picture box control
        /// </summary>
        private void pbMyPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)  // If there is a handler for clicking the control in the client program 
                DragEnter(this, e); // Call it
        }

        /// <summary>
        /// An event handler for the user drag drops the picture box control
        /// </summary>
        private void pbMyPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)  // If there is a handler for clicking the control in the client program 
                DragDrop(this, e); // Call it
        }

        #endregion

        #region OTHER METHODS

        /// <summary>
        /// ToString: Overrides System.Object.ToString()
        /// </summary>
        /// <returns>The name of the card as a string</returns>
        public override string ToString()
        {
            return myCard.ToString();
        }

        #endregion
    }
}
