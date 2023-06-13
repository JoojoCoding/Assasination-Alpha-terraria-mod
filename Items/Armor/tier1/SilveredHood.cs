using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;

namespace assasinmod.Items.Armor.tier1
{
    [AutoloadEquip(EquipType.Head)]
    internal class SilveredHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silvered Hood");
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
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            if (body.type == ModContent.ItemType<SilveredRobe>() && legs.type == ModContent.ItemType<SilveredLeggings>())
            {
                return true;
            }
            return false;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases move speed by 10%\nIncrease lethal damage by 10%";
            player.moveSpeed += 0.1f;
            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HermitHood>());
            recipe.AddIngredient(ItemID.SilverBar, 20);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<HermitHood>())
                .AddIngredient(ItemID.SilverBar, 20)
                .AddIngredient(ItemID.GoldBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
