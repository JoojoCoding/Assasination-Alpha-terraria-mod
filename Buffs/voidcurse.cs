using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Global;

namespace assasinmod.Buffs
{
    internal class voidcurse : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Curse");
            Description.SetDefault("Nullifying life");
            Main.debuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            if (player.lifeRegen <= 0)
            {
                player.lifeRegen -= 50;
            }
            player.statDefense = 0;
            //if(player.statLife <= 0)
            //{
            //    player.Kill;
            //}    
            //player.endurance -= 0.1f;
            Dust.NewDust(player.Center, 1, 1, DustID.Shadowflame, 0.5f, -2f, 50, default(Color), 1f);
            Dust.NewDust(player.Center, 1, 1, DustID.Ash, 0.5f, -2f, 50, new Color(0,0,0), 1f);
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            if (npc.lifeRegen <= 0)
            {
                npc.lifeRegen -= 50;
                //npc.lifeRegenExpectedLossPerSecond = 50;
            }
            
            //npc.lifeRegenCount += 3;
            Dust.NewDust(npc.Center, 1, 1, DustID.Shadowflame, 0.5f, -2f, 50, default(Color), 1f);
            Dust.NewDust(npc.Center, 1, 1, DustID.Ash, 0.5f, -2f, 50, new Color(0, 0, 0), 1f);
        }
    }
}
