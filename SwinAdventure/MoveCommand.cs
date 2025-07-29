using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        //constructor with ids for the move command
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
            
        }

        //methods
        public override string Execute(Player p, string[] text)
        {
            // to store the direction
            string moveTo;
            //array of valid move commands
            string[] moveIds = new string[] { "move", "go", "head", "leave" };

            //error if 3 or more input strings
            if (text.Length >= 3)
            {
                return "I don't know how to move like that";
            }
            //error if first string does not match any move commands
            else if (!moveIds.Contains(text[0]))
            {
                return "Error in move input";
            }
            //error if only 1 string input
            else if (text.Length == 1)
            {
                return "Where do you want to move?";
            }
            else
            {
                // set second string to direction
                moveTo = text[1];

                //check if direction( should be a path identifier) exists in location
                //only check the location the player is in
                //check if the result is a Path object 
                if (p.Locate(moveTo) is Path path)
                {
                    p.Move(path);

                    return $"You head {path.Name}\nYou have arrived in {path.Destination.Name}";
                }
                //error if method returns null or returns a different type of GameObject
                else
                {
                    return "Error in direction!";
                }
            }


        }
    }
}
