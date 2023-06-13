using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using assasinmod.Global;
using assasinmod.Projectiles.tier1;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace assasinmod.Items.Weapons.tier1
{
    internal class CactusBat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus Bat");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;

            Item.damage = 10;
            Item.crit = 10;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 15;
            Item.value = Item.buyPrice(copper: 2);
            Item.rare = ItemRarityID.White;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<CactusBatProj>();
            Item.shootSpeed = 3f;
        }
    }
}
