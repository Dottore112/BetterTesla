using System;
using CommandSystem;
using Exiled.Permissions.Extensions;
    
namespace BetterTesla.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class DisableTeslas : ICommand
    {
        public string Command { get; } = "toggleteslas";

        public string[] Aliases { get; } = new string[] { "togteslas" };

        public string Description { get; } = "A command for disabling teslas";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) 
        {
            if (!sender.CheckPermission("bettertesla.toggleteslas"))
            {
                response = "You don't have the permissions to use this command.";
                return false;
            }

            Handlers.TeslasEnabled = !Handlers.TeslasEnabled;
            response = "Teslas " + (Handlers.TeslasEnabled ? "Activated" : "Disabled");
            return true;
        }
    }
}
