using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Buffs;

namespace assasinmod.Projectiles
{
    internal class GravityKnifeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;


           
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            Projectile.penetrate = 10;

        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
                                    //Projectile.velocity.X = Projectile.velocity.X * 0.99f;
            Dust.NewDust(Projectile.Center, 1, 1, DustID.Shadowflame, 0.5f, -2f, 50, default(Color), 1f);
            Dust.NewDust(Projectile.Center, 1, 1, DustID.Ash, 0.5f, -2f, 50, new Color(0, 0, 0), 1f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Projectile.owner];
            Projectile.rotation += MathHelper.ToRadians(180f);
            target.AddBuff(ModContent.BuffType<voidcurse>(), 60 * 5);


        }
        int bounce = 0;
        int maxBounces = 4;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bounce++;
            for (int i = 0; i < 6; i++)
            {
                //Dust.NewDust(Projectile.Center, 2, 2, DustID.Dirt, 2f, 2f, 0, default(Color), 1f);
                int dust = Dust.NewDust(Projectile.Center, 2, 2, DustID.Silver, 2f, 2f, 0, default(Color), 2f);
                Main.dust[dust].velocity *= 2f;
                Main.dust[dust].scale = (float)Main.rand.Next(79, 105) * 0.013f;
                Main.dust[dust].noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Dig);
            if (Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X;
            if (Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y;
            if (bounce >= maxBounces) return true;
            else return false;
        }
    }
}
