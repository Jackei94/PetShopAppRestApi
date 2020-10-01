using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class PetType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Pet Pet { get; set; }
    }
}
