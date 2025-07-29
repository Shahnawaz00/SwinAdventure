using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids) { }

        // the commnad recieved will split each string and store it in an array
        public abstract string Execute(Player p, string[] text);

    }

}
