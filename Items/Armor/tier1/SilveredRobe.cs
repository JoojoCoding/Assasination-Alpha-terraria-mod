using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;

namespace assasinmod.Items.Armor.tier1
{
    [AutoloadEquip(EquipType.Body)]
    internal class SilveredRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silvered Robe");
            Tooltip.SetDefault("Increase lethal damage by 20%\nDecreases life by 20");
        }
        public override void SetDefaults()
        {
            Item.defense = 5;
            Item.value = Item.buyPrice(silver: 70);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 0.2f;
            player.statLifeMax2 -= 20;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HermitRobe>());
            recipe.AddIngredient(ItemID.SilverBar, 30);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe altrecipe = CreateRecipe()
                .AddIngredient(ModContent.ItemType<HermitRobe>())
                .AddIngredient(ItemID.SilverBar, 30)
                .AddIngredient(ItemID.GoldBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
