using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace BetterTeslaTest
{
    public class Handlers
    {
        public void RoundStarted()
        {
            Map.Broadcast(5, $"<b><color=red>BetterTesla by Dottore</color></b>", Broadcast.BroadcastFlags.Normal, false);
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.IsNTF)
            {
                ev.IsTriggerable = false;
                ev.Player.Broadcast(5, $"<b><color=red>TESLA GATE DISATTIVATO PER GLI MTF</color></b>", Broadcast.BroadcastFlags.Normal, true);


            }

            if (ev.IsTriggerable)
            {
                ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Burned);
                ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Deafened);


                if (ev.IsInHurtingRange)
                {
                    ev.Player.DisableEffect(Exiled.API.Enums.EffectType.Deafened);
                    ev.Player.DisableEffect(Exiled.API.Enums.EffectType.Burned);
                }
                
            }                                 
        }
    }   
}
    