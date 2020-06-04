using Terraria.ModLoader;

namespace EOICalamLost.Items
{
	public class PlanteraNew : ModItem
	{
		public override void SetStaticDefaults() => DisplayName.SetDefault("Music Box (Plantera)");

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.PlanteraNewTile>();
			item.width = 24;
			item.height = 24;
			item.rare = 4;
			item.value = 100000;
			item.accessory = true;
		}
	}
}