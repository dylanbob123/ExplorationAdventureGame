using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplorationGame
{
    public class Item
    {
        public string Name = "sword";
        public string Description = "an orkish shortsword";
        public Dictionary<string, string> ItemsDic = new Dictionary<string, string>();


        public Item()
        {

            ItemsDic.Add("lint", "someone forgot to clean these shoes");
            ItemsDic.Add("a sock", "it smells funny");
            ItemsDic.Add("Arcade token", "it says its worth one credit");
        }    
            
        
      
        
      
        public void GetRandom()
        {
            Random randomNumber = new Random();
            int number;
            if (ItemsDic.Count > 0)
            {
                number = randomNumber.Next(ItemsDic.Count);
                Name = ItemsDic.Keys.ElementAt(number);
                Description = ItemsDic.Values.ElementAt(number);
            }
        }

        public string GetNameAndDescription()
        {
            if (ItemsDic.Count > 0)
            {
                string NameAndDescription = "You found a " + Name + " (" + Description + ") inside one of the shoes";
                return NameAndDescription;
            }
            else
            {
                string NameAndDescription = "";
                return NameAndDescription;
            }
        }

        public void RemoveItem()
        {
            ItemsDic.Remove(Name);
        }

    }
    class Game
    {
 
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Adventure Game");
            Console.WriteLine(Art.title());
            Console.WriteLine("The goal of the game is to eradicate the ghosts from the spooky haunted house");
            Console.WriteLine("press enter to continue");
            Console.ReadKey();
        }
        public static void End()
        {
            if (Goal)
            {
                Console.Clear();
                Console.WriteLine(Art.ghost());
                Console.WriteLine("Success!");
                Inventory.Clear();
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Credits: David Graff -- support me on Patreon");
                Console.WriteLine("type enter to exit...");
                Console.ReadLine();
            }
            else
            {
                Inventory.Clear();
                Console.WriteLine("Try again!");

                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Run = true;
                Play();
            }
        }
        public static void Play()
        {
            Start();
            while (Run == true)
            {
                Menu();
            }
            End();
        }

        static bool Run = true;
        static int Choice;
        static string Input;
        static bool Goal = false;
        static List<String> Inventory = new List<string>();

        public static void Menu()
        {
            
            Item item = new Item();
            Console.Clear();
            Console.WriteLine(" you found some items on your journey:");

            foreach (string items in Inventory)
            {
                Console.WriteLine(items);
            }

            Console.WriteLine(Art.Pumpkin());
            Console.WriteLine("1) Haunted House 2) Bowling Alley 3) Library 4) Arcade 5)Exit");
            Input = Console.ReadLine();
            if (int.TryParse(Input, out Choice))
            {
                if (Choice >= 5)
                {
                    Run = false;
                }
                else
                {
                    //switch statement here
                    switch (Choice)
                    {
                        case 1:
                            Console.Clear();
                            
                            int infrontofHouseChoice;
                            string infrontofHouseInput;


                            Console.WriteLine(Art.HouseArt());


                            bool infrontofhouse = true;
                            while (infrontofhouse == true)
                            {
                                Console.WriteLine("1) Go to the Door 2) Leave House 3) Exit Game");
                                infrontofHouseInput = Console.ReadLine();
                                if (int.TryParse(infrontofHouseInput, out infrontofHouseChoice))
                                {
                                    if (Choice == 3)
                                    {
                                        infrontofhouse = false;
                                        Run = false;
                                    }
                                    else
                                    {

                                        switch (infrontofHouseChoice)
                                        {
                                            case 1:
                                                
                                                Console.WriteLine(Art.DoorLock());
                                                if (Inventory.Contains("key"))
                                                {
                                                    Console.Clear();

                                                    int HouseChoice;
                                                    string HouseInput;


                                                    Console.WriteLine(Art.HouseArt());
                                                    Console.WriteLine("You enter the Haunted House wearily. The door makes a loud creek as you enter");


                                                    bool inhouse = true;
                                                    while (inhouse == true)
                                                    {
                                                        Console.WriteLine("1) Go to the kitchen 2) Go to the living room 4) Leave house 3) Exit Game");
                                                        HouseInput = Console.ReadLine();
                                                        if (int.TryParse(HouseInput, out HouseChoice))
                                                        {
                                                            if (Choice == 4)
                                                            {
                                                                inhouse = false;
                                                                Run = false;
                                                            }
                                                            else
                                                            {

                                                                switch (HouseChoice)
                                                                {
                                                                    case 1:

                                                                        Console.WriteLine("You Enter the kitchen and find a knife in the drawer");
                                                                        Inventory.Add("knife");


                                                                        break;

                                                                    case 2:
                                                                        int GhostChoiceOut;
                                                                        Console.WriteLine("You Enter the Living room and a ghost appears behind you. Should you 1) call ghost busters or 2) try to fight the ghost? 3) Exit Game");
                                                                        string GhostChoice = Console.ReadLine();
                                                                        if (int.TryParse(GhostChoice, out GhostChoiceOut))
                                                                        {
                                                                            if (GhostChoiceOut == 3)
                                                                            {
                                                                                inhouse = false;
                                                                                infrontofhouse = false;
                                                                                Run = false;
                                                                            }
                                                                            else
                                                                            {

                                                                                switch (GhostChoiceOut)
                                                                                {


                                                                                    case 1:
                                                                                        
                                                                                        Console.WriteLine("You call ghost busters and save the day");
                                                                                        inhouse = false;
                                                                                        infrontofhouse = false;
                                                                                        Goal = true;
                                                                                        Run = false;
                                                                                     
                                                                                        
                                                                                       

                                                                                        break;
                                                                                    case 2:
                                                                                        if (Inventory.Contains("knife"))
                                                                                        {
                                                                                            
                                                                                            Console.WriteLine("you fight off the ghost with a knife and save the day");
                                                                                           
                                                                                            Goal = true;
                                                                                            inhouse = false;
                                                                                            infrontofhouse = false;
                                                                                            Run = false;
                                                                                            
                                                                                            
                                                                                           

                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("you die");
                                                                                            Console.WriteLine("type enter to continue...");
                                                                                            Console.ReadLine();
                                                                                            
                                                                                            Goal = false;
                                                                                            inhouse = false;
                                                                                            infrontofhouse = false;
                                                                                            Run = false;
                                                                                            
                                                                                        }
                                                                                        break;
                                                                                }

                                                                            }
                                                                        }
                                                                        break;

                                                                    case 3:
                                                                        Console.WriteLine("You are trapped in here");
                                                                        break;

                                                                }
                                                            }

                                                        }
                                                    }
                                                    Console.Clear();
                                                    break;
                                                }
                                                else
                                                {


                                                    Console.WriteLine("The door is locked");
                                                    //Console.WriteLine("Press enter to continue...");
                                                }

                                                break;
                                            
                                            case 2:

                                                infrontofhouse = false;
                                                break;

                                            case 3:
                                                infrontofhouse = false;
                                                Run = false;
                                                break;
                                              
                                        }
                                    }

                                }
                            }
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            int BAChoice;
                            string BAInput;


                            Console.WriteLine(Art.BowlingAlley());
                            
                            bool inBA = true;
                            while (inBA == true)
                            {
                                
                                Console.WriteLine("1) rent some bowling shoes (this step feels vaguely important) 2) Bowl 3) Leave Alley 4) Exit Game");
                                BAInput = Console.ReadLine();
                                if (int.TryParse(BAInput, out BAChoice))
                                {
                                    if (BAChoice >= 4)
                                    {
                                        inBA = false;
                                        Run = false;
                                    }
                                    else
                                    {

                                        switch (BAChoice)
                                        {
                                            case 1:
                                                Console.WriteLine("The worker looks at you funny and hands you a fresh pair of bowling shoes");
                                                //Console.WriteLine("Press enter to continue...");
                                                item.GetRandom();
                                                if (!Inventory.Contains(item.Name))
                                                {
                                                    Inventory.Add(item.Name);
                                                    Console.WriteLine(item.GetNameAndDescription());
                                                    item.RemoveItem();
                                                }



                                                break;
                                            case 2:
                                                Random generate = new Random();
                                                int scorez = generate.Next(33, 300);
                                                string score = string.Format("you bowl a {0}", scorez);
                                                Console.WriteLine(score);
                                                if (scorez > 200)
                                                {
                                                    Console.WriteLine("thats a great score");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("you can do better than that. Try again!");
                                                }

                                                break;
                                            case 3:

                                                inBA = false;
                                                break;
                                        }
                                    }

                                }
                            }
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();
                            int LibraryChoice;
                            string LibraryInput;
                            Console.WriteLine(Art.Library());
                           
                            bool inLibrary = true;
                            while (inLibrary == true)
                            {

                                Console.WriteLine("1) Browse the books 2) Lookup a book on the computer 3) Leave Library 4) Exit Game");
                                LibraryInput = Console.ReadLine();
                                if (int.TryParse(LibraryInput, out LibraryChoice))
                                {
                                    if (LibraryChoice == 4)
                                    {
                                        inLibrary = false;
                                        Run = false;
                                    }
                                    else
                                    {

                                        switch (LibraryChoice)
                                        {
                                            case 1:
                                                Console.WriteLine("You find some spooky books but nothing of interest");
                                                //Console.WriteLine("Press enter to continue...");
                                                


                                                break;
                                            case 2:
                                                Console.WriteLine(Art.LibraryComp());
                                                Console.WriteLine("type the name of the book: ");
                                                string DVCBook = Console.ReadLine();
                                                if (DVCBook.ToLower().Contains("davinci"))
                                                {
                                                    Console.WriteLine("You get the ISBN and find the book... inside you find the pages have been cut out specifically to hold a key");
                                                    Console.WriteLine("You found a skeleton key");
                                                    Inventory.Add("key");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("that search turns up nothing of interest");
                                                }
                                                break;
                                            case 3:

                                                inLibrary = false;
                                                break;
                                        }
                                    }

                                }
                            }
                            Console.Clear();
                            break;

                            

                        case 4:
                            Console.Clear();
                            int ArcadeChoice;
                            string ArcadeInput;
                            Console.WriteLine(Art.Arcade());

                            bool inArcade = true;
                            while (inArcade == true)
                            {

                                Console.WriteLine("1) talk to the locals 2) insert token and use the fortune teller 3) leave Arcade 4) Exit Game");
                                ArcadeInput = Console.ReadLine();
                                if (int.TryParse(ArcadeInput, out ArcadeChoice))
                                {
                                    if (ArcadeChoice == 4)
                                    {
                                        inArcade = false;
                                        Run = false;
                                    }
                                    else
                                    {

                                        switch (ArcadeChoice)
                                        {
                                            case 1:
                                                Console.WriteLine("The locals dont have much to say, but they agree something needs to be done about the haunted house");
                                                //Console.WriteLine("Press enter to continue...");



                                                break;
                                            case 2:
                                                if (Inventory.Contains("Arcade token"))
                                                {
                                                    Console.WriteLine("the fortune says something about 'The Davinci Code'");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("you dont have a token");
                                                }
                                                
                                                
                                                break;
                                            case 3:

                                                inArcade = false;
                                                break;
                                        }
                                    }

                                }
                            }
                            Console.Clear();
                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a number 1-5.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Menu();
            }
        }

    }
    class Program
    {
        static void Main()
        {
            Game.Play();
        }
    }
}