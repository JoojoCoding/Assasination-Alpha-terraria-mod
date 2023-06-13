using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Projectiles.tier1;
using assasinmod.Global;

namespace assasinmod.Items.Weapons.tier1
{
    internal class woodendarts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Darts");
        }
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 30;

            Item.damage = 4;
            Item.crit = 4;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(copper: 2);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = false;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<woodendartsproj>();
            Item.shootSpeed = 10;
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
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
