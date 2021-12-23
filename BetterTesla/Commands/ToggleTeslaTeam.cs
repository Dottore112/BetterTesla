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
        HashSet<Team> EnabledTeslaTeam = Handlers.EnabledTeslaTeams;
        
        public Handlers Handlers { get; private set; }
        public string Command { get; } = "toggleteslateam";

        public string[] Aliases { get; } = new string[] { "tggttm", "togglettm", "toggleteslatm", "tggteslateam" };

        public string Description { get; } = "A command for disabling teslas for teams";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if(!sender.CheckPermission("bettertesla.toggleteslateam")) {
                response = "You can't use that command";
                return false;
            } else if(arguments.Count != 1) {
                response = "Here how you use it: " + "(command) (team)" + "\nCommands that you can use for same function:" + "\ntggtm - togglettm - toggleteslatm - tggteslateam - toggleteslateam" +
                "\nTeams: CHI - MTF - DBOI - SCI - SCP";
                return false;

            } else {
                switch (arguments.At(0)) {
                    case "CHI": 
                    string Toggled;
                      if(EnabledTeslaTeam.Contains(Team.CHI)) {
                           EnabledTeslaTeam.Remove(Team.CHI);
                           Toggled = "disabled";
                      } else {
                          EnabledTeslaTeam.Add(Team.CHI);
                          Toggled = "enabled";
                      }
                      response = "The tesla has been " + Toggled + " for that team";
                      return true;
                    case "MTF":
                        if (EnabledTeslaTeam.Contains(Team.MTF))
                        {
                            EnabledTeslaTeam.Remove(Team.MTF);
                            Toggled = "disabled";
                        }
                        else
                        {
                            EnabledTeslaTeam.Add(Team.MTF);
                            Toggled = "enabled";
                        }
                        response = "The tesla has been " + Toggled + " for that team";
                        return true;
                    case "SCI":
                        if (EnabledTeslaTeam.Contains(Team.RSC))
                        {
                            EnabledTeslaTeam.Remove(Team.RSC);
                            Toggled = "disabled";
                        }
                        else
                        {
                            EnabledTeslaTeam.Add(Team.RSC);
                            Toggled = "enabled";
                        }
                        response = "The tesla has been " + Toggled + " for that team";
                        return true;
                        
                    case "DBOI":
                        if (EnabledTeslaTeam.Contains(Team.CDP))
                        {
                            EnabledTeslaTeam.Remove(Team.CDP);
                            Toggled = "disabled";
                        }
                        else
                        {
                            EnabledTeslaTeam.Add(Team.CDP);
                            Toggled = "enabled";
                        }
                        response = "The tesla has been " + Toggled + " for that team";
                        return true;
                        
                    case "SCP":
                        if (EnabledTeslaTeam.Contains(Team.SCP))
                        {
                            EnabledTeslaTeam.Remove(Team.SCP);
                            Toggled = "disabled";
                        }
                        else
                        {
                            EnabledTeslaTeam.Add(Team.SCP);
                            Toggled = "enabled";
                        }
                        response = "The tesla has been " + Toggled + " for that team";
                        return true;
                        
                    default: 
                        response = "Inexistent Team" + "\nTeams: CHI - MTF - DBOI - SCI - SCP";
                        return false;
                }

            }
        }

    }
}