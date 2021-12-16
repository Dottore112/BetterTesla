using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using Handlers = Exiled.Events.Handlers;
using Exiled.API.Enums;
using System.Linq;
using Exiled.API.Extensions;

namespace BetterTesla
{
    public class Handlers
    {
        public int TeslaTimes;
        public static bool ActivatedTeslas;

         public void Dying(DyingEventArgs ev)
         {
            if(ev.Handler.Type == DamageType.Tesla && Plugin.Singleton.Config.InventoryErase)
            {
                ev.Target.ClearInventory();
            }
         }


        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if(!ActivatedTeslas) {
                ev.IsTriggerable = false;
            } else {
                ev.IsTriggerable = true;
            }
            if(Plugin.Singleton.Config.TeslaDisableAtNoScp && Player.Get(Team.SCP).Count() == 0) 
            {
                ev.IsTriggerable = false;
            }

            if (ev.Player.IsNTF && Plugin.Singleton.Config.TeslaMTFDisabled)
            {
                ev.IsTriggerable = false;

                if (Plugin.Singleton.Config.TeslaMTFBC == true)
                    ev.Player.Broadcast(Plugin.Singleton.Config.TeslaMTF.Duration, Plugin.Singleton.Config.TeslaMTF.Content, Broadcast.BroadcastFlags.Normal, true);
            }

            if (ev.Player.IsCHI && Plugin.Singleton.Config.TeslaCHIDisabled)
            {
                ev.IsTriggerable = false;
                if (Plugin.Singleton.Config.TeslaCHIBC)
                    ev.Player.Broadcast(Plugin.Singleton.Config.TeslaCHI.Duration, Plugin.Singleton.Config.TeslaCHI.Content, Broadcast.BroadcastFlags.Normal, true);


            }

            if (ev.Player.Team == Team.TUT && Plugin.Singleton.Config.TeslaTUTDisabled)
            {
                ev.IsTriggerable = false;
            }

           if (ev.Player.CurrentItem != null) {
                if (ev.Player.CurrentItem.Type == Plugin.Singleton.Config.BypassTeslaItem && Plugin.Singleton.Config.IfBypassTeslaItem == true)
                {
                    ev.IsTriggerable = false;
                }
           }

            
        }

        public void PickItem(PickingUpItemEventArgs ev) {

            if(ev.Pickup.Type == Plugin.Singleton.Config.BypassTeslaItem)

            ev.Player.Broadcast(Plugin.Singleton.Config.PickItemBC.Duration, Plugin.Singleton.Config.PickItemBC.Content, Broadcast.BroadcastFlags.Normal, true);
        }



        
         

        public void Interact079Tesla(InteractingTeslaEventArgs ev)
        {
            
            ev.AuxiliaryPowerCost = Plugin.Singleton.Config.TeslaCost079;

        if (Plugin.Singleton.Config.IfTesla079Limit) {
            if (TeslaTimes >= Plugin.Singleton.Config.Tesla079Limit) {
                ev.IsAllowed = false;
            } else  if (TeslaTimes < Plugin.Singleton.Config.Tesla079Limit) {
                ev.IsAllowed = true;
                TeslaTimes++;
            }
            
        }
        }
    }
    
}
 

        
    

