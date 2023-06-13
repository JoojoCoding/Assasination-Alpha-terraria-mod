using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Global;
using System;
using IL.Terraria.GameContent;
using IL.Terraria.DataStructures;
using On.Terraria.GameContent;
using Terraria.GameContent;
using System.Runtime.CompilerServices;

namespace assasinmod.Buffs
{
    public class killingIntensions : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Killing Intensions");
            Description.SetDefault("Primal instincts unleashed!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 4;
            player.moveSpeed += 2;

            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 0.5f;
            player.noFallDmg = true;
            player.noKnockback = true;
            player.thorns = 0.1f;
            //player.color = Color.Red;
            Lighting.AddLight(player.position, 1f, 0f, 0f);
        }
        public override bool ReApply(Player player, int time, int buffIndex)
        {
            return true;
        }
    }
}