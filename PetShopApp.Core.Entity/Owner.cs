using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Pet Pet { get; set; }
    }
}
