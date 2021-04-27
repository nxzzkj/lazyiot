using System;
using System.Drawing;
namespace Scada.Controls
{
	/// <summary>
	/// Describes the interface of an element participating
	///  in the UI
	/// </summary>
	public interface INUIElement : INElement
	{
		/// <summary>
		/// Gets or sets the text
		/// </summary>
		string Text {get; set;}
		/// <summary>
		/// Gets or sets the darker color of the gradient
		/// </summary>
		Color DarkColor {get;set;}
		/// <summary>
		/// Gets or set the lighter color of the gradient
		/// </summary>
		Color LightColor {get;set;}

		/// <summary>
		/// Changes the UI style
		/// </summary>
		/// <param name="style"></param>
		//void SetStyle(UIStyle style);
		/// <summary>
		/// Changes the color scheme
		/// </summary>
		/// <param name="scheme"></param>
		//void SetColorScheme(UIColorScheme scheme);
	}
}
