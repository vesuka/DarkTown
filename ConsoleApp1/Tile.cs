using SFML.Graphics;

namespace DarkTown
{
	/// <summary>
	/// Единичный тайл.
	/// </summary>
	internal class Tile : Drawable
	{
		#region Fields
		/// <summary>
		/// Объект класса BackGround.
		/// </summary>
		public BackGround backGround;

		public Bild? building;

		/// <summary>
		/// Уровень освещения тайла.
		/// </summary>
		public sbyte LightLevel;

		/// <summary>
		/// Спрайт тьмы.
		/// </summary>
		private readonly Sprite dark;

		/// <summary>
		/// Спрайт светлой тьмы.
		/// </summary>
		private readonly Sprite lightDark;

		/// <summary>
		/// Приватный вектор размера тайла.
		/// </summary>
		private SFML.System.Vector2f scale;

		/// <summary>
		/// Приватный вектор позиции.
		/// </summary>
		private SFML.System.Vector2f position;
		#endregion

		#region Properties
		/// <summary>
		/// Свойство вектора размера тайла.
		/// </summary>
		/// <seealso cref="scale"/>
		public SFML.System.Vector2f Scale
		{
			get { return scale; }

			//присваивание значений для подопечных объектов
			set
			{
				scale = value;
				backGround.Sprite.Scale = value;
				lightDark.Scale = value;
				dark.Scale = value;
			}
		}

		/// <summary>
		/// Свойство вектора позиции.
		/// </summary>
		/// <seealso cref="position"/>
		public SFML.System.Vector2f Position
		{
			get { return position; }
			//присваивание значений для подопечных объектов
			set
			{
				position = value;
				backGround.Sprite.Position = value;
				lightDark.Position = value;
				dark.Position = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Конструктор Program.
		/// </summary>
		/// <param name="back">Объект заднего фона.</param>
		/// <param name="Scale">Вектор размерности тайла.</param>
		/// <param name="Position">Вектор позиции тайла.</param>
		/// <param name="dark">Текстура для создания спрайта тьмы.</param>
		/// <param name="lightDark">Текстура для создания светлой тьмы.</param>
		public Tile(BackGround back, SFML.System.Vector2f Scale, SFML.System.Vector2f Position, Texture dark, Texture lightDark)
		{
			backGround = back;
			this.dark = new Sprite(dark);
			this.lightDark = new Sprite(lightDark);

			this.Scale = Scale;
			this.Position = Position;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Отрисовывает тайл.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="states"></param>
		public void Draw(RenderTarget target, RenderStates states)
		{
			backGround.Draw(target, states);
			building?.Draw(target, states);

			if (LightLevel <= 0) dark.Draw(target, states);
			else if (LightLevel > 0 && LightLevel <= 5) lightDark.Draw(target, states);
		}
		#endregion
	}
}
