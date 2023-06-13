using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace assasinmod.Projectiles
{
    public class flyingpumpkin : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.CloneDefaults(ProjectileID.MonkStaffT3);

            Projectile.aiStyle = 0;//481
            Projectile.penetrate = -1;
        }
        //public override void AI()
    }
}

