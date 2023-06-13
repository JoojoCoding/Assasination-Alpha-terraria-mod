using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace assasinmod.Projectiles
{
    public class customproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
	    {
            Projectile.width = 240;
            Projectile.height = 240;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
        }
        public override void AI() {
            Projectile.ai[0] += 1f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(0f);
            if (++Projectile.frameCounter >= 4)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.Kill();
                }
            }
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Flare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust].velocity *= 2f;
            Main.dust[dust].scale = (float)Main.rand.Next(100, 125) * 0.013f;
            Main.dust[dust].noGravity = false;

            int dust2 = Dust.NewDust(Projectile.Center, 1, 1, DustID.SolarFlare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust2].velocity *= 2f;
            Main.dust[dust2].scale = (float)Main.rand.Next(89, 115) * 0.013f;
            Main.dust[dust2].noGravity = false;

            int dust3 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Flare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust3].velocity *= 2f;
            Main.dust[dust3].scale = (float)Main.rand.Next(100, 125) * 0.013f;
            Main.dust[dust3].noGravity = false;

            int dust4 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Flare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust4].velocity *= 2f;
            Main.dust[dust4].scale = (float)Main.rand.Next(100, 125) * 0.013f;
            Main.dust[dust4].noGravity = false;
        }
    }
}

