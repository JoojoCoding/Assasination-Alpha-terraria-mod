using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using assasinmod.Global;

namespace assasinmod.Items.Weapons
{
    public class Pugio : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pugio");
            Tooltip.SetDefault("Little and handy roman slasher");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.width = 80;
            Item.height = 80;
            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 1, silver: 30);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.shoot = ProjectileID.FinalFractal;
            Item.shootSpeed = 2f;
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