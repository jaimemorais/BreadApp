using BreadApp.Domain.Base;
using System;
using System.Collections.Generic;

namespace BreadApp.Domain.Entities
{
    public class BreadDone : Entity
    {
        public DateTime Date { get; set; }

        public User User { get; set; }

        public Recipe Recipe { get; set; }

        public string Comments { get; set; }

        public List<string> Tags { get; set; }

    }
}
