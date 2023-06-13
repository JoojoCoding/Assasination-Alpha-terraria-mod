using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using CsvHelper.TypeConversion;
using assasinmod.Global;
using assasinmod.Buffs;

namespace assasinmod.Items.Weapons
{
	public class oldgoodripper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Good Ripper"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a basic modded sword.");
		}
		
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.width = 80;
			Item.height = 80;
			Item.scale = 1f;
			Item.useTime = 15;
			Item.useAnimation = 15;
            Item.crit = 0;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			var dmgline = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
			if(dmgline != null)
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
		public override void HoldItemFrame(Player player)
		{
            Item.crit = 100;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useTime = 30;
            Item.useAnimation = 30;
        }
		public override bool? UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				Item.crit = 100;
				Item.useStyle = ItemUseStyleID.Thrust;
				Item.useTime = 30;
				Item.useAnimation = 30;
            }
			else
			{
				Item.useTime = 15;
                Item.useAnimation = 15;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.crit = 0;
            }
			return true;
		}


		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, 0f, 0f, 0, new Color(186, 0, 0), 2f);//rgb(186, 0, 0)
			Main.dust[dust].noGravity = false;
			Main.dust[dust].velocity *= 0f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (player.altFunctionUse == 2)
			{
				player.statLife += 2;
                player.HealEffect(2);
            }
			target.AddBuff(ModContent.BuffType<voidcurse>(), 60 * 3);
                
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			Recipe altRecipe = CreateRecipe();
			altRecipe.AddIngredient(ItemID.MudBlock, 10);
			altRecipe.AddTile(TileID.WorkBenches);
			altRecipe.Register();
		}
	}
}