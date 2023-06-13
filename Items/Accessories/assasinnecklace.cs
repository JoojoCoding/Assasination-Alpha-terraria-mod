using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Global;

namespace assasinmod.Items.Accessories
{
    public class assasinnecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Young Assasin's necklace"); 
            Tooltip.SetDefault("Rewards with strength, costs life. \nIncreases lethal damage by 20% \nDecreases max life by 10");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 1, silver: 25);

            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 0.2f;
            player.statLifeMax2 -= 10;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Chain, 10);
            recipe.AddIngredient(ItemID.SilverBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe altRecipe = CreateRecipe();
            altRecipe.AddIngredient(ItemID.Chain, 10);
            altRecipe.AddIngredient(ItemID.TungstenBar, 5);
            altRecipe.AddTile(TileID.Anvils);
            altRecipe.Register();
        }
    }
}