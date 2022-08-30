using BreadApp.Domain.Base;
using BreadApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace BreadApp.Domain.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }

        public string Instructions { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<string> Tags { get; set; }

        public bool IsPublished { get; set; }
    }
}
