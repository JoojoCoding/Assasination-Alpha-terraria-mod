using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using assasinmod.Global; 



namespace assasinmod.Items.Weapons
{
    public class seaconqueror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Conqueror");
        }
        public override void SetDefaults()
        {
            Item.height = 46;
            Item.width = 46;
            Item.damage = 100;
            Item.scale = 2f;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.crit = 20;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            //Item.shoot = ProjectileID.RainbowRodBullet;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                if (crit)
                {
                    
                    //Projectile projectile = Main.projectile[ProjectileID.Typhoon] ;
                    //Item.shoot = ProjectileID.Typhoon;
                    Item.shootSpeed = 10;
                    //Projectile.NewProjectile(projectile.GetSource_NaturalSpawn, projectile.position, projectile.velocity, ProjectileID.Typhoon, damage, knockBack, player.whoAmI);
                    int proj = Projectile.NewProjectile(default, player.Center, new Vector2(player.direction * 10f, 0f), ProjectileID.Typhoon, Item.damage, Item.knockBack, player.whoAmI);
                    //Main.projectile[proj].velocity.X += 5f;
                    Main.projectile[proj].direction = player.direction;

                }
            }
        }
    }
}
