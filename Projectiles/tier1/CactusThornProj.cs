using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace assasinmod.Projectiles.tier1
{
    internal class CactusThornProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 26;

            Projectile.penetrate = 1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);

        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            Projectile.velocity.X = Projectile.velocity.X * 0.99f;
            if (Projectile.ai[0] >= 20f)
            {
                Projectile.ai[0] = 20f;
                Projectile.velocity.Y += 0.5f;
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 5; i++)
            {
                //Dust.NewDust(Projectile.Center, 2, 2, DustID.Dirt, 2f, 2f, 0, default(Color), 1f);
                int dust = Dust.NewDust(Projectile.Center, 2, 2, DustID.t_Cactus, 2f, 2f, 0, default(Color), 2f);
                Main.dust[dust].velocity *= 2f;
                Main.dust[dust].scale = (float)Main.rand.Next(79, 105) * 0.013f;
                Main.dust[dust].noGravity = true;
            }


            SoundEngine.PlaySound(SoundID.Dig);
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int chance = Main.rand.Next(0, 3);
            if(chance == 1)
            {
                target.AddBuff(BuffID.Poisoned, 60 * 5);
            }
        }
    }
}
