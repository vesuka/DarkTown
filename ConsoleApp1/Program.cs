using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
namespace DarkTown
{
	internal class Program
	{
		#region Fields
		/// <summary>
		/// 1/16 ширины экрана в пикселях.
		/// </summary>
		public static float OneUnitFactorWidth; 

		/// <summary>
		/// 1/9 высоты экрана в пикселях.
		/// </summary>
		public static float OneUnitFactorHeight;

		/// <summary>
		/// Цена деления экрана.
		/// </summary>
		public static float OneUnit = 32; 

		/// <summary>
		/// Основное окно.
		/// </summary>
		public RenderWindow window = new(VideoMode.FullscreenModes[0],"Test",Styles.Fullscreen);

		/// <summary>
		/// Словарь объектов где ключ это сторока, а значение - это класс Texture.
		/// </summary>
		/// <see cref="Texture"/>
		/// <seealso cref="Dictionary{TKey, TValue}"/>
		public Dictionary<string, Texture> texturesToName = new()
		{
			{"Back-1", new("Resurs\\Back-1.png")},
			{"LightDark", new("Resurs\\partOfDarkness-export.png")},
			{"Dark", new("Resurs\\Dark.png")}
		};

		/// <summary>
		/// Список объектов интерфейса Dwarable для вывода их на экран.
		/// </summary>
		/// <see cref="Drawable"/>
		public List<Drawable> layer = new();
		#endregion

		#region Constructors
		/// <summary>
		/// Создание экземпляра Program.
		/// </summary>
		public Program()
		{
			//просто задаёт значение переменных
			OneUnitFactorHeight = VideoMode.FullscreenModes[0].Height / (OneUnit * 9);
			OneUnitFactorWidth = VideoMode.FullscreenModes[0].Width / (OneUnit * 16);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Точка входа программы.
		/// </summary>
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
			program.window.Closed += program.CloseWindow;
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

		/// <summary>
		/// Обрабатывает нажатие кнопок мыши(в разработке).
		/// </summary>
		/// <param name="sender">Объект который вызывает событие.</param>
		/// <param name="mouse">Объект KeyEventArgs.</param>
		void MouseDown(object? sender,MouseButtonEventArgs mouse)
		{

		}

		/// <summary>
		/// Обрабатывает нажатия клавиш.
		/// </summary>
		/// <param name="sender">Объект который вызывает событие.</param>
		/// <param name="keys">Объект KeyEventArgs.</param>
		void ButtonPresed(object? sender, KeyEventArgs keys)
		{
			//если нажатая кравиша эскейп то закрыть окно. 
			if (keys.Code == Keyboard.Key.Escape) window.Close();
		}

		/// <summary>
		/// При вызове закрывает окно.
		/// </summary>
		/// <param name="sender">Объект который вызывает событие.</param>
		/// <param name="key">Объект EventArgs.</param>
		/// <see cref="EventArgs"/>
		void CloseWindow(object? sender, EventArgs key)
		{
			window.Close();
		}
		#endregion
	}
}