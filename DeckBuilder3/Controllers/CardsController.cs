using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeckBuilder3.Data;
using DeckBuilder3.Models;
using DeckBuilder3.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeckBuilder3.Controllers
{
    public class CardsController : Controller
    {
        private ApplicationDbContext context;

        public CardsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {

            IList<Card> cards = context.Cards.ToList();
            CardSortViewModel cardSortViewModel = new CardSortViewModel(cards);

            return View(cardSortViewModel);
        }

        [HttpPost]
        public IActionResult Index(CardSortViewModel cardSortViewModel)
        {

            IList<Card> cards = context.Cards.ToList();

            if (cardSortViewModel.Name != "all")
            {
                cards = cards.Where(x => x.Name == cardSortViewModel.Name).ToList();
            }

            if (cardSortViewModel.Job != "all")
            {
                cards = cards.Where(x => x.Job == cardSortViewModel.Job).ToList();
            }

            if (cardSortViewModel.Element != "all")
            {
                cards = cards.Where(x => x.Element == cardSortViewModel.Element).ToList();
            }

            if (cardSortViewModel.Role != "all")
            {
                cards = cards.Where(x => x.Role == cardSortViewModel.Role).ToList();
            }

            if (cardSortViewModel.Type != "all")
            {
                cards = cards.Where(x => x.Type == cardSortViewModel.Type).ToList();
            }

            if (cardSortViewModel.Cost != "all")
            {
                cards = cards.Where(x => x.Cost == int.Parse(cardSortViewModel.Cost)).ToList();
            }

            CardSortViewModel newCardSortViewModel = new CardSortViewModel(cards);

            return View(newCardSortViewModel);
        }
    }
}
