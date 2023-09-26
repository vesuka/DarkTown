﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkTown
{
	internal class BackGround : Drawable
	{
		/// <summary>
		/// Объект класса Sprite.
		/// </summary>
		/// <see cref="SFML.Graphics.Sprite"/>
		private readonly Sprite sprite;

		/// <summary>
		/// Свойство объекта Sprite. Позволяет только считавать значение.
		/// </summary>
		public Sprite Sprite { get { return sprite; } }

		/// <summary>
		/// Создание экземпляра класса BackGround.
		/// </summary>
		/// <param name="texture">Текстура для создания спрайта.</param>
		public BackGround(Texture texture)
		{
			sprite = new Sprite(texture);
		}

		/// <summary>
		/// Отрисовывает объект.
		/// </summary>
		public void Draw( RenderTarget target,RenderStates states)
		{
			sprite.Draw(target, states);
		}
	}
}
