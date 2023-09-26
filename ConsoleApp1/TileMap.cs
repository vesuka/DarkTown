using SFML.System;
using System;

namespace DarkTown
{
	internal class TileMap
	{
		/// <summary>
		/// Массив значений света.
		/// </summary>
		public sbyte[] Light;
		
		/// <summary>
		/// Массив тайлов.
		/// </summary>
		public Tile[] tiles;

		/// <summary>
		/// Ширина тайла мапа.
		/// </summary>
		uint Widht;
		
		/// <summary>
		/// Высота тайл мапа.
		/// </summary>
		uint Heihgt;

		/// <summary>
		/// Создаёт новый тайл мап.
		/// </summary>
		/// <param name="widht">Ширина тайл мапа.</param>
		/// <param name="heihgt">Высота тайл мапа.</param>
		public TileMap(uint widht,uint heihgt) 
		{
			Widht = widht;
			Heihgt = heihgt;
			tiles = new Tile[Widht * Heihgt];
			Light = new sbyte[Widht * Heihgt];
		}

		/// <summary>
		/// Присваевает значение Свету и тайлам.
		/// </summary>
		/// <param name="program">Экземляр класса Прогам</param>
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
