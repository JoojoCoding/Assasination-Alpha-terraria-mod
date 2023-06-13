using assasinmod.Projectiles.tier1;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace assasinmod.Items
{
    internal class OrbOfDiscord : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orb of Chaos");
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Red;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item8;
            Item.noUseGraphic = false;
            Item.noMelee = true;
            
        }
        public override bool? UseItem(Player player)
        {
            player.position = Main.MouseWorld;
            player.AddBuff(BuffID.ChaosState, 60 * 5);
            player.chaosState = true;
            if (player.HasBuff(BuffID.ChaosState))
            {
                //player.statLife -= 60;
                player.Heal(-60);
            }
            return true;
        }
    }
}
