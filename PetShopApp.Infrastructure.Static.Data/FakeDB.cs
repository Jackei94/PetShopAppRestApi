using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data
{
    public static class FakeDB
    {
        public static int id = 1;
        public static readonly List<Pet> Pets = new List<Pet>();

        public static int OwnerId = 1;
        public static readonly List<Owner> Owners = new List<Owner>();

        public static int PetTypeId = 1;
        public static readonly List<PetType> PetTypes = new List<PetType>();
    }
}
