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

        public string toggled()
        {
            string msg;
            msg = Handlers.ActivatedTeslas ? msg = "Activated" : msg = "Disabled";
            return msg;
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("bettertesla.toggleteslas"))
            {
                response = "You cannot do that!";
                return false;
            }
            Handlers.ActivatedTeslas = !Handlers.ActivatedTeslas ? true : false;
            response = "Teslas " + toggled();
            return true;
        }
    }
}