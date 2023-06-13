using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using assasinmod.Projectiles;

namespace assasinmod.Items.Weapons
{
    public class testingscythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("testing scythe");
            //Tooltip.SetDefault("Little and handy roman slasher");
        }
        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 50;
            Item.damage = 50;

            Item.useTime = 20; //15
            Item.useAnimation = 20; //15
            Item.useStyle = ItemUseStyleID.Swing;

            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<testingscytheproj>();
            Item.shootSpeed = 0;
            Item.noUseGraphic = true;

        }
    }

}
