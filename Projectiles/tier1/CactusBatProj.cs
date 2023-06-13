using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Buffs;

namespace assasinmod.Projectiles.tier1
{
    internal class CactusBatProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.ShortSword;
            Projectile.width = 48;
            Projectile.height = 48;

            Projectile.penetrate = -1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.timeLeft = 300;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (crit)
            {
                knockback = 30;
                target.AddBuff(ModContent.BuffType<superbled>(), 60 * 2);
                target.AddBuff(BuffID.Poisoned, 60 * 5);
            }
            else
            {
                knockback = 15;
            }
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            DrawOriginOffsetX = 0;
            DrawOffsetX = -((64 / 2) - Projectile.width / 2);
            DrawOriginOffsetY = -((64 / 2) - Projectile.height / 2);
        }
    }
}
