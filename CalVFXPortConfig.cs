using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CalVFXPort
{
    [Label("Calamity VFX Config")]
    public class CalVFXPortConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Omega Blue Tentacle Density")]
        [Range(0, 1000)]
        [DefaultValue(200)]
        [Tooltip("Changes the density of Omega Blue Tentacles. Set to 0 to disable")]
        public int DrawLimit_OBTentacle { get; set; }

        [Label("Brimstone Monster redesign")]
        [DefaultValue(true)]
        [Tooltip("Redesigns Brimstone Monsters to look prettier")]
        public bool BrimMonsterRedesign { get; set; }
        
        [Label("Brimstone Monster Animation Speed")]
        [SliderColor(224, 165, 56, 128)]
        [Range(0f, 2f)]
        [DefaultValue(1)]
        [Tooltip("Adjusts the animation speed of Brimstone Monsters")]
        public float BrimMonsterSpeed { get; set; }

        public static CalVFXPortConfig Instance;
    }
}
