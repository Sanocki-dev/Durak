/*
 *  Cards.cs - Created to be a collection of Card Objects 
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
using System.Collections.Generic;

namespace CardLibrary
{
    public class Cards : List<Card>, ICloneable
    {
      
        /// <summary>
        /// This makes method allows you to copy an amount of cards
        /// </summary>
        /// <param name="targetCards"></param>
        public void CopyTo(Cards targetCards)
        {
            // A loop that will go until the target card it found
            for (int index = 0; index < this.Count; index++)
            {
                // Copies the cards to their new spot
                targetCards[index] = this[index];
            }
        }

        /// <summary>
        /// Deep copy of the collection of Card objects
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // Creates a new cards collection
            Cards newCards = new Cards();

            // Goes through each of the cards coping them to a new collection
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }

            // Returns the new cloned cards 
            return newCards;
        }
    }
}
