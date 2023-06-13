using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using assasinmod.Projectiles;
using assasinmod.Global;
using System.Linq;
using System;
using System.Collections.Generic;


namespace assasinmod.Items.Weapons
{
    public class MagneticDischarge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magnetic Discharge");
            Tooltip.SetDefault("Magnetic force forged into weapon");
        }
        public override void SetDefaults()
        {
            Item.height = 60;
            Item.width = 60;
            Item.damage = 50;
            Item.scale = 1f;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.crit = 10;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MagneticDischargeProj>();
            Item.shootSpeed = 15;

            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var dmgline = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (dmgline != null)
            {
                string[] split = dmgline.Text.Split(' ');
                dmgline.Text = split.First() + " lethal " + split.Last();
            }
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += player.GetModPlayer<DamageTypePlayer>().lethalDamage;
        }
    }
}
