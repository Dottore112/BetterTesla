using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterTesla
{
    public class Config : IConfig
    {
        [Description("Enable/Disable the Plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Is tesla Enable for MTF? (default = true) [true/false]")]
        public bool TeslaMTFDisabled  { get; set; } = true;

        [Description("Is tesla Enable for CHI? (default = false) [true/false]")]
        public bool TeslaCHIDisabled { get; set; } = false;




        [Description ("Is BroadCast Enabled for bypassing tesla for MTF? (default = true) [true/false]")]
        public bool TeslaMTFBC { get; set; } = true;

        [Description ("Is BroadCast Enabled for bypassing tesla for CHI? (default = true) [true/false]")]
        public bool TeslaCHIBC { get; set; } = true;

        [Description("To Make Change To The Broadcast to the MTF")]
        public Exiled.API.Features.Broadcast TeslaMTF { get; set; } = new Exiled.API.Features.Broadcast(" <b><color=red> TESLA GATE DISABLED FOR MTF </color></b>");

        [Description("To Make Change To The Broadcast to the CHI")]
        public Exiled.API.Features.Broadcast TeslaCHI { get; set; } = new Exiled.API.Features.Broadcast(" <b><color=green> TESLA GATE DISABLED FOR CHI </color></b>");

        [Description("There is an Item that bypass the Teslas? (default = false) [true/false]")]
        public bool IfBypassTeslaItem { get; set; } = false;

        [Description("If there is a bypassteslaitem, what is that? (default = radio) Example: Coin. List (Pick the Name):https://pastebin.com/RUT27JBU")]
        public ItemType BypassTeslaItem = ItemType.Coin;

        [Description("to change the cassie when all the SCPs are finished and I announce that the tesla is deactivated")]
        public string CassieMessage { get; set; } = "attention SCP 0 4 9 detected access blocked a tesla gate";

        [Description("Cost for triggering TeslaGate for SCP 079")]
        public int CostTesla { get; set; }  = 1;

        [Description("Broadcast pickup item")]
        public Exiled.API.Features.Broadcast PickItemBC { get; set; } = new Exiled.API.Features.Broadcast(" <color=white> THIS ITEM WILL BYPASS TESLA </color>");

        [Description("Cost for using Tesla for SCP 079 (default = 50)")]
        public int TeslaCost079 = 50;

    }
}