using Exiled.Events.EventArgs;

namespace BetterTesla
{
    public class Handlers
    {
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {

            if (ev.Player.IsNTF && Plugin.Singleton.Config.TeslaMTFDisabled)
            {
                ev.IsTriggerable = false;

                if (Plugin.Singleton.Config.TeslaMTFBC)
                    ev.Player.Broadcast(Plugin.Singleton.Config.TeslaMTF.Duration, Plugin.Singleton.Config.TeslaMTF.Content, Broadcast.BroadcastFlags.Normal, true);
            }

            if (ev.Player.IsCHI && Plugin.Singleton.Config.TeslaCHIDisabled)
            {
                ev.IsTriggerable = false;
                if (Plugin.Singleton.Config.TeslaCHIBC)
                    ev.Player.Broadcast(Plugin.Singleton.Config.TeslaCHI.Duration, Plugin.Singleton.Config.TeslaCHI.Content, Broadcast.BroadcastFlags.Normal, true);
            }

            if (ev.Player.CurrentItem.Type == Plugin.Singleton.Config.BypassTeslaItem && Plugin.Singleton.Config.IfBypassTeslaItem)
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

        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (ev.Pickup.Type == Plugin.Singleton.Config.BypassTeslaItem)

                ev.Player.Broadcast(Plugin.Singleton.Config.PickItemBC.Duration, Plugin.Singleton.Config.PickItemBC.Content, Broadcast.BroadcastFlags.Normal, true);
        }
    }
}