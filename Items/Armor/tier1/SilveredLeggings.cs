using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;

namespace assasinmod.Items.Armor.tier1
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SilveredLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silvered Leggings");
            Tooltip.SetDefault("Increase lethal damage by 15%\nDecreases life by 10");
        }
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.value = Item.buyPrice(silver: 60);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 0.15f;
            player.statLifeMax2 -= 10;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HermitPants>());
            recipe.AddIngredient(ItemID.SilverBar, 25);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe altrecipe = CreateRecipe()
                .AddIngredient(ModContent.ItemType<HermitPants>())
                .AddIngredient(ItemID.SilverBar, 25)
                .AddIngredient(ItemID.GoldBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
