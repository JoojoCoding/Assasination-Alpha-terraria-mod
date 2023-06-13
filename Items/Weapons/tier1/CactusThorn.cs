using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;
using assasinmod.Projectiles.tier1;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace assasinmod.Items.Weapons.tier1
{
    internal class CactusThorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus thorn");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;

            Item.damage = 6;
            Item.crit = 5;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(copper: 2);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = false;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<CactusThornProj>();
            Item.shootSpeed = 10;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = Main.rand.Next(1,4); // 3, 4, or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.ToRadians(10 * i)); // Watch out for dividing by 0 if there is only 1 projectile.
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
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient(ItemID.Cactus, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
