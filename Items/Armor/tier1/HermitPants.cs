using assasinmod.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace assasinmod.Items.Armor.tier1
{
    [AutoloadEquip(EquipType.Legs)]
    internal class HermitPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermit's Pants");
            Tooltip.SetDefault("Increase lethal damage by 10%\nDecreases life by 5");
        }
        public override void SetDefaults()
        {
            Item.defense = 1;
            Item.value = Item.buyPrice(silver: 10);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 0.1f;
            player.statLifeMax2 -= 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TatteredCloth, 5);
            recipe.AddRecipeGroup("Wood", 25);
            recipe.AddIngredient(ItemID.Cobweb, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
