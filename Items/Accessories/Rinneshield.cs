using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using assasinmod.Global;

namespace assasinmod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class Rinneshield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rinne Shield"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Increase defense by 15\nReduces damage taken by 20%\nIncrease max life by 20");
        }

        public override void SetDefaults()
        {

            Item.accessory = true;
            Item.width = 30;
            Item.height = 30;

            Item.rare = ItemRarityID.Expert;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 15;
            player.endurance += 0.2f;
            player.statLifeMax2 += 20;
            player.GetModPlayer<AccesorryDashPlayer>().DashAccessoryEquipped = true;


        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.EoCShield);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}