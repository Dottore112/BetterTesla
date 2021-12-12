using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterTeslaTest
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}