using SFML.Graphics;

namespace DarkTown
{
	/// <summary>
	/// Обновляемый интерфейс.
	/// </summary>
	internal interface IUpdates : Drawable
	{
		/// <summary>
		/// Обновление во время шага.
		/// </summary>
		public void StepUpdate();
		/// <summary>
		/// Обновление во время доли шага.
		/// </summary>
		public void StepFractionUpdate();
	}
}
