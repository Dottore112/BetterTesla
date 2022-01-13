using Exiled.API.Interfaces;
using System.ComponentModel;
using Exiled.API.Features;
using System.Collections.Generic;

namespace BetterTesla
{
    public class Config : IConfig
    {
        [Description("Enable/Disable the Plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Teams that should not active the teslas. Teams here: https://controlc.com/4ff2b452")]
        public List<Team> NoTriggerTesla { get; set; } = new List<Team>() { Team.MTF };

        [Description("Message of Death for Tesla (default: You have been caught by a Tesla Gate")]
        public string DeathMessage { get; set; } = "You have been caught by a Tesla Gate";

        [Description("Is There an Item that bypass the Teslas? (default = false) [true/false]")]
        public bool IfBypassTeslaItem { get; set; } = false;

        [Description("If there is a bypass tesla item, what is that? (default = coin) Example: Coin. List (Pick the Name):https://pastebin.com/RUT27JBU")]
        public HashSet<ItemType> BypassTeslaItem { get; set; } = new HashSet<ItemType>() { ItemType.Coin };

        [Description("Broadcast pickup item (If you don't want a broadcast for that, just erase the the BC content)")]
        public Exiled.API.Features.Broadcast PickItemBC { get; set; } = new Exiled.API.Features.Broadcast(" <color=white> THIS ITEM WILL BYPASS TESLA </color>", 5);

        [Description("Cost for using Tesla for SCP 079 (default = 50)")]
        public int TeslaCost079 { get; set; } = 50;

        [Description("When a player dies by tesla, it should erase his inventory? (default = false)")]
        public bool InventoryErase { get; set; } = false;

        [Description("Has 079 a limit for how many teslas it can trigger? (default = false)")]
        public bool IfTesla079Limit { get; set; } = false;

        [Description("If Teslas079Limit is true, set the limit for 079 (default = 15)")]
        public int Tesla079Limit { get; set; } = 15;

        [Description("If there isn't any SCP left, should be the teslas disabled? (default = false)")]
        public bool TeslaDisableAtNoScp { get; set; } = false;
    }
}