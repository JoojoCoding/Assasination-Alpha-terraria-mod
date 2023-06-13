using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using assasinmod.Projectiles;
using assasinmod.Global;
using Microsoft.Xna.Framework;

namespace assasinmod.Items.Weapons
{
    public class SilverKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Knives");
            //Tooltip.SetDefault("Little and handy roman slasher");
        }
        public override void SetDefaults()
        {
            Item.width = 21;
            Item.height = 7;
            Item.damage = 12;
            Item.crit = 10;

            Item.useTime = 15; //15
            Item.useAnimation = 15; //15
            Item.useStyle = ItemUseStyleID.Swing;

            Item.noMelee = true;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.shoot = ModContent.ProjectileType<SilverKnivesProj>();
            Item.shootSpeed = 15;
            Item.consumable = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.scale = 0.5f;

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