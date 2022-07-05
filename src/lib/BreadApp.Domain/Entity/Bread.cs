using System;
using System.Collections.Generic;

namespace BreadApp.Domain.Entity
{
    public class Bread
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Recipe Recipe { get; set; }

        public List<string> Tags { get; set; }


        // TODO Domain Events

    }
}
