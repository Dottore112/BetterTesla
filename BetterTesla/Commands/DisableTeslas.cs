using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using RemoteAdmin;
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
                response = "You cannot do that!";
                return false;
            }
            else
            {
                if (Handlers.ActivatedTeslas)
                {
                    Handlers.ActivatedTeslas = false;
                    response = "Teslas Disabled";
                    return true;

                }
                else
                {
                    Handlers.ActivatedTeslas = true;
                    response = "Teslas Activated";
                    return true;
                }
            }
        }
    }
}
