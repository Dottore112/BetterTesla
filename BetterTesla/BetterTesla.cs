using Exiled.API.Features;
using System;

namespace BetterTesla
{
    public class BetterTesla : Plugin<Config>
    {
        public Handlers Handlers { get; private set; } = new Handlers();
        public override Version Version { get; } = new Version(1, 7, 3);
        public override Version RequiredExiledVersion { get; } = new Version(4, 0, 0);
        public override string Prefix { get; } = "BetterTesla";

        public static readonly BetterTesla Singleton = new BetterTesla();

        private BetterTesla() { }

        public override void OnEnabled()
        {
            Handlers.RegisterEvents();
        }

        public override void OnDisabled()
        {
            Handlers.UnregisterEvents();
        }
    }
}