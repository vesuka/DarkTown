using SFML.System;
using System;
using System.IO;

namespace DarkTown
{
	/// <summary>
	/// Карта тайлов.
	/// </summary>
	internal class TileMap : LoaderDDt.ILoadedDDt
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

		public TileMap()
		{
			Width = 0; Height = 0;
			tiles = Array.Empty<Tile>();
			Light = Array.Empty<sbyte>();

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
					Resources.texturesToName["Back-1.png"],
					new Vector2f(program.OneUnitFactorWidth, program.OneUnitFactorHeight),
					new Vector2f(i % Width * program.OneUnit * program.OneUnitFactorWidth, i / Width * program.OneUnit * program.OneUnitFactorHeight),
					Resources.texturesToName["Dark.png"],
					Resources.texturesToName["partOfDarkness-export.png"]
					);
				program.layer.Add(tiles[i]);
			}
		}

		public void Load(BinaryReader binaryReader)
		{
			tiles = LoaderDDt.LoadItems<Tile>(binaryReader, binaryReader.ReadInt32());
		}
		public void Save(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(tiles.Length);
			LoaderDDt.SaveItems(tiles, binaryWriter);
		}
		#endregion
	}
}
