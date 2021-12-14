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
        public bool ActivatedTeslas;

        public void OnStartedRound() 
        {
            Cassie.Message(Plugin.Singleton.Config.CassieAtStartMessage, false, true);
            if (Plugin.Singleton.Config.TeslaDisableAtNoScp) {
                if (Player.Get(Team.SCP).Count() == 0) {
                    ActivatedTeslas = false;
                }
            }
        }

         public void Dying(DyingEventArgs ev)
         {
            if(ev.Handler.Type == DamageType.Tesla && Plugin.Singleton.Config.InventoryErase)
            {
                ev.Target.ClearInventory();
            }
         }

         public void Died(DiedEventArgs ev) {
            if (Plugin.Singleton.Config.TeslaDisableAtNoScp) {
                if (Player.Get(Team.SCP).Count() == 0) 
                {
                    ActivatedTeslas = false;
                    Cassie.Message(Plugin.Singleton.Config.TerminatedScpCassie, false, true);
                }
            }
         }

        public Team GetTeam(RoleType roleType) 
        {
            switch (roleType)
            {
                case RoleType.ChaosConscript:
                case RoleType.ChaosMarauder:
                case RoleType.ChaosRepressor:
                case RoleType.ChaosRifleman:
                    return Team.CHI;
                case RoleType.Scientist:
                    return Team.RSC;
                case RoleType.ClassD:
                    return Team.CDP;
                case RoleType.Scp049:
                case RoleType.Scp93953:
                case RoleType.Scp93989:
                case RoleType.Scp0492:
                case RoleType.Scp079:
                case RoleType.Scp096:
                case RoleType.Scp106:
                case RoleType.Scp173:
                    return Team.SCP;
                case RoleType.Spectator:
                    return Team.RIP;
                case RoleType.FacilityGuard:
                case RoleType.NtfCaptain:
                case RoleType.NtfPrivate:
                case RoleType.NtfSergeant:
                case RoleType.NtfSpecialist:
                    return Team.MTF;
                case RoleType.Tutorial:
                    return Team.TUT;
                default:
                    return Team.RIP;
            }
         }
        public void ChangingRole(ChangingRoleEventArgs ev)
        {
            if (Plugin.Singleton.Config.TeslaDisableAtNoScp)
            {
                    if(GetTeam(ev.NewRole) == Team.SCP) 
                        ActivatedTeslas = true;
            }
              if(ev.Player.Team == Team.SCP && GetTeam(ev.NewRole) != Team.SCP && Player.Get(Team.SCP).Count() == 1) 
              {
                ActivatedTeslas = false;
              }
         }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if(!ActivatedTeslas) {
                ev.IsTriggerable = false;
            } else {
                ev.IsTriggerable = true;
            }

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
 

        
    

