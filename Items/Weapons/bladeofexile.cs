using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Projectiles;
using System.Collections.Generic;
using System.Linq;
using System;
using CsvHelper.TypeConversion;
using Terraria.DataStructures;
using assasinmod.Global;

namespace assasinmod.Items.Weapons
{
    public class bladeofexile : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Exiles");
            Tooltip.SetDefault("Blade of the god who was exiled from Olimpus, tool of revenge.");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 76;
            //Item.damageType.DamageClass.Generic;
            Item.damage = 100;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
            Item.crit = 30;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shootSpeed = 25;
            Item.UseSound = SoundID.NPCHit56;
            Item.scale = 0.5f;


            //Item.CloneDefaults(ItemID.ChainGuillotines);
            Item.shoot = ModContent.ProjectileType<bladeofexileproj>();
            //Item.scale = 2f;
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
        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
            crit += player.GetModPlayer<DamageTypePlayer>().lethalCrit;
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