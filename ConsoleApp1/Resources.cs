using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkTown
{
	internal static class Resources
	{
		public static readonly Sprite EmetrySprite = new ();

		/// <summary>
		/// Словарь объектов где ключ это строка, а значение - это класс Texture.
		/// </summary>
		/// <see cref="Texture"/>
		/// <seealso cref="Dictionary{TKey, TValue}"/>
		public static readonly Dictionary<string, Texture> texturesToName = new();


		static Resources()
		{
			string[] files = Directory.GetFiles("Resources", "*.png");

			for (int i = 0; i < files.Length; i++)
			{
				FileInfo info = new(files[i]);
				texturesToName.Add(info.Name, new Texture(files[i]));
			}
		}
		public static string GetNameTexture(Texture texture)
		{
			foreach(var file in texturesToName)
			{
				if(file.Value == texture)
				{
					return file.Key;
				}
			}
			throw new Exception("Name not found");
		}
	}
}
