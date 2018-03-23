using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeckBuilder3.Models;
using DeckBuilder3.Data;
using DeckBuilder3.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeckBuilder3.Controllers
{
    public class DeckController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> _userManager;

        public DeckController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }




        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Deck> decks = context.Decks.ToList();

            return View(decks);
        }

        public IActionResult Add()
        {
            AddDeckViewModel addDeckViewModel = new AddDeckViewModel();
            return View(addDeckViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddDeckViewModel addDeckViewModel)
        {
            if (ModelState.IsValid)
            {
                string CurrentUserID = User.Identity.Name ; 
                Deck newDeck = new Deck
                {
                    Name = addDeckViewModel.Name,
                    UserID = CurrentUserID
                };

                context.Decks.Add(newDeck);
                context.SaveChanges();
                return Redirect("/Deck/ViewDeck/" + newDeck.ID);
            }
            return View(addDeckViewModel);
        }

        public IActionResult ViewDeck(int id)
        {
            List<CardDeck> deckCards = context.CardDecks.Include(deckCard => deckCard.Card).Where(cd => cd.DeckID == id).ToList();
            Deck currentDeck = context.Decks.Single(c => c.ID == id);

            ViewDeckViewModel viewDeckViewModel = new ViewDeckViewModel();

            viewDeckViewModel.Cards = deckCards;
            viewDeckViewModel.Deck = currentDeck;

            return View(viewDeckViewModel);
        }

        public IActionResult EditDeck(int id)
        {
            List<CardDeck> deckCards = context.CardDecks.Include(deckCard => deckCard.Card).Where(cd => cd.DeckID == id).ToList();
            Deck currentDeck = context.Decks.Single(c => c.ID == id);

            IList<Card> cards = context.Cards.ToList();

            EditDeckViewModel editDeckViewModel = new EditDeckViewModel(cards);

            editDeckViewModel.CardDecks = deckCards;
            editDeckViewModel.Deck = currentDeck;

            return View(editDeckViewModel);
        }

        [HttpPost]
        public IActionResult EditDeck(EditDeckViewModel editDeckViewModel)
        {
            int id = editDeckViewModel.DeckID;
            List<CardDeck> deckCards = context.CardDecks.Include(deckCard => deckCard.Card).Where(cd => cd.DeckID == id).ToList();
            Deck currentDeck = context.Decks.Single(c => c.ID == id);

            IList<Card> cards = context.Cards.ToList();

            if (editDeckViewModel.Name != "all")
            {
                cards = cards.Where(x => x.Name == editDeckViewModel.Name).ToList();
            }

            if (editDeckViewModel.Job != "all")
            {
                cards = cards.Where(x => x.Job == editDeckViewModel.Job).ToList();
            }

            if (editDeckViewModel.Element != "all")
            {
                cards = cards.Where(x => x.Element == editDeckViewModel.Element).ToList();
            }

            if (editDeckViewModel.Role != "all")
            {
                cards = cards.Where(x => x.Role == editDeckViewModel.Role).ToList();
            }

            if (editDeckViewModel.Type != "all")
            {
                cards = cards.Where(x => x.Type == editDeckViewModel.Type).ToList();
            }

            if (editDeckViewModel.Cost != "all")
            {
                cards = cards.Where(x => x.Cost == int.Parse(editDeckViewModel.Cost)).ToList();
            }

            EditDeckViewModel newEditDeckViewModel = new EditDeckViewModel(cards);

            newEditDeckViewModel.CardDecks = deckCards;
            newEditDeckViewModel.Deck = currentDeck;

            return View(newEditDeckViewModel);
        }

        [HttpPost]
        public IActionResult AddCard(EditDeckViewModel editDeckViewModel)
        {
            int id = editDeckViewModel.DeckID;
            int cardID = editDeckViewModel.CardID;

            Deck currentDeck = context.Decks.Single(c => c.ID == id);
            Card currentCard = context.Cards.Single(c => c.ID == cardID);

            IList<Card> cards = context.Cards.ToList();

            IList<CardDeck> existingCardDecks = context.CardDecks.Where(c => c.CardID == currentCard.ID).Where(c => c.DeckID == currentDeck.ID).ToList();

            if (currentDeck.Amount < 50)
            {
                if ((existingCardDecks.Count() == 1) && (existingCardDecks[0].Amount < 3))
                {
                    existingCardDecks[0].Amount += 1;
                    currentDeck.Amount += 1;
                    context.SaveChanges();
                }

                if (existingCardDecks.Count() == 0)
                {
                    CardDeck newCardDeck = new CardDeck
                    {
                        DeckID = id,
                        CardID = cardID,
                        Amount = 1
                    };
                    currentDeck.Amount += 1;
                    context.CardDecks.Add(newCardDeck);
                    context.SaveChanges();

                }

            }


            EditDeckViewModel newEditDeckViewModel = new EditDeckViewModel(cards);
            List<CardDeck> deckCards = context.CardDecks.Include(deckCard => deckCard.Card).Where(cd => cd.DeckID == id).ToList();
            newEditDeckViewModel.CardDecks = deckCards;
            newEditDeckViewModel.Deck = currentDeck;

            string reEdit = "/Deck/EditDeck/" + id.ToString();

            return Redirect(reEdit);
        }

        [HttpPost]
        public IActionResult RemoveCard(EditDeckViewModel editDeckViewModel)
        {
            int id = editDeckViewModel.DeckID;
            int cardID = editDeckViewModel.CardID;

            Deck currentDeck = context.Decks.Single(c => c.ID == id);
            Card currentCard = context.Cards.Single(c => c.ID == cardID);

            IList<Card> cards = context.Cards.ToList();

            IList<CardDeck> existingCardDecks = context.CardDecks.Where(c => c.CardID == currentCard.ID).Where(c => c.DeckID == currentDeck.ID).ToList();


            if ((existingCardDecks.Count() == 1) && (existingCardDecks[0].Amount > 0))
            {
                existingCardDecks[0].Amount -= 1;
                currentDeck.Amount -= 1;
                if (existingCardDecks[0].Amount == 0)
                {
                    context.CardDecks.Remove(existingCardDecks[0]);
                }
                context.SaveChanges();
            }

            EditDeckViewModel newEditDeckViewModel = new EditDeckViewModel(cards);
            List<CardDeck> deckCards = context.CardDecks.Include(deckCard => deckCard.Card).Where(cd => cd.DeckID == id).ToList();
            newEditDeckViewModel.CardDecks = deckCards;
            newEditDeckViewModel.Deck = currentDeck;

            string reEdit = "/Deck/EditDeck/" + id.ToString();

            return Redirect(reEdit);
        }
    }
}
