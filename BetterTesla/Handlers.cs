using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using Handlers = Exiled.Events.Handlers;
using Exiled.API.Enums;

namespace BetterTesla
{
    public class Handlers
    {
        public int TeslaTimes;

         public void Dying(DyingEventArgs ev)
        {
            if(ev.Handler.Type == DamageType.Tesla && Plugin.Singleton.Config.InventoryErase)
            {
                ev.Target.ClearInventory();
            }
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {

            if (ev.Player.IsNTF && Plugin.Singleton.Config.TeslaMTFDisabled == true)
            {
                ev.IsTriggerable = false;

                if (Plugin.Singleton.Config.TeslaMTFBC == true)
                    ev.Player.Broadcast(Plugin.Singleton.Config.TeslaMTF.Duration, Plugin.Singleton.Config.TeslaMTF.Content, Broadcast.BroadcastFlags.Normal, true);
            }

            if (ev.Player.IsCHI && Plugin.Singleton.Config.TeslaCHIDisabled == true)
            {
                ev.IsTriggerable = false;
                if (Plugin.Singleton.Config.TeslaCHIBC == true)
                    ev.Player.Broadcast(Plugin.Singleton.Config.TeslaCHI.Duration, Plugin.Singleton.Config.TeslaCHI.Content, Broadcast.BroadcastFlags.Normal, true);


            }

            if (ev.Player.CurrentItem.Type == Plugin.Singleton.Config.BypassTeslaItem && Plugin.Singleton.Config.IfBypassTeslaItem == true)
            {
                ev.IsTriggerable = false;
            }






            if (ev.IsTriggerable && ev.IsInHurtingRange)
            {
                
                
               ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Burned, 2);
               ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Deafened, 2);
                
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
 

        
    

