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
		//обьект заднего фона
		public BackGround backGround;

		//значение от -128 до 127 для обозначение уровня освещения
		public sbyte LightLevel;

		//спрайт тьмы
		private Sprite dark;
		//спрайт светлой тьмы
		private Sprite lightDark;

		//мжножетель размера объекта (приватный)
		SFML.System.Vector2f scale;
		//публичное свойство множетеля размера
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
		//приватная переменая позиции
		SFML.System.Vector2f position;
		//публичное свойство позиции
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

		public Tile(BackGround back,SFML.System.Vector2f Scale,SFML.System.Vector2f Position,Texture dark,Texture lightDark)
		{
			backGround = back;
			this.dark = new Sprite(dark);
			this.lightDark = new Sprite(lightDark);

			this.Scale = Scale;
			this.Position = Position;
		}
		//метод для отрисовки
		public void Draw(RenderTarget target,RenderStates states)
		{
			backGround.Draw(target, states);

			if(LightLevel <= 0) dark.Draw(target, states);
			else if(LightLevel > 0 && LightLevel <=5) lightDark.Draw(target, states);
		}
	}
}
