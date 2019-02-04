using System;
using System.Collections.Generic;

public class InteractiveFiction {
    static void Main(string[] args) {
      PlayGame();
    }


//todo readme
    public static void PlayGame() {
      //Create our game world
      Location roomOne = new Location("Room one", true);
      roomOne.Description = "To your right there is a Bookcase and a coffee table, to the left a ticking clock and a sink, and ahead there is a door with a thin wide slot with a retangular screen over it.";
      Location roomTwo = new Location("Room Two", false);
      roomTwo.Description = "Now in the light you can see a case in the center of the room with a series of switches to your left, with a computer on a desk in the far right corner.";
      roomTwo.PreviousRoom = roomOne;
      Location finalRoom = new Location("Final Room", true);
      finalRoom.Description = "You enter the next room, the voice from before crackles on, \n\"Congratulations on beating our escape room! Thank you for joining us and have a wonderful day.\"\nA new door opens leading back outside and you exit.";
      Location currentLocation;
      currentLocation = roomOne;
      int goOut = 0;

      //creating the things in the game world
      Thing Bookcase = new Thing("Bookcase");
      Bookcase.Description = "It is a mahogany bookcase.";
      Bookcase.Details = "There is a book \"The History of Currency\" sticking out of the bookcase.";
      bool openedbook = false;
      Thing Sink = new Thing("Sink");
      Sink.Description = "It is a metal sink with hot and cold knobs. There is a hint of rust.";
      Thing Clock = new Thing("Clock");
      Clock.Description = "It is a standard analog clock, the hands at 11:20.";
      Clock.Details = "The clock has a glass shiny covering.";
      Thing Door = new Thing("Door");
      Door.Description = "It is an imposing steel door with no knob.";
      Thing Slot = new Thing("Slot");
      Slot.Description = "It is a thin platic slot.";
      int dollarsInserted = 0;
      int moneyInInventory = 0;
      Thing Screen = new Thing("Screen");
      Screen.Description = "A small digital screen.";
      Thing Switches = new Thing("Switches");
      Switches.Description = "A series of 5 swtiches.";
      Thing Computer = new Thing("Computer");
      Computer.Description = "Its an old computer with a crt moniter.";
      string Code = "";
      string CodeOriginal = "you must have balance";
      Thing Desk = new Thing("Desk");
      Desk.Description = "Its a comfortable desk with a computer sitting on top of it.";
      Desk.Details = "There is a closed drawer.";
      bool drawerOpen = false;
      bool balanceBalanced = false;

      //Create the inventory
      List<Thing> inventory = new List<Thing>();
      Thing Matchbook = new Thing("Matchbook");
      Matchbook.Description = "A new matchbook supplied by Escape Room inc";
      inventory.Add(Matchbook);
      Thing Money = new Thing("Money");
      Money.Description = "A wad of $10 dollar bills.";
      Money.Details = "You have $" + moneyInInventory + ".";
      Thing Hammer = new Thing("Hammer");
      Hammer.Description = "It's a rubber mallet with a wood handle.";
      bool HoleOppened = false;
      Thing Book = new Thing("Book");
      Book.Description = "Its a book on the history of currency. Fascinating.";

      //timer
      int timer = 1;

      // introduction
      Console.WriteLine("\nYou step into a small white room. A voice crackles over the speaker.\n");
      Console.WriteLine("\"Welcome to Escape Room Inc and thank you for joining us today. ");
      Console.WriteLine("You will be presented with a series of challenges you must solve. ");
      Console.WriteLine("You will have one hour to complete these challenges. Good luck.\"\n");

      //choosing difficulty
      int difficulty = 0;
      string command;
      while(difficulty == 0) {
        Console. Write("You notice to your right a series of buttons, easy, medium, and hard, which do you press? \n\n> ");
        command = Console.ReadLine();
        if(command.ToLower() == "easy") {
          difficulty = 60;
        }
        else {
          if(command.ToLower() == "medium") {
            difficulty = 50;
          }
          else {
            if(command.ToLower() == "hard") {
              difficulty = 40;
            }
          }
        }
      }

      Console.WriteLine("You enter the first room, the door shuts behind you");
      Console.WriteLine("\n" + currentLocation.GetDescription());

      //Game loop
      bool playing = true;
      while(playing) {
        if(timer<difficulty) {
          if(goOut == timer) {
            roomTwo.Illuminated = false;
            Console.WriteLine("The match goes out, plunging you into darkness.");
          }

          //Get a command
          Console.Write("\n> ");
          command = Console.ReadLine();

          //Process the command
          string[] splitCommands = command.Split(' ');

          if (splitCommands[0].ToLower() == "exit" || currentLocation == finalRoom) {
            playing = false;
          }

          //Loop through everything in the inventory and print out its name
          if (splitCommands[0].ToLower() == "inventory") {
            Console.WriteLine("INVENTORY");
            foreach(Thing item in inventory) {
              Console.WriteLine("\t" + item.Name + "\n\t" + item.GetDescription() + "\n");
            }
          }

          //examine command
          if(splitCommands[0].ToLower() == "examine") {
            if(currentLocation.IsIlluminated()) {
              if(currentLocation == roomOne) {
                if(splitCommands[1].ToLower() == "bookcase") {
                  Console.WriteLine(Bookcase.GetDescription());
                }
                else {
                  if(splitCommands[1].ToLower() == "sink") {
                    Console.WriteLine(Sink.GetDescription());
                  }
                  else {
                    if(splitCommands[1].ToLower() == "clock") {
                      Console.WriteLine(Clock.GetDescription());
                    }
                    else {
                      if(splitCommands[1].ToLower() == "door") {
                        Console.WriteLine(Door.GetDescription());
                      }
                      else {
                        if(splitCommands[1].ToLower() == "slot") {
                          Console.WriteLine(Slot.GetDescription());
                        }
                        else {
                          if(splitCommands[1].ToLower() == "screen") {
                            Console.WriteLine(Screen.GetDescription());
                          }
                          else {
                            Console.WriteLine("You cant examine that");
                          }
                        }
                      }
                    }
                  }
                }
              }
              else {
                if(currentLocation == roomTwo) {
                  if(splitCommands[1] == "switches") {
                    Console.WriteLine(Switches.GetDescription());
                  }
                  else {
                    if(splitCommands[1].ToLower() == "door") {
                      Console.WriteLine(Door.GetDescription());
                    }
                    else {
                      if(splitCommands[1].ToLower() == "computer") {
                        Console.WriteLine(Computer.GetDescription());
                      }
                      else {
                        if(splitCommands[1].ToLower() == "desk") {
                          Console.WriteLine(Desk.GetDescription());
                        }
                        else {
                          Console.WriteLine("You cant examine that");
                        }
                      }
                    }
                  }
                }
              }
            }
            else {
              Console.WriteLine("Its too dark to see anything.");
            }
          }

          if(splitCommands[0].ToLower() == "take") {
            if(!inventory.Contains(Hammer) && splitCommands[1].ToLower() == "hammer" && HoleOppened && currentLocation == roomOne) {
                inventory.Add(Hammer);
                Console.WriteLine("You take the hammer.");
            }
            else {
              if(splitCommands[1].ToLower() == "book" && !inventory.Contains(Book) && currentLocation == roomOne) {
                inventory.Add(Book);
                Console.WriteLine("You take the book.");
                Bookcase.Details = "There is a book missing.";
              }
              else {
                Console.WriteLine("You cant do that.");
              }
            }
          }

          if(splitCommands[0].ToLower() == "open") {
            if(openedbook == false && splitCommands[1].ToLower() == "book" && currentLocation == roomOne) {
              Console.WriteLine("You open the book to find a hole in the book containing $50, which you take. You place the book back on its shelf.");
              moneyInInventory += 50;
              openedbook = true;
              Money.Details = "You have $" + moneyInInventory + ".";
              if(!inventory.Contains(Money)) {
                inventory.Add(Money);
              }
            }
            else {
              if(splitCommands[1].ToLower() == "drawer" && currentLocation == roomTwo && currentLocation.IsIlluminated()) {
                if(Code == CodeOriginal) {
                  Console.WriteLine("In the drawer you find a balace. The right side of the balance has a weight stuck to it, causing it to tip right.");
                  Desk.Details = "In the drawer there is a balance that tips to the right.";
                  drawerOpen = true;
                }
                else {
                  Console.WriteLine("The drawer seems to be stuck.");
                }
              }
              else {
                Console.WriteLine("You cant do that.");
              }
            }
          }

          if(splitCommands[0].ToLower() == "insert") {
            if(splitCommands[1].ToLower() == "money" && moneyInInventory != 0 && currentLocation == roomOne) {
              dollarsInserted += moneyInInventory;
              moneyInInventory = 0;
              inventory.Remove(Money);
              Console.WriteLine("You insert the money into the slot, the screen changes to $" + dollarsInserted + ".00.");
              Screen.Details = "It displays " + dollarsInserted + ".00.";
              if(dollarsInserted == 100) {
                Console.WriteLine("The door to the next room opens.");
                roomOne.NextRoom = roomTwo;
              }
            }
            else {
              Console.WriteLine("You cant do that.");
            }
          }

          if(splitCommands[0].ToLower() == "turn") {
            if(splitCommands[1].ToLower() == "knobs" && currentLocation == roomOne) {
              Console.WriteLine("You turn the knobs to match the hands on the clock. A gap opens in the wall revealing a hammer and $20. You take the money.");
              moneyInInventory += 20;
              Money.Details = "You have $" + moneyInInventory + ".";
              roomOne.Description = "To your right there is a Bookcase and a coffee table, to the left a ticking clock and a sink with a gap in the wall next to it, and ahead there is a door with a thin wide slot with a retangular screen over it.";
              HoleOppened = true;
              if(!inventory.Contains(Money)) {
                inventory.Add(Money);
              }
            }
            else {
              Console.WriteLine("You cant do that.");
            }
          }

          if(splitCommands[0].ToLower() == "break") {
            if(splitCommands[1].ToLower() == "glass" && currentLocation == roomOne && inventory.Contains(Hammer)) {
              Console.WriteLine("The glass breaks, you notice something peeking out inside the clock. Its $30 dollars in cash.");
              moneyInInventory += 30;
              Money.Details = "You have $" + moneyInInventory + ".";
              Clock.Details = "The glass covering the clock is now broken";
              if(!inventory.Contains(Money)) {
                inventory.Add(Money);
              }
            }
            else {
              Console.WriteLine("You cant do that.");
            }
          }

          if(splitCommands[0].ToLower() == "go") {
            if(splitCommands[1].ToLower() == "forward" && currentLocation.NextRoom != null) {
                currentLocation = currentLocation.NextRoom;
                Console.WriteLine(currentLocation.GetDescription());
              }
            else {
              if(splitCommands[1].ToLower() == "back" && currentLocation.PreviousRoom != null) {
                currentLocation = currentLocation.PreviousRoom;
                Console.WriteLine(currentLocation.GetDescription());
              }
              else {
                Console.WriteLine("You cant do that.");
              }
            }
          }

          if (splitCommands[0].ToLower() == "light") {
            if(splitCommands[1].ToLower() == "match") {
              if(!currentLocation.IsIlluminated()) {
                roomTwo.Illuminated = true;
                Console.WriteLine("You light up a match, but it wont last long.");
                Console.WriteLine(roomTwo.GetDescription());
                goOut = timer + 3;
              }
              else {
                Console.WriteLine("Its already light.");
              }
            }
            else {
              if(splitCommands[1].ToLower() == "candle" && currentLocation == roomTwo && balanceBalanced && roomTwo.NextRoom == null) {
                Console.WriteLine("With that the door to the next room opens.");
                roomTwo.NextRoom = finalRoom;
                roomTwo.Illuminated = true;
                goOut = 0;
              }
              else {
                Console.WriteLine("You cant do that.");
              }
            }
          }

          if(splitCommands[0].ToLower() == "flip") {
            if(splitCommands[1].ToLower() == "switches" && currentLocation.IsIlluminated() && currentLocation == roomTwo) {
              Console.Write("Which would you like to switch?(seperate by a space)\n\n> ");
              string switchNumbers = Console.ReadLine();
              if(switchNumbers.Contains("2") && switchNumbers.Contains("3") && switchNumbers.Contains("5") && !switchNumbers.Contains("1") && !switchNumbers.Contains("4")) {
                while(Code!=CodeOriginal) {
                  Random rnd = new Random();
                  int key = rnd.Next(1, 26);
                  Console.Write("With that the computer moniter flickers on. It displays " + key + " " + Cypher(CodeOriginal, key) + ".\nWhat do you enter?\n\n> ");
                  Code = Console.ReadLine().ToLower();
                  if(Code == CodeOriginal) {
                    Console.WriteLine("Text pops up on the computer \"Correct!\". You hear a click in the drawer.");
                  }
                  else {
                    Console.WriteLine("Text pops up on the computer \"Incorrect, try again.\".");
                  }
                }
              }
              else {
                Console.WriteLine("All the switches return to the starting position. Try another potision");
              }
            }
            else {
              Console.WriteLine("You cant do that.");
            }
          }

          if(splitCommands[0].ToLower() == "place") {
            if(currentLocation == roomTwo && currentLocation.IsIlluminated() && drawerOpen) {
              if(splitCommands[1].ToLower() == "book") {
                Console.WriteLine("You balanced the balace. The box in the middle of the room opens revealing a candle.");
                balanceBalanced = true;
                Desk.Details = "In the drawer there is a balanced balance.";
                inventory.Remove(Book);
              }
              if(splitCommands[1].ToLower() == "hammer") {
                Console.WriteLine("The hammer is too heavy, the balace leans too far to the left and the hammer falls off.");
              }
              else {
                Console.WriteLine("You cant do that.");
              }
            }
          }

          if(splitCommands[0].ToLower() != "exit" && splitCommands[0].ToLower() != "inventory" && splitCommands[0].ToLower() != "examine" && splitCommands[0].ToLower() != "take" && splitCommands[0].ToLower() != "open" && splitCommands[0].ToLower() != "insert" && splitCommands[0].ToLower() != "turn" && splitCommands[0].ToLower() != "break" && splitCommands[0].ToLower() != "go" && splitCommands[0].ToLower() != "light" && splitCommands[0].ToLower() != "flip" && splitCommands[0].ToLower() != "place") {
            Console.WriteLine("You cant do that.");
          }

          //increase timer and start over agian
          timer += 1;
        }
        //failstate
        else {
          Console.WriteLine("There is a dinging sound, and all the doors open");
          Console.WriteLine("\"You have failed to complete the challenge in time. Better luck next time.\"");
          playing = false;
        }
      }
    }

    public static string Cypher(string codeOriginal, int key) {
      string code = "";
      char[] chars = new char[26]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
      foreach(char letter in codeOriginal) {
        if(letter == ' ') {
          code += " ";
        }
        else {
          code += chars[(Array.IndexOf(chars, letter) + key) % 26];
        }
      }
      return code;
    }
}
