using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckBuilder3.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int DeckID { get; set; }
        public Deck Deck { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public string CommentText { get; set; }
    }
}
