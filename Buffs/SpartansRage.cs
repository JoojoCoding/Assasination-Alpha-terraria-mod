using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Global;

namespace assasinmod.Buffs
{
    public class SpartansRage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spartan's Rage");
            Description.SetDefault("Rage of the true warrior");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 4;
            player.moveSpeed += 2;
            player.endurance += 0.5f;
            player.statLifeMax2 -= 100;

            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 2f;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.noFallDmg = true;
            player.noKnockback = true;
            player.thorns = 0.1f;
            //player.color = Color.Red;
            Dust.NewDust(player.Center, 5, 5, DustID.Blood, 0.1f, -3f, 50, default(Color), 2f);
        }
    }
}