using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace assasinmod.Projectiles
{
    public class bladeofexileproj : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 10;
            Projectile.height = 22;

            //Projectile.DamageType = DamageClass.Generic;

            //Projectile.aiStyle = 13; //13
            Projectile.penetrate = -1;
            Projectile.scale = 1f;

            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.CloneDefaults(ProjectileID.ChainGuillotine);
        }
        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
        //Projectile.drawOffsetX = 2;
        //  return true;
        //}
        /* public virtual bool PreDraw(ref Color lightColor)
         {
             //spriteBatch.drawOriginOffsetX = 2;
             Main.EntitySpriteDraw ;
             return true;
         }*/
        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction;
            
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Flare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust].velocity *= 2f;
            Main.dust[dust].scale = (float)Main.rand.Next(125, 175) * 0.013f;
            Main.dust[dust].noGravity = false;

            int dust2 = Dust.NewDust(Projectile.Center, 1, 1, DustID.SolarFlare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust2].velocity *= 2f;
            Main.dust[dust2].scale = (float)Main.rand.Next(89, 115) * 0.013f;
            Main.dust[dust2].noGravity = false;

            int dust3 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Flare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust3].velocity *= 2f;
            Main.dust[dust3].scale = (float)Main.rand.Next(125, 175) * 0.013f;
            Main.dust[dust3].noGravity = false;

            int dust4 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Flare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust4].velocity *= 2f;
            Main.dust[dust4].scale = (float)Main.rand.Next(125, 175) * 0.013f;
            Main.dust[dust4].noGravity = false;

            int dust5 = Dust.NewDust(Projectile.Center, 1, 1, DustID.SolarFlare, 1f, 1f, 0, new Color(161, 232, 246), 2f);
            Main.dust[dust5].velocity *= 2f;
            Main.dust[dust5].scale = (float)Main.rand.Next(89, 115) * 0.013f;
            Main.dust[dust5].noGravity = false;

        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.LocalPlayer;
            target.AddBuff(BuffID.OnFire3, 600, true);
            player.statLife += 1;
            //int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 0, new Color(186, 0, 0), 2f);//rgb(186, 0, 0)
            //Main.dust[dust].noGravity = false;
            //Main.dust[dust].velocity *= 0f;
        }
        


    }
}