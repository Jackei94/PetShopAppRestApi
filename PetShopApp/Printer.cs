using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Services;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp
{
    // --UI--
    //Console.WriteLine
    //Console.ReadLine

    // --Infrastructure
    // EF - Static List - Text File

    // --Test--
    // Unit test for Core

    // --Core--
    // Pet - Entity - Core.Entity
    // Domain Service - Repository / UOW - Core
    // Application Service - Service - Core
    public class Printer: IPrinter
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;

            InitData();
        }

        public void StartUI()
        {
            string[] menuItems =
            {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        ListPets(pets);
                        break;
                    case 2:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var birthdate = AskQuestion("Birthdate: ");
                        var soldTime = AskQuestion("Sold Time: ");
                        var color = AskQuestion("Color: ");
                        var previousOwner = AskQuestion("Previous Owner: ");
                        var price = AskQuestion("Price: ");
                        var pet = _petService.NewPet(name, type, Convert.ToDateTime(birthdate), Convert.ToDateTime(soldTime), color, previousOwner, Convert.ToDouble(price));
                        _petService.CreatePet(pet);
                        break;
                    case 3:
                        var idForDelete = PrintFindPetById();
                        _petService.DeletePet(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newBirthdate = AskQuestion("Birthdate: ");
                        var newSoldTime = AskQuestion("Sold Time: ");
                        var newColor = AskQuestion("Color: ");
                        var newPreviousOwner = AskQuestion("Previous Owner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdatePet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Type = newType,
                            Birthdate = Convert.ToDateTime(newBirthdate),
                            SoldTime = Convert.ToDateTime(newSoldTime),
                            Color = newColor,
                            PreviousOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice)
                        });
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }


        //UI
        int PrintFindPetById()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} " +
                    $"Name: {pet.Name} " +
                    $"Type: {pet.Type} " +
                    $"Birthdate : {pet.Birthdate} " +
                    $"Sold Time: {pet.SoldTime} " +
                    $"Color: {pet.Color} " +
                    $"Previous Owner: {pet.PreviousOwner} " +
                    $"Price: {pet.Price}");
            }
            Console.WriteLine("\n");
        }

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5\n");
            }
            return selection;
        }

        void InitData()
        {
            var pet1 = new Pet()
            {
                Name = "Zoey",
                Type = "Cat",
                Birthdate = new DateTime(2020, 06, 01),
                SoldTime = new DateTime(2020, 08, 18),
                Color = "White",
                PreviousOwner = "Lotte",
                Price = (0.0)
            };
            _petService.CreatePet(pet1);

            var pet2 = new Pet()
            {
                Name = "Vax",
                Type = "Dog",
                Birthdate = new DateTime(2018, 11, 01),
                SoldTime = new DateTime(2019, 01, 01),
                Color = "White",
                PreviousOwner = "Karsten",
                Price = (700.0)
            };
            _petService.CreatePet(pet2);
        }
    }
}