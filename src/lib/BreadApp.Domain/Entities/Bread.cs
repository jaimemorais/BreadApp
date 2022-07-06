using BreadApp.Domain.Base;
using System;
using System.Collections.Generic;

namespace BreadApp.Domain.Entities
{
    public class Bread : Entity
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Recipe Recipe { get; set; }

        public List<string> Tags { get; set; }


        // TODO Domain Events


    }
}
