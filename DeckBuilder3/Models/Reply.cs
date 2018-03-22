using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckBuilder3.Models
{
    public class Reply
    {
        public int ID { get; set; }

        public int CommentID { get; set; }
        public Comment Comment { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public string ReplyContent { get; set; }
    }
}
