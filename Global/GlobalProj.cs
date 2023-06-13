using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Buffs;

namespace assasinmod.Global
{
    internal class GlobalProj : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.whoAmI];
            if (crit && player.GetModPlayer<DamageTypePlayer>().lethalArmor)
            {
                player.AddBuff(ModContent.BuffType<killingIntensions>(), 5 * 60);
            }
        }
    }
}
