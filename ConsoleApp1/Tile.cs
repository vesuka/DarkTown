using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkTown
{
	internal class Tile : Drawable
	{
		#region
		/// <summary>
		/// Объект класса BackGround.
		/// </summary>
		public BackGround backGround;

		/// <summary>
		/// Уровень освещения тайла.
		/// </summary>
		public sbyte LightLevel;

		/// <summary>
		/// Спрайт тьмы.
		/// </summary>
		private Sprite dark;
		
		/// <summary>
		/// Спрайт светлой тьмы.
		/// </summary>
		private Sprite lightDark;

		/// <summary>
		/// Приватый вектор размера тайла.
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
			get { return scale;}

			//присвание занчений для подопечных объектов
			set 
			{	
				scale = value;
				backGround.Sprite.Scale = value;
				lightDark.Scale = value;
				dark.Scale = value;
			}
		}

		/// <summary>
		/// Свойсто вектора позиции.
		/// </summary>
		/// <seealso cref="position"/>
		public SFML.System.Vector2f Position
		{
			get { return position; }
			//присвание занчений для подопечных объектов
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
		/// Конструкто Program.
		/// </summary>
		/// <param name="back">Объект заднего фона.</param>
		/// <param name="Scale">Вектор размерности тайла.</param>
		/// <param name="Position">Вектор позиции тайла.</param>
		/// <param name="dark">Текстура для создания спрайта тьмы.</param>
		/// <param name="lightDark">Текстура для создания светлой тьмы.</param>
		public Tile(BackGround back,SFML.System.Vector2f Scale,SFML.System.Vector2f Position,Texture dark,Texture lightDark)
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
		public void Draw(RenderTarget target,RenderStates states)
		{
			backGround.Draw(target, states);

			if(LightLevel <= 0) dark.Draw(target, states);
			else if(LightLevel > 0 && LightLevel <=5) lightDark.Draw(target, states);
		}
		#endregion
	}
}
