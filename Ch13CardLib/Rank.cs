/*
 *  Rank.cs - Has the Ranks information for a deck of cards
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

namespace CardLibrary
{
    /// <summary>
    /// Enum for the ranks of cards starting at 1 to 14 
    /// </summary>
    public enum Rank : byte
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        HighAce
    }
}