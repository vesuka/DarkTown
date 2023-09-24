using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkTown
{
	internal class BackGround : Drawable
	{
		//объект sprite для вывода изоброжение 
		private readonly Sprite sprite;

		//свойство для публичного предстовление sprite
		public Sprite Sprite { get { return sprite; } }
		public BackGround(Texture texture)
		{
			sprite = new Sprite(texture);
		}
		// метод для вывода данных на экран
		public void Draw( RenderTarget target,RenderStates states)
		{
			sprite.Draw(target, states);
		}
	}
}
