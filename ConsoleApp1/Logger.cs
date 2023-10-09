using System;
using System.Diagnostics;
using System.IO;

namespace DarkTown
{

	public static class Logger
	{
		private static string logData = "";

		/// <summary>
		/// Выводит данные.
		/// </summary>
		/// <param name="data">Объект логирования.</param>
		public static void Log(object? data)
		{
			logData += $"time:{DateTime.Now};Data:{data?.ToString()};process:{Process.GetCurrentProcess().ProcessName}";
			logData += Environment.NewLine;
		}

		/// <summary>
		/// Сохраняет данные лога.
		/// </summary>
		/// <param name="path">Путь к файлу.</param>
		public static void Save(string path)
		{
			StreamWriter writer = new(path, false);
			writer.WriteLine(logData);
			writer.Close();
		}
	}
}
