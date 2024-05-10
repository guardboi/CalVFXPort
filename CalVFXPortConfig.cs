using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CalVFXPort
{
    public class CalVFXPortConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Range(0, 1000)]
        [DefaultValue(200)]
        public int DrawLimit_OBTentacle { get; set; }

        public static CalVFXPortConfig Instance;
    }
}
