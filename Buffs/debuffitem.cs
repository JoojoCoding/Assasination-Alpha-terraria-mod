using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace assasinmod.Buffs
{
    internal class debuffitem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ritual Blade");
            Tooltip.SetDefault("Sacrifice your blood");
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 54;

            Item.UseSound = SoundID.Item4;
            Item.autoReuse = false;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.buffType = ModContent.BuffType<voidcurse>();
            Item.buffTime = 60 * 5;
        }
        
    }
}
