using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace assasinmod.Buffs
{
    internal class superbled : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grievous Wounds");
            Description.SetDefault("You're just bleeding out!");
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if(player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            if(player.lifeRegen <= 0)
            {
                player.lifeRegen -= 30;
            }
            player.statDefense -= 1;
            player.lifeRegenCount += 3;
            //if(player.statLife <= 0)
            //{
            //    player.Kill;
            //}    
            //player.endurance -= 0.1f;
            Dust.NewDust(player.Center, 1, 1, DustID.Blood, 0.5f, 1f, 50, default(Color), 2f);
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            if (npc.lifeRegen <= 0)
            {
                npc.lifeRegen -= 30;
            }
            npc.lifeRegenCount += 3;
            Dust.NewDust(npc.Center, 1, 1, DustID.Blood, 0.5f, 1f, 50, default(Color), 2f);
        }
    }
}
