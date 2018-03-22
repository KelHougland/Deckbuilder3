using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckBuilder3.Models
{
    public class Collection
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public List<CardCollection> CardCollections { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
