using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace assasinmod.Projectiles
{
    public class LeviathanAxeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;


            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.aiStyle = 3;
            Projectile.scale = 2f;
            //Projectile.CloneDefaults(ProjectileID.WoodenBoomerang);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(BuffID.Frostburn, 600, true);
            target.AddBuff(BuffID.Chilled, 600, true);
            target.AddBuff(BuffID.Frozen, 120, true);
            //pl.statLife += 1;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Snow, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust].velocity *= 2f;
            Main.dust[dust].scale = (float)Main.rand.Next(79, 105) * 0.013f;
            Main.dust[dust].noGravity = true;
        }
    }
}