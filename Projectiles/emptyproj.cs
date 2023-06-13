using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace assasinmod.Projectiles
{
    public class emptyproj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;


            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.CloneDefaults(ProjectileID.AmethystBolt);
            Projectile.aiStyle = 0;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //int dust = Dust.NewDust(new Vector2(velocity.X, velocity.Y), hitbox.Width, hitbox.Height, DustID.Stone, 0f, 0f, 0, default(Color), 2f);//rgb(186, 0, 0)
            //Main.dust[dust].noGravity = true;
            //Main.dust[dust].velocity *= 0f;
            return true;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Snow, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust].velocity *= 2f;
            Main.dust[dust].scale = (float)Main.rand.Next(89, 115) * 0.013f;
            Main.dust[dust].noGravity = true;

            int dust1 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Snow, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust1].velocity *= 2f;
            Main.dust[dust1].scale = (float)Main.rand.Next(89, 115) * 0.013f;
            Main.dust[dust1].noGravity = true;

            //int dust2 = Dust.NewDust(Projectile.Center, 15, 15, DustID.Ice, 1f, 1f, 0, default(Color), 2f);
            //Main.dust[dust2].velocity *= 2f;
            //Main.dust[dust2].scale = (float)Main.rand.Next(89, 115) * 0.013f;
            //Main.dust[dust2].noGravity = false;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(BuffID.Frostburn, 600, true);
            target.AddBuff(BuffID.Chilled, 600, true);
            target.AddBuff(BuffID.Frozen, 120, true);
            //pl.statLife += 1;
        }
    }
}