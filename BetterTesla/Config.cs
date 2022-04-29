using Exiled.API.Interfaces;
using System.ComponentModel;
using Features = Exiled.API.Features;
using System.Collections.Generic;

namespace BetterTesla
{
    public class Config : IConfig
    {
        [Description("Enable/Disable the Plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Teams that shouldn't trigger teslas. Team Names: https://controlc.com/4ff2b452")]
        public List<Team> /* DisabledTeslaTeams */ NoTriggerTesla { get; set; } = new List<Team>() { Team.MTF };

        [Description("Teslas Death Message (default: \"You have been caught by a Tesla Gate\"")]
        public string /* TeslaDeathMessage */ DeathMessage { get; set; } = "You have been caught by a Tesla Gate";

        [Description("Enable Item Tesla Bypass (default = false) [true/false]")]
        public bool /* EnableTeslaItemBypass */ IfBypassTeslaItem { get; set; } = false;

        [Description("List of Items that Bypass Teslas (default = \"coin\"). Item Names: https://pastebin.com/RUT27JBU")]
        public List<ItemType> /* TeslaBypassItems */ BypassTeslaItem { get; set; } = new List<ItemType>() { ItemType.Coin };

        [Description("Broadcast for when a player picks up a Tesla Bypass Item (You can use an empy string as the Broadcast to disable it)")]
        public Features::Broadcast /* TeslaBypassItemPickupBroadcast */ PickItemBC { get; set; } = new Features::Broadcast("<color=white> YOU'VE PICKED UP AN ITEM THAT BYPASSES TESLAS </color>", 5);

        [Description("Cost for triggering Teslas as SCP 079 (default = 50)")]
        public int /* TeslaSCP079Cost */ TeslaCost079 { get; set; } = 50;

        [Description("Whether or not the Inventory of a Player who died by a Tesla should be cleared (default = false)")]
        public bool /* ClearInventoryOnTeslaDeath */ InventoryErase { get; set; } = false;

        [Description("Whether or not SCP079 should have a limit of how many Teslas it can trigger (default = false)")]
        public bool /* EnableSCP079TeslaLimit */ IfTesla079Limit { get; set; } = false;

        [Description("The Limit of Teslas that can be triggered by SCP079 (default = 15)")]
        public int /* SCP079TeslaLimit */ Tesla079Limit { get; set; } = 15;

        [Description("Whether or not Teslas can be Enabled if no SCP is Left (default = false)")]
        public bool /* DisableTeslasWithNoSCP */ TeslaDisableAtNoScp { get; set; } = false;
    }
}
