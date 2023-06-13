using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Global;

namespace assasinmod.Items.Accessories
{
    public class Medalion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Witcher's Medallion");
            Tooltip.SetDefault("Mutate your body\nDoubles lethal damage\nDecreases life by half");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.buyPrice(gold: 1, silver: 25);

            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //float lethal = player.GetModPlayer<GlobalPlayer>().lethalDamage;
            //lethal *= 2;
            player.GetModPlayer<DamageTypePlayer>().lethalDamage += 1f;
            //int maxlife = player.statLifeMax2;
            //maxlife /= 2;
            player.statLifeMax2 /= 2;
            player.GetModPlayer<DamageTypePlayer>().lethalCrit += 0.5f;
        }
    }
}