using EOICalamLost.Items;
using EOICalamLost.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace EOICalamLost
{
	
	public class EOICalamLost : Mod
	{
		private Texture2D musicBoxes;

		public bool unloadCalled = false;

		public override void Load()
		{
			unloadCalled = false;

			musicBoxes = Main.tileTexture[TileID.MusicBoxes];

			if (!Main.dedServ)
			{
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/GolemBoss"), ModContent.ItemType<GolemNew>(), ModContent.TileType<GolemNewTile>());
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/PlantBoss"), ModContent.ItemType<PlanteraNew>(), ModContent.TileType<PlanteraNewTile>());
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/MoonLord"), ModContent.ItemType<MoonLordNew>(), ModContent.TileType<MoonLordNewTile>());
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Planetoids"), ModContent.ItemType<Planetoids>(), ModContent.TileType<PlanetoidsTile>());
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/EidolonWyrm"), ModContent.ItemType<Eidolon>(), ModContent.TileType<EidolonTile>());
			}
		}


		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.musicVolume != 0)
			{
				if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
				{
					//Bosses
					if (Main.npc.Any(n => n.active && n.boss))
					{
					        if (NPC.AnyNPCs(NPCID.Golem))
					        {
						        music = GetSoundSlot(SoundType.Music, "Sounds/Music/GolemBoss");
						        priority = MusicPriority.BossHigh;
					        }
					        if (NPC.AnyNPCs(NPCID.Plantera) || NPC.AnyNPCs(NPCID.PlanterasHook) || NPC.AnyNPCs(NPCID.PlanterasTentacle))
					        {
						        music = GetSoundSlot(SoundType.Music, "Sounds/Music/PlantBoss");
						        priority = MusicPriority.BossHigh;
					        }
					        if (NPC.AnyNPCs(NPCID.MoonLordCore))
					        {
						        music = GetSoundSlot(SoundType.Music, "Sounds/Music/MoonLord");
						        priority = MusicPriority.BossHigh;
					        }
					}
					else
					{
						//space
						if (Main.LocalPlayer.position.Y / 16 <= Main.worldSurface * 0.35)
						{
							if (((Main.screenTileCounts[TileID.Dirt] > 20) || (Main.screenTileCounts[TileID.Mud] > 20) || (Main.screenTileCounts[TileID.Stone] > 20)) && (Main.screenTileCounts[TileID.Cloud] < 2))
							{
							    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Planetoids");
							    priority = MusicPriority.Environment;
							}
						}
						//Minibosses
						Mod CalamityMod = ModLoader.GetMod("CalamityMod");
                        if (CalamityMod != null)
						{
							if (NPC.AnyNPCs(CalamityMod.NPCType("EidolonWyrmHeadHuge")))
						    {
						    	music = GetSoundSlot(SoundType.Music, "Sounds/Music/EidolonWyrm");
						    	priority = MusicPriority.BossHigh;
						    }
							
						}
					}
				}
			}
		}
	}
}