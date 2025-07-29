using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        //constructor with default identifier "look"
        public LookCommand() : base(new string[] { "look" })
        {

        }

        //main property that returns the output based on the command
        public override string Execute(Player p, string[] text)
        {
            //initialize container and item to hold the values of the input
            IHaveInventory container = null;
            string itemId = null;

            // first check the length of the input (each string stored in an array)
            // if its not equal to 3 and 5 return an error because look command can only process those inputs
            if (text.Length != 1 && text.Length != 3 && text.Length != 5 )
            {
                return "I don't know how to look like that";
            } 
            else
            {
                //if the first text is not "look" then there is command error
                if (text[0] != "look")
                {
                    return "Error in look input";
                }
                // same with if second text is not "at"
                if (text.Length != 1 && text[1] != "at")
                {
                    return "What do you want to look at?";
                }
                // same with if 4th text is not "in" 
                // because if there are 5 inputs we will be look for the item inside a bag
                if (text.Length == 5 && text[3] != "in")
                {
                    return "What do you want to look in?";
                }
                //if none of the errors above occur, assign the conatiner value based on the inputs recieved
                switch(text.Length)
                {
                    // if the input is just "look" then it will look at the room the player is in
                    case 1:
                        container = p;
                        itemId = "room";
                        break;
                    // player is the container if 3 inputs
                    // player object is also converted into IHaveInventory using safe type cast
                    case 3:
                        container = p;
                        itemId = text[2];
                        break;
                    // bag is the container if 5 inputs
                    case 5:
                        // the last input would be the name of the bag
                        // so here a method is called that returns the bag object, the safe type cast is performed in the method 
                        container = FetchContainer(p, text[4]);
                        // if object is null then return an error 
                        if (container == null)
                        {
                            return $"I can't find the {text[4]}";
                        }
                        itemId = text[2];
                        break;
                }
                // 3rd input will be the item
                // lastly, return the full description of the item if no errors encountered
                return LookAtIn(itemId, container);
            }
        }
        // method to fetch a bag that the player has, if asked to locate an item inside a bag
        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        //return the full description of the item being looked
        public string LookAtIn(string thingId, IHaveInventory container)
        {
            //return an error if the item doesnt exist in the container
            if (container.Locate(thingId) == null)
            {
                return $"I can't find the {thingId}";
            } 
            else
            {
                return container.Locate(thingId).FullDescription;
            }
        }
    }
}
