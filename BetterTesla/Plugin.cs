using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;
using Scp079Handler = Exiled.Events.Handlers.Scp079;
using System;
using System.Collections.Generic;

namespace BetterTesla
{
    public class Plugin : Plugin<Config>
    {
        public Handlers Handlers { get; private set; }
        public override Version Version { get; } = new Version(1, 7, 3);
        public override Version RequiredExiledVersion { get; } = new Version(4, 0, 0);
        public override string Prefix { get; } = "BetterTesla";



        public static Plugin Singleton;

        public override void OnEnabled()
        {
            Singleton = this;
            Handlers = new Handlers();
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            PlayerEvents.TriggeringTesla += Handlers.OnTriggeringTesla;
            PlayerEvents.PickingUpItem += Handlers.PickItem;
            PlayerEvents.Dying += Handlers.Dying;
            Scp079Handler.InteractingTesla += Handlers.Interact079Tesla;
        }

        private void UnregisterEvents()
        {
            PlayerEvents.TriggeringTesla -= Handlers.OnTriggeringTesla;
            PlayerEvents.PickingUpItem -= Handlers.PickItem;
            PlayerEvents.Dying -= Handlers.Dying;
            Scp079Handler.InteractingTesla -= Handlers.Interact079Tesla;
            Handlers = null;
        }
    }


}