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
		public BackGround backGround;

		public sbyte LightLevel;

		private Sprite dark;
		private Sprite lightDark;


		SFML.System.Vector2f scale;
		public SFML.System.Vector2f Scale 
		{
			get { return scale;}
			set 
			{	
				scale = value;
				backGround.Sprite.Scale = value;
				lightDark.Scale = value;
				dark.Scale = value;
			}
		}
		SFML.System.Vector2f position;
		public SFML.System.Vector2f Position
		{
			get { return position; }
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
		public void Draw(RenderTarget target,RenderStates states)
		{
			backGround.Draw(target, states);

			if(LightLevel <= 0) dark.Draw(target, states);
			else if(LightLevel > 0 && LightLevel <=5) lightDark.Draw(target, states);
		}
	}
}
