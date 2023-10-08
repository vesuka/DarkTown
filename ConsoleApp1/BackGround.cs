using SFML.Graphics;

namespace DarkTown
{
	/// <summary>
	/// Класс заднего фона для тайлов.
	/// </summary>
	internal class BackGround : Drawable
	{
		#region Fields
		/// <summary>
		/// Объект класса Sprite.
		/// </summary>
		/// <see cref="SFML.Graphics.Sprite"/>
		private readonly Sprite sprite;

		/// <summary>
		/// Свойство объекта Sprite. Позволяет только считавать значение.
		/// </summary>
		public Sprite Sprite { get { return sprite; } }
		#endregion

		#region Constructors
		/// <summary>
		/// Создание экземпляра класса BackGround.
		/// </summary>
		/// <param name="texture">Текстура для создания спрайта.</param>
		public BackGround(Texture texture)
		{
			sprite = new Sprite(texture);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Отрисовывает объект.
		/// </summary>
		public void Draw(RenderTarget target, RenderStates states)
		{
			sprite.Draw(target, states);
		}
		#endregion
	}
}
