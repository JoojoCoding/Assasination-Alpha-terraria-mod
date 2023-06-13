using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace assasinmod.Projectiles.tier1
{
    internal class woodendartsproj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 30;

            Projectile.penetrate = 0;
            Projectile.ignoreWater = true;
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
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y += 0.5f;
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for(int i = 0; i < 5; i++)
            {
                //Dust.NewDust(Projectile.Center, 2, 2, DustID.Dirt, 2f, 2f, 0, default(Color), 1f);
                int dust = Dust.NewDust(Projectile.Center, 2, 2, DustID.Dirt, 2f, 2f, 0, default(Color), 2f);
                Main.dust[dust].velocity *= 2f;
                Main.dust[dust].scale = (float)Main.rand.Next(79, 105) * 0.013f;
                Main.dust[dust].noGravity = true;
            }

           
            SoundEngine.PlaySound(SoundID.Dig);
            return true;
        }
        
    }
}
