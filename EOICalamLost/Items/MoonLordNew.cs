using Terraria.ModLoader;

namespace EOICalamLost.Items
{
	public class MoonLordNew : ModItem
	{
		public override void SetStaticDefaults() => DisplayName.SetDefault("Music Box (Impending Doom)");

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.MoonLordNewTile>();
			item.width = 24;
			item.height = 24;
			item.rare = 4;
			item.value = 100000;
			item.accessory = true;
		}
	}
}