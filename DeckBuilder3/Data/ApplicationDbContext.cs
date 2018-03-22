using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DeckBuilder3.Models;

namespace DeckBuilder3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {

        public DbSet<Card> Cards { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CardDeck> CardDecks { get; set; }

        public DbSet<CardCollection> CardCollections { get; set; }

        public DbSet<Reply> Replies { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
