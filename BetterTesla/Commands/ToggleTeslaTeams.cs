using System;
using CommandSystem;
using System.Collections.Generic;
using Exiled.Permissions.Extensions;

namespace BetterTesla.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class ToggleTeslaTeams : ICommand
    {
        HashSet<Team> DisabledTeslaTeam = Handlers.DisabledTeslaTeam;
        
        public string Command { get; } = "toggleteslateam";

        public string[] Aliases { get; } = new string[] { "tggttm", "togglettm", "toggleteslatm", "tggteslateam" };

        public string Description { get; } = "A command for disabling teslas for teams";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Team team;
            if (!sender.CheckPermission("bettertesla.toggleteslateam"))
            {
                response = "You don't have the permissions to use this command.";
                return false;
            }
            else if (
                // No Arguments Provided
                arguments.Count != 1 ||
                // Invalid Team
                // TODO: Add a different response for invalid team
                !Enum.TryParse(arguments.At(0), true, out team)
            ) {
                response = "Command Usage: " + Command + " <team>\n"
                    + "Aliases: " + String.Join(", ", Aliases) + "\n"
                    + "Teams: CHI - MTF - CDP (ClassD) - RSC (Scientist) - SCP";
                return false;
            }
            else if (DisabledTeslaTeam.Contains(team))
            {
                DisabledTeslaTeam.Add(team);
            }
            else
            {
                DisabledTeslaTeam.Remove(team);
            }
            
            response = "Tesla toggled for " + team;
            return true;
        }
    }
}