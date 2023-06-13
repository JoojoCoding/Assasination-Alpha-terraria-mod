using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Projectiles;
using System.Collections.Generic;
using System.Linq;
using System;
using CsvHelper.TypeConversion;
using assasinmod.Global;
using Terraria.DataStructures;


namespace assasinmod.Items.Weapons
{
    public class bladeofchaos : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Chaos");
            Tooltip.SetDefault("Legendary blade forged in Olimpus.");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ChainGuillotines);
            Item.width = 32;
            Item.height = 76;
            //Item.damageType.DamageClass.Generic;
            Item.damage = 50;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Rapier; 
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.crit = 25;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shootSpeed = 20;
            Item.UseSound = SoundID.NPCHit56;


            //
            Item.shoot = ModContent.ProjectileType<bladeofchaosproj2>();
            //Item.scale = 2f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.ownedProjectileCounts[Item.shoot] == 1)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            }
           

            return true; // return false to stop vanilla from calling Projectile.NewProjectile.
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
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChainKnife);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
}