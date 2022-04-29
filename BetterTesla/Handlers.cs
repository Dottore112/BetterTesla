using Exiled.API.Features;
using Exiled.Events.EventArgs;
using PlayerEvents = Exiled.Events.Handlers.Player;
using Scp079Handler = Exiled.Events.Handlers.Scp079;
using Exiled.API.Enums;
using System.Linq;
using System.Collections.Generic;

namespace BetterTesla
{
    public class Handlers
    {
        public int Tesla079 = 0;
        public static bool TeslasEnabled = true;
        public static HashSet<Team> DisabledTeslaTeam = new HashSet<Team>();

        public void RegisterEvents()
        {
            PlayerEvents.TriggeringTesla += OnTriggeringTesla;
            PlayerEvents.PickingUpItem += PickItem;
            PlayerEvents.Dying += Dying;
            Scp079Handler.InteractingTesla += Interact079Tesla;
        }

        public void UnregisterEvents()
        {
            PlayerEvents.TriggeringTesla -= OnTriggeringTesla; 
            PlayerEvents.PickingUpItem -= PickItem;
            PlayerEvents.Dying -= Dying;
            Scp079Handler.InteractingTesla -= Interact079Tesla;
        }

        public void Dying(DyingEventArgs ev)
        {
            if (ev.Handler.Type == DamageType.Tesla)
            {
                if (BetterTesla.Singleton.Config.InventoryErase) 
                {
                    ev.Target.ClearInventory();
                }

                ev.IsAllowed = false;
                ev.Target.Kill(BetterTesla.Singleton.Config.DeathMessage);
            }
        }


        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (!TeslasEnabled)
                ev.IsTriggerable = false;
            else if (
                // The Player's in a Team for which Teslas are disabled (Round-Specific)
                DisabledTeslaTeam.Contains(ev.Player.Team) ||
                // The Player's in a Team for which Teslas are disabled (Config)
                BetterTesla.Singleton.Config.NoTriggerTesla.Contains(ev.Player.Team) ||
                // The Player is SCP079
                ev.Player.Role == RoleType.Scp079 ||
                // Teslas Disabled if no SCP is present on the Map
                BetterTesla.Singleton.Config.TeslaDisableAtNoScp && Player.Get(Team.SCP).Count() == 0 ||
                // Player has Tesla Bypass Item
                BetterTesla.Singleton.Config.IfBypassTeslaItem && ev.Player.CurrentItem != null && BetterTesla.Singleton.Config.BypassTeslaItem.Contains(ev.Player.CurrentItem.Type)
            ) {
                ev.IsTriggerable = false;
                ev.IsInIdleRange = false;
            }
        }

        public void PickItem(PickingUpItemEventArgs ev)
        {
            if (BetterTesla.Singleton.Config.BypassTeslaItem.Contains(ev.Pickup.Type))
                ev.Player.Broadcast(BetterTesla.Singleton.Config.PickItemBC);
        }

        public void Interact079Tesla(InteractingTeslaEventArgs ev)
        {
            ev.AuxiliaryPowerCost = BetterTesla.Singleton.Config.TeslaCost079;
            if (BetterTesla.Singleton.Config.IfTesla079Limit)
                ev.IsAllowed = Tesla079++ >= BetterTesla.Singleton.Config.Tesla079Limit;
        }
    }
}