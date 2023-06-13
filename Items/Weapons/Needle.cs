using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using assasinmod.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Diagnostics.Tracing;
using assasinmod.Global;

namespace assasinmod.Items.Weapons
{
    public class Needle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Needle");
            //Tooltip.SetDefault("Little and handy roman slasher");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.damage = 20;

            Item.useTime = 15; //15
            Item.useAnimation = 15; //15
            Item.useStyle = ItemUseStyleID.Swing;

            Item.noMelee = true;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.shoot = ModContent.ProjectileType<NeedleProj>();
            Item.shootSpeed = 25;
            Item.consumable = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3; // 3, 4, or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.ToRadians(5*i)); // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false; // return false to stop vanilla from calling Projectile.NewProjectile.
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var dmgline = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (dmgline != null)
            {
                string[] split = dmgline.Text.Split(' ');
                dmgline.Text = split.First() + " lethal " + split.Last();
            }
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += player.GetModPlayer<DamageTypePlayer>().lethalDamage;
        }
    }
}