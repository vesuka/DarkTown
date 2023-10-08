using SFML.System;

namespace DarkTown
{
	/// <summary>
	/// Карта тайлов.
	/// </summary>
	internal class TileMap
	{
		#region Fields
		/// <summary>
		/// Массив значений света.
		/// </summary>
		public sbyte[] Light;

		/// <summary>
		/// Массив тайлов.
		/// </summary>
		public Tile[] tiles;

		/// <summary>
		/// Ширина карты тайлов.
		/// </summary>
		readonly uint Width;

		/// <summary>
		/// Высота карты тайлов.
		/// </summary>
		readonly uint Height;
		#endregion

		#region Constructors
		/// <summary>
		/// Создаёт новый карты тайлов.
		/// </summary>
		/// <param name="width">Ширина карты тайлов.</param>
		/// <param name="height">Высота карты тайлов.</param>
		public TileMap(uint width, uint height)
		{
			Width = width;
			Height = height;
			tiles = new Tile[Width * Height];
			Light = new sbyte[Width * Height];
		}
		#endregion

		#region Methods
		/// <summary>
		/// Присваивает значение свету и тайлам.
		/// </summary>
		/// <param name="program">Экземпляр класса Program</param>
		public void GenerateTileMap(Program program)
		{
			for (int i = 0; i < tiles.Length; i++)
			{
				tiles[i] = new Tile(
					new BackGround(program.texturesToName["Back-1.png"]),
					new Vector2f(program.OneUnitFactorWidth, program.OneUnitFactorHeight),
					new Vector2f(i % Width * program.OneUnit * program.OneUnitFactorWidth, i / Width * program.OneUnit * program.OneUnitFactorHeight),
					program.texturesToName["Dark.png"],
					program.texturesToName["partOfDarkness-export.png"]
					);
				program.layer.Add(tiles[i]);
			}
		}
		#endregion
	}
}
