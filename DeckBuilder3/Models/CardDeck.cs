using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckBuilder3.Models
{
    public class CardDeck
    {
        public int ID { get; set; }

        public int DeckID { get; set; }
        public Deck Deck { get; set; }

        public int CardID { get; set; }
        public Card Card { get; set; }

        public int Amount { get; set; }
    }
}
