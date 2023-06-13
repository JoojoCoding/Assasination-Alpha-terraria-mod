using assasinmod.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace assasinmod.Items.Weapons
{
    internal class GravityKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gravity Knife");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;

            Item.damage = 100;
            Item.crit = 5;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(copper: 2);
            Item.rare = ItemRarityID.Purple;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<GravityKnifeProj>();
            Item.shootSpeed = 20f;
        }
    }
}
