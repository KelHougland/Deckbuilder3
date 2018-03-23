using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DeckBuilder3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeckBuilder3.ViewModels
{
    public class CardSortViewModel
    {
        public List<SelectListItem> Names { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        public List<SelectListItem> Jobs { get; set; }

        [Display(Name = "Job:")]
        public string Job { get; set; }

        public List<SelectListItem> Elements { get; set; }

        [Display(Name = "Element:")]
        public string Element { get; set; }

        public List<SelectListItem> Costs { get; set; }

        [Display(Name = "Cost:")]
        public string Cost { get; set; }

        public List<SelectListItem> Roles { get; set; }

        [Display(Name = "Role:")]
        public string Role { get; set; }

        public List<SelectListItem> Types { get; set; }

        [Display(Name = "Type:")]
        public string Type { get; set; }

        public IEnumerable<Card> Cards { get; set; }

        public CardSortViewModel()
        {

        }

        public CardSortViewModel(IEnumerable<Card> cards)
        {
            Cards = cards;

            Names = new List<SelectListItem>();
            IEnumerable<string> DisNames = cards.Select(x => x.Name).Distinct().OrderBy(c => c);
            Names.Add(new SelectListItem { Value = "all", Text = "All" });

            Jobs = new List<SelectListItem>();
            IEnumerable<string> DisJobs = cards.Select(x => x.Job).Distinct().OrderBy(c => c);
            Jobs.Add(new SelectListItem { Value = "all", Text = "All" });

            Elements = new List<SelectListItem>();
            IEnumerable<string> DisElements = cards.Select(x => x.Element).Distinct().OrderBy(c => c);
            Elements.Add(new SelectListItem { Value = "all", Text = "All" });

            Costs = new List<SelectListItem>();
            IEnumerable<int> DisCosts = cards.Select(x => x.Cost).Distinct().OrderBy(c => c);
            Costs.Add(new SelectListItem { Value = "all", Text = "All" });

            Roles = new List<SelectListItem>();
            IEnumerable<string> DisRoles = cards.Select(x => x.Role).Distinct().OrderBy(c => c);
            Roles.Add(new SelectListItem { Value = "all", Text = "All" });

            Types = new List<SelectListItem>();
            IEnumerable<string> DisTypes = cards.Select(x => x.Type).Distinct().OrderBy(c => c);
            Types.Add(new SelectListItem { Value = "all", Text = "All" });

            foreach (string name in DisNames)
            {
                Names.Add(new SelectListItem
                {
                    Value = name,
                    Text = name
                });
            }

            foreach (string job in DisJobs)
            {
                if (job != null)
                {
                    Jobs.Add(new SelectListItem
                    {
                        Value = job,
                        Text = job
                    });
                }
            }

            foreach (string element in DisElements)
            {
                Elements.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            foreach (int cost in DisCosts)
            {
                Costs.Add(new SelectListItem
                {
                    Value = cost.ToString(),
                    Text = cost.ToString()
                });
            }

            foreach (string role in DisRoles)
            {
                Roles.Add(new SelectListItem
                {
                    Value = role,
                    Text = role
                });
            }

            foreach (string type in DisTypes)
            {
                Types.Add(new SelectListItem
                {
                    Value = type,
                    Text = type
                });
            }

        }
    }
}
