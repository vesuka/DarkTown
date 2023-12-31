﻿using SFML.Graphics;

namespace DarkTown
{
	/// <summary>
	/// Постройка на тайле.
	/// </summary>
	internal class Bild : Drawable
	{
		#region Fields

		/// <summary>
		///	 Локальное поле спрайта.
		/// </summary>
		private readonly Sprite sprite;

		/// <summary>
		/// Экземпляры интерфейса. Отрисовываются.
		/// </summary>
		public IUpdates[]? updates;

		/// <summary>
		/// Локальная переменная размера.
		/// </summary>
		private SFML.System.Vector2f scale;

		/// <summary>
		/// Локальная позиция объекта.
		/// </summary>
		private SFML.System.Vector2f position;

		#endregion

		#region Properties

		/// <summary>
		/// Считывает спрайт.
		/// </summary>
		public Sprite Sprite { get { return sprite; } }
		/// <summary>
		/// Свойство позиции.
		/// </summary>
		public SFML.System.Vector2f Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
				sprite.Position = value;
			}
		}
		/// <summary>
		/// Свойство размера.
		/// </summary>
		public SFML.System.Vector2f Scale
		{
			get
			{
				return scale;
			}
			set
			{
				scale = value;
				sprite.Scale = value;
			}
		}

		#endregion

		#region Constructors
		/// <summary>
		/// Конструктор. Определяет все поля.
		/// </summary>
		/// <param name="texture">Текстура для создания спрайта.</param>
		/// <param name="updates">Экземпляры интерфейса.</param>
		public Bild(Texture texture, IUpdates[]? updates)
		{
			sprite = new Sprite(texture);
			this.updates = updates;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Метод отрисовки.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="states"></param>
		public void Draw(RenderTarget target, RenderStates states)
		{
			sprite.Draw(target, states);
			for (int i = 0; i < updates?.Length; i++) updates[i].Draw(target, states);
		}
		#endregion
	}
}
