using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
namespace DarkTown
{
	internal class Program
	{
		public static float OneUnitFactorWidth; // при умножении на него даёт 1/16 ширины экрана экрана
		public static float OneUnitFactorHeight;// при умножении на него даёт 1/9 высоты экрана

		public static float OneUnit = 32; // размер в пикселях "еденично" разметки экрана

		//Создание окна.
		public RenderWindow window = new(VideoMode.FullscreenModes[0],"Test",Styles.Fullscreen);

		//Словарь текстур
		public Dictionary<string, Texture> texturesToName = new()
		{
			{"Back-1", new("Resurs\\Back-1.png")},
			{"LightDark", new("Resurs\\partOfDarkness-export.png")},
			{"Dark", new("Resurs\\Dark.png")}
		};

		//"слой" посути просто список объектов с интерфейсом.Нужет для вывода изоброжений на экран.
		public List<Drawable> layer = new();

		public Program()
		{
			//просто задаёт значение переменных
			OneUnitFactorHeight = VideoMode.FullscreenModes[0].Height / (OneUnit * 9);
			OneUnitFactorWidth = VideoMode.FullscreenModes[0].Width / (OneUnit * 16);
		}
		static void Main()
		{
			//просто объект програм
			Program program = new Program();

			//класс нужный для создания набора плиток и коректного их отоброжения.
			TileMap tileMap = new TileMap(16, 3);
			tileMap.GenerateTileMap(program);

			//НЕ нужный код. Но может пригодиться.
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

			//подписка на все нужные события
			program.window.Closed += program.close;
			program.window.KeyPressed += program.ButtonPresed;
			program.window.MouseButtonPressed += program.MouseDown;
			//program.window.KeyPressed += Button;
			program.window.SetVerticalSyncEnabled(true);


			//основной цикл программы
			while (program.window.IsOpen)
			{
				//нужная сточка для вызова всех событий
				program.window.DispatchEvents();
				
				// очистка ока и заливка в синий
				program.window.Clear(Color.Blue);

				//отрисовка всех объектов
				for (int i = 0; i < program.layer.Count; i++) program.window.Draw(program.layer[i]);

				//сброс буфера на экран(сложная штука)
				program.window.Display();
			}
		}

		//оброботьчик нажатия кнопок мыши(в разроботке)
		void MouseDown(object? sender,MouseButtonEventArgs mouse)
		{

		}

		//оброботьчик нажатия клавиш.
		void ButtonPresed(object? sender, KeyEventArgs keys)
		{
			//если нажатая кравиша эскейп то закрыть окно. 
			if (keys.Code == Keyboard.Key.Escape) window.Close();
		}
		
		//закрывает окно при нажатии на крестик
		void close(object? sender, EventArgs key)
		{
			window.Close();
		}
	}
}