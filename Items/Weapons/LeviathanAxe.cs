using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using assasinmod.Projectiles;
using assasinmod.Global;

namespace assasinmod.Items.Weapons
{
	public class LeviathanAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leviathan Axe");
			//Tooltip.SetDefault("Little and handy roman slasher");
		}
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 20;
			Item.damage = 40;

			Item.useTime = 30; //15
			Item.useAnimation = 30; //15
			Item.useStyle = ItemUseStyleID.Swing;

			Item.autoReuse = true;
			Item.rare = ItemRarityID.LightRed;
			Item.noUseGraphic = false;

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
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool? CanAutoReuseItem(Player player)
		{
			return true;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 600, true);
            target.AddBuff(BuffID.Chilled, 600, true);
            target.AddBuff(BuffID.Frozen, 120, true);
            //pl.statLife += 1;
        }
        public override void HoldItemFrame(Player player)
        {
            Item.useStyle = ItemUseStyleID.Swing;
        }
        public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.damage = 40;
				Item.shoot = ModContent.ProjectileType<LeviathanAxeProj>();
				Item.shootSpeed = 10;
				Item.noUseGraphic = true;
				Item.autoReuse = true;
				Item.useTime = 15; //15
				Item.useAnimation = 15; //15
			}
			else
			{
				Item.shoot = 0;
                Item.damage = 40;
                Item.noUseGraphic = false;
				Item.autoReuse = true;
				Item.useTime = 15; //15
				Item.useAnimation = 15; //15
			}
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}