using Terraria;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;

namespace assasinmod.Items.Armor.tier1
{
    [AutoloadEquip(EquipType.Body)]
    internal class HermitRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermit's Robe");
            Tooltip.SetDefault("Increase lethal damage by 10%\nDecreases life by 10");
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
            player.statLifeMax2 -= 10;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TatteredCloth, 6);
            recipe.AddRecipeGroup("Wood", 30);
            recipe.AddIngredient(ItemID.Cobweb, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
