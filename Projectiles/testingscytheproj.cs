using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace assasinmod.Projectiles
{
    public class testingscytheproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.width = 35;
            Projectile.height = 35;

            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.scale = 2f;
        }
        public override void AI()
        {
            
            Player player = Main.player[Projectile.owner];
            float rotateSpeed = 0.30f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;
            Projectile.position = new Vector2(player.MountedCenter.X - ((float)Projectile.width / 2), player.MountedCenter.Y - ((float)Projectile.height / 2));
            Projectile.direction = player.direction;
            //Projectile.position = player.MountedCenter;
           
           // Projectile.position = player.position;
            if (Projectile.rotation >= 10f || Projectile.rotation <= -10f)
            {
                Projectile.Kill();
            }
        }
    }
}