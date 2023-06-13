using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;

namespace assasinmod.Global
{
	public class GlobNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc,NPCLoot npcLoot)
		{
			if(npc.type == NPCID.Zombie){
                npcLoot.Add(ItemDropRule.Common(ItemID.TatteredCloth, Main.rand.Next(0,2)));
            }
		}
	}
}