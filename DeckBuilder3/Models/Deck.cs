using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckBuilder3.Models
{
    public class Deck
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public int Amount { get; set; }

        public List<CardDeck> CardDecks { get; set; }
        public List<Comment> Comments { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public Deck()
        {
            Amount = 0;
        }

    }
}
