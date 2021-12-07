using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Handlers = Exiled.Events.Handlers;
using Exiled.Events;
using MEC;

namespace BetterTesla
{
    public class Handlers
    {
        public int TeslaTimes;

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
                if (ev.Player.IsHuman)
                {
                    ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Burned, 3);
                    ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Deafened, 3);
                }
            }
        }

        public void PickItem(PickingUpItemEventArgs ev) {

            if(ev.Pickup.Type == Plugin.Singleton.Config.BypassTeslaItem)

            ev.Player.Broadcast(Plugin.Singleton.Config.PickItemBC.Duration, Plugin.Singleton.Config.PickItemBC.Content, Broadcast.BroadcastFlags.Normal, true);
        }





    }
}
        
    

