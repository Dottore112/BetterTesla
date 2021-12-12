using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace BetterTeslaTest
{
    public class Plugin : Plugin<Config>
    {
        public Handlers Handlers { get; private set; }

        public static Plugin Singleton;

        public override void OnEnabled()
        {
            Singleton = this;

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
            Handlers = new Handlers();
            ServerEvents.RoundStarted += Handlers.RoundStarted;
            PlayerEvents.TriggeringTesla += Handlers.OnTriggeringTesla;
        }
        

        private void UnregisterEvents()
        {
            ServerEvents.RoundStarted -= Handlers.RoundStarted;
            PlayerEvents.TriggeringTesla -= Handlers.OnTriggeringTesla;
            Handlers = null;
        }
    }
}