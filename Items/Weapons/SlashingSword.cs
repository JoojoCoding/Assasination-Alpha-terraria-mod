using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using assasinmod.Projectiles;
using System.Collections.Generic;
using System.Linq;
using System;
using CsvHelper.TypeConversion;
using assasinmod.Global;

namespace assasinmod.Items.Weapons
{
    public class SlashingSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Tempest");
            Tooltip.SetDefault("Slashing sword.");
        }
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 52;
            //Item.damageType.DamageClass.Generic;
            Item.damage = 50;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.crit = 25;
            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.noMelee = false;
            Item.scale = 0.5f;
            Item.shootSpeed = 8;
            //Item.CloneDefaults(ItemID.ChainGuillotines);
            Item.shoot = ModContent.ProjectileType<slash>();
            //Item.scale = 2f;
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
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Cloud, 0f, 0f, 0, default(Color));//rgb(186, 0, 0)
            Main.dust[dust].noGravity = false;
            Main.dust[dust].velocity *= 1f;
        }
        public override bool CanUseItem(Player player)
        {
            if(player.altFunctionUse == 2)
            {
                Item.shoot = ProjectileID.WeatherPainShot;
                Item.useTime = 15;
                Item.useAnimation = 15;
            }
            return true;
        }
    }
}