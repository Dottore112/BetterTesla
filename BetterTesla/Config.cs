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

        [Description("If there is a bypassteslaitem, what is that? (default = coin) Example: Coin. List (Pick the Name):https://pastebin.com/RUT27JBU")]
        public ItemType BypassTeslaItem { get; set; }= ItemType.Coin;

        [Description("Broadcast pickup item")]
        public Exiled.API.Features.Broadcast PickItemBC { get; set; } = new Exiled.API.Features.Broadcast(" <color=white> THIS ITEM WILL BYPASS TESLA </color>");

        [Description("Cost for using Tesla for SCP 079 (default = 50)")]
        public int TeslaCost079 { get; set; } = 50;

        [Description("When a player dies by tesla, it should erase his inventory? (default = false)")]
        public bool InventoryErase { get; set; } = false;

        [Description("Has 079 a limit for how many teslas it can trigger? (default = false)")]
        public bool IfTesla079Limit { get; set; } = false;

        [Description("If Teslas079Limit is true, set the limit for 079 (default = 15)")]
        public int Tesla079Limit { get; set; }= 15;

        [Description("If there isn't any SCP left, should be the teslas disabled? (default = false)")]
        public bool TeslaDisableAtNoScp { get; set; }= false;

        [Description("When the round starts, the plugin should do a cassie about the activated teslas? (default = false)")]
        public bool CassieAtStart { get; set; } = false;

        [Description("Cassie when the round starts")]
        public string CassieAtStartMessage { get; set; } = "cassie_sl .g1 .g2 pitch_0.4 .g4 .g4 .g4 .g4 pitch_1.0 Attention breach containment detected automatic security sistem tesla gate is now enabled pitch_0.4 .g4 .g4 .g3";

        [Description("Cassie enabled for scp termination - tesla disabled? (default = false)")]
        public bool IfTerminatedScpCassie { get; set; } = false;

        [Description("Cassie if the scp got terminated")]
        public string TerminatedScpCassie { get; set; } = "cassie_sl .g1 .g2 pitch_0.4 .g4 .g4 .g4 .g4 All the scp got terminated. automatic security sistem tesla gate is now disabled pitch_0.4 .g4 .g4 .g3 ";


    }
}