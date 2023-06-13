using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Projectiles;
using Steamworks;

namespace assasinmod.Items.Weapons
{
    public class customsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Custom sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("testing sword.");
        }
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<ChloroStarsProj>();
            //Item.shoot = ModContent.ProjectileType<flyingpumpkin>();
            //Item.shoot = ProjectileID.Arkhalis;
            //Item.shoot = ProjectileID.DD2PhoenixBowShot;
            //Item.shoot = ProjectileID.StardustGuardian;
            //Item.shoot = ProjectileID.VampireKnife;

            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.noMelee = true;
            Item.shootSpeed = 20;
            Item.scale = 2f;

        }
    }
}