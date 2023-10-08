﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
namespace DarkTown
{
	/// <summary>
	/// Класс программы.Хранит поля для игры и работы движка.
	/// </summary>
	internal class Program
	{
		#region Fields
		/// <summary>
		/// 1/16 ширины экрана в пикселях.
		/// </summary>
		public float OneUnitFactorWidth;

		/// <summary>
		/// 1/9 высоты экрана в пикселях.
		/// </summary>
		public float OneUnitFactorHeight;

		/// <summary>
		/// Цена деления экрана.
		/// </summary>
		public float OneUnit = 32;

		/// <summary>
		/// Основное окно.
		/// </summary>
		public RenderWindow window = new(VideoMode.FullscreenModes[0], "Test", Styles.Fullscreen);

		/// <summary>
		/// Словарь объектов где ключ это сторока, а значение - это класс Texture.
		/// </summary>
		/// <see cref="Texture"/>
		/// <seealso cref="Dictionary{TKey, TValue}"/>
		public Dictionary<string, Texture> texturesToName = new();

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
			string[] files = Directory.GetFiles("Resurs", "*.png");

			for (int i = 0; i < files.Length; i++)
			{
				FileInfo info = new(files[i]);
				texturesToName.Add(info.Name, new Texture(files[i]));
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Точка входа программы.
		/// </summary>
		static void Main()
		{
			try
			{
				//просто объект програм
				Program program = new();


				//класс нужный для создания набора плиток и коректного их отоброжения.
				TileMap tileMap = new(16, 3);
				tileMap.GenerateTileMap(program);

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
			catch (Exception e)
			{
				Loger.Log(e);
			}

			//Сохранение данных лога.
			Loger.Save("Log.txt");
		}

		/// <summary>
		/// Обрабатывает нажатие кнопок мыши(в разработке).
		/// </summary>
		/// <param name="sender">Объект который вызывает событие.</param>
		/// <param name="mouse">Объект KeyEventArgs.</param>
		void MouseDown(object? sender, MouseButtonEventArgs mouse)
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