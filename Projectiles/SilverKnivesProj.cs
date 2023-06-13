using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.Audio;


namespace assasinmod.Projectiles
{
    public class SilverKnivesProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 5;
            Projectile.height = 18;
            
           
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            //Projectile.scale = 0.7f;
            
        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            // Projectile.spriteDirection = Projectile.direction;
            
            Projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            Projectile.velocity.X = Projectile.velocity.X * 0.99f;
            if (Projectile.ai[0] < 30f)
            //if (Projectile.velocity.X > 1f)
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }
            if (Projectile.ai[0] >= 30f)
            //if(Projectile.velocity.X <= 1f)
            { 
                //Projectile.ai[0] = 30f;
                Projectile.velocity.Y += 0.4f;
                Projectile.rotation += 0.3f;
                //Projectile.rotation = 1.1f * (float);
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Silver, 1f, 1f, 0, default(Color), 1f);
            Main.dust[dust].velocity *= 2f;
           // Main.dust[dust].scale = (float)Main.rand.Next(79, 105) * 0.013f;
            Main.dust[dust].noGravity = false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 5; i++)
            {
                //Dust.NewDust(Projectile.Center, 2, 2, DustID.Dirt, 2f, 2f, 0, default(Color), 1f);
                int dust = Dust.NewDust(Projectile.Center, 2, 2, DustID.Silver, 2f, 2f, 0, default(Color), 2f);
                Main.dust[dust].velocity *= 2f;
                Main.dust[dust].scale = (float)Main.rand.Next(79, 105) * 0.013f;
                Main.dust[dust].noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Dig);
            return true;
        }
    }
}