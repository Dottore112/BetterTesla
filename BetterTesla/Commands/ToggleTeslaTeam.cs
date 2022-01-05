using System;
using System.Linq;
using CommandSystem;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using RemoteAdmin;
using Exiled.Permissions.Extensions;

namespace BetterTesla.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class ToggleTeslaTeam : ICommand
    {
        HashSet<Team> DisabledTeslaTeam = Handlers.DisabledTeslaTeam;

        public string Command { get; } = "toggleteslateam";

        public string[] Aliases { get; } = new string[] { "tggttm", "togglettm", "toggleteslatm", "tggteslateam" };

        public string Description { get; } = "A command for disabling teslas for teams";

        public string toggled;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("bettertesla.toggleteslateam"))
            {
                response = "You can't use that command";
                return false;
            }
            else if (arguments.Count != 1)
            {
                response = "Here how you use it: " + "(command) (team)" + "\nCommands that you can use for same function:" + "\ntggtm - togglettm - toggleteslatm - tggteslateam - toggleteslateam" +
                "\nTeams: CHI - MTF - CDP (ClassD) - RSC (Scientist) - SCP";
                return false;

            }
            else
            {
                if (Enum.TryParse(arguments.At(0), true, out Team team))
                {
                    if (DisabledTeslaTeam.Contains(team))
                    {
                        DisabledTeslaTeam.Remove(team);
                        toggled = "activated";
                    }
                    else
                    {
                        DisabledTeslaTeam.Add(team);
                        toggled = "disabled";
                    }

                }
                else
                {
                    response = "Here how you use it: " + "(command) (team)" + "\nCommands that you can use for same function:" + "\ntggtm - togglettm - toggleteslatm - tggteslateam - toggleteslateam" +
                "\nTeams: CHI - MTF - CDP (ClassD) - RSC (Scientist) - SCP";
                    return false;
                }
                response = "Tesla" + toggled + "for that team";
                return true;
            }
        }
    }
}