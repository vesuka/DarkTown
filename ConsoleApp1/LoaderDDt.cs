using System.Collections.Generic;
using System.IO;

namespace DarkTown
{
	/// <summary>
	/// класс для загрузки файлов .ddt
	/// </summary>
	internal static class LoaderDDt
	{
		#region Methods
		#region Standart load and save.
		/// <summary>
		/// Загружает элемент из файла. 
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <returns>Экземпляр обобщенного типа.</returns>
		public static Item LoadItem<Item>(string path) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			Item item = new();
			item.Load(binaryReader);
			binaryReader.Close();
			return item;
		}

		/// <summary>
		/// Загружает элемент из файла.
		/// </summary>
		/// <typeparam name="Item">Экземпляр обобщенного типа.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <returns></returns>
		public static Item LoadItem<Item>(BinaryReader reader) where Item : ILoadedDDt, new()
		{
			Item item = new();
			item.Load(reader);
			return item;
		}

		/// <summary>
		/// Загружает массив элементов из файла.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItems<Item>(string path) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			List<Item> items = new();
			while (binaryReader.BaseStream.Length != binaryReader.BaseStream.Position)
			{
				items.Add(LoadItem<Item>(binaryReader));
			}
			binaryReader.Close();
			return items.ToArray();
		}

		/// <summary>
		/// Загружает массив элементов из файла.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItems<Item>(BinaryReader reader) where Item : ILoadedDDt, new()
		{
			List<Item> items = new();
			while (reader.BaseStream.Length != reader.BaseStream.Position)
			{
				items.Add(LoadItem<Item>(reader));
			}
			return items.ToArray();
		}

		/// <summary>
		/// Загружает массив элементов из файла.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="count">Количество загружаемых объектов.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItems<Item>(string path, int count) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			Item[] items = new Item[count];
			for (int i = 0; i < count; i++)
			{
				items[i] = LoadItem<Item>(binaryReader);
			}
			binaryReader.Close();
			return items;
		}

		/// <summary>
		/// Загружает массив элементов из файла.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <param name="count">Количество загружаемых объектов.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItems<Item>(BinaryReader reader, int count) where Item : ILoadedDDt, new()
		{
			Item[] items = new Item[count];
			for (int i = 0; i < count; i++)
			{
				items[i] = (LoadItem<Item>(reader));
			}
			return items;
		}



		/// <summary>
		/// Сохраняет элемент в файл.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="item">Сохраняемый объект.</param>
		/// <param name="path">Путь к файлу.</param>
		public static void SaveItem<Item>(Item item, string path) where Item : ILoadedDDt, new()
		{

			using BinaryWriter binaryWriter = new(File.Open(path, FileMode.Create));
			item.Save(binaryWriter);
			binaryWriter.Flush();
			binaryWriter.Close();
		}

		/// <summary>
		/// Сохраняет элемент в файл.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="item">Сохраняемый объект.</param>
		/// <param name="binaryWriter">Писарь.</param>
		public static void SaveItem<Item>(Item item, BinaryWriter binaryWriter) where Item : ILoadedDDt, new()
		{
			item.Save(binaryWriter);
		}

		/// <summary>
		/// Сохраняет массив элементов в файл.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="items">Массив сохраняемых в файл объектов.</param>
		/// <param name="path">Путь к файлу</param>
		public static void SaveItems<Item>(Item[] items, string path) where Item : ILoadedDDt, new()
		{
			using BinaryWriter binaryWriter = new(File.Open(path, FileMode.Create));
			for (int i = 0; i < items.Length; i++)
			{
				items[i].Save(binaryWriter);
			}
			binaryWriter.Flush();
			binaryWriter.Close();
		}

		/// <summary>
		/// Сохраняет массив элементов в файл.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="items">Массив сохраняемых в файл объектов.</param>
		/// <param name="binaryWriter">Писарь.</param>
		public static void SaveItems<Item>(Item[] items, BinaryWriter binaryWriter) where Item : ILoadedDDt, new()
		{
			for (int i = 0; i < items.Length; i++)
			{
				items[i].Save(binaryWriter);
			}
		}

		#endregion

		#region Template load and save.

		// перегрузки Item LoadItemWithTemplate.

		/// <summary>
		/// Загружает элемент из файла. Считывает и загружает по шаблону. 
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <returns>Экземпляр обобщенного типа.</returns>
		public static Item LoadItemWithTemplate<Item>(string path) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			Item item = new();
			item.LoadWithTemplate(binaryReader, binaryReader.ReadString());
			binaryReader.Close();
			return item;
		}

		/// <summary>
		/// Загружает элемент из файла. Загружает по переданному шаблону. 
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="template">Шаблон</param>
		/// <returns>Экземпляр обобщенного типа.</returns>
		public static Item LoadItemWithTemplate<Item>(string path,string template) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			Item item = new();
			item.LoadWithTemplate(binaryReader, template);
			binaryReader.Close();
			return item;
		}

		/// <summary>
		/// Загружает элемент из файла. Считывает и загружает по шаблону.
		/// </summary>
		/// <typeparam name="Item">Экземпляр обобщенного типа.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <returns></returns>
		public static Item LoadItemWithTemplate<Item>(BinaryReader reader) where Item : ILoadedDDt, new()
		{
			Item item = new();
			item.LoadWithTemplate(reader, reader.ReadString());
			return item;
		}

		/// <summary>
		/// Загружает элемент из файла. Загружает по переданному шаблону.
		/// </summary>
		/// <typeparam name="Item">Экземпляр обобщенного типа.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <param name="template">Шаблон.</param>
		/// <returns></returns>
		public static Item LoadItemWithTemplate<Item>(BinaryReader reader,string template) where Item : ILoadedDDt, new()
		{
			Item item = new();
			item.LoadWithTemplate(reader, template);
			return item;
		}

		//перегрузки Item[] LoadItemsWithTemplate.

		/// <summary>
		/// Загружает массив элементов из файла. Перед каждым элементом должен быть его шаблон.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItemsWithTemplate<Item>(string path) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			List<Item> items = new();
			while (binaryReader.BaseStream.Length != binaryReader.BaseStream.Position)
			{
				items.Add(LoadItemWithTemplate<Item>(binaryReader));
			}
			binaryReader.Close();
			return items.ToArray();
		}

		/// <summary>
		/// Загружает массив элементов из файла. Перед каждым элементом должен быть его шаблон.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItemsWithTemplate<Item>(BinaryReader reader) where Item : ILoadedDDt, new()
		{
			List<Item> items = new();
			while (reader.BaseStream.Length != reader.BaseStream.Position)
			{
				items.Add(LoadItemWithTemplate<Item>(reader));
			}
			return items.ToArray();
		}

		/// <summary>
		/// Загружает массив элементов из файла. Перед каждым элементом должен быть его шаблон.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="count">Количество загружаемых объектов.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItemsWithTemplate<Item>(string path, int count) where Item : ILoadedDDt, new()
		{
			using BinaryReader binaryReader = new(File.OpenRead(path));
			Item[] items = new Item[count];
			for (int i = 0; i < count; i++)
			{
				items[i] = LoadItemWithTemplate<Item>(binaryReader);
			}
			binaryReader.Close();
			return items;
		}

		/// <summary>
		/// Загружает массив элементов из файла. Перед каждым элементом должен быть его шаблон.
		/// </summary>
		/// <typeparam name="Item">Тип читаемый из файла.</typeparam>
		/// <param name="reader">Чтец.</param>
		/// <param name="count">Количество загружаемых объектов.</param>
		/// <returns>Массив Item.</returns>
		public static Item[] LoadItemsWithTemplate<Item>(BinaryReader reader, int count) where Item : ILoadedDDt, new()
		{
			Item[] items = new Item[count];
			for (int i = 0; i < count; i++)
			{
				items[i] = LoadItemWithTemplate<Item>(reader);
			}
			return items;
		}

		//

		/// <summary>
		/// Сохраняет элемент в файл. Записывает шаблон из экземпляра.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="item">Сохраняемый объект.</param>
		/// <param name="path">Путь к файлу.</param>
		public static void SaveItemWithTemplate<Item>(Item item, string path) where Item : ILoadedDDt, new()
		{
			using BinaryWriter binaryWriter = new(File.Open(path, FileMode.Create));
			binaryWriter.Write(item.GetTemplate());
			item.Save(binaryWriter);
			binaryWriter.Flush();
			binaryWriter.Close();
		}

		/// <summary>
		/// Сохраняет элемент в файл. Записывает шаблон из экземпляра.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="item">Сохраняемый объект.</param>
		/// <param name="binaryWriter">Писарь.</param>
		public static void SaveItemWithTemplate<Item>(Item item, BinaryWriter binaryWriter) where Item : ILoadedDDt, new()
		{
			binaryWriter.Write(item.GetTemplate());
			item.Save(binaryWriter);
		}

		/// <summary>
		/// Сохраняет массив элементов в файл. Записывает шаблон из экземпляра перед каждым элементом.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="items">Массив сохраняемых в файл объектов.</param>
		/// <param name="path">Путь к файлу</param>
		public static void SaveItemsWithTemplate<Item>(Item[] items, string path) where Item : ILoadedDDt, new()
		{
			using BinaryWriter binaryWriter = new(File.Open(path, FileMode.Create));
			for (int i = 0; i < items.Length; i++)
			{
				binaryWriter.Write(items[i].GetTemplate());
				items[i].Save(binaryWriter);
			}
			binaryWriter.Flush();
			binaryWriter.Close();
		}

		/// <summary>
		/// Сохраняет массив элементов в файл. Записывает шаблон из экземпляра перед каждым элементом.
		/// </summary>
		/// <typeparam name="Item">Тип сохраняемый в файл.</typeparam>
		/// <param name="items">Массив сохраняемых в файл объектов.</param>
		/// <param name="binaryWriter">Писарь.</param>
		public static void SaveItemsWithTemplate<Item>(Item[] items, BinaryWriter binaryWriter) where Item : ILoadedDDt, new()
		{
			for (int i = 0; i < items.Length; i++)
			{
				binaryWriter.Write(items[i].GetTemplate());
				items[i].Save(binaryWriter);
			}
		}
		#endregion
		#endregion


		/// <summary>
		/// Интерфейс для взаимодействия класса и LoaderDDt.
		/// </summary>
		public interface ILoadedDDt
		{
			/// <summary>
			/// Метод для чтения.
			/// </summary>
			/// <param name="reader">Чтец.</param>
			public void Load(BinaryReader reader);

			public void LoadWithTemplate(BinaryReader reader, string template);

			/// <summary>
			/// Метод для сохранения.
			/// </summary>
			/// <param name="writer">Писарь.</param>
			public void Save(BinaryWriter writer);

			public void SaveWithTemplate(BinaryWriter writer, string template);

			public string GetTemplate();
		}

	}
}
