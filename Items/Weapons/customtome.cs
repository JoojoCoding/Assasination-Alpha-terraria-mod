using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using assasinmod.Projectiles;

namespace assasinmod.Items.Weapons
{
    public class customtome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Knives");
            //Tooltip.SetDefault("Little and handy roman slasher");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 20;
            Item.damage = 50;

            Item.useTime = 1; //15
            Item.useAnimation = 1; //15
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<emptyproj>();
            Item.shootSpeed = 15;
            Item.noUseGraphic = true;

        }
    }
}