using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckBuilder3.Models
{
    public class CardCollection
    {
        public int ID { get; set; }

        public int CollectionID { get; set; }
        public Collection Collection { get; set; }

        public int CardID { get; set; }
        public Card Card { get; set; }

        public int Amount { get; set; }

        public int Foil { get; set; }

        public CardCollection()
        {
        }
    }
}
