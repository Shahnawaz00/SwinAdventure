using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        private List<Command> _commands;

        public CommandProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>
            {
                new LookCommand(),
                new MoveCommand()
            };
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command cmd in _commands)
            {
                if (cmd.AreYou(text[0]))
                {
                    return cmd.Execute(p, text);
                }
            }
            return "Error in command input.";
        }
    }
}
