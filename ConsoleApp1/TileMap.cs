using SFML.System;
using System;

namespace DarkTown
{
	internal class TileMap
	{
		//массив заначений света от -128 до 127  
		public sbyte[] Light;
		//массив тайлов.
		public Tile[] tiles;

		//количество тайлов по X
		int Widht;
		//количество тайлов по Y
		int Heihgt;
		public TileMap(int widht,int heihgt) 
		{
			Widht = widht;
			Heihgt = heihgt;
			tiles = new Tile[Widht * Heihgt];
			Light = new sbyte[Widht * Heihgt];
		}

		//создаёт тайл мап присваивая занчение массивам 
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
