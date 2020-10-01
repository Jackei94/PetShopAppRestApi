using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime SoldTime { get; set; }

        public string Color { get; set; }

        public string PreviousOwner { get; set; }

        public double Price { get; set; }

        public List<Pet> Owners { get; set; }

        public List<Pet> PetTypes { get; set; }
    }
}
