using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeckBuilder3.Models;

namespace DeckBuilder3.ViewModels
{
    public class ViewDeckViewModel
    {
        public Deck Deck { get; set; }
        public IList<CardDeck> Cards { get; set; }

    }
}
