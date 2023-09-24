using SFML.System;
using System;

namespace DarkTown
{
	internal class TileMap
	{
		public sbyte[] Light;
		public Tile[] tiles;

		int Widht;
		int Heihgt;
		public TileMap(int widht,int heihgt) 
		{
			Widht = widht;
			Heihgt = heihgt;
			tiles = new Tile[Widht * Heihgt];
			Light = new sbyte[Widht * Heihgt];
		}
		public void GenerateTileMap(Program program)
		{
			for (int i = 0; i < tiles.Length; i++)
			{
				tiles[i] = new Tile(
					new BackGround(program.texturesToName["Back-1"]),
					new Vector2f(Program.OneUnitFactorWidth, Program.OneUnitFactorHeight),
					new Vector2f(i % Widht *Program.OneUnit * Program.OneUnitFactorWidth, i / Widht * Program.OneUnit * Program.OneUnitFactorHeight),
					program.texturesToName["Dark"],
					program.texturesToName["LightDark"]
					);
				program.layer.Add(tiles[i]);
			}
		}
	}
}
