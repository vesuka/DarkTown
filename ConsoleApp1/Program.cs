using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
namespace DarkTown
{
	internal class Program
	{
		public static float OneUnitFactorWidth;
		public static float OneUnitFactorHeight;

		public static float OneUnit = 32;

		public RenderWindow window = new(VideoMode.FullscreenModes[0],"Test",Styles.Fullscreen);

		public Dictionary<string, Texture> texturesToName = new()
		{
			{"Back-1", new("Resurs\\Back-1.png")},
			{"LightDark", new("Resurs\\partOfDarkness-export.png")},
			{"Dark", new("Resurs\\Dark.png")}
		};

		public List<Drawable> layer = new();

		public Program()
		{
			OneUnitFactorHeight = VideoMode.FullscreenModes[0].Height / (OneUnit * 9);
			OneUnitFactorWidth = VideoMode.FullscreenModes[0].Width / (OneUnit * 16);
		}
		static void Main()
		{
			Program program = new Program();

			TileMap tileMap = new TileMap(16, 3);
			tileMap.GenerateTileMap(program);

			OneUnitFactorHeight = VideoMode.FullscreenModes[0].Height / (OneUnit * 9);
			OneUnitFactorWidth = VideoMode.FullscreenModes[0].Width / (OneUnit * 16);
			
			/*void Button(object? sender, KeyEventArgs e)
			{
				if(e.Code == Keyboard.Key.Enter)
				{
					for(int i = 0; i < tileMap.Light.Length; i++)
					{
						tileMap.Light[i]++;
						tileMap.tiles[i].LightLevel = tileMap.Light[i];
					}
				}
			}*/

			program.window.Closed += program.close;
			program.window.KeyPressed += program.ButtonPresed;
			program.window.MouseButtonPressed += program.MouseDown;
			//program.window.KeyPressed += Button;
			program.window.SetVerticalSyncEnabled(true);



			while (program.window.IsOpen)
			{
				program.window.DispatchEvents();
				
				program.window.Clear(Color.Blue);
				for (int i = 0; i < program.layer.Count; i++) program.window.Draw(program.layer[i]);
				program.window.Display();
			}
		}
		void MouseDown(object? sender,MouseButtonEventArgs mouse)
		{

		}
		void ButtonPresed(object? sender, KeyEventArgs keys)
		{
			if (keys.Code == Keyboard.Key.Escape) window.Close();
		}
		void close(object? sender, EventArgs key)
		{
			window.Close();
		}
	}
}