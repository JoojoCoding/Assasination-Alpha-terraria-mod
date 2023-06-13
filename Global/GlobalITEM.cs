using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;
using assasinmod.Buffs;

namespace assasinmod.Global
{
    internal class GlobalITEM : GlobalItem
    {
        public override void SetStaticDefaults()
        {
         
        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(crit && player.GetModPlayer<DamageTypePlayer>().lethalArmor)
            {
                player.AddBuff(ModContent.BuffType<killingIntensions>(), 5 * 60);
            }
        }
    }
}
