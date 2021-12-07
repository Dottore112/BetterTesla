using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace BetterTesla
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
            PlayerEvents.TriggeringTesla += Handlers.OnTriggeringTesla;
            PlayerEvents.PickingUpItem += Handlers.OnPickingUpItem;
        }

        private void UnregisterEvents()
        {
            PlayerEvents.TriggeringTesla -= Handlers.OnTriggeringTesla; //using *nome a caso* = Exiled.Events.Handlers.Scp079; serve per registrare gli eventi 
            PlayerEvents.PickingUpItem -= Handlers.OnPickingUpItem;
            Handlers = null;
        }
    }
}