using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DeckBuilder3.ViewModels
{
    public class AddDeckViewModel
    {
        [Required]
        [Display(Name = "Deck Name")]
        public string Name { get; set; }

    }
}
