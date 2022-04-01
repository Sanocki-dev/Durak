/*  
 *  CardOutOfRangeExcpetion.cs - Defines the CardOutOfRangeExcpetion Class, which is derived from Exception
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class CardOutOfRangeException : Exception
    {
        // DeckContents property (get only)
        private Cards deckContents;
        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }

        /// <summary>
        /// Ctor(Cards)
        /// </summary>
        /// <param name="sourceDeckContents"></param>
        public CardOutOfRangeException(Cards sourceDeckContents)
        : base("There are only 52 cards in the deck.")
        {
            // Set the Cards field
            deckContents = sourceDeckContents;
        }
    }
}
